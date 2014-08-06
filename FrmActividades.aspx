<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmActividades.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="form-group">
            <div class="col-md-8">
                
                <h3>Catálogo de Actividades</h3>
                <hr />
                
            </div>            
        </div>
    </div>
    <asp:LinkButton ID="Button1" runat="server"  CssClass="btn btn-success "><i class="glyphicon glyphicon-saved"></i>&nbsp;Guardar</asp:LinkButton>
    <%--<asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="btn btn-success" />--%>
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
                    <asp:DropDownList ID="CmdN1" runat="server" CssClass="form-control" Height="28px" Width="180px"></asp:DropDownList> </td>
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
                        <p><asp:Label ID="Label4" runat="server" Text="Descripción"></asp:Label></p>
                </td>
                <td>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Height="110px" TextMode="MultiLine" Width="296px"></asp:TextBox>
                </td>
            </tr>
        </table>
      
                    <br />
            
                
                    <br />
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Lista Equipos</h3>
        </div>
        <div class="panel-body">
            <center>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" 
                            CellPadding="4"
                            Font-Size="Smaller" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle CssClass="alt" BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="idact" HeaderText="Id" HtmlEncode="false">
                                    <ItemStyle  Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="act" HeaderText="Actividades" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle  VerticalAlign="Top" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="secuencia" HeaderText="Secuencia" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle  VerticalAlign="Top" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="intervencion" HeaderText="Intervencion" HtmlEncode="false">
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

</asp:Content>

