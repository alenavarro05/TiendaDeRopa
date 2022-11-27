using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Tienda_de_Ropa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "V0WeYQsOSH4jq10GoN15Hi8hAcsIiEWwh6fDNBZe",
            BasePath = "https://tienda-de-ropa--codigo-bien-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {
                MessageBox.Show("Existe un problema en la conección de Internet");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 std = new Class1
            {
                ID = txt_ID.Text,
                Articulo = txt_articulo.Text,
                Marca = txt_marca.Text,
                Talla = txt_talla.Text,
                Modelo = txt_modelo.Text,
                Disponibles = txt_disponible.Text,
                Imagen = Imagen.Image
            };
            var setter = client.Set("Codigo de Barras/Producto/" + txt_ID.Text, std);
            MessageBox.Show("Datos insertados correctamente");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1 std = new Class1
            {
                ID = txt_ID.Text,
                Articulo = txt_articulo.Text,
                Marca = txt_marca.Text,
                Talla = txt_talla.Text,
                Modelo = txt_modelo.Text,
                Disponibles = txt_disponible.Text,
                Imagen = Imagen.Image
            };
            var setter = client.Update("CodigoProducto/" + txt_ID.Text, std);
            MessageBox.Show("Datos actualizados correctamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var resultado = client.Delete("Codigo de Barras/Producto/" + txt_ID.Text);
            MessageBox.Show("Datos eliminados correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) ;
            {
                Imagen.Image = Image.FromFile(openFileDialog1.FileName);
                this.Text = String.Concat("Visor de Imagenes (" + openFileDialog1.FileName + ")");
            }
        }
    }
}
