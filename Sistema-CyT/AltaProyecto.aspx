<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaProyecto.aspx.cs" Inherits="Sistema_CyT.AltaProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Formulario de ALTA Proyecto</h3>
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
                        AppendDataBoundItems="false">
                        <asp:ListItem Value="-1">&lt;Seleccione Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <!--PANEL DE PROYECTO SIMPLE-->
        <asp:Panel ID="PanelInformacion" CssClass="panel panel-default" runat="server">
            <!--EXPEDIENTE COPADE-->
            <div class="form-group">
                <br />
                <asp:Label ID="lblNumeroExp" runat="server" Text="N° EXPEDIENTE" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtNumeroExp" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTipoProyecto" runat="server" Text="TIPO PROYECTO" CssClass="col-md-2 control-label"> </asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlTipoProyecto" runat="server"
                            BackColor="WhiteSmoke"
                            ForeColor="#000066"
                            CssClass="selectpicker form-control show-tick"
                            data-live-search="true"
                            DataTextField="nombre"
                            AutoPostBack="False"
                            AppendDataBoundItems="true">
                            <asp:ListItem Value="-1">&lt;Seleccione Tipo&gt;</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <!--NOMBRE DEL PROYECTO-->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="TITULO" CssClass="col-md-2 col-xs-12 control-label"></asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--OBJETIVOS DEL PROYECTO-->
            <div class="form-group">
                <asp:Label ID="lblObjetivos" runat="server" Text="OBJETIVOS" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtObjetivos" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--BREVE DESCRIPCION-->
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="BREVE DESCRIPCION" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--DESTINATARIOS DEL PROYECTO-->
            <div class="form-group">
                <asp:Label ID="lblDestinatarios" runat="server" Text="DESTINATARIOS" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtDestinatarios" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                <%--NUEVA LOCALIDAD--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalLocalidad">Nueva Localidad</button>
                    </div>
                    <!-- MODAL NUEVA LOCALIDAD  -->
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
            <!--SECTOR-->
            <div class="form-group">
                <asp:Label ID="lblSector" runat="server" Text="SECTOR" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlSector" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Sector&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--TEMATICA-->
            <div class="form-group">
                <asp:Label ID="lblTematica" runat="server" Text="TEMATICA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlTematica" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Tematica&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--OBSERVACIONES-->
            <div class="form-group">
                <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                </div>
            </div>
        </asp:Panel>


        <!--PANEL COFECYT - Informacion del Proyecto-->
        <asp:Panel ID="PanelCofecytInformacion" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>COFECyT - Informacion del Proyecto</h3>
            </div>
            <!--TITULO/NOMBRE DEL PROYECTO-->
            <div class="form-group">
                <br />
                <asp:Label ID="lblTituloCofecyt" runat="server" Text="TITULO" CssClass="col-md-2 col-xs-12 control-label"></asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtTituloCofecyt" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--OBJETIVOS DEL PROYECTO-->
            <div class="form-group">
                <asp:Label ID="lblObjetivosCofecyt" runat="server" Text="OBJETIVOS" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtObjetivosCofecyt" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--BREVE DESCRIPCION-->
            <div class="form-group">
                <asp:Label ID="lblDescripcionCofecyt" runat="server" Text="BREVE DESCRIPCION" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtDescripcionCofecyt" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--DESTINATARIOS DEL PROYECTO-->
            <div class="form-group">
                <asp:Label ID="lblDestinatariosCofecyt" runat="server" Text="DESTINATARIOS" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtDestinatariosCofecyt" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--LOCALIDAD-->
            <div class="form-group">
                <asp:Label ID="lblLocalidadCofecyt" runat="server" Text="LOCALIDAD" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlLocalidadCofecyt" runat="server"
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
                <%--NUEVA LOCALIDAD--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalLocalidadCofecyt">Nueva Localidad</button>
                    </div>
                    <!-- MODAL NUEVA LOCALIDAD  -->
                    <div class="modal fade" id="modalLocalidadCofecyt" tabindex="-1" role="dialog" aria-labelledby="modalLabelLocalidadCofecyt" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelLocalidadCofecyt">Nueva Localidad</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <asp:Label ID="lblNombreCofecyt" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtNombreCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblCodigoPostalCofecyt" runat="server" Text="CODIGO POSTAL" CssClass="col-md-4 control-label"> </asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCodigoPostalCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="Button2" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="Button3" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalLocalidadGuardar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--SECTOR-->
            <div class="form-group">
                <asp:Label ID="lblSectorCofecyt" runat="server" Text="SECTOR" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlSectorCofecyt" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Sector&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--TEMATICA-->
            <div class="form-group">
                <asp:Label ID="lblTematicaCofecyt" runat="server" Text="TEMATICA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlTematicaCofecyt" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Tematica&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!--EXPEDIENTE COPADE-->
            <div class="form-group">
                <asp:Label ID="lblNumeroExpedienteCopadeCofecyt" runat="server" Text="N°EXP COPADE" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtNumeroExpedienteCopadeCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--NUMERO DE CONVENIO-->
            <div class="form-group">
                <asp:Label ID="lblNumeroConvenio" runat="server" Text="N° CONVENIO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtNumeroConvenio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--NUMERO EXPEDIENTE DGA-->
            <div class="form-group">
                <asp:Label ID="lblNumeroExpedienteDga" runat="server" Text="N° EXP DGA" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtNumeroExpedienteDga" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--UVT-->
            <div class="form-group">
                <asp:Label ID="lblUvt" runat="server" Text="UVT" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-7">
                    <asp:DropDownList ID="ddlUvt" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione UVT&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--DIRECTOR DEL PROYECTO-->
            <div class="form-group">
                <asp:Label ID="lblDirector" runat="server" Text="DIRECTOR PROYECTO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlDirector" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- FECHA DE PRESENTACION -->
            <div class="form-group">
                <asp:Label ID="lblFechaPresentacion" runat="server" Text="FECHA PRESENTACION" CssClass="col-md-3 control-label"></asp:Label>
                <div class="col-md-3">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaPresentacion"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- FECHA DE ULTIMA EVALUACION TECNICA -->
            <div class="form-group">
                <asp:Label ID="lblUltimaEvaluacionTecnica" runat="server" Text="FECHA ULTIMA EVALUACION TECNICA" CssClass="col-md-3 control-label"></asp:Label>
                <div class="col-md-3">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtUltimaEvaluacionTecnica"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- FECHA DE FINALIZACION -->
            <div class="form-group">
                <asp:Label ID="lblFechaFinalizacion" runat="server" Text="FECHA FINALIZACION" CssClass="col-md-3 control-label"></asp:Label>
                <div class="col-md-3">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaFinalizacion"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <!--DURACION DEL PROYECTO EN MESES SEGUN LO ESTIMADO-->
            <div class="form-group">
                <asp:Label ID="lblDuracionEstimada" runat="server" Text="DURACION ESTIMADA" CssClass="col-md-3 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtDuracionEstimada" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--DURACION DEL PROYECTO EN MESES SEGUN IFFA-->
            <div class="form-group">
                <asp:Label ID="lblDuracionEstimadaIfaa" runat="server" Text="DURACION ESTIMADA SEGUN IFAA" CssClass="col-md-3 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtDuracionEstimadaIfaa" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--BENEFICIARIOS-->
            <div class="form-group">
                <asp:Label ID="lblBeneficiarios" runat="server" Text="BENEFICIARIOS" CssClass="col-md-3 control-label"> </asp:Label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtBeneficiarios" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--ENTIDADES INTERVINIENTES-->
            <div class="form-group">
                <asp:Label ID="lblEntidadesIntervinientes" runat="server" Text="ENTIDADES INTERVINIENTES" CssClass="col-md-3 control-label"> </asp:Label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtEntidadesIntervinientes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--ESTADO COFECYT del Proyecto-->
            <div class="form-group">
                <asp:Label ID="lblEstadoCofecyt" runat="server" Text="ESTADO DE SITUACION" CssClass="col-md-3 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlEstadoCofecyt" runat="server"
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
            <!--CONTACTO BENEFICIARIO-->
            <div class="form-group">
                <asp:Label ID="lblContactoBeneficiario" runat="server" Text="CONTACTO BENEFICIARIO" CssClass="col-md-3 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlContactoBeneficiario" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--OBSERVACIONES-->
            <div class="form-group">
                <asp:Label ID="lblObservacionesCofecyt" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-8 col-xs-12">
                    <asp:TextBox ID="txtObservacionesCofecyt" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                </div>
            </div>
        </asp:Panel>


        <!--PANEL DEL COFECYT - FINANCIAMIENTO-->
        <asp:Panel ID="PanelCofecytFinanciamiento" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>COFECyT - Financiamiento del Proyecto</h3>
            </div>
            <!--MONTO SOLICITADO-->
            <div class="form-group">
                <br />
                <asp:Label ID="lblMontoSolicitadoCofecyt" runat="server" Text="MONTO SOLICITADO" CssClass="col-md-3 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoSolicitadoCofecyt" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO CONTRAPARTE-->
            <div class="form-group">
                <asp:Label ID="lblMontoContraparteCofecyt" runat="server" Text="MONTO CONTRAPARTE" CssClass="col-md-3 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoContraparteCofecyt" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO TOTAL-->
            <div class="form-group">
                <asp:Label ID="lblMontoTotalCofecyt" runat="server" Text="MONTO TOTAL" CssClass="col-md-3 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoTotalCofecyt" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO TOTAL RENDIDO Y APROBADO (DGA)-->
            <div class="form-group">
                <asp:Label ID="lblMontoTotalDgaCofecyt" runat="server" Text="MONTO TOTAL RENDIDO Y APROBADO DGA" CssClass="col-md-3 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoTotalDgaCofecyt" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO DEVOLUCION-->
            <div class="form-group">
                <asp:Label ID="lblMontoDevolucionCofecyt" runat="server" Text="DEVOLUCION" CssClass="col-md-3 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoDevolucionCofecyt" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO RESCINDIDO-->
            <div class="form-group">
                <asp:Label ID="lblMontoRescindidoCofecyt" runat="server" Text="MONTO RESCINDIDO" CssClass="col-md-3 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoRescindidoCofecyt" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </asp:Panel>


        <!--PANEL INFORMACION ADICIONAL DEL PROYECTO-->
        <asp:Panel ID="PanelInformacionAdicionalProyecto" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Informacion Adicional del Proyecto</h3>
            </div>
            <!--MONTO SOLICITADO-->
            <div class="form-group">
                <br />
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

            <!--CONTACTO REFERENTE-->
            <div class="form-group">
                <asp:Label ID="lblContacto" runat="server" Text="REFERENTE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlContacto" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlContacto_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--NUEVO CONTACTO--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalContacto">Nuevo Contacto</button>
                    </div>
                    <!-- MODAL NUEVO CONTACTO  -->
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
                                        <asp:Label ID="lblContactoNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtContactoNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblContactoApellidoModal" runat="server" Text="APELLIDO" CssClass="col-md-4 control-label"> </asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtContactoApellidoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblContactoTelefonoModal" runat="server" Text="TELEFONO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtContactoTelefonoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblContactoCorreoElectronicoModal" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-4 control-label"></asp:Label>
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
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Empresa&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--NUEVA EMPRESA--%>
                <div class="col-md-2">
                    <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalEmpresa">Nueva Empresa</button>
                </div>
                <!-- MODAL NUEVA EMPRESA  -->
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
                                    <asp:Label ID="lblEmpresaNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmpresaNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblEmpresaTelefonoModal" runat="server" Text="TELEFONO" CssClass="col-md-4 control-label"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmpresaTelefonoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblEmpresaCorreoElectronicoModal" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-4 control-label"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmpresaCorreoElectronicoModal" runat="server" CssClass="form-control"></asp:TextBox>
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
            <!--ESTADO del Proyecto Simple-->
            <div class="form-group">
                <asp:Label ID="lblTipoEstado" runat="server" Text="ESTADO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlTipoEstado" runat="server"
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
        </asp:Panel>

        <asp:Panel ID="PanelMostrarEtapas" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Etapas del Proyecto</h3>
            </div>
            <div class="form-group">
                <br />
                <asp:Label ID="lblEtapa" runat="server" Text="ETAPAS" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <button id="btnAgregarEtapa" type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalEtapa">Agregar Etapa</button>
                </div>
            </div>

            <!--LISTA DE ETAPAS CARGADAS-->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
                    <asp:GridView ID="dgvEtapas" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="idEtapa"
                        CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen etapas cargadas" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Inicio" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaInicio" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Fin" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaFin" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Rendicion" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate><%# (Boolean.Parse(Eval("Rendicion").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Informe Tecnico" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate><%# (Boolean.Parse(Eval("Informe").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>



        <!--BOTON GUARDAR PROYECTO  -->
        <div class="form-group">
            <div class="col-md-2 col-md-offset-2">
                <asp:Button ID="btnGuardarProyecto" runat="server" Text="Guardar Proyecto" CssClass="btn btn-success form-control" OnClick="btnGuardarProyecto_Click" />
            </div>
        </div>

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
                            <asp:Button runat="server" ID="btnModalEtapaSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                            <asp:Button runat="server" ID="btnModalEtapaGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalEtapaGuardar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <asp:Panel ID="PanelMostrarEtapasCofecyt" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>Etapas del Proyecto</h3>
            </div>
            <div class="form-group">
                <br />
                <asp:Label ID="lblEtapaCofecyt" runat="server" Text="ETAPAS" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <button id="btnAgregarEtapaCofecyt" type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalEtapaCofecyt">Agregar Etapa</button>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblActividadCofecyt" runat="server" Text="ACTIVIDADES" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <button id="btnAgregarActividadCofecyt" type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalActividadCofecyt">Agregar Actividad</button>
                </div>
            </div>
            <!--LISTA DE ETAPAS COFECYT-->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
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
            </div>
            <!--LISTA DE ACTIVIDADES COFECYT-->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
                    <asp:GridView ID="dgvActividadesCofecyt" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="idActividadCofecyt"
                        CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen actividades cargadas" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Etapa" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="l2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "idEtapaCofecyt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Actividad" DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Resultados Esperados" DataField="resultadosEsperados" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Localizacion" DataField="localizacion" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <!-- MODAL AGREGAR ETAPA NUEVA -->
            <div class="modal fade" id="modalEtapaCofecyt" tabindex="-1" role="dialog" aria-labelledby="modalLabelEtapaCofecyt" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 class="modal-title" id="modalLabelEtapaCofecyt">AGREGAR ETAPA</h4>
                        </div>
                        <!-- CUERPO DEL MODAL -->
                        <div class="modal-body">
                            <!--NOMBRE-->
                            <div class="form-group">
                                <asp:Label ID="lblNombreModalCofecyt" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNombreModalCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!--ESTADO DE LA ETAPA-->
                            <div class="form-group">
                                <asp:Label ID="lblTipoEstadoEtapaCofecyt" runat="server" Text="ESTADO" CssClass="col-md-2 control-label"></asp:Label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlTipoEstadoEtapaCofecyt" runat="server"
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
                                <asp:Label ID="lblFechaInicioCofecyt" runat="server" Text="FECHA INICIO" CssClass="col-md-2 control-label"> </asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group date"
                                        data-provide="datepicker"
                                        data-date-autoclose="true"
                                        data-date-today-btn="true"
                                        data-date-clear-btn="true"
                                        data-date-today-highlight="true">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaInicioCofecyt"></asp:TextBox>
                                        <div class="input-group-addon">
                                            <span class="glyphicon glyphicon-th"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--FECHA FINAL-->
                            <div class="form-group">
                                <asp:Label ID="lblFechaFinCofecyt" runat="server" Text="FECHA FINAL" CssClass="col-md-2 control-label"> </asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group date"
                                        data-provide="datepicker"
                                        data-date-autoclose="true"
                                        data-date-today-btn="true"
                                        data-date-clear-btn="true"
                                        data-date-today-highlight="true">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaFinCofecyt"></asp:TextBox>
                                        <div class="input-group-addon">
                                            <span class="glyphicon glyphicon-th"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- RENDICION -->
                            <div class="form-group">
                                <asp:Label ID="lblRendicionCofecyt" runat="server" Text="PRESENTO RENDICION ?" CssClass="col-md-3 control-label "></asp:Label>
                                <div class="col-md-1">
                                    <asp:CheckBox ID="chkRendicionCofecyt" runat="server" CssClass="control-label" BorderStyle="None" />
                                </div>
                            </div>
                            <!-- INFORME -->
                            <div class="form-group">
                                <asp:Label ID="lblInformeCofecyt" runat="server" Text="PRESENTO INFORME ?" CssClass="col-md-3 control-label "></asp:Label>
                                <div class="col-md-1">
                                    <asp:CheckBox ID="chkInformeCofecyt" runat="server" CssClass="control-label" BorderStyle="None" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblDuracionSegunUvt" runat="server" Text="DURACION SEGUN UVT" CssClass="col-md-3 control-label"> </asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtDuracionSegunUvt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnModalEtapaCofecytSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                <asp:Button runat="server" ID="btnModalEtapaCofecytGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalEtapaCofecytGuardar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- MODAL AGREGAR ACTIVIDAD NUEVA -->
            <div class="modal fade" id="modalActividadCofecyt" tabindex="-1" role="dialog" aria-labelledby="modalLabelActividadCofecyt" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 class="modal-title" id="modalLabelActividadCofecyt">AGREGAR ACTIVIDAD</h4>
                        </div>
                        <!-- CUERPO DEL MODAL -->
                        <div class="modal-body">
                            <!--NOMBRE DE LA ETAPA-->
                            <div class="form-group">
                                <asp:Label ID="lblEtapaActividad" runat="server" Text="ETAPA" CssClass="col-md-3 control-label"></asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlEtapaActividad" runat="server"
                                        BackColor="WhiteSmoke"
                                        ForeColor="#000066"
                                        CssClass="selectpicker form-control show-tick"
                                        data-live-search="true"
                                        DataTextField="nombre"
                                        AutoPostBack="False"
                                        AppendDataBoundItems="False">
                                        <asp:ListItem Value="-1">&lt;Seleccione Etapa&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!--NOMBRE-->
                            <div class="form-group">
                                <asp:Label ID="lblNombreActividadCofecyt" runat="server" Text="NOMBRE" CssClass="col-md-3 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNombreActividadCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!--BREVE DESCRIPCION-->
                            <div class="form-group">
                                <asp:Label ID="lblDescripcionActividadCofecyt" runat="server" Text="BREVE DESCRIPCION" CssClass="col-md-3 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDescripcionActividadCofecyt" TextMode="MultiLine" Rows="2" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!--RESULTADOS ESPERADOS-->
                            <div class="form-group">
                                <asp:Label ID="lblResultadosEsperadosActividadCofecyt" runat="server" Text="RESULTADOS ESPERADOS" CssClass="col-md-3 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtResultadosEsperadosActividadCofecyt" TextMode="MultiLine" Rows="2" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!--LOCALIZACION-->
                            <div class="form-group">
                                <asp:Label ID="lblLocalizacionActividadCofecyt" runat="server" Text="LOCALIZACION" CssClass="col-md-3 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLocalizacionActividadCofecyt" TextMode="MultiLine" Rows="1" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnModalActividadCofecytSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                <asp:Button runat="server" ID="btnModalActividadCofecytGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalActividadCofecytGuardar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>













        </asp:Panel>
    </div>
</asp:Content>
