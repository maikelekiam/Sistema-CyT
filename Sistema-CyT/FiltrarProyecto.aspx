<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FiltrarProyecto.aspx.cs" Inherits="Sistema_CyT.FiltrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-info" runat="server">

            <div class="panel-heading">
                <h3>Buscar PROYECTO</h3>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lblFondo" runat="server" Text="FONDO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlFondo" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="true"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlFondo_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Fondo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblAnio" runat="server" Text="AÑO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlAnio" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        AutoPostBack="true"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Año&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-9 col-md-offset-1">
                    <asp:GridView ID="dgvProyectos" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both"
                        OnSelectedIndexChanged="dgvProyectos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idProyecto" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="300" />
                            <asp:TemplateField HeaderText="Convocatoria" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="300">
                                <ItemTemplate>
                                    <asp:Label ID="lblConvocatoria" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Convocatorium.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField Text="Actuaciones" CommandName="Select" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <%--<div class="form-group">
                <div class="col-md-9 col-md-offset-1">
                    <asp:GridView ID="dgvConvocatorias" runat="server" AutoGenerateColumns="true"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both">
                    </asp:GridView>
                </div>
            </div>--%>
        </asp:Panel>
    </div>
</asp:Content>
