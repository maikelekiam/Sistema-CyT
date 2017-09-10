<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarConvocatoria.aspx.cs" Inherits="Sistema_CyT.MostrarConvocatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="panelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Datos de la CONVOCATORIA</h3>
            </div>
            <div class="panel-body">
                <!--NOMBRE-->
                <div class="form-group">
                    <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                    </div>
                </div>
                <!--AÑO-->
                <div class="form-group">
                    <asp:Label ID="lblAnio" runat="server" Text="AÑO" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--FONDO-->
                <div class="form-group">
                    <asp:Label ID="lblFonfo" runat="server" Text="FONDO" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtFondo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--TIPO DE CONVOCATORIA-->
                <div class="form-group">
                    <asp:Label ID="lblTipoConvocatoria" runat="server" Text="TIPO DE CONVOCATORIA" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtTipoConvocatoria" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--TIPO DE FINANCIAMIENTO-->
                <div class="form-group">
                    <asp:Label ID="lblTipoFinanciamiento" runat="server" Text="TIPO DE FINANCIAMIENTO" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtTipoFinanciamiento" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--FECHA DE APERTURA y FECHA DE CIERRE-->
                <div class="form-group">
                    <asp:Label ID="lblFechaApertura" runat="server" Text="FECHA DE APERTURA" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtFechaApertura" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblFechaCierre" runat="server" Text="FECHA DE CIERRE" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtFechaCierre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--ABIERTA-->
                <div class="form-group">
                    <asp:Label ID="lblAbierta" runat="server" Text="ESTADO" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtAbierta" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="panelInferior" CssClass="panel panel-default" runat="server">
            <!--LISTA DE MODALIDADES CARGADAS-->
            <div class="panel-heading">
                <h3>Modalidades de la Convocatoria</h3>
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
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Objetivo" DataField="objetivo" ItemStyle-HorizontalAlign="Left" />
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
