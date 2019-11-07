<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NuevoProducto.aspx.cs" Inherits="WebApp.NuevoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script>
         function validar() {
            var titulo = $('#txtTitulo').val();
            var descripcion = $('#txtDescripcion').val();
            var URLImagen = $('#txtURLImagen').val();
            if (!titulo || !descripcion || !URLImagen)
            {
                 alert('Debes completar todos los campos para proceder!');
                 return false;

            }
            return true;
}
    </script>
    <h1>Ingresa los datos</h1>
    
        <div class="form-group">
            <label>Titulo</label>
            <asp:TextBox ID="txtTitulo" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Descripcion</label>
            <asp:TextBox ID="txtDescripcion" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>URLImagen</label>
            <asp:TextBox ID="txtURLImagen" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <asp:Button Text="Aceptar" ID="btnAceptar"  OnClientClick="return validar()" OnClick ="CargarDatos"  CssClass="btn btn-primary" runat ="server"/>

</asp:Content>
