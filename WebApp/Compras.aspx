<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebApp.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="text-align:center;margin-bottom:15px">
        <h1>COMPRAS</h1>
        <asp:Button Text="Nueva" onclick="btnNuevaCompra_OnClick" runat="server" />
    </div>
</asp:Content>
