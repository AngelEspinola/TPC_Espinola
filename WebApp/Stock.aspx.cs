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
    public partial class Stock : System.Web.UI.Page
    {

        List<Producto> listaStock;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownLists();
                BindearListaStock();
            }
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
        private void LlenarDropDownLists()
        {
            List<string> lista = new List<string>();
            lista.Add("mayor que");
            lista.Add("menor que");
            lista.Add("igual a");

            ddlStockActualFiltro.DataSource = lista;
            ddlStockActualFiltro.DataBind();

            ddlStockMinimoFiltro.DataSource = lista;
            ddlStockMinimoFiltro.DataBind();

        }
        protected void BindearListaStock()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            listaStock = negocio.listar(false);
            dgvStock.DataSource = listaStock;
            dgvStock.DataBind();

        }
        protected void FiltrarGridProductos(object sender, EventArgs e)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            listaStock = negocioProducto.listar(cbxEscasos.Checked == true);
            
            if (txtProducto.Text != "")
            {
                listaStock = listaStock.FindAll(X => X.Titulo.ToLower().Contains(txtProducto.Text.ToLower()));
            }
            if (txtStockActual.Text != "")
            {
                switch (ddlStockActualFiltro.Text)
                {
                    case "mayor que":
                        listaStock = listaStock.FindAll(X => X.Stock > float.Parse(txtStockActual.Text));
                        break;
                    case "menor que":
                        listaStock = listaStock.FindAll(X => X.Stock < float.Parse(txtStockActual.Text));
                        break;
                    case "igual a":
                        listaStock = listaStock.FindAll(X => X.Stock == float.Parse(txtStockActual.Text));
                        break;
                }
            }
            if (txtStockMinimo.Text != "")
            {
                switch (ddlStockMinimoFiltro.Text)
                {
                    case "mayor que":
                        listaStock = listaStock.FindAll(X => X.StockMinimo > float.Parse(txtStockMinimo.Text));
                        break;
                    case "menor que":
                        listaStock = listaStock.FindAll(X => X.StockMinimo < float.Parse(txtStockMinimo.Text));
                        break;
                    case "igual a":
                        listaStock = listaStock.FindAll(X => X.StockMinimo == float.Parse(txtStockMinimo.Text));
                        break;
                }
            }
            dgvStock.DataSource = listaStock;
            dgvStock.DataBind();
        }
        protected void LimpiarFiltro(object sender, EventArgs e)
        {
            txtProducto.Text = string.Empty;
            txtStockActual.Text = string.Empty;
            txtStockMinimo.Text = string.Empty;
            cbxEscasos.Checked = false;
        }
    }
}