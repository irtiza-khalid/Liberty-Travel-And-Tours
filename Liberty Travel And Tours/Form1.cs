using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;

namespace Liberty_Travel_And_Tours
{
    public partial class Form1 : Form
    {
        String admin_username = "admin";
        String admin_password = "admin123";
        public Form1()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "YwJ6GYeglQqKsiDgqLoFnNqWH9pYFMQHp8NMCLeu",
            BasePath = "https://liberty-travel-and-tours-2eed9-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient Client;
        private void Form1_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(config);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void bround2_Click(object sender, EventArgs e)
        {

        }

        private void bround1_Click(object sender, EventArgs e)
        {
            string sf = round1.Text;
            if(string.IsNullOrWhiteSpace(round1.Text)&& string.IsNullOrWhiteSpace(round2.Text))
            {
                MessageBox.Show("please fill all feilds");
                return;
            }
            FirebaseResponse res = Client.Get("users/"+ round1.Text);
          
            userInfo usr=res.ResultAs<userInfo>();
            userInfo uuu = new userInfo()
            {
              username = round1.Text,
                pass = round2.Text 
            };
            if(userInfo.isequal(usr,uuu))
            {
                this.Hide();
                Form3 f = new Form3();
                f.FormClosed += (s, args) => this.Close();
                f.Show();


            }
            else if(round1.Text == admin_username && round2.Text == admin_password)
            {
                this.Hide();
                Form6 f = new Form6();
                f.FormClosed += (s, args) => this.Close();
                f.Show();
            }
            else
            {
                userInfo.geterror();
            }
           
        }

        private void round2_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                round2.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;

            }
            else
            {
                //Hides Textbox password
                round2.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                round2.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;

            }
            else
            {
                //Hides Textbox password
                round2.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }

        }

        private void label10_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

        private void round1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
