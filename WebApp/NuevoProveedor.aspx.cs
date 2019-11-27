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
        string ProveedorID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarGridView();
            }

            ProveedorID = Request.QueryString["idpkm"];
            if (ProveedorID != null && !IsPostBack)
            {
                ProveedorNegocio negocioProveedor = new ProveedorNegocio();
                List<Proveedor> listaProveedores = negocioProveedor.listar();
                List<Producto> listaProductos = negocioProveedor.listarProductos(ProveedorID.ToString());
                proveedorLocal = listaProveedores.Find(J => J.ID.ToString() == ProveedorID);
                if (proveedorLocal != null)
                {
                    
                    txtCUIT.Text = proveedorLocal.CUIT;
                    txtRazonSocial.Text = proveedorLocal.RazonSocial;
                    txtEmail.Text = proveedorLocal.Email;
                    txtDireccion.Text = proveedorLocal.Direccion;
                    txtCiudad.Text = proveedorLocal.Ciudad;
                    txtCodigoPostal.Text = proveedorLocal.CodigoPostal;
                    txtFechaRegistro.Text = proveedorLocal.FechaRegistro;
                    foreach (GridViewRow dgvItem in this.dgvProductos.Rows)
                    {
                        CheckBox Sel = ((CheckBox)dgvProductos.Rows[dgvItem.RowIndex].FindControl("cbxSeleccion"));

                        Producto match;
                        match = listaProductos.Find(X => X.ID.ToString() == dgvItem.Cells[1].Text);
                        if (match != null)
                        {
                            Sel.Checked = true;
                        }
                    }
                }
            }

        }
        protected void chkStatus_OnChackedChanged(object sender, EventArgs e)
        {
        }
        protected void CargarGridView()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
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
        private void traerProductosSeleccionados(ref string[] productos)
        {
            foreach (GridViewRow dgvItem in this.dgvProductos.Rows)
            {

                CheckBox Sel = ((CheckBox)dgvProductos.Rows[dgvItem.RowIndex].FindControl("cbxSeleccion"));

                if (Sel.Checked)
                {
                    Array.Resize(ref productos, productos.Length + 1);
                    productos[productos.Length - 1] = dgvItem.Cells[1].Text;
                }
            }
        }

        public void CargarDatos(object sender, EventArgs e)
        {
            ProveedorNegocio negocioProveedor = new ProveedorNegocio();
            proveedorLocal = new Proveedor();

            proveedorLocal.CUIT = txtCUIT.Text;
            proveedorLocal.RazonSocial = txtRazonSocial.Text;
            proveedorLocal.Email = txtEmail.Text;
            proveedorLocal.Direccion = txtDireccion.Text;
            proveedorLocal.Ciudad = txtCiudad.Text;
            proveedorLocal.CodigoPostal = txtCodigoPostal.Text;
            proveedorLocal.FechaRegistro = txtFechaRegistro.Text;

            if (Request.QueryString["idpkm"] == "") //Se agrega proveedor
            {
                negocioProveedor.agregar(proveedorLocal);
            }
            else //Se modifica proveedor
            {
                ProveedorID = Request.QueryString["idpkm"].ToString();
                negocioProveedor.modificar(proveedorLocal, ProveedorID);
                negocioProveedor.eliminarProductos(ProveedorID.ToString());
            }
            //Array que va a ser cargado con aquellos ID de productos asignados al proveedor
            string[] productosSeleccionados = new string[0];
            traerProductosSeleccionados(ref productosSeleccionados);

            for (int i = 0; i < productosSeleccionados.Length; i++)
            {
                negocioProveedor.agregarProducto(productosSeleccionados[i],negocioProveedor.traerIDProveedor(proveedorLocal.CUIT));
            }
            //proveedorLocal.ID = Convert.ToInt32(negocioProveedor.traerIDProveedor(proveedorLocal.CUIT));
            Response.Redirect("Proveedores.aspx");
        }
    }
}