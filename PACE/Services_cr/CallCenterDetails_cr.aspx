<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallCenterDetails_cr.aspx.cs" Inherits="PACE.Services_cr.CallCenterDetails_cr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <title>Call center query details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="5" cellspacing="5" style="width: 98%">
        <tr>
            <td>Query Status
            </td>
            <td>
            <asp:TextBox ID="txtQueresStatus" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Complaint Name
            </td>
            <td>
            <asp:TextBox ID="txtComplaintName" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Complaint
            </td>
            <td>
            <asp:TextBox ID="txtComplaint" runat="server" CssClass="TextBoxMulti" Enabled="false"></asp:TextBox>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
