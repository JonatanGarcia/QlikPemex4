<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>STIN - Tiempos No Productivos</title>
    <link href="Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-image: url(images/Bubble.png)">
    <form id="form1" runat="server">
        <div style="text-align: center; width: 80%; position: absolute; left: 10%; right: 10%; top: 15%; bottom: 15%;">
            &nbsp; 
            <table 
                    width="50%";
                    style="margin: auto; 
                    vertical-align: middle; 
                    background-color:#F0F0F0; 
                    border-radius:35px; 
                    border-color:#ffffff;">
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <img alt="Stin" class="auto-style1" src="images/stin.png" >                       
                    </td>                     
                </tr>                
                <tr>
                    <td>Tiempos No Productivos</td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="txtUsuario_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtUsuario" WatermarkText="Usuario">
                        </asp:TextBoxWatermarkExtender>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="txtPassword_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtPassword" WatermarkText="Password">
                        </asp:TextBoxWatermarkExtender>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-info" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
