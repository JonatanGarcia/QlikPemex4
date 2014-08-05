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
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
        </style>
</head>
<body style="background-image: url(images/Bubble.png)">
    <form id="form1" runat="server">
        <div style="text-align: center; width: 80%; position: absolute; left: 10%; right: 10%; top: 15%; bottom: 15%;">
            &nbsp;<table 
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
                        <img alt="Stin" src="images/stin.png" >                       
                    </td>                     
                </tr>                
                <tr>
                    <td>Tiempos No Productivos</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser" FailureText="*Usuario o Password incorrecto">
                            <LayoutTemplate>
                                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                                    <tr>
                                        <td>
                                            <table cellpadding="0">
                                                <tr>
                                                    <td align="center" colspan="2">Iniciar sesión</td>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                                <tr align="right" valign="top">
                                                    <td align="right" valign="middle">
                                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="labelwhiteTrim">Usuario:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control" ValidationGroup="login1"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr align="right" valign="top">
                                                    <td align="right" valign="middle">
                                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"  CssClass="labelwhiteTrim">Contraseña:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <td><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="auto-style1" valign="middle">
                                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Recordármelo la próxima vez." CssClass="checkbox" />
                                                    </td>
                                                    <td class="auto-style1"></td>
                                                </tr>                                                
                                                <tr>
                                                    <td align="center" colspan="2" style="color: Red;" valign="top">
                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                    </td>
                                                    <td align="right">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="btn btn-info" Text="Inicio de sesión" ValidationGroup="Login1" />
                                                    </td>
                                                    <td align="right">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:Login>
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
