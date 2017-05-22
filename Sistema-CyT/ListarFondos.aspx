﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarFondos.aspx.cs" Inherits="Sistema_CyT.ListarFondos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="Panel1" runat="server">
            <div class="panel-heading">
                <h3>Listado de FONDOS</h3>
            </div>
            <div class="form-group">
                <div class="col-md-9 col-md-offset-1">
                    <asp:GridView ID="dgvFondos" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover table-bordered table-striped" BorderWidth="2px"
                        GridLines="Both"
                        OnRowCommand="dgvFondos_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="idFondo" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="200" />
                            <asp:BoundField HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="500" />
                            <asp:TemplateField HeaderText="Origen" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Origen.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Activo" DataField="activo" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="Azure" />
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>


</asp:Content>
