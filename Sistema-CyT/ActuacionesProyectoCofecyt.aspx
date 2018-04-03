<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActuacionesProyectoCofecyt.aspx.cs" Inherits="Sistema_CyT.ActuacionesProyectoCofecyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyectoCofecyt" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <br />
                <asp:Label ID="lblProyectoCofecyt" Style="text-align: justify;" Font-Bold="true" runat="server" CssClass="col-md-12 control-label"></asp:Label>
                <br />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelActuacionProyectoCofecyt" CssClass="panel" runat="server">
            <!-- BOTON AGREGAR ACTUACION -->
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Button ID="btnAgregarActuacionProyectoCofecyt" runat="server" Text="Agregar Actuacion" Width="180" CssClass="btn boton_azul" OnClick="btnAgregarActuacionProyectoCofecyt_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelNuevaActuacionProyectoCofecyt" CssClass="panel panel-success" runat="server">
            <div class="panel-body">
                <!--FECHA DE LA ACTUACION-->
                <div class="form-group">
                    <asp:Label ID="lblFechaActuacionProyectoCofecyt" runat="server" Text="FECHA DE ACTUACION" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-4">
                        <div class="input-group date"
                            data-provide="datepicker"
                            data-date-autoclose="true"
                            data-date-today-btn="true"
                            data-date-clear-btn="true"
                            data-date-today-highlight="true">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaActuacionProyectoCofecyt"></asp:TextBox>
                            <div class="input-group-addon">
                                <span class="glyphicon glyphicon-th"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--DETALLE DE LA ACTUACION-->
            <div class="form-group">
                <asp:Label ID="lblDetalle" runat="server" Text="DETALLE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
            </div>
            <!--PENDIENTE-->
            <div class="form-group">
                <asp:Label ID="lblPendiente" runat="server" Text="PENDIENTE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtPendiente" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
            </div>
            <!--RESPONSABLE-->
            <div class="form-group">
                <asp:Label ID="lblResponsable" runat="server" Text="RESPONSABLE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtResponsable" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--AGENTE-->
            <div class="form-group">
                <asp:Label ID="lblAgente" runat="server" Text="AGENTE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtAgente" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--FECHA LIMITE-->
            <div class="form-group">
                <asp:Label ID="lblFechaLimite" runat="server" Text="FECHA LIMITE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaLimite"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <!--OBSERVACIONES-->
            <div class="form-group">
                <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
            </div>
            <!--DOCUMENTACION ANEXADA-->
            <div class="form-group">
                <asp:Label ID="lblDocumentacionAnexada" runat="server" Text="DOCUMENTACION ANEXADA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDocumentacionAnexada" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
            </div>
            <!--BOTONES GUARDAR + CANCELAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnGuardarActuacion" runat="server" Text="Guardar Actuacion"  Width="180" CssClass="btn boton_verde" OnClick="btnGuardarActuacion_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn boton_rojo" Width="180" OnClick="btnCancelar_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnActualizarActuacion" runat="server" Text="Actualizar Actuacion"  Width="180" CssClass="btn boton_verde" OnClick="btnActualizarActuacion_Click" />
                </div>
            </div>
        </asp:Panel>

        <!--GRILLA CON LAS ACTUACIONES-->
        <asp:Label ID="lblGrillaActuaciones" runat="server" Text="GRILLA DE ACTUACIONES">
                <h4>ACTUACIONES REALIZADAS</h4>
        </asp:Label>
        <div class="form-group">
            <div class="col-md-12">
                <asp:GridView ID="dgvActuaciones" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" BorderWidth="2px" GridLines="Both"
                    OnSelectedIndexChanging="dgvActuaciones_SelectedIndexChanging"
                    OnRowDeleting="dgvActuaciones_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="idActuacion" DataField="idActuacionProyectoCofecyt" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="50" />
                        <asp:BoundField HeaderText="idP" DataField="idProyectoCofecyt" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="50" />
                        <asp:BoundField HeaderText="Fecha" DataField="fechaActuacion"
                            DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80" HeaderStyle-Width="80" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Detalle" DataField="detalle"
                            ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="300" HeaderStyle-Width="300" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Pendiente" DataField="pendiente"
                            ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="250" HeaderStyle-Width="250" />
                        <%--<asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Responsable" DataField="responsable"
                            ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="100" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Agente" DataField="agente"
                            ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="100" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderText="Limite" DataField="fechaLimite"
                            DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80" HeaderStyle-Width="80" />--%>


                        <asp:ButtonField HeaderText="Mostrar" CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-search" HeaderStyle-Width="50" />
                        <asp:ButtonField HeaderText="Editar" CommandName="delete" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-edit" HeaderStyle-Width="50" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
