﻿using System;
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
                conexion.ConnectionString = "server=localhost; database=CATALOGO_P3_DB; Persist Security Info=True; User ID= sa; Password=Contra993!";
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
    }
}
