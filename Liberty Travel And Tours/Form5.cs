using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liberty_Travel_And_Tours
{
    public partial class Form5 : Form
    {
        static string output, output2, output3;
        public Form5()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        IFirebaseClient Client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "YwJ6GYeglQqKsiDgqLoFnNqWH9pYFMQHp8NMCLeu",
            BasePath = "https://liberty-travel-and-tours-2eed9-default-rtdb.firebaseio.com/"
        };
        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                Client = new FireSharp.FirebaseClient(config);
            }
            catch

            {
                MessageBox.Show("connects error");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                pictureBox2.Image = image.GetThumbnailImage(250, 200, null, new IntPtr());
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                pictureBox4.Image = image.GetThumbnailImage(250, 200, null, new IntPtr());

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                pictureBox5.Image = image.GetThumbnailImage(250, 200, null, new IntPtr());

            }
        }

        private async void bround1_Click(object sender, EventArgs e)
        {
            bool isNullOrEmpty = pictureBox2 == null || pictureBox2.Image == null || pictureBox4 == null || pictureBox4.Image == null || pictureBox5 == null || pictureBox5.Image == null;
            if (isNullOrEmpty == false)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, ImageFormat.Jpeg);
                byte[] a = ms.GetBuffer();
                output = Convert.ToBase64String(a);


                MemoryStream ms2 = new MemoryStream();
                pictureBox4.Image.Save(ms2, ImageFormat.Jpeg);
                byte[] a2 = ms2.GetBuffer();
                output2 = Convert.ToBase64String(a2);

                MemoryStream ms3 = new MemoryStream();
                pictureBox5.Image.Save(ms3, ImageFormat.Jpeg);
                byte[] a3 = ms3.GetBuffer();
                output3 = Convert.ToBase64String(a3);
            }

            if (string.IsNullOrWhiteSpace(round10.Text) || string.IsNullOrWhiteSpace(round11.Text) || string.IsNullOrWhiteSpace(round12.Text) || string.IsNullOrWhiteSpace(round8.Text) || string.IsNullOrWhiteSpace(round14.Text) || isNullOrEmpty == true || string.IsNullOrWhiteSpace(round9.Text) || string.IsNullOrWhiteSpace(round7.Text) || string.IsNullOrWhiteSpace(round6.Text) || string.IsNullOrWhiteSpace(round2.Text) || string.IsNullOrWhiteSpace(round5.Text) || string.IsNullOrWhiteSpace(round4.Text) || string.IsNullOrWhiteSpace(round1.Text) || string.IsNullOrWhiteSpace(round13.Text) || string.IsNullOrWhiteSpace(round3.Text))
            {
                MessageBox.Show("please fill all feilds");
                return;
            }



            EmployementVisa ev = new EmployementVisa()
            {
                Firstname = round3.Text,
                Lastname = round13.Text,
                Email = round1.Text,
                Cnic = int.Parse(round2.Text),
                Passportno = int.Parse(round4.Text),
                Age = int.Parse(round5.Text),
                Martialst = round6.Text,
                Visatype = round7.Text,
                Dob = round9.Text,
                Photo = output,
                Idcopy = output2,
                Passcopy = output3,
                Passportissue = round10.Text,
                Passportexpiry = round11.Text,
                Gender = round12.Text,
                Phoneno = round8.Text,
                Country = round14.Text,
                status = round15.Text,
            };
            SetResponse setResponse = await Client.SetAsync("EmployementVisa/" + round3.Text, ev);
            EmployementVisa result = setResponse.ResultAs<EmployementVisa>();
            pictureBox2.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;

            MessageBox.Show("succesfully enter into database");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

        private void bround1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
