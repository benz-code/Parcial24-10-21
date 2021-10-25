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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
       

        private void Form4_Load(object sender, EventArgs e)
        {
           

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=parcial; Uid=root;  Pwd = usbw;");

            MySqlCommand comando = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", connection);
            comando.Parameters.AddWithValue("@usn", lblcc.Text);
            connection.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                label2.Text = registro["username"].ToString();
                label3.Text = registro["password"].ToString();
                label4.Text = registro["emailaddress"].ToString();
                label5.Text = registro["lastname"].ToString();
                label6.Text = registro["firstname"].ToString();
                label7.Text = registro["id"].ToString();
            }
            connection.Close();
        }

       

        

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblcc_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 mv = new Form3();
            mv.lblitalo.Text = lblcc.Text;
            mv.ShowDialog();
            this.Close();
        }
    }
}
