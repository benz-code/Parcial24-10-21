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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void txtfirsname_TextChanged(object sender, EventArgs e)
        {
            String fname = txtfirsname.Text;
            if (fname.ToLower().Trim().Equals("fi"))
            {
                txtfirsname.Text = "";
                txtfirsname.ForeColor = Color.Black;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 mv = new Form1();
            mv.ShowDialog();
            this.Close();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `emailaddress`, `username`, `password`) VALUES (@fn, @ln, @email, @usn, @pass)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = txtfirsname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = txtlastname.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtemail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtusuario.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = txtpassword.Text;


            db.openConnection();


            if (!checkTextBoxesValues())
            {

                if (txtpassword.Text.Equals(txtpassconfirm.Text))
                {

                    if (checkUsername())
                    {
                        MessageBox.Show("no ha ingresado nombre de usuario", "Alerta" , MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter Your Informations First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }




            db.closeConnection();
        }

        public Boolean checkUsername()
        {
            DB db = new DB();

            String username = txtusuario.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean checkTextBoxesValues()
        {
            String fname = txtfirsname.Text;
            String lname = txtlastname.Text;
            String email = txtemail.Text;
            String uname = txtusuario.Text;
            String pass = txtpassword.Text;

            if (fname.Equals("first name") || lname.Equals("last name") ||
                email.Equals("email address") || uname.Equals("username")
                || pass.Equals("password"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpassconfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
