<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AnalisisEspecifico.aspx.vb" Inherits="_Default" %><%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspS" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="Content/Accordion.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style8
        {
            width: 100%;
        }
         .accordion {  
            width: 400px;  
        }  
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" 
            runat="server">
        </asp:ScriptManager>
    <br />
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<asp:ListBox ID="LbSelecciones" runat="server" Width="230px" Font-Bold="True" 
                           Font-Overline="False" Font-Underline="True" 
        AutoPostBack="True">
                       </asp:ListBox>
   
            <asp:Button ID="Button5" runat="server" Text="Atras" />
   
           <table class="style8">
        <tr>
            <td rowspan="3">
                <span>
                                        <asp:TextBox ID="TxtPozos" runat="server" Width="160px" 
                    AutoPostBack="True"></asp:TextBox>
                                        
                                        <aspS:TextBoxWatermarkExtender ID="TBWE2" runat="server" 
                                            TargetControlID="TxtPozos" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de pozo" />
                                            <br />
                                        <asp:ListBox ID="LbPozo" runat="server"
                                            SelectionMode="Multiple" Width="160px" 
                    Height="250px" AutoPostBack="True"></asp:ListBox>
                                        
                                    </span>
            </td>
            <td>
                <asp:TextBox ID="TxtN1" runat="server" Width="200px"></asp:TextBox>
                <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" 
                                            TargetControlID="TxtN1" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de Nivel 1" />
                <br />
                <asp:ListBox ID="LbN1" runat="server" Width="260px" AutoPostBack="True"></asp:ListBox>
            </td>
            <td rowspan="3">
                <asp:TextBox ID="TxtN3" runat="server" Width="200px"></asp:TextBox>
                <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" 
                                            TargetControlID="TxtN3" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de Nivel 3" />
                <br />
                <asp:ListBox ID="LbN3" runat="server" Height="250px" Width="260px" 
                    AutoPostBack="True"></asp:ListBox>
            </td>
            <td rowspan="3">
                <asp:TextBox ID="TxtN4" runat="server" Width="200px"></asp:TextBox>
                <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" 
                                            TargetControlID="TxtN4" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de Nivel 4" />
                <br />
                <asp:ListBox ID="LbN4" runat="server" Height="250px" Width="260px" 
                    AutoPostBack="True"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TxtN2" runat="server" Width="200px"></asp:TextBox>
                <aspS:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" 
                                            TargetControlID="TxtN2" WatermarkCssClass="watermarked" 
                                            WatermarkText="Busqueda de Nivel 2" />
                <br />
                <asp:ListBox ID="LbN2" runat="server" Height="124px" Width="260px" 
                    AutoPostBack="True">
                </asp:ListBox>
            </td>
        </tr>
        </table>


                                    <asp:Button ID="Button1" runat="server" 
                Text="Nivel 1" />

            <br />
            <asp:Button ID="Button2" runat="server" Text="Nivel 2" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Nivel 3" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Nivel 4" />
            <br />

<asp:Chart ID="Chart1" runat="server" Width="980px" Height="501px">
                            <Series>
                                <asp:Series ChartType="Pie" IsValueShownAsLabel="True" Legend="Legend1" 
                                    Name="Series1">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <Area3DStyle Enable3D="True" Inclination="50" />
                                </asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                                <asp:Legend Docking="Top" IsTextAutoFit="False" Name="Legend1">
                                </asp:Legend>
                            </Legends>
                        </asp:Chart>


        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

