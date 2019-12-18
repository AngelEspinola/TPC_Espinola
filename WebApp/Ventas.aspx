<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebApp.Ventas" %>

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
    </style>
    <div style="text-align:center">

        <table class="table" style="text-align:center">
                <thead class="thead-light">
                <tr>
                    <th colspan="3" style="font-size:x-large" >
                        <label style="margin:0px 15px 10px 15px">VENTAS</label>
                    </th>
                </tr>
        </table>
    </div>
    <div style="text-align:center;margin:0px 20px 0px 20px">
        <asp:GridView CssClass="table"  ID="dgvVentas" runat="server" AutoGenerateColumns="false">
            <Columns>    
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Cliente.ID" HeaderText="ID Cliente" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataFormatString="{0:C}" DataField="Total" HeaderText="Total" />
                <asp:TemplateField>
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
            <asp:Button ID="btnclose" runat="server" Text="Close" OnClick="btnclose_Click" />
        </div>
    </asp:Panel>

    <asp:Button ID="btnDummy" runat="server" Style="display: none;" />
        <asp:ScriptManager   ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager >
        <cc1:modalpopupextender  ID="GridViewDetails" runat="server" TargetControlID="btnDummy"
            PopupControlID="pnlGridViewDetails" BackgroundCssClass="modalBackground" />

</asp:Content>
