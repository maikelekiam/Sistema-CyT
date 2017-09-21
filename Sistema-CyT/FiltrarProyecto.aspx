<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FiltrarProyecto.aspx.cs" Inherits="Sistema_CyT.FiltrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>Buscar PROYECTO</h3>
            </div>
            <!-- LISTA CON LOS FONDOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblFondo" Font-Bold="true" runat="server" Text="&lt Filtro Fondo &gt" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8 ">
                    <asp:DropDownList ID="ddlFondo" runat="server"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="True"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlFondo_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Fondo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- LISTA CON LAS CONVOCATORIAS EN LA BASE DE DATOS -->
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




            <%--<div class="form-group">
                <asp:Label ID="lblAnio" runat="server" Text="AÑO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlAnio" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        AutoPostBack="true"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Año&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>--%>


            <div class="form-group">
                <br />
                <div class="col-md-12">
                    <asp:GridView ID="dgvProyectos" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both"
                        OnSelectedIndexChanged="dgvProyectos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="Expediente" DataField="numeroExpediente" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="150" />
                            <asp:BoundField HeaderText="Nombre del Proyecto" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="400" />


                            <asp:BoundField HeaderText="Tipo" DataField="tipoProyecto" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="200" />

                            <%--<asp:BoundField HeaderText="Localidad" DataField="localidad" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="200" />--%>


                            <asp:BoundField HeaderText="Estado" DataField="tipoEstado" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="120" />
                            <asp:BoundField HeaderText="Año" DataField="anio" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="60" />

                            <asp:ButtonField Text="Actuaciones" CommandName="Select" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>








            <%--<div class="form-group">
                <div class="col-md-9 col-md-offset-1">
                    <asp:GridView ID="dgvProyectos" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both"
                        OnSelectedIndexChanged="dgvProyectos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idProyecto" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="300" />
                            <asp:TemplateField HeaderText="Convocatoria" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="300">
                                <ItemTemplate>
                                    <asp:Label ID="lblConvocatoria" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Convocatorium.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField Text="Actuaciones" CommandName="Select" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>--%>

            <%--<div class="form-group">
                <div class="col-md-9 col-md-offset-1">
                    <asp:GridView ID="dgvConvocatorias" runat="server" AutoGenerateColumns="true"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both">
                    </asp:GridView>
                </div>
            </div>--%>
        </asp:Panel>
    </div>
</asp:Content>
