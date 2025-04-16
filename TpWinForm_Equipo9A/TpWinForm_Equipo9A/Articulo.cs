using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpWinForm_Equipo9A
{
    internal class Articulo
    {
        public int ID { get; set; }
        public string Nombre {  get; set; }
        public string Descripcion { get; set; }
        public decimal Precio {  get; set; } 
        public string Codigo { get; set; }

    }
}
