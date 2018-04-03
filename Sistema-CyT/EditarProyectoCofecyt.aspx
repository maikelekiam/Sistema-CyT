<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarProyectoCofecyt.aspx.cs" Inherits="Sistema_CyT.EditarProyectoCofecyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Formulario EDITAR Proyecto</h3>
            </div>
            <!-- LISTA CON LAS CONVOCATORIAS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <div class="col-md-2">
                    <asp:TextBox ID="txtFiltroConvocatoria" runat="server" CssClass="form-control AlineadoDerecha" Font-Bold="true" ReadOnly="true">< Filtro Convocatoria ></asp:TextBox>
                </div>
                <%--<asp:Label ID="lblConvocatoriaChoice" Font-Bold="true" runat="server" Text="&lt Filtro Convocatoria &gt" CssClass="col-md-2 control-label"></asp:Label>--%>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlConvocatoriaChoice" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Width="100%"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        AutoPostBack="true"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlConvocatoriaChoice_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- LISTA CON LOS PROYECTOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <div class="col-md-2">
                    <asp:TextBox ID="txtFiltroProyecto" runat="server" CssClass="form-control AlineadoDerecha" Font-Bold="true" ReadOnly="true">< Filtro Proyecto ></asp:TextBox>
                </div>
                <%--<asp:Label ID="lblProyectos" Font-Bold="true" runat="server" Text="&lt Seleccione Proyecto &gt" CssClass="col-md-2 control-label"> </asp:Label>--%>
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



        <!--BOTON ACTUALIZAR PROYECTO-->
        <div class="form-group">
            <div class="col-md-2 col-md-offset-2">
                <asp:Button ID="btnActualizarProyecto" runat="server" Text="Actualizar Proyecto" CssClass="btn btn-success form-control" OnClick="btnActualizarProyecto_Click" />
            </div>
        </div>

    </div>
</asp:Content>
