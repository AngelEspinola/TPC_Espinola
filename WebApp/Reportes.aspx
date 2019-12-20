<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="WebApp.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">

        <table class="table" style="text-align:center">
                <thead class="thead-light">
                <tr>
                    <th colspan="3" style="font-size:x-large" >
                        <label style="margin:0px 15px 10px 15px">REPORTES</label>
                    </th>
                </tr>
        </table>
    </div>
     <div style ="text-align:center">
        <div style="margin-top:20px">
            <asp:Button Text="Compras" CssClass="btn btn-secondary btn-lg" onclick ="Compras_OnClick" runat="server" />
            <asp:Button Text="Ventas" CssClass="btn btn-secondary btn-lg" onclick ="Ventas_OnClick" runat="server" />
            <asp:Button Text="Stock" CssClass="btn btn-secondary btn-lg" onclick ="Stock_OnClick" runat="server" />
        </div>
         <div style="margin-top:10px">
        <img  style="margin:20px 0px 15px 0px" src="/img/pie-chart-5.png" alt="Logo UTN" />
         </div>
    </div>
</asp:Content>
