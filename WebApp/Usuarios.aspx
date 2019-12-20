<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApp.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">
        <table class="table" style="text-align:center">
                <thead class="thead-light">
                <tr>
                    <th colspan="3" style="font-size:x-large" >
                        <label style="margin:0px 15px 10px 15px">USUARIOS</label>
                    </th>
                </tr>
        </table>
        <asp:Button Text="Nuevo" CssClass="btn btn-primary btn-lg" onclick="btnNuevoUsuario_OnClick" runat="server" />
    </div>

    <div style="text-align:center;margin:15px 40px 0px 40px">
      <asp:GridView CssClass="table" ID="dgvUsuarios" runat="server" AutoGenerateColumns="false" OnRowEditing="dgvUsuarios_RowEditing" OnRowCancelingEdit="dgvUsuarios_RowCancelingEdit" OnRowDeleting="dgvUsuarios_RowDeleting" OnRowUpdating="dgvUsuarios_RowUpdating">
        <Columns>    
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Identificador" HeaderText="Identificador" />
            <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" />
            <asp:CommandField ShowEditButton="true" />  
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>  
    </asp:GridView>
        </div>
    
</asp:Content>
