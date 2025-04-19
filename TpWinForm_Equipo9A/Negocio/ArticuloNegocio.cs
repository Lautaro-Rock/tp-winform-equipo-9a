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
            AccesoDatos datos = new AccesoDatos();

            try 
	        {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, Precio, ImagenUrl, M.Id as IdMarca, M.Descripcion as Marca, C.Id as IdCategoria, C.Descripcion as Categoria From ARTICULOS A, IMAGENES, CATEGORIAS C, MARCAS M Where A.Id = IdArticulo and A.IdCategoria = C.Id and A.IdMarca = M.Id;");
                datos.ejecutarLectura();

                while (datos.ConexionDataReader.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Nombre = (string)datos.ConexionDataReader["Nombre"];
                    aux.Descripcion = (string)datos.ConexionDataReader["Descripcion"];
                    aux.ID = (int)datos.ConexionDataReader["Id"];
                    aux.Precio = datos.ConexionDataReader["Precio"] != DBNull.Value ? Convert.ToDecimal(datos.ConexionDataReader["Precio"]):0m;
                    aux.Codigo = datos.ConexionDataReader["Codigo"] != DBNull.Value ? datos.ConexionDataReader["Codigo"].ToString() : "";
                    aux.UrlImagen = new Imagen();
                    aux.UrlImagen.ImagenUrl = (string)datos.ConexionDataReader["ImagenUrl"];
                    aux.Marca = new Marca(); 
                    aux.Marca.ID = (int)datos.ConexionDataReader["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.ConexionDataReader["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.ConexionDataReader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.ConexionDataReader["Categoria"];

                    lista.Add(aux); 

                }

                return lista; 

            }
	        catch (Exception ex)
	        {

		        throw ex;
	        }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("BEGIN TRANSACTION DECLARE @IdArticulo int; " +
                    "INSERT INTO ARTICULOS(Nombre, Descripcion, Codigo, Precio, IdMarca, IdCategoria) " +
                    "VALUES('" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '" + nuevo.Codigo + "', " + nuevo.Precio.ToString(CultureInfo.InvariantCulture) + ", @IdMarca, @IdCategoria) " +
                    "SELECT @IdArticulo = scope_identity(); " +
                    "INSERT INTO IMAGENES VALUES(@IdArticulo, '"+nuevo.UrlImagen.ImagenUrl+"'); " +
                    "COMMIT");
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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
               string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, Precio, ImagenUrl, M.Id as IdMarca, M.Descripcion as Marca, C.Id as IdCategoria, C.Descripcion as Categoria From ARTICULOS A, IMAGENES, CATEGORIAS C, MARCAS M Where A.Id = IdArticulo and A.IdCategoria = C.Id and A.IdMarca = M.Id And ";
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
                    aux.Nombre = (string)datos.ConexionDataReader["Nombre"];
                    aux.Descripcion = (string)datos.ConexionDataReader["Descripcion"];
                    aux.ID = (int)datos.ConexionDataReader["Id"];
                    aux.Precio = datos.ConexionDataReader["Precio"] != DBNull.Value ? Convert.ToDecimal(datos.ConexionDataReader["Precio"]) : 0m;
                    aux.Codigo = datos.ConexionDataReader["Codigo"] != DBNull.Value ? datos.ConexionDataReader["Codigo"].ToString() : "";
                    aux.UrlImagen = new Imagen();
                    aux.UrlImagen.ImagenUrl = (string)datos.ConexionDataReader["ImagenUrl"];
                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.ConexionDataReader["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.ConexionDataReader["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.ConexionDataReader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.ConexionDataReader["Categoria"];
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
