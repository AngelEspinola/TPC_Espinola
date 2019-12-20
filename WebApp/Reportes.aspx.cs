using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebApp
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Usuario user = (Usuario)Session["user"];
                if (user.Nivel == 1)
                {
                    Label userTopNav = (Label)Master.FindControl("userTopNav");
                    userTopNav.Text = user.Identificador;
                }
                else
                {
                    Session["Error"] = "Whoops! parece que no tenes los permisos necesarios para ingresar a esta pagina.";
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }
        protected void Ventas_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }
        protected void Compras_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }

        protected void Stock_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Stock.aspx");
        }
    }
}