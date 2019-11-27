using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using AccesoDatos;

namespace WebApp
{
    public partial class NuevaVenta : System.Web.UI.Page
    {
        Venta ventaLocal;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocioCliente = new ClienteNegocio();
            ddlClientes.DataSource = negocioCliente.listar();
            ddlClientes.DataBind();
            
            ProductoNegocio negocioProducto = new ProductoNegocio();
            ddlProductos.DataSource = negocioProducto.listar();
            ddlProductos.DataBind();
        }

        public void GuardarVenta(object sender, EventArgs e)
        {
            VentaNegocio negocioVenta = new VentaNegocio();
            ventaLocal = new Venta();
            ClienteNegocio negocioCliente = new ClienteNegocio();
            ProductoNegocio negocioProducto = new ProductoNegocio();
            DetalleVenta detalleVenta = new DetalleVenta();

            //if (Convert.ToInt32(Request.QueryString["idpkm"]) != 0)
            //{
            //    productoID = Convert.ToInt32(Request.QueryString["idpkm"]);
            //    productoLocal.Titulo = txtTitulo.Text;
            //    productoLocal.Descripcion = txtDescripcion.Text;
            //    productoLocal.URLImagen = txtURLImagen.Text;

            //    negocioProducto.modificar(productoLocal, productoID);
            //}
            //else
            //{
            ventaLocal.cliente = negocioCliente.traerCliente(txtCliente.Text);
            ventaLocal.Detalle = new List<DetalleVenta>();
            detalleVenta.Producto = negocioProducto.traerProducto(txtProducto.Text);
            detalleVenta.Cantidad = int.Parse(txtCantidad.Text);
            ventaLocal.Detalle.Add(detalleVenta);

            negocioVenta.agregarVentaYDetalle(ventaLocal);
            //}
            Response.Redirect("Ventas.aspx");

        }
    }

}