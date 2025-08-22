<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="PremiumCalculation.aspx.cs" Inherits="PACE.CreditLifeInformation.PremiumCalculation1"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>

    <style type="text/css">
        .label
        {
            background-position: 14% left;
        }
        #lblERRFor
        {
            padding-left: 10px;
        }
        .style1
        {
            width: 100px;
        }
        .style2
        {
            width: 3%;
        }
        .NewsTab .ajax__tab_header
        {
            color: Gray;
            font-weight: bold;
            background-color: White;
            margin-left: 10px;
        }
        .NewsTab .ajax__tab_outer
        {
            background-color: White;
        }
        .NewsTab .ajax__tab_inner
        {
            color: #ffffff;
            padding: 6px;
            margin-right: 1px;
            margin-left: 1px;
            margin-top: 1px;
            margin-bottom: 1px;
            background-color: #22bcb9;
            border-top-right-radius: 5px;
            border-top-left-radius: 5px;
        }
        .NewsTab .ajax__tab_hover .ajax__tab_outer
        {
            background-color: Gray;
        }
        .NewsTab .ajax__tab_hover .ajax__tab_inner
        {
            background: url(           "../Images/tab_left_active.png" ) no-repeat left;
        }
        .NewsTab .ajax__tab_active .ajax__tab_outer
        {
            background: url(           "../Images/tab_right_active.png" ) no-repeat right;
        }
        .NewsTab .ajax__tab_active .ajax__tab_inner
        {
            background-color: Gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:UpdatePanel ID="UPInsured" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="font-size: 12px !important;"
                width="100%">
                <tr>
                    <th class="strip-title" colspan="4" valign="top">
                        Premium Calculation
                    </th>
                </tr>
                <tr>
                    <td colspan="4" width="100%">
                        <div id="div1" style="width: 99%; border: 0px black solid;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="text-align: left; width: 25%">
                                        <p style="height: 30px">
                                            Name 1
                                        </p>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:TextBox ID="txtname" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 25%">
                                        <p style="height: 30px">
                                            Name 2
                                        </p>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:TextBox ID="txtname2" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px;" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Gender 1
                                        </p>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="styled-select1">
                                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Gender 2
                                        </p>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlGender2" runat="server" CssClass="styled-select1">
                                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px;" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            DOB 1(MM/DD/YYYY)
                                        </p>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDob" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                        <asp:ImageButton ID="imgDOB" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                            ImageAlign="Middle" Height="20px" Width="20px" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDob"
                                            PopupButtonID="imgDOB">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            DOB 2(MM/DD/YYYY)
                                        </p>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDob2" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                        <asp:ImageButton ID="imgDOB2" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                            ImageAlign="Middle" Height="20px" Width="20px" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDob2"
                                            PopupButtonID="imgDOB2">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 35px;" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Sum Assured Type
                                        </p>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSumassuredType" runat="server" CssClass="styled-select1">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Premium Mode Type
                                        </p>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPremiumModeType" runat="server" CssClass="styled-select1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px;" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Rider
                                        </p>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRider" runat="server" CssClass="styled-select1">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Rate Of Interest
                                        </p>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlrateIns" runat="server" CssClass="styled-select1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px;" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Policy Tenure
                                        </p>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolicyTenure" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                    </td>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Loan Tenure
                                        </p>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLoanTenure" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px;" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Segment (Code)
                                        </p>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSegment" runat="server" CssClass="styled-select1">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Moratorium
                                        </p>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMoratorium" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px;" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Cover
                                        </p>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCover" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                    <td style="text-align: left;">
                                        <p style="height: 30px">
                                            Sharing%
                                        </p>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSharing" runat="server" CssClass="inputbg1">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                </tr>
                <tr>
                    <td style="height: 15px;" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right; line-height: 30px;">
                        <asp:ImageButton ID="btnSearch" runat="server" ToolTip="Search" OnClick="btnSearch_Click"
                            Text="Search" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png" />
                        &nbsp;
                    </td>
                    <td colspan="2" style="text-align: left; line-height: 30px;">
                        <asp:ImageButton ID="btnuploal" runat="server" ToolTip="Search" Text="Upload" ImageUrl="~/App_Themes/Theme/Images/btn_Upload.png"
                            PostBackUrl="~/Services_cr/Upload_Premium_Calculation.aspx" />
                        &nbsp;
                    </td>
                </tr>
                <tr id="trExcel" runat="server" visible="false">
                    <td colspan="4" style="text-align: right; width: 920px;">
                        <asp:ImageButton ID="imgExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                            OnClick="imgExportToExcel_Click" Width="50px" Height="50px" AlternateText="Export"
                            ToolTip="Export To Excel" />
                    </td>
                </tr>
                <tr id="trGrid" runat="server" visible="true">
                    <td colspan="4" style="text-align: left; width: 100%;">
                        <div id="div" style="overflow-x: auto; width: 99%; overflow-x: scroll; overflow-y: scroll;
                            border: 0px black solid;">
                            <asp:GridView runat="server" ID="gvPreCal" AutoGenerateColumns="False" GridLines="Both"
                                Width="100%" PageSize="5" EmptyDataText="No record found" Visible="true" AllowPaging="True">
                                <RowStyle CssClass="GridViewRowStyle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />
                                <Columns>
                                  <%-- <asp:BoundField DataField="MemberType" HeaderText="Member Type" />--%>
                                    <asp:BoundField DataField="InsuredName" HeaderText="Insured Name" Visible="false" />
                                    <asp:BoundField DataField="InsuredName" HeaderText="Insured Name" InsertVisible="false" />
                                    <asp:BoundField DataField="STaxChargeable" HeaderText="Tax Chargeable" />
                                    <asp:BoundField DataField="Premiumrate" HeaderText="Premium Rate" />
                                    <asp:BoundField DataField="Premium_Amount" HeaderText="Premium Amount without Taxes" />
                                    <asp:BoundField DataField="GST_Amount" HeaderText="GST Amount" />
                                    <asp:BoundField DataField="Total_Premium_Amount" HeaderText="Total Premium Amount Including Taxes" />
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblResult" runat="server" Visible="false" Text="No Record Found" ForeColor="red">
                            </asp:Label>
                        </div>
                    </td>
                </tr>
                </table> </div> </td> </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
