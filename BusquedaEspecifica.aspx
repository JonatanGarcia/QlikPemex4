<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BusquedaEspecifica.aspx.vb" Inherits="_Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="Content/Accordion.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style8
        {
            width: 100%;
        }
        .style10
        {
            width: 137px;
        }
        .style11
        {
            width: 78px;
        }
        
        .style001
        {
            background-color: #333333;
            color: #FFFFFF;
            text-align: center;
            font-weight: bold;
            }
        
       
        
        .style12
        {
            width: 240px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:scriptmanager runat="server"></asp:scriptmanager>
    <asp:Button ID="Button13" CssClass="btn btn-default" runat="server" Text="Exportar" />
            
    <asp:updatepanel runat="server">
        <ContentTemplate>
      
<asp:Button runat="server" Text="Buscar" CssClass="btn btn-default" onclick="Unnamed3_Click"></asp:Button>
            <br />
            <br />
            
    <br />

<%--   <table>
    
                <tr>
                <th class="style001">
                    <asp:Label ID="Label8" runat="server" Text="Selecciones Actuales"></asp:Label>
                </th>
                </tr>
                <tr>
                 <th>
                       <asp:ListBox ID="LbSelecciones" runat="server" Width="230px" Font-Bold="True" 
                           Font-Overline="False" Font-Underline="True" AutoPostBack="True">
                       </asp:ListBox>
                 </th>
                </tr>

                        </table>
            --%>
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
            <Header> Rangos </Header>
            <Content> 
                 <table class="style8">
  
        <tr>
            <td class="style11">
                <asp:Label ID="Label1" runat="server" Text="Fecha Inicio"></asp:Label>
                </td>
            <td class="style10">
                <asp:TextBox ID="TxtFechaInicial" runat="server" CssClass="form-control"></asp:TextBox>
                 <aspS:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                    Enabled="True" Format="yyyy-MM-dd" TargetControlID="TxtFechaInicial">
                </aspS:CalendarExtender>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label2" runat="server" Text="Fecha Fin"></asp:Label>
                </td>
            <td class="style10">
                <asp:TextBox ID="TxtFechaFinal" runat="server" CssClass="form-control"></asp:TextBox>
                 <aspS:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                    Enabled="True" Format="yyyy-MM-dd" TargetControlID="TxtFechaFinal">
                </aspS:CalendarExtender>
                  
            </td>
            <td>
                &nbsp;</td>
            <td>
               <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
            </Content>
        </aspS:AccordionPane>        

          <aspS:AccordionPane ID="AccordionPane2" runat="server">
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
        </aspS:AccordionPane>
          <aspS:AccordionPane ID="AccordionPane3" runat="server">
            <Header> Filtros</Header>
            <Content>
                <asp:Label ID="LblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
               <table>
                    <tr>
                        <%-- pozo --%>
                        <td>
                             <table>
                                <tr>
                                    <td class="style001" colspan="2">
                                        <asp:Label ID="Label5" runat="server" Text="Pozo"></asp:Label>
                                        </td>
                                    <td class="style001">
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                        <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
                                            TargetControlID="TextBox3" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de pozo" />
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:ListBox ID="LbPozo" runat="server"
                                            SelectionMode="Multiple" Width="160px" CssClass="list-group-item"></asp:ListBox>
                                        
                                    </td>
                                    <td>
                                        <asp:Button ID="Button8" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button7" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LbPozoFinal" runat="server" Width="160px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <%-- end pozo --%>
                        <td class="style12"></td>
                        <td>
                            <table>
                                <tr>
                                    <td class="style001" colspan="3">
                                        <asp:Label ID="Label4" runat="server" Text="Intervencion"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="LbIntervencion" runat="server" 
                                            SelectionMode="Multiple" Width="160px" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button5" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button6" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LbIntervencionFinal" runat="server" Width="160px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                     <tr>
                         <%-- plataforma --%>
                          <td class="style12">
                            <table>
                                <tr>
                                    <td class="style001" colspan="2">
                                     <asp:Label ID="Label6" runat="server" Text="Plataforma"></asp:Label>
                                    </td>
                                    <td class="style001">
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                        <aspS:TextBoxWatermarkExtender ID="TBWE4" runat="server" 
                                            TargetControlID="TextBox4" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de Plataforma" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="LbPlataforma" runat="server"
                                            SelectionMode="Multiple" Width="160px" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button10" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button9" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LbPlataformaFinal" runat="server" Width="160px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                         <%-- end plataforma --%>
                        <td></td>
                        <td>
                             <table>
                                <tr>
                                   <td class="style001"
                                        colspan="3">
                                        <asp:Label ID="Label3" runat="server" Text="Año"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <%-- aqui va el año --%>
                                    <td>
                                        <asp:ListBox ID="LbAnio" runat="server"
                                            SelectionMode="Multiple" Width="160px" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button3" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button4" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LbAnioFinal" runat="server" Width="160px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                     <tr>
                        <td>
                                <table>
                                    <tr>
                                        <td class="style001" colspan="2">
                                            <asp:Label ID="Label7" runat="server" Text="Equipo"></asp:Label>
                                        </td>
                                        <td class="style001">
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                            <aspS:TextBoxWatermarkExtender ID="TBWE3" runat="server" 
                                                TargetControlID="TextBox5" WatermarkCssClass="watermarked" 
                                                WatermarkText="Busqueda de Equipo" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="LbEquipo" runat="server"
                                                SelectionMode="Multiple" Width="160px" CssClass="list-group-item"></asp:ListBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button12" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                            <br />
                                            <br />
                                            <asp:Button ID="Button11" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="LbEquipoFinal" runat="server" Width="160px" SelectionMode="Multiple" CssClass="list-group-item"></asp:ListBox>
                                        </td>
                                    </tr>
                                </table>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
               </table>
            
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
        
            <br />
            <br />            
            
</ContentTemplate>
</asp:updatepanel>

</asp:Content>

