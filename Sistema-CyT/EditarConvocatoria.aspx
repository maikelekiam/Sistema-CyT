<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarConvocatoria.aspx.cs" Inherits="Sistema_CyT.EditarConvocatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="PanelSuperior" CssClass="panel panel-info" runat="server">
            <div class="panel-heading">
                <h3>Formulario EDITAR Convocatoria</h3>
            </div>

            <!-- LISTA CON LAS CONVOCATORIAS EN LA BASE DE DATOS -->
            <div class="form-group">
                <br />
                <asp:Label ID="lblDdl" Font-Bold="true" runat="server" Text="&lt Seleccione Convocatoria &gt" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlActualizarConvocatoria" runat="server"
                        BackColor="#ffff99"
                        ForeColor="#000066"
                        Font-Bold="true"
                        CssClass="form-control"
                        DataTextField="nombre"
                        AutoPostBack="True"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlActualizarConvocatoria_SelectedIndexChanged">
                        <asp:ListItem Value="-1">&lt;Seleccione Convocatoria&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!--NOMBRE-->
            <br />
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                </div>
            </div>
            <!--DESCRIPCION-->
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="DESCRIPCION" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--OBJETIVO-->
            <div class="form-group">
                <asp:Label ID="lblObjetivo" runat="server" Text="OBJETIVO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtObjetivo"    runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <!--AÑO y FONDO-->
            <div class="form-group">
                <asp:Label ID="lblAnio" runat="server" Text="AÑO" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtAnio" Width="260" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                </div>
                <asp:Label ID="lblFondo" runat="server" Text="FONDO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlFondo" runat="server"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre"
                        AutoPostBack="false">
                        <asp:ListItem Value="-1">&lt;Seleccione Fondo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- TIPO DE FINANCIAMIENTO Y TIPO DE CONVOCATORIA -->
            <div class="form-group">
                <asp:Label ID="lblTipoFinanciamiento" runat="server" Text="TIPO FINANCIAMIENTO" CssClass="col-md-2 control-label"> </asp:Label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlTipoFinanciamiento" runat="server"
                        Width="100%"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre">
                        <asp:ListItem Value="-1">&lt;Seleccione Tipo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Label ID="lblTipoConvocatoria" runat="server" Text="TIPO CONVOCATORIA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlTipoConvocatoria" runat="server"
                        Width="100%"
                        BackColor="WhiteSmoke"
                        ForeColor="#000066"
                        Font-Bold="false"
                        CssClass="selectpicker form-control show-tick"
                        DataTextField="nombre">
                        <asp:ListItem Value="-1">&lt;Seleccione Tipo&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- FECHA DE APERTURA Y FECHA DE CIERRE -->
            <div class="form-group">
                <asp:Label ID="lblFechaApertura" runat="server" Text="FECHA APERTURA" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-format="dd/mm/yyyy"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaApertura"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
                <asp:Label ID="lblFechaCierre" runat="server" Text="FECHA CIERRE" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <div class="input-group date"
                        data-provide="datepicker"
                        data-date-format="dd/mm/yyyy"
                        data-date-autoclose="true"
                        data-date-today-btn="true"
                        data-date-clear-btn="true"
                        data-date-today-highlight="true">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaCierre"></asp:TextBox>
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblAbierta" runat="server" Text="ESTA ABIERTA ?" CssClass="col-md-2 control-label "></asp:Label>
                <div class="col-md-1">
                    <asp:CheckBox ID="chkAbierta" runat="server" CssClass="control-label" BorderStyle="None" Checked="true" />
                </div>
            </div>
            <!-- BOTON ACTUALIZAR -->
            <div class="form-group">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button ID="btnActualizarConvocatoria" runat="server" Text="Actualizar Convocatoria" CssClass="btn btn-info form-control" OnClick="btnActualizarConvocatoria_Click" />
                </div>
            </div>
        </asp:Panel>
        <!--LISTA DE MODALIDADES CARGADAS-->
        <div class="panel-heading">
            <h3>Modalidades de la Convocatoria</h3>
        </div>
        <div class="form-group">
            <div class="col-md-12">
                <asp:GridView ID="dgvModalidades" runat="server" AutoGenerateColumns="false"
                    DataKeyNames="idModalidad"
                    CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen modalidades cargadas" ShowHeaderWhenEmpty="true"
                    OnSelectedIndexChanging="dgvModalidades_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="ID" DataField="idModalidad" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Nombre" DataField="nombre" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Objetivo" DataField="objetivo" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Monto Maximo" DataField="montoMaximoProyecto" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="% Financiamiento" DataField="porcentajeFinanciamiento" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Plazo Ejecucion" DataField="plazoEjecucion" ItemStyle-HorizontalAlign="Center" />

                        <asp:ButtonField Text="Editar" ButtonType="Button" CommandName="select" HeaderStyle-BackColor="#cccccc" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>


        <!--LISTA DE MODALIDADES PARA LA CONVOCATORIA ACTUAL-->
        <div class="panel-heading">
            <h3>MODALIDADES PARA LA CONVOCATORIA ACTUAL</h3>
        </div>
        <div class="form-group">
            <div class="col-md-12">
                <asp:GridView ID="dgvCM" runat="server" AutoGenerateColumns="true"
                    DataKeyNames="idModalidad"
                    CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen modalidades cargadas" ShowHeaderWhenEmpty="true">
                    
                </asp:GridView>
            </div>
        </div>


    </div>
</asp:Content>

