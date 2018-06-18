<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarFondo.aspx.cs" Inherits="Sistema_CyT.MostrarFondo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" id="nombreDiv">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Informacion</h3>
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
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 lblalider"> </asp:Label>
                <asp:Label ID="txtTelefono" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- DIRECCION -->
            <div class="form-group">
                <asp:Label ID="lblDireccion" runat="server" Text="DIRECCION" CssClass="col-md-2 lblalider"> </asp:Label>
                <asp:Label ID="txtDireccion" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!-- CONTACTO -->
            <div class="form-group">
                <asp:Label ID="lblContacto" runat="server" Text="CONTACTO" CssClass="col-md-2 lblalider"> </asp:Label>
                <asp:Label ID="txtContacto" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
        </asp:Panel>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Imprimir" CssClass="boton_azul" OnClientClick="printDiv('nombreDiv')" />
    



    <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
        <br />
        <div class="panel-heading">
            <h3>Lista de Convocatorias</h3>
        </div>
        <div class="form-group">
            <br />
            <div class="col-md-12">
                <asp:GridView ID="dgvConvocatoria" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" BorderWidth="2px"
                    EmptyDataText="No existen Convocatorias para este Fondo" ShowHeaderWhenEmpty="true"
                    GridLines="Both">
                    <Columns>
                        <asp:BoundField HeaderText="AÑO" DataField="anio" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderText="NOMBRE" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="500" />
                        <asp:BoundField HeaderText="APERTURA" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaApertura" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="250" />
                        <asp:BoundField HeaderText="CIERRE" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaCierre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="250" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>





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
