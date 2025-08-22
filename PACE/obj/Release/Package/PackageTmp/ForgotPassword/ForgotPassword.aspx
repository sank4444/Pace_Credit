<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="PACE.ForgotPassword.ForgotPassword" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="inputbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="inputbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtRepassword" runat="server" CssClass="inputbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSummary" runat="server" Width="60%" Height="60px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LdqwfsSAAAAAHJ_WitXo4_S5clpiK9ptcmcepT9"
                                PrivateKey="6LdqwfSAAAAACO1PSFSsjE3hw9KyugcPOb2irp9" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="btnlogin" runat="server" ForeColor="#FFFFFF" ToolTip="Login"
                                ImageUrl="~/App_Themes/Theme/Images/Btn_bg.png" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
            <div class="UpdateProgressmodal">
                <div class="UpdateProgresscenter">
                    <asp:Label ID="labelDisplay" runat="server" Text="Processing..."></asp:Label>
                    <br />
                    <img id="progessImage" src="../App_Themes/Theme/Images/loading.gif" alt="" width="70" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
