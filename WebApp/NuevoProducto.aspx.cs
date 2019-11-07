using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace WebApp
{
    public partial class NuevoProducto : System.Web.UI.Page
    {

        Producto productoLocal;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CargarDatos(object sender, EventArgs e)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            productoLocal = new Producto();

            if (Session["ClienteID" + Session.SessionID] == null)
            {
                productoLocal.Descripcion = txtDescripcion.Text;
                productoLocal.Titulo = txtTitulo.Text;
                productoLocal.URLImagen = txtURLImagen.Text;
                
                negocioProducto.agregar(productoLocal);
            }
            else
            {
            }

        }
    }
}