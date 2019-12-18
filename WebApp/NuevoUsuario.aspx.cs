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
    public partial class NuevoUsuario : System.Web.UI.Page
    {
        Usuario usuarioLocal;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            usuarioLocal = new Usuario();
            string response = "";
            usuarioLocal.Identificador = txtIdentificador.Text;
            usuarioLocal.Nivel = Convert.ToInt32(txtNivel.Text);
            usuarioLocal.Contraseña = txtContraseña.Text;
            usuarioLocal.Email = txtEmail.Text;

            response = negocioUsuario.agregar(usuarioLocal);
            if (response == "")
            {
                Session["Exito"] = "Usuario generado con exito!";
                Response.Redirect("Exito.aspx");
            }
            else
            {
                Session["Error"] = response;
                Response.Redirect("Error.aspx");
            }
        }
    }
}