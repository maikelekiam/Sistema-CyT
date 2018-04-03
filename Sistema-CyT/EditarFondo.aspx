<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarFondo.aspx.cs" Inherits="Sistema_CyT.EditarFondo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Formulario EDITAR Fondo</h3>
            </div>

            <!-- LISTA CON LOS FONDOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblDdl" Font-Bold="true" runat="server" Text="&lt Seleccione FONDO &gt" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlActualizarFondo" runat="server"
                        BackColor="#ffff99"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="true"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlActualizarFondo_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>

            <!-- NOMBRE DEL FONDO -->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control tb5" TextMode="MultiLine" Rows="1"></asp:TextBox>
                </div>
            </div>

            <!-- DESCRIPCION DEL FONDO -->
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="DESCRIPCION" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-6 ">
                    <asp:TextBox ID="txtDecripcion" runat="server" CssClass="form-control tb5" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>

            <!-- ORIGEN DEL FONDO -->
            <div class="form-group">
                <asp:Label ID="lblOrigen" runat="server" Text="ORIGEN" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlOrigen" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                    </asp:DropDownList>
                </div>



                <%--AGREGAR ACA EL MODAL PARA NUEVO ORIGEN--%>
                <div class="form-group">
                    <div class="col-md-2">
                        <button type="button" class="btn boton_azul" data-toggle="modal" data-target="#modalOrigen">Nuevo Origen</button>
                    </div>
                    <!-- MODAL EMPRESA  -->
                    <div class="modal fade" id="modalOrigen" tabindex="-1" role="dialog" aria-labelledby="modalLabelOrigen" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h4 class="modal-title" id="modalLabelOrigen">Nuevo Origen</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOrigenModal" runat="server" CssClass="form-control"></asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" ID="btnModalOrigenSalir" Text="SALIR" class="btn btn-danger" data-dismiss="modal" />
                                        <asp:Button runat="server" ID="btnModalOrigenGuardar" Text="GUARDAR" CssClass="btn btn-success" OnClick="btnModalOrigenGuardar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- TELEFONO -->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 col-xs-6 control-label"> </asp:Label>
                <div class="col-md-6 col-xs-12">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control tb5"></asp:TextBox><br />
                </div>
            </div>
            <!-- DIRECCION -->
            <div class="form-group">
                <asp:Label ID="lblDireccion" runat="server" Text="DIRECCION" CssClass="col-md-2 col-xs-6 control-label"> </asp:Label>
                <div class="col-md-6 col-xs-12">
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control tb5"></asp:TextBox><br />
                </div>
            </div>
            <!-- CONTACTO -->
            <div class="form-group">
                <asp:Label ID="lblContacto" runat="server" Text="CONTACTO" CssClass="col-md-2 col-xs-6 control-label"> </asp:Label>
                <div class="col-md-6 col-xs-12">
                    <asp:TextBox ID="txtContacto" runat="server" CssClass="form-control tb5"></asp:TextBox><br />
                </div>
            </div>
            <!-- ACTIVO -->
            <div class="form-group">
                <asp:Label ID="lblActivo" runat="server" Text="ACTIVO" CssClass="col-md-2 control-label "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkActivo" runat="server" CssClass="control-label" BorderStyle="None" Checked="true" />
                </div>
            </div>

            <!-- BOTON ACTUALIZAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnActualizarFondo" runat="server" Text="Actualizar Fondo" CssClass="btn form-control boton_verde" OnClick="btnActualizarFondo_Click" />
                </div>
            </div>
        </asp:Panel>

        <!-- GRILLA CON TODOS LOS FONDOS -->
        <asp:Panel ID="PanelInferior" CssClass="panel" runat="server">
            <div class="panel-heading col-md-offset-1" style="height: 40px; padding: 0">
                <h3>Lista de Fondos Activos</h3>
            </div>
            <div class="form-group">
                <div class="col-md-9 col-md-offset-1">
                    <asp:GridView ID="dgvFondo" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both" EmptyDataText="No existen fondos registrados" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idFondo" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:BoundField HeaderText="Descripcion" DataField="descripcion" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="400" />
                            <asp:TemplateField HeaderText="Origen" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Origen.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Activo" DataField="activo" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                        </Columns>
                        <SelectedRowStyle BackColor="Azure" />
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
