using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TpWinForm_Equipo9A
{
    public partial class Form5: Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 ventana3 = new Form3();
            ventana3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 ventana4 = new Form4();
            ventana4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ventana2 = new Form2();
            ventana2.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 ventanaAgregar = new Form3();
            ventanaAgregar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
        
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form4 ventanaEliminar = new Form4();
            ventanaEliminar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 ventanaBuscarArt = new Form6();
            ventanaBuscarArt.ShowDialog();
        }
    }
}
