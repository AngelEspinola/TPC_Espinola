<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebApp.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>CLIENTES</h1>
    <asp:Button Text="Nuevo" onclick="btnNuevoCliente_OnClick" runat="server" />
    <asp:GridView CssClass="table" ID="dgvClientes" runat="server" AutoGenerateColumns="false" OnRowEditing="dgvClientes_RowEditing" OnRowCancelingEdit="dgvClientes_RowCancelingEdit" OnRowDeleting="dgvClientes_RowDeleting" OnRowUpdating="dgvClientes_RowUpdating">
        <Columns>    
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="DNI" HeaderText="DNI" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
            <asp:BoundField DataField="CodigoPostal" HeaderText="Codigo Postal" />
            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" />
            <asp:CommandField ShowEditButton="true" />  
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>  
    </asp:GridView>
</asp:Content>
