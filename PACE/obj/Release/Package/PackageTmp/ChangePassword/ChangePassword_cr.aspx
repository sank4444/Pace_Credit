<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword_cr.aspx.cs" Inherits="PACE.ChangePassword.ChangePassword_cr"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function ReturningDefault() {
            alert("Password changed successfully.");
            window.location = "../Default_CL.aspx";
        }
    </script>

    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
 <table width="100%" border="0" cellpadding="2" cellspacing="0">
        <tr>
            <th class="strip-title" colspan="2" valign="top">
                Change Password
            </th>
        </tr>
        <tr>
            <td width="200px" align="left" style="text-align: left; padding-left: 5px;">
                Old Password
            </td>
            <td>
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="inputbg"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword"
                    ErrorMessage="*">
                </asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td align="left" style="text-align: left; padding-left: 5px;">
                New Password
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="inputbg"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="text-align: left; padding-left: 5px;">
                Confirm Password
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="inputbg"></asp:TextBox>
                 <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                    ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm password should be match new password"
                    Font-Names="Verdana" Font-Size="Small">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/CImage.aspx" />
            </td>
        </tr>
        <tr align="left">
            <td align="left" style="text-align: left; padding-left: 15px;">
                Enter above text
            </td>
            <td nowrap="nowrap">
                <asp:TextBox ID="TxtCaptchaCode" runat="server" CssClass="inputbg"> 
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="font-family: Verdana; font-size: small">
            </td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Submit.png"
                    Width="100px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
