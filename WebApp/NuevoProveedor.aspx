<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NuevoProveedor.aspx.cs" Inherits="WebApp.NuevoProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
         function validar() {
            var CUIT = $('#txtCUIT').val();
            var razonSocial = $('#txtRazonSocial').val();
            var direccion = $('#txtDireccion').val();
            var email = $('#txtEmail').val();
            //var ciudad = $('#txtCiudad').val();
             var codigoPostal = $('#txtCodigoPostal').val();
            var fechaRegistro = $('#txtFechaRegistro').val();
            if (!CUIT || !razonSocial || !direccion || !email || !ciudad || !codigoPostal || !fechaRegistro)
            {
                 alert('Debes completar todos los campos para proceder!');
                 return false;
            }
            return true;
}
    </script>
    <h1>Ingresa tus datos!</h1>
    
        <div class="form-group">
            <label>CUIT</label>
            <asp:TextBox ID="txtCUIT" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
            <%--<asp:Button Text="Buscar"  CssClass="btn btn-info btn-lg" runat="server"  OnClick="BuscarCUIT"/>--%>
        </div>
        <div class="form-group">
            <label>Razon Social</label>
            <asp:TextBox ID="txtRazonSocial" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Direccion</label>
            <asp:TextBox ID="txtDireccion" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Ciudad</label>
            <asp:TextBox ID="txtCiudad" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Codigo Postal</label>
            <asp:TextBox ID="txtCodigoPostal" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Fecha de Registro</label>
            <asp:TextBox ID="txtFechaRegistro" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />    
    </div>
    <div class="form-group">
            <label>Productos</label>
            <asp:DataGrid ID="DefaultGrid" Runat="server" AutoGenerateColumns="False">
             <Columns>
              </Columns>
            </asp:DataGrid>

        <asp:GridView CssClass="table" ID="dgvProductos" runat="server" AutoGenerateColumns="false" >
            <Columns>    
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbxSeleccion" runat="server" AutoPostBack="false" OnCheckedChanged="chkStatus_OnChackedChanged" Checked='false' />
                    </ItemTemplate>
              </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            </Columns>  
        </asp:GridView>


    </div>
    <asp:Button Text="Aceptar" ID="btnAceptar"  OnClientClick="return validar()" OnClick ="CargarDatos"  CssClass="btn btn-primary" runat ="server"/>

</asp:Content>
