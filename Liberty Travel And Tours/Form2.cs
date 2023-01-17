using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Liberty_Travel_And_Tours
{
    public partial class Form2 : Form
    {
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(config);
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bround1_Click(object sender, EventArgs e)
        {
            CreateUser();
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
        private async void CreateUser()
        {

            var Info = new userInfo
            {              
            email = round1.Text,
                username = round3.Text,
                pass =round2.Text
            };
             FirebaseResponse respone = await Client.SetAsync("users/" +round3.Text,Info);
            MessageBox.Show("user registered succesfully");
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

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }
    }
}
