<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarUdtUvt.aspx.cs" Inherits="Sistema_CyT.MostrarUdtUvt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" id="nombreDiv">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Informacion de la UDT / UVT</h3>
            </div>
            <!-- TIPO -->
            <br />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="TIPO" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtTipo" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- NOMBRE -->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtNombre" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- REFERENTE TECNICO -->
            <br />
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="REFERENTE TECNICO" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtReferenteTecnico" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- DIRECTOR / GERENTE -->
            <br />
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="DIRECTOR / GERENTE" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtDirectorGerente" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- TELEFONO -->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 lblalider"> </asp:Label>
                <asp:Label ID="txtTelefono" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- CORREO ELECTRONICO -->
            <div class="form-group">
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-2 lblalider"> </asp:Label>
                <asp:Label ID="txtCorreoElectronico" runat="server" CssClass="col-md-6 lblaliizq text-lowercase" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- DOMICILIO -->
            <div class="form-group">
                <asp:Label ID="lblDomicilio" runat="server" Text="DOMICILIO" CssClass="col-md-2   lblalider"> </asp:Label>
                <asp:Label ID="txtDomicilio" runat="server" Font-Bold="true" CssClass="col-md-6   lblalider"> </asp:Label>
            </div>
            <!-- LOCALIDAD -->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="LOCALIDAD" CssClass="col-md-2   lblalider"> </asp:Label>
                <asp:Label ID="txtLocalidad" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
            <!-- OBSERVACIONES -->
            <div class="form-group">
                <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2   lblalider"> </asp:Label>
                <asp:Label ID="txtObservaciones" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label><br />
            </div>
        </asp:Panel>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Imprimir" CssClass="boton_azul" OnClientClick="printDiv('nombreDiv')" />
    <script>
        function printDiv(nombreDiv) {

            //var c = document.getElementById('logo').innerHTML;
            var contenido = document.getElementById(nombreDiv).innerHTML;
            var contenidoOriginal = document.body.innerHTML;

            document.body.innerHTML = contenido;

            window.print();

            document.body.innerHTML = contenidoOriginal;
        }
    </script>
    <br />
    <br />
    <br />
    <br />
</asp:Content>


