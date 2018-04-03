<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEmpresa.aspx.cs" Inherits="Sistema_CyT.EditarEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Formulario de ALTA Empresa</h3>
            </div>
            <!-- LISTA CON LAS EMPRESAS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblEmpresa" Font-Bold="true" runat="server" Text="&lt Seleccione Empresa &gt" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlEmpresas" runat="server"
                        BackColor="#ffff99"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="true"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlPersonas_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Empresa&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--NOMBRE-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--TELEFONO-->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--CORREO ELECTRONICO-->
            <div class="form-group">
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--DOMICILIO-->
            <div class="form-group">
                <asp:Label ID="lblDomicilio" runat="server" Text="DOMICILIO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--LOCALIDAD-->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="LOCALIDAD" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlLocalidad" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Localidad&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--OBSERVACIONES-->
            <div class="form-group">
                <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- BOTON ACTUALIZAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnActualizarEmpresa" runat="server" Text="Actualizar Empresa" Width="180" CssClass="btn boton_verde form-control" OnClick="btnActualizarEmpresa_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
