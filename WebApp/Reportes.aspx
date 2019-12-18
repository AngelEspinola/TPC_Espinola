<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="WebApp.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style ="text-align:center">
        <div style="margin-top:20px">
            <asp:Button Text="Compras" CssClass="btn btn-secondary btn-lg" onclick ="Compras_OnClick" runat="server" />
            <asp:Button Text="Ventas" CssClass="btn btn-secondary btn-lg" onclick ="Ventas_OnClick" runat="server" />
        </div>
    </div>
</asp:Content>
