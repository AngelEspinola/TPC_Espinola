<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="WebApp.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>PROVEEDORES</h1>
    <asp:Button Text="Nuevo" onclick="NuevoProveedor_OnClick" runat="server" />
    <asp:GridView CssClass="table" ID="dgvProveedores" runat="server" AutoGenerateColumns="false" OnRowEditing="dgvProveedores_RowEditing" OnRowCancelingEdit="dgvProveedores_RowCancelingEdit" OnRowDeleting="dgvProveedores_RowDeleting" OnRowUpdating="dgvProveedores_RowUpdating">
        <Columns>    
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="CUIT" HeaderText="CUIT" />
            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
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
