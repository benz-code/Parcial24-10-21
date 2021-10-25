using MySql.Data.MySqlClient;
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

namespace wards23
{
    public partial class Form1 : Form
    {

 



        public Form1()
        {
            
            InitializeComponent();
           
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);





        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 mv = new Form2();
            mv.ShowDialog();
            this.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            

            if ((textBox1.Text == "admin") && (textBox2.Text == "admin"))
            {
                this.Hide();
                Form5 mv = new Form5();
                mv.ShowDialog();
                this.Close();
            }
            else
            {
               
               

                DB db = new DB();






                String username = textBox1.Text;
                String password = textBox2.Text;
                string xd = textBox2.Text + textBox1.Text;

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", db.getConnection());

                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

                



                adapter.SelectCommand = command;



                adapter.Fill(table);




                if (table.Rows.Count > 0)
                {
                    if (xd.Trim().Equals(""))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "No se ha detectado un informacion de usuario ", "Aletar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        
                        


                        this.Hide();
                       
                        Form3 mv = new Form3();
                        mv.lblitalo.Text = textBox1.Text;
                        
                    
                        MetroFramework.MetroMessageBox.Show(this, "Te damos la bievenida a nuestro formulario " + username + " que la pases bien", "Bievenida",MessageBoxButtons.OK, MessageBoxIcon.None);

                        
                        mv.ShowDialog();
                      
                        this.Close();

                        
                    }
                }
                else
                {



                    if (username.Trim().Equals(""))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "No se ha detectado un nombre de usuario. Porfavor ingrese un nombre de usuario", "Aletar", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    else if (password.Trim().Equals(""))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "No se ha detectado alguna contraseña. Porfavor ingrese una contraseña", "Aletar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Este usuario no existe o los datos son incorrectos. Comrpuebse sus datos escritos", "Aletar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            
            this.WindowState= FormWindowState.Minimized;
            
            


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form7 mv = new Form7();
            mv.ShowDialog();
            this.Close();
        }
    }
    
}
