using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Cd_Producto
    {
        public static Cd_Producto _instancia = null;
        private Cd_Producto()
        {
        }
        public static Cd_Producto Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Cd_Producto();
                }
                return _instancia;
            }
        }
        public List<Producto> ObtenerProducto()
        {
            var rptListaProducto = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ProductoObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaProducto.Add(new Producto()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString())
                      
                        });
                    }
                    dr.Close();
                    return rptListaProducto;
                }
                catch
                {
                    rptListaProducto = null;
                    return rptListaProducto;
                }
            }
        }
        public bool RegistrarProducto(Producto oProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_RegistrarProducto", oConexion);
                    cmd.Parameters.AddWithValue("NombreProducto", oProducto.NombreProducto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool ModificarProducto(Producto oProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ModificarProducto", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("NombreProducto", oProducto.NombreProducto);
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.IdCategoria);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool EliminarProducto(int IdProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CPProductoEliminar", oConexion);
                    cmd.Parameters.AddWithValue("cod", IdProducto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}
