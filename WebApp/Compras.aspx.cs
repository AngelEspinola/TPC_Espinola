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
    public partial class Compras : System.Web.UI.Page
    {
        List<Compra> listaCompras;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownLists();
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
        private void LlenarDropDownLists()
        {
            List<string> lista = new List<string>();
            lista.Add("mayor que");
            lista.Add("menor que");
            lista.Add("igual a");

            ddlImporteFiltro.DataSource = lista;
            ddlImporteFiltro.DataBind();

            ddlFechaFiltro.DataSource = lista;
            ddlFechaFiltro.DataBind();

        }
        protected void BindearListaVentas()
        {
            CompraNegocio negocio = new CompraNegocio();
            listaCompras = negocio.listar();
            dgvVentas.DataSource = listaCompras;
            dgvVentas.DataBind();

        }
        

        protected void ViewDetails(object sender, EventArgs e)
        {
            //Grab the selected row
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;

            DetalleCompraNegocio negocioCompra = new DetalleCompraNegocio();

            dgvDetalles.DataSource = negocioCompra.listar(row.Cells[0].Text);
            dgvDetalles.DataBind();
            GridViewDetails.Show();
        }


        protected void btnclose_Click(object sender, EventArgs e)
        {
            //Hide the modal popup extender
            GridViewDetails.Hide();
        }

        protected void FiltrarGridProductos(object sender, EventArgs e)
        {
            CompraNegocio negocioCompra = new CompraNegocio();
            listaCompras = negocioCompra.listar();

            if (dtpFecha.Text != "")
            {
                switch (ddlFechaFiltro.Text)
                {
                    case "mayor que":
                        listaCompras = listaCompras.FindAll(X => X.Fecha.Date.CompareTo(DateTime.Parse(dtpFecha.Text)) > 0);
                        break;
                    case "menor que":
                        listaCompras = listaCompras.FindAll(X => X.Fecha.Date.CompareTo(DateTime.Parse(dtpFecha.Text)) < 0);
                        break;
                    case "igual a":
                        listaCompras = listaCompras.FindAll(X => X.Fecha.Date.Equals(DateTime.Parse(dtpFecha.Text)));
                        break;
                }
            }
            if (txtClienteDNI.Text != "")
            {
                listaCompras = listaCompras.FindAll(X => X.Proveedor.CUIT == txtClienteDNI.Text);
            }
            if (txtImporte.Text != "")
            {
                switch (ddlImporteFiltro.Text)
                {
                    case "mayor que":
                        listaCompras = listaCompras.FindAll(X => X.Total > float.Parse(txtImporte.Text));
                        break;
                    case "menor que":
                        listaCompras = listaCompras.FindAll(X => X.Total < float.Parse(txtImporte.Text));
                        break;
                    case "igual a":
                        listaCompras = listaCompras.FindAll(X => X.Total == float.Parse(txtImporte.Text));
                        break;
                }
            }
            Session["listaVentas"] = listaCompras;
            dgvVentas.DataSource = listaCompras;
            dgvVentas.DataBind();
        }
        protected void LimpiarFiltro(object sender, EventArgs e)
        {
            txtClienteDNI.Text = string.Empty;
            txtImporte.Text = string.Empty;
            dtpFecha.Text = string.Empty;
        }
    }
}