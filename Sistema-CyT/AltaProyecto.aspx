<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaProyecto.aspx.cs" Inherits="Sistema_CyT.AltaProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Nuevo Proyecto</h3>
            </div>
            <!-- LISTA CON LOS FONDOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblFondoChoice" runat="server" Text="FONDO" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
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
                <asp:Label ID="lblConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlConvocatoria" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Width="100%"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="false">
                        <asp:ListItem Value="-1">&lt;Seleccione Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <!--PANEL DE PROYECTO SIMPLE-->
        <asp:Panel ID="PanelInformacion" CssClass="panel panel-default" runat="server">
            <!--CODIGO INTERNO-->
            <div class="form-group">
                <br />
                <asp:Label ID="lblCodigoInterno" runat="server" Text="CODIGO INTERNO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtCodigoInterno" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--EXPEDIENTE COPADE-->
            <div class="form-group">
                <asp:Label ID="lblNumeroExp" runat="server" Text="N°EXPEDIENTE" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
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
                <div class="col-md-9">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--OBJETIVOS DEL PROYECTO-->
            <div class="form-group">
                <asp:Label ID="lblObjetivos" runat="server" Text="OBJETIVOS" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-9">
                    <asp:TextBox ID="txtObjetivos" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--BREVE DESCRIPCION-->
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="BREVE DESCRIPCION" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-9">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--DESTINATARIOS DEL PROYECTO-->
            <div class="form-group">
                <asp:Label ID="lblDestinatarios" runat="server" Text="DESTINATARIOS" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-9">
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
                        <button type="button" class="boton_azul" data-toggle="modal" data-target="#modalLocalidad">Nueva Localidad</button>
                    </div>
                    <!-- MODAL NUEVA LOCALIDAD  -->
                    <div class="modal fade" id="modalLocalidad" tabindex="-1" role="dialog" aria-labelledby="modalLabelLocalidad" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h3 class="modal-title" id="modalLabelLocalidad">Nueva Localidad</h3>
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
                                        <asp:Button runat="server" ID="btnModalLocalidadSalir" Text="Salir" class="boton_rojo" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalLocalidadGuardar" Text="Guardar" CssClass="boton_verde" OnClick="btnModalLocalidadGuardar_Click" />
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
                <div class="col-md-9">
                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
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
                    <asp:TextBox ID="txtMontoSolicitado" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO CONTRAPARTE-->
            <div class="form-group">
                <asp:Label ID="lblMontoContraparte" runat="server" Text="MONTO CONTRAPARTE" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoContraparte" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--MONTO TOTAL-->
            <div class="form-group">
                <asp:Label ID="lblMontoTotal" runat="server" Text="MONTO TOTAL" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                <div class="col-md-4 col-xs-12">
                    <asp:TextBox ID="txtMontoTotal" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <!--CONTACTO REFERENTE-->
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
                <%--NUEVO CONTACTO--%>
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
                                    <h3 class="modal-title" id="modalLabelContacto">Nuevo Contacto</h3>
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

            <!--EMPRESA-->
            <div class="form-group">
                <asp:Label ID="lblEmpresa" runat="server" Text="EMPRESA" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
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
                    <button type="button" class="boton_azul" data-toggle="modal" data-target="#modalEmpresa">Nueva Empresa</button>
                </div>
                <!-- MODAL NUEVA EMPRESA  -->
                <div class="modal fade" id="modalEmpresa" tabindex="-1" role="dialog" aria-labelledby="modalLabelEmpresa" aria-hidden="true">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <h3 class="modal-title" id="modalLabelEmpresa">Nueva Empresa</h3>
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
                                    <asp:Button runat="server" ID="btnModalEmpresaSalir" Text="Salir" class="boton_rojo" data-dismiss="modal" />
                                    <asp:Button runat="server" ID="btnModalEmpresaGuardar" Text="Guardar" CssClass="boton_verde" OnClick="btnModalEmpresaGuardar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--ESTADO del Proyecto Simple-->
            <div class="form-group">
                <asp:Label ID="lblTipoEstado" runat="server" Text="ESTADO" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
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

        <!--BOTON Guardar PROYECTO  -->
        <div class="form-group">
            <div class="col-md-2 col-md-offset-2">
                <asp:Button ID="btnGuardarProyecto" runat="server" Text="Guardar Proyecto" CssClass="boton_verde" OnClick="btnGuardarProyecto_Click" />
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />

    </div>
</asp:Content>
