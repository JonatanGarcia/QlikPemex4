<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GraficaEjemplo.aspx.vb" Inherits="GraficaEjemplo" %>

<asp:Content 
        ID="Content1" 
        ContentPlaceHolderID="head" 
        runat="Server">
</asp:Content>
<asp:Content 
        ID="Content2" 
        ContentPlaceHolderID="ContentPlaceHolder1" 
        runat="Server">
    <div>
        <asp:literal id="ltrChart" runat="server"></asp:literal>
    </div>
</asp:Content>

