using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnNuevaCompra_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("NuevaCompra.aspx");
        }
    }
}