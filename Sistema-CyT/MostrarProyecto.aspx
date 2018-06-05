<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarProyecto.aspx.cs" Inherits="Sistema_CyT.MostrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyecto" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>
                    <asp:Label ID="lblNombreProyecto" runat="server" CssClass="col-md-12"></asp:Label>
                    <br />
                </h3>
            </div>
            <div class="panel-body">
                <!--CONTACTO-->
                <div class="form-group">
                    <asp:Label ID="lblContacto" runat="server" Text="REFERENTE" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                    <asp:Label ID="txtContacto" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true"></asp:Label>
                </div>
                <!--EXPEDIENTE-->
                <div class="form-group">
                    <asp:Label ID="lblNumeroExp" runat="server" Text="N°EXPEDIENTE" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                    <asp:Label ID="txtNumeroExp" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true"></asp:Label>
                </div>
                <!--CONVOCATORIA-->
                <div class="form-group">
                    <asp:Label ID="lblConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 col-xs-12 AlineadoDerecha"></asp:Label>
                    <asp:Label ID="txtConvocatoria" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true"></asp:Label>
                </div>
                <!--TIPO DE PROYECTO-->
                <div class="form-group">
                    <asp:Label ID="lblTipoProyecto" runat="server" Text="TIPO" CssClass="col-md-2 col-xs-12 AlineadoDerecha"></asp:Label>
                    <asp:Label ID="txtTipoProyecto" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO SOLICITADO-->
                <div class="form-group">
                    <asp:Label ID="lblMontoSolicitado" runat="server" Text="MONTO SOLICITADO" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                    <asp:Label ID="txtMontoSolicitado" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO CONTRAPARTE-->
                <div class="form-group">
                    <asp:Label ID="lblMontoContraparte" runat="server" Text="MTO CONTRAPARTE" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                    <asp:Label ID="txtMontoContraparte" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true"></asp:Label>
                </div>
                <!--MONTO TOTAL-->
                <div class="form-group">
                    <asp:Label ID="lblMontoTotal" runat="server" Text="MONTO TOTAL" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                    <asp:Label ID="txtMontoTotal" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true"></asp:Label>
                </div>
                <!--DESCRIPCION-->
                <div class="form-group">
                    <asp:Label ID="lblDescripcion" runat="server" Text="BREVE DESCRIPCION" CssClass="col-md-2 AlineadoDerecha"> </asp:Label>
                    <asp:Label ID="txtDescripcion" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true" TextMode="MultiLine" Rows="3"></asp:Label>
                </div>
                <!--OBSERVACIONES-->
                <div class="form-group">
                    <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 col-xs-12 AlineadoDerecha"> </asp:Label>
                    <asp:Label ID="txtObservaciones" runat="server" CssClass="AlineadoIzquierda" Font-Bold="true" TextMode="MultiLine" Rows="1"></asp:Label>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelEtapasActividades" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <h3>Etapas y Actividades del Proyecto</h3>
            </div>
            <!--LISTA DE ETAPAS CARGADAS-->
            <div class="form-group">
                <br />
                <div class="col-md-10 col-md-offset-1">
                    <asp:GridView ID="dgvEtapas" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="idEtapa"
                        CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen etapas cargadas" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdE" DataField="idEtapa" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdP" DataField="idProyecto" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Etapas" DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Inicio" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaInicio" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Fin" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaFin" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Estado" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoEstadoEtapa.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Rendicion" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="50">
                                <ItemTemplate><%# (Boolean.Parse(Eval("Rendicion").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Informe Tecnico" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="50">
                                <ItemTemplate><%# (Boolean.Parse(Eval("Informe").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <!--LISTA DE ACTIVIDADES CARGADAS-->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
                    <asp:GridView ID="dgvActividades" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="idActividad"
                        CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen actividades cargadas" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Etapa" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="l2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Etapa.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Actividad" DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Descripcion" DataField="descripcion" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Resultados Esperados" DataField="resultadosEsperados" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Localizacion" DataField="localizacion" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
        <div class="form-group">
            <div class="col-md-4">
                <asp:Button Style="text-align: left;" runat="server" ID="btnEtapa" Text=" Agregar/Editar Etapas" Width="200" CssClass="boton_azul" OnClick="btnEtapa_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-4">
                <asp:Button Style="text-align: left;" runat="server" ID="btnActividad" Text=" Agregar/Editar Actividades" Width="200" CssClass="boton_azul style-1" OnClick="btnActividad_Click" />
            </div>
        </div>
        <asp:Button runat="server" ID="btnActuaciones" Text="HISTORIAL DE ACTUACIONES" Width="250" CssClass="boton_azul" OnClick="btnActuaciones_Click" />
    </div>
</asp:Content>
