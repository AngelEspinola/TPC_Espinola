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
    public partial class Clientes : System.Web.UI.Page
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
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> listaClientes;
            listaClientes = negocio.listar();
            dgvClientes.DataSource = listaClientes;
            dgvClientes.DataBind();
        }
        protected void btnNuevoCliente_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("NuevoCliente.aspx");
        }

        protected void dgvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells[0].Text);
            negocio.eliminar(id);
            CargarDatosGrilla();
        }
        protected void dgvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvClientes.EditIndex = e.NewEditIndex;
            CargarDatosGrilla();
        }
        protected void dgvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvClientes.EditIndex = -1;
            CargarDatosGrilla();
        }
        protected void dgvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();

            cliente.ID = Convert.ToInt32(e.NewValues["ID"].ToString());
            cliente.DNI = e.NewValues["DNI"].ToString();
            cliente.Nombre = e.NewValues["Nombre"].ToString();
            cliente.Apellido = e.NewValues["Apellido"].ToString();
            cliente.Email = e.NewValues["Email"].ToString();
            cliente.Direccion = e.NewValues["Direccion"].ToString();
            cliente.Ciudad = e.NewValues["Ciudad"].ToString();
            cliente.CodigoPostal = e.NewValues["CodigoPostal"].ToString();
            cliente.FechaRegistro = e.NewValues["FechaRegistro"].ToString();

            negocio.modificar(cliente);
            dgvClientes.EditIndex = -1;
            CargarDatosGrilla();
        }

    }
}