namespace Luna
{
    partial class Main
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
            this.capCurtain = new System.Windows.Forms.Label();
            this.capExfiltrate = new System.Windows.Forms.Label();
            this.capUSB = new System.Windows.Forms.Label();
            this.capReady = new System.Windows.Forms.Label();
            this.grpCurtains = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.curtainGeneric = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.curtainEmail = new System.Windows.Forms.RadioButton();
            this.curtainModern = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.exfilCapsLock = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.exfilTelnetBanner = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.exfilEncText = new System.Windows.Forms.RadioButton();
            this.exfilText = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.confirmText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.outputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.driveUSB = new System.Windows.Forms.ComboBox();
            this.errorPop = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCreateStartFile = new System.Windows.Forms.Button();
            this.grpCurtains.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // capCurtain
            // 
            this.capCurtain.BackColor = System.Drawing.Color.IndianRed;
            this.capCurtain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.capCurtain.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capCurtain.ForeColor = System.Drawing.Color.LightGray;
            this.capCurtain.Location = new System.Drawing.Point(27, 9);
            this.capCurtain.Name = "capCurtain";
            this.capCurtain.Size = new System.Drawing.Size(172, 27);
            this.capCurtain.TabIndex = 11;
            this.capCurtain.Text = "Curtain Style";
            this.capCurtain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capExfiltrate
            // 
            this.capExfiltrate.BackColor = System.Drawing.Color.IndianRed;
            this.capExfiltrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.capExfiltrate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capExfiltrate.ForeColor = System.Drawing.Color.LightGray;
            this.capExfiltrate.Location = new System.Drawing.Point(198, 9);
            this.capExfiltrate.Name = "capExfiltrate";
            this.capExfiltrate.Size = new System.Drawing.Size(172, 27);
            this.capExfiltrate.TabIndex = 12;
            this.capExfiltrate.Text = "Exfiltration Method";
            this.capExfiltrate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capUSB
            // 
            this.capUSB.BackColor = System.Drawing.Color.IndianRed;
            this.capUSB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.capUSB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capUSB.ForeColor = System.Drawing.Color.LightGray;
            this.capUSB.Location = new System.Drawing.Point(369, 9);
            this.capUSB.Name = "capUSB";
            this.capUSB.Size = new System.Drawing.Size(172, 27);
            this.capUSB.TabIndex = 13;
            this.capUSB.Text = "Additional Options";
            this.capUSB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capReady
            // 
            this.capReady.BackColor = System.Drawing.Color.IndianRed;
            this.capReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.capReady.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capReady.ForeColor = System.Drawing.Color.LightGray;
            this.capReady.Location = new System.Drawing.Point(540, 9);
            this.capReady.Name = "capReady";
            this.capReady.Size = new System.Drawing.Size(172, 27);
            this.capReady.TabIndex = 14;
            this.capReady.Text = "Ready to Deploy";
            this.capReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpCurtains
            // 
            this.grpCurtains.Controls.Add(this.label7);
            this.grpCurtains.Controls.Add(this.curtainGeneric);
            this.grpCurtains.Controls.Add(this.label6);
            this.grpCurtains.Controls.Add(this.label5);
            this.grpCurtains.Controls.Add(this.curtainEmail);
            this.grpCurtains.Controls.Add(this.curtainModern);
            this.grpCurtains.Location = new System.Drawing.Point(27, 51);
            this.grpCurtains.Name = "grpCurtains";
            this.grpCurtains.Size = new System.Drawing.Size(685, 133);
            this.grpCurtains.TabIndex = 15;
            this.grpCurtains.TabStop = false;
            this.grpCurtains.Text = "Step #1: Curtain Style";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(422, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "A very basic login prompt showing user ID with OK button. User might ignore and t" +
    "ab-off.";
            // 
            // curtainGeneric
            // 
            this.curtainGeneric.AutoSize = true;
            this.curtainGeneric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curtainGeneric.Location = new System.Drawing.Point(16, 91);
            this.curtainGeneric.Name = "curtainGeneric";
            this.curtainGeneric.Size = new System.Drawing.Size(104, 17);
            this.curtainGeneric.TabIndex = 4;
            this.curtainGeneric.TabStop = true;
            this.curtainGeneric.Text = "Generic Login";
            this.curtainGeneric.UseVisualStyleBackColor = true;
            this.curtainGeneric.CheckedChanged += new System.EventHandler(this.curtainGeneric_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(573, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "An Outlook style prompt with a screen captured background. Captures on Cancel and" +
    " OK. User might ignore and tab-off.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(551, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "A Windows 7 style login window, standard background, user tile displayed. Takes f" +
    "ull screen and requires response.";
            // 
            // curtainEmail
            // 
            this.curtainEmail.AutoSize = true;
            this.curtainEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curtainEmail.Location = new System.Drawing.Point(16, 55);
            this.curtainEmail.Name = "curtainEmail";
            this.curtainEmail.Size = new System.Drawing.Size(126, 17);
            this.curtainEmail.TabIndex = 1;
            this.curtainEmail.TabStop = true;
            this.curtainEmail.Text = "Email Client Login";
            this.curtainEmail.UseVisualStyleBackColor = true;
            this.curtainEmail.CheckedChanged += new System.EventHandler(this.curtainEmail_CheckedChanged);
            // 
            // curtainModern
            // 
            this.curtainModern.AutoSize = true;
            this.curtainModern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curtainModern.Location = new System.Drawing.Point(16, 19);
            this.curtainModern.Name = "curtainModern";
            this.curtainModern.Size = new System.Drawing.Size(157, 17);
            this.curtainModern.TabIndex = 0;
            this.curtainModern.TabStop = true;
            this.curtainModern.Text = "Modern Windows Login";
            this.curtainModern.UseVisualStyleBackColor = true;
            this.curtainModern.CheckedChanged += new System.EventHandler(this.curtainModern_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.exfilCapsLock);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.exfilTelnetBanner);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.exfilEncText);
            this.groupBox1.Controls.Add(this.exfilText);
            this.groupBox1.Location = new System.Drawing.Point(27, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 174);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step #2: Exfiltration Method";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(653, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "In Mission Impossible style, flash password in morse through Caps Lock indicator." +
    " High success, but low practicality and highly suspicious.";
            // 
            // exfilCapsLock
            // 
            this.exfilCapsLock.AutoSize = true;
            this.exfilCapsLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exfilCapsLock.Location = new System.Drawing.Point(16, 127);
            this.exfilCapsLock.Name = "exfilCapsLock";
            this.exfilCapsLock.Size = new System.Drawing.Size(123, 17);
            this.exfilCapsLock.TabIndex = 6;
            this.exfilCapsLock.TabStop = true;
            this.exfilCapsLock.Text = "Caps Lock Morse";
            this.exfilCapsLock.UseVisualStyleBackColor = true;
            this.exfilCapsLock.CheckedChanged += new System.EventHandler(this.exfilCapsLock_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(592, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Alter the Telnet banner to show the password in plaintext as first line and start" +
    " service. Requires admin access to Telnet files.";
            // 
            // exfilTelnetBanner
            // 
            this.exfilTelnetBanner.AutoSize = true;
            this.exfilTelnetBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exfilTelnetBanner.Location = new System.Drawing.Point(16, 91);
            this.exfilTelnetBanner.Name = "exfilTelnetBanner";
            this.exfilTelnetBanner.Size = new System.Drawing.Size(105, 17);
            this.exfilTelnetBanner.TabIndex = 4;
            this.exfilTelnetBanner.TabStop = true;
            this.exfilTelnetBanner.Text = "Telnet Banner";
            this.exfilTelnetBanner.UseVisualStyleBackColor = true;
            this.exfilTelnetBanner.CheckedChanged += new System.EventHandler(this.exfilTelnetBanner_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(565, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Create an output file as above, but with full encryption and custom key. Stronger" +
    " security and reasonable success rate.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(634, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Create a simple output file from target PC to accessible path (e.g. a public netw" +
    "ork share). Low security but high likelihood of success.";
            // 
            // exfilEncText
            // 
            this.exfilEncText.AutoSize = true;
            this.exfilEncText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exfilEncText.Location = new System.Drawing.Point(16, 55);
            this.exfilEncText.Name = "exfilEncText";
            this.exfilEncText.Size = new System.Drawing.Size(135, 17);
            this.exfilEncText.TabIndex = 1;
            this.exfilEncText.TabStop = true;
            this.exfilEncText.Text = "Encrypted Text File";
            this.exfilEncText.UseVisualStyleBackColor = true;
            this.exfilEncText.CheckedChanged += new System.EventHandler(this.exfilEncText_CheckedChanged);
            // 
            // exfilText
            // 
            this.exfilText.AutoSize = true;
            this.exfilText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exfilText.Location = new System.Drawing.Point(16, 19);
            this.exfilText.Name = "exfilText";
            this.exfilText.Size = new System.Drawing.Size(106, 17);
            this.exfilText.TabIndex = 0;
            this.exfilText.TabStop = true;
            this.exfilText.Text = "Plain Text File";
            this.exfilText.UseVisualStyleBackColor = true;
            this.exfilText.CheckedChanged += new System.EventHandler(this.exfilText_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.confirmText);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.passwordText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.outputFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.driveUSB);
            this.groupBox2.Location = new System.Drawing.Point(27, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 108);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step #3: Additional Options";
            // 
            // confirmText
            // 
            this.confirmText.Location = new System.Drawing.Point(494, 74);
            this.confirmText.Name = "confirmText";
            this.confirmText.PasswordChar = '●';
            this.confirmText.Size = new System.Drawing.Size(172, 20);
            this.confirmText.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(362, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 22);
            this.label14.TabIndex = 17;
            this.label14.Text = "Confirm password:";
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(171, 74);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '●';
            this.passwordText.Size = new System.Drawing.Size(172, 20);
            this.passwordText.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 15;
            this.label4.Text = "Output file password:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 22);
            this.label3.TabIndex = 14;
            this.label3.Text = "Output file (full path):";
            // 
            // outputFile
            // 
            this.outputFile.Location = new System.Drawing.Point(171, 46);
            this.outputFile.Name = "outputFile";
            this.outputFile.Size = new System.Drawing.Size(495, 20);
            this.outputFile.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Indicate the USB drive; all start files will be copied to the root of that direct" +
    "ory.";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "USB drive to place Luna:";
            // 
            // driveUSB
            // 
            this.driveUSB.FormattingEnabled = true;
            this.driveUSB.Location = new System.Drawing.Point(171, 19);
            this.driveUSB.Name = "driveUSB";
            this.driveUSB.Size = new System.Drawing.Size(111, 21);
            this.driveUSB.TabIndex = 10;
            this.driveUSB.Validated += new System.EventHandler(this.driveUSB_Validated);
            // 
            // errorPop
            // 
            this.errorPop.BackColor = System.Drawing.Color.Moccasin;
            this.errorPop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorPop.Location = new System.Drawing.Point(32, 554);
            this.errorPop.Name = "errorPop";
            this.errorPop.Size = new System.Drawing.Size(674, 54);
            this.errorPop.TabIndex = 9;
            this.errorPop.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.btnCreateStartFile);
            this.groupBox3.Location = new System.Drawing.Point(27, 495);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(685, 56);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step #4: Create Start Files";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(448, 37);
            this.label12.TabIndex = 9;
            this.label12.Text = "Once all options are selected, create a package of files required to run Luna off" +
    " a USB drive: an AutoRun file, a new copy of Luna, and any temporary files neces" +
    "sary.";
            // 
            // btnCreateStartFile
            // 
            this.btnCreateStartFile.Enabled = false;
            this.btnCreateStartFile.Location = new System.Drawing.Point(471, 16);
            this.btnCreateStartFile.Name = "btnCreateStartFile";
            this.btnCreateStartFile.Size = new System.Drawing.Size(208, 23);
            this.btnCreateStartFile.TabIndex = 5;
            this.btnCreateStartFile.Text = "Create Start Files";
            this.btnCreateStartFile.UseVisualStyleBackColor = true;
            this.btnCreateStartFile.Click += new System.EventHandler(this.btnCreateStartFile_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 617);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.errorPop);
            this.Controls.Add(this.grpCurtains);
            this.Controls.Add(this.capReady);
            this.Controls.Add(this.capUSB);
            this.Controls.Add(this.capExfiltrate);
            this.Controls.Add(this.capCurtain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Luna";
            this.Load += new System.EventHandler(this.Main_Load);
            this.grpCurtains.ResumeLayout(false);
            this.grpCurtains.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label capCurtain;
        private System.Windows.Forms.Label capExfiltrate;
        private System.Windows.Forms.Label capUSB;
        private System.Windows.Forms.Label capReady;
        private System.Windows.Forms.GroupBox grpCurtains;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton curtainEmail;
        private System.Windows.Forms.RadioButton curtainModern;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton curtainGeneric;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton exfilTelnetBanner;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton exfilEncText;
        private System.Windows.Forms.RadioButton exfilText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton exfilCapsLock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label errorPop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox driveUSB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCreateStartFile;
        private System.Windows.Forms.TextBox confirmText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputFile;
    }
}

