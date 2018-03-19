<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarActividad.aspx.cs" Inherits="Sistema_CyT.AgregarActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--FECHA NACIMIENTO-->
    <div class="form-group">
        <asp:Label ID="lblFechaNacimiento" runat="server" Text="FECHA DE NACIMIENTO" CssClass="col-md-2 control-label"></asp:Label>
        <asp:DropDownList ID="ddlDia" runat="server"
            CssClass="selectpicker form-control show-tick"
            data-live-search="false"
            data-width="70">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlMes" runat="server"
            CssClass="selectpicker form-control show-tick"
            data-live-search="false"
            data-width="150">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlAnio" runat="server"
            CssClass="selectpicker form-control show-tick"
            data-live-search="false"
            data-width="100">
        </asp:DropDownList>
    </div>



</asp:Content>
