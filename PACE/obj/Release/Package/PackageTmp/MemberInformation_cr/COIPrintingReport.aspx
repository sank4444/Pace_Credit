<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="COIPrintingReport.aspx.cs" Inherits="GLIMPSE.Web.Reports.COIPrintingReport" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <base target="_self">
    <title>COI Printing Report</title>

    <script src="../../../Script/Common.js" type="text/javascript"></script>

    <script src="../../../Script/script.js" type="text/javascript"></script>

    <link href="../../../App_Themes/Cocotree/Styles/Style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        window.onload = function() {
        var formatDropDown = document.getElementById('RptCOIPrintReport_ctl01_ctl05_ctl00');
            if (formatDropDown != null) {
                formatDropDown.remove(1);
            }
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="width: 100%;" valign="top">
                    <div style="width: 100%;" class="MainContentHeader">
                        <asp:Label ID="lblCOIPrintReport" runat="server" Font-Bold="True" Font-Names="Raavi" Font-Size="Medium"
                            ForeColor="White" Text="COI Printing Report"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td>
                     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <rsweb:ReportViewer ID="RptCOIPrintReport" runat="server" Font-Names="Verdana"
                     ShowPrintButton="false"
                        Font-Size="8pt" Height="675px" Width="100%" Visible="false">
                    </rsweb:ReportViewer>
                    <asp:Label runat="server" ID="lblNoTextMsg" Visible="false" Text="No Records Found"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
