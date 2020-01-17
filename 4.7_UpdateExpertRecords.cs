using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session4
{
    public partial class UpdateExpertRecords : Form
    {
        string _userID;
        public UpdateExpertRecords(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ExpertMain(_userID)).ShowDialog();
            this.Close();
        }

        private void expertNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void UpdateExpertRecords_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var getSkill = (from x in context.Skills
                                select x.skillName);
                HashSet<string> skill = new HashSet<string>();
                foreach (var item in getSkill)
                {
                    skill.Add(item);
                }
                skillBox.Items.AddRange(skill.ToArray());
            }
        }

        private void expertNameBox_Click(object sender, EventArgs e)
        {
            expertNameBox.Items.Clear();
            if (skillBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Skill!", "No skill detected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var context = new Session4Entities())
                {
                    var getCompetitor = (from x in context.Users
                                         where x.Skill.skillName == skillBox.SelectedItem.ToString() && x.User_Type.userTypeName == "Expert"
                                         select x.name);
                    List<string> names = new List<string>();

                    foreach (var item in getCompetitor)
                    {
                        names.Add(item);
                    }
                    expertNameBox.Items.AddRange(names.ToArray());

                }
            }
        }

        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Training Module";
            dataGridView1.Columns[1].Name = "Duration (Days)";
            dataGridView1.Columns[2].Name = "Start Date";
            dataGridView1.Columns[3].Name = "Estimated End Date";
            dataGridView1.Columns[4].Name = "Progress (%)";
            dataGridView1.Columns[5].Name = "Assign ID";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            using (var context = new Session4Entities())
            {
                var getUserID = (from x in context.Users
                                 where x.name.Equals(expertNameBox.SelectedItem.ToString())
                                 select x.userId).First();
                if (nameBtn.Checked)
                {

                    var getModulesUnderName = (from x in context.Assign_Training
                                               where x.userIdFK == getUserID
                                               orderby x.Training_Module.moduleName
                                               select x);
                    foreach (var item in getModulesUnderName)
                    {

                        var list = new List<string>()
                        {
                            item.Training_Module.moduleName, item.Training_Module.durationDays.ToString(),
                            item.startDate.ToString("dd/MM/yyyy"), item.startDate.AddDays(item.Training_Module.durationDays).ToString("dd/MM/yyyy"),
                            item.progress.ToString(), item.trainingId.ToString()
                        };
                        dataGridView1.Rows.Add(list.ToArray());
                    }


                }
                else if (progressBtn.Checked)
                {
                    var getModulesUnderName = (from x in context.Assign_Training
                                               where x.userIdFK == getUserID
                                               orderby x.progress descending
                                               select x);
                    foreach (var item in getModulesUnderName)
                    {
                        var list = new List<string>()
                        {
                            item.Training_Module.moduleName, item.Training_Module.durationDays.ToString(),
                            item.startDate.ToString("dd/MM/yyyy"), item.startDate.AddDays(item.Training_Module.durationDays).ToString("dd/MM/yyyy"),
                            item.progress.ToString(), item.trainingId.ToString()
                        };
                        dataGridView1.Rows.Add(list.ToArray());
                    }
                }
                else
                {
                    var getModulesUnderName = (from x in context.Assign_Training
                                               where x.userIdFK == getUserID
                                               orderby x.Training_Module.moduleName descending
                                               select x);
                    foreach (var item in getModulesUnderName)
                    {

                        var list = new List<string>()
                        {
                            item.Training_Module.moduleName, item.Training_Module.durationDays.ToString(),
                            item.startDate.ToString("dd/MM/yyyy"), item.startDate.AddDays(item.Training_Module.durationDays).ToString("dd/MM/yyyy"),
                            item.progress.ToString(), item.trainingId.ToString()
                        };
                        dataGridView1.Rows.Add(list.ToArray());
                    }

                    

                }
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    var now = DateTime.Now;
                    var estimatedDate = Convert.ToDateTime(item.Cells[3].Value);
                    if ((estimatedDate - now).TotalDays <= 14 && (estimatedDate - now).TotalDays > 5)
                    {
                        item.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if ((estimatedDate - now).TotalDays <= 5)
                    {
                        item.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void nameBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void progressBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                var getPreviousValue = (from x in context.Assign_Training
                                        where x.trainingId == ID
                                        select x.progress).FirstOrDefault();
                try
                {
                    var valueChange = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (valueChange < getPreviousValue || valueChange > 100)
                    {
                        MessageBox.Show("Please enter a valid integer between 0-100 inclusive! Progress cannot be lower than previous value!", "Invalid input detected",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = getPreviousValue;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a valid positive integer!", "Invalid input detected",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = getPreviousValue;
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("Are you sure you want to update?", "Update Progress",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                using (var context = new Session4Entities())
                {
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        var ID = Convert.ToInt32(item.Cells[5].Value);
                        var getUpdate = (from x in context.Assign_Training
                                         where x.trainingId == ID
                                         select x).First();
                        getUpdate.progress = Convert.ToInt32(item.Cells[4].Value);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Update successful!", "Update Progress",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
    }
}
