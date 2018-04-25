<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarActuacionProyectoCofecyt.aspx.cs" Inherits="Sistema_CyT.MostrarActuacionProyectoCofecyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <br />
            <div class="form-group">
                <asp:Label ID="blbl01" runat="server" Text="FECHA ACTUACION" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtFechaActuacion" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true" BorderStyle="Ridge" BorderWidth="1px"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl02" runat="server" Text="DETALLE" CssClass="col-md-2 lblalider"> </asp:Label>
                <asp:Label ID="txtDetalle" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true" BorderStyle="Ridge" BorderWidth="1px"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl03" runat="server" Text="PENDIENTE" CssClass="col-md-2 lblalider"></asp:Label>
                <asp:Label ID="txtPendiente" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true" BorderStyle="Ridge" BorderWidth="1px"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl04" runat="server" Text="RESPONSABLE" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtResponsable" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true" BorderStyle="Ridge" BorderWidth="1px"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl05" runat="server" Text="AGENTE" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtAgente" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true" BorderStyle="Ridge" BorderWidth="1px"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl06" runat="server" Text="FECHA LIMITE" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtFechaLimite" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true" BorderStyle="Ridge" BorderWidth="1px"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl07" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtObservaciones" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true" BorderStyle="Ridge" BorderWidth="1px"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl08" runat="server" Text="DOCUMENTACION ANEXADA" CssClass="col-md-2 col-xs-6 lblalider"> </asp:Label>
                <asp:Label ID="txtDocumentacionAnexada" runat="server" CssClass="col-md-6 lblaliizq" Font-Bold="true" BorderStyle="Ridge" BorderWidth="1px"></asp:Label>
            </div>
        </asp:Panel>
        <!-- BOTON GUARDAR -->
        <div class="form-group">
            <div class="col-md-2 col-md-offset-2">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="boton_verde" OnClick="btnVolver_Click" />
            </div>
        </div>

    </div>
</asp:Content>
