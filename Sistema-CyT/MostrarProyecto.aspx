<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarProyecto.aspx.cs" Inherits="Sistema_CyT.MostrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Panel ID="PanelProyecto" CssClass="panel panel-default" runat="server">
            <div class="panel-heading">
                <br />
                <asp:Label ID="lblNombreProyecto" Style="text-align: justify;" Font-Bold="true" runat="server" CssClass="col-md-12 control-label"></asp:Label>
                <br />
            </div>
            <div class="panel-body">
                <!--EXPEDIENTE-->
                <div class="form-group">
                    <asp:Label ID="lblNumeroExp" runat="server" Text="EXPEDIENTE / N°CONVENIO" CssClass="col-md-2 control-label"> </asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNumeroExp" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--CONVOCATORIA-->
                <div class="form-group">
                    <asp:Label ID="lblConvocatoria" runat="server" Text="CONVOCATORIA" CssClass="col-md-2 col-xs-12 control-label"></asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtConvocatoria" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--MONTO SOLICITADO-->
                <div class="form-group">
                    <asp:Label ID="lblMontoSolicitado" runat="server" Text="MONTO SOLICITADO" CssClass="col-md-2 control-label"> </asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtMontoSolicitado" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--MONTO CONTRAPARTE-->
                <div class="form-group">
                    <asp:Label ID="lblMontoContraparte" runat="server" Text="MTO CONTRAPARTE" CssClass="col-md-2 control-label"> </asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtMontoContraparte" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--MONTO TOTAL-->
                <div class="form-group">
                    <asp:Label ID="lblMontoTotal" runat="server" Text="MONTO TOTAL" CssClass="col-md-2 control-label"> </asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtMontoTotal" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!--DESCRIPCION-->
                <div class="form-group">
                    <asp:Label ID="lblDescripcion" runat="server" Text="BREVE DESCRIPCION" CssClass="col-md-2 control-label"> </asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>
                <!--OBSERVACIONES-->
                <div class="form-group">
                    <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES" CssClass="col-md-2 col-xs-12 control-label"> </asp:Label>
                    <div class="col-md-8 col-xs-12">
                        <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                    </div>
                </div>
                <asp:Button runat="server" ID="btnActuaciones" Text="ACTUACIONES" CssClass="btn btn-primary" OnClick="btnActuaciones_Click" />
            </div>

            <!--LISTA DE ETAPAS CARGADAS-->
            <div class="form-group">
                <div class="col-md-10 col-md-offset-1">
                    <asp:GridView ID="dgvEtapas" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="idEtapa"
                        CssClass="table table-hover" BorderWidth="2px" EmptyDataText="No existen etapas cargadas" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdE" DataField="idEtapa" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="IdP" DataField="idProyecto" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Etapa" DataField="nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="250" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Inicio" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaInicio" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:BoundField HeaderStyle-BackColor="#cccccc" HeaderText="Fin" DataFormatString="{0:dd-MMM-yyyy}" DataField="fechaFin" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100" />
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Rendicion" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate><%# (Boolean.Parse(Eval("Rendicion").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-BackColor="#cccccc" HeaderText="Informe Tecnico" ItemStyle-HorizontalAlign="Left" ControlStyle-Font-Size="Small" HeaderStyle-Width="100">
                                <ItemTemplate><%# (Boolean.Parse(Eval("Informe").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>


        </asp:Panel>
    </div>
</asp:Content>
