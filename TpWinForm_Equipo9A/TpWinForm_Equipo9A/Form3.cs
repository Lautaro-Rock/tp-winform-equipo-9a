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
        private Articulo art=null;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Articulo articulo)
        {
            InitializeComponent();
            this.art = articulo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Articulo newArticulo = new Articulo();
            ArticuloNegocio newNegocio= new ArticuloNegocio();
            try
            {
                if (art == null)
                {
                    art = new Articulo();
                }
                art.Nombre = newNombre.Text;
                art.Descripcion = inputDescripcion.Text;
                art.Codigo = inputCod.Text;
                art.Precio = inputPrecio.Value;
                art.Marca = (Marca)cboMarca.SelectedItem;
                art.Categoria = (Categoria)cboCategoria.SelectedItem;

                if (art.ID != 0)
                {
                    newNegocio.editar(art);
                    MessageBox.Show("Editado exitosamente");
                }
                else
                {
                    newNegocio.agregar(art);
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();


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
                cboMarca.DisplayMember = "Descripcion";
                cboMarca.ValueMember = "Id";
                cboCategoria.DataSource = newCategoria.lista();
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.ValueMember = "Id";

                if (art != null) { 
                 newNombre.Text= art.Nombre;
                 inputCod.Text= art.Codigo;
                 inputPrecio.Text= art.Precio.ToString();
                 inputDescripcion.Text= art.Descripcion;
                  cboMarca.SelectedValue = art.ID;
                  cboCategoria.SelectedValue = art.ID;
                }

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

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
