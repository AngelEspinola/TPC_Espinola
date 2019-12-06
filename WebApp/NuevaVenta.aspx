<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="WebApp.NuevaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
         function validar() {
            var cantidad = $('#txtCantidad').val();
            
            if (!cantidad)
            {
                 alert('Debes ingresar una cantidad!');
                 return false;

             }
             if (isNaN(cantidad) || cantidad % 1 !== 0)
             {
                 alert('El campo "Cantidad" debe contener un numero entero!');
                 return false;
             }
            return true;
            }
    </script>
    
        <%--<div>
            <label>Cliente</label>
        </div>
        <div class="form-group">
            <asp:Button Text="Buscar" CssClass ="btn btn-secondary" runat="server" />
            <asp:TextBox runat="server" ID="txtCliente" />
            <asp:DropDownList ID="ddlClientes" runat="server">
                
            </asp:DropDownList>
        </div>
        <div>
            <label>Proveedor</label>
        </div>
        <div>
            <asp:Button Text="Buscar" CssClass ="btn btn-secondary" runat="server" />
            <asp:TextBox runat="server" ID="txtProducto"/>
            <asp:DropDownList ID="ddlProductos" runat="server"> </asp:DropDownList>
        
        </div>
        <div style="margin-top:20px">
            <label>Cantidad</label>
            <asp:TextBox runat="server" ID="txtCantidad" />
        </div>
    <div style="margin-top:15px">
        <asp:Button Text="Guardar" CssClass ="btn btn-secondary" OnClick="GuardarVenta" runat="server" />
    </div>
--%>




    <table class="table" style="text-align:center">
                <thead class="thead-light">
                <tr>
                    <th colspan="5">
                        <label style="margin:0px 15px 10px 15px">Cliente</label>
                        <asp:DropDownList  style="width:300px" ID="ddlClientes" AutoPostBack="true" OnSelectedIndexChanged="ddlClientes_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </th>
                </tr>
                </thead>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="1">
                        <label>Producto</label>
                        <asp:TextBox BackColor= "WhiteSmoke" runat="server" ID="txtProducto" />
                    </td>
                    <td colspan="1">
                        <label>Descripcion</label>
                        <asp:TextBox BackColor= "WhiteSmoke" runat="server" ID="txtDescripcion" />
                    </td>
                    <td colspan="1" style="text-align:center">
                        <asp:Button Text="Filtrar" style="margin-right:10px"  CssClass ="btn btn-secondary" OnClientClick="Filtrar" OnClick="FiltrarGridProductos" runat="server" />
                    </td>
                    <td colspan="1">
                        <label>Cantidad </label>
                        <asp:TextBox BackColor= "WhiteSmoke" runat="server" ClientIDMode="Static" ID="txtCantidad" />
                    </td>
                    <td colspan="1" style="text-align:center">
                        <asp:Button Text="Agregar Detalle" style="margin-right:10px"  CssClass ="btn btn-secondary" OnClientClick="return validar()" OnClick="AgregarDetalle" runat="server" />
                    </td>
                </tr>
                </table>
            <asp:GridView CssClass="table table-dark" ID="dgvProductos" runat="server" AutoGenerateColumns="false">
                        <Columns>  
                            <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSeleccion" runat="server" AutoPostBack="false"  Checked='false' />
                                    </ItemTemplate>
                              </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="true"/>
                            <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataFormatString="{0:C}" DataField="Precio" HeaderText="Precio" />
                        </Columns>  
            </asp:GridView>
            <div style="text-align:center;margin-bottom:20px">
                    <label>Importe Total:<%-- $<%=Session["totalDetalle"] != null? (float)Session["totalDetalle"] : 0%>--%></label>
                        <asp:TextBox ReadOnly="true" BackColor= "LightGray" runat="server" ID="txtTotal" />
                    <asp:Button Text="Guardar Venta" style="margin-left:10px" CssClass ="btn btn-secondary" OnClick="GuardarVenta" runat="server" />
            </div>
            
            <asp:GridView CssClass="table table-dark" ID="dgvDetalleVenta" runat="server" OnRowDeleting="RowDeleting" OnRowDeleted="RowDeleted" AutoGenerateDeleteButton="false" AutoGenerateColumns="false">
                        <Columns>    
                            <asp:BoundField DataField="Producto.ID" HeaderText="ID" Visible="true"/>
                            <asp:BoundField DataField="Producto.Titulo" HeaderText="Producto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataFormatString="{0:C}" DataField="Precio" HeaderText="Precio Unitario" />
                            <asp:BoundField DataFormatString="{0:C}" DataField="SubTotal" HeaderText="Sub Total" />
                            <asp:CommandField ButtonType="Image" ItemStyle-Height="10px"  DeleteImageUrl="~/img/x-button.svg.hi.png" ShowDeleteButton="True" />
                        </Columns>  
             </asp:GridView>

  
</asp:Content>
