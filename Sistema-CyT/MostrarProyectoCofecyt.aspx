<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarProyectoCofecyt.aspx.cs" Inherits="Sistema_CyT.MostrarProyectoCofecyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyectoCofecyt" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h4>
                    <asp:Label ID="lblNombreProyectoCofecyt" runat="server" CssClass="col-md-12" Font-Size="Larger"></asp:Label>
                    <br />
                    <br />
                </h4>
            </div>
            <div class="panel-body">
                <!--CODIGO INTERNO-->
                <div class="form-group">
                    <asp:Label ID="lblCodigoInterno" runat="server" Text="CODIGO INTERNO" CssClass="col-md-2 lblalider"></asp:Label>
                    <asp:Label ID="txtCodigoInterno" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--CONVOCATORIA-->
                <div class="form-group">
                    <asp:Label ID="lblConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 lblalider"></asp:Label>
                    <asp:Label ID="txtConvocatoria" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--OBJETIVOS DEL PROYECTO-->
                <div class="form-group">
                    <asp:Label ID="lblObjetivosCofecyt" runat="server" Text="OBJETIVOS" CssClass="col-md-2 lblalider"> </asp:Label>
                    <asp:Label ID="txtObjetivosCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--BREVE DESCRIPCION-->
                <div class="form-group">
                    <asp:Label ID="lblDescripcionCofecyt" runat="server" Text="BREVE DESCRIPCION" CssClass="col-md-2 lblalider"> </asp:Label>
                    <asp:Label ID="txtDescripcionCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--DESTINATARIOS DEL PROYECTO-->
                <div class="form-group">
                    <asp:Label ID="lblDestinatariosCofecyt" runat="server" Text="DESTINATARIOS" CssClass="col-md-2 lblalider"> </asp:Label>
                    <asp:Label ID="txtDestinatariosCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--LOCALIDAD-->
                <div class="form-group">
                    <asp:Label ID="lblLocalidadCofecyt" runat="server" Text="LOCALIDAD" CssClass="col-md-2 lblalider"></asp:Label>
                    <asp:Label ID="txtLocalidadCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--SECTOR-->
                <div class="form-group">
                    <asp:Label ID="lblSectorCofecyt" runat="server" Text="SECTOR" CssClass="col-md-2 lblalider"></asp:Label>
                    <asp:Label ID="txtSectorCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--TEMATICA-->
                <div class="form-group">
                    <asp:Label ID="lblTematicaCofecyt" runat="server" Text="TEMATICA" CssClass="col-md-2 lblalider"></asp:Label>
                    <asp:Label ID="txtTematicaCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--EXPEDIENTE COPADE-->
                <div class="form-group">
                    <asp:Label ID="lblNumeroExpedienteCopadeCofecyt" runat="server" Text="N°EXP COPADE" CssClass="col-md-2 lblalider"> </asp:Label>
                    <asp:Label ID="txtNumeroExpedienteCopadeCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--NUMERO DE CONVENIO-->
                <div class="form-group">
                    <asp:Label ID="lblNumeroConvenio" runat="server" Text="N° CONVENIO" CssClass="col-md-2 lblalider"> </asp:Label>
                    <asp:Label ID="txtNumeroConvenio" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--NUMERO EXPEDIENTE DGA-->
                <div class="form-group">
                    <asp:Label ID="lblNumeroExpedienteDga" runat="server" Text="N° EXP DGA" CssClass="col-md-2 lblalider"> </asp:Label>
                    <asp:Label ID="txtNumeroExpedienteDga" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--UVT-->
                <div class="form-group">
                    <asp:Label ID="lblUvt" runat="server" Text="UVT" CssClass="col-md-2 lblalider"></asp:Label>
                    <asp:Label ID="txtUvt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--DIRECTOR DEL PROYECTO-->
                <div class="form-group">
                    <asp:Label ID="lblDirector" runat="server" Text="DIRECTOR PROYECTO" CssClass="col-md-2 lblalider"></asp:Label>
                    <asp:Label ID="txtDirector" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!-- FECHA DE PRESENTACION -->
                <div class="form-group">
                    <asp:Label ID="lblFechaPresentacion" runat="server" Text="FECHA PRESENTACION" CssClass="col-md-3 lblalider"></asp:Label>
                    <asp:Label ID="txtFechaPresentacion" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!-- FECHA DE ULTIMA EVALUACION TECNICA -->
                <div class="form-group">
                    <asp:Label ID="lblUltimaEvaluacionTecnica" runat="server" Text="FECHA ULTIMA EVALUACION TECNICA" CssClass="col-md-3 lblalider"></asp:Label>
                    <asp:Label ID="txtUltimaEvaluacionTecnica" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!-- FECHA DE FINALIZACION -->
                <div class="form-group">
                    <asp:Label ID="lblFechaFinalizacion" runat="server" Text="FECHA FINALIZACION" CssClass="col-md-3 lblalider"></asp:Label>
                    <asp:Label ID="txtFechaFinalizacion" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--DURACION DEL PROYECTO EN MESES SEGUN LO ESTIMADO-->
                <div class="form-group">
                    <asp:Label ID="lblDuracionEstimada" runat="server" Text="DURACION ESTIMADA" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtDuracionEstimada" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--DURACION DEL PROYECTO EN MESES SEGUN IFFA-->
                <div class="form-group">
                    <asp:Label ID="lblDuracionEstimadaIfaa" runat="server" Text="DURACION ESTIMADA SEGUN IFAA" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtDuracionEstimadaIfaa" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--ENTIDADES INTERVINIENTES-->
                <div class="form-group">
                    <asp:Label ID="lblEntidadesIntervinientes" runat="server" Text="ENTIDADES INTERVINIENTES" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtEntidadesIntervinientes" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--ESTADO COFECYT del Proyecto-->
                <div class="form-group">
                    <asp:Label ID="lblEstadoCofecyt" runat="server" Text="ESTADO DE SITUACION" CssClass="col-md-3 lblalider"></asp:Label>
                    <asp:Label ID="txtEstadoCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--BENEFICIARIOS-->
                <div class="form-group">
                    <asp:Label ID="lblBeneficiarios" runat="server" Text="BENEFICIARIOS" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtBeneficiarios" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--CONTACTO BENEFICIARIO-->
                <div class="form-group">
                    <asp:Label ID="lblContactoBeneficiario" runat="server" Text="CONTACTO BENEFICIARIO" CssClass="col-md-3 lblalider"></asp:Label>
                    <asp:Label ID="txtContactoBeneficiario" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--CONTRAPARTE-->
                <div class="form-group">
                    <asp:Label ID="lblContraparte" runat="server" Text="CONTRAPARTE" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtContraparte" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--CONTACTO CONTRAPARTE-->
                <div class="form-group">
                    <asp:Label ID="lblContactoContraparte" runat="server" Text="CONTACTO CONTRAPARTE" CssClass="col-md-3 lblalider"></asp:Label>
                    <asp:Label ID="txtContactoContraparte" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--OBSERVACIONES-->
                <div class="form-group">
                    <asp:Label ID="lblObservacionesCofecyt" runat="server" Text="OBSERVACIONES" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtObservacionesCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO SOLICITADO-->
                <div class="form-group">
                    <asp:Label ID="lblMontoSolicitadoCofecyt" runat="server" Text="MONTO SOLICITADO" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtMontoSolicitadoCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO CONTRAPARTE-->
                <div class="form-group">
                    <asp:Label ID="lblMontoContraparteCofecyt" runat="server" Text="MONTO CONTRAPARTE" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtMontoContraparteCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO TOTAL-->
                <div class="form-group">
                    <asp:Label ID="lblMontoTotalCofecyt" runat="server" Text="MONTO TOTAL" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtMontoTotalCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO TOTAL RENDIDO Y APROBADO (DGA)-->
                <div class="form-group">
                    <asp:Label ID="lblMontoTotalDgaCofecyt" runat="server" Text="MONTO TOTAL RENDIDO Y APROBADO DGA" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtMontoTotalDgaCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO DEVOLUCION-->
                <div class="form-group">
                    <asp:Label ID="lblMontoDevolucionCofecyt" runat="server" Text="DEVOLUCION" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtMontoDevolucionCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO RESCINDIDO-->
                <div class="form-group">
                    <asp:Label ID="lblMontoRescindidoCofecyt" runat="server" Text="MONTO RESCINDIDO" CssClass="col-md-3 lblalider"> </asp:Label>
                    <asp:Label ID="txtMontoRescindidoCofecyt" runat="server" CssClass="col-md-8 lblaliizq" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelEtapasActividades" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Etapas y Actividades del Proyecto</h3>
            </div>
            <!--LISTA DE ETAPAS COFECYT-->
            <div class="form-group">
                <br />
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
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Duracion segun UVT" DataField="duracionSegunUvt" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100" />
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
                <div class="col-md-12">
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

        <div class="form-group">
            <div class="col-md-4">
                <asp:Button Style="text-align: left;" runat="server" ID="btnEtapa" Text=" Agregar/Editar Etapas" Width="200" CssClass="boton_azul" OnClick="btnEtapa_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-4">
                <asp:Button Style="text-align: left;" runat="server" ID="btnActividad" Text=" Agregar/Editar Actividades" Width="200" CssClass="boton_azul style-1" OnClick="btnActividad_Click" />
            </div>
        </div>

        <asp:Button Style="text-align: left;" runat="server" ID="btnActuaciones" Width="250" Text=" Historial de Actuaciones" CssClass="boton_azul" OnClick="btnActuaciones_Click" />

    </div>
</asp:Content>
