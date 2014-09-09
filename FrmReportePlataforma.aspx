<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmReportePlataforma.aspx.vb" Inherits="Default3" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <asp:ScriptManager ID="ScriptManager1" 
            runat="server">
        </asp:ScriptManager>
    
    <div class="row">
        <div class="form-group">
            <div class="col-md-8">
                
                <h3>Reporte por Plataforma</h3>
                <hr />
                
            </div>            
        </div>
    </div>

    <asps:accordion ID="MyAccordion" runat="Server" AutoSize="None" 
                            ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" 
                            HeaderCssClass="accordionHeader" 
                            HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" 
                            SelectedIndex="-1" SuppressHeaderPostbacks="true" TransitionDuration="250">
                            <Panes>
                                <aspS:AccordionPane runat="server">
                                    <Header>
                                        Filtros
                                    </Header>
                                    <Content>
                                    <%--<div class="row">--%>
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
                                            </div>
                                            </div>
                                        </div><!-- /.col-sm-4 -->
                                        <div class="col-sm-6">
                                           <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Intervención</h3>
                                            </div>
                                            <div class="panel-body">
                                                 <table>
                                                   <tr>
                                                    <td><asp:ListBox ID="LbIntervencion" runat="server"
                                                            SelectionMode="Multiple"  CssClass="list-group-item" Width="220px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button9" runat="server" Text="&gt;&gt;" CssClass="btn btn-default"/>
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="Button10" runat="server" Text="&lt;&lt;" CssClass="btn btn-default"/>
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="LbIntervencionFinal" runat="server"  SelectionMode="Multiple" CssClass="list-group-item" Width="220px"></asp:ListBox>
                                                    </td>
                                                </tr>
                                               </table>
                                            </div>
                                            </div>

                                        </div>
                                           <div class="col-md-10">
                                           <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="btn btn-success"><i class="glyphicon glyphicon-search"></i>&nbsp;Buscar</asp:LinkButton>    
                                         </div> 
                                     </Content>
                               </aspS:AccordionPane>
                           </Panes>
            </asps:accordion>
    <br />

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    <Report FileName="Rpts\CrtReportePlataforma.rpt">
    </Report>
</CR:CrystalReportSource>
</asp:Content>

