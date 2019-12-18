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
                    usuario.Nivel = Convert.ToInt32(lector["Nivel"].ToString());
                    usuario.Email = lector["Email"].ToString();

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
        public Usuario traerUsuario(string ID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            Usuario usuario = new Usuario();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM[TPC_ESPINOLA].[dbo].[Usuarios] WHERE [TPC_ESPINOLA].[dbo].[Usuarios].ID = @ID";
                comando.Connection = conexion;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ID", ID);
                conexion.Open();
                lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    usuario.ID = Convert.ToInt32(lector["ID"].ToString());
                    usuario.Identificador = lector["Identificador"].ToString();
                    usuario.Contraseña = lector["Contraseña"].ToString();
                    usuario.Nivel = Convert.ToInt32(lector["Nivel"].ToString());
                    usuario.Email = lector["Email"].ToString();
                }
                return usuario;
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
        public void modificar(Usuario usuario)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE [TPC_ESPINOLA].[dbo].[Usuarios] SET Identificador = @Identificador, Nivel = @Nivel, Contraseña = @Contraseña, Email = @Email WHERE[TPC_ESPINOLA].[dbo].[Usuarios].ID = @ID";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ID", usuario.ID);
                comando.Parameters.AddWithValue("@Identificador", usuario.Identificador);
                comando.Parameters.AddWithValue("@Nivel", usuario.Nivel);
                comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                comando.Parameters.AddWithValue("@Email", usuario.Email);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
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
        public void eliminar(int id)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandText = "delete from [TPC_ESPINOLA].[dbo].[Usuarios] where ID = @id";
                comando.Connection = conexion;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", id);
                conexion.Open();
                comando.ExecuteNonQuery();

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
        public string agregar(Usuario nuevoUsuario)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            string response = "";
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "  INSERT INTO [TPC_ESPINOLA].[dbo].[Usuarios] (Identificador,Nivel,Contraseña,Email) VALUES (@Identificador,@Nivel,@Contraseña,@Email)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Identificador", nuevoUsuario.Identificador);
                comando.Parameters.AddWithValue("@Nivel", nuevoUsuario.Nivel);
                comando.Parameters.AddWithValue("@Contraseña", nuevoUsuario.Contraseña);
                comando.Parameters.AddWithValue("@Email", nuevoUsuario.Email);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return response;
        }
    }
}
