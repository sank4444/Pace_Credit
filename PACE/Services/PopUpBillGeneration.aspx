<%@ Page Language="C#" AutoEventWireup="true" Inherits="Services_PopUpBillGeneration"
    CodeBehind="PopUpBillGeneration.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Generation Details</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Theme/StyleSheets/PageLevelStyleSheet.css" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table>
                    <tr>
                        <th class="strip-title" colspan="4" valign="top">
                            Bill Generation
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table cellspacing="0" style="width: 100%; border: solid 1px black">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 100%;">
                                        <div style="width: 980px; height: 450px; overflow: auto;">
                                            <rsweb:ReportViewer ID="rpt1" runat="server" Height="450px" Width="980px">
                                            </rsweb:ReportViewer>
                                            <asp:Label runat="server" ID="lblnomessage" Visible="False" Text="No record found to display."></asp:Label>
                                        </div>
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
</body>
</html>
