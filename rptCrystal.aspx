<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rptCrystal.aspx.vb" Inherits="Default2" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <CR:CrystalReportViewer 
                ID="CrystalReportViewer1" 
            runat="server" 
            AutoDataBind="True" 
            GroupTreeImagesFolderUrl="" 
            Height="1202px" 
            ReportSourceID="CrystalReportSource1" 
            ToolbarImagesFolderUrl="" 
            ToolPanelWidth="200px"
            Width="1104px" />
    </center>
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="Rpts/crPozo.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>
