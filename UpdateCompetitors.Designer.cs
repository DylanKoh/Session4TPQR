namespace Session4
{
    partial class UpdateCompetitors
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.skillBox = new System.Windows.Forms.ComboBox();
            this.competitorBox = new System.Windows.Forms.ComboBox();
            this.nameBtn = new System.Windows.Forms.RadioButton();
            this.endDateBtn = new System.Windows.Forms.RadioButton();
            this.moduleNameBox = new System.Windows.Forms.TextBox();
            this.progressBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.updateBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1096, 100);
            this.panel1.TabIndex = 2;
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
            this.label1.Size = new System.Drawing.Size(263, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16F);
            this.label2.Location = new System.Drawing.Point(307, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(507, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Update Competitor Training Records";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Skill: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Competitor\'s Name: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Sort By: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(275, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Search By Module Name: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Search By Progress: ";
            // 
            // skillBox
            // 
            this.skillBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillBox.FormattingEnabled = true;
            this.skillBox.Location = new System.Drawing.Point(331, 169);
            this.skillBox.Name = "skillBox";
            this.skillBox.Size = new System.Drawing.Size(433, 33);
            this.skillBox.TabIndex = 9;
            // 
            // competitorBox
            // 
            this.competitorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitorBox.FormattingEnabled = true;
            this.competitorBox.Location = new System.Drawing.Point(331, 219);
            this.competitorBox.Name = "competitorBox";
            this.competitorBox.Size = new System.Drawing.Size(433, 33);
            this.competitorBox.TabIndex = 10;
            this.competitorBox.SelectedIndexChanged += new System.EventHandler(this.competitorBox_SelectedIndexChanged);
            this.competitorBox.Click += new System.EventHandler(this.competitorBox_Click);
            // 
            // nameBtn
            // 
            this.nameBtn.AutoSize = true;
            this.nameBtn.Location = new System.Drawing.Point(331, 271);
            this.nameBtn.Name = "nameBtn";
            this.nameBtn.Size = new System.Drawing.Size(91, 29);
            this.nameBtn.TabIndex = 11;
            this.nameBtn.TabStop = true;
            this.nameBtn.Text = "Name";
            this.nameBtn.UseVisualStyleBackColor = true;
            this.nameBtn.CheckedChanged += new System.EventHandler(this.nameBtn_CheckedChanged);
            // 
            // endDateBtn
            // 
            this.endDateBtn.AutoSize = true;
            this.endDateBtn.Location = new System.Drawing.Point(428, 271);
            this.endDateBtn.Name = "endDateBtn";
            this.endDateBtn.Size = new System.Drawing.Size(125, 29);
            this.endDateBtn.TabIndex = 12;
            this.endDateBtn.TabStop = true;
            this.endDateBtn.Text = "End Date";
            this.endDateBtn.UseVisualStyleBackColor = true;
            this.endDateBtn.CheckedChanged += new System.EventHandler(this.endDateBtn_CheckedChanged);
            // 
            // moduleNameBox
            // 
            this.moduleNameBox.Location = new System.Drawing.Point(331, 321);
            this.moduleNameBox.Name = "moduleNameBox";
            this.moduleNameBox.Size = new System.Drawing.Size(433, 32);
            this.moduleNameBox.TabIndex = 13;
            // 
            // progressBox
            // 
            this.progressBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.progressBox.FormattingEnabled = true;
            this.progressBox.Location = new System.Drawing.Point(331, 377);
            this.progressBox.Name = "progressBox";
            this.progressBox.Size = new System.Drawing.Size(433, 33);
            this.progressBox.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 440);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1072, 202);
            this.dataGridView1.TabIndex = 15;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(973, 648);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(111, 37);
            this.updateBtn.TabIndex = 16;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateCompetitors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 697);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBox);
            this.Controls.Add(this.moduleNameBox);
            this.Controls.Add(this.endDateBtn);
            this.Controls.Add(this.nameBtn);
            this.Controls.Add(this.competitorBox);
            this.Controls.Add(this.skillBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UpdateCompetitors";
            this.Text = "Update Competitors Records";
            this.Load += new System.EventHandler(this.UpdateCompetitors_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox skillBox;
        private System.Windows.Forms.ComboBox competitorBox;
        private System.Windows.Forms.RadioButton nameBtn;
        private System.Windows.Forms.RadioButton endDateBtn;
        private System.Windows.Forms.TextBox moduleNameBox;
        private System.Windows.Forms.ComboBox progressBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button updateBtn;
    }
}