using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using Dominio;
namespace Negocio
{
    public class ArticuloNegocio
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
                comando.CommandText = "Select A.Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, ImagenUrl From ARTICULOS A, IMAGENES Where A.Id = IdArticulo ";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.ID = (int)lector["Id"];
                    aux.Precio = lector["Precio"] != DBNull.Value ? Convert.ToDecimal(lector["Precio"]):0m;
                    aux.Codigo = lector["Codigo"] != DBNull.Value ? lector["Codigo"].ToString() : "";
                    aux.UrlImagen = new Imagen();
                    aux.UrlImagen.ImagenUrl = (string)lector["ImagenUrl"];

                    lista.Add(aux); 

                }
                conexion.Close();
                return lista; 

            }
	        catch (Exception ex)
	        {

		        throw ex;
	        }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("INSERT INTO ARTICULOS (Nombre, Descripcion, Codigo, Precio, IdMarca, IdCategoria) VALUES ('" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '" + nuevo.Codigo + "', " + nuevo.Precio.ToString(CultureInfo.InvariantCulture) + ", @IdMarca, @IdCategoria)");
                data.setearParametro("@IdMarca", nuevo.Marca.ID);
                data.setearParametro("@IdCategoria", nuevo.Categoria.ID);
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
                data.setearConsulta("DELETE FROM ARTICULOS WHERE Nombre='"+nuevo.Nombre+"'");
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

        public void editar(Articulo edit)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS Set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, Precio=@Precio where Id=@Id");
                datos.setearParametro("@Codigo", edit.Codigo);
                datos.setearParametro("@Nombre", edit.Nombre);
                datos.setearParametro("@Descripcion", edit.Descripcion);
                datos.setearParametro("@IdMarca", edit.Marca.ID);
                datos.setearParametro("@IdCategoria", edit.Categoria.ID);
                datos.setearParametro("@Precio", edit.Precio);
                datos.setearParametro("@Id", edit.ID);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }
    }
}
