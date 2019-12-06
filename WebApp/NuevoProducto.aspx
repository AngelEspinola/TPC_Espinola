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
            <asp:TextBox ID="txtTitulo" MaxLength="50" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Descripcion</label>
            <asp:TextBox ID="txtDescripcion" MaxLength="200" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>URLImagen</label>
            <asp:TextBox ID="txtURLImagen" MaxLength="250" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group" style="width:200px">
            <label>Porcentaje de Ganancia (%)</label>
            <asp:TextBox ID="txtGanancia" MaxLength="50" style="width:80px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <asp:Button Text="Guardar" ID="btnAceptar"  OnClientClick="return validar()" OnClick ="CargarDatos"  CssClass="btn btn-primary" runat ="server"/>

</asp:Content>
