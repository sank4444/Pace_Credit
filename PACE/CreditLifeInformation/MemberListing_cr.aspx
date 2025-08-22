<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberListing_cr.aspx.cs" Inherits="PACE.CreditLifeInformation.MemberListing_cr" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Member Listing</title>

    <script src="https://code.jquery.com/jquery-1.12.3.js" type="text/javascript"></script>

    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th class="strip-title" colspan="4" valign="top">
                            Member Listing
                        </th>
                    </tr>
                    <tr>
                        <td valign="bottom" style="vertical-align: bottom">
                            Please Select Policy Period &nbsp;&nbsp;
                            <asp:DropDownList ID="ddlPolicyYear" runat="server" CssClass="styled-select" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlPolicyYear_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:ImageButton ID="btnExportToExcel" runat="server" ImageAlign="Bottom" CssClass="ImageAligament"
                                Visible="false" ToolTip="Export to Excel" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                                OnClick="btnExportToExcel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 100%;">
                            <asp:UpdatePanel ID="UPInsured" runat="server">
                                <ContentTemplate>
                                    <tr>
                                        <td style="width: 100%;" valign="top">
                                            <asp:GridView ID="gvMemberList" runat="server" CssClass="display">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnExportToExcel" />
                                </Triggers>
                            </asp:UpdatePanel>
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
    <script type="text/javascript">
        $(document).ready(function() {
            $('.display').DataTable();
        });
    </script>
    </form>
</body>
</html>


