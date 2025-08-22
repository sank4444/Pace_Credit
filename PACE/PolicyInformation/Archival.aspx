<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Archival.aspx.cs" Inherits="PACE.PolicyInformation.Archival" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Archival</title>

    <script src="https://code.jquery.com/jquery-1.12.3.js" type="text/javascript"></script>

    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>

    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style type="text/css">
        div .container 
        {
            width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smArchive" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upArchive" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <th class="strip-title" valign="top" colspan="2">
                        Archival
                    </th>
                </tr>
                <tr>
                    <td>
                        Policy year &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlPolicyYear" runat="server" CssClass="styled-select" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPolicyYear_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td >
                        <div style="width:100%;">
                            <asp:GridView ID="gvArchival" runat="server" AutoGenerateColumns="false" CssClass="display"
                                Width="100%" OnRowCommand="gvArchival_RowCommand">
                                <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />--%>
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDownload" Text="Download" CommandName='download' CommandArgument='<%# Eval("Download") %>'
                                                runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="progessArchive" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upArchive"
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
