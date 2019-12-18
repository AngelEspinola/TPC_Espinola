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

        protected void ViewDetails(object sender, EventArgs e)
        {
            //Grab the selected row
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;

            DetalleVentaNegocio negocioVenta = new DetalleVentaNegocio();

            dgvDetalles.DataSource = negocioVenta.listar(row.Cells[0].Text);
            dgvDetalles.DataBind();
            GridViewDetails.Show();
        }


        protected void btnclose_Click(object sender, EventArgs e)
        {
            //Hide the modal popup extender
            GridViewDetails.Hide();
        }
    }
}