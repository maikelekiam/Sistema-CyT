<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUdtUvt.aspx.cs" Inherits="Sistema_CyT.AltaUdt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="Panel1" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Formulario de ALTA UDT/UVT</h3>
            </div>
            <!--TIPO-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblTipo" runat="server" Text="TIPO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlTipo" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">&lt;Seleccione Tipo&gt;</asp:ListItem>
                        <asp:ListItem Value="0">UDT</asp:ListItem>
                        <asp:ListItem Value="2">UVT</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--NOMBRE-->
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <!--REFERENTE TECNICO-->
            <div class="form-group">
                <asp:Label ID="lblReferenteTecnico" runat="server" Text="REFERENTE TECNICO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlReferenteTecnico" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlReferenteTecnico_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--DIRECTOR / GERENTE-->
            <div class="form-group">
                <asp:Label ID="lblDirectorGerente" runat="server" Text="DIRECTOR / GERENTE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlDirectorGerente" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        CssClass="selectpicker form-control show-tick"
                        data-live-search="true"
                        DataTextField="nombre"
                        AutoPostBack="false"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlDirectorGerente_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Persona&gt;</asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:Button ID="btnGuardarUdtUvt" runat="server" Text="Guardar" CssClass="btn btn-success form-control" OnClick="btnGuardarUdtUvt_Click" />
                </div>
            </div>
        </asp:Panel>
        <!--GRILLA PARA MOSTRAR LAS UDT/UVT EN LA BASE DE DATOS-->
        <h4>GRILLA DE UDT/UVT</h4>
        <div class="form-group">
            <div class="col-md-9 col-md-offset-1">
                <asp:GridView ID="dgvUdtUvt" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" BorderWidth="2px"
                    GridLines="Both" EmptyDataText="No existen UDT/UVT registradas" ShowHeaderWhenEmpty="true"
                    >
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="idUdtUvt" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Telefono" DataField="telefono" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                        <asp:BoundField HeaderText="Correo Electronico" DataField="correoElectronico" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#cccccc" />
                        
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
