using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liberty_Travel_And_Tours
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bround1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f = new Form4();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

        private void bround2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f = new Form5();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }
    }
}
