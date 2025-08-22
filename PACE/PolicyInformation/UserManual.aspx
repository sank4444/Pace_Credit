<%@ Page Language="C#" AutoEventWireup="true" Inherits="PolicyInformation_UserManual"
    CodeBehind="UserManual.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Manual</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .ImageAligament
        {
            height: 45px;
            width: 45px;
            vertical-align: bottom;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <th class="strip-title" colspan="4" valign="top">
                User Manual
            </th>
        </tr>
    </table>
    </form>
</body>
</html>
