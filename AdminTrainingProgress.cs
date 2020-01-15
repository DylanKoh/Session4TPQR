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
            GridRefresh();
        }
        private void GridRefresh()
        {
            NumberList.ColumnCount = 1;
            NumberList.Columns[0].Name = "Trainee Category";

            using (var context = new Session4Entities())
            {
                var getTrainingStart = (from x in context.Assign_Training
                                        orderby x.startDate ascending
                                        select x.startDate).ToList();
                var getDistinctDates = (from x in getTrainingStart
                                        select x.ToString("MM/yyyy")).Distinct();
                foreach (var item in getDistinctDates)
                {
                    NumberList.Columns.Add(item, item);
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
                                               where x.startDate.ToString("MM/yyyy").Equals(dates) && x.User.User_Type.userTypeName == "Competitor"
                                               select x).Count();

                    var getStartedTraining2 = (from x in initialQuery
                                               where x.startDate.ToString("MM/yyyy").Equals(dates) && x.User.User_Type.userTypeName == "Expert"
                                               select x).Count();
                    row1.Add(getStartedTraining1.ToString());
                    row2.Add(getStartedTraining2.ToString());
                }
                NumberList.Rows.Add(row1);
                NumberList.Rows.Add(row2);
            }
        }
    }
}
