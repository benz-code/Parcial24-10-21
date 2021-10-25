using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace wards23
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            Form6 Frm = new Form6();
         
            Frm.TopLevel = false;
            panel3.Controls.Add(Frm);
            Frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
