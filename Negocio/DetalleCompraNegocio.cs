using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;
using System.Data.SqlClient;

namespace Negocio
{
    public class DetalleCompraNegocio
    {
        public List<Detalle> listar(string CompraID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Detalle> listado = new List<Detalle>();
            Detalle detalle;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "SELECT * FROM [TPC_ESPINOLA].[dbo].[DetalleCompras] WHERE [TPC_ESPINOLA].[dbo].[DetalleCompras].CompraID = @IDCompra";
                comando.Connection = conexion;
                comando.Parameters.AddWithValue("@IDCompra", CompraID);
                conexion.Open();
                lector = comando.ExecuteReader();
                ProductoNegocio negocioProducto = new ProductoNegocio();
                while (lector.Read())
                {
                    detalle = new Detalle();
                    detalle.ID = Convert.ToInt32(lector["ID"].ToString());
                    detalle.Producto = negocioProducto.traerProducto(lector["ProductoID"].ToString());
                    detalle.Cantidad = int.Parse(lector["Cantidad"].ToString());
                    detalle.Precio = float.Parse(lector["Precio"].ToString());
                    detalle.SubTotal = int.Parse(lector["Cantidad"].ToString()) * float.Parse(lector["Precio"].ToString());
                    
                    listado.Add(detalle);
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
        public float calcularTotal(string CompraID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            float total = 0;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM [TPC_ESPINOLA].[dbo].[DetalleCompras] WHERE [TPC_ESPINOLA].[dbo].[DetalleCompras].CompraID = @ID";
                comando.Connection = conexion;
                comando.Parameters.AddWithValue("@ID", CompraID);
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    total += int.Parse(lector["Cantidad"].ToString()) * float.Parse(lector["Precio"].ToString());
                }

                return total;

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
        public void agregar(Detalle detalleCompra,string ProveedorID, string CompraID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {

                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "  INSERT INTO [TPC_ESPINOLA].[dbo].[DetalleCompras] (CompraID,ProductoID,Cantidad,Precio) VALUES (@CompraID,@ProductoID,@Cantidad,@Precio)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@CompraID", CompraID);
                comando.Parameters.AddWithValue("@ProductoID", detalleCompra.Producto.ID);
                comando.Parameters.AddWithValue("@Cantidad", detalleCompra.Cantidad);
                comando.Parameters.AddWithValue("@Precio", detalleCompra.Precio);
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

        public float TraerUltimoPrecioCompra(string IDProducto)
        {
            float Precio = 0;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Detalle> listado = new List<Detalle>();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "SELECT * FROM [TPC_ESPINOLA].[dbo].[DetalleCompras] WHERE [TPC_ESPINOLA].[dbo].[DetalleCompras].ProductoID = @ProductoID ORDER BY ID DESC";
                comando.Connection = conexion;
                comando.Parameters.AddWithValue("@ProductoID", IDProducto);
                conexion.Open();
                lector = comando.ExecuteReader();
                ProductoNegocio negocioProducto = new ProductoNegocio();
                if (lector.Read())
                {
                    Precio = float.Parse(lector["Precio"].ToString());
                }

                return Precio;

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
