<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPersona.aspx.cs" Inherits="Sistema_CyT.AltaPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Formulario de ALTA Persona</h3>
            </div>
            <!--NOMBRE-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--APELLIDO-->
            <div class="form-group">
                <asp:Label ID="lblApellido" runat="server" Text="APELLIDO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--TIPO DOCUMENTO + DNI-->
            <div class="form-group">
                <asp:Label ID="lblTipoDocumento" runat="server" Text="TIPO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-1">
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        data-width="fit">
                        <asp:ListItem Value="DNI">DNI</asp:ListItem>
                        <asp:ListItem Value="DU">DU</asp:ListItem>
                        <asp:ListItem Value="LE">LE</asp:ListItem>
                        <asp:ListItem Value="CI">CI</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Label ID="lblDocumento" runat="server" Text="DOCUMENTO" class="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtDocumento" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <!--TELEFONO-->
            <div class="form-group">
                <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--CORREO ELECTRONICO-->
            <div class="form-group">
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="CORREO ELECTRONICO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--DOMICILIO-->
            <div class="form-group">
                <asp:Label ID="lblDomicilio" runat="server" Text="DOMICILIO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--LOCALIDAD-->
            <div class="form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="LOCALIDAD" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlLocalidad" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="False"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Localidad&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--OBSERVACIONES-->
            <div class="form-group">
                <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!-- BOTON GUARDAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnGuardarPersona" runat="server" Text="Guardar Persona" CssClass="btn btn-success form-control" OnClick="btnGuardarPersona_Click" />
                </div>
            </div>
        </asp:Panel>
        <!--GRILLA PARA MOSTRAR LAS PERSONAS EN LA BASE DE DATOS-->
        <h4>GRILLA DE PERSONAS</h4>
        <div class="form-group">
            <div class="col-md-9 col-md-offset-1">
                <asp:GridView ID="dgvPersona" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" BorderWidth="2px"
                    GridLines="Both" EmptyDataText="No existen personas registradas" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="idPersona" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Apellido" DataField="apellido" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Telefono" DataField="telefono" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Correo Electronico" DataField="correoElectronico" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
