<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmArchivo.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="form-group">
            <div class="col-md-8">
                <h3>Siop / Plantillas</h3>
                <hr />
            </div>            
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-5">
            <div class="well" >
                <h4>Información a cargar</h4>
                <table>
                    <tr>
                        <td>Tipo Archivo</td>
                        <td><asp:DropDownList ID="CmbArchivo" runat="server" CssClass="form-control" Height="28px" Width="180px">
                            <asp:ListItem Value="TxtSiop">SIOP</asp:ListItem>
                            <asp:ListItem Value="TxtPlantilla">PLANTILLA</asp:ListItem>
                            <asp:ListItem Value="TxtPrograma">PROGRAMA</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><br /> Intervención</td>
                        <td><br /><asp:DropDownList ID="CmbInter" runat="server" CssClass="form-control" Height="28px" Width="180px" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><br /><asp:Label ID="LblTipo" runat="server" Text="Tipo Intervención" Visible="False"></asp:Label></td>
                        <td><br /><asp:DropDownList ID="CmbTipoInter" runat="server" CssClass="form-control" Height="28px" Width="180px" AutoPostBack="True" Visible="False"></asp:DropDownList></td>
                    </tr>
                </table>
             
            </div>
        </div>
         <div class="col-md-5">
            <div class="well" >
                <h4>Seleccionar archivo</h4>
                <table>
                    <tr>
                        <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Subir" CssClass="btn btn-primary" />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-10">
            <div class="well" >
                <h4>Seleccionar Pozo</h4>
                <table>
                       
                    <tr>
                         <td>Pozo</td>
                        <td>
                            <asp:DropDownList ID="CmbPozo" runat="server" CssClass="form-control" Height="28px" Width="180px"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Visualizar"  CssClass="btn btn-info"/>
                <asp:Button ID="Button3" runat="server" Text="Guardar"  CssClass="btn btn-success"/>
            </div>
        </div>
    </div>

    
</asp:Content>

