<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPersonas.aspx.cs" Inherits="Sistema_CyT.ListarPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Lista de CONTACTOS</h3>
<%--                <asp:Label ID="lblFondo" Font-Bold="true" runat="server" CssClass="col-md-2 control-label"> </asp:Label>--%>

            </div>
            <!--GRILLA PARA MOSTRAR LAS PERSONAS EN LA BASE DE DATOS-->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
                    <br />
                    <asp:GridView ID="dgvPersona" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both" EmptyDataText="No existen personas registradas" ShowHeaderWhenEmpty="true"
                        OnSelectedIndexChanging="dgvPersona_SelectedIndexChanging"
                        OnRowDeleting="dgvPersona_RowDeleting">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idPersona" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Apellido" DataField="apellido" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Telefono" DataField="telefono" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Correo Electronico" DataField="correoElectronico" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />

                            <asp:ButtonField HeaderText="Actuaciones" CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-list" />
                            <asp:ButtonField HeaderText="Detalles" CommandName="delete" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-search" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

