<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="WebApp.NuevaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <script>
         function validar() {
            var DNI = $('#txtDNI').val();
            var nombre = $('#txtNombre').val();
            var apellido = $('#txtApellido').val();
            var direccion = $('#txtDireccion').val();
            var email = $('#txtEmail').val();
            //var ciudad = $('#txtCiudad').val();
            var codigoPostal = $('#txtCodigoPostal').val();
            var fechaRegistro = $('#txtFechaRegistro').val();
            debugger;
            if (!DNI || !nombre || !apellido || !direccion || !email || !ciudad || !codigoPostal || !fechaRegistro)
            {
                 alert('Debes completar todos los campos para proceder!');
                 return false;

            }
            return true;
}
    </script>--%>
    
        <div>
            <label>Cliente</label>
        </div>
        <div class="form-group">
            <asp:Button Text="Buscar" CssClass ="btn-dark" runat="server" />
            <asp:TextBox runat="server" ID="txtCliente" />
            <asp:DropDownList ID="ddlClientes" runat="server">
                
            </asp:DropDownList>
        </div>
        <div>
            <label>Proveedor</label>
        </div>
        <div>
            <asp:Button Text="Buscar" CssClass ="btn-dark" runat="server" />
            <asp:TextBox runat="server" ID="txtProducto"/>
            <asp:DropDownList ID="ddlProductos" runat="server"> </asp:DropDownList>
        
        </div>
        <div style="margin-top:20px">
            <label>Cantidad</label>
            <asp:TextBox runat="server" ID="txtCantidad" />
        </div>
    <div style="margin-top:15px">
        <asp:Button Text="Guardar" CssClass ="btn-dark" OnClick="GuardarVenta" runat="server" />
    </div>
</asp:Content>
