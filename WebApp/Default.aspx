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
        <div class="boton-imagen">
            <h1>Titulo pagina Default</h1>
            <a href="Clientes.aspx">
            <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text"  />
            </a>
            <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text" />
        </div>
        <div class="boton-imagen">
            <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text" />
            <img src="https://st2.depositphotos.com/1794440/7673/v/950/depositphotos_76733111-stock-illustration-button-clients.jpg" alt="Alternate Text" />
        </div>
    </div>
</asp:Content>
