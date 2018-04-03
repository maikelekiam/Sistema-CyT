<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarFondo.aspx.cs" Inherits="Sistema_CyT.MostrarFondo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h4>Informacion</h4>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtNombre" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="DESCRIPCION" CssClass="col-md-2 lblalider"> </asp:Label>
                <asp:Label ID="txtDescripcion" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblOrigen" runat="server" Text="ORIGEN" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtOrigen" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- TELEFONO -->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtTelefono" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- DIRECCION -->
            <div class="form-group">
                <asp:Label ID="lblDireccion" runat="server" Text="DIRECCION" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtDireccion" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- CONTACTO -->
            <div class="form-group">
                <asp:Label ID="lblContacto" runat="server" Text="CONTACTO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtContacto" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
