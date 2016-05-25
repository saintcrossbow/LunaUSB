namespace Luna
{
    partial class loginDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginDialog));
            this.capTitle = new System.Windows.Forms.Label();
            this.capUserName = new System.Windows.Forms.Label();
            this.capPassword = new System.Windows.Forms.Label();
            this.loginUser = new System.Windows.Forms.ComboBox();
            this.loginPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // capTitle
            // 
            this.capTitle.AutoSize = true;
            this.capTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capTitle.Location = new System.Drawing.Point(13, 13);
            this.capTitle.Name = "capTitle";
            this.capTitle.Size = new System.Drawing.Size(237, 13);
            this.capTitle.TabIndex = 0;
            this.capTitle.Text = "The server requires a user name and password.";
            // 
            // capUserName
            // 
            this.capUserName.AutoSize = true;
            this.capUserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capUserName.Location = new System.Drawing.Point(12, 56);
            this.capUserName.Name = "capUserName";
            this.capUserName.Size = new System.Drawing.Size(62, 13);
            this.capUserName.TabIndex = 1;
            this.capUserName.Text = "&User name:";
            // 
            // capPassword
            // 
            this.capPassword.AutoSize = true;
            this.capPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capPassword.Location = new System.Drawing.Point(13, 96);
            this.capPassword.Name = "capPassword";
            this.capPassword.Size = new System.Drawing.Size(57, 13);
            this.capPassword.TabIndex = 2;
            this.capPassword.Text = "&Password:";
            // 
            // loginUser
            // 
            this.loginUser.FormattingEnabled = true;
            this.loginUser.Location = new System.Drawing.Point(140, 53);
            this.loginUser.Name = "loginUser";
            this.loginUser.Size = new System.Drawing.Size(200, 21);
            this.loginUser.TabIndex = 3;
            this.loginUser.TabStop = false;
            // 
            // loginPassword
            // 
            this.loginPassword.Location = new System.Drawing.Point(140, 96);
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.Size = new System.Drawing.Size(200, 20);
            this.loginPassword.TabIndex = 6;
            this.loginPassword.UseSystemPasswordChar = true;
            this.loginPassword.Validated += new System.EventHandler(this.loginPassword_Validated);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(175, 145);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(265, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // loginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 185);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.loginPassword);
            this.Controls.Add(this.loginUser);
            this.Controls.Add(this.capPassword);
            this.Controls.Add(this.capUserName);
            this.Controls.Add(this.capTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect";
            this.Activated += new System.EventHandler(this.loginDialog_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label capTitle;
        private System.Windows.Forms.Label capUserName;
        private System.Windows.Forms.Label capPassword;
        private System.Windows.Forms.ComboBox loginUser;
        private System.Windows.Forms.MaskedTextBox loginPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}