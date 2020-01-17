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
    }
}
