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
    public class CompraNegocio
    {
        public List<Compra> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Compra> listado = new List<Compra>();
            Compra compra;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM[TPC_ESPINOLA].[dbo].[Compras]";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                ProveedorNegocio negocioProveedor= new ProveedorNegocio();
                DetalleCompraNegocio negocioDetalleCompra = new DetalleCompraNegocio();
                while (lector.Read())
                {
                    compra = new Compra();
                    compra.ID = Convert.ToInt32(lector["Id"]);
                    compra.Proveedor = negocioProveedor.traerProveedor(lector["ProveedorID"].ToString());
                    compra.Detalle = negocioDetalleCompra.listar(lector["Id"].ToString());
                    compra.Fecha = Convert.ToDateTime(lector["Fecha"].ToString());
                    compra.Total = negocioDetalleCompra.calcularTotal(lector["ID"].ToString());

                    listado.Add(compra);
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
        public string agregarCompraYDetalle(Compra nuevaCompra)
        {
            DetalleCompraNegocio negocioDetalleCompra = new DetalleCompraNegocio();
            ProductoNegocio negocioProducto = new ProductoNegocio();
            Producto producto;
            string response = "";
            string IDCompra = this.agregar(nuevaCompra);
            if (IDCompra != "")
            {
                foreach (Detalle det in nuevaCompra.Detalle)
                {
                    negocioDetalleCompra.agregar(det, nuevaCompra.Proveedor.ID.ToString(), IDCompra);
                    producto = negocioProducto.traerProducto(det.Producto.ID.ToString());
                    negocioProducto.modificarStock(producto, det.Cantidad, true); // alta = true / baja = false
                }
            }
            else
            {
                response = "Error al generar compra! intente nuevamente mas tarde";
                //Falla al generar la compra
            }
            return response;

        }

        protected string agregar(Compra nuevaCompra)
        {
            string IDCompra = "";
            SqlDataReader lector;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO [TPC_ESPINOLA].[dbo].[Compras] (ProveedorID,Fecha) VALUES (@ProveedorID,@Fecha)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ProveedorID", nuevaCompra.Proveedor.ID);
                comando.Parameters.AddWithValue("@Fecha", nuevaCompra.Fecha);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

                comando.CommandText = "SELECT ID FROM [TPC_ESPINOLA].[dbo].[Compras] WHERE [TPC_ESPINOLA].[dbo].[Compras].ProveedorID = @ProveedorID AND [TPC_ESPINOLA].[dbo].[Compras].Fecha = @Fecha";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ProveedorID", nuevaCompra.Proveedor.ID);
                comando.Parameters.AddWithValue("@Fecha", nuevaCompra.Fecha);
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    IDCompra = lector["ID"].ToString();
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
            return IDCompra;
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
