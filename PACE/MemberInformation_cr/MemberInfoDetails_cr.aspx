<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberInfoDetails_cr.aspx.cs"
    Inherits="PACE.MemberInformation_cr.MemberInfoDetails_cr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Member Information Details Credit Life</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="../App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>

    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Theme/StyleSheets/inner_page_style.css" rel="stylesheet" />
    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <style>
        .active {
            line-height: 24px;
        }

        .page-title {
            font-weight: bolder;
            font-size: 23px;
        }

        /* Tab styling */
        .nav-tabs .nav-link {
            border: 1px solid #dee2e6;
            border-bottom: none;
            border-radius: 0.25rem 0.25rem 0 0;
            margin-right: 2px;
            color: var(--primary-color);
            background-color: #e9ecef;
        }

            .nav-tabs .nav-link.active {
                color: white;
                background-color: #20c997; /* Teal color from screenshot */
                border-color: #20c997;
            }

        .tab-content {
            border: 1px solid #dee2e6;
            padding: 20px;
            /*  border-top: none;*/
            border-radius: 0 0 0.25rem 0.25rem;
        }
        /* Read-only field styling */
        .form-control-plaintext {
            padding-left: 0.75rem; /* Align with normal inputs */
            padding-right: 0.75rem;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            background-color: #e9ecef; /* Light grey background for read-only */
        }

        .form-label {
            font-weight: bold;
            color: #495057;
        }

        .NewsTab .ajax__tab_header {
            color: Gray;
            font-weight: bold;
            background-color: White;
            /*margin-left: 10px;*/
        }

        .NewsTab .ajax__tab_outer {
            background-color: White;
        }

        .NewsTab .ajax__tab_inner {
            border: 1px solid #dee2e6;
            border-bottom: none;
            border-radius: 0.25rem 0.25rem 0 0;
            margin-right: 2px;
            color: var(--primary-color);
            background-color: #e9ecef;
        }

        .NewsTab .ajax__tab_hover .ajax__tab_outer {
            background-color: #e0f2fe;
            border-color: #e0f2fe;
        }

        .NewsTab .ajax__tab_hover .ajax__tab_inner {
            background: url( "../Images/tab_left_active.png" ) no-repeat left;
        }

        .NewsTab .ajax__tab_active .ajax__tab_outer {
            background: url( "../Images/tab_right_active.png" ) no-repeat right;
        }

        .NewsTab .ajax__tab_active .ajax__tab_inner {
            color: white;
            background-color: #20c997;
            border-color: #20c997;
        }

        .ajax__tab_tab {
            padding: 4px 14px;
        }

        .change-password-header-bar {
            background-color: #cccccc;
            padding: 8px 15px;
            font-weight: bold;
            margin-top: 20px;
            margin-bottom: 20px;
            border-radius: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sm" runat="server">
        </asp:ScriptManager>

        <div class="content-box">
            <h4 class="page-title">Member Information Details Credit Life  (COI:<asp:Label ID="lblCOINo1" runat="server"></asp:Label>)</h4>
            <!-- Added COI Number -->
            <div class="mb-3">
                <%--<a href="member_information.html" class="btn btn-sm btn-outline-secondary"><i class="fas fa-arrow-left"></i>Back to Member Enquiry</a>--%>
                <asp:Button ID="btnRedirectToMemberEnquiry" runat="server" CssClass="btn btn-sm btn-outline-secondary" Text="Back to Member Enquiry" OnClick="btnRedirectToMemberEnquiry_Click"  />
            </div>
            <asp:HiddenField ID="hdnMemberID" runat="server" />
            <cc1:TabContainer ID="tabComtainer" runat="server" Width="100%" ActiveTabIndex="0"
                CssClass="NewsTab nav-tabs">
                <cc1:TabPanel ID="tab1" runat="server" HeaderText="Plan Details" BackColor="#646464"
                    Font-Bold="true" Font-Size="18px">
                    <ContentTemplate>

                        <!-- Main Content Area -->
                        <!-- Tab Content -->
                        <div class="tab-content" id="divMemberInformation" style="width: 100%">

                            <div class="row g-3 mt-2">
                                <div class="col-md-6">
                                    <label for="lblSourcingBranch" class="form-label">Tata AIA Life Sourcing Branch</label>
                                    <asp:Label ID="lblSourcingBranch" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lblSrcBranchCode" class="form-label">Branch Code</label>
                                    <asp:Label ID="lblSrcBranchCode" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblclmCode" class="form-label">CLM Code</label>
                                    <asp:Label ID="lblclmCode" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblclmCode" class="form-label">CLM Name</label>
                                    <asp:Label ID="lblclmName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <div class="change-password-header-bar">Policy Holder's Details</div>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblClientName" class="form-label">Client Name</label>
                                    <asp:Label ID="lblClientName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPolicyNmbr" class="form-label">Policy Number</label>
                                    <asp:Label ID="lblPolicyNmbr" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSubOffCode" class="form-label">Sub Office Code</label>
                                    <asp:Label ID="lblSubOffCode" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSuboffname" class="form-label">Sub Office Name</label>
                                    <asp:Label ID="lblSuboffname" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSuboffname" class="form-label">Zone</label>
                                    <asp:Label ID="lblZone" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSuboffname" class="form-label">COI No</label>
                                    <asp:Label ID="lblCOINo" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSourcBrnch" class="form-label">Sourcing Branch</label>
                                    <asp:Label ID="lblSourcBrnch" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSalesPer" class="form-label">Name of Sales Person</label>
                                    <asp:Label ID="lblSalesPer" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblRegion" class="form-label">Region</label>
                                    <asp:Label ID="lblRegion" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <div class="change-password-header-bar">Plan Details</div>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblProductname" class="form-label">Product Name</label>
                                    <asp:Label ID="lblProductname" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSumAssuredType" class="form-label">Sum Assured Type</label>
                                    <asp:Label ID="lblSumAssuredType" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblLoanTerm" class="form-label">Loan Term(In Years)</label>
                                    <asp:Label ID="lblLoanTerm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblProInsTrm" class="form-label">Proposed Insurance Term(In Years)</label>
                                    <asp:Label ID="lblProInsTrm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblCitrm" class="form-label">CI Term(In Years)</label>
                                    <asp:Label ID="lblCitrm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblloanAc" class="form-label">Loan A/C No</label>
                                    <asp:Label ID="lblloanAc" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtLoanEffDt" class="form-label">Loan Effective Date</label>
                                    <asp:Label ID="txtLoanEffDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtLonDisDt" class="form-label">Loan Disbursement Date</label>
                                    <asp:Label ID="txtLonDisDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblOutstloanAmt" class="form-label">Outstanding Loan Amount</label>
                                    <asp:Label ID="lblOutstloanAmt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblprososedloanAmt" class="form-label">Proposed Loan Amount</label>
                                    <asp:Label ID="lblprososedloanAmt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblBenefit" class="form-label">Benefit/Coverage</label>
                                    <asp:Label ID="lblBenefit" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblmoratoPer" class="form-label">Moratorium Period</label>
                                    <asp:Label ID="lblmoratoPer" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblMoratoriumInterest" class="form-label">Moratorium Interest</label>
                                    <asp:Label ID="lblMoratoriumInterest" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblInsAmt" class="form-label">Interest Amount</label>
                                    <asp:Label ID="lblInsAmt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPremiumMode" class="form-label">Premium Mode</label>
                                    <asp:Label ID="lblPremiumMode" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPremiumType" class="form-label">Premium Type</label>
                                    <asp:Label ID="lblPremiumType" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblRateOfInterest" class="form-label">Rate Of Interest</label>
                                    <asp:Label ID="lblRateOfInterest" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPayDetails" class="form-label">Payment Details</label>
                                    <asp:Label ID="lblPayDetails" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblCheqJournal" class="form-label">Cheque/Journal No.</label>
                                    <asp:Label ID="lblCheqJournal" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblAmount" class="form-label">Amount</label>
                                    <asp:Label ID="lblAmount" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblIntiDt" class="form-label">Intimation date</label>
                                    <asp:Label ID="lblIntiDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblDateSig" class="form-label">Date Signed by Proposed Insured</label>
                                    <asp:Label ID="lblDateSig" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblplaceSigIns" class="form-label">Place Signed by Proposed Insured</label>
                                    <asp:Label ID="lblplaceSigIns" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbldateSigPoHol" class="form-label">Date Signed by Policy Holder</label>
                                    <asp:Label ID="lbldateSigPoHol" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPlaSigpolHo" class="form-label">Place Signed by Policy Holder</label>
                                    <asp:Label ID="lblPlaSigpolHo" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPremiumFrequency" class="form-label">Premium Frequency</label>
                                    <asp:Label ID="lblPremiumFrequency" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSegment" class="form-label">Segment</label>
                                    <asp:Label ID="lblSegment" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblNoOfUnit" class="form-label">No Of Unit</label>
                                    <asp:Label ID="lblNoOfUnit" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblApplicationType" class="form-label">Application Type</label>
                                    <asp:Label ID="lblApplicationType" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblNumberOfApplicants" class="form-label">Number Of Applicants</label>
                                    <asp:Label ID="lblNumberOfApplicants" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblcovEffDate" class="form-label">Coverage Effective Date</label>
                                    <asp:Label ID="lblcovEffDate" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblCovTerDt" class="form-label">Coverage Termination Date</label>
                                    <asp:Label ID="lblCovTerDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblpreDueDT" class="form-label">Premium Due Date</label>
                                    <asp:Label ID="lblpreDueDT" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblGracePreDuDt" class="form-label">Grace Premium Due Date</label>
                                    <asp:Label ID="lblGracePreDuDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblCoIssDt" class="form-label">COI issued Date</label>
                                    <asp:Label ID="lblCoIssDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblMemTerDt" class="form-label">Member Termination Date</label>
                                    <asp:Label ID="lblMemTerDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblpayDt" class="form-label">Payment date</label>
                                    <asp:Label ID="lblpayDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblMemEffDt" class="form-label">Member Effective Date</label>
                                    <asp:Label ID="lblMemEffDt" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6" style="display: none;">
                                    <label for="lblPreAmtApp" class="form-label">Premium Amount(As Per App Form):</label>
                                    <asp:Label ID="lblPreAmtApp" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <div class="change-password-header-bar">Premium Details</div>
                                </div>

                                <div class="table-responsive">
                                    <asp:Panel ID="PnlContentPlaceHolder" runat="server" Width="100%">
                                        <asp:GridView ID="GridPremium" runat="server" Width="100%" CssClass="table table-bordered table-striped data-table member-enquiry-table">
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        </asp:GridView>
                                    </asp:Panel>

                                </div>

                            </div>
                        </div>
                        <!-- End Content Box -->

                        <!-- History Modal -->
                        <div class="modal fade" id="historyModal" tabindex="-1" aria-labelledby="historyModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-xl modal-dialog-scrollable">
                                <!-- Changed to modal-xl for wider view -->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h2 class="modal-title" id="historyModalLabel">History Details</h2>
                                        <!-- Use h2 and standard styling -->
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <p>Placeholder content for history details...</p>
                                        <!-- History details will be loaded here based on the button clicked -->
                                    </div>
                                    <div class="modal-footer modal-buttons">
                                        <!-- Add modal-buttons class -->
                                        <button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
                                        <!-- Use btn-light -->
                                    </div>
                                </div>
                            </div>
                        </div>




                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Insured" BackColor="#646464"
                    Font-Bold="true" Font-Size="18px">
                    <ContentTemplate>
                        <div class="tab-content" id="devInsured">
                            <div class="row g-3 mt-2">
                                <div class="col-md-6" style="display:none">
                                    <label for="lblCstID" class="form-label">Customer Id</label>
                                    <asp:Label ID="lblCstID" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6" style="display:none">
                                    <label for="lblMemRefID" class="form-label">Member Ref Id</label>
                                    <asp:Label ID="lblMemRefID" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPriLoanAppName" class="form-label">Primary Loan Applicant Name</label>
                                    <asp:Label ID="lblPriLoanAppName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblRelaPriLoanApp" class="form-label">Relationship with Primary Loan Applicant</label>
                                    <asp:Label ID="lblRelaPriLoanApp" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblSecLonAppName" class="form-label">Secondary Loan Applicant Name</label>
                                    <asp:Label ID="lblSecLonAppName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblName" class="form-label">Title</label>
                                    <asp:Label ID="lblName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="FrtName" class="form-label">First Name</label>
                                    <asp:Label ID="FrtName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblMdlName" class="form-label">Middle Name</label>
                                    <asp:Label ID="lblMdlName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbllstName" class="form-label">Last Name</label>
                                    <asp:Label ID="lbllstName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbllndmark" class="form-label">Land Mark</label>
                                    <asp:Label ID="lbllndmark" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblAddrs1" class="form-label">Address1</label>
                                    <asp:Label ID="lblAddrs1" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblAddrs2" class="form-label">Address2</label>
                                    <asp:Label ID="lblAddrs2" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblAddrs3" class="form-label">Address3</label>
                                    <asp:Label ID="lblAddrs3" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblAddrs4" class="form-label">Address4</label>
                                    <asp:Label ID="lblAddrs4" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblCountryofResidence" class="form-label">Country of Residence</label>
                                    <asp:Label ID="lblCountryofResidence" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblState" class="form-label">State</label>
                                    <asp:Label ID="lblState" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                             <div class="col-md-6">
                                    <label for="lblcity" class="form-label">City</label>
                                    <asp:Label ID="lblcity" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPincode" class="form-label">Pin Code</label>
                                    <asp:Label ID="lblPincode" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                  <div class="col-md-6">
                                    <label for="lblLandline" class="form-label">Landline</label>
                                    <asp:Label ID="lblLandline" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblMobile" class="form-label">Mobile</label>
                                    <asp:Label ID="lblMobile" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                  <div class="col-md-6">
                                    <label for="lblemail" class="form-label">Email</label>
                                    <asp:Label ID="lblemail" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblGender" class="form-label">Gender</label>
                                    <asp:Label ID="lblGender" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblDOB" class="form-label">BirthDate</label>
                                    <asp:Label ID="lblDOB" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblAge" class="form-label">Age</label>
                                    <asp:Label ID="lblAge" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblNationality" class="form-label">Nationality</label>
                                    <asp:Label ID="lblNationality" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblResiSts" class="form-label">Residential Status</label>
                                    <asp:Label ID="lblResiSts" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblAnnIncome" class="form-label">Annual Income</label>
                                    <asp:Label ID="lblAnnIncome" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPanNumbr" class="form-label">PAN Number</label>
                                    <asp:Label ID="lblPanNumbr" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblIdentityCardType" class="form-label">Identity Card Type</label>
                                    <asp:Label ID="lblIdentityCardType" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblIndentityCrdNo" class="form-label">Identity Card No</label>
                                    <asp:Label ID="lblIndentityCrdNo" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblInsShare" class="form-label">Insured Sharing %</label>
                                    <asp:Label ID="lblInsShare" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-12">
                                    <div class="change-password-header-bar">Health</div>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblHeight" class="form-label">Height(In cm)</label>
                                    <asp:Label ID="lblHeight" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblWeight" class="form-label">Weight(In Kg)</label>
                                    <asp:Label ID="lblWeight" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPhysicianName" class="form-label">Physician Name</label>
                                    <asp:Label ID="lblPhysicianName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPhyFirstNm" class="form-label">First Name</label>
                                    <asp:Label ID="lblPhyFirstNm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                  <div class="col-md-6">
                                    <label for="lblPhyMidlNm" class="form-label">Middle Name</label>
                                    <asp:Label ID="lblPhyMidlNm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblPhyLstNm" class="form-label">Last Name</label>
                                    <asp:Label ID="lblPhyLstNm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblhlthAddress" class="form-label">Address</label>
                                    <asp:Label ID="lblhlthAddress" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblhlthLandline" class="form-label">Landline</label>
                                    <asp:Label ID="lblhlthLandline" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblhlthmob" class="form-label">Mobile No.</label>
                                    <asp:Label ID="lblhlthmob" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-12">
                                    <div class="change-password-header-bar">Occupation</div>
                                </div>
                                  <div class="col-md-6">
                                    <label for="lblNmeEmp" class="form-label">Name Of Employer</label>
                                    <asp:Label ID="lblNmeEmp" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblOrganizationType" class="form-label">Organization Type</label>
                                    <asp:Label ID="lblOrganizationType" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                  <div class="col-md-6">
                                    <label for="lblNatureOfDuties" class="form-label">Nature Of Duties</label>
                                    <asp:Label ID="lblNatureOfDuties" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblOccPtioncd" class="form-label">Occupation Code</label>
                                    <asp:Label ID="lblOccPtioncd" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                   <div class="col-md-6">
                                    <label for="lblOccupation" class="form-label">Occupation</label>
                                    <asp:Label ID="lblOccupation" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblOccupationclass" class="form-label">Occupation Class</label>
                                    <asp:Label ID="lblOccupationclass" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <div class="change-password-header-bar">Nominee Details</div>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblNomineeName" class="form-label">Nominee Title</label>
                                    <asp:Label ID="lblNomineeName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblFrstNm" class="form-label">First Name</label>
                                    <asp:Label ID="lblFrstNm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblNmneMdlName" class="form-label">Middle Name</label>
                                    <asp:Label ID="lblNmneMdlName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblNmneLstNm" class="form-label">Last Name</label>
                                    <asp:Label ID="lblNmneLstNm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblNominee1Relation" class="form-label">Nominee1 Relation</label>
                                    <asp:Label ID="lblNominee1Relation" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblNomiAg1" class="form-label">Nominee1 Age</label>
                                    <asp:Label ID="lblNomiAg1" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                  <div class="col-md-6">
                                    <label for="lblNomiDOB1" class="form-label">Nominee1 DOB</label>
                                    <asp:Label ID="lblNomiDOB1" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblNomiPerctg1" class="form-label">Nominee1 Percentage</label>
                                    <asp:Label ID="lblNomiPerctg1" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblNomineeGen" class="form-label">Nominee Gender</label>
                                    <asp:Label ID="lblNomineeGen" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-12">
                                    <div class="change-password-header-bar">Apointee Details</div>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblApointeeTitle" class="form-label">Apointee Title</label>
                                    <asp:Label ID="lblApointeeTitle" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblApointeeFName" class="form-label">First Name</label>
                                    <asp:Label ID="lblApointeeFName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                  <div class="col-md-6">
                                    <label for="lblApointeeMName" class="form-label">Middle Name</label>
                                    <asp:Label ID="lblApointeeMName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblApointeeLName" class="form-label">Last Name</label>
                                    <asp:Label ID="lblApointeeLName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblAppointeeRelation" class="form-label">Appointee Relation</label>
                                    <asp:Label ID="lblAppointeeRelation" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblApointeeAge" class="form-label">Apointee Age</label>
                                    <asp:Label ID="lblApointeeAge" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblAppointeeIdentityCardType" class="form-label">Appointee IdentityCardType</label>
                                    <asp:Label ID="lblAppointeeIdentityCardType" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lblAppointeeIdentiyCardNumber" class="form-label">Appointee IdentiyCardNumber</label>
                                    <asp:Label ID="lblAppointeeIdentiyCardNumber" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                            </div>
                            <table cellspacing="0" class="tableBox" cellpadding="0" border="0">
                                <tr>
                                    <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                        <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">

                                         
                                            
                                           
                                            <tr style="display: none;">
                                                <td colspan="4">&nbsp;
                                                </td>
                                            </tr>
                                            <%----LS str--%>
                                            <tr style="display: none;">
                                                <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">Violation Details
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4">&nbsp;
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
                                                <td colspan="4">&nbsp;
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">Questionaire
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4">&nbsp;
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4" style="width: 100%">
                                                    <table border="1" cellpadding="2" cellspacing="0" style="" width="100%">
                                                        <tr>
                                                            <td style="width: 78%;">Has question number 1 been answered as &#39;Yes&#39;?
                                                            </td>
                                                            <td align="left" style="width: 22%;">
                                                                <asp:DropDownList ID="ddlHasQ" runat="server" CssClass="styled-select" Enabled="False">
                                                                    <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 75%;">Have any of the questions from 2 to 11 in the application form been answered as
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
                                                            <td style="width: 75%;">I hereby declare and agree that at the time of claim under the policy, the Company
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
                        <div class="tab-content" id="Div1">

                             <div class="row g-3 mt-2">
                                <div class="col-md-6">
                                    <label for="lbl_co_CustomerId" class="form-label">Customer Id</label>
                                    <asp:Label ID="lbl_co_CustomerId" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_MemberRefId" class="form-label">Member Ref Id</label>
                                    <asp:Label ID="lbl_co_MemberRefId" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_ApplicantName" class="form-label">Primary Loan Applicant Name</label>
                                    <asp:Label ID="lbl_co_ApplicantName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Title" class="form-label">Title</label>
                                    <asp:Label ID="lbl_co_Title" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_FName" class="form-label">First Name</label>
                                    <asp:Label ID="lbl_co_FName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_MName" class="form-label">Middle Name</label>
                                    <asp:Label ID="lbl_co_MName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_LName" class="form-label">Last Name</label>
                                    <asp:Label ID="lbl_co_LName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_LandMark" class="form-label">Land Mark</label>
                                    <asp:Label ID="lbl_co_LandMark" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Address1" class="form-label">Address1</label>
                                    <asp:Label ID="lbl_co_Address1" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Address2" class="form-label">Address2</label>
                                    <asp:Label ID="lbl_co_Address2" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_Address3" class="form-label">Address3</label>
                                    <asp:Label ID="lbl_co_Address3" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Address4" class="form-label">Address4</label>
                                    <asp:Label ID="lbl_co_Address4" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_CountryofResidence" class="form-label">Country of Residence</label>
                                    <asp:Label ID="lbl_co_CountryofResidence" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_State" class="form-label">State</label>
                                    <asp:Label ID="lbl_co_State" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_city" class="form-label">City</label>
                                    <asp:Label ID="lbl_co_city" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Pincode" class="form-label">Pin Code</label>
                                    <asp:Label ID="lbl_co_Pincode" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Landline" class="form-label">Landline</label>
                                    <asp:Label ID="lbl_co_Landline" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Mobile" class="form-label">Mobile</label>
                                    <asp:Label ID="lbl_co_Mobile" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_email" class="form-label">Email</label>
                                    <asp:Label ID="lbl_co_email" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Gender" class="form-label">Gender</label>
                                    <asp:Label ID="lbl_co_Gender" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Nationality" class="form-label">Nationality</label>
                                    <asp:Label ID="lbl_co_Nationality" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_ResiSts" class="form-label">Residential Status</label>
                                    <asp:Label ID="lbl_co_ResiSts" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_AnnIncome" class="form-label">Annual Income</label>
                                    <asp:Label ID="lbl_co_AnnIncome" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_PanNumbr" class="form-label">PAN Number</label>
                                    <asp:Label ID="lbl_co_PanNumbr" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_IdentityCardType" class="form-label">Identity Card Type</label>
                                    <asp:Label ID="lbl_co_IdentityCardType" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_IndentityCrdNo" class="form-label">Identity Card No</label>
                                    <asp:Label ID="lbl_co_IndentityCrdNo" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_InsShare" class="form-label">Insured Sharing %</label>
                                    <asp:Label ID="lbl_co_InsShare" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_Co_RelationshipwithPrimaryApplicant" class="form-label">Relationship with Primary Applicant</label>
                                    <asp:Label ID="lbl_Co_RelationshipwithPrimaryApplicant" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <div class="change-password-header-bar">Health</div>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_Height" class="form-label">Height(In cm)</label>
                                    <asp:Label ID="lbl_co_Height" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Weight" class="form-label">Weight(In Kg)</label>
                                    <asp:Label ID="lbl_co_Weight" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_PhysicianName" class="form-label">Physician Name</label>
                                    <asp:Label ID="lbl_co_PhysicianName" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_PhyFirstNm" class="form-label">First Name</label>
                                    <asp:Label ID="lbl_co_PhyFirstNm" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_hlthAddress" class="form-label">Address</label>
                                    <asp:Label ID="lbl_co_hlthAddress" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_hlthLandline" class="form-label">Landline</label>
                                    <asp:Label ID="lbl_co_hlthLandline" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_hlthmob" class="form-label">Mobile No</label>
                                    <asp:Label ID="lbl_co_hlthmob" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                  <div class="col-md-12">
                                    <div class="change-password-header-bar">Occupation</div>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_NmeEmp" class="form-label">Name Of Employer</label>
                                    <asp:Label ID="lbl_co_NmeEmp" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_OrganizationType" class="form-label">Organization Type</label>
                                    <asp:Label ID="lbl_co_OrganizationType" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_NatureOfDuties" class="form-label">Nature Of Duties</label>
                                    <asp:Label ID="lbl_co_NatureOfDuties" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_OccPtioncd" class="form-label">Occupation Code</label>
                                    <asp:Label ID="lbl_co_OccPtioncd" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label for="lbl_co_Occupation" class="form-label">Occupation</label>
                                    <asp:Label ID="lbl_co_Occupation" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>
                                 <div class="col-md-6">
                                    <label for="lbl_co_Occupationclass" class="form-label">Occupation Class</label>
                                    <asp:Label ID="lbl_co_Occupationclass" CssClass="form-control-plaintext" runat="server">&nbsp;</asp:Label>
                                </div>

                            </div>

                            <table cellspacing="0" class="tableBox" cellpadding="0" border="0">
                                <tr>
                                    <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                        <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                            
                                   
                                            <%--ls stsr--%>
                                            <tr style="display: none;">
                                                <td colspan="4">&nbsp;
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">violation Occupation
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4">&nbsp;
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
                                                <td colspan="4">&nbsp;
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4" style="background: #808080; color: #FFF; padding: 10px">Questionaire
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4">&nbsp;
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="4" style="width: 100%">
                                                    <table border="1" cellpadding="2" cellspacing="0" style="" width="100%">
                                                        <tr>
                                                            <td style="width: 78%;">Has question number 1 been answered as &#39;Yes&#39;?
                                                            </td>
                                                            <td align="left" style="width: 22%;">
                                                                <asp:DropDownList ID="ddl_co_HasQ" runat="server" CssClass="styled-select" Enabled="False">
                                                                    <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 75%;">Have any of the questions from 2 to 11 in the application form been answered as
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
                                                            <td style="width: 75%;">I hereby declare and agree that at the time of claim under the policy, the Company
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
                        <div id="divUnderwriting" visible="false" style="width: 1px; background-color: White; visibility: hidden">
                            <table cellspacing="0" cellpadding="0" border="0" visible="false">
                                <tr>
                                    <td style="padding-left: 12px; padding-top: 12px; margin-top: 20px;" valign="top">
                                        <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 0px; line-height: 25px;">
                                            <tr>
                                                <td colspan="4" style="background: #808080; width: 970px; color: #FFF; padding: 10px">Additional Links and History
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">&nbsp;
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
                                    <td colspan="4">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background: #808080; width: 970px; color: #FFF; padding: 10px">Alpha Details
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">&nbsp;
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
                                    <td colspan="4">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background: #808080; width: 100%; color: #FFF; padding: 10px">Member requirements and decision
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">&nbsp;
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
                                <td align="left" colspan="4" style="width: 100%; padding-left: 12px; margin-top: 2px; padding-top: 12px;">
                                    <table width="70%">
                                        <tr>
                                            <td style="width: 35%">Member History
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="lnkMemberHistory" runat="server" OnClick="lnkMemberHistory_Click"
                                                    ImageUrl="~/App_Themes/Theme/Images/btn_View.png" Height="29px" Width="101px"
                                                    ToolTip="click to View Member History" CommandName="MemberHistory" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Premium History
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="lnkPremiumHistory" runat="server" OnClick="lnkBtnReceiptDetails_Click"
                                                    ImageUrl="~/App_Themes/Theme/Images/btn_View.png" Height="29px" Width="101px"
                                                    ToolTip="click to View Premium History" CommandName="MemberHistory" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>COI Generation
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="lnkCOIGeneration" runat="server" OnClick="lnkCoi_Click" ImageUrl="~/App_Themes/Theme/Images/btn_View.png"
                                                    Height="29px" Width="101px" ToolTip="click to COI Generation" CommandName="COIGeneration" />
                                            </td>
                                        </tr>
                                        <%------------%>
                                        <tr>
                                            <td>Surrender Letter
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="lnkSurrenderletter" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_View.png"
                                                    Height="29px" Width="101px" OnClick="lnkSurrenderletter_Click" ToolTip="click to COI Generation" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Decline Letter
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
                                                <td style="width: 188px;">Name
                                                </td>
                                                <td style="width: 20px;">:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Name" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender23" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lbl_Name" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Gender
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Gender" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender24" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lbl_Gender" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Birth Date
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_DOB" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                        ID="RoundedCornersExtender27" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                        TargetControlID="lbl_DOB" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Age
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Age" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                        ID="RoundedCornersExtender28" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                        TargetControlID="lbl_Age" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Mobile No.
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_MbNo" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                        ID="RoundedCornersExtender7" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                        TargetControlID="lbl_MbNo" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Recharge Date
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_RCharDt" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                        ID="RoundedCornersExtender10" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                        TargetControlID="lbl_RCharDt" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Member Status
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_MemberStatus" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender33" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lbl_MemberStatus" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Remark
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Remark" runat="server" Width="360px">&nbsp;</asp:Label><cc1:RoundedCornersExtender
                                                        ID="RoundedCornersExtender8" runat="server" BorderColor="179, 179, 179" Radius="8"
                                                        TargetControlID="lbl_Remark" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Circle
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Circl" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender39" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lbl_Circl" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Validity
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Validty" runat="server" Width="360px">&nbsp;</asp:Label>
                                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender40" runat="server" BorderColor="179, 179, 179"
                                                        Radius="8" TargetControlID="lbl_Validty" Enabled="True">
                                                    </cc1:RoundedCornersExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp;
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


        </div>

    </form>
    <script src="../App_Themes/Theme/StyleSheets/dashboard_script.js" type="text/javascript"></script>
    <script type="text/javascript">       
        !window.jQuery && document.write(unescape('%3Cscript src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"%3E%3C/script%3E'))</script>

    <script src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"
        type="text/javascript"></script>

    <script type="text/javascript">
            (function ($) {
                $(window).load(function () {
                    $("#divMemberInformation").mCustomScrollbar({
                        scrollButtons: {
                            enable: true
                        }
                    });
                });
            })(jQuery);
         
       function RedirectToParent() {
        // Call parent window function from iframe
        if (window.parent && window.parent.onIframeButtonClick) {
            window.parent.onIframeButtonClick();
        }
    }
    </script>

</body>
</html>
