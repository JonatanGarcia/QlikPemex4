<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
       
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Análisis General de NPT's">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </ContentTemplate>
            </cc1:TabPanel>
           
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Análisis Especifico de NPT's">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button2" runat="server" Text="Button" />
                </ContentTemplate>
            </cc1:TabPanel>
                      
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="SIOP">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                </ContentTemplate>
            </cc1:TabPanel>
           
            <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Control de Perforación">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button4" runat="server" Text="Button" />
                </ContentTemplate>
            </cc1:TabPanel>

             <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Consulta de Datos (SIOP)">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button5" runat="server" Text="Button" />
                </ContentTemplate>
            </cc1:TabPanel>

        </cc1:TabContainer>

</asp:Content>

