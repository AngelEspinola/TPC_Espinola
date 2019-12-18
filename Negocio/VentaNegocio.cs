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
                    venta.Cliente = negocioCliente.traerCliente(lector["ClienteID"].ToString());
                    venta.Detalle = negocioDetalleVenta.listar(lector["Id"].ToString());
                    venta.Fecha = Convert.ToDateTime(lector["Fecha"]);
                    venta.Total = negocioDetalleVenta.calcularTotal(lector["ID"].ToString());

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
        private bool ValidarStock(Venta nuevaVenta)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            Producto producto;
            bool response = true;
            foreach (Detalle det in nuevaVenta.Detalle)
            {
                producto = negocioProducto.traerProducto(det.Producto.ID.ToString());
                if (producto != null)
                {
                    if (producto.Stock < det.Cantidad)
                    {
                        response = false;
                    }
                }
            }
            return response;
        }
        public string agregarVentaYDetalle(Venta nuevaVenta)
        {
            DetalleVentaNegocio negocioDetalleVenta = new DetalleVentaNegocio();
            ProductoNegocio negocioProducto = new ProductoNegocio();
            string response = "";
            if (ValidarStock(nuevaVenta) == true)
            {
                string IDVenta = this.agregar(nuevaVenta);
                if (IDVenta != "")
                {
                    foreach (Detalle detalleVenta in nuevaVenta.Detalle)
                    {
                        negocioDetalleVenta.agregar(detalleVenta, nuevaVenta.Cliente.ID.ToString(), IDVenta);
                        negocioProducto.modificarStock(detalleVenta.Producto, detalleVenta.Cantidad, false); // alta = true / baja = false
                    }
                }
                else
                {
                    response = "Se encontro una falla al generar la venta! Por favor, intente nuevamente.";
                }
            }
            else
            {
                response = "Whoops! Al parecer no hay stock suficiente para al menos 1 de los productos detallados";
            }
            return response;
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
                comando.CommandText = "INSERT INTO [TPC_ESPINOLA].[dbo].[Ventas] (ClienteID,Fecha) VALUES (@ClienteID,@Fecha)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ClienteID", nuevaVenta.Cliente.ID);
                comando.Parameters.AddWithValue("@Fecha", nuevaVenta.Fecha);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

                comando.CommandText = "SELECT ID FROM [TPC_ESPINOLA].[dbo].[Ventas] WHERE [TPC_ESPINOLA].[dbo].[Ventas].ClienteID = @ClienteID AND [TPC_ESPINOLA].[dbo].[Ventas].Fecha = @Fecha";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ClienteID", nuevaVenta.Cliente.ID);
                comando.Parameters.AddWithValue("@Fecha", nuevaVenta.Fecha);
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
