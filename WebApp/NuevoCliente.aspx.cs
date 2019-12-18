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
    public partial class NuevoCliente : System.Web.UI.Page
    {

        Producto producto;
        Cliente clienteLocal;

        protected void Page_Load(object sender, EventArgs e)
        {
            var productoID = Convert.ToInt32(Request.QueryString["idpkm"]);
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> listaProductos = negocio.listar();
            producto = listaProductos.Find(J => J.ID == productoID);
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
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
        }

        public void BuscarCUIT(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> listaClientes;
            listaClientes = negocio.listar();
            clienteLocal = listaClientes.Find(X => X.DNI == txtDNI.Text);
            if (clienteLocal != null)
            {
                txtNombre.Text = clienteLocal.Nombre.ToString();
                txtApellido.Text = clienteLocal.Apellido.ToString();
                txtEmail.Text = clienteLocal.Email.ToString();
                txtDireccion.Text = clienteLocal.Direccion.ToString();
                txtCiudad.Text = clienteLocal.Ciudad.ToString();
                txtCodigoPostal.Text = clienteLocal.CodigoPostal.ToString();
                txtFechaRegistro.Text = clienteLocal.FechaRegistro;
                Session["ClienteID" + Session.SessionID] = negocio.traerIDCliente(txtDNI.Text);
            }
            else
            {
                string msg = "<script language=\"javascript\">";
                msg += "alert(' DNI no encontrado ');";
                msg += "</script>";
                Response.Write(msg);
            }
        }
        
        public void CargarDatos(object sender, EventArgs e)
        {
            ClienteNegocio negocioCliente = new ClienteNegocio();
            clienteLocal = new Cliente();

            if (Session["ClienteID" + Session.SessionID] == null)
            {
                clienteLocal.DNI = txtDNI.Text;
                clienteLocal.Apellido = txtApellido.Text;
                clienteLocal.Nombre = txtNombre.Text;
                clienteLocal.Email = txtEmail.Text;
                clienteLocal.Direccion = txtDireccion.Text;
                clienteLocal.Ciudad = txtCiudad.Text;
                clienteLocal.CodigoPostal = txtCodigoPostal.Text;
                clienteLocal.FechaRegistro = txtFechaRegistro.Text;

                negocioCliente.agregar(clienteLocal);
                clienteLocal.ID = Convert.ToInt32(negocioCliente.traerIDCliente(clienteLocal.DNI));
            }
            else
            {
                clienteLocal.ID = Convert.ToInt32(Session["ClienteID" + Session.SessionID]);
            }
            Response.Redirect("Clientes.aspx");

        }
    }
}