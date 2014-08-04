<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AnalisisEspecifico.aspx.vb" Inherits="_Default" %><%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspS" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Content/Accordion.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style8 {
            width: 100%;
        }
            .style001
        {
            background-color: #333333;
            color: #FFFFFF;
            text-align: center;
            font-weight: bold;
            }
        .style11 {
            width: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" 
            runat="server">
        </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

           
            <div class="row">
                <div class="form-group">
                    <div class="col-md-8">
                        <h3>Análisis Especifico</h3>
                        <hr />
                        <asp:Button ID="Button6" runat="server" CssClass="btn btn-success" Text="Exportar" />
                        <asp:Button ID="Button5" runat="server" Text="Atras" CssClass="btn btn-primary" Visible="False" />
                    </div>

                    <div class="col-md-4">
                        <h4><asp:Label ID="Label6" runat="server" Text="Selecciones Actuales" Visible="False"></asp:Label></h4>
                        <asp:ListBox ID="LbSelecciones" runat="server" Width="230px" Font-Bold="True" 
                           Font-Overline="False" Font-Underline="True" AutoPostBack="True" Visible="False">
                       </asp:ListBox>
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
                                        <asp:Label ID="LblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        <table>
                                            <tr>
                                                <td class="style001">Pozo
                                                    <asp:TextBox ID="TxtPozos" runat="server" Width="160px" 
                                                            AutoPostBack="True"></asp:TextBox>
                                                    <aspS:TextBoxWatermarkExtender ID="TBWE2" runat="server" 
                                                            TargetControlID="TxtPozos" WatermarkCssClass="watermarked" 
                                                            WatermarkText="Busqueda de pozo" />
                                                </td>
                                                <td class="style11"></td>
                                                <td class="style001">Nivel 1
                                                    <asp:TextBox ID="TxtN1" runat="server" Width="200px"  AutoPostBack="True" ></asp:TextBox>
                                                    <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" 
                                                                TargetControlID="TxtN1" WatermarkCssClass="watermarked" 
                                                                WatermarkText="Busqueda de Nivel 1" />
                                                </td>
                                                <td class="style11"></td>
                                                <td class="style001">Nivel 3
                                                    <asp:TextBox ID="TxtN3" runat="server" Width="200px" AutoPostBack="True" ></asp:TextBox>
                                                    <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" 
                                                            TargetControlID="TxtN3" WatermarkCssClass="watermarked" 
                                                            WatermarkText="Busqueda de Nivel 3" />
                                                </td>
                                                <td class="style11"></td>
                                                <td class="style001">Nivel 4
                                                    <asp:TextBox ID="TxtN4" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" 
                                                                                TargetControlID="TxtN4" WatermarkCssClass="watermarked" 
                                                                                WatermarkText="Busqueda de Nivel 4" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="3">
                                                    <asp:ListBox ID="LbPozo" runat="server"
                                                            SelectionMode="Multiple" Width="160px" 
                                                            Height="250px" AutoPostBack="True" CssClass="list-group-item"></asp:ListBox>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:ListBox ID="LbN1" runat="server" SelectionMode="Multiple" Width="260px" AutoPostBack="True" CssClass="list-group-item"></asp:ListBox>
                                                    <br />
                                                </td>
                                                <td></td>
                                                <td rowspan="3">
                                                    <asp:ListBox ID="LbN3" runat="server" SelectionMode="Multiple" Height="250px" Width="260px" 
                                                            AutoPostBack="True" CssClass="list-group-item"></asp:ListBox>
                                                    </td>
                                                <td></td>
                                                <td rowspan="3">
                                                    <asp:ListBox ID="LbN4" runat="server" SelectionMode="Multiple" Height="250px" Width="260px" 
                                                        AutoPostBack="True" CssClass="list-group-item"></asp:ListBox>
                                                </td>
                                            </tr>
                                                
                                            <tr>
                                                <td></td>
                                                <td class="style001">Nivel 2
                                                    <asp:TextBox ID="TxtN2" runat="server" Width="200px" AutoPostBack="True"></asp:TextBox>
                                                    <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" 
                                                                                TargetControlID="TxtN2" WatermarkCssClass="watermarked" 
                                                                                WatermarkText="Busqueda de Nivel 2" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:ListBox ID="LbN2" runat="server" SelectionMode="Multiple" Height="124px" Width="260px" 
                                                        AutoPostBack="True" CssClass="list-group-item">
                                                    </asp:ListBox>
                                                </td>
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
            <div class="row">
                <div class="col-sm-2">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">Niveles</h4>
                                    </div>
                                    <div class="panel-body">
                                                <asp:Button ID="Button1" runat="server" Text="Nivel 1" CssClass="btn btn-info" />
                                                <br />
                                                <br />
                                                <asp:Button ID="Button2" runat="server" Text="Nivel 2" CssClass="btn btn-info"/>
                                                <br />
                                                <br />
                                                <asp:Button ID="Button3" runat="server" Text="Nivel 3" CssClass="btn btn-info"/>
                                                <br />
                                                <br />
                                                <asp:Button ID="Button4" runat="server" Text="Nivel 4" CssClass="btn btn-info"/>
                                    </div>
                                </div>
                            </div>
                <div class="col-sm-10">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">Días NPT's</h4>
                                    </div>
                                    <div class="panel-body">
                                          <asp:Chart ID="Chart1" runat="server" Width="920px" Height="501px">
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
                                    </div>
                                </div>
                            </div>
                </div>

        </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="Button6"/>
         </Triggers>

    </asp:UpdatePanel>
</asp:Content>

