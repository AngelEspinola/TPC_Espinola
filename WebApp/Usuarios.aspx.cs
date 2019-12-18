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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosGrilla();
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
        protected void CargarDatosGrilla()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> listaUsuarios;
            listaUsuarios = negocio.listar();
            dgvUsuarios.DataSource = listaUsuarios;
            dgvUsuarios.DataBind();
        }

        protected void btnNuevoUsuario_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("NuevoUsuario.aspx");
        }

        protected void dgvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            int id = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells[0].Text);
            negocio.eliminar(id);
            CargarDatosGrilla();
        }
        protected void dgvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvUsuarios.EditIndex = e.NewEditIndex;
            CargarDatosGrilla();
        }
        protected void dgvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvUsuarios.EditIndex = -1;
            CargarDatosGrilla();
        }
        protected void dgvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            usuario.ID = Convert.ToInt32(e.NewValues["ID"].ToString());
            usuario.Identificador = e.NewValues["Identificador"].ToString();
            usuario.Nivel = Convert.ToInt32(e.NewValues["Nivel"].ToString());
            usuario.Contraseña = e.NewValues["Contraseña"].ToString();
            usuario.Email = e.NewValues["Email"].ToString();

            negocio.modificar(usuario);
            dgvUsuarios.EditIndex = -1;
            CargarDatosGrilla();
        }
    }
}