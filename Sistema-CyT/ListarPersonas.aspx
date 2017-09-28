﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPersonas.aspx.cs" Inherits="Sistema_CyT.ListarPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Lista de PERSONAS</h3>
            </div>
            <!--GRILLA PARA MOSTRAR LAS PERSONAS EN LA BASE DE DATOS-->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
                    <br />
                    <asp:GridView ID="dgvPersona" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-striped" BorderWidth="2px"
                        GridLines="Both" EmptyDataText="No existen personas registradas" ShowHeaderWhenEmpty="true"
                        OnSelectedIndexChanged="dgvPersona_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idPersona" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Apellido" DataField="apellido" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Telefono" DataField="telefono" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                            <asp:BoundField HeaderText="Correo Electronico" DataField="correoElectronico" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                            <asp:ButtonField Text="Actuaciones" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" CommandName="Select" ItemStyle-Width="80" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

