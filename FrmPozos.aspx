<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmPozos.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        
    <div class="row">
        <div class="form-group">
            <div class="col-md-8">
                
                <h3>
                    Catálogo de Pozos</h3>
                <hr />
                
            </div>            
        </div>
    </div>
    
    <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="btn btn-success" />
    <br />
<br />

    <div class="well">
        <table>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label></td>
                <td><asp:TextBox ID="TxtNivel3" runat="server" CssClass="form-control" Height="28px" Width="180px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Internvención"></asp:Label></td>
                <td>
                    <br />
                    <asp:DropDownList ID="CmdIntervencion" runat="server" CssClass="form-control" Height="28px" Width="180px" AutoPostBack="True"></asp:DropDownList> </td>
            </tr>
             <tr>
                <td>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Año"></asp:Label></td>
                <td>
                    <br />
                    <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control" Height="28px" Width="180px" ></asp:TextBox>
                    <asp:CalendarExtender ID="txtAnio_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtAnio" Format="yyyy">
                    </asp:CalendarExtender>
                    </td>
            </tr>
             <tr>
                <td>
                    <br />
                        <p><asp:Label ID="Label4" runat="server" Text="Plataforma"></asp:Label></p>
                </td>
                <td>
                    <br />
                    <asp:DropDownList ID="CmdPlataforma" runat="server" CssClass="form-control" Height="28px" Width="180px"></asp:DropDownList>

                </td>
            </tr>
                <tr>
                <td>
                    <br />
                        <p><asp:Label ID="Label5" runat="server" Text="Equipo"></asp:Label></p>
                </td>
                <td>
                    <br />
                    <asp:DropDownList ID="CmdEquipo" runat="server" CssClass="form-control" Height="28px" Width="180px"></asp:DropDownList>
                </td>
            </tr>
                <tr>
                <td>
                    <br />
                        <p><asp:Label ID="LblSubInter" runat="server" Text="Tipo Rma" Visible="False"></asp:Label></p>
                </td>
                <td>
                    <br />
                    <asp:DropDownList ID="CmdSubInter" runat="server" CssClass="form-control" Height="28px" Width="180px" Visible="False"></asp:DropDownList>

                </td>
            </tr>
        </table>
      
                    <br />
            
                
                    <br />
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Lista Pozos</h3>
        </div>
        <div class="panel-body">
            <center>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" 
                            CellPadding="4"
                            Font-Size="Smaller" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle CssClass="alt" BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="idIntervencion" HeaderText="Id" HtmlEncode="false">
                                    <ItemStyle  Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pozo" HeaderText="Pozo" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle  VerticalAlign="Top" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="inter" HeaderText="Intervencion" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle  VerticalAlign="Top" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="anio" HeaderText="Año" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle  VerticalAlign="Top" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="plata" HeaderText="Plataforma" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle  VerticalAlign="Top" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="equ" HeaderText="Equipo" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle  VerticalAlign="Top" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="catSub" HeaderText="Tipo" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle  VerticalAlign="Top" Width="200px" />
                                </asp:BoundField>
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

