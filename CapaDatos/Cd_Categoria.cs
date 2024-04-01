using CapaModelo;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class Cd_Categoria
    {
        public static Cd_Categoria _instancia = null;
        private Cd_Categoria()
        {
        }
        public static Cd_Categoria Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Cd_Categoria();
                }
                return _instancia;
            }
        }
        public List<Categoria> ObtenerCategoria()
        {
            var rptListaCategoria = new List<Categoria>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("sp_MostrarCategoria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaCategoria.Add(new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                        }) ;
                    }
                    dr.Close();
                    return rptListaCategoria;
                }
                catch
                {
                    rptListaCategoria = null;
                    return rptListaCategoria;
                }
            }
        }
        public bool RegistrarCategoria(Categoria oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCategoria2", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
                    cmd.Parameters.AddWithValue("FechaCreacion", oCategoria.FechaCreacion);
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
        public bool ModificarCategoria(Categoria oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarCategoria4", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
                    
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
        public bool EliminarCategoria(int IdCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarCategoria1", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", IdCategoria);
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
