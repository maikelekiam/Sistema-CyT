<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaProyecto.aspx.cs" Inherits="Sistema_CyT.AltaProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" runat="server">
            <div class="panel-heading">
                <h3>Formulario de ALTA Proyecto</h3>
            </div>
            <!--NOMBRE-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                </div>
            </div>
            <!--EXPEDIENTE-->
            <div class="form-group">
                <asp:Label ID="lblNumeroExp" runat="server" Text="EXPEDIENTE" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNumeroExp" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--CONVOCATORIA-->
            <div class="form-group">
                <asp:Label ID="lblConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10 ">
                    <asp:DropDownList ID="ddlConvocatoria" runat="server"
                        Width="800"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione una Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--MONTO SOLICITADO-->
            <div class="form-group">
                <asp:Label ID="lblMontoSolicitado" runat="server" Text="MONTO SOLICITADO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtMontoSolicitado" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO CONTRAPARTE-->
            <div class="form-group">
                <asp:Label ID="lblMontoContraparte" runat="server" Text="MONTO CONTRAPARTE" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtMontoContraparte" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO TOTAL-->
            <div class="form-group">
                <asp:Label ID="lblMontoTotal" runat="server" Text="MONTO TOTAL" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtMontoTotal" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--CONTACTO-->
            <div class="form-group">
                <asp:Label ID="lblContacto" runat="server" Text="CONTACTO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlContacto" runat="server"
                        Width="400"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--EMPRESA-->
            <div class="form-group">
                <asp:Label ID="lblEmpresa" runat="server" Text="EMPRESA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlEmpresa" runat="server"
                        Width="400"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Empresa&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--LOCALIDAD-->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="LOCALIDAD" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlLocalidad" runat="server"
                        Width="400"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Localidad&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>


            <!--BOTON GUARDAR PROYECTO  -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <br />
                    <asp:Button ID="btnGuardarProyecto" runat="server" Text="Guardar Proyecto" CssClass="btn btn-success form-control" OnClick="btnGuardarProyecto_Click" />
                </div>
            </div>











        </asp:Panel>
    </div>
</asp:Content>
