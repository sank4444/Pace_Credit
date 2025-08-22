<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" Inherits="Bill_Enquiry_BillEnquiry" Title="Billing Enquiry"
    CodeBehind="BillEnquiry.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:UpdatePanel ID="UPInsured" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                    <th class="strip-title" colspan="4" valign="top">
                        Billing Enquiry
                    </th>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 100px;">
                                    Bill No.
                                </td>
                                <td style="width: 200px;">
                                    <asp:TextBox ID="txtBillNo" runat="Server" CssClass="inputbg"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                </td>
                                <td style="width: 200px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Period From
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPeriodFrom" runat="server" CssClass="inputbg">
                                    </asp:TextBox>
                                    <asp:Image ID="imgPeriodFrom" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                        ImageAlign="Middle" Height="20px" Width="20px" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPeriodFrom"
                                        PopupButtonID="imgPeriodFrom">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    Period To
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPeriodTo" runat="server" Enabled="true" CssClass="inputbg">
                                    </asp:TextBox>
                                    <asp:Image ID="imgPeriodTo" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                        ImageAlign="Middle" Height="20px" Width="20px" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPeriodTo"
                                        PopupButtonID="imgPeriodTo">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center; line-height: 30px;">
                                    <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" ToolTip="Search"
                                        Text="Search" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png" />
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px;">
                    </td>
                </tr>
                <tr id="trExcel" runat="server" visible="false">
                    <td colspan="4" style="text-align: right; width: 920px;">
                        <asp:ImageButton ID="imgExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                            Visible="false" Width="50px" Height="50px" AlternateText="Export" ToolTip="Export To Excel"
                            OnClick="imgExportToExcel_Click" />
                    </td>
                </tr>
                <tr id="trGrid" runat="server" visible="true">
                    <td colspan="4" style="text-align: left; width: 920px;">
                        <div id="div" style="width: 100%; overflow-x: scroll; overflow-y: scroll; border: 0px black solid;">
                            <asp:GridView runat="server" ID="gvBillEnuiry" AutoGenerateColumns="False" GridLines="Both"
                                Width="100%" PageSize="5" EmptyDataText="No record found" Visible="true" AllowPaging="True"
                                OnPageIndexChanging="gvBillEnuiry_PageIndexChanging" OnRowCommand="gvBillEnuiry_RowCommand">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Invoice">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkInvocePdf" runat="server" ToolTip="Click to Download PDF"
                                                CommandArgument='<%#Eval("BillUID") %>' CommandName="printPdf"><img src="../App_Themes/Theme/Images/PDF.png" height="46px" width="37px" style="border:none;" /></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill No">
                                        <ItemTemplate>
                                            <a href="#" id="BillNo" onclick='openWindow("<%# Eval("BillNo") %>");'>
                                                <%# Eval("BillNo")%></a>
                                            <asp:Label ID="txtBillNo" runat="server" Visible="false" Text='<%# Eval("BillNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="BillingModeName" HeaderText="Mode" />
                                    <asp:BoundField DataField="NetPremium" HeaderText="Gross Premium" />
                                    <asp:BoundField DataField="Loading_Premium" HeaderText="Loading Premium" />
                                    <asp:BoundField DataField="ServiceTaxAmt" HeaderText="Service Tax" />
                                    <asp:BoundField DataField="EdcessAmt" HeaderText="EdCess" />
                                    <asp:BoundField DataField="PaidAmt" HeaderText="Paid Amount" />
                                    <asp:BoundField DataField="OutstandingAmt" HeaderText="Outstanding Amount" />
                                    <asp:BoundField DataField="BillToDT" HeaderText="Bill To Date" />
                                    <asp:BoundField DataField="BillDueDT" HeaderText="Bill Issue Date" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>
                            <b><span style="font-size: 26px; color: Red;">*</span>Note :</b>- Service tax includes
                            "Service Tax" at the applicable rate from time to time and "Swach Bharat Cess" with
                            effect from 15-Nov-2015.</p>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript" language="javascript">
        function openWindow(code) {
            window.open('PopUpBillEnquiry.aspx?BillNo=' + code, 'popWindow', 'toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=1,width=920,height=540,left = 90,top = 90');
        }
        function openWindowInvoice(code) {
            window.open('../Reports/BillGenerateReport.aspx?BillNo=' + code, 'popWindow', 'toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=1,width=920,height=540,left = 90,top = 90');
        }
        $(function() {
            $("#div").accordion();
        });
    </script>

</asp:Content>
