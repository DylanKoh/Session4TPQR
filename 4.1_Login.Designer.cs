namespace Session4
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userIDBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.chooseBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.countdownTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 92);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(385, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020\r\n26-28 Jul 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16F);
            this.label2.Location = new System.Drawing.Point(324, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Training Management Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "User ID: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password: ";
            // 
            // userIDBox
            // 
            this.userIDBox.Location = new System.Drawing.Point(288, 161);
            this.userIDBox.Name = "userIDBox";
            this.userIDBox.Size = new System.Drawing.Size(466, 32);
            this.userIDBox.TabIndex = 4;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(288, 236);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(466, 32);
            this.passwordBox.TabIndex = 5;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(431, 293);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(136, 46);
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // chooseBtn
            // 
            this.chooseBtn.Location = new System.Drawing.Point(544, 438);
            this.chooseBtn.Name = "chooseBtn";
            this.chooseBtn.Size = new System.Drawing.Size(137, 39);
            this.chooseBtn.TabIndex = 7;
            this.chooseBtn.Text = "Choose File";
            this.chooseBtn.UseVisualStyleBackColor = true;
            this.chooseBtn.Click += new System.EventHandler(this.chooseBtn_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(847, 438);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(121, 39);
            this.uploadBtn.TabIndex = 8;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(286, 442);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(252, 32);
            this.textBox3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "File Path: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16F);
            this.label6.Location = new System.Drawing.Point(255, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(548, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "Training Management Account Creation";
            // 
            // countdownTime
            // 
            this.countdownTime.AutoSize = true;
            this.countdownTime.Location = new System.Drawing.Point(426, 522);
            this.countdownTime.Name = "countdownTime";
            this.countdownTime.Size = new System.Drawing.Size(73, 25);
            this.countdownTime.TabIndex = 12;
            this.countdownTime.Text = "label7";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 556);
            this.Controls.Add(this.countdownTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.chooseBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.userIDBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userIDBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button chooseBtn;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label countdownTime;
        private System.Windows.Forms.Timer timer1;
    }
}

