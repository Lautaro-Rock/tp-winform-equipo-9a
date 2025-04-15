using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
