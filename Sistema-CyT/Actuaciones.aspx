﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actuaciones.aspx.cs" Inherits="Sistema_CyT.Actuaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyecto" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h4>
                    <asp:Label ID="lblProyecto" runat="server" CssClass="col-md-12" Font-Size="Larger"></asp:Label>
                    <br />
                    <br />
                </h4>
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
            <!--CONTACTO-->
            <div class="form-group">
                <asp:Label ID="lblContacto" runat="server" Text="REFERENTE" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
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
                <%--DETALLE DEL CONTACTO--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="boton_azul" data-toggle="modal" data-target="#modalContacto">Nuevo Contacto</button>
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
                                        <asp:Button runat="server" ID="btnModalContactoSalir" Text="Salir" class="boton_rojo" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalContactoGuardar" Text="Guardar" CssClass="boton_verde" OnClick="btnModalContactoGuardar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--ORGANISMO + OPCION PARA AGREGAR NUEVO ORGANISMO-->
            <div class="form-group">
                <asp:Label ID="lblOrganismo" runat="server" Text="ORGANISMO" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlOrganismo" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
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
                        <button type="button" class="boton_azul" data-toggle="modal" data-target="#modalOrganismo">Nuevo Organismo</button>
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
                                        <asp:Label ID="lbl01" runat="server" Text="NOMBRE" CssClass="col-md-4 AlineadoDerecha"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOrganismoNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        <asp:Label ID="lbl02" runat="server" Text="TELEFONO" CssClass="col-md-4 AlineadoDerecha"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOrganismoTelefonoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                        <asp:Label ID="lbl03" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-4 AlineadoDerecha"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOrganismoCorreoElectronicoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="btnModalOrganismoSalir" Text="Salir" class="boton_rojo" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalOrganismoGuardar" Text="Guardar" CssClass="boton_verde" OnClick="btnModalOrganismoGuardar_Click" />
                                    </div>
                                </div>
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
                        CssClass="selectpicker form-control show-tick"
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
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="NOMBRE" CssClass="col-md-4 AlineadoDerecha"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtViaComunicacionModal" runat="server" CssClass="form-control"></asp:TextBox><br />
                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" ID="btnModalViaComunicacionSalir" Text="Salir" class="boton_rojo" data-dismiss="modal" />
                                    <asp:Button runat="server" ID="btnModalViaComunicacionGuardar" Text="Guardar" CssClass="boton_verde" OnClick="btnModalViaComunicacionGuardar_Click" />
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
                    <asp:Button ID="btnGuardarActuacion" runat="server" Text="Guardar Actuacion" CssClass="boton_verde" OnClick="btnGuardarActuacion_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton_rojo" OnClick="btnCancelar_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnActualizarActuacion" runat="server" Text="Actualizar Actuacion" CssClass="boton_verde" OnClick="btnActualizarActuacion_Click" />
                </div>
            </div>
        </asp:Panel>

        <!--GRILLA CON LAS ACTUACIONES-->
        <asp:Label ID="lblGrillaActuaciones" runat="server" Text="GRILLA DE ACTUACIONES">
                <h3>Actuaciones Realizadas</h3>
        </asp:Label>
        <div class="form-group">
            <div class="col-md-12">
                <asp:GridView ID="dgvActuaciones" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" BorderWidth="2px" GridLines="Both"
                    OnSelectedIndexChanging="dgvActuaciones_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="idActuacion" DataField="idActuacion" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderText="idP" DataField="idProyecto" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        <asp:BoundField HeaderText="Fecha" DataField="fecha"
                            DataFormatString="{0:dd-MMM-yyyy}" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80" HeaderStyle-Width="80" />
                        <asp:TemplateField HeaderText="Nombre" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="80">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Persona.Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="80">
                            <ItemTemplate>
                                <asp:Label ID="lblApellido" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Persona.Apellido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Organismo" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="80">
                            <ItemTemplate>
                                <asp:Label ID="lbl23" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Organismo.Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Via" HeaderStyle-BackColor="#cccccc" HeaderStyle-Width="80">
                            <ItemTemplate>
                                <asp:Label ID="lblViaComunicacion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ViaComunicacion.Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Detalle" DataField="detalle"
                            ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="100" HeaderStyle-Width="300" />
                        <asp:ButtonField CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="30" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-edit" ItemStyle-Width="30" HeaderStyle-Width="30" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
