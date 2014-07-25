<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AnalisisGeneral.aspx.vb" Inherits="_Default"  EnableEventValidation="False" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspS" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="Content/Accordion.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style8
        {
            width: 100%;
        }
        .style9
        {
            height: 23px;
        }
        .style10
        {
            width: 586px;
        }
        .style11
        {
            width: 1470px;
        }
        .style14
        {
            width: 861px;
        } 
        .style15
        {
            width: 87px;
        }
        .style16
        {
            height: 23px;
            width: 87px;
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
            width: 440px;
        }

        .auto-style1 {
            height: 22px;
        }

        .auto-style2 {
            height: 22px;
            width: 782px;
        }

        .style001
        {
            background-color: #244767;
            color: #FFFFFF;
            text-align: center;
            font-weight: bold;
            }

        </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
            <div class="row">
                <div class="form-group">
                    <div class="col-md-8">
                        <h4>Opción</h4>
                            <hr />
                         <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Text="Exportar" />      
                    </div>
                
                <div class="col-md-4">
                        <h4><asp:Label ID="Label1" runat="server" Text="Selecciones Actuales"></asp:Label></h4>
                        <hr />
                        <asp:ListBox ID="LbSelecciones" runat="server" Width="230px" Font-Bold="True" 
                            Font-Overline="False" Font-Underline="True" AutoPostBack="True">
                        </asp:ListBox>
                        <br />
                        <asp:Button ID="Button3" runat="server" Text="Atras" CssClass="btn btn-default"/>
                        <asp:Button ID="Button2" runat="server" Text="Borrar" CssClass="btn btn-default" />
                </div>             
                    </div>
             </div>     
                      
                       
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <aspS:Accordion ID="MyAccordion" runat="Server" AutoSize="None" 
                            ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" 
                            HeaderCssClass="accordionHeader" 
                            HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" 
                            SelectedIndex="0" SuppressHeaderPostbacks="true" TransitionDuration="250">
                            <Panes>
                                <aspS:AccordionPane runat="server">
                                    <Header>
                                        Filtros
                                    </Header>
                                    <Content>
                                        <%-- la tabla --%>
                                        <asp:Label ID="LblMsg" runat="server" ForeColor="Red" ></asp:Label>
                                         <table>
                                            <tr>
                                                <td class="style12">
                                                    <table>
                                                        <tr>
                                                            <td class="style001" colspan="2">Pozo</td>
                                                            <td class="style001">
                                                                 <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                                                 <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                                        TargetControlID="TextBox2"
                                                                        WatermarkText="Busqueda de pozo"
                                                                        WatermarkCssClass="watermarked" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                 <asp:ListBox ID="LbPozo" runat="server" SelectionMode="Multiple" Width="150px" 
                                                                    AutoPostBack="True" CssClass="list-group-item">
                                                                </asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td class="style001" colspan="3">Año</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ListBox ID="LbAnio" runat="server" SelectionMode="Multiple" 
                                                                    AutoPostBack="True" Width="150px" CssClass="list-group-item"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style12">
                                                    <table>
                                                        <tr>
                                                            <td class="style001" colspan="2">Plataforma</td>
                                                            <td class="style001">
                                                                 <asp:TextBox ID="TextBox4" runat="server"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                                                 <aspS:TextBoxWatermarkExtender ID="TBWE4" runat="server"
                                                                        TargetControlID="TextBox4"
                                                                        WatermarkText="Busqueda de Plataforma"
                                                                        WatermarkCssClass="watermarked" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ListBox ID="LbPlataforma" runat="server" SelectionMode="Multiple" 
                                                                        Width="150px" AutoPostBack="True" CssClass="list-group-item"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td class="style001" colspan="3">Intervención</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ListBox ID="LbIntervencion" runat="server" SelectionMode="Multiple" 
                                                                Width="150px" AutoPostBack="True" CssClass="list-group-item"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style12">
                                                    <table>
                                                        <tr>
                                                            <td class="style001" colspan="2">Equipo</td>
                                                            <td class="style001">
                                                                 <asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                                                 <aspS:TextBoxWatermarkExtender ID="TBWE3" runat="server"
                                                                        TargetControlID="TextBox3"
                                                                        WatermarkText="Busqueda de Equipo"
                                                                        WatermarkCssClass="watermarked" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ListBox ID="LbEquipo" runat="server" SelectionMode="Multiple" 
                                                                    Width="150px" AutoPostBack="True" CssClass="list-group-item"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </Content>
                                 </aspS:AccordionPane>
              
                                <aspS:AccordionPane ID="AccorditionPane6" runat="server">
                                    <Header>Excel</Header>
                                    <Content>
                                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                            CellPadding="4" CssClass="mGrid" EnableModelValidation="True" 
                            Font-Size="Smaller" ForeColor="Black" GridLines="Horizontal" 
                            PagerStyle-CssClass="pgr">
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:BoundField DataField="NPozo" HeaderText="Pozo" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dateOperacion" dataformatstring="{0:dd/MM/yyyy}" 
                                    HeaderText="Día" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="intCon" HeaderText="Consecutivo" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="intProf" HeaderText="Profundidad" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="floatTiempo" HeaderText="Tiempo" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="N1" HeaderText="Nivel 1" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="N2" HeaderText="Nivel 2" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="N3" HeaderText="Nivel 3" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="N4" HeaderText="Nivel 4" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Plata" HeaderText="Plataforma" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>                                
                                <asp:BoundField DataField="Nintervencion" HeaderText="Intervencion" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Etapa" HeaderText="Etapa" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Tr" HeaderText="Diam. Tr" HtmlEncode="false">
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
                <table>
                <tr>
                   <th class="style15">
                   </th>
                    <th colspan="4" style="text-align: center">
                        
                    </th>
                </tr>
                <tr>
                    <th class="style15">
                        &nbsp;</th>
                    <th colspan="3" rowspan="2">
                        <table style="width: 772px">
                            <tr>
                                <th style="background-color: #333333; color: #FFFFFF"><asp:Label runat="server" Text="Días Perforación"></asp:Label></th>
                                <th style="background-color: #333333; color: #FFFFFF"><asp:Label runat="server" Text="Días Terminación"></asp:Label></th>
                                <th style="background-color: #333333; color: #FFFFFF"><asp:Label runat="server" Text="Días RMA"></asp:Label></th>
                                <th style="background-color: #333333; color: #FFFFFF"><asp:Label runat="server" Text="Días NPT's"></asp:Label></th>
                                <th style="background-color: #333333; color: #FFFFFF"><asp:Label runat="server" Text="Continuidad OP."></asp:Label></th>
                                <th style="background-color: #333333; color: #FFFFFF"><asp:Label runat="server" Text="#Pozos"></asp:Label></th>
                            </tr>
                            <tr align="center">
                                <td>
                                    <asp:Label ID="LbldiasPerfora" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LblDiasTerm" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LblDiasRMA" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LblDiasNPTS" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LblCO" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LblPozos" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        </th>
                    <th>
                        &nbsp;</th>
                </tr>
                <tr>
                    <td class="style16">
                    </td>
                    <td class="style9">
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <th class="style11">
                        <asp:Chart ID="Chart1" runat="server" Palette="Bright" Height="374px" 
                            Width="768px">
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Crossing="Min" IsReversed="True" Minimum="0">
                                    </AxisY>
                                    <AxisX Crossing="Min" Minimum="0">
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </th>
                    <th class="style10">
                        &nbsp;</th>
                    <th>
                        <asp:Chart ID="Chart2" runat="server" Width="399px" Palette="None" 
                            PaletteCustomColors="Highlight; Gray; 255, 128, 0">
                            <Series>
                                <asp:Series ChartType="Pie" IsValueShownAsLabel="True" Legend="Legend1" 
                                    Name="Series1" Font="Microsoft Sans Serif, 8.25pt, style=Bold">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                </asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                                <asp:Legend Docking="Top" IsTextAutoFit="False" Name="Legend1" Font="Microsoft Sans Serif, 8.25pt, style=Bold">
                                </asp:Legend>
                            </Legends>
                        </asp:Chart>
                    </th>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button4" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>