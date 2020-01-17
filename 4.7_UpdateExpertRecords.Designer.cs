namespace Session4
{
    partial class UpdateExpertRecords
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
            this.skillBox = new System.Windows.Forms.ComboBox();
            this.expertNameBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameBtn = new System.Windows.Forms.RadioButton();
            this.progressBtn = new System.Windows.Forms.RadioButton();
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
            this.panel1.Size = new System.Drawing.Size(1090, 100);
            this.panel1.TabIndex = 3;
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
            this.label2.Location = new System.Drawing.Point(326, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(445, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Update Expert Training Records";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Skill: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Expert\'s Name: ";
            // 
            // skillBox
            // 
            this.skillBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillBox.FormattingEnabled = true;
            this.skillBox.Location = new System.Drawing.Point(351, 166);
            this.skillBox.Name = "skillBox";
            this.skillBox.Size = new System.Drawing.Size(393, 33);
            this.skillBox.TabIndex = 7;
            // 
            // expertNameBox
            // 
            this.expertNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expertNameBox.FormattingEnabled = true;
            this.expertNameBox.Location = new System.Drawing.Point(351, 232);
            this.expertNameBox.Name = "expertNameBox";
            this.expertNameBox.Size = new System.Drawing.Size(393, 33);
            this.expertNameBox.TabIndex = 8;
            this.expertNameBox.SelectedIndexChanged += new System.EventHandler(this.expertNameBox_SelectedIndexChanged);
            this.expertNameBox.Click += new System.EventHandler(this.expertNameBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sort By: ";
            // 
            // nameBtn
            // 
            this.nameBtn.AutoSize = true;
            this.nameBtn.Location = new System.Drawing.Point(351, 293);
            this.nameBtn.Name = "nameBtn";
            this.nameBtn.Size = new System.Drawing.Size(91, 29);
            this.nameBtn.TabIndex = 10;
            this.nameBtn.TabStop = true;
            this.nameBtn.Text = "Name";
            this.nameBtn.UseVisualStyleBackColor = true;
            this.nameBtn.CheckedChanged += new System.EventHandler(this.nameBtn_CheckedChanged);
            // 
            // progressBtn
            // 
            this.progressBtn.AutoSize = true;
            this.progressBtn.Location = new System.Drawing.Point(448, 293);
            this.progressBtn.Name = "progressBtn";
            this.progressBtn.Size = new System.Drawing.Size(119, 29);
            this.progressBtn.TabIndex = 11;
            this.progressBtn.TabStop = true;
            this.progressBtn.Text = "Progress";
            this.progressBtn.UseVisualStyleBackColor = true;
            this.progressBtn.CheckedChanged += new System.EventHandler(this.progressBtn_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 346);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1066, 268);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(919, 630);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(159, 44);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // UpdateExpertRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 686);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBtn);
            this.Controls.Add(this.nameBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.expertNameBox);
            this.Controls.Add(this.skillBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UpdateExpertRecords";
            this.Text = "UpdateExpertRecords";
            this.Load += new System.EventHandler(this.UpdateExpertRecords_Load);
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
        private System.Windows.Forms.ComboBox skillBox;
        private System.Windows.Forms.ComboBox expertNameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton nameBtn;
        private System.Windows.Forms.RadioButton progressBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button updateBtn;
    }
}