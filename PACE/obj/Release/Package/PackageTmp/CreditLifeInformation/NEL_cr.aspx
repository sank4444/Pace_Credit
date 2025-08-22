<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NEL_cr.aspx.cs" 
Inherits="PACE.CreditLifeInformation.NEL_cr" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>NEL</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%" border="0" cellpadding="5" cellspacing="5">
                    <tr>
                        <th class="strip-title" valign="top">
                            Non Medical Limit (NML)
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 100%;">
                                <asp:GridView ID="gvMedicalNonMedical" runat="server" OnRowCommand="gvMedicalNonMedical_RowCommand"
                                    DataKeyNames="MedicalNonMedicalMappingUID" AllowPaging="true" PageSize="5" Width="700px"
                                    AutoGenerateColumns="false" OnPageIndexChanging="gvMedicalNonMedical_PageIndexChanging">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        PageButtonCount="3" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Medical Chart Code" Visible ="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkButMediChartcode" runat="server" Text='<%#Eval("MedicalChartCode")%>'
                                                    ToolTip='<%#Eval("MedicalChartCode")%>' CommandName="VIEWMEDICODE" CommandArgument='<%#Eval("MedicalChartCode")%>'
                                                    ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Non Medical Chart Code">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkButNonMediChartcode" runat="server" Text='<%#Eval("NonMedicalChartCode")%>'
                                                    ToolTip='<%#Eval("NonMedicalChartCode")%>' CommandName="VIEWNONMEDICODE" CommandArgument='<%#Eval("NonMedicalChartCode")%>'
                                                    ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FromDate" HeaderText="From Date"></asp:BoundField>
                                        <asp:BoundField DataField="ToDate" HeaderText="To Date"></asp:BoundField>
                                        <asp:BoundField DataField="Freeze" HeaderText="Freeze"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr id="trgv" runat="server" >
                        <td class="strip-title" valign="top">
                            Non Medical Chart Details
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 50%;">
                                <asp:GridView ID="gvNonMedicalCodeDetails" runat="server" AllowPaging="true" PageSize="5"
                                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="gvNonMedicalCodeDetails_PageIndexChanging">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        PageButtonCount="3" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="NonMedicalLimitCode" HeaderText="NM Code"></asp:BoundField>
                                        <asp:BoundField DataField="From_AGE" HeaderText="From Age"></asp:BoundField>
                                        <asp:BoundField DataField="To_AGE" HeaderText="To Age"></asp:BoundField>
                                        <asp:BoundField DataField="Sum_Assured" HeaderText="Sum Assured"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="tbReport" runat="server" visible="false">
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="rptNEL" runat="server" Height="470px" Width="100%" ShowPrintButton="False"
                                Visible="False">
                            </rsweb:ReportViewer>
                            <asp:Label runat="server" ID="lblNoTextMsg" Visible="false" Text="No Records Found">
                            </asp:Label>
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
