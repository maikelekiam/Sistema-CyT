<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarEmpresa.aspx.cs" Inherits="Sistema_CyT.MostrarEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h4>Informacion</h4>
            </div>
            <!-- NOMBRE -->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtNombre" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- TELEFONO -->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtTelefono" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- CORREO ELECTRONICO -->
            <div class="form-group">
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-2 col-xs-6 lblalider text-lowercase"> </asp:Label>
                <asp:Label ID="txtCorreoElectronico" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- DOMICILIO -->
            <div class="form-group">
                <asp:Label ID="lblDomicilio" runat="server" Text="DOMICILIO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="lbl01" runat="server" Font-Bold="true" CssClass="col-md-6 col-xs-6 lblalider"> </asp:Label>
            </div>
            <!-- LOCALIDAD -->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="LOCALIDAD" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtLocalidad" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- CONTACTO -->
            <div class="form-group">
                <asp:Label ID="lblContacto" runat="server" Text="CONTACTO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtContacto" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- OBSERVACIONES -->
            <div class="form-group">
                <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtObservaciones" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
    </asp:Panel>
    </div>
</asp:Content>
