<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEtapa.aspx.cs" Inherits="Sistema_CyT.EditarEtapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>Formulario EDITAR Etapa</h3>
            </div>
            <!--NOMBRE-->
            <div class="form-group">
                <br />
                <asp:Label ID="lblNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--ESTADO DE LA ETAPA-->
            <div class="form-group">
                <asp:Label ID="lblTipoEstadoEtapa" runat="server" Text="ESTADO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlTipoEstadoEtapa" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Estado&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--FECHA DE INICIO-->
            <div class="form-group">
                <asp:Label ID="lblFechaInicioModal" runat="server" Text="FECHA INICIO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaInicioModal"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <!--FECHA FINAL-->
            <div class="form-group">
                <asp:Label ID="lblFechaFinalModal" runat="server" Text="FECHA FINAL" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaFinalModal"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- RENDICION -->
            <div class="form-group">
                <asp:Label ID="lblRendicion" runat="server" Text="PRESENTO RENDICION ?" CssClass="col-md-3 control-label "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkRendicion" runat="server" CssClass="control-label" BorderStyle="None" />
                </div>
            </div>
            <!-- INFORME -->
            <div class="form-group">
                <asp:Label ID="lblInforme" runat="server" Text="PRESENTO INFORME ?" CssClass="col-md-3 control-label "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkInforme" runat="server" CssClass="control-label" BorderStyle="None" />
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnModalSalir" Text="SALIR" class="btn btn-danger" OnClick="btnModalSalir_Click" />
                <asp:Button runat="server" ID="btnModalActualizar" Text="ACTUALIZAR" CssClass="btn btn-success" OnClick="btnModalActualizar_Click"/>
            </div>






        </asp:Panel>
    </div>
</asp:Content>
