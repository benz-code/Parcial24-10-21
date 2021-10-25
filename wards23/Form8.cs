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


namespace wards23
{
    public partial class Form8 : Form
    {
        MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=smis031021; Uid=root;  Pwd = usbw;");
        public Form8()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();
                string mensaje = "Usted estas conextado";
                if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Estado de conexion", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Yes)
                    conexion.Close();
            }
            catch
            {

                string mensaje = "Usted ha tenido Problemas con la Conexion Comprueba tu conexion al Serviodor";
                if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Estado de conexion", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.Yes)
                    conexion.Close();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MySqlCommand comando = new MySqlCommand("Select * from actores", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable table = new DataTable();
            adaptador.Fill(table);
            dataGridView1.DataSource = table;


        }

        private void button1_Click(object sender, EventArgs e)
        {




        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {


            this.Hide();
            Form2 mv = new Form2();
            mv.ShowDialog();
            this.Close();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 mv = new Form1();
            mv.ShowDialog();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conexion.Open();
            string delen = "DELETE FROM actores WHERE ID= '" + txtdelen.Text + "';";
            MySqlCommand comandodelen = new MySqlCommand(delen, conexion);
            comandodelen.ExecuteNonQuery();
            conexion.Close();
            MetroFramework.MetroMessageBox.Show(this, "Los Datos de la ID " + txtdelen.Text + " se han eliminado Datos",
                "Datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void txtdelen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void abriform(object formulariohija)
        {
            

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bookToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            abriform(new Form8());
        }

        private void btnconnection_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();
                string mensaje = "Usted estas conextado";
                if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Estado de conexion", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Yes)
                    conexion.Close();
            }
            catch
            {

                string mensaje = "Usted ha tenido Problemas con la Conexion Comprueba tu conexion al Serviodor";
                if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Estado de conexion", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.Yes)
                    conexion.Close();

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            conexion.Open();
            string delen = "DELETE FROM actores WHERE ID= '" + txtdelen.Text + "';";
            MySqlCommand comandodelen = new MySqlCommand(delen, conexion);
            comandodelen.ExecuteNonQuery();
            conexion.Close();
            MetroFramework.MetroMessageBox.Show(this, "Los Datos de la ID " + txtdelen.Text + " se han eliminado Datos",
                "Datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }
    }
}
