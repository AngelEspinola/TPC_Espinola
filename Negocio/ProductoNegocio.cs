using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Producto> listado = new List<Producto>();
            Producto producto;
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "SELECT [Id],[Titulo] ,[Descripcion] ,[URLImagen] FROM[TPC_ESPINOLA].[dbo].[Productos]";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    producto = new Producto();
                    producto.ID = Convert.ToInt32(lector["Id"]);
                    producto.Titulo = lector["Titulo"].ToString();
                    producto.Descripcion = lector["Descripcion"].ToString();
                    producto.URLImagen = lector["URLImagen"].ToString();

                    listado.Add(producto);
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

        public void modificar(Producto nuevoProducto, int productoID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            List<Producto> listado = new List<Producto>();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "UPDATE [TPC_ESPINOLA].[dbo].[Productos] SET Titulo = @Titulo, Descripcion = @Descripcion, URLImagen = @URLImagen WHERE[TPC_ESPINOLA].[dbo].[Productos].ID = @ID";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Titulo", nuevoProducto.Titulo);
                comando.Parameters.AddWithValue("@Descripcion", nuevoProducto.Descripcion);
                comando.Parameters.AddWithValue("@URLImagen", nuevoProducto.URLImagen);
                comando.Parameters.AddWithValue("@ID", productoID);
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

        public void agregar(Producto nuevoProducto)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "  INSERT INTO [TPC_ESPINOLA].[dbo].[Productos] (Titulo,Descripcion,URLImagen) VALUES (@Titulo,@Descripcion,@URLImagen)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Titulo", nuevoProducto.Titulo);
                comando.Parameters.AddWithValue("@Descripcion", nuevoProducto.Descripcion);
                comando.Parameters.AddWithValue("@URLImagen", nuevoProducto.URLImagen);
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
        public void eliminar(string id)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandText = "delete from [TPC_ESPINOLA].[dbo].[Productos] where ID = @id";
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
