<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarProyectos.aspx.cs" Inherits="Sistema_CyT.ListarProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-warning" runat="server">
            <div class="panel-heading">
                <h3>Lista de PROYECTOS</h3>
            </div>
            <!-- LISTA CON LOS FONDOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblFondoChoice" Font-Bold="true" runat="server" Text="&lt Filtro Fondo &gt" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlFondoChoice" runat="server"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="True"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlFondoChoice_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Fondo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblConvocatoria" Font-Bold="true" runat="server" Text="&lt Filtro Convocatoria &gt" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlConvocatoria" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Width="100%"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="true"
                        AppendDataBoundItems="false"
                        OnSelectedIndexChanged="ddlConvocatoria_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblEstado" runat="server" Font-Bold="true" Text="&lt Filtro Estado &gt" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlEstado" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Estado&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" CssClass="btn btn-success" OnClick="btnFiltrar_Click" />
                <asp:Button runat="server" ID="btnTodos" Text="TODOS" CssClass="btn btn-primary" OnClick="btnTodos_Click" />
            </div>
            <div class="form-group">
                <br />
                <div class="col-md-12">
                    <asp:GridView ID="dgvProyectos" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both"
                        OnSelectedIndexChanged="dgvProyectos_SelectedIndexChanged">
                        <Columns>
<%--                            <asp:BoundField HeaderText="ID" DataField="idProyecto" ItemStyle-HorizontalAlign="Left" />--%>
                            <asp:BoundField HeaderText="Expediente" DataField="numeroExpediente" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="150" />
                            <asp:BoundField HeaderText="Nombre del Proyecto" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="400" />
                            <asp:BoundField HeaderText="Localidad" DataField="localidad" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="200" />
                            <asp:BoundField HeaderText="Estado" DataField="tipoEstado" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="150" />
                            <asp:BoundField HeaderText="Año" DataField="anio" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="60" />
                            <asp:ButtonField Text="Detalles" CommandName="Select" ItemStyle-Width="60" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
