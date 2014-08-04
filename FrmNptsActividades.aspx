<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmNptsActividades.aspx.vb" Inherits="_Default" %>

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
                    
                    Npts-Actividades</h3>
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
                        <p><asp:Label ID="Label4" runat="server" Text="Actividades"></asp:Label></p>
                </td>
                <td>
                    <br />
                    <asp:DropDownList ID="CmbActividades" runat="server" CssClass="form-control" Height="28px" Width="180px" AutoPostBack="True"></asp:DropDownList>

                </td>
            </tr>

        </table>      
        <br />            
        <br />

        <table>
            <tr>
                <th>No Asignado</th>
                <th></th>
                <th>Asignado</th>
            </tr
            <td></td>
            <tr>
                <td>
                    <asp:ListBox ID="LblNoasignado" runat="server" SelectionMode="Multiple" Width="500px" CssClass="list-group-item"></asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text=">" CssClass="btn btn-info" />
                    <br />
                    <br />
                    <asp:Button ID="Button3" runat="server" Text="<" CssClass="btn btn-info" />

                </td>
                <td>
                    <asp:ListBox ID="LblAsignado" runat="server" SelectionMode="Multiple" Width="500px" CssClass="list-group-item"></asp:ListBox>
                </td>
            </tr>
        </table>

    </div>

   </ContentTemplate>
</asp:UpdatePanel>
    
</asp:Content>

