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
