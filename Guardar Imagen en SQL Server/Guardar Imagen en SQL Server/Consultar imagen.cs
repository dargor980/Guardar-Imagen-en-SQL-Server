using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Guardar_Imagen_en_SQL_Server
{
    public partial class Consultar_imagen : Form
    {
        public Consultar_imagen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("server=AMADEUS ; database=baseprueba ; integrated security=True");
                conexion.Open();
                string query = "SELECT imagen FROM caca WHERE nombre='cacaMAYOR'";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader rdr = comando.ExecuteReader();
                Image newImage = null;
                if (rdr.Read())
                {
                    
                    
                    byte[] imgData = (byte[])rdr.GetValue(0);
                    //transportar info imagen al picturebox

                    using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
                    {
                        ms.Write(imgData, 0, imgData.Length);
                        newImage = Image.FromStream(ms, true);
                    }
                    pictureBox1.Image = newImage;
                    newImage = null;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            
        }
    }
}
