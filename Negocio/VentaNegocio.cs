using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Negocio;
using AccesoDatos;

namespace Negocio
{
    public class VentaNegocio
    {

        public List<Venta> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Venta> listado = new List<Venta>();
            Venta venta;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "SELECT * FROM[TPC_ESPINOLA].[dbo].[Ventas]";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                ClienteNegocio negocioCliente = new ClienteNegocio();
                DetalleVentaNegocio negocioDetalleVenta = new DetalleVentaNegocio();
                while (lector.Read())
                {
                    venta = new Venta();
                    venta.ID = Convert.ToInt32(lector["Id"]);
                    venta.cliente = negocioCliente.traerCliente(lector["ClienteID"].ToString());
                    venta.Detalle = negocioDetalleVenta.listar(lector["Id"].ToString());
                    venta.total = float.Parse(lector["Total"].ToString());

                    listado.Add(venta);
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

        //public void modificar(Producto nuevoProducto, int productoID)
        //{
        //    SqlConnection conexion = new SqlConnection();
        //    SqlCommand comando = new SqlCommand();
        //    List<Producto> listado = new List<Producto>();
        //    try
        //    {
        //        conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
        //        comando.CommandType = System.Data.CommandType.Text;
        //        //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
        //        comando.CommandText = "UPDATE [TPC_ESPINOLA].[dbo].[Productos] SET Titulo = @Titulo, Descripcion = @Descripcion, URLImagen = @URLImagen WHERE[TPC_ESPINOLA].[dbo].[Productos].ID = @ID";
        //        comando.Parameters.Clear();
        //        comando.Parameters.AddWithValue("@Titulo", nuevoProducto.Titulo);
        //        comando.Parameters.AddWithValue("@Descripcion", nuevoProducto.Descripcion);
        //        comando.Parameters.AddWithValue("@URLImagen", nuevoProducto.URLImagen);
        //        comando.Parameters.AddWithValue("@ID", productoID);
        //        comando.Connection = conexion;
        //        conexion.Open();
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    finally
        //    {
        //        conexion.Close();
        //    }
        //}
        public void agregarVentaYDetalle(Venta nuevaVenta)
        {
            DetalleVentaNegocio negocioDetalleVenta = new DetalleVentaNegocio();
            string IDVenta = this.agregar(nuevaVenta);
            negocioDetalleVenta.agregar(nuevaVenta, IDVenta);
        }
        
        protected string agregar(Venta nuevaVenta)
        {
            string IDVenta = "";
            SqlDataReader lector;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO [TPC_ESPINOLA].[dbo].[Ventas] (ClienteID,Total) VALUES (@ClienteID,@Total)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ClienteID", nuevaVenta.cliente.ID);
                comando.Parameters.AddWithValue("@Total", nuevaVenta.total);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

                comando.CommandText = "SELECT ID FROM [TPC_ESPINOLA].[dbo].[Ventas] WHERE [TPC_ESPINOLA].[dbo].[Ventas].ClienteID = @ClienteID AND [TPC_ESPINOLA].[dbo].[Ventas].Total = @Total";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ClienteID", nuevaVenta.cliente.ID);
                comando.Parameters.AddWithValue("@Total", nuevaVenta.total);
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    IDVenta = lector["ID"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
                return IDVenta;
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
