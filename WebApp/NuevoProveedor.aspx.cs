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
    public partial class NuevoProveedor : System.Web.UI.Page
    {
        
        Proveedor proveedorLocal;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
        }

        public void BuscarCUIT(object sender, EventArgs e)
        {
           
        }
        public void CargarDatos(object sender, EventArgs e)
        {
            ProveedorNegocio negocioProveedor = new ProveedorNegocio();
            proveedorLocal = new Proveedor();

            if (Session["ProveedorID" + Session.SessionID] == null)
            {
                proveedorLocal.CUIT = txtCUIT.Text;
                proveedorLocal.RazonSocial = txtRazonSocial.Text;
                proveedorLocal.Email = txtEmail.Text;
                proveedorLocal.Direccion = txtDireccion.Text;
                proveedorLocal.Ciudad = txtCiudad.Text;
                proveedorLocal.CodigoPostal = txtCodigoPostal.Text;
                proveedorLocal.FechaRegistro = txtFechaRegistro.Text;

                negocioProveedor.agregar(proveedorLocal);
                proveedorLocal.ID = Convert.ToInt32(negocioProveedor.traerIDProveedor(proveedorLocal.CUIT));
            }
            else
            {
                proveedorLocal.ID = Convert.ToInt32(Session["ProveedorID" + Session.SessionID]);
            }

        }
    }
}