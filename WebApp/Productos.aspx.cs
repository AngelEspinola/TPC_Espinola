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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Producto> listaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindearListaProductos();
            }
        }

        protected void BindearListaProductos ()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            listaProductos = negocio.listar();
            repetidor.DataSource = listaProductos;
            repetidor.DataBind();
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoProducto.aspx");
        }

        protected void btnEliminar_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ProductoNegocio negocio = new ProductoNegocio();
            negocio.eliminar(btn.CommandArgument.ToString());
            BindearListaProductos();
        }
    }
}