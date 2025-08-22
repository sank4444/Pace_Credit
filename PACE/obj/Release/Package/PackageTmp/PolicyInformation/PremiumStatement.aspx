<%@ Page Language="C#" AutoEventWireup="true" Inherits="PolicyInformation_PremiumStatement"
    CodeBehind="PremiumStatement.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Premium Statement</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 35%;
        }
        .style2
        {
            width: 14%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
<%--      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
--%>            <div>
                <table width="100%">
                    <tr>
                        <th class="strip-title" colspan="5" valign="top">
                            Premium Statement
                        </th>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style2">
                            From Date <span style="color: Red">*</span> &nbsp;
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="inputbg"></asp:TextBox>
                            <asp:Image ID="imgPeriodFrom" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                Height="20px" Width="20px" ImageAlign="Middle" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                PopupButtonID="imgPeriodFrom">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td class="style2">
                            To Date<span style="color: Red">*</span> &nbsp;
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="inputbg"></asp:TextBox>
                            <asp:Image ID="imgPeriodTo" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                Height="20px" Width="20px" ImageAlign="Middle" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                PopupButtonID="imgPeriodTo">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png"
                                OnClientClick="return PremiumStatementValidation();" OnClick="imgSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr id="trReport" runat="server">
                        <td colspan="5">
                          
                            <rsweb:ReportViewer ID="rptPremiumStatement" runat="server" Height="470px" Width="100%"
                                ShowPrintButton="true" AsyncRendering="false">
                            </rsweb:ReportViewer>
                            <asp:Label runat="server" ID="lblNoTextMsg" Visible="false" Text="No Records Found">
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
       <%-- </ContentTemplate>
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
    </asp:UpdateProgress>--%>
    </form>

    <script type="text/javascript" language="javascript">

        function Validation() {
            var FromDate = $('#<%=txtFromDate.ClientID %>').val();
            var ToDate = $('#<%=txtToDate.ClientID %>').val();



            if (FromDate == "") {
                $('#divFrom').css('display', 'inline');
                $('#divFrom').html('<span id="DisplayingError" class="DisplayingError">Select FROM DATE </span>');
                $('#<%=txtFromDate.ClientID %>').focus();
                $('#DisplayingError').click(function() { $('#<%=txtFromDate.ClientID %>').focus(); });
                return false;
            }
            else if (ToDate == "") {
                $('#divTo').css('display', 'inline');
                $('#divTo').html('<span id="DisplayingError" class="DisplayingError">Select TO DATE  </span>');
                $('#<%=txtToDate.ClientID %>').focus();
                $('#DisplayingError').click(function() { $('#<%=txtToDate.ClientID %>').focus(); });
                return false;
            }
            else {
                return true;
            }

        }
        
    </script>

</body>
</html>
