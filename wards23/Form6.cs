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
    public partial class Form6 : Form
    {
       
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        { 
               MySqlConnection conexion   = new MySqlConnection("Server=localhost;Database=parcial; Uid=root;  Pwd = usbw;");
        
            MySqlCommand comando = new MySqlCommand("Select * from  users", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable table = new DataTable();
            adaptador.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void delenToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox23.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "No ha escrito un nombre",
                   "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=parcial; Uid=root;  Pwd = usbw;");
                conexion.Open();
                string delen = "DELETE FROM users WHERE ID= '" + textBox23.Text + "';";
                MySqlCommand comandodelen = new MySqlCommand(delen, conexion);
                comandodelen.ExecuteNonQuery();
                conexion.Close();
                MetroFramework.MetroMessageBox.Show(this, "Los Datos de la ID " + textBox23.Text + " se han eliminado Datos",
                    "Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=parcial; Uid=root;  Pwd = usbw;");
            MySqlCommand comando = new MySqlCommand("Select * from users", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable table = new DataTable();
            adaptador.Fill(table);
            dataGridView1.DataSource = table;
            MetroFramework.MetroMessageBox.Show(this, "SE a actualizado la tabla de Datos",
                              "Tabla de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
