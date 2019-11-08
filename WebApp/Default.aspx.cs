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
    }

    
}