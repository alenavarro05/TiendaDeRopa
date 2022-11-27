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
            AuthSecret = "UqR85NXt4q3ObclV06J2Sk4fFqCjTo8STafxj0HQ",
            BasePath = "https://tiendaropa-4f36b-default-rtdb.firebaseio.com/"
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
                Modelo = txt_modelo,
                Disponibles = txt_disponible,
            };
            var setter = client.Set("Lista/Estudiantes/" + txt_ID.Text, std);
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
                Modelo = txt_modelo,
                Disponibles = txt_disponible

            };
            var setter = client.Update("ListaEstudiante/" + txt_ID.Text, std);
            MessageBox.Show("Datos actualizados correctamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var resultado = client.Delete("Lista/Estudiantes/" + txt_ID.Text);
            MessageBox.Show("Datos eliminados correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
