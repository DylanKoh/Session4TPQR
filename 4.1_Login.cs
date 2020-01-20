using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session4
{
    //Initial Commit
    public partial class Login : Form
    {
        //Initialise Competition Date
        DateTime endTime = new DateTime(2020, 07, 26, 9, 0, 0);
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Triggered when Login button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                //Checks if User ID or Password field is empty
                if (userIDBox.Text.Trim() == "" || passwordBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please check your login details!", "Empty Field(s)", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    var getUser = (from x in context.Users
                                   where x.userId == userIDBox.Text
                                   select x).FirstOrDefault();

                    //Check if User exist in DB
                    if (getUser == null)
                    {
                        MessageBox.Show("User does not exist!", "Invalid Login credentials",MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                    //Check if password keyed in matches DB's password
                    else if (getUser.passwd != passwordBox.Text)
                    {
                        MessageBox.Show("Password is wrong!", "Invalid Login credentials", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Welcome {getUser.name}!", "Successful Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //If user is Admin, direct to Admin Main Menu page - 4.2
                        if (getUser.User_Type.userTypeName == "Admin")
                        {
                            this.Hide();
                            (new AdminMain(getUser.userId)).ShowDialog();
                            this.Close();
                        }

                        //If user is Expert, direct to Expert Main Menu page - 4.3
                        else if (getUser.User_Type.userTypeName == "Expert")
                        {
                            this.Hide();
                            (new ExpertMain(getUser.userId)).ShowDialog();
                            this.Close();
                        }

                        //If user is Competitor, direct to Update Competitor's Record page - 4.6
                        else
                        {
                            this.Hide();
                            (new UpdateCompetitors()).ShowDialog();
                            this.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Triggered when the Choose button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "csv|*.csv",
                InitialDirectory = "C:/",
                Title = "Import CSV data"
            };
            var i = openFileDialog.ShowDialog();

            //If file selected, then store file name in textbox
            if (i == DialogResult.OK)
            {
                textBox3.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Onload, load the timer to Competition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {

            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(timer1_Tick);
            TimeSpan ts = endTime.Subtract(DateTime.Now);
            countdownTime.Text = $"{ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'")} till event starts!";
            t.Start(); ;
        }

        /// <summary>
        /// Reads the CSV from filepath from the textbox, then check if account exist. If it doesnm't,
        /// add to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadBtn_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(textBox3.Text);
            for (int i = 1; i < lines.Count(); i++)
            {
                using (var context = new Session4Entities())
                {
                    var values = lines[i].Split(',');
                    var id = values[0].Trim();
                    var checkIfExist = (from x in context.Users
                                        where x.userId == id
                                        select x).FirstOrDefault();
                    if (checkIfExist == null)
                    {
                        context.Users.Add(new User()
                        {
                            userId = values[0].Trim(),
                            skillIdFK = Int32.Parse(values[1]),
                            passwd = values[2].Trim(),
                            name = values[3].Trim(),
                            userTypeIdFK = Int32.Parse(values[4])
                        });
                        context.SaveChanges();
                    }
                    
                }
            }
            MessageBox.Show("Users added!", "Successful account creation(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// EventHandler for Timer ticking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = endTime.Subtract(DateTime.Now);
            countdownTime.Text = $"{ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'")} till event starts!";
        }
    }
}
