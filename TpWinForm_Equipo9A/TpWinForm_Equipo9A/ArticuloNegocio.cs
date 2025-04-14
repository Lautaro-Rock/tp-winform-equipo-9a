using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace TpWinForm_Equipo9A
{
    class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector; 

            try 
	        {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text; 
                comando.CommandText = "Select Id, Nombre, Descripcion From ARTICULOS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.ID = (int)lector["Id"];

                    lista.Add(aux); 

                }
                conexion.Close();
                return lista; 

            }
	        catch (Exception ex)
	        {

		        throw(ex);
	        }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("INSERT INTO ARTICULOS (Nombre, Descripcion) VALUES ('" + nuevo.Nombre + "', '" + nuevo.Descripcion + "')");
                data.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        public void eliminar(Articulo nuevo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("DELETE FROM ARTICULOS WHERE Nombre='" + nuevo.Nombre + "'");
                data.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }
    }
}
