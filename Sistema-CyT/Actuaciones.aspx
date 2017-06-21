<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actuaciones.aspx.cs" Inherits="Sistema_CyT.Actuaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="PanelProyecto" CssClass="panel panel-success" runat="server">
            <div class="panel-heading">
                <h3>Proyecto</h3>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
            </div>
        </asp:Panel>

        <asp:Label ID="label2" runat="server" Text="AGREGAR ACTUACION" CssClass="col-md-2 control-label"></asp:Label>


    </div>
</asp:Content>
