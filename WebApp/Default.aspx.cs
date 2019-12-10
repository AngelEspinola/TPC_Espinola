using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Clientes_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }
        protected void Productos_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
        protected void Proveedores_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }
        protected void Ventas_OnClick(object sender, EventArgs e)
        {
            //Response.Redirect("Ventas.aspx");
            Response.Redirect("NuevaVenta.aspx");
        }
        protected void Compras_OnClick(object sender, EventArgs e)
        {
            //Response.Redirect("Compras.aspx");
            Response.Redirect("NuevaCompra.aspx");
        }

        protected void Reportes_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }

    
}