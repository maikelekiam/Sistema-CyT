<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarFondo.aspx.cs" Inherits="Sistema_CyT.EditarFondo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>Formulario EDITAR Fondo</h3>
            </div>

            <!-- LISTA CON LOS FONDOS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblDdl" Font-Bold="true" runat="server" Text="&lt Seleccione FONDO &gt" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlActualizarFondo" runat="server"
                        Width="280"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="form-control"
                        DataTextField="nombre"
                        AutoPostBack="True"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlActualizarFondo_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>

            <!-- NOMBRE DEL FONDO -->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 col-xs-6 control-label"> </asp:Label>
                <div class="col-md-6 col-xs-12 ">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox><br />
                </div>
            </div>

            <!-- DESCRIPCION DEL FONDO -->
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="DESCRIPCION" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-6 ">
                    <asp:TextBox ID="txtDecripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox><br />
                </div>
            </div>

            <!-- ORIGEN DEL FONDO -->
            <div class="form-group">
                <asp:Label ID="lblOrigen" runat="server" Text="ORIGEN" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlOrigen" runat="server"
                        Width="280"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        AutoPostBack="true"
                        DataTextField="nombre">
                        <asp:ListItem Value="-1">&lt;Seleccione Origen&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- BOTON ACTUALIZAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnActualizarFondo" runat="server" Text="Actualizar Fondo" CssClass="btn btn-info form-control" OnClick="btnActualizarFondo_Click" />
                </div>
            </div>
        </asp:Panel>

        <!-- GRILLA CON TODOS LOS FONDOS -->
        <asp:Panel ID="PanelInferior" CssClass="panel" runat="server">
            <div class="form-group">
                <div class="col-md-9 col-md-offset-1">
                    <asp:GridView ID="dgvFondo" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-bordered table-striped" BorderWidth="3px"
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
