﻿using System;
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
            pbxArticulo.Load(listaArticulo[0].UrlImagen.ImagenUrl.ToString());
        }

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem; 
            pbxArticulo.Load(seleccionado.UrlImagen.ImagenUrl.ToString());
        }
    }
}
