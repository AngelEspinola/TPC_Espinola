using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WebApp
{
    public partial class Ventas : System.Web.UI.Page
    {
        List<Venta> listaVentas;
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
            VentaNegocio negocio = new VentaNegocio();
            listaVentas = negocio.listar();

            Session["listaVentas"] = listaVentas;
            dgvVentas.DataSource = listaVentas;
            dgvVentas.DataBind();

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

        protected void FiltrarGridProductos(object sender, EventArgs e)
        {
            VentaNegocio negocioVenta = new VentaNegocio();
            listaVentas = negocioVenta.listar();

            if (dtpFecha.Text != "")
            {
                switch (ddlFechaFiltro.Text)
                {
                    case "mayor que":
                        listaVentas = listaVentas.FindAll(X => X.Fecha.Date.CompareTo(DateTime.Parse(dtpFecha.Text)) > 0);
                        break;
                    case "menor que":
                        listaVentas = listaVentas.FindAll(X => X.Fecha.Date.CompareTo(DateTime.Parse(dtpFecha.Text)) < 0);
                        break;
                    case "igual a":
                        listaVentas = listaVentas.FindAll(X => X.Fecha.Date.Equals(DateTime.Parse(dtpFecha.Text)));
                        break;
                }
            }
            if (txtClienteDNI.Text != "")
            {
                listaVentas = listaVentas.FindAll(X => X.Cliente.DNI == txtClienteDNI.Text);
            }
            if (txtImporte.Text != "")
            {
                switch (ddlImporteFiltro.Text)
                {
                    case "mayor que":
                        listaVentas = listaVentas.FindAll(X => X.Total > float.Parse(txtImporte.Text));
                        break;
                    case "menor que":
                        listaVentas = listaVentas.FindAll(X => X.Total < float.Parse(txtImporte.Text));
                        break;
                    case "igual a":
                        listaVentas = listaVentas.FindAll(X => X.Total == float.Parse(txtImporte.Text));
                        break;
                }
            }
            Session["listaVentas"] = listaVentas;
            dgvVentas.DataSource = listaVentas;
            dgvVentas.DataBind();
        }
        protected void LimpiarFiltro(object sender, EventArgs e)
        {
            txtClienteDNI.Text = string.Empty;
            txtImporte.Text = string.Empty;
            dtpFecha.Text = string.Empty;
        }
        protected void GeneratePDF(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            VentaNegocio negocioVenta = new VentaNegocio();
            Venta venta;
            List<Venta> listaVentas = (List<Venta>)Session["listaVentas"];
            venta = listaVentas.Find(X => X.ID == int.Parse(btn.CommandArgument.ToString()));
            if(venta != null)
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("C:/PDF/"+venta.Cliente.DNI+"_"+venta.Fecha.Date.Year+venta.Fecha.Month+venta.Fecha.Day+".pdf", FileMode.Create, FileAccess.ReadWrite));
                doc.Open();

                Paragraph title = new Paragraph();
                title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
                title.Add("Factura");

                doc.Add(new Paragraph("Cliente: " + venta.Cliente.NombreYApellido));
                doc.Add(new Paragraph("DNI: " + venta.Cliente.DNI));
                doc.Add(new Paragraph("Fecha: " + venta.Fecha.ToString() + "\n"));

                doc.Add(new Paragraph(""));
                PdfPTable table = new PdfPTable(3);

                table.AddCell("Producto");

                table.AddCell("Cantidad");

                table.AddCell("Precio");

                foreach (Detalle det in venta.Detalle)
                {
                    table.AddCell(det.Producto.Titulo);
                    table.AddCell(det.Cantidad.ToString());
                    table.AddCell(det.Precio.ToString("C2"));
                }

                doc.Add(table);

                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Total: " + venta.Total.ToString("C2")));

                doc.Close();

                System.Diagnostics.Process.Start("C:/PDF/" + venta.Cliente.DNI + "_" + venta.Fecha.Date.Year + venta.Fecha.Month + venta.Fecha.Day + ".pdf");
            }
            //Generar PDF 
        }
    }
}