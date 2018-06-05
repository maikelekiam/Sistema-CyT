<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActuacionesPersona.aspx.cs" Inherits="Sistema_CyT.ActuacionesPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelPersona" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>
                    <asp:Label ID="lblPersona" runat="server" CssClass="col-md-12"></asp:Label>
                </h3>
                <%--<asp:Label ID="lblPersona" Style="text-align: justify;" Font-Bold="true" runat="server" CssClass="col-md-12 control-label"></asp:Label>--%>
                <br />
                <br />
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelActuacion" CssClass="panel" runat="server">
            <!-- BOTON AGREGAR ACTUACION -->
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Button ID="btnAgregarActuacion" runat="server" Text="Agregar Actuacion" CssClass="boton_azul" OnClick="btnAgregarActuacion_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelNuevaActuacion" CssClass="panel panel-success" runat="server">
            <div class="panel-body">
                <!--FECHA DE LA ACTUACION-->
                <div class="form-group">
                    <asp:Label ID="lblFechaActuacion" runat="server" Text="FECHA DE ACTUACION" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
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
            <!--VIA DE COMUNICACION + OPCION PARA AGREGAR NUEVA VIA DE COMUNICACION-->
            <div class="form-group">
                <asp:Label ID="lblViaComunicacion" runat="server" Text="VIA DE COMUNICACION" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlViaComunicacion" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Via Comunicacion&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--AGREGAR ACA EL MODAL PARA LA NUEVA VIA DE COMUNICACION--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="boton_azul" style="width: 250px;" data-toggle="modal" data-target="#modalViaComunicacion">Nueva Via de Comunicacion</button>
                    </div>
                    <!-- MODAL VIA DE COMUNICACION  -->
                    <div class="modal fade" id="modalViaComunicacion" tabindex="-1" role="dialog" aria-labelledby="modalLabelViaComunicacion" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelViaComunicacion">Nueva Via de Comunicacion</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtViaComunicacionModal" runat="server" Width="450" CssClass="tb5"></asp:TextBox><br />
                                    </div>

                                </div>
                                <div class="modal-footer">

                                    <div class="form-group col-md-12">
                                        <br />
                                        <div class="col-md-5">
                                            <asp:Button runat="server" ID="btnModalViaComunicacionSalir" Text="Salir" CssClass="boton_rojo" data-dismiss="modal" />
                                        </div>
                                        <div class="col-md-5">
                                            <asp:Button runat="server" ID="btnModalViaComunicacionGuardar" Text="Guardar" CssClass="boton_verde" OnClick="btnModalViaComunicacionGuardar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <!--DETALLE DE LA ACTUACION-->
            <div class="form-group">
                <asp:Label ID="lblDetalle" runat="server" Text="DETALLE" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
            </div>
            <!--BOTONES GUARDAR + CANCELAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnGuardarActuacion" runat="server" Text="Guardar" Width="180" CssClass="boton_verde" OnClick="btnGuardarActuacion_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="180" CssClass="boton_rojo" OnClick="btnCancelar_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnActualizarActuacion" runat="server" Width="180" Text="Actualizar" CssClass="boton_verde" OnClick="btnActualizarActuacion_Click" />
                </div>
            </div>
        </asp:Panel>

        <!--GRILLA CON LAS ACTUACIONES-->
        <asp:Label ID="lblGrillaActuaciones" runat="server" Text="GRILLA DE ACTUACIONES">
                <h4>ACTUACIONES REALIZADAS</h4>
        </asp:Label>
        <div class="form-group">
            <div class="col-md-10 col-md-offset-1">
                <asp:GridView ID="dgvActuaciones" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" BorderWidth="2px" GridLines="Both"
                    OnSelectedIndexChanging="dgvActuaciones_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="idA" DataField="idActuacionPersona" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderText="Fecha" DataField="fecha"
                            DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80" HeaderStyle-Width="80" />
                        <asp:TemplateField HeaderText="Via" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="80">
                            <ItemTemplate>
                                <asp:Label ID="lblViaComunicacion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ViaComunicacion.Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Detalle" DataField="detalle"
                            ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="100" HeaderStyle-Width="300" />
                        <%--                        <asp:ButtonField Text="Editar" CommandName="select" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="80" />--%>
                        <asp:ButtonField CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="30" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-edit" ItemStyle-Width="30" HeaderStyle-Width="30" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
