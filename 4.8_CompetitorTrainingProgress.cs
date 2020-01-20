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
    public partial class CompetitorTrainingProgress : Form
    {
        string _userID;
        public CompetitorTrainingProgress(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        //Redirects user back to Expert Main Menu page - 4.3
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ExpertMain(_userID)).ShowDialog();
            this.Close();
        }

        private void CompetitorTrainingProgress_Load(object sender, EventArgs e)
        {
            #region Populate the skill of the Expert that logged in
            using (var context = new Session4Entities())
            {
                var getSkillOfExpert = (from x in context.Users
                                        where x.userId == _userID
                                        select x.Skill.skillName).First();
                skillLbl.Text += getSkillOfExpert;
            }
            #endregion

            //Loads the DGV based on relevant skill
            GridRefresh();
        }

        /// <summary>
        /// Gets all competitors of the Expert skill trait and show their training progress of assigned training
        /// </summary>
        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Competitors Name";

            using (var context = new Session4Entities())
            {
                var getCompetitorsForSkill = (from x in context.Users
                                              where skillLbl.Text.Contains(x.Skill.skillName) && x.User_Type.userTypeName == "Competitor"
                                              select x);
                var getModulesColumn = (from x in context.Assign_Training
                                        where x.User.User_Type.userTypeName == "Competitor" && skillLbl.Text.Contains(x.User.Skill.skillName)
                                        select x.Training_Module.moduleName).Distinct();
                foreach (var item in getModulesColumn)
                {
                    dataGridView1.Columns.Add(item, item);
                }
                foreach (var competitor in getCompetitorsForSkill)
                {
                    var rows = new List<string>();
                    var getModules = (from x in context.Assign_Training
                                      where x.userIdFK == competitor.userId
                                      select x);
                    rows.Add(competitor.name);
                    foreach (var item in getModules)
                    {
                        rows.Add(item.progress.ToString());
                    }
                    dataGridView1.Rows.Add(rows.ToArray());
                }

                //Checks if any of the cell value is 0, then color red backcolor
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if (column.Index == 0) continue;
                        if (Convert.ToInt32(dataGridView1.Rows[item.Index].Cells[column.Index].Value) == 0)
                        {
                            dataGridView1.Rows[item.Index].Cells[column.Index].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
    }
}
