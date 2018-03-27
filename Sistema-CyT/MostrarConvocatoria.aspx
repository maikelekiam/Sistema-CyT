<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarConvocatoria.aspx.cs" Inherits="Sistema_CyT.MostrarConvocatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="panelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h4>Datos de la CONVOCATORIA</h4>
            </div>
            <br />
            <!--NOMBRE-->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtNombre" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!--AÑO-->
            <div class="form-group">
                <asp:Label ID="lblAnio" runat="server" Text="AÑO" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtAnio" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!--FONDO-->
            <div class="form-group">
                <asp:Label ID="lblFonfo" runat="server" Text="FONDO" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtFondo" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!--TIPO DE CONVOCATORIA y TIPO DE FINANCIAMIENTO-->
            <div class="form-group">
                <asp:Label ID="lblTipoConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtTipoConvocatoria" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTipoFinanciamiento" runat="server" Text="TIPO" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtTipoFinanciamiento" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!--FECHA DE APERTURA y FECHA DE CIERRE-->
            <div class="form-group">
                <asp:Label ID="lblFechaApertura" runat="server" Text="FECHA DE APERTURA" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtFechaApertura" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblFechaCierre" runat="server" Text="FECHA DE CIERRE" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtFechaCierre" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
            <!--ABIERTA-->
            <div class="form-group">
                <asp:Label ID="lblAbierta" runat="server" Text="ESTADO" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtAbierta" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true"></asp:Label>
            </div>
        </asp:Panel>


        <asp:Panel ID="panelInferior" CssClass="panel panel-default" runat="server">
            <!--LISTA DE MODALIDADES CARGADAS-->
            <div class="panel-heading">
                <h4>Modalidades de la Convocatoria</h4>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:GridView ID="dgvModalidades" runat="server" AutoGenerateColumns="false"
                            DataKeyNames="idModalidad"
                            CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen modalidades cargadas" ShowHeaderWhenEmpty="true">
                            <Columns>
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdM" DataField="idModalidad" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Justify" HeaderStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Objetivo" DataField="objetivo" ItemStyle-HorizontalAlign="Justify" />
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Monto Maximo" DataField="montoMaximoProyecto" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="% Fin" DataField="porcentajeFinanciamiento" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Plazo Ejecucion" DataField="plazoEjecucion" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdC" DataField="idConvocatoria" ItemStyle-HorizontalAlign="Center" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
