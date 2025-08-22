<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PremiumRateReport_cr.aspx.cs"
 Inherits="PACE.Report_CreditLife.PremiumRateReport_cr" %>
<%--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
--%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Premium Rate</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th class="strip-title" valign="top">
                Premium Rate Report
            </th>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:GridView ID="gvPremiumRate" runat="server"  Visible="false"
                    AllowPaging="true" PageSize="5" Width="100%" AutoGenerateColumns="true" OnPageIndexChanging="gvPremiumRate_PageIndexChanging">
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                        PageButtonCount="3" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                    </Columns>
                </asp:GridView>
                
                 <asp:ScriptManager runat="server" ID="smPremiumRaeReport">
                </asp:ScriptManager>
                <rsweb:ReportViewer runat="server" ID="rvPremiumRateReport" Height="470px" ShowPrintButton="False"
                    Visible="False" Width="100%">
                </rsweb:ReportViewer>
                <asp:Label runat="server" ID="lblNoTextMsg" Visible="false" Text="No Records Found">
                </asp:Label>
                
              <%--  <asp:ScriptManager runat="server" ID="smPremiumRaeReport">
                </asp:ScriptManager>
                <rsweb:ReportViewer runat="server" ID="rvPremiumRateReport" Height="470px" ShowPrintButton="False"
                    Visible="False" Width="100%">
                </rsweb:ReportViewer>
                <asp:Label runat="server" ID="lblNoTextMsg" Visible="false" Text="No Records Found">
                </asp:Label>--%>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
