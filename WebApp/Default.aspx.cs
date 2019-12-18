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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user;
            if (!IsPostBack)
            {
            }
            if (Session["user"] != null)
            {
                user = (Usuario)Session["user"];
                Label userTopNav = (Label)Master.FindControl("userTopNav");
                userTopNav.Text = user.Identificador;
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
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