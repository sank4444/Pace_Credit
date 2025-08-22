<%@ Page Language="C#" AutoEventWireup="true" Inherits="MemberInformation_MemberInfoDetails"
    CodeBehind="MemberInfoDetails.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Member Information Details</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <style>
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
            background: url( "../Images/tab_left_active.png" ) no-repeat left;
        }
        .NewsTab .ajax__tab_active .ajax__tab_outer
        {
            background: url( "../Images/tab_right_active.png" ) no-repeat right;
        }
        .NewsTab .ajax__tab_active .ajax__tab_inner
        {
            background-color: Gray;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <%--&nbsp;used in label for if there is no data from database label shrinking it self because of round corner ajaxs control--%>
    <table width="100%" cellspacing="0" cellpadding="0" class="full-strip">
        <tr>
            <th class="strip-title" colspan="4" valign="top">
                Member Information Details
            </th>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="tabComtainer" runat="server" Width="100%" ActiveTabIndex="0"
                    CssClass="NewsTab">
                    <%--CssClass="Tab"--%>
                    <cc1:TabPanel ID="tab1" runat="server" HeaderText="Basic Information" BackColor="#646464"
                        Font-Bold="true" Font-Size="18px">
                        <ContentTemplate>
                            <div id="divMemberInformation">
                                <table cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                            <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                                <tr>
                                                    <td style="width: 188px;">
                                                        Client Name
                                                    </td>
                                                    <td style="width: 20px;">
                                                        :
                                                    </td>
                                                    <td style="width: 360px;">
                                                        <asp:Label ID="LblClientNameText" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rc" runat="server" BorderColor="179, 179, 179" Radius="10"
                                                            TargetControlID="LblClientNameText" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Policy Number
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblPolicyNoText" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPolicyNoText" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="LblPolicyNoText" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Policy Year
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblYear" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="LblYear" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Sub Office Code
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblSubOfficeCodeText" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="LblSubOfficeCodeText" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Sub Office Name
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblSubOfficeText" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="LblSubOfficeText" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Name
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblInsuredTitle" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                            ID="RoundedCornersExtender21" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                            TargetControlID="lblInsuredTitle" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Gender
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblGender" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblGender" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Birth Date
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblInsuredDOB" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                            ID="RoundedCornersExtender25" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                            TargetControlID="lblInsuredDOB" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Age
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblInsuredAge" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                            ID="RoundedCornersExtender26" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                            TargetControlID="lblInsuredAge" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        COI No
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblCertificateofInsuranceNoText" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender6" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="LblCertificateofInsuranceNoText" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="tdEmployeeNo" runat="server">
                                                        Employee No
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEmployeeNo" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender9" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblEmployeeNo" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Initial Effective Date
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblInitialEffDate" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender15" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblInitialEffDate" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Termination Date
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTerminationDate" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender17" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblTerminationDate" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Member Status
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMemberStatus" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender18" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblMemberStatus" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        MHUID no
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMHUIDno" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender16" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblMHUIDno" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <%--Added by karunakar on 10-06-2016 
                                            as per new CR m-Insurance
                                            start
                                            --%>
                                                <tr>
                                                    <td>
                                                        Expiry Date
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblExpiryDate" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblExpiryDate" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <%--end--%>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <%--COMMENTED BY KARUNAKAR ON 02-04-2016 START
                                                    AS PER NEW CR
                                                --%>
                                                <%-- <tr>
                                                    <td>
                                                        Active At Work
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAAW" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender19" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblAAW" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>--%>
                                                <%--END--%>
                                                <%--  <tr>
                                                    <td style="width: 35%">
                                                        Mobile no
                                                    </td> <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMobileNo" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender10" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblMobileNo" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        Identity no
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblIdentityNo" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender11" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblIdentityNo" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Circle
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCircle" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender37" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblCircle" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Validity
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblValidity" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender38" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lblValidity" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Benefit/Coverage" Width="100%">
                        <ContentTemplate>
                            <table style="padding-left: 0px" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 100%; padding-left: 12px; margin-top: 2px; padding-top: 12px;">
                                        <asp:GridView ID="gvProductBenefit" runat="server" AutoGenerateColumns="true" GridLines="both"
                                            CssClass="display" Width="100%">
                                            <%-- <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                PageButtonCount="3" />--%>
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <Columns>
                                            </Columns>
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Premium Details" Width="100%">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                <tr>
                                    <td colspan="4" style="width: 100%; padding-left: 12px; margin-top: 2px; padding-top: 12px;">
                                        <asp:GridView ID="gvPremiumDetail" runat="server" GridLines="both" OnDataBound="gvPremiumDetail_OnDataBound"
                                            OnRowCommand="gvPremiumDetail_RowCommand" Width="100%">
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                PageButtonCount="3" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="MTRF">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgPDF" runat="server" ImageUrl="~/App_Themes/Theme/Images/PDF.png"
                                                            CommandName="ShowMTRF" Height="35px" Width="35px" Visible="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="History">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                <tr>
                                    <td align="left" colspan="4" style="width: 100%; padding-left: 12px; margin-top: 2px;
                                        padding-top: 12px;">
                                        <table width="70%">
                                            <tr>
                                                <td style="width: 35%">
                                                    Member History
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="lnkMemberHistory" runat="server" OnClick="lnkMemberHistory_Click"
                                                        ImageUrl="~/App_Themes/Theme/Images/btn_View.png" Height="29px" Width="101px"
                                                        ToolTip="click to View Member History" CommandName="MemberHistory" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Premium History
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="lnkPremiumHistory" runat="server" OnClick="lnkBtnReceiptDetails_Click"
                                                        ImageUrl="~/App_Themes/Theme/Images/btn_View.png" Height="29px" Width="101px"
                                                        ToolTip="click to View Premium History" CommandName="MemberHistory" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <%--ADDED BY KARUNAKAR ON 02-04-2016
                    AS PER NEW CR TTSL 
                    START--%>
                    <cc1:TabPanel ID="tbSMS" runat="server" HeaderText="Communication" Visible="false">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                <tr>
                                    <td colspan="4" style="width: 100%; padding-left: 12px; margin-top: 2px; padding-top: 12px;">
                                        <%--<table width="70%">
                                            <tr>
                                                <td style="width: 35%">
                                                    SMS delivery date
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSDlDate" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lblSDlDate" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    SMS text
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSMSmult" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender7" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lblSMSmult" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    SMS delivary status
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSMSdelvStat" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender8" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lblSMSdelvStat" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                        </table>--%>
                                        <asp:GridView ID="gvSMS" runat="server" AutoGenerateColumns="true" AllowPaging="true"
                                            Width="100%" GridLines="both">
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                PageButtonCount="3" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <Columns>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tbNominee" runat="server" HeaderText="Nominee" Visible="false">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                <tr>
                                    <td align="left" colspan="4" style="width: 100%; padding-left: 12px; margin-top: 2px;
                                        padding-top: 12px;">
                                        <table width="70%">
                                            <tr>
                                                <td>
                                                    Nominee name
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNName" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender12" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lblNName" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nominee relation
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNRelation" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender13" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lblNRelation" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nominee age
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNAge" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender14" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lblNAge" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Address
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAddress" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender19" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lblAddress" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <%--END--%>
                </cc1:TabContainer>
            </td>
        </tr>
        <%--  added by sonali on 04/08/2017
        START--%>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainerREJECT" runat="server" Visible="false" Width="100%"
                    ActiveTabIndex="0" CssClass="NewsTab">
                    <%--CssClass="Tab"--%>
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText=" Basic Information" BackColor="#646464"
                        Font-Bold="true" Font-Size="18px">
                        <ContentTemplate>
                            <div id="divInformation">
                                <table cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                            <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                                <tr>
                                                    <td style="width: 188px;">
                                                        Name
                                                    </td>
                                                    <td style="width: 20px;">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Name" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender23" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lbl_Name" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Gender
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Gender" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender24" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lbl_Gender" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Birth Date
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_DOB" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                            ID="RoundedCornersExtender27" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                            TargetControlID="lbl_DOB" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Age
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Age" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                            ID="RoundedCornersExtender28" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                            TargetControlID="lbl_Age" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Mobile No.
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_MbNo" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                            ID="RoundedCornersExtender7" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                            TargetControlID="lbl_MbNo" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Recharge Date
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_RCharDt" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                            ID="RoundedCornersExtender10" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                            TargetControlID="lbl_RCharDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Member Status
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_MemberStatus" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender33" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lbl_MemberStatus" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Remark
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Remark" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                            ID="RoundedCornersExtender8" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                            TargetControlID="lbl_Remark" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Circle
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Circl" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender39" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lbl_Circl" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Validity
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Validty" runat="server" Width="360px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender40" runat="server" BorderColor="179, 179, 179"
                                                            Radius="8" TargetControlID="lbl_Validty" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <%--END--%>
                </cc1:TabContainer>
            </td>
        </tr>
        <%--End--%>
    </table>
    </form>

    <script type="text/javascript">        !window.jQuery && document.write(unescape('%3Cscript src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"%3E%3C/script%3E'))</script>

    <script src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"
        type="text/javascript"></script>

    <script type="text/javascript">
        (function($) {
            $(window).load(function() {
                $("#divMemberInformation").mCustomScrollbar({
                    scrollButtons: {
                        enable: true
                    }
                });
            });
        })(jQuery);
    
    </script>

</body>
</html>
