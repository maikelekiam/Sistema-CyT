<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarConvocatorias.aspx.cs" Inherits="Sistema_CyT.ListarConvocatorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Lista de Convocatorias</h3>
            </div>
            <div class="form-group">
                <br />
                <asp:Label ID="lblEstado" runat="server" Text="ESTADO" CssClass="col-md-1 AlineadoDerecha"></asp:Label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlEstado" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                    </asp:DropDownList>
                </div>
                <asp:Label ID="lblFiltroFondo" runat="server" Text="FONDO" CssClass="col-md-1 AlineadoDerecha"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlFiltroFondo" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Fondo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button runat="server" ID="btnFiltrarConvocatorias" Text="FILTRAR" CssClass="boton_verde" OnClick="btnFiltrarConvocatorias_Click" />
                <asp:Button runat="server" ID="btnFiltrarConvocatoriasAbiertas" Text="ABIERTAS" CssClass="boton_azul" OnClick="btnFiltrarConvocatoriasAbiertas_Click" />
            </div>

            <asp:Button runat="server" ID="btnFiltrarConvocatoriasTodas" Text="TODAS" CssClass="boton_azul" OnClick="btnFiltrarConvocatoriasTodas_Click" />

            <div class="form-group">
                <br />
                <div class="col-md-12">
                    <asp:GridView ID="dgvConvocatoria" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both"
                        OnRowDeleting="dgvConvocatoria_RowDeleting">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idConvocatoria" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="AÑO" DataField="anio" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="100" />
                            <asp:BoundField HeaderText="NOMBRE" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="500" />
                            <asp:TemplateField HeaderText="FONDO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fondo.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TIPO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoFinanciamiento.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="APERTURA" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaApertura" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderText="CIERRE" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaCierre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="250" />
                            <asp:ButtonField HeaderText="Detalles" CommandName="delete" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-search" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
