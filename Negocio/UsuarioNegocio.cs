using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Usuario> listado = new List<Usuario>();
            Usuario usuario;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM [TPC_ESPINOLA].[dbo].[Usuarios] ";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                ProductoNegocio negocioProducto = new ProductoNegocio();
                while (lector.Read())
                {
                    usuario = new Usuario();
                    usuario.ID = int.Parse(lector["ID"].ToString());
                    usuario.Identificador = lector["Identificador"].ToString();
                    usuario.Contraseña = lector["Contraseña"].ToString();

                    listado.Add(usuario);
                }

                return listado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
