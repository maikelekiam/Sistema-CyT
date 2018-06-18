<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarProyectosCofecyt.aspx.cs" Inherits="Sistema_CyT.ListarProyectosCofecyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Proyectos de COFECyT</h3>
                <asp:Label ID="lblFondo" Font-Bold="true" runat="server" CssClass="col-md-2 control-label"> </asp:Label>
            </div>
            <%--<div class="form-group">
                <br />
                <div class="col-md-10 col-md-offset-1">
                    <asp:Button runat="server" ID="btnDetem" Text="DETEM" CssClass="boton_naranja" />
                    <asp:Button runat="server" ID="btnPfip" Text="PFIP" CssClass="boton_azul" />
                    <asp:Button runat="server" ID="btnAsetur" Text="ASETUR" CssClass="boton_verde" />
                    <asp:Button runat="server" ID="btnPfipEspro" Text="PFIP ESPRO" CssClass="boton_rojo" />
                </div>
            </div>--%>

            <!-- LISTA CON LAS CONVOCATORIAS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 control-label"></asp:Label>
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
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlConvocatoria_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--                <asp:Button runat="server" ID="btnTodos" Text="Filtrar TODOS" CssClass="btn boton_verde" OnClick="btnTodos_Click" />--%>
            </div>

            <!--GRILLA -->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
                    <asp:GridView ID="dgvProyectos" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both" EmptyDataText="No existen proyectos para esta Convocatoria" ShowHeaderWhenEmpty="true"
                        OnSelectedIndexChanging="dgvProyectos_SelectedIndexChanging"
                        OnRowDeleting="dgvProyectos_RowDeleting">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idProyectoCofecyt" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="COD INT" DataField="CodigoInterno" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                            
                            <asp:BoundField HeaderText="Titulo" DataField="titulo" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />

                            <asp:TemplateField HeaderText="Estado" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="120">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoEstadoCofecyt.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:ButtonField HeaderText="Actuaciones" CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-list" HeaderStyle-Width="50" />
                            <asp:ButtonField HeaderText="Detalles" CommandName="delete" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-search" HeaderStyle-Width="50" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
