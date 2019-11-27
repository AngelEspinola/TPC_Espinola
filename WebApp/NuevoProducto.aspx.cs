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
        int productoID;
        protected void Page_Load(object sender, EventArgs e)
        {
            productoID = Convert.ToInt32(Request.QueryString["idpkm"]);
            if (productoID != 0 && !IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<Producto> listaProductos = negocio.listar();
                productoLocal = listaProductos.Find(J => J.ID == productoID);
                if (productoLocal != null)
                {
                    txtTitulo.Text = productoLocal.Titulo;
                    txtDescripcion.Text = productoLocal.Descripcion;
                    txtURLImagen.Text = productoLocal.URLImagen;
                }
            }
        }
        public void CargarDatos(object sender, EventArgs e)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            productoLocal = new Producto();

            if (Convert.ToInt32(Request.QueryString["idpkm"]) != 0)
            {
                productoID = Convert.ToInt32(Request.QueryString["idpkm"]);
                productoLocal.Titulo = txtTitulo.Text;
                productoLocal.Descripcion = txtDescripcion.Text;
                productoLocal.URLImagen = txtURLImagen.Text;

                negocioProducto.modificar(productoLocal, productoID);
            }
            else 
            {
                productoLocal.Descripcion = txtDescripcion.Text;
                productoLocal.Titulo = txtTitulo.Text;
                productoLocal.URLImagen = txtURLImagen.Text;
                
                negocioProducto.agregar(productoLocal);
            }
            Response.Redirect("Productos.aspx");
        }
    }
}