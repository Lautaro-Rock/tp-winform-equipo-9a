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
    public partial class Form4: Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 ventana3 = new Form3();
            ventana3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 ventana5 = new Form5();  
            ventana5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 ventana2 = new Form2();
            ventana2.ShowDialog();
        }
    }
}
