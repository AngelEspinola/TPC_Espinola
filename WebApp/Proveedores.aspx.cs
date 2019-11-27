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
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosGrilla();
            }
        }
        protected void CargarDatosGrilla()
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            List<Proveedor> listaProveedor;
            listaProveedor = negocio.listar();
            dgvProveedores.DataSource = listaProveedor;
            dgvProveedores.DataBind();
        }
        protected void NuevoProveedor_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("NuevoProveedor.aspx");
        }
        protected void dgvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            int id = Convert.ToInt32(dgvProveedores.Rows[e.RowIndex].Cells[0].Text);
            negocio.eliminar(id);
            CargarDatosGrilla();
        }
        protected void dgvProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("NuevoProveedor.aspx" + dgvProveedores.SelectedRow.Cells[1]);
            dgvProveedores.EditIndex = e.NewEditIndex;
            CargarDatosGrilla();
        }
        protected void btnModificar_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Redirect("NuevoProveedor.aspx?idpkm=" + btn.CommandArgument.ToString());
        }
        protected void btnEliminar_OnClick(object sender, EventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument.ToString());
            negocio.eliminar(id);
            CargarDatosGrilla();
        }
        protected void dgvProveedores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvProveedores.EditIndex = -1;
            CargarDatosGrilla();
        }
        protected void dgvProveedores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Proveedor proveedor = new Proveedor();
            //ProveedorNegocio negocio = new ProveedorNegocio();

            //proveedor.ID            = Convert.ToInt32(e.NewValues["ID"].ToString());
            //proveedor.CUIT          = e.NewValues["CUIT"].ToString();
            //proveedor.RazonSocial   = e.NewValues["RazonSocial"].ToString();
            //proveedor.Email         = e.NewValues["Email"].ToString();
            //proveedor.Direccion     = e.NewValues["Direccion"].ToString();
            //proveedor.Ciudad        = e.NewValues["Ciudad"].ToString();
            //proveedor.CodigoPostal  = e.NewValues["CodigoPostal"].ToString();
            //proveedor.FechaRegistro = e.NewValues["FechaRegistro"].ToString();

            //negocio.modificar(proveedor);
            //dgvProveedores.EditIndex = -1;
            //CargarDatosGrilla();
        }

    }
}