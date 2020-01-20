namespace Session4
{
    partial class ExpertMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBtn = new System.Windows.Forms.Button();
            this.updateExpertRecordsBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 100);
            this.panel1.TabIndex = 1;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 28);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(115, 44);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(823, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // trackBtn
            // 
            this.trackBtn.Location = new System.Drawing.Point(394, 256);
            this.trackBtn.Name = "trackBtn";
            this.trackBtn.Size = new System.Drawing.Size(269, 89);
            this.trackBtn.TabIndex = 6;
            this.trackBtn.Text = "Track Competitor Training Progress";
            this.trackBtn.UseVisualStyleBackColor = true;
            this.trackBtn.Click += new System.EventHandler(this.trackBtn_Click);
            // 
            // updateExpertRecordsBtn
            // 
            this.updateExpertRecordsBtn.Location = new System.Drawing.Point(394, 169);
            this.updateExpertRecordsBtn.Name = "updateExpertRecordsBtn";
            this.updateExpertRecordsBtn.Size = new System.Drawing.Size(269, 81);
            this.updateExpertRecordsBtn.TabIndex = 5;
            this.updateExpertRecordsBtn.Text = "Update Expert Training Records";
            this.updateExpertRecordsBtn.UseVisualStyleBackColor = true;
            this.updateExpertRecordsBtn.Click += new System.EventHandler(this.updateExpertRecordsBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16F);
            this.label2.Location = new System.Drawing.Point(403, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Expert Main Menu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExpertMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 396);
            this.Controls.Add(this.trackBtn);
            this.Controls.Add(this.updateExpertRecordsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ExpertMain";
            this.Text = "Main Menu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button trackBtn;
        private System.Windows.Forms.Button updateExpertRecordsBtn;
        private System.Windows.Forms.Label label2;
    }
}