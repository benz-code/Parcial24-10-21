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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);




        private void pictureBox1_Click(object sender, EventArgs e)
        {


            MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=parcial; Uid=root;  Pwd = usbw;");
            string xd = txtid.Text;
            string sd = txtpassword.Text;
            string kl = txtid.Text + txtpassword.Text;
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `id` = @ID", conexion);

            command.Parameters.Add("@ID", MySqlDbType.VarChar).Value = txtid.Text;






            adapter.SelectCommand = command;



            adapter.Fill(table);



            if (table.Rows.Count > 0)
            {

                MySqlConnection conexion2 = new MySqlConnection("Server=localhost;Database=parcial; Uid=root;  Pwd = usbw;");
                conexion2.Open();
                string actualizar = "UPDATE users SET ID='" + txtid.Text +
                    "',password='" + txtpassword.Text +
                     "'WHERE ID='" + txtid.Text +
                     "';";
                MySqlCommand comando = new MySqlCommand(actualizar, conexion2);
                comando.ExecuteNonQuery();
                string mensaje = "Usted a actualizado con exito los datos";
                if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Datos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Yes)
                    conexion2.Close();


                this.Hide();
                Form1 mv = new Form1();
                mv.ShowDialog();
                this.Close();
            }

            else
            {
                if (kl.Trim().Equals(""))
                {
                    MetroFramework.MetroMessageBox.Show(this, "No se ha detectado un informacion para el cambio de contraseña, Porfavor verifique sus Datos", "Aletar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (xd.Trim().Equals(""))
                {
                    MetroFramework.MetroMessageBox.Show(this, "No se ha llenado el espacio de ID, porfavor llenarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                else if (sd.Trim().Equals(""))
                {
                    MetroFramework.MetroMessageBox.Show(this, "No se ha llena es pacio de nueva contrase, porfavor llenarlo para el cambio de contraseña", "Aletar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Este usuario no existe, Compruese su ID y vuelva intentar el cambio de su contraseña", "Aletar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mv = new Form1();
            mv.ShowDialog();
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
