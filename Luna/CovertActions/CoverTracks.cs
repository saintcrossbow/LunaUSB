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
    public sealed class CoverTracks
    {
        // Singleton pattern method
        // If not familiar with why and how, see http://csharpindepth.com/Articles/General/Singleton.aspx
        private static readonly CoverTracks instance = new CoverTracks();
        // Standard of 3 rounds of clearing data + 1 pass of random data
        // See http://www.blancco.com/blog/how-many-overwriting-rounds-are-required-to-erase-a-hard-disk/
        const int STANDARD_ROUND_COUNT = 3;

        static CoverTracks()
        {
        }

        private CoverTracks()
        {
        }

        public static CoverTracks Instance
        {
            get { return instance; }
        }

        // Track the files we've created
        private List<string> _filesCreated = new List<String>();

        // Track any process started
        private List<System.Diagnostics.Process> _processesStarted = new List<System.Diagnostics.Process>();
        
        // Add a temporary file to delete later
        public void AddFile(string fullFilePath)
        {
            _filesCreated.Add(fullFilePath);
        }

        // Add a process that should be ensured stopped if problems
        public void AddProcess(System.Diagnostics.Process processInfo)
        {
            _processesStarted.Add(processInfo);
        }

        // Clear all tracks using a secure delete (or if problems, a regular delete).
        // Clears list of files afterwards
        public void ClearAllFiles()
        {
            foreach (string target in _filesCreated)
            {
                if (File.Exists(target))
                {
                    // Remove the file securely if possible, regular delete if not
                    if (WipeFile(target))
                    {
                        // Nothing else really to do, but leaving open just in case
                    }
                    else
                    {
                        // Problems wiping the file - try straight delete
                        try { File.Delete(target); }
                        catch { };
                    }
                }
            }
            _filesCreated.Clear();
        }

        // Make sure processes are stopped - they should be, but, well, ya never know
        public void ClearAllProcesses()
        {
            foreach (System.Diagnostics.Process proc in _processesStarted)
            {
                try
                {
                    proc.Kill();
                }
                catch {}
            }

        }

        // Securely delete a file. Increase rounds for better security. Default round is 3.
        private bool WipeFile(string target)
        {
            return WipeFile(target, STANDARD_ROUND_COUNT);
        }

        private bool WipeFile(string target, int numberRounds)
        {
            bool rtn = true;
            Random rnd = new Random(DateTime.Now.Millisecond);

            try
            {
                long targetLength = new System.IO.FileInfo(target).Length;
                var wipeBuffer = new byte[targetLength];
                // Overwrite with 0s the number of times specified
                for (long i = 0;  i < wipeBuffer.Length; i++)
                    wipeBuffer[i] = 0x30;               
                for (int round = 0; round < numberRounds; round++)
                    File.WriteAllBytes(target, wipeBuffer);                

                // As final touch, overwrite with random bytes buffered with a random length
                targetLength += rnd.Next(50, 5000);
                wipeBuffer = new byte[targetLength];
                rnd.NextBytes(wipeBuffer);              // Method that conveniently fills up random numbers
                File.WriteAllBytes(target, wipeBuffer);
                // Finally delete
                File.Delete(target);
            }
            catch
            {
                rtn = false;
            }
            return rtn;
        }
        
    }
}
