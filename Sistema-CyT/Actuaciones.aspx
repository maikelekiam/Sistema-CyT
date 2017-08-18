<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actuaciones.aspx.cs" Inherits="Sistema_CyT.Actuaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyecto" CssClass="panel panel-success" runat="server">
            <div class="panel-heading">
                <br />
                <asp:Label ID="lblProyecto" Style="text-align: left; font-size: large;" Font-Bold="true" runat="server" CssClass="col-md-12 control-label"></asp:Label>
                <br />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelActuacion" CssClass="panel" runat="server">
            <!-- BOTON AGREGAR ACTUACION -->
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Button ID="btnAgregarActuacion" runat="server" Text="Agregar Actuacion" CssClass="btn btn-info form-control" OnClick="btnAgregarActuacion_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelNuevaActuacion" CssClass="panel panel-success" runat="server">
            <div class="panel-body">
                <!--FECHA DE LA ACTUACION-->
                <div class="form-group">
                    <asp:Label ID="lblFechaActuacion" runat="server" Text="FECHA DE ACTUACION" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-4">
                        <div class="input-group date"
                            data-provide="datepicker"
                            
                            data-date-autoclose="true"
                            data-date-today-btn="true"
                            data-date-clear-btn="true"
                            data-date-today-highlight="true">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaActuacion"></asp:TextBox>
                            <div class="input-group-addon">
                                <span class="glyphicon glyphicon-th"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!--ORGANISMO + OPCION PARA AGREGAR NUEVO ORGANISMO-->
            <div class="form-group">
                <asp:Label ID="lblOrganismo" runat="server" Text="ORGANISMO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlOrganismo" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Organismo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <%--AGREGAR ACA EL MODAL PARA EL NUEVO ORGANISMO--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#modalOrganismo">Nuevo Organismo</button>
                    </div>
                    <!-- MODAL ORGANISMO  -->
                    <div class="modal fade" id="modalOrganismo" tabindex="-1" role="dialog" aria-labelledby="modalLabelOrganismo" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelOrganismo">Nuevo Organismo</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <asp:Label ID="lbl01" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOrganismoNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        <asp:Label ID="lbl02" runat="server" Text="TELEFONO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOrganismoTelefonoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        <asp:Label ID="lbl03" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOrganismoCorreoElectronicoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="btnModalOrganismoSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalOrganismoGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalOrganismoGuardar_Click" />
                                    </div>
                                </div>
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
            <!--BOTONES GUARDAR + CANCELAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnGuardarActuacion" runat="server" Text="Guardar Actuacion" CssClass="btn btn-success form-control" OnClick="btnGuardarActuacion_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger form-control" OnClick="btnCancelar_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnActualizarActuacion" runat="server" Text="Actualizar Actuacion" CssClass="btn btn-success form-control" OnClick="btnActualizarActuacion_Click" />
                </div>
            </div>
        </asp:Panel>

        <!--GRILLA CON LAS ACTUACIONES-->
        <asp:Label ID="lblGrillaActuaciones" runat="server" Text="GRILLA DE ACTUACIONES">
                <h4>ACTUACIONES REALIZADAS</h4>
        </asp:Label>
        <div class="form-group">
            <div class="col-md-9 col-md-offset-1">
                <asp:GridView ID="dgvActuaciones" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" BorderWidth="2px" GridLines="Both"
                    OnSelectedIndexChanging="dgvActuaciones_SelectedIndexChanging"
                    OnRowDeleting="dgvActuaciones_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="idActuacion" DataField="idActuacion" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderText="idP" DataField="idProyecto" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderText="Fecha" DataField="fecha"
                            DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50" HeaderStyle-Width="80" />
                        <asp:TemplateField HeaderText="Organismo" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lbl23" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Organismo.Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Detalle" DataField="detalle"
                            ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="100" HeaderStyle-Width="300" />
                        <asp:ButtonField Text="Editar" CommandName="select" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="80" />
                        <asp:ButtonField Text="Borrar" CommandName="delete" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="80" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
