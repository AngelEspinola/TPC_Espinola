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
        List<Detalle> listaDetalle = new List<Detalle>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["listaDetalle"] = null;
                ClienteNegocio negocioCliente = new ClienteNegocio();
                ddlClientes.DataSource = negocioCliente.listar();
                ddlClientes.DataTextField = "NombreYApellido";
                ddlClientes.DataValueField = "ID";
                ddlClientes.DataBind();

                ProductoNegocio negocioProducto = new ProductoNegocio();
                dgvProductos.DataSource = negocioProducto.listar();
                dgvProductos.DataBind();
            }
        }

        //public void GuardarVenta(object sender, EventArgs e)
        //{
        //    VentaNegocio negocioVenta = new VentaNegocio();
        //    ventaLocal = new Venta();
        //    ClienteNegocio negocioCliente = new ClienteNegocio();
        //    ProductoNegocio negocioProducto = new ProductoNegocio();
        //    Detalle detalleVenta = new Detalle();

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
            //ventaLocal.cliente = negocioCliente.traerCliente(txtCliente.Text);
            //ventaLocal.Detalle = new List<Detalle>();
            //detalleVenta.Producto = negocioProducto.traerProducto(txtProducto.Text);
            //detalleVenta.Cantidad = int.Parse(txtCantidad.Text);
            //ventaLocal.Detalle.Add(detalleVenta);

            //negocioVenta.agregarVentaYDetalle(ventaLocal);
            ////}
            //Response.Redirect("Ventas.aspx");

        //}

        protected void ddlClientes_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        protected void GuardarVenta(object sender, EventArgs e)
        {
            VentaNegocio negocioVenta = new VentaNegocio();
            ClienteNegocio negocioCliente = new ClienteNegocio();
            List<Detalle> listaDetalle = Session["listaDetalle"] != null? (List<Detalle>)Session["listaDetalle"] : null;

            if (listaDetalle != null && listaDetalle.Count != 0)
            {
                ventaLocal = new Venta();
                ventaLocal.Detalle = listaDetalle;
                ventaLocal.Fecha = DateTime.Now;
                ventaLocal.Cliente = negocioCliente.traerCliente(ddlClientes.SelectedItem.Value);
                negocioVenta.agregarVentaYDetalle(ventaLocal);

                Response.Redirect("Default.aspx");
            }
            else
            {
                Alerta("Oops! No tienes ningun producto en tu lista de Venta!");
            }
        }

        protected void AgregarDetalle(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Detalle nuevoDetalle = new Detalle();
            ProductoNegocio negocioProducto = new ProductoNegocio();
            List<Producto> listaProductos;
            if (Session["listaProductos"] != null)
            {
                listaProductos = (List<Producto>)Session["listaProductos"];
            }
            else
            {
                listaProductos = negocioProducto.listar();
            }
            List<Detalle> listaDetalle = new List<Detalle>();

            foreach (GridViewRow dgvItem in this.dgvProductos.Rows)
            {
                CheckBox Sel = ((CheckBox)dgvProductos.Rows[dgvItem.RowIndex].FindControl("cbxSeleccion"));
                if (Sel.Checked == true)
                {
                    nuevoDetalle = new Detalle();
                    nuevoDetalle.Producto = listaProductos[dgvItem.RowIndex];
                    nuevoDetalle.Precio = listaProductos[dgvItem.RowIndex].Precio;
                    nuevoDetalle.Cantidad = int.Parse(txtCantidad.Text);
                    nuevoDetalle.SubTotal = listaProductos[dgvItem.RowIndex].Precio * float.Parse(txtCantidad.Text);

                    if (Session["listaDetalle"] != null)
                    {
                        listaDetalle = (List<Detalle>)Session["listaDetalle"];
                    }
                    listaDetalle.Add(nuevoDetalle);

                    Session["listaDetalle"] = listaDetalle;


                    dgvDetalleVenta.DataSource = listaDetalle;
                    dgvDetalleVenta.DataBind();
                }
            }
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

        protected void FiltrarGridProductos(object sender, EventArgs e)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            List<Producto> listaProductos = negocioProducto.listar();

            if (txtProducto.Text != "")
            {
                listaProductos = listaProductos.FindAll(X => X.Titulo.ToLower().Contains(txtProducto.Text.ToLower()));
            }
            if (txtDescripcion.Text != "")
            {
                listaProductos = listaProductos.FindAll(X => X.Descripcion.ToLower().Contains(txtDescripcion.Text.ToLower()));
            }
            Session["listaProductos"] = listaProductos;
            dgvProductos.DataSource = listaProductos;
            dgvProductos.DataBind();
        }
        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Detalle> listaDetalle = (List<Detalle>)Session["listaDetalle"];
            listaDetalle.RemoveAt(e.RowIndex);
            Session["listaDetalle"] = listaDetalle;

            dgvDetalleVenta.DataSource = listaDetalle;
            dgvDetalleVenta.DataBind();
            ActualizarTotal();
        }
        protected void RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
        }
        private void Alerta(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }
    }

}