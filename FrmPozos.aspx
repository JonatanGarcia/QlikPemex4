﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmPozos.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>            
            <div class="row">
                <div class="form-group">
                    <div class="col-md-8">
                        <h3>Catálogo Pozos</h3>
                        <hr />
                    </div>
                </div>
            </div>
            <div class="alert alert-danger" id="msg" runat="server">
                <span class="glyphicon glyphicon-remove"></span>
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="well">
                <table>
                    <tr valign="middle">
                        <td class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Pozo"></asp:Label></td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtCia" runat="server" CssClass="form-control" Height="28px" Width="180px" CausesValidation="True"></asp:TextBox>
                            <td class="auto-style1">
                                <asp:LinkButton ID="btnNuevo" runat="server" CssClass="btn btn-sm btn-success"><i class="glyphicon glyphicon-saved"></i>&nbsp;Guardar</asp:LinkButton></td>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="GridMsg" runat="server" class="alert alert-danger">
                <span class="glyphicon glyphicon-remove"></span>
                <asp:Label ID="lblGridMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Lista de Pozos</h3>
                </div>
                <div class="panel-body">
                    <center>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False"
                            CellPadding="4"
                            Font-Size="Smaller" ForeColor="#333333" GridLines="None" AutoGenerateEditButton="True">
                            <AlternatingRowStyle CssClass="alt" BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible =" false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEditIdPozo" runat="server" Text='<%# Bind("idPozo")%>' Visible="false"></asp:Label>                                        
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("idPozo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pozo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("strNombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("strNombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle VerticalAlign="Top" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <EditItemTemplate>
                                        <asp:Label ID="editChkValue" runat="server" Text='<%# Bind("bitVisible")%>' Visible="false"></asp:Label>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("bitVisible")%>' Enabled="false"/>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton 
                                            ID="lnkRemove" 
                                            runat="server"
                                            CommandArgument='<%# Eval("idPozo")%>'
                                            Text="Eliminar" 
                                            OnClick="GridView1_RowDeleting">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" CssClass="pgr" ForeColor="White"
                                HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </center>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

