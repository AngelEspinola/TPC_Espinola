<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApp.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="text-align:center;margin-bottom:15px">
        <h1>USUARIOS</h1>
    <asp:Button Text="Nuevo" CssClass="btn btn-secondary" onclick="btnNuevoUsuario_OnClick" runat="server" />
    </div>
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
    
</asp:Content>
