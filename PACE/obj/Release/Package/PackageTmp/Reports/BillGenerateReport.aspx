<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="Services_BillGenerateReport" Codebehind="BillGenerateReport.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BillReport</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server" ID="SMBill">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="rvBILL" runat="server" Height="700px" Width="700px">
        </rsweb:ReportViewer>
        <asp:Label runat="server" ID="lblnomessage" Visible="False" Text="No record found to display."></asp:Label>
    </div>
    </form>
</body>
</html>
