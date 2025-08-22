<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptsandPayments_cr.aspx.cs" 
MasterPageFile="~/Masters/MenuMasterPage_Cr.master"  Inherits="PACE.CreditLifeInformation.ReceiptsandPayments_cr" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .dataTables_length,.dataTables_filter,.dataTables_info
        {
            color: #ffffff !important;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function() {
            displayingGrid();
        });
        function displayingGrid() {
            $('.display').DataTable({
                "order": [[0, "asc"]],
                "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]]

            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <th class="strip-title" valign="top" colspan="4">
                Receipts and Payments
            </th>
        </tr>
        <tr>
            <td style="width: 200px;">
                Mode of receipts & payments
            </td>
            <td style="width: 210px; padding-left: 6px;">
                <asp:DropDownList ID="ddlSelection" runat="server" CssClass="styled-select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlSelection" runat="server" ErrorMessage="Please select Mode of Receipts & Payments"
                    SetFocusOnError="True" Text="*" Display="Dynamic" ControlToValidate="ddlSelection"
                    InitialValue="0"></asp:RequiredFieldValidator>
                <%--OnSelectedIndexChanged="ddlSelection_SelectedIndexChanged"--%>
            </td>
            <td style="width: 200px;">
                <asp:ImageButton ID="btnExportToExcel" runat="server" ImageAlign="Bottom" CssClass="ImageAligament"
                    Visible="false" ToolTip="Export to Excel" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                    Width="50px" Height="50px" OnClick="btnExportToExcel_Click" />
            </td>
            <td style="width: 200px;">
            </td>
        </tr>
        <tr>
            <td >
                Period From
            </td>
            <td >
                <asp:TextBox ID="txtPeriodFrom" runat="server" CssClass="inputbg" Enabled="false">
                </asp:TextBox>
                <asp:Image ID="imgPeriodFrom" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                    ImageAlign="Middle" Height="20px" Width="20px" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPeriodFrom" Format="dd/MM/yyyy" PopupPosition="BottomRight"
                    PopupButtonID="imgPeriodFrom">
                </cc1:CalendarExtender>
            </td>
            <td >
                Period To
            </td>
            <td >
                <asp:TextBox ID="txtPeriodTo" runat="server" Enabled="false" CssClass="inputbg" >
                </asp:TextBox>
                <asp:Image ID="imgPeriodTo" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                    ImageAlign="Middle" Height="20px" Width="20px" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPeriodTo" Format="dd/MM/yyyy"
                    PopupButtonID="imgPeriodTo" PopupPosition="BottomRight">
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
        <tr>
            <td style="width: 100%" colspan="4">
                <asp:UpdatePanel ID="UPInsured" runat="server">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="gvReceiptPaymnet" AutoGenerateColumns="true" CssClass="display"
                            Width="100%" OnPreRender="gvReceiptPaymnet_PreRender">
                            <RowStyle CssClass="GridViewRowStyle" />
                            <%--AllowPaging="true" PageSize="5" GridLines="None" 
                                        onselectedindexchanging="gvReceiptPaymnet_SelectedIndexChanging"--%>
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                PageButtonCount="3" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnExportToExcel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

