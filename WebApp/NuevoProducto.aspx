<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NuevoProducto.aspx.cs" Inherits="WebApp.NuevoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script>
         function validar() {
            var titulo = $('#txtTitulo').val();
            var descripcion = $('#txtDescripcion').val();
            var URLImagen = $('#txtURLImagen').val();

            var ganancia = $('#txtGanancia').val();
            
             if (!titulo || !descripcion || !URLImagen || !ganancia)
             {
                 alert('Hay campos obligatorios sin completar!');
                 return false;
             }
             if (isNaN(ganancia.replace(",",".")))
             {
                 alert('La ganancia debe ser un numero!');
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
                <label style="font-size:small">(*)</label>
                <label>Titulo</label>
                <asp:TextBox ID="txtTitulo" MaxLength="50" style="width:150px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group">
                <label style="font-size:small">(*)</label>
                <label>Descripcion</label>
                <asp:TextBox ID="txtDescripcion" MaxLength="200" style="width:350px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group">
                <label style="font-size:small">(*)</label>
                <label>URLImagen</label>
                <asp:TextBox ID="txtURLImagen" MaxLength="250" style="width:350px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group">
                <label style="font-size:small">(*)</label>
                <label>Porcentaje de Ganancia (%)</label>
                <asp:TextBox ID="txtGanancia" MaxLength="50" style="width:80px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group" style="width:200px">
                <label>Stock Minimo</label>
                <asp:TextBox ID="txtStockMinimo" MaxLength="50" style="width:80px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group" style="width:200px">
                <label>Stock</label>
                <asp:TextBox ID="txtStock" ReadOnly="true" MaxLength="99999999" style="width:80px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
                <label style="font-size:small">(*) Obligatorio</label>
    </div>
    <div style="text-align:center">
        <asp:Button Text="Guardar" ID="btnAceptar"  OnClientClick="return validar()" OnClick ="CargarDatos"  CssClass="btn btn-primary btn-lg" runat ="server"/>
    </div>

</asp:Content>
