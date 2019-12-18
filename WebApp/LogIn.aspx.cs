using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using Negocio;
using Dominio;

namespace WebApp
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    Response.Write("<script>alert('PageLoad');</script>");
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Usuario LogUserIn(string user, string password)
        {
            Usuario response = null;

            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            List<Usuario> listaUsuarios = negocioUsuario.listar();
            Usuario match = listaUsuarios.Find(X => X.Identificador.ToString() == user && X.Contraseña.ToString() == password);

            if (match != null)
            {
               //Reconocio el usuario y contraseña ingresado con uno existente en la bbdd
               HttpContext.Current.Session["user"] = match;
               response = match;
            }
            return response;
        }
    }
}