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
    public partial class UpdateCompetitors : Form
    {
        public UpdateCompetitors()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        private void UpdateCompetitors_Load(object sender, EventArgs e)
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
            LoadProgress();
        }

        private void competitorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }
        private void LoadProgress()
        {
            var list = new List<string>()
            {
                "No Filter", "Completed", "In Progress", "Not Started"
            };
            progressBox.Items.AddRange(list.ToArray());
        }

        private void competitorBox_Click(object sender, EventArgs e)
        {
            progressBox.Items.Clear();
            LoadProgress();
            competitorBox.Items.Clear();
            if (skillBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Skill!", "No skill detected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var context = new Session4Entities())
                {
                    var getCompetitor = (from x in context.Users
                                         where x.Skill.skillName == skillBox.SelectedItem.ToString() && x.User_Type.userTypeName == "Competitor"
                                         select x.name);
                    List<string> names = new List<string>();

                    foreach (var item in getCompetitor)
                    {
                        names.Add(item);
                    }
                    competitorBox.Items.AddRange(names.ToArray());
                    
                }
            }
        }

        private void nameBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
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
                                 where x.name.Equals(competitorBox.SelectedItem.ToString())
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
                else if (endDateBtn.Checked)
                {
                    var getModulesUnderName = (from x in context.Assign_Training
                                               where x.userIdFK == getUserID
                                               select x).ToList();
                    foreach (var item in getModulesUnderName.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)))
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
            }

        }

        private void endDateBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void defaultBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void moduleNameBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session4Entities())
            {
                var getUserID = (from x in context.Users
                                 where x.name.Equals(competitorBox.SelectedItem.ToString())
                                 select x.userId).First();
                if (nameBtn.Checked)
                {

                    var getModulesUnderName = (from x in context.Assign_Training
                                               where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text)
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
                else if (endDateBtn.Checked)
                {
                    var getModulesUnderName = (from x in context.Assign_Training
                                               where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text)
                                               select x).ToList();
                    foreach (var item in getModulesUnderName.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)))
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
                                               where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text)
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
            }
            
        }

        private void progressBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session4Entities())
            {
                var getUserID = (from x in context.Users
                                 where x.name.Equals(competitorBox.SelectedItem.ToString())
                                 select x.userId).First();
                if (progressBox.SelectedItem.ToString() == "Completed")
                {
                    if (nameBtn.Checked)
                    {

                        var getModulesUnderName = (from x in context.Assign_Training
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text) && x.progress == 100
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
                    else if (endDateBtn.Checked)
                    {
                        var getModulesUnderName = (from x in context.Assign_Training
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text) && x.progress == 100
                                                   select x).ToList();
                        foreach (var item in getModulesUnderName.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)))
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
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text) && x.progress == 100
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
                }

                else if (progressBox.SelectedItem.ToString() == "In Progress") 
                {
                    
                    if (nameBtn.Checked)
                    {

                        var getModulesUnderName = (from x in context.Assign_Training
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text) 
                                                   && x.progress <= 100 && x.progress > 0
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
                    else if (endDateBtn.Checked)
                    {
                        var getModulesUnderName = (from x in context.Assign_Training
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text)
                                                   && x.progress <= 100 && x.progress > 0
                                                   select x).ToList();
                        foreach (var item in getModulesUnderName.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)))
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
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text)
                                                   && x.progress <= 100 && x.progress > 0
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
                }
                else if (progressBox.SelectedItem.ToString() == "Not Started")
                {
                    if (nameBtn.Checked)
                    {

                        var getModulesUnderName = (from x in context.Assign_Training
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text)
                                                   && x.progress == 0
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
                    else if (endDateBtn.Checked)
                    {
                        var getModulesUnderName = (from x in context.Assign_Training
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text)
                                                   && x.progress == 0
                                                   select x).ToList();
                        foreach (var item in getModulesUnderName.OrderByDescending(x => x.startDate.AddDays(x.Training_Module.durationDays)))
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
                                                   where x.userIdFK == getUserID && x.Training_Module.moduleName.Contains(moduleNameBox.Text)
                                                   && x.progress == 0 
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
                }

                else
                {
                    GridRefresh();
                }
                
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (i < 0 || i > 100)
                {
                    MessageBox.Show("Please input a valid integer between 0 - 100 inclusive!", "Invalid entry detected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please input a valid positive integer!", "Invalid entry detected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("Are you sure you want to update progress?", "Update Progress",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                using (var context = new Session4Entities())
                {
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        var getID = Convert.ToInt32(item.Cells[5].Value);
                        var getTraining = (from x in context.Assign_Training
                                           where x.trainingId == getID
                                           select x).First();
                        getTraining.progress = Convert.ToInt32(item.Cells[4].Value);
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Update successful!", "Update", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                
            }
            
        }

        private void skillBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            competitorBox.Items.Clear();
            progressBox.Items.Clear();
            LoadProgress();
            dataGridView1.Rows.Clear();
        }
    }
}
