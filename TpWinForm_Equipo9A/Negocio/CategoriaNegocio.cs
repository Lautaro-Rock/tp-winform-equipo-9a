using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> lista()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.ConexionDataReader.Read())
                {
                    Categoria aux = new Categoria();
                    aux.ID = (int)datos.ConexionDataReader["Id"];
                    aux.Descripcion = (string)datos.ConexionDataReader["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
