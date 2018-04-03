<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarPersona.aspx.cs" Inherits="Sistema_CyT.MostrarPersona" %>

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
            <!-- APELLIDO -->
            <div class="form-group">
                <asp:Label ID="lblApellido" runat="server" Text="APELLIDO" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtApellido" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- TELEFONO -->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtTelefono" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- CORREO ELECTRONICO -->
            <div class="form-group">
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtCorreoElectronico" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- TIPO DOCUMENTO -->
            <div class="form-group">
                <asp:Label ID="lblTipoDocumento" runat="server" Text="TIPO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtTipoDocumento" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- DOCUMENTO -->
            <div class="form-group">
                <asp:Label ID="lblDocumento" runat="server" Text="DOCUMENTO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtDocumento" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- DOMICILIO -->
            <div class="form-group">
                <asp:Label ID="lblDomicilio" runat="server" Text="DOMICILIO" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtDomicilio" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- LOCALIDAD -->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="LOCALIDAD" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtLocalidad" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- OBSERVACIONES -->
            <div class="form-group">
                <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtObservaciones" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
