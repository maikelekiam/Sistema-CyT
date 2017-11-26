<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarProyectoCofecyt.aspx.cs" Inherits="Sistema_CyT.MostrarProyectoCofecyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyectoCofecyt" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <br />
                <asp:Label ID="lblNombreProyectoCofecyt" Style="text-align: justify;" Font-Bold="true" runat="server" CssClass="col-md-12 control-label"></asp:Label>
                <br />
            </div>
            <div class="panel-body">
                <!--CONVOCATORIA-->
                <div class="form-group">
                    <asp:Label ID="lblConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 col-xs-12 control-label"></asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtConvocatoria" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
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
                        <asp:TextBox ID="txtDestinatariosCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--LOCALIDAD-->
                <div class="form-group">
                    <asp:Label ID="lblLocalidadCofecyt" runat="server" Text="LOCALIDAD" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtLocalidadCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--SECTOR-->
                <div class="form-group">
                    <asp:Label ID="lblSectorCofecyt" runat="server" Text="SECTOR" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtSectorCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--TEMATICA-->
                <div class="form-group">
                    <asp:Label ID="lblTematicaCofecyt" runat="server" Text="TEMATICA" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtTematicaCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <div class="col-md-6 col-xs-12">
                        <asp:TextBox ID="txtUvt" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                    </div>
                </div>
                <!--DIRECTOR DEL PROYECTO-->
                <div class="form-group">
                    <asp:Label ID="lblDirector" runat="server" Text="DIRECTOR PROYECTO" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-4 col-xs-12">
                        <asp:TextBox ID="txtDirector" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!-- FECHA DE PRESENTACION -->
                <div class="form-group">
                    <asp:Label ID="lblFechaPresentacion" runat="server" Text="FECHA PRESENTACION" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-4 col-xs-12">
                        <asp:TextBox ID="txtFechaPresentacion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!-- FECHA DE ULTIMA EVALUACION TECNICA -->
                <div class="form-group">
                    <asp:Label ID="lblUltimaEvaluacionTecnica" runat="server" Text="FECHA ULTIMA EVALUACION TECNICA" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-4 col-xs-12">
                        <asp:TextBox ID="txtUltimaEvaluacionTecnica" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!-- FECHA DE FINALIZACION -->
                <div class="form-group">
                    <asp:Label ID="lblFechaFinalizacion" runat="server" Text="FECHA FINALIZACION" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-4 col-xs-12">
                        <asp:TextBox ID="txtFechaFinalizacion" runat="server" CssClass="form-control"></asp:TextBox>
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
                        <asp:TextBox ID="txtBeneficiarios" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                    </div>
                </div>
                <!--ENTIDADES INTERVINIENTES-->
                <div class="form-group">
                    <asp:Label ID="lblEntidadesIntervinientes" runat="server" Text="ENTIDADES INTERVINIENTES" CssClass="col-md-3 control-label"> </asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtEntidadesIntervinientes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                    </div>
                </div>
                <!--ESTADO COFECYT del Proyecto-->
                <div class="form-group">
                    <asp:Label ID="lblEstadoCofecyt" runat="server" Text="ESTADO DE SITUACION" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtEstadoCofecyt" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--CONTACTO BENEFICIARIO-->
                <div class="form-group">
                    <asp:Label ID="lblContactoBeneficiario" runat="server" Text="CONTACTO BENEFICIARIO" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtContactoBeneficiario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--OBSERVACIONES-->
                <div class="form-group">
                    <asp:Label ID="lblObservacionesCofecyt" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                    <div class="col-md-8 col-xs-12">
                        <asp:TextBox ID="txtObservacionesCofecyt" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                    </div>
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
                <asp:Button runat="server" ID="btnActuaciones" Text="MOSTRAR ACTUACIONES" CssClass="btn btn-primary" OnClick="btnActuaciones_Click" />
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
                                    <asp:Label ID="l2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EtapaCofecyt.Nombre") %>'></asp:Label>
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


        </asp:Panel>
    </div>
</asp:Content>
