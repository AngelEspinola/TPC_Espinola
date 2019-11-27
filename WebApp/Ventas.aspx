<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebApp.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;margin-bottom:15px">
        <h1>VENTAS</h1>
        <asp:Button Text="Nueva" onclick="btnNuevaVenta_OnClick" runat="server" />
    </div>
    <asp:GridView CssClass="table" ID="dgvVentas" runat="server" AutoGenerateColumns="false">
        <Columns>    
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
            <asp:BoundField DataField="Detalle[0].Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Total" HeaderText="Total" />
        </Columns>  
    </asp:GridView>
</asp:Content>
