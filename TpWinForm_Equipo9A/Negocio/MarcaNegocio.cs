using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> lista()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From MARCAS");
                datos.ejecutarLectura();

                while(datos.ConexionDataReader.Read())
                {
                    Marca aux = new Marca();
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
