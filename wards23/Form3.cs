using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace wards23
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        private void abriform(object formulariohija)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form fh = formulariohija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(fh);
            this.panel2.Tag = fh;
            fh.Show();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            


        }
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mensaje de alerta");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("mensaje de alerta");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_VisibleChanged(object sender, EventArgs e)
        {
            
        }

      

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void lblitalo_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

       

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

       

        private void button1_Click_2(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button1_MouseCaptureChanged(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint_2(object sender, PaintEventArgs e)
        {
          
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel2.Visible = true;
            abriform(new Form8());



        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            this.Hide();

            Form4 mv = new Form4();
            mv.lblcc.Text = lblitalo.Text;






            mv.ShowDialog();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel2.Visible = true;
            abriform(new Form9());
        }
    }
}
