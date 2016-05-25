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

namespace Luna.CovertActions
{
    interface IExfiltrate
    {
        // Set and get the sought secret information
        string secretData { set;  get; }

        // Target file if required (use null if not used)
        string targetFile { set;  get; }

        // Encryption key if used (use null if not used)
        string encyptKey { set;  get; }

        // Each method will have distinct way of communicating out the data
        void exfiltrateData();
        
    }
}
