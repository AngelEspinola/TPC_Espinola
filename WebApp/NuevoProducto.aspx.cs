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
                    txtGanancia.Text = productoLocal.Ganancia.ToString();
                    txtStockMinimo.Text = productoLocal.StockMinimo.ToString();
                    txtStock.Text = productoLocal.Stock.ToString();
                }
            }
            else
            {
                txtStock.Text = "0";
            }
            if (Session["user"] != null)
            {
                Usuario user = (Usuario)Session["user"];
                Label userTopNav = (Label)Master.FindControl("userTopNav");
                userTopNav.Text = user.Identificador;
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }
        public void CargarDatos(object sender, EventArgs e)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            productoLocal = new Producto();

            productoLocal.Descripcion = txtDescripcion.Text;
            productoLocal.Titulo = txtTitulo.Text;
            productoLocal.URLImagen = txtURLImagen.Text;
            productoLocal.Ganancia = float.Parse(txtGanancia.Text);
            productoLocal.StockMinimo = int.Parse(txtStockMinimo.Text);
            productoLocal.Stock = long.Parse(txtStock.Text);

            if (Convert.ToInt32(Request.QueryString["idpkm"]) != 0)
            {
                productoID = Convert.ToInt32(Request.QueryString["idpkm"]);
                negocioProducto.modificar(productoLocal, productoID);
            }
            else 
            {
                negocioProducto.agregar(productoLocal);
            }
            Response.Redirect("Productos.aspx");
        }
    }
}