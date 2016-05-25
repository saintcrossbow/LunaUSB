namespace Luna
{
    partial class missionRun
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
            this.userPicture = new System.Windows.Forms.PictureBox();
            this.loginPicture = new System.Windows.Forms.PictureBox();
            this.loginName = new System.Windows.Forms.Label();
            this.loginSubText = new System.Windows.Forms.Label();
            this.loginPasswordWin7 = new System.Windows.Forms.MaskedTextBox();
            this.loginButton = new System.Windows.Forms.PictureBox();
            this.switchButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchButton)).BeginInit();
            this.SuspendLayout();
            // 
            // userPicture
            // 
            this.userPicture.Location = new System.Drawing.Point(1, 1);
            this.userPicture.Name = "userPicture";
            this.userPicture.Size = new System.Drawing.Size(100, 50);
            this.userPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPicture.TabIndex = 0;
            this.userPicture.TabStop = false;
            this.userPicture.Visible = false;
            // 
            // loginPicture
            // 
            this.loginPicture.BackColor = System.Drawing.Color.Transparent;
            this.loginPicture.Location = new System.Drawing.Point(1, 57);
            this.loginPicture.Name = "loginPicture";
            this.loginPicture.Size = new System.Drawing.Size(100, 50);
            this.loginPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loginPicture.TabIndex = 1;
            this.loginPicture.TabStop = false;
            this.loginPicture.Visible = false;
            // 
            // loginName
            // 
            this.loginName.AutoSize = true;
            this.loginName.BackColor = System.Drawing.Color.Transparent;
            this.loginName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginName.ForeColor = System.Drawing.Color.White;
            this.loginName.Location = new System.Drawing.Point(213, 9);
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(0, 32);
            this.loginName.TabIndex = 2;
            this.loginName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginSubText
            // 
            this.loginSubText.AutoSize = true;
            this.loginSubText.BackColor = System.Drawing.Color.Transparent;
            this.loginSubText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginSubText.ForeColor = System.Drawing.Color.White;
            this.loginSubText.Location = new System.Drawing.Point(219, 9);
            this.loginSubText.Name = "loginSubText";
            this.loginSubText.Size = new System.Drawing.Size(0, 15);
            this.loginSubText.TabIndex = 3;
            this.loginSubText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginPasswordWin7
            // 
            this.loginPasswordWin7.Location = new System.Drawing.Point(107, 1);
            this.loginPasswordWin7.Name = "loginPasswordWin7";
            this.loginPasswordWin7.Size = new System.Drawing.Size(100, 20);
            this.loginPasswordWin7.TabIndex = 5;
            this.loginPasswordWin7.UseSystemPasswordChar = true;
            this.loginPasswordWin7.Visible = false;
            this.loginPasswordWin7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginEnter);
            this.loginPasswordWin7.Validated += new System.EventHandler(this.loginPasswordWin7_Validated);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Transparent;
            this.loginButton.Location = new System.Drawing.Point(1, 113);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 50);
            this.loginButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loginButton.TabIndex = 6;
            this.loginButton.TabStop = false;
            this.loginButton.Visible = false;
            // 
            // switchButton
            // 
            this.switchButton.BackColor = System.Drawing.Color.Transparent;
            this.switchButton.Location = new System.Drawing.Point(1, 169);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(100, 50);
            this.switchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.switchButton.TabIndex = 8;
            this.switchButton.TabStop = false;
            this.switchButton.Visible = false;
            // 
            // missionRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(612, 433);
            this.Controls.Add(this.switchButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.loginPasswordWin7);
            this.Controls.Add(this.loginSubText);
            this.Controls.Add(this.loginName);
            this.Controls.Add(this.loginPicture);
            this.Controls.Add(this.userPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "missionRun";
            this.Text = "Form1";
            this.Deactivate += new System.EventHandler(this.missionRun_Deactivate);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginEnter);
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox userPicture;
        private System.Windows.Forms.PictureBox loginPicture;
        private System.Windows.Forms.Label loginName;
        private System.Windows.Forms.Label loginSubText;
        private System.Windows.Forms.MaskedTextBox loginPasswordWin7;
        private System.Windows.Forms.PictureBox loginButton;
        private System.Windows.Forms.PictureBox switchButton;
    }
}