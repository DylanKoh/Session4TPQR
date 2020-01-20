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

        //Redirects user back to Login page - 4.1
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        //Redirects user to Update Expert Records page - 4.7
        private void updateExpertRecordsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new UpdateExpertRecords(_userID)).ShowDialog();
            this.Close();
        }

        //Redirects user to Competitors Training Progress - 4.8
        private void trackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new CompetitorTrainingProgress(_userID)).ShowDialog();
            this.Close();
        }
    }
}
