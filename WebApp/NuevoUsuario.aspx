<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NuevoUsuario.aspx.cs" Inherits="WebApp.NuevoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
         function validar() {
            var identificador = $('#txtIdentificador').val();
            var nivel = $('#txtNivel').val();
            var email = $('#txtEmail').val();
            var contraseña = $('#txtContraseña').val();
            var contraseñaConfirmacion = $('#txtContraseñaConf').val();

             if (!identificador || !nivel || !email || !contraseña || !contraseñaConfirmacion)
             {
                 alert('Hay campos obligatorios sin completar!');
                 return false;
             }
             if (contraseña != contraseñaConfirmacion)
             {
                 alert('La contraseña ingresada no coincide con su confirmacion!');
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
                <label>Identificador</label>
                <asp:TextBox ID="txtIdentificador" MaxLength="100" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group">
                <label>Nivel</label>
                <asp:TextBox ID="txtNivel" MaxLength="20" style="width:50px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" MaxLength="250" style="width:350px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group">
                <label>Contraseña</label>
                <asp:TextBox ID="txtContraseña" TextMode="Password" MaxLength="100" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        <div class="form-group">
                <label>Confirmar Contraseña</label>
                <asp:TextBox ID="txtContraseñaConf" TextMode="Password" MaxLength="100" style="width:200px" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
    </div>
    <div style="text-align:center">
        <asp:Button Text="Guardar" ID="btnAceptar"  OnClientClick="return validar()" OnClick ="CargarDatos"  CssClass="btn btn-primary btn-lg" runat ="server"/>
    </div>

</asp:Content>
