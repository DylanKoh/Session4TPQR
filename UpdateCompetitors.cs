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
        }

        private void competitorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void competitorBox_Click(object sender, EventArgs e)
        {
            competitorBox.Items.Clear();
            if (skillBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Skill!");
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

            if (nameBtn.Checked)
            {

            }
            else if (endDateBtn.Checked)
            {

            }
            else
            {
                using (var context =  new Session4Entities())
                {
                    //var getAssignDetails = (from x in context.Assign_Training)
                }
               
            }
        }

        private void endDateBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }
    }
}
