<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="popupContactinfo_cr.aspx.cs"
    Inherits="PACE.ContactInformation_cr.popupContactinfo_cr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Contact Information</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/PIE_IE678.js" type="text/javascript"></script>

    <style type="text/css">
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="line-height: 16px;">
                    <tr>
                        <th class="strip-title" colspan="4" valign="top">
                            Contact Information
                        </th>
                    </tr>
                    <tr>
                        <td style="width: 100%; margin: 5px">
                            <table width="100%" cellpadding="5" cellspacing="5" border="0" style="text-align: left">
                                <tr>
                                    <td>
                                        Sub office Code
                                    </td>
                                    <td colspan="4">
                                        <asp:Label ID="lblUnitCode" runat="server" Width="90%">
                                        </asp:Label>
                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" BorderColor="#b3b3b3"
                                            Radius="10" Corners="All" TargetControlID="lblUnitCode">
                                        </cc1:RoundedCornersExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sub office Name
                                    </td>
                                    <td colspan="4">
                                        <asp:Label ID="lblUnitName" runat="server" Width="90%">
                                        </asp:Label>
                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" BorderColor="#b3b3b3"
                                            Radius="10" Corners="All" TargetControlID="lblUnitName">
                                        </cc1:RoundedCornersExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Address
                                    </td>
                                    <td colspan="4">
                                        <input id="txtAddress" runat="server" type="text" style="width: 90%; height: 25px;
                                            padding-left: 5px; border-radius: 10px;" disabled="True" />
                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" BorderColor="#b3b3b3"
                                            Radius="10" Corners="All" TargetControlID="txtAddress">
                                        </cc1:RoundedCornersExtender>
                                        <%--  <asp:TextBox ID="txtAddress" runat="server" Width="90%" TextMode="MultiLine" Height="40px"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Contact Person Name
                                    </td>
                                    <td style="margin-bottom:20px" >
                                        <asp:TextBox ID="txtContPerName" runat="server" CssClass="inputbgls" Enabled="False"></asp:TextBox>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContPerName"
                                            ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Please enter characters: Alphabets and space."
                                            ForeColor="Black" />
                                    </td>
                                    <td>
                                        Contact Number
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContactNo" runat="server" CssClass="inputbg" onkeypress="javascript:return isNumber(event)"
                                            Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Contact Person Email
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbgls" Enabled="False"></asp:TextBox>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid mail "
                                            ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ForeColor="Black"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        Contact Person Designation
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="inputbg" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Button ID="btnEdit" runat="server" CssClass="edit_button" OnClick="btnEdit_Click" />
                                        <asp:Button ID="btnSave" runat="server" CssClass="save_button" OnClick="btnSave_Click"
                                            Enabled="false" />
                                        &nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="cancel_button" OnClientClick="closeWin();" />
                                    </td>
                                </tr>
                            </table>
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

    <script type="text/javascript" language="javascript">
        function closeWin() {
            window.close();
        }
//  ls      $(function() {
//            if (window.PIE) {
//                $('.rounded').each(function() {
//                    PIE.attach(this);
//                });
//            }
//        });
        
         function isNumber(evt) {
        var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
            return false;

        return true;
    }    
    </script>

</body>
</html>
