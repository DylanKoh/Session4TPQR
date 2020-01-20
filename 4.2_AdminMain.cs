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
    public partial class AdminMain : Form
    {
        string _userID;
        public AdminMain(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        //Redirects user back to Login page - 4.1
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        //Redirects user to Assign Training page - 4.4
        private void assignBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AssignTraining(_userID)).ShowDialog();
            this.Close();
        }

        //Redirects user to Track Overall Training Progress page - 4.5
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminTrainingProgress(_userID)).ShowDialog();
            this.Close();
        }
    }
}
