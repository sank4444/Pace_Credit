<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PremiumRates_cr_rnd.aspx.cs"
    Inherits="PACE.CreditLifeInformation.PremiumRates_cr" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
</html>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Premium Rates</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Theme/StyleSheets/jquery.dataTables.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <script src="https://code.jquery.com/jquery-1.12.3.js" type="text/javascript"></script>

    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
            <div>
                <table width="100%">
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr id="trReport" runat="server">
                        <td colspan="5">
                          
                            <rsweb:ReportViewer ID="rvPremiumRateReport"  runat="server" Height="470px" Width="100%"
                              ShowPrintButton="False" AsyncRendering="false"  ><%-- AsyncRendering="false"--%>
                            </rsweb:ReportViewer>
                            <asp:Label runat="server" ID="lblNoTextMsg" Visible="false" Text="No Records Found">
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="5" cellspacing="5" width="100%">
                <tr>
                    <th class="strip-title" valign="top">
                        Premium Rates Credit Life
                    </th>
                </tr>
                <tr>
                    <td>
                        <div id="divMultipleCertNo" style="width: 100%" runat="server">
                            <asp:GridView ID="gvPremiumRates" runat="server" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
                                CssClass="display" Width="100%" OnRowCommand="gvPremiumRates_RowCommand">
                                <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />--%>
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:BoundField DataField="SegmentName" HeaderText="Segment Name"></asp:BoundField>
                                    <asp:BoundField DataField="RatePerName" HeaderText="Base Unit"></asp:BoundField>
                                    <asp:BoundField DataField="RateofInterest" HeaderText="Rate of Interest"></asp:BoundField>
                                    <asp:BoundField DataField="SumAssuredTypeName" HeaderText="Sum Assured Type"></asp:BoundField>
                                    <asp:BoundField DataField="Sex" HeaderText="Gender"></asp:BoundField>
                                    <asp:BoundField DataField="PolicyYear" HeaderText="Policy Year"></asp:BoundField>
                                    <asp:BoundField DataField="Sex" HeaderText="Gender"></asp:BoundField>
                                    <asp:BoundField DataField="Moratorium" HeaderText="Moratorium"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Rate Code">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LnkButRateCode" runat="server" Text='<%#Eval("PremRateCode")%>'
                                                ToolTip='<%#Eval("PremRateCode")%>' CommandName="VIEWRATECODE" CommandArgument='<%#Eval("PremRateCode")%>'
                                                ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <%--<rsweb:reportviewer runat="server" id="rvPremiumRateReport" height="470px" showprintbutton="False"
                                visible="False" width="100%">
                            </rsweb:reportviewer>--%>
                            
                        </div>
                    </td>
                </tr>
            </table>
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
