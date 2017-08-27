<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarProyecto.aspx.cs" Inherits="Sistema_CyT.EditarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>Formulario EDITAR Proyecto</h3>
            </div>

            <!-- LISTA CON LOS PROYECTOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblProyectos" Font-Bold="true" runat="server" Text="&lt Seleccione Proyecto &gt" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlActualizarProyecto" runat="server"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="True"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlActualizarProyecto_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Proyecto&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!--NOMBRE-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 col-xs-12 control-label"></asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--EXPEDIENTE-->
            <div class="form-group">
                <asp:Label ID="lblNumeroExp" runat="server" Text="EXPEDIENTE" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtNumeroExp" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--CONVOCATORIA-->
            <div class="form-group">
                <asp:Label ID="lblConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 col-xs-12 control-label"></asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:DropDownList ID="ddlConvocatoria" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--MONTO SOLICITADO-->
            <div class="form-group">
                <asp:Label ID="lblMontoSolicitado" runat="server" Text="MONTO SOLICITADO" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoSolicitado" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO CONTRAPARTE-->
            <div class="form-group">
                <asp:Label ID="lblMontoContraparte" runat="server" Text="MONTO CONTRAPARTE" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoContraparte" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO TOTAL-->
            <div class="form-group">
                <asp:Label ID="lblMontoTotal" runat="server" Text="MONTO TOTAL" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoTotal" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--CONTACTO-->
            <div class="form-group">
                <asp:Label ID="lblContacto" runat="server" Text="CONTACTO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlContacto" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--AGREGAR ACA EL MODAL PARA EL NUEVO CONTACTO--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalContacto">Nuevo Contacto</button>
                    </div>
                    <!-- MODAL CONTACTO  -->
                    <div class="modal fade" id="modalContacto" tabindex="-1" role="dialog" aria-labelledby="modalLabelContacto" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelContacto">Nuevo Contacto</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <asp:Label ID="lbl01" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtContactoNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lbl02" runat="server" Text="APELLIDO" CssClass="col-md-4 control-label"> </asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtContactoApellidoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lbl03" runat="server" Text="TELEFONO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtContactoTelefonoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lbl04" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtContactoCorreoElectronicoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="btnModalContactoSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalContactoGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalContactoGuardar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!--EMPRESA-->
            <div class="form-group">
                <asp:Label ID="lblEmpresa" runat="server" Text="EMPRESA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlEmpresa" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Empresa&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--AGREGAR ACA EL MODAL PARA LA NUEVA EMPRESA--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalEmpresa">Nueva Empresa</button>
                    </div>
                    <!-- MODAL EMPRESA  -->
                    <div class="modal fade" id="modalEmpresa" tabindex="-1" role="dialog" aria-labelledby="modalLabelEmpresa" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelEmpresa">Nueva Empresa</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtEmpresaModal" runat="server" CssClass="form-control"></asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="btnModalEmpresaSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalEmpresaGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalEmpresaGuardar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
                <%--AGREGAR ACA EL MODAL PARA LA NUEVA LOCALIDAD--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalLocalidad">Nueva Localidad</button>
                    </div>
                    <!-- MODAL LOCALIDAD  -->
                    <div class="modal fade" id="modalLocalidad" tabindex="-1" role="dialog" aria-labelledby="modalLabelLocalidad" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelLocalidad">Nueva Localidad</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtLocalidadNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="CODIGO POSTAL" CssClass="col-md-4 control-label"> </asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtLocalidadCodigoPostalModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="btnModalLocalidadSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalLocalidadGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalLocalidadGuardar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="PanelMostrarEtapas" CssClass="panel" runat="server">
                <div class="form-group">
                    <asp:Label ID="lblEtapa" runat="server" Text="ETAPAS" CssClass="col-md-2 control-label"> </asp:Label>
                    <div class="col-md-4">
                        <button id="btnAgregarEtapa" type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalEtapa">Agregar Etapa</button>
                    </div>
                </div>
            </asp:Panel>
            <!-- MODAL AGREGAR ETAPA NUEVA -->
            <div class="modal fade" id="modalEtapa" tabindex="-1" role="dialog" aria-labelledby="modalLabelEtapa" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 class="modal-title" id="modalLabelEtapa">AGREGAR ETAPA</h4>
                        </div>
                        <!-- CUERPO DEL MODAL -->
                        <div class="modal-body">
                            <!--NOMBRE-->
                            <div class="form-group">
                                <asp:Label ID="lblNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!--DURACION-->
                            <div class="form-group">
                                <asp:Label ID="lblDuracionModal" runat="server" Text="DURACION" CssClass="col-md-2 control-label"> </asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDuracionModal" runat="server" CssClass="form-control" placeholder="meses"></asp:TextBox>
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
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnModalEtapaSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                <asp:Button runat="server" ID="btnModalEtapaGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalEtapaGuardar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--BOTON ACTUALIZAR PROYECTO-->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnActualizarProyecto" runat="server" Text="Actualizar Proyecto" CssClass="btn btn-success form-control" OnClick="btnActualizarProyecto_Click" />
                </div>
            </div>
        </asp:Panel>

        <!--LISTA DE ETAPAS CARGADAS-->
        <div class="form-group">
            <div class="col-md-10 col-md-offset-1">
                <asp:GridView ID="dgvEtapas" runat="server" AutoGenerateColumns="false"
                    DataKeyNames="idEtapa"
                    CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen etapas cargadas" ShowHeaderWhenEmpty="true"
                    OnSelectedIndexChanging="dgvEtapas_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdE" DataField="idEtapa" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdP" DataField="idProyecto" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Duracion" DataField="duracion" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Inicio" DataFormatString="{0:dd-MM-yyyy}" DataField="fechaInicio" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="120" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Fin" DataFormatString="{0:dd-MM-yyyy}" DataField="fechaFin" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="120" />
                        <asp:ButtonField Text="Editar" ButtonType="Button" CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Font-Size="Small" HeaderStyle-Width="120" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
