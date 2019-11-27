﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApp.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;margin:5px 0px 15px 0px">
    <h1>Productos</h1>
        <asp:Button Text="Nuevo" CssClass="btn-dark" onclick="Unnamed1_Click" runat="server" />
    </div>

<%--    <asp:TextBox runat="server" AutoPostBack="true" Id="txtNumeroPokemon" OnTextChanged="txtNumeroPokemon_TextChanged" />--%>
    <%--<asp:DropDownList runat="server" ID="cboPokemons" />--%>

    <div class="card-columns" style="margin-left: 25%; margin-right: 10px;">
         <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="card">
                    <img src="<%#Eval("URLImagen") %>" class="card-img-top" alt="...">
                    <div class="card-body" style="text-align:center">
                        <h5 class="card-title"><%#Eval("Titulo")%></h5>
                        <p class="card-text"><%#Eval("Descripcion")%></p>
                        <p class="card-text"><%#Eval("ID")%></p>
                    </div>
                    <%--<a class="btn-dark" style="resize:both" href="NuevoProducto.aspx?idpkm=<%#Eval("ID")%>">Modificar</a>--%>
                    <div style="text-align:center; margin-bottom:20px; margin-left:10px; margin-right:10px">
                        <asp:Button Text="Modificar" CssClass="btn-dark" OnClick ="btnModificar_OnClick" CommandArgument='<%#Eval("ID")%>' CommandName="IDProducto" runat="server" />
                        <asp:Button ID="btnEliminar" CssClass="btn-dark" Text="Eliminar" CommandArgument='<%#Eval("ID")%>' CommandName="IDProducto" runat="server" OnClick="btnEliminar_OnClick" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


      <%--  <% foreach (var item in listaProductos)
            { %>
        <div class="card">
            <img src="<% = item.URLImagen %>" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title"><% = item.Titulo %></h5>
                <p class="card-text"><% = item.Descripcion %></p>
            </div>
            <asp:Button class ="btn btn-dark" CommandArgument="<% = item.ID.ToString()%>" CommandName="ProductoID" OnClick="btnEliminar_OnClick" Text="Eliminar" runat="server" />
            <a class="btn btn-dark" href="NuevoProducto.aspx?idpkm=<% = item.ID.ToString() %>">Modificar</a>
            <%--<a class="btn btn-primary" CommandArgument='<%#Eval("product.ProductId")%>' CommandName="ThisBtnClick" onClick="btnEliminar_OnClick">Eliminar</a>
        </div>
        <% } %>--%>
    </div>
</asp:Content>
