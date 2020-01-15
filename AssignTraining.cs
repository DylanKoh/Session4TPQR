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
    public partial class AssignTraining : Form
    {
        string _userID;
        public AssignTraining(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void AssignTraining_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var getSkills = (from x in context.Skills
                                 select x.skillName);
                HashSet<string> skills = new HashSet<string>();
                foreach (var item in getSkills)
                {
                    skills.Add(item);
                }
                skillBox.Items.AddRange(skills.ToArray());

                HashSet<string> category = new HashSet<string>();
                var getCategory = (from x in context.User_Type
                                   select x.userTypeName);
                foreach (var item in getCategory)
                {
                    if (item == "Admin") continue;
                    else
                    {
                        category.Add(item);
                    }

                }
                categoryBox.Items.AddRange(category.ToArray());
                GridRefresh();
                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow rows in dataGridView1.Rows)
                    {
                        var i = Convert.ToInt32(rows.Cells[3].Value);
                        var getAssignment = (from x in context.Assign_Training
                                             where x.trainingId == i
                                             select x).FirstOrDefault();
                        context.Assign_Training.Remove(getAssignment);
                        context.SaveChanges();
                    }
                }


            }
            
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminMain(_userID)).ShowDialog();
            this.Close();
        }

        private void moduleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Skill";
            dataGridView1.Columns[1].Name = "Training Category";
            dataGridView1.Columns[2].Name = "Training Module";
            dataGridView1.Columns[3].Name = "Assigned ID";
            dataGridView1.Columns[4].Name = "Date";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            using (var context = new Session4Entities())
            {
                var getTraining = (from x in context.Assign_Training
                                   select x);
                foreach (var item in getTraining)
                {
                    List<string> rows = new List<string>()
                    {
                        item.Training_Module.Skill.skillName, item.Training_Module.User_Type.userTypeName, item.Training_Module.moduleName,
                        item.trainingId.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
            }
        }

        private void moduleBox_Click(object sender, EventArgs e)
        {
            moduleBox.Items.Clear();
            using (var context = new Session4Entities())
            {
                if (skillBox.SelectedItem != null && categoryBox.SelectedItem != null)
                {
                    var getTypeID = (from x in context.User_Type
                                     where x.userTypeName == categoryBox.SelectedItem.ToString()
                                     select x.userTypeId).First();

                    var getSkillID = (from x in context.Skills
                                      where x.skillName == skillBox.SelectedItem.ToString()
                                      select x.skillId).First();

                    HashSet<string> module = new HashSet<string>();
                    var getModule = (from x in context.Training_Module
                                     where x.skillIdFK == getSkillID && x.userTypeIdFK == getTypeID
                                     select x.moduleName);
                    foreach (var item in getModule)
                    {
                        module.Add(item);
                    }
                    moduleBox.Items.AddRange(module.ToArray());
                }
                else
                {
                    MessageBox.Show("Please select a skill and Trainee Catergory!");
                }

            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var checkDuration = (from x in context.Training_Module
                                     where x.moduleName == moduleBox.SelectedItem.ToString()
                                     select x.durationDays).First();
                if (dateTimePicker1.Value > DateTime.Parse("29/7/2020"))
                {
                    MessageBox.Show("Cannot add if start date is after competition!");

                }
                else
                {
                    var getLatest = (from x in context.Assign_Training
                                       orderby x.trainingId descending
                                       select x).FirstOrDefault();
                    if (getLatest != null)
                    {
                        var getLatestID = (from x in context.Assign_Training
                                           orderby x.trainingId descending
                                           select x.trainingId).FirstOrDefault() + 1;
                        List<string> newRow = new List<string>()
                        {
                        skillBox.SelectedItem.ToString(), categoryBox.SelectedItem.ToString(), moduleBox.SelectedItem.ToString(),
                        getLatestID.ToString(), dateTimePicker1.Value.ToString()
                        };
                        dataGridView1.Rows.Add(newRow.ToArray());
                    }
                    else
                    {
                        if (dataGridView1.Rows.Count == 0)
                        {
                            List<string> newRow = new List<string>()
                        {
                        skillBox.SelectedItem.ToString(), categoryBox.SelectedItem.ToString(), moduleBox.SelectedItem.ToString(),
                        1.ToString(), dateTimePicker1.Value.ToString()
                        };
                            dataGridView1.Rows.Add(newRow.ToArray());
                        }
                        else
                        {
                            List<int> id = new List<int>();
                            foreach (DataGridViewRow rows in dataGridView1.Rows)
                            {
                                id.Add(Convert.ToInt32(rows.Cells[3].Value));
                            }
                            var newID = id.Max() + 1;
                            List<string> newRow = new List<string>()
                            {
                            skillBox.SelectedItem.ToString(), categoryBox.SelectedItem.ToString(), moduleBox.SelectedItem.ToString(),
                                newID.ToString(), dateTimePicker1.Value.ToString()
                        };
                            dataGridView1.Rows.Add(newRow.ToArray());
                        }
                        
                    }
                    
                    
                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete!");
            }
            else
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        private void assignBtn_Click(object sender, EventArgs e)
        {
            using (var context  = new Session4Entities())
            {
                foreach (DataGridViewRow rows in dataGridView1.Rows)
                {
                    var skillName = rows.Cells[0].Value.ToString();
                    var getSkillID = (from x in context.Skills
                                      where x.skillName == skillName
                                      select x.skillId).First();
                    var categoryName = rows.Cells[1].Value.ToString();
                    var getCategoryID = (from x in context.User_Type
                                         where x.userTypeName == categoryName
                                         select x.userTypeId).First();
                    var moduleName = rows.Cells[2].Value.ToString();
                    var getModuleID = (from x in context.Training_Module
                                       where x.moduleName == moduleName
                                       select x.moduleId).First();
                    var getAllID = (from x in context.Users
                                    where x.User_Type.userTypeName == categoryName && x.Skill.skillName == skillName
                                    select x.userId);
                    foreach (var item in getAllID)
                    {
                        context.Assign_Training.Add(new Assign_Training()
                        {
                            startDate = Convert.ToDateTime(rows.Cells[4].Value),
                            progress = 0,
                            trainingId = Convert.ToInt32(rows.Cells[3].Value),
                            userIdFK = item,
                            moduleIdFK = getModuleID

                        });
                    }
                    
                }
                context.SaveChanges();
                this.Hide();
                (new AdminMain(_userID)).ShowDialog();
                this.Close();
            }
        }
    }
}
