<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillPayment_cr.aspx.cs" 
MasterPageFile="~/Masters/MenuMasterPage_Cr.master" Inherits="PACE.MIS.BillPayment_cr" %>

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
</html>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" media="all" href="../App_Themes/Theme/StyleSheets/jsDatePick_ltr.min.css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>

    <script src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"
        type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <th class="strip-title" valign="top" colspan="3">
                Bill Payment
            </th>
        </tr>
        <tr>
            <td>
                Policy Reserve Amount
            </td>
            <td>
                <asp:TextBox ID="txtPolicySuspenseAmt" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Policy Float Amount
            </td>
            <td>
                <asp:TextBox ID="txtFloatSuspenseAmt" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Suboffice Reserve Amount
            </td>
            <td>
                <asp:TextBox ID="txtSubOffSuspenseAmt" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Suboffice Float Amount
            </td>
            <td>
                <asp:TextBox ID="txtSubOffFloatAmt" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Count of Outstanding Bill
            </td>
            <td>
                <asp:TextBox ID="txtCountofOutstandingBill" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;" colspan="2">
                <div id="divFrom" style="display: none;">
                </div>
            </td>
            <td style="text-align: left;" colspan="2">
                <div id="divTo" style="display: none;">
                </div>
            </td>
        </tr>
        <tr id="trGrid" runat="server" visible="true">
            <td colspan="4" align="left">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 920px;">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="ImgBtnExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                                CausesValidation="false" Width="45px" Height="45px" Visible="false" ToolTip="Click here to Export excel"
                                OnClick="ImgBtnExportToExcel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="div" style="overflow-y: scroll; width: 920px; height: 360px;">
                                <asp:UpdatePanel ID="UP" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvBillPayment" runat="server" Visible="true" AutoGenerateColumns="false"
                                            CausesValidation="false" AllowPaging="true" PageSize="2" EmptyDataText="No Records Found"
                                            OnPageIndexChanging="gvBillPayment_PageIndexChanging">
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                PageButtonCount="3" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkPay" runat="server" Enabled="true" OnCheckedChanged="chkPay_CheckedChanged"
                                                            AutoPostBack="true"></asp:CheckBox>
                                                        <asp:HiddenField ID="hndBillUID" runat="server" Value='<%#Eval("BillUID") %>' />
                                                        <asp:Label ID="LblOutstandingAmt" Font-Bold="false" runat="server" Text='<%# Eval("OutstandingAmt") %>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Float">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlFloat" runat="server" Width="80px">
                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="BillNo" HeaderText="Bill No" />
                                                <asp:BoundField DataField="TotEmploy" HeaderText="Member Count" />
                                                <asp:BoundField DataField="NetPremium" HeaderText="Gross Premium" />
                                                <asp:BoundField DataField="ServiceTaxAmt" HeaderText="Service Tax" />
                                                <asp:BoundField DataField="EdcessAmt" HeaderText="Edcess" />
                                                <asp:BoundField DataField="Bill_Amount" HeaderText="Bill Amount" />
                                                <asp:BoundField DataField="PaidAmt" HeaderText="Paid Amount" />
                                                <asp:BoundField DataField="OutstandingAmt" HeaderText="Outstanding Amount" />
                                                <asp:BoundField DataField="BillIssuedDate" HeaderText="Issued Date" />
                                                <asp:BoundField DataField="BillPaidDT" HeaderText="Paid Date" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="ImgBtnExportToExcel" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr visible="false" id="trPayBtn" runat="server">
            <td>
                <asp:ImageButton ID="imgPay" runat="server" ToolTip="click here to generate Bill Payment"
                    Visible="true" AlternateText="Bill Payment" ImageUrl="~/App_Themes/Theme/Images/btn_Pay.png"
                    OnClick="imgPay_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <p>
                    <b><span style="font-size: 26px; color: Red;">*</span>Note :</b>- Service tax includes
                    "Service Tax" at the applicable rate from time to time and "Swach Bharat Cess" with
                    effect from 15-Nov-2015.</p>
            </td>
        </tr>
    </table>
</asp:Content>
