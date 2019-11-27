<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="WebApp.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;margin-bottom:15px">
        <h1>PROVEEDORES</h1>
        <asp:Button Text="Nuevo" CssClass="btn-dark" onclick="NuevoProveedor_OnClick" runat="server" />
    </div>
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
            
             <asp:TemplateField>
                    <ItemTemplate>
                    <asp:Button Text="Editar" CssClass="btn-dark" OnClick ="btnModificar_OnClick" CommandArgument='<%#Eval("ID")%>' CommandName="IDProveedor" runat="server" />
                    </ItemTemplate>
             </asp:TemplateField>
            <asp:TemplateField>
                    <ItemTemplate>
                    <asp:Button Text="Eliminar" CssClass="btn-dark" OnClick ="btnEliminar_OnClick" CommandArgument='<%#Eval("ID")%>' CommandName="IDProveedor" runat="server" />
                    </ItemTemplate>
             </asp:TemplateField>
        </Columns>  
    </asp:GridView>
    
</asp:Content>
