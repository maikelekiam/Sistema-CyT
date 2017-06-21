<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actuaciones.aspx.cs" Inherits="Sistema_CyT.Actuaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="PanelProyecto" CssClass="panel panel-success" runat="server">
            <div class="panel-heading">
                <br />
                <asp:Label ID="lblProyecto" Style="text-align: left; font-size: large;" Font-Bold="true" runat="server" CssClass="col-md-12 control-label"></asp:Label>
                <br />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelActuacion" CssClass="panel" runat="server">
            <!-- BOTON GUARDAR -->
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Button ID="btnAgregarActuacion" runat="server" Text="Agregar Actuacion" CssClass="btn btn-info form-control" OnClick="btnAgregarActuacion_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelNuevaActuacion" CssClass="panel panel-success" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Hola"></asp:Label>

        </asp:Panel>



    </div>
</asp:Content>
