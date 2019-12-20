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
    public class StockNegocio
    {
        public List<Stock> listar(bool SoloEscasos)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Stock> listado = new List<Stock>();
            ProductoNegocio negocioProducto = new ProductoNegocio();
            Stock stock;
            try
            {
                DetalleCompraNegocio negocioDetCompra = new DetalleCompraNegocio();
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM[TPC_ESPINOLA].[dbo].[Productos]";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    stock = new Stock();
                    stock.Producto = negocioProducto.traerProducto(lector["Id"].ToString());
                    stock.StockActual = long.Parse(lector["Stock"].ToString());
                    if (!Convert.IsDBNull(lector["StockMinimo"]))
                    {
                        stock.StockMinimo = int.Parse(lector["StockMinimo"].ToString());
                    }
                    else
                    {
                        stock.StockMinimo = 0;
                    }
                    if (SoloEscasos == false)
                    {
                        listado.Add(stock);
                    }
                    else if (stock.StockActual <= stock.StockMinimo)
                    {
                        listado.Add(stock);
                    }
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
