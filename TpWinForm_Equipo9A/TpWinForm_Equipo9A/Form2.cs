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
    public partial class Form2 : Form
    {
        private List<Articulo> listaArticulo;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar(); 
            dgvArticulo.DataSource = listaArticulo;
            dgvArticulo.Columns["UrlImagen"].Visible = false;
            cargarImagen(listaArticulo[0].UrlImagen.ImagenUrl.ToString());
        }

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem; 
            cargarImagen(seleccionado.UrlImagen.ImagenUrl.ToString());
        }

        private void cargarImagen(string imagen) 
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception)
            {

                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSf0ee70UsCrUU3czX7qfX0gCjXy9Qo8nfiuQ&s");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Articulo Seleccionado;
            Seleccionado=(Articulo)dgvArticulo.CurrentRow.DataBoundItem;

            Form3 modificar= new Form3(Seleccionado);
            modificar.ShowDialog();
        }
    }
}
