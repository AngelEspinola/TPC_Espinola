<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="WebApp.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
        .pnlBackGround
        {
            position: fixed;
            top: 10%;
            left: 10px;
            width: auto;
            height: auto;
            text-align: center;
            background-color: White;
            border: solid 3px black;
        }
        .search_categories{
          font-size: 13px;
          padding: 5px 4px 5px 7px;
          background: #fff;
          border: 1px solid #ccc;
          border-radius: 9px;
          overflow: hidden;
          position: relative;
          margin-right: 10px
        }

        .search_categories .select{
          width: 120%;
          background:url('arrow.png') no-repeat;
          background-position:80% center;
        }

        .search_categories .select select{
          background: transparent;
          line-height: 1;
          border: 0;
          padding: 0;
          border-radius: 0;
          width: 120%;
          position: relative;
          z-index: 10;
          font-size: 1em;
        }
    </style>
    <div style="text-align:center">

        <table class="table" style="text-align:center">
                <thead class="thead-light">
                <tr>
                    <th colspan="4" style="font-size:x-large" >
                        <label style="margin:0px 15px 10px 15px">STOCK</label>
                    </th>
                </tr>
                <tr>
                    <td colspan="1" style="margin-top:10px">
                        <label style="font-weight:bold;margin-left:15px">Producto</label>
                        <asp:TextBox Width="100px" BackColor= "WhiteSmoke" runat="server" ID="txtProducto" />
                    </td>
                    <td colspan="1" style="margin-top:10px">
                        <label style="font-weight:bold;margin-right:8px"">Stock Minimo</label>
                        <asp:DropDownList CssClass="search_categories" BackColor= "WhiteSmoke" runat="server" ClientIDMode="Static" ID="ddlStockMinimoFiltro" />
                        <asp:TextBox Width="20%" BackColor= "WhiteSmoke" runat="server" ClientIDMode="Static" ID="txtStockMinimo" />
                    </td>
                    <td colspan="1" style="margin-top:10px">
                        <label style="font-weight:bold;margin-right:8px">Stock</label>
                        <asp:DropDownList CssClass="search_categories" BackColor= "WhiteSmoke" runat="server" ClientIDMode="Static" ID="ddlStockActualFiltro" />
                        <asp:TextBox Width="20%" BackColor= "WhiteSmoke" runat="server" ClientIDMode="Static" ID="txtStockActual" />
                    </td>
                    <td colspan="1" style="margin-top:10px">
                        <asp:CheckBox runat="server" ID="cbxEscasos" />
                        <label style="font-weight:bold;margin-right:15px">Inferior a stock minimo</label>
                    </td>
                    
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1" style="text-align:right">
                    <asp:Button Text="Filtrar" style="width:300px;margin-right:40px"  CssClass ="btn btn-secondary" OnClick="FiltrarGridProductos" runat="server" />
                    </td>
                    <td colspan="1" style="text-align:left">
                    <asp:Button Text="Limpiar" style="width:300px"  CssClass ="btn btn-secondary" OnClick="LimpiarFiltro" runat="server" />
                    </td>
                    <td colspan="1"></td>
                </tr>
        </table>
    </div>
    <div style="text-align:center;margin:0px 40px 0px 40px">
        <asp:GridView CssClass="table"  ID="dgvStock" runat="server" AutoGenerateColumns="false">
            <Columns>    
                <asp:BoundField DataField="ID" ControlStyle-Width="10%" HeaderText="ID" />
                <asp:BoundField DataField="Titulo" HeaderText="Producto" />
                <asp:BoundField DataField="StockMinimo" HeaderText="Stock Minimo" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
            </Columns>  
        </asp:GridView>
    </div>

</asp:Content>

