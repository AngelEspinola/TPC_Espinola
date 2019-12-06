using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace WebApp
{
    public partial class NuevaCompra : System.Web.UI.Page
    {
        Compra compraLocal;
        List<Detalle> detalleCompra = new List<Detalle>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Se limpia la lista en la Sesion. Generando que se pierdan los datos al salir o cambiar de pagina
                LimpiarGrilla();
                ProveedorNegocio negocioProveedor = new ProveedorNegocio();
                ddlProveedores.DataSource = negocioProveedor.listar();
                ddlProveedores.DataValueField = "ID";
                ddlProveedores.DataTextField = "RazonSocial";
                ddlProveedores.DataBind();

                ActualizarProductos();
            }
            else {
                
            }
        }
        private void LimpiarGrilla()
        {
            Session["listaDetalle"] = null;
            dgvDetalleCompra.DataSource = detalleCompra;
            dgvDetalleCompra.DataBind();
        }
        private void LimpiarCampos()
        {
            txtCantidad.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }
        public void AgregarDetalle(object sender, EventArgs e)
        {
            Detalle nuevoDetalle = new Detalle();
            ProductoNegocio negocioProducto = new ProductoNegocio();
            nuevoDetalle.Producto = negocioProducto.traerProducto(ddlProductos.SelectedItem.Value);
            nuevoDetalle.Cantidad = int.Parse(txtCantidad.Text);
            nuevoDetalle.Precio = float.Parse(txtPrecio.Text);
            nuevoDetalle.SubTotal = (float.Parse(txtPrecio.Text) * int.Parse(txtCantidad.Text));

            if (Session["listaDetalle"] != null)
            {
                detalleCompra = (List<Detalle>)Session["listaDetalle"];
            }
            detalleCompra.Add(nuevoDetalle);

            Session["listaDetalle"] = detalleCompra;

            dgvDetalleCompra.DataSource = detalleCompra;
            dgvDetalleCompra.DataBind();
            ActualizarTotal();
        }
        private void ActualizarTotal()
        {
            float totalDetalle = 0;
            List<Detalle> listaDetalle = Session["listaDetalle"] != null ? (List<Detalle>)Session["listaDetalle"] : null;
            if (listaDetalle != null)
            {
                foreach (Detalle det in listaDetalle)
                {
                    totalDetalle += det.SubTotal;
                }
            }
            Session["totalDetalle"] = totalDetalle;
            txtTotal.Text = totalDetalle.ToString("C2"); 
        }

        public void GuardarCompra(object sender, EventArgs e)
        {
            CompraNegocio negocioCompra = new CompraNegocio();
            ProveedorNegocio negocioProveedor = new ProveedorNegocio();
            ProductoNegocio negocioProducto = new ProductoNegocio();
            compraLocal = new Compra();
            Detalle detalleVenta;
            List<Detalle> listaDetalle = new List<Detalle>();
            compraLocal.Proveedor = negocioProveedor.traerProveedor(ddlProveedores.SelectedItem.Value);
            
            foreach (GridViewRow dgvItem in dgvDetalleCompra.Rows)
            {
                detalleVenta = new Detalle();
                detalleVenta.Producto = negocioProducto.traerProducto(dgvDetalleCompra.Rows[dgvItem.RowIndex].Cells[0].Text);
                detalleVenta.Cantidad = Convert.ToInt32(dgvDetalleCompra.Rows[dgvItem.RowIndex].Cells[2].Text);
                detalleVenta.Precio = float.Parse(dgvDetalleCompra.Rows[dgvItem.RowIndex].Cells[3].Text);
                listaDetalle.Add(detalleVenta);
            }
            compraLocal.Detalle = listaDetalle;
            compraLocal.Fecha = DateTime.Now;
            negocioCompra.agregarCompraYDetalle(compraLocal);
            
            Response.Redirect("Compras.aspx");

        }
        private void ActualizarProductos()
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            ddlProductos.DataSource = negocioProducto.listar(ddlProveedores.SelectedItem.Value);
            ddlProductos.DataValueField = "ID";
            ddlProductos.DataTextField = "Titulo";
            ddlProductos.DataBind();
        }
    

        protected void ddlProveedores_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarProductos();
            LimpiarGrilla();
            LimpiarCampos();
            ActualizarTotal();
        }
        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Detalle> listaDetalle = (List<Detalle>)Session["listaDetalle"];
            listaDetalle.RemoveAt(e.RowIndex);
            Session["listaDetalle"] = listaDetalle;

            dgvDetalleCompra.DataSource = listaDetalle;
            dgvDetalleCompra.DataBind();
        }
        protected void RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
        }
    }
}