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
        DateTime endTime = new DateTime(2020, 07, 26, 9, 0, 0);
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session4Entities())
            {
                if (userIDBox.Text.Trim() == "" || passwordBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please check your login details!", "Empty Field(s)");
                }
                else
                {
                    var getUser = (from x in context.Users
                                   where x.userId == userIDBox.Text
                                   select x).FirstOrDefault();
                    if (getUser == null)
                    {
                        MessageBox.Show("User does not exist!");
                    }
                    else if (getUser.passwd != passwordBox.Text)
                    {
                        MessageBox.Show("Password is wrong!");
                    }
                    else
                    {
                        MessageBox.Show($"Welcome {getUser.name}!", "Successful Login");
                        if (getUser.User_Type.userTypeName == "Admin")
                        {
                            this.Hide();
                            (new AdminMain(getUser.userId)).ShowDialog();
                            this.Close();
                        }
                        else if (getUser.User_Type.userTypeName == "Expert")
                        {
                            this.Hide();
                            (new ExpertMain(getUser.userId)).ShowDialog();
                            this.Close();
                        }
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

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "csv|*.csv",
                InitialDirectory = "C:/",
                Title = "Import CSV data"
            };
            var i = openFileDialog.ShowDialog();
            if (i == DialogResult.OK)
            {
                textBox3.Text = openFileDialog.FileName;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(timer1_Tick);
            TimeSpan ts = endTime.Subtract(DateTime.Now);
            countdownTime.Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
            t.Start(); ;
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(textBox3.Text);
            for (int i = 1; i < lines.Count(); i++)
            {
                using (var context = new Session4Entities())
                {
                    var values = lines[i].Split(',');
                    var id = values[0];
                    var checkIfExist = (from x in context.Users
                                        where x.userId == id
                                        select x).FirstOrDefault();
                    if (checkIfExist == null)
                    {
                        context.Users.Add(new User()
                        {
                            userId = values[0],
                            skillIdFK = Int32.Parse(values[1]),
                            passwd = values[2],
                            name = values[3],
                            userTypeIdFK = Int32.Parse(values[4])
                        });
                        context.SaveChanges();
                    }
                    
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = endTime.Subtract(DateTime.Now);
            countdownTime.Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
        }
    }
}
