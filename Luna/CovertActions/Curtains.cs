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
using System.IO;
using System.Drawing;

// Curtains are meant to be extendable and easily maintained. So if you'd like to make these look
// exactly like their targets, you should be able to do so easily without modifying too much of the 
// other code. 

namespace Luna
{
    // Windows 7+ login style
    public class curtainWin7 : Luna.CovertActions.ICurtain 
    {
        public System.Drawing.Image background
        {
            get { return Luna.Properties.Resources.windows_7_original_wide; }           
        }

        public System.Drawing.Image loginImage
        {
            get { return Luna.Properties.Resources.windows_7_logon; }
        }

        // Attempt to get the actual user tile
        public System.Drawing.Image userTile
        {
            get {
                    string userTile = bestTileMatch();
                    if (userTile == "")
                    {
                        // Couldn't find a user tile, so use a default one
                        return Luna.Properties.Resources.windows_7_default_user;
                    }
                    else
                    {
                        Bitmap userBitmap = new Bitmap(userTile);
                        return userBitmap;
                    }

                }
        }

        public int userTilePostionMethod
        {
            get { return (int)Common.UserTilePositionMethod.Win7; }
        }

        public string userName
        {            
            get { return LunaGeneral.bestUserName(); }
        }

        public string userSubtext
        {
            get { return "Locked"; }
        }

        // Try to find the most likely user tile
        private string bestTileMatch()
        {
            const string DEFAULT_USER_PATH = "C:\\Users\\%1\\AppData\\Local\\Temp\\";
            string[] fileAttempts = { Path.Combine(DEFAULT_USER_PATH.Replace("%1",Environment.UserName), Environment.UserName + ".bmp"),
                                      Path.Combine(DEFAULT_USER_PATH.Replace("%1",Environment.UserName), Environment.UserDomainName + "+" + Environment.UserName + ".bmp"),
                                      Path.Combine(DEFAULT_USER_PATH.Replace("%1",Environment.UserName), Environment.UserDomainName + "" + Environment.UserName + ".bmp")};
            string retFile = "";

            // Determine if tile is there based on our patterns
            try
            {
                foreach (string target in fileAttempts)
                {
                    if (File.Exists(target))
                    {
                        retFile = target;
                        break;
                    }
                }
            }
            catch
            {
                // Any error return to default user tile
                retFile = "";
            }

            return retFile;
        }

        public int loginPasswordStyle
        {
            get { return (int)Common.PasswordBoxStyle.Win7; }
        }

        public System.Drawing.Image loginButton 
        { 
            get { return Luna.Properties.Resources.windows_7_login_button; }  
        }

        public System.Drawing.Image switchButton
        {
            get { return Luna.Properties.Resources.windows_7_switch_user; }
        }

        public void showLoginInfo()
        {
        }

    }

    // Show an Outlook style prompt using existing background (using screenshot to force entry into password box)
    public class curtainOutlook : Luna.CovertActions.ICurtain
    {
        public System.Drawing.Image background
        {
            get 
            { 
                // Try to get a full screen print - if unable to do so return nothing.
                // The screen print is needed to know if focus lost (and thus requiring an abort)
                try
                {
                    string saveFile = Path.Combine(Path.GetTempPath(), LunaGeneral.randomFile() + ".png");
                    LunaGeneral.ScreenPrint(saveFile);                   
                    // Track for later delete
                    CoverTracks.Instance.AddFile(saveFile);
                    using (var saveBitmap = new Bitmap(saveFile))
                    {
                        return new Bitmap(saveBitmap);
                    }
                }
                catch
                {
                    // If anything goes wrong, we're returning nothing
                    return null;
                }
            }
        }

        public System.Drawing.Image loginImage
        {
            get { return null; }
        }

        // Attempt to get the actual user tile
        public System.Drawing.Image userTile
        {
            get { return null; }
        }

        public int userTilePostionMethod
        {
            get { return (int)Common.UserTilePositionMethod.Undefined; }
        }

        public string userName
        {
            get
            {   return ""; }
        }

        public string userSubtext
        {
            get { return ""; }
        }

        public int loginPasswordStyle
        {
            get { return (int)Common.PasswordBoxStyle.OutlookPrompt; }
        }

        public System.Drawing.Image loginButton
        {
            get { return null; }
        }

        public System.Drawing.Image switchButton
        {
            get { return null; }
        }
    }

    // Show just a basic input box to get password. Should set off warning flags for most users.
    public class curtainGeneric : Luna.CovertActions.ICurtain
    {
        public System.Drawing.Image background
        {
            get
            {
                // Try to get a full screen print - if unable to do so return nothing.
                // The screen print is needed to know if focus lost (and thus requiring an abort)
                try
                {
                    string saveFile = Path.Combine(Path.GetTempPath(), LunaGeneral.randomFile() + ".png");
                    LunaGeneral.ScreenPrint(saveFile);
                    // Track for later delete
                    CoverTracks.Instance.AddFile(saveFile);
                    using (var saveBitmap = new Bitmap(saveFile))
                    {
                        return new Bitmap(saveBitmap);
                    }
                }
                catch
                {
                    // If anything goes wrong, we're returning nothing
                    return null;
                }
            }
        }

        public System.Drawing.Image loginImage
        {
            get { return null; }
        }

        // Attempt to get the actual user tile
        public System.Drawing.Image userTile
        {
            get { return null; }
        }

        public int userTilePostionMethod
        {
            get { return (int)Common.UserTilePositionMethod.Undefined; }
        }

        public string userName
        {
            get { return LunaGeneral.bestUserName(); }
        }

        public string userSubtext
        {
            get { return ""; }
        }

        public int loginPasswordStyle
        {
            get { return (int)Common.PasswordBoxStyle.Generic; }
        }

        public System.Drawing.Image loginButton
        {
            get { return null; }
        }

        public System.Drawing.Image switchButton
        {
            get { return null; }
        }
    }

    public class curtainCortana : Luna.CovertActions.ICurtain
    {
        public System.Drawing.Image background
        {
            get
            {
                // Try to get a full screen print - if unable to do so return nothing.
                // The screen print is needed to know if focus lost (and thus requiring an abort)
                try
                {
                    string saveFile = Path.Combine(Path.GetTempPath(), LunaGeneral.randomFile() + ".png");
                    LunaGeneral.ScreenPrint(saveFile);
                    // Track for later delete
                    CoverTracks.Instance.AddFile(saveFile);
                    using (var saveBitmap = new Bitmap(saveFile))
                    {
                        return new Bitmap(saveBitmap);
                    }
                }
                catch
                {
                    // If anything goes wrong, we're returning nothing
                    return null;
                }
            }
        }

        public System.Drawing.Image loginImage
        {
            get { return null; }
        }

        // Attempt to get the actual user tile
        public System.Drawing.Image userTile
        {
            get { return null; }
        }

        public int userTilePostionMethod
        {
            get { return (int)Common.UserTilePositionMethod.Undefined; }
        }

        public string userName
        {
            get { return LunaGeneral.bestUserName(); }
        }

        public string userSubtext
        {
            get { return ""; }
        }

        public int loginPasswordStyle
        {
            get { return (int)Common.PasswordBoxStyle.Cortana; }
        }

        public System.Drawing.Image loginButton
        {
            get { return null; }
        }

        public System.Drawing.Image switchButton
        {
            get { return null; }
        }
    }

    public class curtainOutlookModern : Luna.CovertActions.ICurtain
    {
        public System.Drawing.Image background
        {
            get
            {
                // Try to get a full screen print - if unable to do so return nothing.
                // The screen print is needed to know if focus lost (and thus requiring an abort)
                try
                {
                    string saveFile = Path.Combine(Path.GetTempPath(), LunaGeneral.randomFile() + ".png");
                    LunaGeneral.ScreenPrint(saveFile);
                    // Track for later delete
                    CoverTracks.Instance.AddFile(saveFile);
                    using (var saveBitmap = new Bitmap(saveFile))
                    {
                        return new Bitmap(saveBitmap);
                    }
                }
                catch
                {
                    // If anything goes wrong, we're returning nothing
                    return null;
                }
            }
        }

        public System.Drawing.Image loginImage
        {
            get { return null; }
        }

        public System.Drawing.Image userTile
        {
            get { return null; }
        }

        public int userTilePostionMethod
        {
            get { return (int)Common.UserTilePositionMethod.Undefined; }
        }

        public string userName
        {
            get { return LunaGeneral.bestUserName(); }
        }

        public string userSubtext
        {
            get { return ""; }
        }

        public int loginPasswordStyle
        {
            get { return (int)Common.PasswordBoxStyle.OutlookModern; }
        }

        public System.Drawing.Image loginButton
        {
            get { return null; }
        }

        public System.Drawing.Image switchButton
        {
            get { return null; }
        }
    }

    // Special curtain that just freezes the screen while something else is executed in background
    public class curtainCovertFreeze : Luna.CovertActions.ICurtain
    {
        public System.Drawing.Image background
        {
            get
            {
                // Try to get a full screen print - if unable to do so return nothing.
                // The screen print is needed to know if focus lost (and thus requiring an abort)
                try
                {
                    string saveFile = Path.Combine(Path.GetTempPath(), LunaGeneral.randomFile() + ".png");
                    LunaGeneral.ScreenPrint(saveFile);
                    // Track for later delete
                    CoverTracks.Instance.AddFile(saveFile);
                    using (var saveBitmap = new Bitmap(saveFile))
                    {
                        return new Bitmap(saveBitmap);
                    }
                }
                catch
                {
                    // If anything goes wrong, we're returning nothing
                    return null;
                }
            }
        }

        public System.Drawing.Image loginImage
        {
            get { return null; }
        }

        // Attempt to get the actual user tile
        public System.Drawing.Image userTile
        {
            get { return null; }
        }

        public int userTilePostionMethod
        {
            get { return (int)Common.UserTilePositionMethod.Undefined; }
        }

        public string userName
        {
            get { return ""; }
        }

        public string userSubtext
        {
            get { return ""; }
        }

        public int loginPasswordStyle
        {
            get { return (int)Common.PasswordBoxStyle.Undefined; }
        }

        public System.Drawing.Image loginButton
        {
            get { return null; }
        }

        public System.Drawing.Image switchButton
        {
            get { return null; }
        }
    }

}
