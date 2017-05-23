<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaConvocatoria.aspx.cs" Inherits="Sistema_CyT.AltaConvocatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" CssClass="panel panel-success" runat="server">
        <div class="panel-heading">
            <h3>Formulario de ALTA Convocatoria</h3>
        </div>
        <!--NOMBRE-->
        <br />
        <div class="form-group">
            <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-8">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
            </div>
        </div>
        <!--DESCRIPCION-->
        <div class="form-group">
            <asp:Label ID="lblDescripcion" runat="server" Text="DESCRIPCION" CssClass="col-md-2 control-label"> </asp:Label>
            <div class="col-md-8">
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
            </div>
        </div>
        <!--OBJETIVO-->
        <div class="form-group">
            <asp:Label ID="lblObjetivo" runat="server" Text="OBJETIVO" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-8">
                <asp:TextBox ID="txtObjetivo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
            </div>
        </div>
        <!--AÑO y FONDO-->
        <div class="form-group">
            <asp:Label ID="lblAnio" runat="server" Text="AÑO" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="txtAnio" Width="150" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
            </div>
            <asp:Label ID="lblFondo" runat="server" Text="FONDO" CssClass="col-md-2 control-label"> </asp:Label>
            <div class="col-md-3 ">
                <asp:DropDownList ID="ddlFondo" runat="server"
                    BackColor="WhiteSmoke"
                    ForeColor="#000066"
                    Font-Bold="false"
                    CssClass="selectpicker form-control show-tick"
                    DataTextField="nombre"
                    AutoPostBack="false">
                    <asp:ListItem Value="-1">&lt;Seleccione Fondo&gt;</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <!--TIPO y MODALIDAD-->
        <div class="form-group">
            <asp:Label ID="lblTipoFinanciamiento" runat="server" Text="TIPO FINANCIAMIENTO" CssClass="col-md-2 control-label"> </asp:Label>
            <div class="col-md-3 ">
                <asp:DropDownList ID="ddlTipoFinanciamiento" runat="server"
                    Width="100%"
                    BackColor="WhiteSmoke"
                    ForeColor="#000066"
                    Font-Bold="false"
                    CssClass="selectpicker form-control show-tick"
                    DataTextField="nombre">
                    <asp:ListItem Value="-1">&lt;Seleccione Tipo Financiamiento&gt;</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Label ID="lblModalidad" runat="server" Text="MODALIDAD" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3 ">
                <asp:DropDownList ID="ddlModalidad" runat="server"
                    Width="100%"
                    BackColor="WhiteSmoke"
                    ForeColor="#000066"
                    Font-Bold="false"
                    CssClass="selectpicker form-control show-tick"
                    DataTextField="nombre">
                    <asp:ListItem Value="-1">&lt;Seleccione Modalidad&gt;</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblFechaApertura" runat="server" Text="FECHA APERTURA" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
                <div class="input-group date"
                    data-provide="datepicker"
                    data-date-format="dd/mm/yyyy"
                    data-date-autoclose="true"
                    data-date-today-btn="true"
                    data-date-clear-btn="true"
                    data-date-today-highlight="true">
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaApertura"></asp:TextBox>
                    <div class="input-group-addon">
                        <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>
            </div>
            <asp:Label ID="lblFechaCierre" runat="server" Text="FECHA CIERRE" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
                <div class="input-group date"
                    data-provide="datepicker"
                    data-date-format="dd/mm/yyyy"
                    data-date-autoclose="true"
                    data-date-today-btn="true"
                    data-date-clear-btn="true"
                    data-date-today-highlight="true">
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaCierre"></asp:TextBox>
                    <div class="input-group-addon">
                        <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAbierta" runat="server" Text="ESTA ABIERTA ?" CssClass="col-md-2 control-label "></asp:Label>
            <div class="col-md-1">
                <asp:CheckBox ID="chkAbierta" runat="server" CssClass="form-control" BorderStyle="None" />
            </div>
        </div>








    </asp:Panel>
</asp:Content>
