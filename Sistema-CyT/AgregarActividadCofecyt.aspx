<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarActividadCofecyt.aspx.cs" Inherits="Sistema_CyT.AgregarActividadCofecyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3 id="lblPanelSuperiorTitulo" runat="server">Proyecto</h3>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelInformacionProyecto" CssClass="panel panel-default" runat="server">
            <div class="form-group">
                <br />
                <asp:Label ID="lblEtapa" runat="server" Text="ETAPA" CssClass="col-md-3 AlineadoDerecha"></asp:Label>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlEtapa" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Etapa&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--NOMBRE-->
            <div class="form-group">
                <asp:Label ID="lblNombreActividad" runat="server" Text="NOMBRE DE LA ACTIVIDAD" CssClass="col-md-3 AlineadoDerecha"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNombreActividad" TextMode="MultiLine" Rows="2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--BREVE DESCRIPCION-->
            <div class="form-group">
                <asp:Label ID="lblDescripcionActividad" runat="server" Text="BREVE DESCRIPCION" CssClass="col-md-3 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtDescripcionActividad" TextMode="MultiLine" Rows="2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--RESULTADOS ESPERADOS-->
            <div class="form-group">
                <asp:Label ID="lblResultadosEsperadosActividad" runat="server" Text="RESULTADOS ESPERADOS" CssClass="col-md-3 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtResultadosEsperadosActividad" TextMode="MultiLine" Rows="2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--LOCALIZACION-->
            <div class="form-group">
                <asp:Label ID="lblLocalizacionActividad" runat="server" Text="LOCALIZACION" CssClass="col-md-3 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtLocalizacionActividad" TextMode="MultiLine" Rows="1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- BOTON GUARDAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-1">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="180" CssClass="boton_verde" OnClick="btnGuardar_Click"></asp:Button>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" Width="180" CssClass="boton_rojo" OnClick="btnVolver_Click"></asp:Button>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" Width="180" CssClass="boton_verde" OnClick="btnActualizar_Click"></asp:Button>
                </div>
            </div>
        </asp:Panel>
        <!--LISTA DE ACTIVIDADES-->
        <div class="form-group">
            <div class="col-md-12">
                <asp:GridView ID="dgvActividades" runat="server" AutoGenerateColumns="false"
                    DataKeyNames="idActividadCofecyt"
                    OnSelectedIndexChanging="dgvActividades_SelectedIndexChanging"
                    CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen actividades cargadas" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Id" DataField="idActividadCofecyt" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="30" />
                        <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Etapa" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EtapaCofecyt.Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Actividad" DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Resultados Esperados" DataField="resultadosEsperados" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Localizacion" DataField="localizacion" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150" />
                        <asp:ButtonField CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="30" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-edit" ItemStyle-Width="30" HeaderStyle-Width="30" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
