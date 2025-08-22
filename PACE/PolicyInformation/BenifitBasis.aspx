<%@ Page Language="C#" AutoEventWireup="true" Inherits="PolicyInformation_BenifitBasis"
    CodeBehind="BenifitBasis.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Benefit Basis</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="divBenifitBasis" style="width: 100%" runat="server">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <th class="strip-title" valign="top">
                            Benefit Basis
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvBenifitBasis" runat="server" Width="100%" AutoGenerateColumns="false"
                                AllowPaging="true" PageSize="5" OnRowCommand="gvBenifitBasis_RowCommand" OnPageIndexChanging="gvBenifitBasis_PageIndexChanging">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:BoundField DataField="PlanMasterCode" HeaderText="Plan Master Code" HeaderStyle-Wrap="false"
                                        ItemStyle-Wrap="false" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgView" runat="server" ImageUrl="~/App_Themes/Theme/Images/View.png"
                                                Height="35px" Width="35px" CommandArgument='<%#Eval("PlanMasterCode") %>' CommandName="view" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Cover" HeaderText="Cover" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                    <asp:BoundField DataField="MultipleSalary" HeaderText="Multiple Salary" HeaderStyle-Wrap="false"
                                        ItemStyle-Wrap="false" />
                                    <asp:BoundField DataField="CoverTypeCode" HeaderText="Cover Type Code" HeaderStyle-Wrap="false"
                                        ItemStyle-Wrap="false" />
                                    <asp:BoundField DataField="CoverTypeName" HeaderText="Cover Type Name" HeaderStyle-Wrap="false"
                                        ItemStyle-Wrap="false" />
                                    <asp:BoundField DataField="PolicyYear" HeaderText="Policy Year" HeaderStyle-Wrap="false"
                                        ItemStyle-Wrap="false" />
                                    <asp:BoundField DataField="PolicyCoveragePlanUID" HeaderText="PlanMasterCode" HeaderStyle-Wrap="false"
                                        ItemStyle-Wrap="false" Visible="false" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>
                                <b><span style="color: Red">*</span> <span style="text-decoration: underline;">Note</span>:-</b>The
                                above mentioned Benefit Basis may not be applicable to all members. Kindly refer
                                to policy quotation for further details.</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="trViewGrid" runat="server" visible="false">
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                <tr>
                                    <th id="thView" class="strip-title" valign="top">
                                        Designationwise
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvDisplay" runat="server" Width="100%" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="5" OnPageIndexChanging="gvDisplay_PageIndexChanging">
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                PageButtonCount="3" />
                                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:BoundField DataField="SrNo" HeaderText="Sr No." HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                                <asp:BoundField DataField="cover" HeaderText="Cover" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                                <asp:BoundField DataField="DesignationCode" HeaderText="Designation Code" HeaderStyle-Wrap="false"
                                                    ItemStyle-Wrap="false" />
                                                <asp:BoundField DataField="DesignationName" HeaderText="Designation Name" HeaderStyle-Wrap="false"
                                                    ItemStyle-Wrap="false" />
                                            </Columns>
                                        </asp:GridView>
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
