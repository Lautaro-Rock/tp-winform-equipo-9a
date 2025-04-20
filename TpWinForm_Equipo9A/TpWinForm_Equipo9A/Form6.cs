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
    public partial class Form6: Form
    {
        private List<Articulo> articulos;
        
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                if(cboCampo.SelectedItem == null)
                {
                    MessageBox.Show("El desplegable Campo debe ser completado");
                    txtFiltro.Text = "";

                }
                else if (cboCriterio.SelectedItem == null)
                {
                    MessageBox.Show("El desplegable Criterio debe ser completado");
                    txtFiltro.Text = "";
                }
                else if (txtFiltro.Text == "")
                {
                    MessageBox.Show("Debe escribir el filtro");
                    
                }
                else {
                    string campo = cboCampo.SelectedItem.ToString();
                    string criterio = cboCriterio.SelectedItem.ToString();
                    string filtro = txtFiltro.Text;
                    List<Articulo> list_filtrada = articuloNegocio.filtrar(campo, criterio, filtro);
                    dataGridViewFitro.DataSource = list_filtrada;
                    pcBoxFiltro.Load(list_filtrada[0].UrlImagen.ImagenUrl.ToString());
                    pcBoxFiltro.SizeMode = PictureBoxSizeMode.StretchImage;
                    dataGridViewFitro.Columns["UrlImagen"].Visible = false;
                    dataGridViewFitro.Columns["Marca"].Visible = false;
                    dataGridViewFitro.Columns["Categoria"].Visible = false;
                }

                
                //string criterio = cboCriterio.SelectedItem.ToString();
                //string filtro = txtFiltro.Text;
                //List<Articulo> list_filtrada = articuloNegocio.filtrar(campo, criterio, filtro);
                //dataGridViewFitro.DataSource = list_filtrada;
                //pcBoxFiltro.Load(list_filtrada[0].UrlImagen.ImagenUrl.ToString());
                //pcBoxFiltro.SizeMode = PictureBoxSizeMode.StretchImage;
                //dataGridViewFitro.Columns["UrlImagen"].Visible = false;
                //dataGridViewFitro.Columns["Marca"].Visible = false;
                //dataGridViewFitro.Columns["Categoria"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            txtFiltro.Text = "";
        }

        private void Form6_Load(object sender, EventArgs e)
        {
               
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articulos = articuloNegocio.listar();
            cboCampo.Items.Add("Por ID ARTICULO");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");
            
        }

        private void CampoCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void CampoMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
         
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewFitro_SelectionChanged(object sender, EventArgs e)
        {
            
            Articulo seleccionado = (Articulo)dataGridViewFitro.CurrentRow.DataBoundItem;

            try
            {
                pcBoxFiltro.Load(seleccionado.UrlImagen.ImagenUrl.ToString());
            }
            catch
            {
                pcBoxFiltro.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSf0ee70UsCrUU3czX7qfX0gCjXy9Qo8nfiuQ&s");
            }

        }
    }
}
