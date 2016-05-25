using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luna
{

    // Simple file exfiltration: try to write to a file as specified in mission parameters. Any issues writing the file causes it to abort and
    // forget exfiltration. Goal is to keep covert before data exfiltrate.
    public class FileExfiltrate : Luna.CovertActions.IExfiltrate
    {
        string _secretData = "";
        string _targetFile = "";

        public string secretData
        {
            get { return _secretData; }

            set { _secretData = value; }
        }

        public string targetFile
        {
            get { return _targetFile; }

            set { _targetFile = value; }
        }

                
        
        public void exfiltrateData()
        {
        }

    }

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
        }

    }
}
