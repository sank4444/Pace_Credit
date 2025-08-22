<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberInfoPopUp_cr.aspx.cs" 
Inherits="PACE.MemberInformation_cr.MemberInfoPopUp_cr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Member Information PopUp</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlHistory" ScrollBars="Both" runat="server">
                <table cellspacing="0" cellpadding="0" border="0" style="height: 100%; width: 100%;">
                    <tr>
                        <th class="strip-title" colspan="4" valign="top" id="thHeader" runat="server">
                            Member Information Creadit Life
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvServicing" runat="server" Width="100%" AllowPaging="True" OnPageIndexChanging="gvBillEnuiry_PageIndexChanging"
                                EmptyDataText="No record found">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
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

