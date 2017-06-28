<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarConvocatoria.aspx.cs" Inherits="Sistema_CyT.MostrarConvocatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="Panel1" CssClass="panel panel-warning" runat="server">
            <div class="panel-heading">
                <h3>Datos de la CONVOCATORIA</h3>
            </div>
            <br />
            <!--NOMBRE-->
            <br />
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
            <!--FECHA DE APERTURA-->
            <div class="form-group">
                <asp:Label ID="lblFechaApertura" runat="server" Text="FECHA DE APERTURA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtFechaApertura" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--FECHA DE CIERRE-->
            <div class="form-group">
                <asp:Label ID="lblFechaCierre" runat="server" Text="FECHA DE CIERRE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtFechaCierre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
             <!--ABIERTA-->
            <div class="form-group">
                <asp:Label ID="lblAbierta" runat="server" Text="ESTADO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtAbierta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
