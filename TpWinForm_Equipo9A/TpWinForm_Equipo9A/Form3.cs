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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Articulo newArticulo = new Articulo();
            ArticuloNegocio newNegocio= new ArticuloNegocio();
            try
            {
                newArticulo.Nombre = newNombre.Text;
                newArticulo.Descripcion=inputDescripcion.Text;
                newArticulo.Codigo=inputCod.Text;
                newArticulo.Precio=inputPrecio.Value;
                newArticulo.Marca = (Marca)cboMarca.SelectedItem;
                newArticulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                newNegocio.agregar(newArticulo);
                MessageBox.Show("Agregado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MarcaNegocio newMarca = new MarcaNegocio();
            CategoriaNegocio newCategoria = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = newMarca.lista();
                cboCategoria.DataSource = newCategoria.lista();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
