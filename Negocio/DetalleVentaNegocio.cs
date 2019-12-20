﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;
using System.Data.SqlClient;

namespace Negocio
{
    public class DetalleVentaNegocio
    {
        public List<Detalle> listar(string VentaID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Detalle> listado = new List<Detalle>();
            Detalle detalleVenta;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM [TPC_ESPINOLA].[dbo].[DetalleVentas] WHERE [TPC_ESPINOLA].[dbo].[DetalleVentas].VentaID = @ID";
                comando.Connection = conexion;
                comando.Parameters.AddWithValue("@ID", VentaID);
                conexion.Open();
                lector = comando.ExecuteReader();
                ProductoNegocio negocioProducto = new ProductoNegocio();
                while (lector.Read())
                {
                    detalleVenta = new Detalle();
                    detalleVenta.ID = Convert.ToInt32(lector["ID"].ToString());
                    detalleVenta.Precio = float.Parse(lector["Precio"].ToString());
                    detalleVenta.Producto = negocioProducto.traerProducto(lector["ProductoID"].ToString());
                    detalleVenta.Cantidad = int.Parse(lector["Cantidad"].ToString());
                    detalleVenta.SubTotal = int.Parse(lector["Cantidad"].ToString()) * float.Parse(lector["Precio"].ToString());

                    listado.Add(detalleVenta);
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
        public float calcularTotal(string VentaID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            float total = 0;
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM [TPC_ESPINOLA].[dbo].[DetalleVentas] WHERE [TPC_ESPINOLA].[dbo].[DetalleVentas].VentaID = @ID";
                comando.Connection = conexion;
                comando.Parameters.AddWithValue("@ID", VentaID);
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
        public void agregar(Detalle detalleVenta, string ClienteID, string VentaID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {

                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "  INSERT INTO [TPC_ESPINOLA].[dbo].[DetalleVentas] (ProductoID,VentaID,Cantidad,Precio) VALUES (@ProductoID,@VentaID,@Cantidad,@Precio)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ProductoID", detalleVenta.Producto.ID);
                comando.Parameters.AddWithValue("@VentaID", VentaID);
                comando.Parameters.AddWithValue("@Cantidad", detalleVenta.Cantidad);
                comando.Parameters.AddWithValue("@Precio", detalleVenta.Precio);
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

    }
}
