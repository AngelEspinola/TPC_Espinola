<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebApp.Compras" %>
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
                    <th colspan="5" style="font-size:x-large" >
                        <label style="margin:0px 15px 10px 15px">VENTAS</label>
                    </th>
                </tr>
                <tr>
                    <td colspan="1" style="margin-top:10px">
                        <label style="font-weight:bold">CUIT</label>
                        <asp:TextBox Width="100px" BackColor= "WhiteSmoke" runat="server" ID="txtClienteDNI" />
                    </td>
                    <td colspan="1" style="margin-top:10px">
                        <label style="font-weight:bold;margin-right:8px"">Fecha</label>
                        <asp:DropDownList CssClass="search_categories" BackColor= "WhiteSmoke" runat="server" ClientIDMode="Static" ID="ddlFechaFiltro" />
                        <asp:TextBox TextMode="Date" Width="150px" BackColor= "WhiteSmoke" runat="server" ID="dtpFecha" />
                    </td>
                    <td colspan="1" style="margin-top:10px">
                        <label style="font-weight:bold;margin-right:8px">Total</label>
                        <asp:DropDownList CssClass="search_categories" BackColor= "WhiteSmoke" runat="server" ClientIDMode="Static" ID="ddlImporteFiltro" />
                        <asp:TextBox BackColor= "WhiteSmoke" runat="server" ClientIDMode="Static" ID="txtImporte" />
                    </td>
                    <td colspan="1" style="text-align:center">
                        <asp:Button Text="Filtrar" style="width:100px"  CssClass ="btn btn-secondary" OnClick="FiltrarGridProductos" runat="server" />
                    </td>
                    <td colspan="1" style="text-align:center">
                        <asp:Button Text="Limpiar" style="margin-right:10px;width:100px"  CssClass ="btn btn-secondary" OnClick="LimpiarFiltro" runat="server" />
                    </td>
                </tr>
        </table>
    </div>
    <div style="text-align:center;margin:0px 40px 0px 40px">
        <asp:GridView CssClass="table"  ID="dgvVentas" runat="server" AutoGenerateColumns="false">
            <Columns>    
                <asp:BoundField DataField="ID" ControlStyle-Width="10%" HeaderText="ID" />
                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" />
                <asp:BoundField DataField="Proveedor.CUIT" HeaderText="CUIT" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataFormatString="{0:C}" DataField="Total" HeaderText="Total" />
                <asp:TemplateField FooterStyle-Width="15%">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkViewDetails" CssClass="btn btn-secondary" runat="server" CommandArgument='<%# Eval("ID")%>'
                            OnClick="ViewDetails" Text="Detalle" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>  
        </asp:GridView>
    </div>

    <asp:Panel ID="pnlGridViewDetails" runat="server" Style="display: none;"
        CssClass="pnlBackGround">
        <%--Add other controls here--%>
        <div style="margin:10px 10px 10px 10px">
            <asp:GridView CssClass="table" ID="dgvDetalles" runat="server" AutoGenerateColumns="false">
            <Columns>    
                <asp:BoundField DataField="ID" HeaderText="ID Prod" />
                <asp:BoundField DataField="Producto.Titulo" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataFormatString="{0:C}" DataField="Precio" HeaderText="Precio Unitario" />
                <asp:BoundField DataFormatString="{0:C}" DataField="SubTotal" HeaderText="Sub Total" />
            </Columns>  
            </asp:GridView>
        </div>
        <div style="margin:0px 0px 10px 0px">
            <asp:Button ID="btnclose" CssClass="btn btn-primary" runat="server" Text="Close" OnClick="btnclose_Click" />
        </div>
    </asp:Panel>

    <asp:Button ID="btnDummy" runat="server" Style="display: none;" />
        <asp:ScriptManager   ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager >
        <cc1:modalpopupextender  ID="GridViewDetails" runat="server" TargetControlID="btnDummy"
            PopupControlID="pnlGridViewDetails" BackgroundCssClass="modalBackground" />
</asp:Content>
