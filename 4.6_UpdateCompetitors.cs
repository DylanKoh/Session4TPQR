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

        /// <summary>
        /// Onload, load Skill Combo box and the Progress Combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Repopulated everything based on new competitor filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void competitorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        /// <summary>
        /// Responsible for adding to Progress Combo box
        /// </summary>
        private void LoadProgress()
        {
            var list = new List<string>()
            {
                "No Filter", "Completed", "In Progress", "Not Started"
            };
            progressBox.Items.AddRange(list.ToArray());
        }

        /// <summary>
        /// When combo box for competitor is clicked, load all the competitor to the Skill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        //When checked, repopulate DGV by the order of Name
        private void nameBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        /// <summary>
        /// When the name of the specific competitor is selected, load all of his/her
        /// training assigned to him/her based on relevant filtering and ordering
        /// </summary>
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

        /// <summary>
        /// Order by End Date where newest is 1st, repopulate DGV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endDateBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        /// <summary>
        /// Default ordering of the DGV, repopulate DGV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        /// <summary>
        /// When typing into the textbox for Module Name filtering, constantly query DB
        /// and populate the DGV with data of modules that contain what is typed in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Gets the relevant progress by filtering of the Module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Checks if value entered is valid and whether it is more than the current value.
        /// Else errors out and revert back to current value of progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    var i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (i < 0 || i > 100)
                    {
                        MessageBox.Show("Please input a valid integer between 0 - 100 inclusive!", "Invalid entry detected",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }

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
                    MessageBox.Show("Please input a valid positive integer!", "Invalid entry detected",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }

        /// <summary>
        /// Triggered when Update Button is clicked. When user's response to MessageBox is Yes,
        /// then update all progress to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When selcted a new skill, clear everything till competitor is chosen from the new skill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skillBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            competitorBox.Items.Clear();
            progressBox.Items.Clear();
            LoadProgress();
            dataGridView1.Rows.Clear();
        }
    }
}
