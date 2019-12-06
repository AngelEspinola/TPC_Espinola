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
            var ciudad = $('#txtCiudad').val();
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
    <div style="text-align:center">

        <table class="table" style="text-align:center">
                <thead class="thead-light">
                <tr>
                    <th colspan="3" style="font-size:x-large" >
                        <label style="margin:0px 15px 10px 15px">INGRESA LOS DATOS</label>
                    </th>
                </tr>
        </table>
    </div>

    
    <div style="margin-left:38%">
        <div class="form-group">
            <label>CUIT</label>
            <asp:TextBox ID="txtCUIT" MaxLength="20" style="width:300px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            <%--<asp:Button Text="Buscar"  CssClass="btn btn-info btn-lg" runat="server"  OnClick="BuscarCUIT"/>--%>
        </div>
        <div class="form-group">
            <label>Razon Social</label>
            <asp:TextBox ID="txtRazonSocial" MaxLength="100" style="width:300px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" MaxLength="100" style="width:300px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Direccion</label>
            <asp:TextBox ID="txtDireccion" MaxLength="50" style="width:300px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Ciudad</label>
            <asp:TextBox ID="txtCiudad" MaxLength="50" style="width:300px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Codigo Postal</label>
            <asp:TextBox ID="txtCodigoPostal" MaxLength="8" style="width:300px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Fecha de Registro</label>
            <asp:TextBox ID="txtFechaRegistro" MaxLength="10" style="width:300px" ClientIDMode="Static" CssClass="form-control" runat="server" />    
    </div>
    </div>
    <table class="table" style="text-align:center">
                <thead class="thead-light">
                <tr>
                    <th colspan="3" style="font-size:x-large" >
                        <label style="font-size:large;font-weight:bold">PRODUCTOS</label>
                    </th>
                </tr>
        </table>
    <div style="text-align:center">
    </div>
    <div class="form-group" style="margin-left:auto;margin-right:auto;width:80%">
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
    <div style="text-align:center">
        <asp:Button Text="Aceptar" ID="btnAceptar"  OnClientClick="return validar()" OnClick ="CargarDatos"  CssClass="btn btn-primary btn-lg" runat ="server"/>
    </div>

</asp:Content>
