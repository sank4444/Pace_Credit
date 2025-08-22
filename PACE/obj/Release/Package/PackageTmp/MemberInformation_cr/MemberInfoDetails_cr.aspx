<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberInfoDetails_cr.aspx.cs"
    Inherits="PACE.MemberInformation_cr.MemberInfoDetails_cr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Member Information Details Credit Life</title>
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
            background: url(                "../Images/tab_left_active.png" ) no-repeat left;
        }
        .NewsTab .ajax__tab_active .ajax__tab_outer
        {
            background: url(                "../Images/tab_right_active.png" ) no-repeat right;
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
    <table width="100%" cellspacing="0" cellpadding="0" class="full-strip">
        <tr>
            <th class="strip-title" colspan="4" valign="top">
                Member Information Details Credit Life
            </th>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdnMemberID" runat="server" />
                <cc1:TabContainer ID="tabComtainer" runat="server" Width="100%" ActiveTabIndex="0"
                    CssClass="NewsTab">
                    <cc1:TabPanel ID="tab1" runat="server" HeaderText="Plan Details" BackColor="#646464"
                        Font-Bold="true" Font-Size="18px">
                        <ContentTemplate>
                            <div id="divMemberInformation" style="width: 99%">
                                <table style="width: 99%" cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                            <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                                <tr>
                                                    <td width="25%">
                                                        Tata AIA Life Sourcing Branch
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Label ID="lblSourcingBranch" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcTataLifesorce" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblSourcingBranch" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td width="25%">
                                                        Branch Code
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Label ID="lblSrcBranchCode" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcBranchCode" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblSrcBranchCode" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        CLM Code
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblclmCode" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcCLMcode" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblclmCode" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        CLM Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblclmName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcCLMname" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblclmName" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Policy Holder&#39;s Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Client Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblClientName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcClintname" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblClientName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Policy Number
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPolicyNmbr" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPlicyNo" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblPolicyNmbr">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Sub Office Code
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSubOffCode" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcSubOffCode" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblSubOffCode">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Sub Office Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSuboffname" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcSubOfName" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblSuboffname">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Zone
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblZone" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcZone" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblZone">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        COI No
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCOINo" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcCoINo" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblCOINo">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Sourcing Branch
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSourcBrnch" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcSourceBranch" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblSourcBrnch">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Name of Sales Person
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSalesPer" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcSalesName" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblSalesPer">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Region
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRegion" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcRegion" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblRegion" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px" backcolor="#646464"
                                                        font-bold="true" font-size="18px">
                                                        Plan Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Product Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblProductname" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcProdname" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblProductname" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Sum Assured Type
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSumAssuredType" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblSumAssuredType" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Loan Term(In Years)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblLoanTerm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcLoanType" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblLoanTerm" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Proposed Insurance Term(In Years)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblProInsTrm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="TclProInsTrm" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblProInsTrm" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        CI Term(In Years)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCitrm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcCItrm" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblCitrm" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Loan A/C No
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblloanAc" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcloanAc" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblloanAc" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Loan Effective Date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="txtLoanEffDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcLoanEffDt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="txtLoanEffDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                        <td>
                                                            Loan Disbursement Date
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="txtLonDisDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                            <cc1:RoundedCornersExtender ID="rcLonDisDt" runat="server" BorderColor="179, 179, 179"
                                                                Radius="10" TargetControlID="txtLonDisDt" Enabled="True">
                                                            </cc1:RoundedCornersExtender>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Outstanding Loan Amount
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOutstloanAmt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcOutstandingloanAmt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblOutstloanAmt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Proposed Loan Amount
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblprososedloanAmt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcproposedloanAmt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblprososedloanAmt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Benefit/Coverage
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblBenefit" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblBenefit" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Moratorium Period
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblmoratoPer" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcmoratoPer" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblmoratoPer" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Moratorium Interest
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMoratoriumInterest" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblMoratoriumInterest" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Interest Amount
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblInsAmt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="tcInsAmt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblInsAmt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Premium Mode
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPremiumMode" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPremiumMode" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Premium Type
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPremiumType" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPremiumType" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Rate Of Interest
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRateOfInterest" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender6" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblRateOfInterest" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Payment Details:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPayDetails" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPayDetails" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPayDetails" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Cheque/Journal No.
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCheqJournal" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcCheqJournal" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblCheqJournal" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Amount:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmount" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcAmount" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblAmount" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Intimation date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblIntiDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcIntiDt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblIntiDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Date Signed by Proposed Insured:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDateSig" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcDateSig" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblDateSig" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Place Signed by Proposed Insured
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblplaceSigIns" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcplaceSigIns" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblplaceSigIns" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Date Signed by Policy Holder
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbldateSigPoHol" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcDateSigPol" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lbldateSigPoHol" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Place Signed by Policy Holder
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPlaSigpolHo" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPlaSigpolHo" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPlaSigpolHo" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Premium Frequency
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPremiumFrequency" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender9" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPremiumFrequency" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Segment
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSegment" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender11" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblSegment" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        No Of Unit
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoOfUnit" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcNoOfUnit" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblNoOfUnit" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Application Type
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblApplicationType" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender12" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblApplicationType" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Number Of Applicants
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNumberOfApplicants" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender13" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblNumberOfApplicants" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Coverage Effective Date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcovEffDate" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rccovEffDate" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblcovEffDate" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Coverage Termination Date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCovTerDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcCovTerDt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblCovTerDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Premium Due Date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblpreDueDT" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPreDueDt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblpreDueDT" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Grace Premium Due Date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblGracePreDuDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPreDuDt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblGracePreDuDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        COI issued Date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCoIssDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcCoIissDt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblCoIssDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Member Termination Date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMemTerDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcMemTerDt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblMemTerDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Payment date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblpayDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPayDT" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblpayDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Member Effective Date
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMemEffDt" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rdMemEffDt" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblMemEffDt" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td>
                                                        Premium Amount(As Per App Form):
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPreAmtApp" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPreAmtApp" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPreAmtApp" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="0" width="999px">
                                                <tr>
                                                    <td style="background: #808080; color: #FFF; padding: 10px">
                                                        Premium Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; width: 100%;">
                                                        <div style="overflow-x: auto; overflow-x: scroll; overflow-y: scroll; width: 999px;">
                                                            <asp:Panel ID="PnlContentPlaceHolder" runat="server" Width="100%">
                                                                <asp:GridView ID="GridPremium" runat="server" Width="100%">
                                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
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
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Insured" BackColor="#646464"
                        Font-Bold="true" Font-Size="18px">
                        <ContentTemplate>
                            <div id="devInsured">
                                <table cellspacing="0" class="tableBox" cellpadding="0" border="0">
                                    <tr>
                                        <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                            <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                                <tr style="display: none;">
                                                    <td width="25%">
                                                        Customer Id :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCstID" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcCstID" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblCstID" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td width="25%">
                                                        Member Ref Id :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMemRefID" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclblMemRefID" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblMemRefID" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Primary Loan Applicant Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPriLoanAppName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPriLoanAppName" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPriLoanAppName" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td width="25%"> 
                                                        Relationship with Primary Loan Applicant
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRelaPriLoanApp" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcRelaPriLoanApp" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblRelaPriLoanApp" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Secondary Loan Applicant Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSecLonAppName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcSecLonAppName" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblSecLonAppName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Title
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender15" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        First Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="FrtName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcFrtName" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="FrtName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Middle Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMdlName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcMdlName" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblMdlName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Last Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbllstName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclstName" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbllstName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Land Mark
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbllndmark" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclndmark" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbllndmark">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address1
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAddrs1" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcAddrs1" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAddrs1">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Address2
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAddrs2" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcAddrs2" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAddrs2">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address3
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAddrs3" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcAddrs3" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAddrs3">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Address4
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAddrs4" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcAddrs4" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAddrs4">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Country of Residence
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCountryofResidence" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender16" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblCountryofResidence">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        State
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblState" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender17" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblState">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        City
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcity" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rccity" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblcity">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Pin Code
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPincode" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPincode" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblPincode">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Landline
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblLandline" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcLandline" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblLandline">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Mobile
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMobile" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcMobile" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblMobile">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Email
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblemail" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcemail" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblemail">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Gender
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblGender" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender18" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblGender">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        BirthDate
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDOB" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcDOB" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblDOB">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Age
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAge" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclblAge" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAge">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nationality
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNationality" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender19" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNationality">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Residential Status
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblResiSts" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclblResiSts" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblResiSts">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Annual Income
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAnnIncome" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcAnnIncome" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAnnIncome">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        PAN Number
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPanNumbr" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPanNumbr" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblPanNumbr">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Identity Card Type
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblIdentityCardType" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender20" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblIdentityCardType">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Identity Card No
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblIndentityCrdNo" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcIndentityCrdNo" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblIndentityCrdNo">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Insured Sharing %
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblInsShare" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcInsShare" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblInsShare">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Health
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Height(In cm)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblHeight" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclblHeight" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblHeight">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Weight(In Kg)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblWeight" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclblWeight" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblWeight">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Physician Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPhysicianName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender21" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPhysicianName" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        First Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPhyFirstNm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPhyFirstNm" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lblPhyFirstNm" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Middle Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPhyMidlNm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPhyMidlNm" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblPhyMidlNm">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Last Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPhyLstNm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcPhyLstNm" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblPhyLstNm">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblhlthAddress" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rchlthAddress" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblhlthAddress">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Landline
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblhlthLandline" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclthLandline" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblhlthLandline">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Mobile No.
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblhlthmob" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rchlthmob" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblhlthmob">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Occupation
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Name Of Employer
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNmeEmp" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcNmeEmp" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNmeEmp">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Organization Type
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOrganizationType" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender22" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblOrganizationType">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nature Of Duties
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNatureOfDuties" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender25" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNatureOfDuties">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Occupation Code
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOccPtioncd" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcOccPtioncd" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblOccPtioncd">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Occupation
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOccupation" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcOccupation" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblOccupation">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Occupation Class
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOccupationclass" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcOccupationclass" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblOccupationclass">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Nominee Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nominee Title
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNomineeName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender26" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNomineeName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        First Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFrstNm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rclblFrstNm" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblFrstNm">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Middle Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNmneMdlName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcNmneMdlName" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNmneMdlName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Last Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNmneLstNm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcNmneLstNm" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNmneLstNm">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nominee1 Relation
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNominee1Relation" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender29" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNominee1Relation">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Nominee1 Age
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNomiAg1" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcNomiAg1" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNomiAg1">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nominee1 DOB
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNomiDOB1" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RcNomiDOB1" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNomiDOB1">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Nominee1 Percentage
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNomiPerctg1" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcNomiPerctg1" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNomiPerctg1">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nominee Gender
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNomineeGen" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="rcNomineeGen" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNomineeGen">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Apointee Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Apointee Title
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblApointeeTitle" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender14" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblApointeeTitle">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        First Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblApointeeFName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender34" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblApointeeFName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Middle Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblApointeeMName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender35" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblApointeeMName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Last Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblApointeeLName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender57" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblApointeeLName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Appointee Relation
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAppointeeRelation" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender58" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAppointeeRelation">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Apointee Age
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblApointeeAge" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender59" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblApointeeAge">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <%--<td>
                                                        Nominee1 DOB
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender60" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblNomiDOB1">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>--%>
                                                    <td>
                                                        Appointee IdentityCardType
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAppointeeIdentityCardType" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender61" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAppointeeIdentityCardType">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                <%--</tr>--%>
                                                    <td>
                                                        Appointee IdentiyCardNumber
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAppointeeIdentiyCardNumber" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender62" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lblAppointeeIdentiyCardNumber">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <%----LS str--%>
                                                <tr style="display: none;">
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Violation Details
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4" style="text-align: left; width: 100%;">
                                                        <div style="overflow-x: auto; overflow-x: scroll; overflow-y: scroll; width: 999px;">
                                                            <asp:GridView ID="gvViolation" runat="server" Width="100%" AutoGenerateColumns="false">
                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                <Columns>
                                                                    <%--<asp:BoundField DataField="SrNo" HeaderText="Sr.No" />--%>
                                                                    <asp:BoundField DataField="DESCription" HeaderText="DESCription" />
                                                                    <asp:BoundField DataField="RaisedDate" HeaderText="RaisedDate" />
                                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                                    <asp:BoundField DataField="SolveType" HeaderText="SolveType" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%----LS end--%>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Questionaire
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4" style="width: 100%">
                                                        <table border="1" cellpadding="2" cellspacing="0" style="" width="100%">
                                                            <tr>
                                                                <td style="width: 78%;">
                                                                    Has question number 1 been answered as &#39;Yes&#39;?
                                                                </td>
                                                                <td align="left" style="width: 22%;">
                                                                    <asp:DropDownList ID="ddlHasQ" runat="server" CssClass="styled-select" Enabled="False">
                                                                        <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 75%;">
                                                                    Have any of the questions from 2 to 11 in the application form been answered as
                                                                    &#39;Yes&#39;?
                                                                </td>
                                                                <td align="left" style="width: 25%;">
                                                                    <asp:DropDownList ID="ddlHaveAnyQ" runat="server" CssClass="styled-select" Enabled="False">
                                                                        <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 75%;">
                                                                    I hereby declare and agree that at the time of claim under the policy, the Company
                                                                    shall make claim payments in favour of the Policyholder to the extent of outstanding
                                                                    loan balance. I further declare that the said authorization made by me is in consideration
                                                                    of loan/existing outstanding loan granted to me by the Policyholder.
                                                                </td>
                                                                <td align="left" style="width: 25%;">
                                                                    <asp:DropDownList ID="ddlhereby" runat="server" CssClass="styled-select" Enabled="False">
                                                                        <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table style="padding-left: 0px" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 100%; padding-left: 12px; margin-top: 2px; padding-top: 12px;">
                                            <asp:GridView ID="gvProductBenefit" runat="server" AutoGenerateColumns="False" Width="100%">
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Co-Applicant" BackColor="#646464"
                        Font-Bold="true" Font-Size="18px">
                        <ContentTemplate>
                            <div id="Div1">
                                <table cellspacing="0" class="tableBox" cellpadding="0" border="0">
                                    <tr>
                                        <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                            <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                                <tr>
                                                    <td width="25%">
                                                        Customer Id :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_CustomerId" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender30" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lbl_co_CustomerId" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td width="25%">
                                                        Member Ref Id :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_MemberRefId" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender31" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lbl_co_MemberRefId" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Primary Loan Applicant Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_ApplicantName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender32" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lbl_co_ApplicantName" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Title
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Title" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender36" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Title">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        First Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_FName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender37" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_FName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Middle Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_MName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender38" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_MName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Last Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_LName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender41" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_LName">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Land Mark
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_LandMark" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender42" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_LandMark">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address1
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Address1" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender43" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Address1">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Address2
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Address2" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender44" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Address2">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address3
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Address3" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender45" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Address3">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Address4
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Address4" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender46" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Address4">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Country of Residence
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_CountryofResidence" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender47" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_CountryofResidence">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        State
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_State" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender48" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_State">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        City
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_city" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender49" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_city">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Pin Code
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Pincode" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender50" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Pincode">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Landline
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Landline" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender51" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Landline">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Mobile
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Mobile" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender52" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Mobile">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Email
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_email" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender53" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_email">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Gender
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Gender" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender54" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Gender">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        BirthDate
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_DOB" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender55" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_DOB">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Age
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Age" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender56" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Age">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nationality
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Nationality" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_RoundedCornersExtender19" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Nationality">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Residential Status
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_ResiSts" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rclblResiSts" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_ResiSts">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Annual Income
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_AnnIncome" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcAnnIncome" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_AnnIncome">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        PAN Number
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_PanNumbr" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcPanNumbr" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_PanNumbr">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Identity Card Type
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_IdentityCardType" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_RoundedCornersExtender20" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_IdentityCardType">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Identity Card No
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_IndentityCrdNo" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcIndentityCrdNo" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_IndentityCrdNo">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Insured Sharing %
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_InsShare" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcInsShare" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_InsShare">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Relationship with Primary Applicant
                                                    </td>
                                                    <td>
                                                    <asp:Label ID="lbl_Co_RelationshipwithPrimaryApplicant" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender60" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_Co_RelationshipwithPrimaryApplicant">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Health
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Height(In cm)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Height" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rclblHeight" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Height">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Weight(In Kg)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Weight" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rclblWeight" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Weight">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Physician Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_PhysicianName" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_RoundedCornersExtender21" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lbl_co_PhysicianName" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        First Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_PhyFirstNm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcPhyFirstNm" runat="server" BorderColor="179, 179, 179"
                                                            Radius="10" TargetControlID="lbl_co_PhyFirstNm" Enabled="True">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Middle Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_PhyMidlNm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcPhyMidlNm" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_PhyMidlNm">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Last Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_PhyLstNm" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcPhyLstNm" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_PhyLstNm">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_hlthAddress" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rchlthAddress" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_hlthAddress">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Landline
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_hlthLandline" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rclthLandline" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_hlthLandline">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Mobile No.
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_hlthmob" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rchlthmob" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_hlthmob">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Occupation
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Name Of Employer
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_NmeEmp" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcNmeEmp" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_NmeEmp">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Organization Type
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_OrganizationType" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_RoundedCornersExtender22" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_OrganizationType">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nature Of Duties
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_NatureOfDuties" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_RoundedCornersExtender25" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_NatureOfDuties">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Occupation Code
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_OccPtioncd" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcOccPtioncd" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_OccPtioncd">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Occupation
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Occupation" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcOccupation" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Occupation">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                    <td>
                                                        Occupation Class
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_co_Occupationclass" runat="server" Width="180px">&nbsp;</asp:Label>
                                                        <cc1:RoundedCornersExtender ID="co_rcOccupationclass" runat="server" BorderColor="179, 179, 179"
                                                            Enabled="True" Radius="10" TargetControlID="lbl_co_Occupationclass">
                                                        </cc1:RoundedCornersExtender>
                                                    </td>
                                                </tr>
                                                <%--ls stsr--%>
                                                <tr style="display: none;">
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        violation Occupation
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                     <td colspan="4" style="text-align: left; width: 100%;">
                                                        <div style="overflow-x: auto; overflow-x: scroll; overflow-y: scroll; width: 999px;">
                                                        <asp:GridView ID="gvViolation_Occu" runat="server" Width="100%">
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <Columns>
                                                                <%--<asp:BoundField DataField="SrNo" HeaderText="Sr.No" />--%>
                                                                <asp:BoundField DataField="DESCription" HeaderText="DESCription" />
                                                                <asp:BoundField DataField="RaisedDate" HeaderText="RaisedDate" />
                                                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                                                <asp:BoundField DataField="SolveType" HeaderText="SolveType" />
                                                            </Columns>
                                                        </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%--end ls stsr--%>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">
                                                        Questionaire
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="4" style="width: 100%">
                                                        <table border="1" cellpadding="2" cellspacing="0" style="" width="100%">
                                                            <tr>
                                                                <td style="width: 78%;">
                                                                    Has question number 1 been answered as &#39;Yes&#39;?
                                                                </td>
                                                                <td align="left" style="width: 22%;">
                                                                    <asp:DropDownList ID="ddl_co_HasQ" runat="server" CssClass="styled-select" Enabled="False">
                                                                        <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 75%;">
                                                                    Have any of the questions from 2 to 11 in the application form been answered as
                                                                    &#39;Yes&#39;?
                                                                </td>
                                                                <td align="left" style="width: 25%;">
                                                                    <asp:DropDownList ID="ddl_co_HaveAnyQ" runat="server" CssClass="styled-select" Enabled="False">
                                                                        <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 75%;">
                                                                    I hereby declare and agree that at the time of claim under the policy, the Company
                                                                    shall make claim payments in favour of the Policyholder to the extent of outstanding
                                                                    loan balance. I further declare that the said authorization made by me is in consideration
                                                                    of loan/existing outstanding loan granted to me by the Policyholder.
                                                                </td>
                                                                <td align="left" style="width: 25%;">
                                                                    <asp:DropDownList ID="ddl_co_hereby" runat="server" CssClass="styled-select" Enabled="False">
                                                                        <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" BackColor="White" Width="1px" Font-Bold="false"
                        Font-Size="18px" ForeColor="White" Visible="false">
                        <ContentTemplate>
                            <div id="divUnderwriting" visible="false" style="width: 1px; background-color: White;
                                visibility: hidden">
                                <table cellspacing="0" cellpadding="0" border="0" visible="false">
                                    <tr>
                                        <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                            <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                                <tr>
                                                    <td colspan="4" style="background: #808080; width: 970px; color: #FFF; padding: 10px">
                                                        Additional Links and History
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnkBtnReceiptDetails" runat="server" ForeColor="Blue" Text="Receipt Details"
                                                            CausesValidation="False" OnClick="lnkBtnReceiptDetails_Click"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="lnkBtnUWCommentsHistory" runat="server" Text="U/w Comments History"
                                                            ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="lnkCoi" runat="server" Text="COI" ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="background: #808080; width: 970px; color: #FFF; padding: 10px">
                                            Alpha Details
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="width: 100%; padding-left: 12px; margin-top: 2px; padding-top: 12px;">
                                            <asp:GridView ID="gvPremiumDetail" runat="server" GridLines="both" OnDataBound="gvPremiumDetail_OnDataBound"
                                                AutoGenerateColumns="false" OnRowCommand="gvPremiumDetail_RowCommand" Width="100%">
                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                    PageButtonCount="3" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <Columns>
                                                    <asp:BoundField DataField="ClientName" HeaderText="Clint" />
                                                    <asp:BoundField DataField="PolicyNumber" HeaderText="Policy" />
                                                    <asp:BoundField DataField="COI" HeaderText="COI" />
                                                    <asp:BoundField DataField="ApplicantType" HeaderText="Applicant type" />
                                                    <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" />
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="BirthDate" HeaderText="DOB" />
                                                    <asp:BoundField DataField="Cover" HeaderText="Benefits Covered" />
                                                    <asp:BoundField DataField="UWDecision" HeaderText="Decision" />
                                                    <asp:BoundField DataField="subStatusName" HeaderText="Status" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="background: #808080; width: 100%; color: #FFF; padding: 10px">
                                            Member requirements and decision
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="width: 100%; padding-left: 12px; margin-top: 2px; padding-top: 12px;">
                                            <asp:GridView ID="gvMemReq" runat="server" GridLines="both" AutoGenerateColumns="false"
                                                Width="100%">
                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                    PageButtonCount="3" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <Columns>
                                                    <asp:BoundField DataField="Applicant" HeaderText="Application Type" />
                                                    <asp:BoundField DataField="PolicyMemberUID" HeaderText="Mem.Ref.ID" />
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="ApplicationSignDate" HeaderText="Date of commencement " />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:BoundField DataField="UWDecision" HeaderText="UW Decision" />
                                                    <asp:BoundField DataField="CounterOffer" HeaderText="Counter offer" />
                                                    <asp:BoundField DataField="PolicyMemberUWDecDetUID" HeaderText="Memmer label u/w" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                </td> </tr> </table>
                                <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="" Visible="false">
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
                                            <tr>
                                                <td>
                                                    COI Generation
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="lnkCOIGeneration" runat="server" OnClick="lnkCoi_Click" ImageUrl="~/App_Themes/Theme/Images/btn_View.png"
                                                        Height="29px" Width="101px" ToolTip="click to COI Generation" CommandName="COIGeneration" />
                                                </td>
                                            </tr>
                                            <%------------%>
                                            <tr>
                                                <td>
                                                    Surrender Letter
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="lnkSurrenderletter" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_View.png"
                                                        Height="29px" Width="101px" OnClick="lnkSurrenderletter_Click" ToolTip="click to COI Generation" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Decline Letter
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="lnkDeclineLetter" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_View.png"
                                                        Height="29px" Width="101px" OnClick="lnkDeclineLetter_Click" ToolTip="click to COI Generation" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainerREJECT" runat="server" Width="100%" ActiveTabIndex="0"
                    Visible="false">
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Basic Information" BackColor="#646464"
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
                </cc1:TabContainer>
            </td>
        </tr>
    </table>
    </form>

    <script type="text/javascript">       
     !window.jQuery && document.write(unescape('%3Cscript src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"%3E%3C/script%3E'))</script>

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
