<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .boton-imagen img:hover{
          transform: scale(1.1);
        }
        .boton-imagen img {
            height:100px;
            width:100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style ="text-align:center">
        <%--<div class="boton-imagen">
            <a href="Clientes.aspx">
            <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text"  />
            </a>
            <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text" />
        </div>--%>
        <div style="margin-top:20px">
            <asp:Button Text="Clientes" CssClass ="btn-dark" onclick ="Clientes_OnClick" runat="server" />
            <asp:Button Text="Productos" CssClass="btn-dark" onclick ="Productos_OnClick" runat="server" />
            <asp:Button Text="Proveedores" CssClass="btn-dark" onclick ="Proveedores_OnClick" runat="server" />
        </div>
        <div style="margin-top:20px">
            <asp:Button Text="Ventas" CssClass="btn-dark" onclick ="Ventas_OnClick" runat="server" />
            <asp:Button Text="Compras" CssClass="btn-dark" onclick ="Compras_OnClick" runat="server" />
        </div>
        <div class="boton-imagen" style="margin-top:20px">
            <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text" />
            <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text" />
        </div>
    </div>
</asp:Content>
