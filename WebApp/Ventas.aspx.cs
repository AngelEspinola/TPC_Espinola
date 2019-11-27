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
    public partial class Ventas : System.Web.UI.Page
    {
        List<Venta> listaVentas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindearListaVentas();
            }
        }
        protected void BindearListaVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            listaVentas = negocio.listar();
            dgvVentas.DataSource = listaVentas;
            dgvVentas.DataBind();

        }

        protected void btnNuevaVenta_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("NuevaVenta.aspx");
        }
    }
}