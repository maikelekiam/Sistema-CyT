﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarOrganismos.aspx.cs" Inherits="Sistema_CyT.ListarOrganismos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>ORGANISMOS</h3>
                <asp:Label ID="lblOrganismo" Font-Bold="true" runat="server" CssClass="col-md-2 control-label"> </asp:Label>

            </div>
            <!--GRILLA PARA MOSTRAR Organismos EN LA BASE DE DATOS-->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
                    <br />
                    <asp:GridView ID="dgvOrganismo" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both" EmptyDataText="No existen Organismos registradas" ShowHeaderWhenEmpty="true"
                        OnSelectedIndexChanging="dgvOrganismo_SelectedIndexChanging"
                        >
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idOrganismo" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" ItemStyle-CssClass="text-uppercase" />
                            <asp:BoundField HeaderText="Telefono" DataField="telefono" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Correo Electronico" DataField="correoElectronico" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" ItemStyle-CssClass="text-lowercase"/>
                            <asp:ButtonField HeaderText="Detalles" CommandName="select" HeaderStyle-BackColor="#cccccc" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ControlStyle-CssClass="glyphicon glyphicon-search" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
