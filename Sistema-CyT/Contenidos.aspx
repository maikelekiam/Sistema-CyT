﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contenidos.aspx.cs" Inherits="Sistema_CyT.Contenidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyectos" CssClass="panel panel-default" runat="server">
            <div class="form-group">
                <div class="col-md-6">
                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                    <asp:Button Text="Cargar Proyectos COFECyT" Width="250" CssClass="btn form-control boton_azul" OnClick="Upload2" runat="server" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
