<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillEnquiry_cr.aspx.cs"
    MasterPageFile="~/Masters/MenuMasterPage_Cr.master" Inherits="PACE.MIS.BillEnquiry_cr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:UpdatePanel ID="UPInsured" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <th class="strip-title" colspan="4" valign="top">
                        <%-- Billing Enquiry Credit Life--%>
                        <asp:Label ID="lblreportname" runat="server" Text=""></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td colspan="4" width="100%">
                        <div id="div2" style="width: 999px; border: 0px black solid;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="text-align: left; width: 15%">
                                        Period From
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:TextBox ID="txtPeriodFrom" runat="server" CssClass="inputbg1"> 
                                        </asp:TextBox>
                                        <asp:ImageButton ID="imgPeriodFrom" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                            ImageAlign="Middle" Height="20px" Width="20px" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPeriodFrom"
                                            PopupButtonID="imgPeriodFrom">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td>
                                        Period To
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPeriodTo" runat="server" Enabled="true" CssClass="inputbg1">
                                        </asp:TextBox>
                                        <asp:ImageButton ID="imgPeriodTo" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                            ImageAlign="Middle" Height="20px" Width="20px" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPeriodTo"
                                            PopupButtonID="imgPeriodTo">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div id="divName" style="display: none;">
                                        </div>
                                    </td>
                                    <td >
                                        <div id="divPeriodTo" style="display: none;">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 20px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center; line-height: 30px;">
                                        <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" ToolTip="Search"
                                            OnClientClick="return Validation()" Text="Search" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png" />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="trExcel" runat="server" visible="false">
                                    <%-- visible="false" ExportToExcel.png Export.png--%>
                                    <td colspan="4" style="text-align: right;">
                                        <asp:ImageButton ID="imgExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                                            Width="40px" Height="40px" AlternateText="Export" ToolTip="Export To Excel" OnClick="imgExportToExcel_Click" />
                                        <%--Visible="false"--%>
                                    </td>
                                </tr>
                                <tr id="trGrid" runat="server" visible="true">
                                    <td colspan="4" style="text-align: left;">
                                        <div id="div" style="width: 999px; overflow-x: scroll; overflow-y: scroll; border: 0px black solid;">
                                            <asp:GridView runat="server" ID="gvBillEnuiry" AutoGenerateColumns="true" GridLines="Both"
                                                PageSize="3" EmptyDataText="No record found" Visible="true" AllowPaging="True"
                                                OnPageIndexChanging="gvBillEnuiry_PageIndexChanging" OnRowCommand="gvBillEnuiry_RowCommand">
                                                <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                                    NextPageText="Next" />
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <%-- LS Craete  
                              <RowStyle CssClass="GridViewRowStyle" />
                                --%>
                                                <%-- 
                                    <Columns>
                                    <asp:TemplateField HeaderText="Invoice">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkInvocePdf" runat="server" ToolTip="Click to Download PDF"
                                                CommandArgument='<%#Eval("BillUID") %>' CommandName="printPdf">
                                                <img src="../App_Themes/Theme/Images/PDF.png" height="46px" width="37px" style="border:none;" />
                                             </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill No">
                                        <ItemTemplate>
                                            <a href="#" id="BillNo" onclick='openWindow("<%# Eval("MISCODE") %>");'>
                                                <%# Eval("MISCODE")%></a>
                                            <asp:Label ID="txtBillNo" runat="server" Visible="false" Text='<%# Eval("MISCODE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>--%>
                                                <%--<asp:BoundField DataField="BillingModeName" HeaderText="Mode" />
                                    <asp:BoundField DataField="NetPremium" HeaderText="Gross Premium" />
                                    <asp:BoundField DataField="Loading_Premium" HeaderText="Loading Premium" />
                                    <asp:BoundField DataField="ServiceTaxAmt" HeaderText="Service Tax" />
                                    <asp:BoundField DataField="EdcessAmt" HeaderText="EdCess" />
                                    <asp:BoundField DataField="PaidAmt" HeaderText="Paid Amount" />
                                    <asp:BoundField DataField="OutstandingAmt" HeaderText="Outstanding Amount" />
                                    <asp:BoundField DataField="BillToDT" HeaderText="Bill To Date" />
                                    <asp:BoundField DataField="BillDueDT" HeaderText="Bill Issue Date" />
                                    
                                    </Columns>
                                    --%>
                                            </asp:GridView>
                                            
                                           
                                            
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <%--<td>
                        <p>
                            <b><span style="font-size: 26px; color: Red;">*</span>Note :</b>- Service tax includes
                            "Service Tax" at the applicable rate from time to time and "Swach Bharat Cess" with
                            effect from 15-Nov-2015.</p>
                    </td>--%>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
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
            window.open('PopUpBillEnquiry_cr.aspx?BillNo=' + code, 'popWindow', 'toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=1,width=920,height=540,left = 90,top = 90');
        }
        function openWindowInvoice(code) {
            window.open('../Reports/BillGenerateReport.aspx?BillNo=' + code, 'popWindow', 'toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=1,width=920,height=540,left = 90,top = 90');
        }
        $(function() {
            //$("#div").accordion();
        });
        
        
  function Validation() {
            var Periodfrm = $('#<%=txtPeriodFrom.ClientID %>').val();
          var PeriodTo = $('#<%=txtPeriodTo.ClientID %>').val();
          if (Periodfrm == "" || PeriodTo == "" ) {
                $('#divName').css('display', 'inline');
                $('#divName').html('<span id="DisplayingError" class="DisplayingError">Please enter Period From and To can\'t be Empty </span>');
                $('#<%=txtPeriodFrom.ClientID %>').focus();
                $('#DisplayingError').click(function() { $('#<%=txtPeriodFrom.ClientID %>').focus(); });
                return false;
            }
//            else if ( PeriodTo == "") {
//                $('#divPeriodTo').css('display', 'inline');
//                $('#divPeriodTo').html('<span id="DisplayingError" class="DisplayingError">Please enter Period To can\'t be Empty </span>');
//                $('#<%=txtPeriodTo.ClientID %>').focus();
//                $('#DisplayingError').click(function() { $('#<%=txtPeriodTo.ClientID %>' ).focus(); });
//                return false;
//            }
            else {
                return true;
            }
        }
    </script>

</asp:Content>
