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
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Proveedor> listado = new List<Proveedor>();
            Proveedor proveedor;
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "SELECT [Id],[CUIT],[RazonSocial],[Email],[Direccion],[Ciudad],[CodigoPostal],[FechaRegistro] FROM[TPC_ESPINOLA].[dbo].[Proveedores]";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    proveedor = new Proveedor();

                    proveedor.ID = Convert.ToInt32(lector["Id"]);

                    if (!Convert.IsDBNull(lector["CUIT"]))
                        proveedor.CUIT = lector["CUIT"].ToString();

                    if (!Convert.IsDBNull(lector["RazonSocial"]))
                        proveedor.RazonSocial = lector["RazonSocial"].ToString();

                    if (!Convert.IsDBNull(lector["Email"]))
                        proveedor.Email = lector["Email"].ToString();

                    if (!Convert.IsDBNull(lector["Direccion"]))
                        proveedor.Direccion = lector["Direccion"].ToString();

                    if (!Convert.IsDBNull(lector["Ciudad"]))
                        proveedor.Ciudad = lector["Ciudad"].ToString();

                    if (!Convert.IsDBNull(lector["CodigoPostal"]))
                        proveedor.CodigoPostal = lector["CodigoPostal"].ToString();

                    if (!Convert.IsDBNull(lector["FechaRegistro"]))
                        proveedor.FechaRegistro = Convert.ToDateTime(lector["FechaRegistro"]).ToShortDateString();

                    listado.Add(proveedor);
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

        public void agregar(Proveedor nuevoProveedor)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "  INSERT INTO [TPC_ESPINOLA].[dbo].[Proveedores] (CUIT,RazonSocial,Email,Direccion,Ciudad,CodigoPostal,FechaRegistro) VALUES (@CUIT,@RazonSocial,@Email,@Direccion,@Ciudad,@CodigoPostal,@FechaRegistro)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@CUIT", nuevoProveedor.CUIT);
                comando.Parameters.AddWithValue("@RazonSocial", nuevoProveedor.RazonSocial.ToString());
                comando.Parameters.AddWithValue("@Email", nuevoProveedor.Email.ToString());
                comando.Parameters.AddWithValue("@Direccion", nuevoProveedor.Direccion.ToString());
                comando.Parameters.AddWithValue("@Ciudad", nuevoProveedor.Ciudad.ToString());
                comando.Parameters.AddWithValue("@CodigoPostal", nuevoProveedor.CodigoPostal.ToString());
                comando.Parameters.AddWithValue("@FechaRegistro", nuevoProveedor.FechaRegistro);
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

        public void modificar(Proveedor proveedor, string proveedorID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "UPDATE [TPC_ESPINOLA].[dbo].[Proveedores] SET CUIT = @CUIT, RazonSocial = @RazonSocial, Email = @Email, Direccion = @Direccion, Ciudad = @Ciudad, CodigoPostal = @CodigoPostal, FechaRegistro = @FechaRegistro WHERE[TPC_ESPINOLA].[dbo].[Proveedores].ID = @ID";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ID", proveedorID);
                comando.Parameters.AddWithValue("@CUIT", proveedor.CUIT);
                comando.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
                comando.Parameters.AddWithValue("@Email", proveedor.Email);
                comando.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                comando.Parameters.AddWithValue("@Ciudad", proveedor.Ciudad);
                comando.Parameters.AddWithValue("@CodigoPostal", proveedor.CodigoPostal);
                comando.Parameters.AddWithValue("@FechaRegistro", proveedor.FechaRegistro);
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

        public string traerIDProveedor(string CUIT)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            string idProveedor = null;
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "SELECT [Id] FROM[TPC_ESPINOLA].[dbo].[Proveedores] WHERE[TPC_ESPINOLA].[dbo].[Proveedores].CUIT = @CUIT";
                comando.Connection = conexion;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@CUIT", CUIT);
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    idProveedor = lector["Id"].ToString();
                }

                return idProveedor;

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
        public Proveedor traerProveedor(string ID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            ProductoNegocio negocioProducto;
            Proveedor proveedor = new Proveedor();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM[TPC_ESPINOLA].[dbo].[Proveedores] WHERE [TPC_ESPINOLA].[dbo].[Proveedores].Id = @ID";
                comando.Connection = conexion;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ID", ID);
                conexion.Open();
                lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    negocioProducto = new ProductoNegocio();
                    proveedor.ID = int.Parse(lector["Id"].ToString());
                    proveedor.RazonSocial = lector["RazonSocial"].ToString();
                    proveedor.CUIT = lector["CUIT"].ToString();
                    proveedor.Ciudad = lector["Ciudad"].ToString();
                    proveedor.CodigoPostal = lector["CodigoPostal"].ToString();
                    proveedor.Direccion = lector["Direccion"].ToString();
                    proveedor.Email = lector["Email"].ToString();
                    proveedor.Productos = negocioProducto.listar(lector["Id"].ToString());
                }
                return proveedor;
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
                comando.CommandText = "delete from [TPC_ESPINOLA].[dbo].[Proveedores] where ID = @id";
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
        public void agregarProducto(string ProductoID, string ProveedorID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "  INSERT INTO [TPC_ESPINOLA].[dbo].[ProductosXProveedores] (ProductoID,ProveedorID) VALUES (@ProductoID,@ProveedorID)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ProductoID", ProductoID);
                comando.Parameters.AddWithValue("@ProveedorID", ProveedorID);
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
        public void eliminarProductos(string ProveedorID)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandText = "DELETE from [TPC_ESPINOLA].[dbo].[ProductosXProveedores] where [TPC_ESPINOLA].[dbo].[ProductosXProveedores].ProveedorID = @ProveedorID";
                comando.Connection = conexion;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@ProveedorID", ProveedorID);
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
        public List<Producto> listarProductos(string ProveedorID)
        {
            List<Producto> listaProductos = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            string productoID;
            Producto producto;
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT [ProductoID] FROM [TPC_ESPINOLA].[dbo].[ProductosXProveedores] WHERE [TPC_ESPINOLA].[dbo].[ProductosXProveedores].ProveedorID = @ProveedorID";
                comando.Connection = conexion;
                comando.Parameters.AddWithValue("@ProveedorID", ProveedorID);
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {

                    productoID = lector["ProductoID"].ToString();
                    producto = negocio.traerProducto(productoID);
                    listaProductos.Add(producto);
                }

                return listaProductos;

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
