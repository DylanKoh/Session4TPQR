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
    public partial class ExpertMain : Form
    {
        string _userID;
        public ExpertMain(string userId)
        {
            InitializeComponent();
            _userID = userId;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        private void assignBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new UpdateExpertRecords(_userID)).ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new CompetitorTrainingProgress(_userID)).ShowDialog();
            this.Close();
        }
    }
}
