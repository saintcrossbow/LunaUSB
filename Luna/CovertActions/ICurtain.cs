//Copyright(C) 2016-2018  saintcrossbow@gmail.com

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
    public interface ICurtain
    {
        // Basic background for login
        System.Drawing.Image background { get; }

        // OS specific graphics for login view
        System.Drawing.Image loginImage { get; }
        System.Drawing.Image userTile { get; }
        // Use unspecified to not use a user tile:
        int userTilePostionMethod { get; }

        // User name - blank if none should be displayed
        string userName { get; }
        // Additional obvious text that logons like to ask like like "enter password". Only shows along with a user
        string userSubtext { get; }

        // Password box style
        int loginPasswordStyle { get; }
        // Null if not to be used
        System.Drawing.Image loginButton { get; }
        // Null if not to be used. Note that switch button not really going to do anything, just display
        System.Drawing.Image switchButton { get; }
    }

}
