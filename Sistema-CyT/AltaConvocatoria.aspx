﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaConvocatoria.aspx.cs" Inherits="Sistema_CyT.AltaConvocatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Nueva Convocatoria</h3>
            </div>
            <!--NOMBRE-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control tb5" TextMode="MultiLine" Rows="1"></asp:TextBox>
                </div>
            </div>
            <!--AÑO y FONDO-->
            <div class="form-group">
                <asp:Label ID="lblAnio" runat="server" Text="AÑO" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtAnio" Width="260" runat="server" CssClass="form-control" MaxLength="4" Text="2017"></asp:TextBox>
                </div>
                <asp:Label ID="lblFondo" runat="server" Text="FONDO" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
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
                <asp:Label ID="lblTipoFinanciamiento" runat="server" Text="TIPO FINANCIAMIENTO" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
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
                <asp:Label ID="lblTipoConvocatoria" runat="server" Text="TIPO CONVOCATORIA" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlTipoConvocatoria" runat="server"
                        Width="100%"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlTipoConvocatoria_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Tipo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- FECHA DE APERTURA Y FECHA DE CIERRE -->
            <div class="form-group">
                <asp:Label ID="lblFechaApertura" runat="server" Text="FECHA APERTURA" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
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
                <asp:Label ID="lblFechaCierre" runat="server" Text="FECHA CIERRE" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-3" runat="server" id="fc">
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
            <div class="form-group">
                <asp:Label ID="lblAbierta" runat="server" Text="ESTA ABIERTA ?" CssClass="col-md-2 AlineadoDerecha "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkAbierta" runat="server" CssClass="AlineadoDerecha" BorderStyle="None" Checked="true" />
                </div>
            </div>

            <asp:Panel ID="PanelMostrarModalidad" CssClass="panel" runat="server">
                <div class="form-group">
                    <asp:Label ID="lblModalidad" runat="server" Text="MODALIDADES" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                    <div class="col-md-4">
                        <button id="btnAgregarModalidad" type="button" class="boton_azul" style="width: 180px;" data-toggle="modal" data-target="#modalModalidad">Agregar Modalidad</button>
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
                                <asp:Label ID="lblNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-4 AlineadoDerecha"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblDescripcionModal" runat="server" Text="DESCRIPCION" CssClass="col-md-4 AlineadoDerecha"> </asp:Label>
                                <div class="col-md-8 ">
                                    <asp:TextBox ID="txtDescripcionModal" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblObjetivoModal" runat="server" Text="OBJETIVO" CssClass="col-md-4 AlineadoDerecha"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtObjetivoModal" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                            <!--PLAZO DE EJECUCION-->
                            <div class="form-group">
                                <asp:Label ID="lblPlazoEjecucionModal" runat="server" Text="PLAZO EJECUCION" CssClass="col-md-4 AlineadoDerecha"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtPlazoEjecucionModal" runat="server" CssClass="form-control" placeholder="meses"></asp:TextBox>
                                </div>
                            </div>
                            <!--MONTO MAXIMO POR PROYECTO-->
                            <div class="form-group">
                                <asp:Label ID="lblMontoMaximoProyectoModal" runat="server" Text="MONTO MAXIMO POR PROYECTO" CssClass="col-md-4 AlineadoDerecha"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtMontoMaximoProyectoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!--PORCENTAJE DE FINANCIAMIENTO-->
                            <div class="form-group">
                                <asp:Label ID="lblPorcentajeFinanciamientoModal" runat="server" Text="% FINANCIAMIENTO" CssClass="col-md-4 AlineadoDerecha"> </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtPorcentajeFinanciamientoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnModalModalidadSalir" Text="Salir" class="boton_rojo" Width="150" data-dismiss="modal" />
                            <asp:Button runat="server" ID="btnModalModalidadGuardar" Text="Guardar" CssClass="boton_verde" Width="150" OnClick="btnModalModalidadGuardar_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <!--BOTON GUARDAR CONVOCATORIA-->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnGuardarConvocatoria" runat="server" Text="Guardar" Width="180" CssClass="boton_verde" OnClick="btnGuardarConvocatoria_Click" />
                </div>
            </div>

            <!--LISTA DE MODALIDADES CARGADAS-->
            <div class="form-group">
                <div class="col-md-12">
                    <asp:GridView ID="dgvModalidades" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="idModalidad"
                        CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen modalidades cargadas" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Right" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Objetivo" DataField="objetivo" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Monto Maximo" DataField="montoMaximoProyecto" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="% Financiamiento" DataField="porcentajeFinanciamiento" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Plazo Ejecucion" DataField="plazoEjecucion" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
