<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicyQuoteListing.aspx.cs"
    Inherits="PACE.PolicyInformation.PolicyQuoteListing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Policy Quote List</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 100%;" valign="top" class="strip-title">
                            Policy Quote List
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 1px;">
                    <tr>
                        <td align="center" style="width: 15%; vertical-align: top;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 99%;">
                                            <asp:GridView ID="gvPolicyQuoteList" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                EnableAjaxSkinRendering="true" DataKeyNames="PolicyQuoteUID,Fk_PolicyUID,isActive"
                                                OnPageIndexChanging="grdPolicyQuoteList_PageIndexChanging">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                              
<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                    PageButtonCount="3" />
                                                <Columns>
                                                    <asp:BoundField DataField="RenewalNoUID" Visible="false" />
                                                    <asp:BoundField DataField="Fk_SegmentUID" Visible="false" />
                                                    <asp:BoundField DataField="Fk_RiderUID" Visible="false" />
                                                    <asp:BoundField DataField="PremiumRateAppFlag" Visible="false" />
                                                    <asp:BoundField DataField="ReducingRateAppFlag" Visible="false" />
                                                    <asp:BoundField DataField="SegmentName" HeaderText="Segment Name" ItemStyle-Width="12%"
                                                        ReadOnly="true" HeaderStyle-Wrap="false" Visible="false">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemStyle Width="12%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RiderName" HeaderText="Benefit" ItemStyle-Width="10%"
                                                        ReadOnly="true" HeaderStyle-Wrap="false">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Parameters" ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgParameters" runat="server" Text='<%# Eval("ParameterAppFlag") %>'
                                                                CommandName="LNK_PARAMETERS" CausesValidation="False" Height="35px" Width="35px"
                                                                ImageUrl="~/App_Themes/Theme/Images/View.png" ToolTip="Click to view Parameters." />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Premium Rate" ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgPremiumRate" runat="server" Text='<%# Eval("PremiumRateAppFlag") %>'
                                                                Height="35px" Width="35px" CommandName="LNK_PREMIUMRATE" CausesValidation="False"
                                                                OnClientClick="javascript:WindowOpen('PremiumRates.aspx');" ImageUrl="~/App_Themes/Theme/Images/View.png"
                                                                ToolTip="Click to view Premium rate." />
                                                            <%--<asp:LinkButton ID="lnkPremiumRate" runat="server" Text='<%# Eval("PremiumRateAppFlag") %>'
                                                        CommandName="LNK_PREMIUMRATE" CausesValidation="False"></asp:LinkButton>--%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reducing SA" ItemStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkReducingSa" runat="server" Text='<%# Eval("ReducingRateAppFlag") %>'
                                                                CommandName="LNK_REDUCING" CausesValidation="False"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FromDate" HeaderText="From Date" ItemStyle-Width="10%"
                                                        ReadOnly="true" HeaderStyle-Wrap="false">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="To Date" ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblToDate" runat="server" Text='<%# Eval("Todate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Freeze" ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBtnFreeze" runat="server" Text='<%# Eval("Freeze") %>' CommandName="LNK_FREEZE"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Revise" ItemStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBtnRevise" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                Text='<%# Eval("Revise") %>' CommandName="LNK_REVISE" Visible="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="8%"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <%--<PagerTemplate>
                                        <table width="100%" class="BGLTBLU">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPageNo" runat="server" Text="Page" CssClass="TextboxLabel"></asp:Label>
                                                    &nbsp;
                                                    <asp:DropDownList ID="ddlPageSelector" runat="server" Width="50px" AutoPostBack="true"
                                                        CssClass="ListBox">
                                                    </asp:DropDownList>
                                                    of
                                                    <asp:Label ID="lblTotalRows" runat="server" CssClass="TextboxLabel" Text="No Of Rows"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:ImageButton CommandName="Page" CommandArgument="First" runat="server" ID="imgbtnFirst"
                                                        ImageUrl="~/App_Themes/Cocotree/Images/ico_first.jpg" ToolTip="Go to First Page" />
                                                    <asp:ImageButton CommandName="Page" CommandArgument="Prev" runat="server" ID="imgbtnPrevious"
                                                        ImageUrl="~/App_Themes/Cocotree/Images/ico_previous.jpg" ToolTip="Go to Previous Page" />
                                                    <asp:ImageButton CommandName="Page" CommandArgument="Next" runat="server" ID="imgbtnNext"
                                                        ImageUrl="~/App_Themes/Cocotree/Images/ico_next.jpg" ToolTip="Go to Next Page" />
                                                    <asp:ImageButton CommandName="Page" CommandArgument="Last" runat="server" ID="imgbtnLast"
                                                        ImageUrl="~/App_Themes/Cocotree/Images/ico_last.jpg" ToolTip="Go to Last Page" />
                                                </td>
                                            </tr>
                                        </table>
                                    </PagerTemplate>--%>
                                            </asp:GridView>
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
