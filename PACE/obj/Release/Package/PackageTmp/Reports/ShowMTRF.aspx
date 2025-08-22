<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="ShowMTRF.aspx.cs" Inherits="PACE.Reports.ShowMTRFaspx" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Medical Test Request Form</title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:ScriptManager runat="server" ID="SMBill">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="rvMTRF" runat="server" Height="700px" Width="700px">
        </rsweb:ReportViewer>
        <asp:Label runat="server" ID="lblnomessage" Visible="False" Text="No record found to display."></asp:Label>
     </div>
    </form>
</body>
</html>
