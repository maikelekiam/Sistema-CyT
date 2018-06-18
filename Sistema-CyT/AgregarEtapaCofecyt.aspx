<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEtapaCofecyt.aspx.cs" Inherits="Sistema_CyT.AgregarEtapaCofecyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3 id="lblPanelSuperiorTitulo" runat="server">Proyecto</h3>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelInformacionProyecto" CssClass="panel panel-default" runat="server">
            <div class="form-group">
                <br />
                <asp:Label ID="lblTipoEstadoEtapa" runat="server" Text="ESTADO ETAPA" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
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
            <!--NOMBRE-->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE ETAPA" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtNombreEtapa" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--FECHA DE INICIO-->
            <div class="form-group">
                <asp:Label ID="lblFechaInicioEtapa" runat="server" Text="FECHA INICIO" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                <div class="col-md-4">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaInicioEtapa"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <!--FECHA FINAL-->
            <div class="form-group">
                <asp:Label ID="lblFechaFinEtapa" runat="server" Text="FECHA FINAL" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                <div class="col-md-4">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaFinEtapa"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- RENDICION -->
            <div class="form-group">
                <asp:Label ID="lblRendicionEtapa" runat="server" Text="PRESENTO RENDICION ?" CssClass="col-md-3 AlineadoDerecha "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkRendicionEtapa" runat="server" CssClass="AlineadoDerecha" BorderStyle="None" />
                </div>
            </div>
            <!-- INFORME -->
            <div class="form-group">
                <asp:Label ID="lblInformeEtapa" runat="server" Text="PRESENTO INFORME ?" CssClass="col-md-3 AlineadoDerecha "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkInformeEtapa" runat="server" CssClass="AlineadoDerecha" BorderStyle="None" />
                </div>
            </div>
            <!--DURACION SEGUN UVT-->
            <div class="form-group">
                <asp:Label ID="lblDuracionSegunUvt" runat="server" Text="DURACION SEGUN UVT" CssClass="col-md-3 AlineadoDerecha"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtDuracionSegunUvt" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- BOTON GUARDAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-1">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="180" CssClass="boton_verde" OnClick="btnGuardar_Click"></asp:Button>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" Width="180" CssClass="boton_rojo" OnClick="btnVolver_Click"></asp:Button>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" Width="180" CssClass="boton_verde" OnClick="btnActualizar_Click"></asp:Button>
                </div>
            </div>
        </asp:Panel>
        <!--LISTA DE ETAPAS-->
        <div class="form-group">
            <div class="col-md-12 col-md-offset-0">
                <asp:GridView ID="dgvEtapas" runat="server" AutoGenerateColumns="false"
                    DataKeyNames="idEtapaCofecyt"
                    OnSelectedIndexChanging="dgvEtapas_SelectedIndexChanging"
                    CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen etapas cargadas" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Id" DataField="idEtapaCofecyt" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Etapa" DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Inicio" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaInicio" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Fin" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaFin" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Rendicion" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                            <ItemTemplate><%# (Boolean.Parse(Eval("Rendicion").ToString())) ? "Si" : "No" %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Informe Tecnico" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                            <ItemTemplate><%# (Boolean.Parse(Eval("Informe").ToString())) ? "Si" : "No" %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Duracion" DataField="duracionSegunUvt" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Estado" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoEstadoEtapa.Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="30" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-edit" ItemStyle-Width="30" HeaderStyle-Width="30" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>















        <%--<asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3 id="lblPanelSuperiorTitulo" runat="server">Proyecto</h3>
            </div>
            <!-- LISTA CON LOS FONDOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblFondoChoice" Font-Bold="true" runat="server" CssClass="col-md-2 control-label"> </asp:Label>
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
            <!-- LISTA CON LAS CONVOCATORIAS EN LA BASE DE DATOS -->
            <div class="form-group">
                <asp:Label ID="lblConvocatoria" Font-Bold="true" runat="server" CssClass="col-md-2 control-label"></asp:Label>
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
            <!-- LISTA CON LOS PROYECTOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <asp:Label ID="lblProyectos" Font-Bold="true" runat="server" Text="" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlProyectoChoice" runat="server"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        AutoPostBack="True"
                        AppendDataBoundItems="false"
                        OnSelectedIndexChanged="ddlProyectoChoice_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Proyecto&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelInformacionProyecto" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <br />
                <asp:Label ID="lblNombreProyecto" Style="text-align: justify;" Font-Bold="true" runat="server" CssClass="col-md-12 control-label"></asp:Label>
                <br />
            </div>
        </asp:Panel>

        <!--LISTA DE ETAPAS COFECYT-->
        <div class="form-group">
            <div class="col-md-12 col-md-offset-0">
                <asp:GridView ID="dgvEtapasCofecyt" runat="server" AutoGenerateColumns="false"
                    DataKeyNames="idEtapaCofecyt"
                    CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen etapas cargadas" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Etapa" DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Inicio" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaInicio" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Fin" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaFin" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />

                        <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Rendicion" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                            <ItemTemplate><%# (Boolean.Parse(Eval("Rendicion").ToString())) ? "Si" : "No" %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Informe Tecnico" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                            <ItemTemplate><%# (Boolean.Parse(Eval("Informe").ToString())) ? "Si" : "No" %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Duracion (UVT)" DataField="duracionSegunUvt" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100" />
                        <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Estado" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoEstadoEtapa.Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>--%>
    </div>

</asp:Content>
