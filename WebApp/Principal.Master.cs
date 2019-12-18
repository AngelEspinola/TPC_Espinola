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
    public partial class Principal : System.Web.UI.MasterPage
    {
        public Usuario user;
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        public bool IsAdmin()
        {
            bool response = false;
            if (Session["user"] != null)
            {
                user = (Usuario)Session["user"];

                if(user.Nivel == 1)
                {
                    response = true;
                }
            }
            return response;
        }
        protected void LogOut_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}