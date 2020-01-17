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
    public partial class AdminTrainingProgress : Form
    {
        string _userID;
        public AdminTrainingProgress(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminMain(_userID)).ShowDialog();
            this.Close();
        }

        private void AdminTrainingProgress_Load(object sender, EventArgs e)
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
            }
        }

        private void skillBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumberList.Rows.Clear();
            statusExpertList.Rows.Clear();
            statusCompetitorsList.Rows.Clear();
            NumberList.Columns.Clear();
            chart1.Series.Clear();
            GridRefresh();
            
        }
        private void GridRefresh()
        {

            NumberList.ColumnCount = 1;
            NumberList.Columns[0].Name = "Trainee Category";

            statusExpertList.ColumnCount = 1;
            statusExpertList.Columns[0].Name = "Status\n(Experts)";

            statusCompetitorsList.ColumnCount = 1;
            statusCompetitorsList.Columns[0].Name = "Status\n(Competitors)";

            using (var context = new Session4Entities())
            {
                #region Loading of 1st DGV
                var getTrainingStart = (from x in context.Assign_Training
                                        where x.User.Skill.skillName == skillBox.SelectedItem.ToString()
                                        orderby x.startDate ascending
                                        select x.startDate).ToList();
                var getDistinctDates = (from x in getTrainingStart
                                        select x.ToString("MM/yyyy")).Distinct();
                foreach (var item in getDistinctDates)
                {
                    NumberList.Columns.Add($"No. of training started on {item}", $"No. of training started on {item}");
                }

                var getCategory = (from x in context.User_Type
                                   where x.userTypeName != "Admin"
                                   select x.userTypeName).Distinct();
                List<string> row1 = new List<string>();
                List<string> row2 = new List<string>();
                foreach (var item in getCategory)
                {
                    if (item == "Competitor")
                    {
                        row1.Add(item);
                    }
                    else
                    {
                        row2.Add(item);
                    }
                }
                foreach (var dates in getDistinctDates)
                {
                    var initialQuery = (from x in context.Assign_Training
                                        select x).ToList();

                    var getStartedTraining1 = (from x in initialQuery
                                               where x.startDate.ToString("MM/yyyy").Equals(dates) && x.User.User_Type.userTypeName == "Competitor" && x.User.Skill.skillName == skillBox.SelectedItem.ToString()
                                               select x).Count();

                    var getStartedTraining2 = (from x in initialQuery
                                               where x.startDate.ToString("MM/yyyy").Equals(dates) && x.User.User_Type.userTypeName == "Expert" && x.User.Skill.skillName == skillBox.SelectedItem.ToString()
                                               select x).Count();
                    row1.Add(getStartedTraining1.ToString());
                    row2.Add(getStartedTraining2.ToString());
                }
                NumberList.Rows.Add(row1.ToArray());
                NumberList.Rows.Add(row2.ToArray());
                #endregion

                #region Loading of 2nd DGV
                var getModulesExpert = (from x in context.Assign_Training
                                        where x.User.Skill.skillName == skillBox.SelectedItem.ToString() && x.User.User_Type.userTypeName == "Expert"
                                        select x.Training_Module.moduleName).Distinct();
                var row1StatusExpert = new List<string>() { "Completed" };
                var row2StatusExpert = new List<string>() { "In Progress" };
                var row3StatusExpert = new List<string>() { "Not Started" };
                foreach (var item in getModulesExpert)
                {
                    statusExpertList.Columns.Add(item, item);
                    var getCompleted = (from x in context.Assign_Training
                                        where x.Training_Module.moduleName == item && x.progress == 100
                                        select x).FirstOrDefault();
                    var getProgress = (from x in context.Assign_Training
                                       where x.Training_Module.moduleName == item && x.progress <= 100 && x.progress > 0
                                       select x).FirstOrDefault();
                    var getNot = (from x in context.Assign_Training
                                  where x.Training_Module.moduleName == item && x.progress == 0
                                  select x).FirstOrDefault();
                    if (getCompleted != null)
                    {
                        var getCompletedAmt = (from x in context.Assign_Training
                                               where x.Training_Module.moduleName == item && x.progress == 100
                                               select x).Count();
                        row1StatusExpert.Add(getCompletedAmt.ToString());
                    }
                    else
                    {
                        row1StatusExpert.Add(0.ToString());
                    }

                    if (getProgress != null)
                    {
                        var getProgressAmt = (from x in context.Assign_Training
                                              where x.Training_Module.moduleName == item && x.progress <= 100 && x.progress > 0
                                              select x).Count();
                        row2StatusExpert.Add(getProgressAmt.ToString());
                    }
                    else
                    {
                        row2StatusExpert.Add(0.ToString());
                    }
                    if (getNot != null)
                    {
                        var getNotAmt = (from x in context.Assign_Training
                                         where x.Training_Module.moduleName == item && x.progress == 0
                                         select x).Count();
                        row3StatusExpert.Add(getNotAmt.ToString());
                    }
                    else
                    {
                        row3StatusExpert.Add(0.ToString());
                    }
                }
                statusExpertList.Rows.Add(row1StatusExpert.ToArray());
                statusExpertList.Rows.Add(row2StatusExpert.ToArray());
                statusExpertList.Rows.Add(row3StatusExpert.ToArray());

                #endregion

                #region Loading of 3rd DGV
                var getModulesCompetitor = (from x in context.Assign_Training
                                            where x.User.Skill.skillName == skillBox.SelectedItem.ToString() && x.User.User_Type.userTypeName == "Competitor"
                                            select x.Training_Module.moduleName).Distinct();
                var row1StatusCompetitor = new List<string>() { "Completed" };
                var row2StatusCompetitor = new List<string>() { "In Progress" };
                var row3StatusCompetitor = new List<string>() { "Not Started" };
                foreach (var item in getModulesCompetitor)
                {
                    statusCompetitorsList.Columns.Add(item, item);
                    var getCompleted = (from x in context.Assign_Training
                                        where x.Training_Module.moduleName == item && x.progress == 100
                                        select x).FirstOrDefault();
                    var getProgress = (from x in context.Assign_Training
                                       where x.Training_Module.moduleName == item && x.progress <= 100 && x.progress > 0
                                       select x).FirstOrDefault();
                    var getNot = (from x in context.Assign_Training
                                  where x.Training_Module.moduleName == item && x.progress == 0
                                  select x).FirstOrDefault();
                    if (getCompleted != null)
                    {
                        var getCompletedAmt = (from x in context.Assign_Training
                                               where x.Training_Module.moduleName == item && x.progress == 100
                                               select x).Count();
                        row1StatusCompetitor.Add(getCompletedAmt.ToString());
                    }
                    else
                    {
                        row1StatusCompetitor.Add(0.ToString());
                    }

                    if (getProgress != null)
                    {
                        var getProgressAmt = (from x in context.Assign_Training
                                              where x.Training_Module.moduleName == item && x.progress <= 100 && x.progress > 0
                                              select x).Count();
                        row2StatusCompetitor.Add(getProgressAmt.ToString());
                    }
                    else
                    {
                        row2StatusCompetitor.Add(0.ToString());
                    }
                    if (getNot != null)
                    {
                        var getNotAmt = (from x in context.Assign_Training
                                         where x.Training_Module.moduleName == item && x.progress == 0
                                         select x).Count();
                        row3StatusCompetitor.Add(getNotAmt.ToString());
                    }
                    else
                    {
                        row3StatusCompetitor.Add(0.ToString());
                    }
                }
                statusCompetitorsList.Rows.Add(row1StatusCompetitor.ToArray());
                statusCompetitorsList.Rows.Add(row2StatusCompetitor.ToArray());
                statusCompetitorsList.Rows.Add(row3StatusCompetitor.ToArray());
                #endregion
                chart1.ChartAreas[0].AxisY.Title = "Number of Competitors";
                #region Load Chart
                foreach (DataGridViewRow rows in statusCompetitorsList.Rows)
                {
                    chart1.Series.Add(rows.Cells[0].Value.ToString());
                    foreach (DataGridViewColumn columns in statusCompetitorsList.Columns)
                    {
                        if (columns.Index == 0) continue;
                        var point = statusCompetitorsList.Rows[rows.Index].Cells[columns.Index].Value;
                        chart1.Series[$"{rows.Cells[0].Value.ToString()}"].Points.AddXY(columns.HeaderText, point);
                        
                    }
                }
                #endregion
            }

        }
    }
}
