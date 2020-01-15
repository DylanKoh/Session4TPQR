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

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ExpertMain(_userID)).ShowDialog();
            this.Close();
        }

        private void CompetitorTrainingProgress_Load(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                var getSkillOfExpert = (from x in context.Users
                                        where x.userId == _userID
                                        select x.Skill.skillName).First();
                skillLbl.Text += getSkillOfExpert;
            }
            
        }
    }
}
