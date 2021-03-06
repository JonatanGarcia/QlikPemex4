﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmActividades.aspx.vb" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:scriptmanager runat="server"></asp:scriptmanager>
    <asp:updatepanel runat="server">
         <ContentTemplate>
    <div class="row">
        <div class="form-group">
            <div class="col-md-8">
                <h3>Catálogo de Actividades</h3>
                <hr />
            </div>
        </div>
    </div>
    <br />
   <div class="alert alert-danger" id="msg" runat="server">
        <span class="glyphicon glyphicon-remove"></span>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="well">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Height="28px" Width="180px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Internvención"></asp:Label></td>
                <td>
                    <br />
                    <asp:DropDownList
                        ID="ddlIntervencion"
                        runat="server"
                        CssClass="form-control"
                        Height="28px"
                        Width="180px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Secuencia"></asp:Label></td>
                <td>
                    <br />
                    <asp:TextBox ID="txtSecuencia" runat="server" CssClass="form-control" Height="28px" Width="180px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <p>
                        <asp:Label ID="Label4" runat="server" Text="Descripción"></asp:Label>
                    </p>
                </td>
                <td>
                    <br />
                    <asp:TextBox ID="txtDescripcion" runat="server" Height="100px" TextMode="MultiLine" Width="296px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <br />
                    <asp:LinkButton ID="btnNuevo" runat="server" CssClass="btn btn-success "><i class="glyphicon glyphicon-saved"></i>&nbsp;Guardar</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>

    <div class="alert alert-danger" id="msgUpdate" runat="server">
        <span class="glyphicon glyphicon-remove"></span>
        <asp:Label ID="lblErrorUpdate" runat="server" ForeColor="Red"></asp:Label>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Lista de Actividades</h3>
        </div>        
        <div class="panel-body">        
            <center>
                <asp:GridView
                    ID="GridView1"
                    runat="server"
                    AllowPaging="True"
                    AutoGenerateColumns="False"
                    CellPadding="4"
                    Font-Size="Smaller"
                    ForeColor="#333333"
                    GridLines="None" AutoGenerateEditButton="True">
                    <AlternatingRowStyle CssClass="alt" BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <EditItemTemplate>
                                <asp:Label ID="TextBox1" Visible="false" runat="server" Text='<%# Bind("idActividad") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("idActividad") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actividades">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Actividad") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Actividad") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top" Width="200px" />
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:TemplateField> <asp:TemplateField HeaderText="Descripcion">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Descripcion")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("Descripcion")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top" Width="200px" />
                            <ItemStyle HorizontalAlign="Left" Width="400px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Secuencia">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Secuencia") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Secuencia") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top" Width="200px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Intervencion">
                            <EditItemTemplate>
                                <asp:Label ID="lblInter" Visible="false" runat="server" Text='<%# Bind("idTipo")%>'></asp:Label>
                                <asp:DropDownList 
                                    ID="ddlEditInterv" 
                                    runat="server">                                    
                                </asp:DropDownList>
                              </EditItemTemplate>                          
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("strNombreTipo")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top" Width="200px" />
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton
                                    ID="lnkRemove"
                                    runat="server"
                                    CommandArgument='<%# Eval("idActividad")%>'
                                    Text="Eliminar"
                                    OnClick="GridView1_RowDeleting">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" CssClass="pgr" ForeColor="White" HorizontalAlign="Center" />
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
     </asp:updatepanel>
</asp:Content>