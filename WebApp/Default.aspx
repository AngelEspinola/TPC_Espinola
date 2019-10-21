<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
      .boton-imagen image :hover{
        transform: scale(1.5);
      }
        .boton-imagen image {
         height:10px;
         width:10px:
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="boton-imagen"></div>
    <h1>Titulo pagina Default</h1>
    <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text" />
</asp:Content>
