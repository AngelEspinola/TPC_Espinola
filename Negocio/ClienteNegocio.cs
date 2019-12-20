using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Negocio;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Cliente> listado = new List<Cliente>();
            Cliente cliente;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT [Id],[DNI],[Nombre],[Apellido],[Email],[Direccion],[Ciudad],[CodigoPostal],[FechaRegistro] FROM[TPC_ESPINOLA].[dbo].[Clientes]";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    cliente = new Cliente();

                    cliente.ID = Convert.ToInt32(lector["ID"]);

                    if (!Convert.IsDBNull(lector["DNI"]))
                        cliente.DNI = lector["DNI"].ToString();

                    if (!Convert.IsDBNull(lector["Nombre"]))
                        cliente.Nombre = lector["Nombre"].ToString();

                    if (!Convert.IsDBNull(lector["Apellido"]))
                        cliente.Apellido = lector["Apellido"].ToString();

                    if (!Convert.IsDBNull(lector["Email"]))
                        cliente.Email = lector["Email"].ToString();

                    if (!Convert.IsDBNull(lector["Direccion"]))
                        cliente.Direccion = lector["Direccion"].ToString();

                    if (!Convert.IsDBNull(lector["Ciudad"]))
                        cliente.Ciudad = lector["Ciudad"].ToString();

                    if (!Convert.IsDBNull(lector["CodigoPostal"]))
                        cliente.CodigoPostal = lector["CodigoPostal"].ToString();

                    if (!Convert.IsDBNull(lector["FechaRegistro"]))
                        cliente.FechaRegistro = Convert.ToDateTime(lector["FechaRegistro"]).ToShortDateString();

                    listado.Add(cliente);
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

        public string agregar(Cliente nuevoCliente)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            string response = "";
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "  INSERT INTO [TPC_ESPINOLA].[dbo].[Clientes] (DNI,Nombre,Apellido,Email,Direccion,Ciudad,CodigoPostal,FechaRegistro) VALUES (@DNI,@Nombre,@Apellido,@Email,@Direccion,@Ciudad,@CodigoPostal,@FechaRegistro)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@DNI", nuevoCliente.DNI);
                comando.Parameters.AddWithValue("@Nombre", nuevoCliente.Nombre.ToString());
                comando.Parameters.AddWithValue("@Apellido", nuevoCliente.Apellido.ToString());
                comando.Parameters.AddWithValue("@Email", nuevoCliente.Email.ToString());
                comando.Parameters.AddWithValue("@Direccion", nuevoCliente.Direccion.ToString());
                comando.Parameters.AddWithValue("@Ciudad", nuevoCliente.Ciudad.ToString());
                comando.Parameters.AddWithValue("@CodigoPostal", nuevoCliente.CodigoPostal.ToString());
                comando.Parameters.AddWithValue("@FechaRegistro", nuevoCliente.FechaRegistro);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                response = ex.Message;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return response;
        }

        public void modificar(Cliente cliente)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE [TPC_ESPINOLA].[dbo].[Clientes] SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Direccion = @Direccion, Ciudad = @Ciudad, CodigoPostal = @CodigoPostal, FechaRegistro = @FechaRegistro WHERE[TPC_ESPINOLA].[dbo].[Clientes].ID = @ID";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ID", cliente.ID);
                comando.Parameters.AddWithValue("@DNI", cliente.DNI);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                comando.Parameters.AddWithValue("@Ciudad", cliente.Ciudad);
                comando.Parameters.AddWithValue("@CodigoPostal", cliente.CodigoPostal);
                comando.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);
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

        public string traerIDCliente(string DNI)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            string idCliente = null;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT [Id] FROM[TP_WEB].[dbo].[Clientes] WHERE[TP_WEB].[dbo].[Clientes].DNI = @DNI";
                comando.Connection = conexion;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@DNI", DNI);
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    idCliente = lector["Id"].ToString();
                }

                return idCliente;

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

        public Cliente traerCliente(string ID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            Cliente cliente = new Cliente();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM[TPC_ESPINOLA].[dbo].[Clientes] WHERE [TPC_ESPINOLA].[dbo].[Clientes].Id = @ID";
                comando.Connection = conexion;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ID", ID);
                conexion.Open();
                lector = comando.ExecuteReader();

                if(lector.Read())
                {
                    cliente.ID = int.Parse(lector["Id"].ToString());
                    cliente.Nombre = lector["Nombre"].ToString();
                    cliente.Apellido = lector["Apellido"].ToString();
                    cliente.Ciudad = lector["Ciudad"].ToString();
                    cliente.CodigoPostal = lector["CodigoPostal"].ToString();
                    cliente.Direccion = lector["Direccion"].ToString();
                    cliente.DNI = lector["DNI"].ToString();
                    cliente.Email = lector["Email"].ToString();
                }
                return cliente;
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
                comando.CommandText = "delete from [TPC_ESPINOLA].[dbo].[Clientes] where ID = @id";
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
    }
}
