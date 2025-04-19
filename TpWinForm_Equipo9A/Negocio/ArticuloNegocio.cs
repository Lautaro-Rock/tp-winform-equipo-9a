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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
               string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, Precio, M.Descripcion, ImagenUrl From ARTICULOS A, MARCAS M , IMAGENES Where A.Id = M.Id And A.Id = IdArticulo And ";
                switch (campo)
                {
                    case "Por ID ARTICULO":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "A.Id > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "A.Id < " + filtro;
                                break;
                            default:
                                consulta += "A.Id = " + filtro;
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                    break;
                    default:
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Descripcion like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.ConexionDataReader.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.ConexionDataReader["Id"];
                    aux.Codigo = datos.ConexionDataReader["Codigo"] != DBNull.Value ? datos.ConexionDataReader["Codigo"].ToString() : "";
                    aux.Nombre = (string)datos.ConexionDataReader["Nombre"];
                    aux.Descripcion = (string)datos.ConexionDataReader["Descripcion"];
                    aux.Precio = datos.ConexionDataReader["Precio"] != DBNull.Value ? Convert.ToDecimal(datos.ConexionDataReader["Precio"]) : 0m;
                    aux.UrlImagen = new Imagen();
                    aux.UrlImagen.ImagenUrl = (string)datos.ConexionDataReader["ImagenUrl"];
                    lista.Add(aux);

                }
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
