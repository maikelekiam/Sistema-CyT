<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarProyecto.aspx.cs" Inherits="Sistema_CyT.MostrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyecto" CssClass="panel panel-success" runat="server">
            <div class="panel-heading">
                <br />
                <asp:Label ID="lblNombreProyecto" Style="text-align: left; font-size: large;" Font-Bold="true" runat="server" CssClass="col-md-12 control-label"></asp:Label>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
