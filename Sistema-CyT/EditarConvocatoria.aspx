<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarConvocatoria.aspx.cs" Inherits="Sistema_CyT.EditarConvocatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>Formulario EDITAR Convocatoria</h3>
            </div>

            <!-- LISTA CON LAS CONVOCATORIAS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblDdl" Font-Bold="true" runat="server" Text="&lt Seleccione Convocatoria &gt" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlActualizarConvocatoria" runat="server"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="True"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlActualizarConvocatoria_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!--NOMBRE-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <!--AÑO y FONDO-->
            <div class="form-group">
                <asp:Label ID="lblAnio" runat="server" Text="AÑO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtAnio" Width="260" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
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
            <!-- TIPO DE FINANCIAMIENTO Y TIPO DE CONVOCATORIA -->
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
                        <asp:ListItem Value="-1">&lt;Seleccione Tipo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Label ID="lblTipoConvocatoria" runat="server" Text="TIPO CONVOCATORIA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlTipoConvocatoria" runat="server"
                        Width="100%"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre">
                        <asp:ListItem Value="-1">&lt;Seleccione Tipo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- FECHA DE APERTURA Y FECHA DE CIERRE -->
            <div class="form-group">
                <asp:Label ID="lblFechaApertura" runat="server" Text="FECHA APERTURA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <div class="input-group date"
                        data-provide="datepicker"
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
            <!-- ABIERTA -->
            <div class="form-group">
                <asp:Label ID="lblAbierta" runat="server" Text="ESTA ABIERTA ?" CssClass="col-md-2 control-label "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkAbierta" runat="server" CssClass="control-label" BorderStyle="None" />
                </div>
            </div>
            <!-- ACTIVO -->
            <div class="form-group">
                <asp:Label ID="lblActivo" runat="server" Text="ACTIVA" CssClass="col-md-2 control-label "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkActivo" runat="server" CssClass="control-label" BorderStyle="None" />
                </div>
            </div>

            <asp:Panel ID="PanelMostrarModalidad" CssClass="panel" runat="server">
                <div class="form-group">
                    <asp:Label ID="lblModalidad" runat="server" Text="MODALIDADES" CssClass="col-md-2 control-label"> </asp:Label>
                    <div class="col-md-4">
                        <button id="btnAgregarModalidad" type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalModalidad">Agregar Modalidad</button>
                    </div>
                </div>
            </asp:Panel>
            <!-- MODAL AGREGAR MODALIDAD NUEVA -->
            <div class="modal fade" id="modalModalidad" tabindex="-1" role="dialog" aria-labelledby="modalLabelModalidad" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 class="modal-title" id="modalLabelModalidad">AGREGAR MODALIDAD</h4>
                        </div>
                        <!-- CUERPO DEL MODAL -->
                        <div class="modal-body">
                            <div class="form-group">
                                <br />
                                <asp:Label ID="lblNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblDescripcionModal" runat="server" Text="DESCRIPCION" CssClass="col-md-4 control-label"> </asp:Label>
                                <div class="col-md-8 ">
                                    <asp:TextBox ID="txtDescripcionModal" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblObjetivoModal" runat="server" Text="OBJETIVO" CssClass="col-md-4 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtObjetivoModal" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                            <!--PLAZO DE EJECUCION-->
                            <div class="form-group">
                                <asp:Label ID="lblPlazoEjecucionModal" runat="server" Text="PLAZO EJECUCION" CssClass="col-md-4 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtPlazoEjecucionModal" runat="server" CssClass="form-control" placeholder="meses"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblMontoMaximoProyectoModal" runat="server" Text="MONTO MAXIMO POR PROYECTO" CssClass="col-md-4 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtMontoMaximoProyectoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!--PORCENTAJE DE FINANCIAMIENTO-->
                            <div class="form-group">
                                <asp:Label ID="lblPorcentajeFinanciamientoModal" runat="server" Text="% FINANCIAMIENTO" CssClass="col-md-4 control-label"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtPorcentajeFinanciamientoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnModalModalidadSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                            <asp:Button runat="server" ID="btnModalModalidadGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalModalidadGuardar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- BOTON ACTUALIZAR CONVOCATORIA-->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnActualizarConvocatoria" runat="server" Text="Actualizar Convocatoria" CssClass="btn btn-info form-control" OnClick="btnActualizarConvocatoria_Click" />
                </div>
            </div>
        </asp:Panel>

        <!--LISTA DE MODALIDADES CARGADAS-->
        <div class="panel-heading">
            <h3>Modalidades de la Convocatoria</h3>
        </div>
        <div class="form-group">
            <div class="col-md-12">
                <asp:GridView ID="dgvModalidades" runat="server" AutoGenerateColumns="false"
                    DataKeyNames="idModalidad"
                    CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen modalidades cargadas" ShowHeaderWhenEmpty="true"
                    OnSelectedIndexChanging="dgvModalidades_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdM" DataField="idModalidad" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Objetivo" DataField="objetivo" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Monto Maximo" DataField="montoMaximoProyecto" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="% Fin" DataField="porcentajeFinanciamiento" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Plazo Ejecucion" DataField="plazoEjecucion" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdC" DataField="idConvocatoria" ItemStyle-HorizontalAlign="Center" />
                        <asp:ButtonField Text="Editar" ButtonType="Button" CommandName="select" HeaderStyle-BackColor="#cccccc" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

