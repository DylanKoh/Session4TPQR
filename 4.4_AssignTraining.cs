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
                #region Populating Skill Combo Box
                var getSkills = (from x in context.Skills
                                 select x.skillName);
                HashSet<string> skills = new HashSet<string>();
                foreach (var item in getSkills)
                {
                    skills.Add(item);
                }
                skillBox.Items.AddRange(skills.ToArray());
                #endregion

                #region Populating Category Combo box
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
                #endregion

                //Initial loading of DGV if DB has records of assigned trainings
                GridRefresh();



            }


        }

        //Redirects user back to Admin Main Menu page - 4.2
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminMain(_userID)).ShowDialog();
            this.Close();
        }

        private void moduleBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// This method loads data in from DB into DGV if there is a record of Assigned Training that exist
        /// </summary>
        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Skill";
            dataGridView1.Columns[1].Name = "Training Category";
            dataGridView1.Columns[2].Name = "Training Module";
            dataGridView1.Columns[3].Name = "Module ID";
            dataGridView1.Columns[4].Name = "Date";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            using (var context = new Session4Entities())
            {
                var getTraining = (from x in context.Assign_Training
                                   select x);
                foreach (var item in getTraining.Select(x => x.moduleIdFK).Distinct())
                {
                    var getDetails = (from x in context.Assign_Training
                                      where x.moduleIdFK == item
                                      select x).FirstOrDefault();
                    List<string> rows = new List<string>()
                    {
                        getDetails.Training_Module.Skill.skillName, getDetails.Training_Module.User_Type.userTypeName, getDetails.Training_Module.moduleName,
                        item.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
            }
        }

        /// <summary>
        /// When the Combo Box for Module is clicked, this code runs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moduleBox_Click(object sender, EventArgs e)
        {
            moduleBox.Items.Clear();
            using (var context = new Session4Entities())
            {
                //Checks if Skill and Category is selected
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
                                     select x);

                    ///Checks if DB have the modules assigned. If not, add to the Module Combo box
                    foreach (var item in getModule)
                    {
                        var checkTraining = (from x in context.Assign_Training
                                             where x.moduleIdFK == item.moduleId
                                             select x).FirstOrDefault();
                        if (checkTraining == null)
                            module.Add(item.moduleName);
                        else continue;
                    }
                    moduleBox.Items.AddRange(module.ToArray());

                    ///Check if DGV contains the module that has assigned then deleting the relevant module from the relevant skill and category
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        var moduleID = Convert.ToInt32(item.Cells[3].Value);
                        var checkModules = (from x in context.Training_Module
                                            where x.moduleId == moduleID
                                            select x.moduleName).FirstOrDefault();
                        moduleBox.Items.Remove(checkModules);
                    }
                }

                else
                {
                    MessageBox.Show("Please select a skill and Trainee Catergory!");
                }

            }
        }

        /// <summary>
        /// Triggered when Add button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var checkDuration = (from x in context.Training_Module
                                     where x.moduleName == moduleBox.SelectedItem.ToString()
                                     select x.durationDays).First();
                ///Check if duration from start date, whether it is after Competiton or will it overrun to or over Competiton date
                if (dateTimePicker1.Value > DateTime.Parse("26/7/2020") || dateTimePicker1.Value.AddDays(checkDuration) >= DateTime.Parse("26/7/2020"))
                {
                    MessageBox.Show("Cannot add if start date is after competition or duration will run into competition date!", "Invalid start date",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    var getID = (from x in context.Training_Module
                                 where x.moduleName == moduleBox.SelectedItem.ToString()
                                 select x.moduleId).FirstOrDefault();

                    List<string> newRow = new List<string>()
                        {
                            skillBox.SelectedItem.ToString(), categoryBox.SelectedItem.ToString(), moduleBox.SelectedItem.ToString(),
                            getID.ToString(), dateTimePicker1.Value.ToString()
                        };
                    dataGridView1.Rows.Add(newRow.ToArray());
                    moduleBox.Items.Remove(moduleBox.SelectedItem);




                }
            }
        }

        /// <summary>
        /// Triggered when Remove button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeBtn_Click(object sender, EventArgs e)
        {
            //Check if there is even any rows selected
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete!");
            }
            else
            {
                ///Removes training from DB, then adds the mopdule back to Combo box
                using (var context = new Session4Entities())
                {
                    var moduleID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                    var getTrainingsCheck = (from x in context.Assign_Training
                                             where x.moduleIdFK == moduleID
                                             select x).FirstOrDefault();
                    if (getTrainingsCheck != null)
                    {
                        var getTrainings = (from x in context.Assign_Training
                                            where x.moduleIdFK == moduleID
                                            select x).ToList();
                        foreach (var item in getTrainings)
                        {
                            context.Assign_Training.Remove(item);
                            context.SaveChanges();
                        }
                    }
                    moduleBox.Items.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }

            }
        }

        /// <summary>
        /// Triggered when the Add button is clicked. Checks if training is assigned already in DB, else assign training
        /// to all of the category's and skill's participants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void assignBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
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


                    var getAllID = (from x in context.Users
                                    where x.User_Type.userTypeName == categoryName && x.Skill.skillName == skillName
                                    select x.userId).ToList();
                    var ID = Convert.ToInt32(rows.Cells[3].Value);
                    var checkIfIDExist = (from x in context.Assign_Training
                                          where x.moduleIdFK == ID
                                          select x).FirstOrDefault();
                    if (checkIfIDExist == null)
                    {
                        foreach (var item in getAllID)
                        {
                            context.Assign_Training.Add(new Assign_Training()
                            {
                                startDate = Convert.ToDateTime(rows.Cells[4].Value),
                                progress = 0,
                                userIdFK = item,
                                moduleIdFK = Convert.ToInt32(rows.Cells[3].Value)
                            });
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        continue;
                    }

                }

            }
            this.Hide();
            (new AdminMain(_userID)).ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Whenever skill is changed, clear the module box selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skillBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            moduleBox.Items.Clear();
        }

        /// <summary>
        /// Whenever the category is changed, clear the module box selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            moduleBox.Items.Clear();
        }
    }
}
