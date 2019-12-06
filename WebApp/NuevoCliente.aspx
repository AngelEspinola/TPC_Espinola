<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NuevoCliente.aspx.cs" Inherits="WebApp.NuevoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
     <script>
         function validar() {
            var DNI = $('#txtDNI').val();
            var nombre = $('#txtNombre').val();
            var apellido = $('#txtApellido').val();
            var direccion = $('#txtDireccion').val();
            var email = $('#txtEmail').val();
            var ciudad = $('#txtCiudad').val();
            var codigoPostal = $('#txtCodigoPostal').val();
            var fechaRegistro = $('#txtFechaRegistro').val();

            if (!DNI || !nombre || !apellido || !direccion || !email || !ciudad || !codigoPostal || !fechaRegistro)
            {
                 alert('Debes completar todos los campos para proceder!');
                 return false;
            }

            if (isNaN(DNI))
            {
                alert("El DNI debe contener solo numeros! Ejemplo: 39515418");
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

    
    <div style="margin-left:43%">
        <div class="form-group">
            <label>DNI</label>
            <asp:TextBox ID="txtDNI" MaxLength="20" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            <asp:Button Text="Buscar" Visible="false"  CssClass="btn btn-info btn-lg" runat="server"  OnClick="BuscarCUIT"/>
        </div>
        <div class="form-group">
            <label>Nombre</label>
            <asp:TextBox ID="txtNombre" MaxLength="100" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Apellido</label>
            <asp:TextBox ID="txtApellido" MaxLength="50" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" MaxLength="100" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Direccion</label>
            <asp:TextBox ID="txtDireccion" MaxLength="150" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Ciudad</label>
            <asp:TextBox ID="txtCiudad" MaxLength="100" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Codigo Postal</label>
            <asp:TextBox ID="txtCodigoPostal" MaxLength="8" style="width:80px" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Fecha de Registro</label>
            <asp:TextBox ID="txtFechaRegistro" MaxLength="10" style="width:150px" ClientIDMode="Static" CssClass="form-control" runat="server" />    
    </div>
    </div>

    <div style="text-align:center">

    <asp:Button Text="Aceptar" ID="btnAceptar"  OnClientClick="return validar()" OnClick ="CargarDatos"  CssClass="btn btn-primary btn-lg" runat ="server"/>
    </div>
</asp:Content>
