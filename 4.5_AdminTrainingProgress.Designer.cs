namespace Session4
{
    partial class AdminTrainingProgress
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.skillBox = new System.Windows.Forms.ComboBox();
            this.NumberList = new System.Windows.Forms.DataGridView();
            this.statusExpertList = new System.Windows.Forms.DataGridView();
            this.statusCompetitorsList = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusExpertList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCompetitorsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1095, 74);
            this.panel1.TabIndex = 3;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 20);
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
            this.label1.Location = new System.Drawing.Point(829, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16F);
            this.label2.Location = new System.Drawing.Point(357, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(436, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Track Overall Training Progress";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Skill: ";
            // 
            // skillBox
            // 
            this.skillBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillBox.FormattingEnabled = true;
            this.skillBox.Location = new System.Drawing.Point(435, 112);
            this.skillBox.Name = "skillBox";
            this.skillBox.Size = new System.Drawing.Size(261, 33);
            this.skillBox.TabIndex = 6;
            this.skillBox.SelectedIndexChanged += new System.EventHandler(this.skillBox_SelectedIndexChanged);
            // 
            // NumberList
            // 
            this.NumberList.AllowUserToAddRows = false;
            this.NumberList.AllowUserToDeleteRows = false;
            this.NumberList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.NumberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NumberList.Location = new System.Drawing.Point(11, 151);
            this.NumberList.Name = "NumberList";
            this.NumberList.ReadOnly = true;
            this.NumberList.RowHeadersWidth = 51;
            this.NumberList.RowTemplate.Height = 24;
            this.NumberList.Size = new System.Drawing.Size(1071, 110);
            this.NumberList.TabIndex = 7;
            // 
            // statusExpertList
            // 
            this.statusExpertList.AllowUserToAddRows = false;
            this.statusExpertList.AllowUserToDeleteRows = false;
            this.statusExpertList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.statusExpertList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statusExpertList.Location = new System.Drawing.Point(11, 267);
            this.statusExpertList.Name = "statusExpertList";
            this.statusExpertList.ReadOnly = true;
            this.statusExpertList.RowHeadersWidth = 51;
            this.statusExpertList.RowTemplate.Height = 24;
            this.statusExpertList.Size = new System.Drawing.Size(514, 214);
            this.statusExpertList.TabIndex = 8;
            // 
            // statusCompetitorsList
            // 
            this.statusCompetitorsList.AllowUserToAddRows = false;
            this.statusCompetitorsList.AllowUserToDeleteRows = false;
            this.statusCompetitorsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.statusCompetitorsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statusCompetitorsList.Location = new System.Drawing.Point(569, 267);
            this.statusCompetitorsList.Name = "statusCompetitorsList";
            this.statusCompetitorsList.ReadOnly = true;
            this.statusCompetitorsList.RowHeadersWidth = 51;
            this.statusCompetitorsList.RowTemplate.Height = 24;
            this.statusCompetitorsList.Size = new System.Drawing.Size(514, 214);
            this.statusCompetitorsList.TabIndex = 9;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(203, 487);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(688, 300);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // AdminTrainingProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1095, 812);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.statusCompetitorsList);
            this.Controls.Add(this.statusExpertList);
            this.Controls.Add(this.NumberList);
            this.Controls.Add(this.skillBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AdminTrainingProgress";
            this.Text = "Track Overall Training Progress";
            this.Load += new System.EventHandler(this.AdminTrainingProgress_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusExpertList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCompetitorsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox skillBox;
        private System.Windows.Forms.DataGridView NumberList;
        private System.Windows.Forms.DataGridView statusExpertList;
        private System.Windows.Forms.DataGridView statusCompetitorsList;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}