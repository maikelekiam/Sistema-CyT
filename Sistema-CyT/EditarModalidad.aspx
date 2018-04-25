<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarModalidad.aspx.cs" Inherits="Sistema_CyT.EditarModalidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h4>Formulario EDITAR Modalidad</h4>
            </div>
            <div class="form-group">
                <br />
                <asp:Label ID="lblNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-3 AlineadoDerecha"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDescripcionModal" runat="server" Text="DESCRIPCION" CssClass="col-md-3 AlineadoDerecha"> </asp:Label>
                <div class="col-md-8 ">
                    <asp:TextBox ID="txtDescripcionModal" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblObjetivoModal" runat="server" Text="OBJETIVO" CssClass="col-md-3 AlineadoDerecha"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtObjetivoModal" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--PLAZO DE EJECUCION-->
            <div class="form-group">
                <asp:Label ID="lblPlazoEjecucionModal" runat="server" Text="PLAZO EJECUCION" CssClass="col-md-3 AlineadoDerecha"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtPlazoEjecucionModal" runat="server" CssClass="form-control" placeholder="meses"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblMontoMaximoProyectoModal" runat="server" Text="MONTO MAXIMO POR PROYECTO" CssClass="col-md-3 AlineadoDerecha"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtMontoMaximoProyectoModal" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--PORCENTAJE DE FINANCIAMIENTO-->
            <div class="form-group">
                <asp:Label ID="lblPorcentajeFinanciamientoModal" runat="server" Text="% FINANCIAMIENTO" CssClass="col-md-3 AlineadoDerecha"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtPorcentajeFinanciamientoModal" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnModalModalidadSalir" Text="Salir" Width="150" CssClass="boton_rojo" OnClick="btnModalModalidadSalir_Click" />
                <asp:Button runat="server" ID="btnModalModalidadActualizar" Text="Actualizar" Width="150" CssClass="boton_verde" OnClick="btnModalModalidadActualizar_Click" />
            </div>






        </asp:Panel>
    </div>
</asp:Content>
