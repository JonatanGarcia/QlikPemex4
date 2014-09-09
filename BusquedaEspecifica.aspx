<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BusquedaEspecifica.aspx.vb" Inherits="_Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:scriptmanager runat="server"></asp:scriptmanager>
    
            
    <asp:updatepanel runat="server">
        <ContentTemplate>
      
            <div class="alert alert-warning" id="msg" runat="server">
                          <span class="glyphicon glyphicon-remove"></span>  <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                        </div>
            <div class="row">
                <div class="form-group">
                    <div class="col-md-8">
                        <h3>Busqueda Especifica</h3>
                        <hr />
                        <%--<asp:Button ID="Button13" CssClass="btn btn-success" runat="server" Text="Exportar" />--%>
                        <asp:LinkButton ID="Button13" runat="server"  CssClass="btn btn-success "><i class="glyphicon glyphicon-save"></i>&nbsp;Exportar</asp:LinkButton>

                        <%--<asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" onclick="Unnamed3_Click"></asp:Button>--%>
                        <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="btn btn-primary" OnClick="Unnamed3_Click"><i class="glyphicon glyphicon-search"></i>&nbsp;Buscar</asp:LinkButton>
                    </div>
                </div>
            </div>

    <aspS:Accordion
    ID="MyAccordion"
    runat="Server"
    SelectedIndex="0"
    HeaderCssClass="accordionHeader"
    HeaderSelectedCssClass="accordionHeaderSelected"
    ContentCssClass="accordionContent"
    AutoSize="None"
    FadeTransitions="true"
    TransitionDuration="250"
    FramesPerSecond="40"
    RequireOpenedPane="false"
    SuppressHeaderPostbacks="true">
    <Panes>
        <aspS:AccordionPane runat="server">
            <%-- Valor a mostrar --%>
            <Header> Valores a Mostrar</Header>
            <Content>
                <table>
                    <tr>
                        <td>
                            <asp:listbox ID="LbInicial"  SelectionMode="Multiple" runat="server" Height="236px" Width="161px" CssClass="list-group-item">
                                    <asp:ListItem Value="0">Pozo</asp:ListItem>
                                    <asp:ListItem Value="1">Intervencion</asp:ListItem>
                                    <asp:ListItem Value="2">Consecutivo</asp:ListItem>
                                    <asp:ListItem Value="3">Fecha Operación</asp:ListItem>
                                    <asp:ListItem Value="4">Profundidad</asp:ListItem>
                                    <asp:ListItem Value="5">Resumen</asp:ListItem>
                                    <asp:ListItem Value="6">Horas</asp:ListItem>
                                    <asp:ListItem Value="7">Dias</asp:ListItem>
                                    <asp:ListItem Value="8">Detalle</asp:ListItem>
                                    <asp:ListItem Value="9">Diámetro TR</asp:ListItem>
                                    <asp:ListItem Value="10">Etapa</asp:ListItem>
                                    <asp:ListItem Value="11">Nivel 4</asp:ListItem>
                                    <asp:ListItem Value="12">Nivel 3</asp:ListItem>
                                    <asp:ListItem Value="13">Nivel 2</asp:ListItem>
                                    <asp:ListItem Value="14">Nivel 1</asp:ListItem>
                                    <asp:ListItem Value="15">Plataforma</asp:ListItem>
                                    <asp:ListItem Value="16">Equipo</asp:ListItem>
                                    <asp:ListItem Value="17">Compañia</asp:ListItem>
                                    <asp:ListItem Value="18">Año</asp:ListItem>
                            </asp:listbox>
                        </td>
                        <td>
                          <asp:Button ID="Button1" runat="server" text="&gt;&gt;" CssClass="btn btn-default" />
                          <br />
                           <br />
                          <asp:Button ID="Button2" runat="server" text="&lt;&lt;" CssClass="btn btn-default" />
                        </td>
                        <td>
                            <asp:listbox ID="LbFinal" SelectionMode="Multiple" runat="server" Height="236px" Width="161px" CssClass="list-group-item" ></asp:listbox>
                        </td>
                    </tr>
                </table>
            
            </Content>

            <%--  --%>
        </aspS:AccordionPane>
          <aspS:AccordionPane ID="AccordionPane3" runat="server">
            <Header> Filtros</Header>
            <Content>
                  <div class="col-sm-6">
                       <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Pozos
                                </h3>                                
                        </div>
                        <div class="panel-body">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                        <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
                                            TargetControlID="TextBox3" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de pozo" />
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:ListBox ID="LbPozo" runat="server"
                                            SelectionMode="Multiple" Width="220px" CssClass="list-group-item"></asp:ListBox>
                                        
                                    </td>
                                    <td>
                                        <asp:Button ID="Button8" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button7" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LbPozoFinal" runat="server" Width="220px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                       
                      <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Plataformas</h3>
                        </div>
                        <div class="panel-body">
                             <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                        <aspS:TextBoxWatermarkExtender ID="TBWE4" runat="server" 
                                            TargetControlID="TextBox4" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de Plataforma" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="LbPlataforma" runat="server"
                                            SelectionMode="Multiple" Width="220px" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button10" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button9" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LbPlataformaFinal" runat="server" Width="220px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Equipos</h3>
                        </div>
                        <div class="panel-body">
                            <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                            <aspS:TextBoxWatermarkExtender ID="TBWE3" runat="server" 
                                                TargetControlID="TextBox5" WatermarkCssClass="watermarked" 
                                                WatermarkText="Busqueda de Equipo" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="LbEquipo" runat="server"
                                                SelectionMode="Multiple" Width="220px" CssClass="list-group-item"></asp:ListBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button12" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                            <br />
                                            <br />
                                            <asp:Button ID="Button11" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="LbEquipoFinal" runat="server" Width="220px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                        </td>
                                    </tr>
                                </table>
                        </div>
                    </div>

                    </div><!-- Final del div 6-->

                <div class="col-sm-6">
                    <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">Fechas</h3>
                            </div>
                            <div class="panel-body">
                                 <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Fecha Inicio"></asp:Label>
                                        </td>
                                        <td>
                                                <asp:TextBox ID="TxtFechaInicial" runat="server" CssClass="form-control"></asp:TextBox>
                                                <aspS:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                                    Enabled="True" Format="yyyy-MM-dd" TargetControlID="TxtFechaInicial" PopupPosition="Left">
                                                </aspS:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                                <br />
                                            <asp:Label ID="Label2" runat="server" Text="Fecha Fin"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="TxtFechaFinal" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <aspS:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                                                    Enabled="True" Format="yyyy-MM-dd" TargetControlID="TxtFechaFinal" PopupPosition="Left">
                                                    </aspS:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </div>
                        </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Intervención</h3>
                        </div>
                        <div class="panel-body">
                              <table>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="LbIntervencion" runat="server" 
                                            SelectionMode="Multiple" Width="220px" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button5" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button6" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LbIntervencionFinal" runat="server" Width="220px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Años</h3>
                        </div>
                        <div class="panel-body">
                               <table>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="LbAnio" runat="server"
                                            SelectionMode="Multiple" Width="220px" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button3" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button4" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LbAnioFinal" runat="server" Width="220px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                    </div>
                </div><!--  final del div 6-->
            </Content>      
        </aspS:AccordionPane>      
  
        <aspS:AccordionPane ID="AccordionPane4" runat="server">
        <Header> Excel</Header>
            <Content>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" CssClass="mGrid" 
                Font-Size="Smaller" ForeColor="Black" GridLines="Horizontal" 
                PagerStyle-CssClass="pgr">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:BoundField DataField="Pozo" HeaderText="Pozo" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Intervencion" HeaderText="Intervencion" 
                        HtmlEncode="false" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Consecutivo" HeaderText="Consecutivo" 
                        HtmlEncode="false" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Fecha" dataformatstring="{0:dd/MM/yyyy}" 
                        HeaderText="Fecha" HtmlEncode="false" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Profundidad" HeaderText="Profundidad" 
                        HtmlEncode="false" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="resumen" HeaderText="Resumen" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="horas" HeaderText="Horas" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dias"  dataformatstring="{0:0.00}"
                         HeaderText="Días" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Detalle" HeaderText="Detalle" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Diametro" HeaderText="Diámetro TR" 
                        HtmlEncode="false" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Etapa" HeaderText="Etapa" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Nivel4" HeaderText="Nivel 4" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Nivel3" HeaderText="Nivel 3" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Nivel2" HeaderText="Nivel 2" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Nivel1" HeaderText="Nivel 1" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Plataforma" HeaderText="Plataforma" 
                        HtmlEncode="false" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Equipo" HeaderText="Equipo" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Compania" HeaderText="Compañia" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="anio" HeaderText="Año" HtmlEncode="false" 
                        Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" CssClass="pgr" ForeColor="Black" 
                    HorizontalAlign="Right" />
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            </asp:GridView>

            </Content>
        </aspS:AccordionPane>
     </Panes>            
    </aspS:Accordion>
       
</ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button13" />
        </Triggers>
</asp:updatepanel>

</asp:Content>

