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
    public partial class frmBuscar: Form
    {
        private List<Articulo> articulos;
        
        public frmBuscar()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccionar un campo antes de buscar.");
                return true;
            }

            if (cboCampo.SelectedItem.ToString() == "Por ID ARTICULO")
            {
                if (string.IsNullOrEmpty(txtFiltro.Text)) 
                {
                    MessageBox.Show("Si la busqueda es por ID ARTICULO, el filtro no puede estar vacío");
                    return true; 
                }

                if (!soloNumeros(txtFiltro.Text))
                {
                    MessageBox.Show("Si la busqueda es por ID ARTICULO, solo se permiten numeros en el filtro.");
                    return true; 
                }
            }
            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsNumber(caracter))
                {
                    return false; 
                }
            }
            return true;
        }
        private void BotonBusqueda_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                {
                    return; 
                }

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCampo.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                List<Articulo> list_filtrada = articuloNegocio.filtrar(campo, criterio, filtro); 
                dataGridViewFitro.DataSource = list_filtrada;
                dataGridViewFitro.Columns["UrlImagen"].Visible = false;
                dataGridViewFitro.Columns["Marca"].Visible = false;
                dataGridViewFitro.Columns["Categoria"].Visible = false;
                cargarImagen(list_filtrada[0].UrlImagen.ImagenUrl.ToString());

                //PanelResultadoBusq.Controls.Add(imagen_filtrado);
                //PanelResultadoBusq.Controls.Add(botonfiltrado);

            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, ingresar numeros mayores a 0 y dentro del rango de articulos en la Base de Datos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            cboCampo.Items.Add("Por ID ARTICULO");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");
            
        }

        private void Campo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Por ID ARTICULO")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void dataGridViewFitro_SelectionChanged(object sender, EventArgs e)
        {
            
            Articulo seleccionado = (Articulo)dataGridViewFitro.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen.ImagenUrl.ToString());
            

        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pcBoxFiltro.SizeMode = PictureBoxSizeMode.StretchImage;
                pcBoxFiltro.Load(imagen);
            }
            catch (Exception)
            {

                pcBoxFiltro.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSf0ee70UsCrUU3czX7qfX0gCjXy9Qo8nfiuQ&s");
            }
        }
    }
}
