<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUdtUvt.aspx.cs" Inherits="Sistema_CyT.AltaUdt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Nueva UDT / UVT</h3>
            </div>
            <!--TIPO-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblTipo" runat="server" Text="TIPO" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlTipo" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Tipo&gt;</asp:ListItem>
                        <asp:ListItem Value="0">UDT</asp:ListItem>
                        <asp:ListItem Value="1">UVT</asp:ListItem>
                        <asp:ListItem Value="2">UDT / UVT</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--NOMBRE-->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--REFERENTE TECNICO-->
            <div class="form-group">
                <asp:Label ID="lblReferenteTecnico" runat="server" Text="REFERENTE TECNICO" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlReferenteTecnico" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlReferenteTecnico_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--NUEVO REFERENTE TECNICO--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="boton_azul" style="width: 250px" data-toggle="modal" data-target="#modalReferenteTecnico">Nuevo Referente Tecnico</button>
                    </div>
                    <!-- MODAL NUEVO REFERENTE TECNICO  -->
                    <div class="modal fade" id="modalReferenteTecnico" tabindex="-1" role="dialog" aria-labelledby="modalLabelReferenteTecnico" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelReferenteTecnico">Nuevo Referente Tecnico</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <asp:Label ID="lblReferenteTecnicoNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtReferenteTecnicoNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblReferenteTecnicoApellidoModal" runat="server" Text="APELLIDO" CssClass="col-md-4 control-label"> </asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtReferenteTecnicoApellidoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblReferenteTecnicoTelefonoModal" runat="server" Text="TELEFONO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtReferenteTecnicoTelefonoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblReferenteTecnicoCorreoElectronicoModal" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtReferenteTecnicoCorreoElectronicoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="btnModalReferenteTecnicoSalir" Text="Salir" class="boton_rojo" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalReferenteTecnicoGuardar" Text="Guardar" CssClass="boton_verde" OnClick="btnModalReferenteTecnicoGuardar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--DIRECTOR / GERENTE-->
            <div class="form-group">
                <asp:Label ID="lblDirectorGerente" runat="server" Text="DIRECTOR / GERENTE" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlDirectorGerente" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlDirectorGerente_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--NUEVO DIRECTOR / GERENTE--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="boton_azul" style="width: 250px" data-toggle="modal" data-target="#modalDirectorGerente">Nuevo Director / Gerente</button>
                    </div>
                    <!-- MODAL NUEVO DIRECTOR / GERENTE  -->
                    <div class="modal fade" id="modalDirectorGerente" tabindex="-1" role="dialog" aria-labelledby="modalLabelDirectorGerente" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelDirectorGerente">Nuevo Director / Gerente</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <asp:Label ID="lblDirectorGerenteNombreModal" runat="server" Text="NOMBRE" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDirectorGerenteNombreModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblDirectorGerenteApellidoModal" runat="server" Text="APELLIDO" CssClass="col-md-4 control-label"> </asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDirectorGerenteApellidoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblDirectorGerenteTelefonoModal" runat="server" Text="TELEFONO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDirectorGerenteTelefonoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblDirectorGerenteCorreoElectronicoModal" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-4 control-label"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDirectorGerenteCorreoElectronicoModal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="btnModalDirectorGerenteSalir" Text="Salir" class="boton_rojo" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalDirectorGerenteGuardar" Text="Guardar" CssClass="boton_verde" OnClick="btnModalDirectorGerenteGuardar_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!--TELEFONO-->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--CORREO ELECTRONICO-->
            <div class="form-group">
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--DOMICILIO-->
            <div class="form-group">
                <asp:Label ID="lblDomicilio" runat="server" Text="DOMICILIO" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--LOCALIDAD-->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="LOCALIDAD" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
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
            </div>
            <!--OBSERVACIONES-->
            <div class="form-group">
                <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 AlineadoDerecha"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- BOTON GUARDAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnGuardarUdtUvt" runat="server" Text="Guardar" Width="180" CssClass="boton_verde" OnClick="btnGuardarUdtUvt_Click" />
                </div>
            </div>
        </asp:Panel>
        <!--GRILLA PARA MOSTRAR LAS UDT/UVT EN LA BASE DE DATOS-->
        <%--<h4>GRILLA DE UDT/UVT</h4>--%>
        <br />
        <div class="form-group">
            <div class="col-md-9 col-md-offset-1">
                <asp:GridView ID="dgvUdtUvt" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" BorderWidth="2px"
                    GridLines="Both" EmptyDataText="No existen UDT/UVT registradas" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="idUdtUvt" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Telefono" DataField="telefono" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Correo Electronico" DataField="correoElectronico" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
