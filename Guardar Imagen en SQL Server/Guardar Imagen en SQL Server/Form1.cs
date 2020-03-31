using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Guardar_Imagen_en_SQL_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = dlgImagen.ShowDialog();
            if (r == DialogResult.OK)
            {
                textBox1.Text = dlgImagen.FileName;
                pictureBox1.Load(textBox1.Text);
            }
               
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=AMADEUS ; database=baseprueba ; integrated security=True");
            conexion.Open();
            byte[] data = System.IO.File.ReadAllBytes(textBox1.Text);
            String query = "INSERT INTO CACA(nombre,imagen) VALUES('cacaMAYOR',@prImagen)";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.Add("@prImagen", data);
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ConsultarImagen_Click(object sender, EventArgs e)
        {
            Form consultar = new Consultar_imagen();
            consultar.Show();

        }
    }
}
