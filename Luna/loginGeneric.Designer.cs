namespace Luna
{
    partial class loginGeneric
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
            this.btnOK = new System.Windows.Forms.Button();
            this.loginPassword = new System.Windows.Forms.MaskedTextBox();
            this.capPassword = new System.Windows.Forms.Label();
            this.capUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(231, 102);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // loginPassword
            // 
            this.loginPassword.Location = new System.Drawing.Point(12, 66);
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.Size = new System.Drawing.Size(294, 20);
            this.loginPassword.TabIndex = 13;
            this.loginPassword.UseSystemPasswordChar = true;
            // 
            // capPassword
            // 
            this.capPassword.AutoSize = true;
            this.capPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capPassword.Location = new System.Drawing.Point(12, 50);
            this.capPassword.Name = "capPassword";
            this.capPassword.Size = new System.Drawing.Size(57, 13);
            this.capPassword.TabIndex = 11;
            this.capPassword.Text = "&Password:";
            // 
            // capUserName
            // 
            this.capUserName.AutoSize = true;
            this.capUserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capUserName.Location = new System.Drawing.Point(12, 9);
            this.capUserName.Name = "capUserName";
            this.capUserName.Size = new System.Drawing.Size(50, 13);
            this.capUserName.TabIndex = 10;
            this.capUserName.Text = "User TK";
            // 
            // loginGeneric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 141);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.loginPassword);
            this.Controls.Add(this.capPassword);
            this.Controls.Add(this.capUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginGeneric";
            this.Text = "Enter Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.MaskedTextBox loginPassword;
        private System.Windows.Forms.Label capPassword;
        private System.Windows.Forms.Label capUserName;
    }
}