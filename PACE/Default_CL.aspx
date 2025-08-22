<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_CL.aspx.cs" Inherits="PACE.Default_CL" %>
<%--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
    <title>Welcome to PACE</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />

    <script src="App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="Scripts/JScript1.js" type="text/javascript"></script>


    <style type="text/css">
        body
        {
            font-size: 16px !important;
            line-height: 18px;
        }
        .uniqueReference
        {
            color: #000;
            cursor: auto;
            height: 69px;
            line-height: 69px;
            margin: 0;
            padding: 0;
            position: fixed;
            text-align: center;
            width: 244px;
            text-align: center;
            font-size: 12px !important;
            line-height: 14px !important;
            bottom: -26px;
            left: -40px;
        }
        .Footer
        {
            background-color: #23bcb9;
            width: 100%;
            text-align: center;
            font-size: 12px !important;
            line-height: 14px !important;
            bottom: -226px;
            left: 0px;
            height: 14px;
            margin: 0;
            padding: 0;
            position: absolute;
            color: #000;
            cursor: auto;
        }
         /* Responsive adjustments */
        @media (max-width: 780px) {
         /*   .default-page {
                padding: 30px 20px;
            }*/

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .default-page h2 {
                font-size: 22px;
                line-height: 1.5;
            }

            .module-content h1{
                  line-height: 1.5;
            }

            .options {
                flex-direction: column;
                align-items: flex-start;
                gap: 10px;
            }

            .forgot-password {
                align-self: flex-start;
            }
        }

    </style>
</head>
<body class="container">
    <form id="form1" runat="server">
    <div class="default-page">

        <header class="dashboard-header">
        <div class="header-container">
            <div class="header-left">
                <img src="App_Themes/Theme/Images/tata_pace.png" alt="Xangam Logo" class="logo">
            </div>
            <nav class="dashboard-nav">
                <ul class="main-menu">
                    <!-- Policy Information -->
                    <li class="nav-item has-megamenu">
                        <a href="#" class="nav-link">Policy Information <i class="fas fa-chevron-down"></i></a>
                        <div class="mega-menu">
                            <div class="mega-menu-column">
                                <h4>Policy Details</h4> <!-- Updated heading -->
                                <ul>
                                    <li><a href="CreditLifeInformation/CreditLifeInformation.aspx" class="nav-link sub-link">Policy Enquiry</a></li>
                                    <li><a href="CreditLifeInformation/COpyPolicySubOfficeAccess_cr.aspx" class="nav-link sub-link">Policy & Sub Office Access</a></li>
                                    <li><a href="ContactInformation_cr/ContactInformation_cr.aspx" class="nav-link sub-link">Client Contact Information</a></li>
                                    
                                </ul>
                            </div>
                            <div class="mega-menu-column">
                                <h4>Downloads</h4>
                                <ul>
                                    <li><a href="../CreditLifeInformation/PremiumRates_cr.aspx" class="nav-link sub-link" data-target="policy-enquiry">Premium Rates Credit Life</a></li> <!-- Link updated -->
                                    <li><a href="../CreditLifeInformation/NEL_cr.aspx" class="nav-link sub-link">Non Medical Limit (NML)</a></li>
                                    <li><a href="../MemberInformation_cr/AllMember.aspx" class="nav-link sub-link">COI Download</a></li>
                                </ul>
                            </div>
                        </div>
                    </li>
                    <!-- Member Information -->
                    <li class="nav-item">
                        <a href="../MemberInformation_cr/MemberInformation_cr.aspx" class="nav-link">Member Information</a>
                    </li>
                    <li class="nav-item">
                        <a href="../MIS/BillEnquiry_cr.aspx?id=ClientMIS" class="nav-link">MIS Screen</a>
                    </li>
                     <!-- Premium calculator -->
                    <li class="nav-item has-megamenu">
                        <a href="#" class="nav-link">Premium calculator <i class="fas fa-chevron-down"></i></a>
                        <div class="mega-menu">
                             <div class="mega-menu-column">
                                <h4>Calculation</h4>
                                <ul>
                                    <li><a href="../CreditLifeInformation/PremiumCalculation.aspx" class="nav-link sub-link" data-target="billing-enquiry">Premium calculation</a></li>
                                    <li><a href="../CreditLifeInformation/SurrenderCalculation.aspx" class="nav-link sub-link" data-target="billing-payment">Surrender calculation</a></li>
                                </ul>
                            </div>
                        </div>
                    </li>
                    <!-- Servicing (Refactored to Mega Menu structure) -->
                       <li class="nav-item has-megamenu">
                        <a href="#" class="nav-link">Servicing <i class="fas fa-chevron-down"></i></a>
                        <div class="mega-menu">
                             <div class="mega-menu-column">
                                <ul>
                                    <li><a href="../Services_cr/service_cr.aspx" class="nav-link sub-link" data-target="billing-enquiry">Submission</a></li>
                                </ul>
                            </div>
                        </div>
                    </li>
             
                    <!-- Miscellaneous (Refactored to Mega Menu structure) -->
                    <li class="nav-item has-megamenu"> <!-- Changed from dropdown -->
                        <a href="#" class="nav-link">Miscellaneous <i class="fas fa-chevron-down"></i></a> <!-- Changed from dropdown-toggle -->
                        <div class="mega-menu"> <!-- Changed from dropdown-menu -->
                             <div class="mega-menu-column">
                                <h4>Other</h4> <!-- Added heading for structure -->
                                <ul>
                                    <%--<li><a href="customer_feedback.html" class="nav-link sub-link">Customer Feedback</a></li> <!-- Changed class -->--%>
                                    <li><a href="../ChangePassword/ChangePassword_cr.aspx" class="nav-link sub-link">Change Password</a></li> <!-- Changed class -->
                                    <li><a href="../ContactUs/Contactus_cr.aspx" class="nav-link sub-link">Contact Us</a></li> <!-- Changed class -->
                                </ul>
                            </div>
                        </div>
                    </li>
                </ul>
                <!-- Mobile Nav Footer: Contains Welcome/Logout for mobile view -->
                <div class="mobile-nav-footer">
                    <span class="user-greeting">Welcome, [User Name]</span>
                    <asp:Button ID="Button1_Mobile" runat="server" CssClass="LogoutIcon_button logout-btn" Text="Logout" UseSubmitBehavior="false"
                                            OnClick="btnLogOut_Click" />
                </div>
            </nav>
            <div class="header-right">
                <span class="user-greeting">Welcome, <asp:Label ID="lblusername" runat="server" /></span>
                 <%--<asp:ImageButton ID="ImageButton1" class="logout-btn" runat="server" ToolTip="Logout" AlternateText="" OnClick="imgLogout_Click" />--%>
                <asp:Button ID="Button1" runat="server" CssClass="LogoutIcon_button logout-btn" Text="Logout" UseSubmitBehavior="false"
                                        OnClick="btnLogOut_Click" />
            </div>
            <button class="mobile-nav-toggle"><i class="fas fa-bars"></i></button>
        </div>
    </header>

            <!-- Main Content Area -->
    <main class="dashboard-main-content">
        <section class="content-area">
            <!-- Default/Selected Content Area (Dashboard Grid) -->
            <div id="policy-info-main" class="module-content active">
                <h1>PACE Portal Dashboard</h1>
                <p>Select a module to manage your corporate policies.</p>

                <div class="dashboard-grid">
                    <!-- Card for Policy Information -->
                    <div class="dashboard-card">
                        <div class="card-icon">&#128196;</div> <!-- Placeholder icon -->
                        <h2>Policy Information</h2>
                        <p>View policy details, contacts, and download documents.</p>
                        <a href="#" class="card-link" data-target="policy-enquiry">Go to Policy Info</a> <!-- Link to specific section -->
                    </div>

                    <!-- Card for Member Information -->
                    <div class="dashboard-card">
                        <div class="card-icon">&#128101;</div> <!-- Placeholder icon -->
                        <h2>Member Information</h2>
                        <p>Search and view details for individual members.</p>
                        <a href="member_information.html" class="card-link">Go to Member Info</a> <!-- Direct link -->
                    </div>

                    <!-- Card for MIS Screen -->
                    <div class="dashboard-card">
                        <div class="card-icon">&#128202;</div> <!-- Placeholder icon -->
                        <h2>MIS Screen</h2>
                        <p>Analyze management information system (MIS) reports and client data.</p>
                        <a href="bill_enquiry.html" class="card-link">Go to MIS</a> <!-- Direct link -->
                    </div>

                       <!-- Card for Premium calculator  -->
                    <div class="dashboard-card">
                        <div class="card-icon">&#128425;</div> <!-- Placeholder icon -->
                        <h2>Premium calculator </h2>
                        <p>Computes insurance premiums based on coverage, risk factors, and policy terms</p>
                        <a href="claim_intimation.html" class="card-link">Go to Premium calculator </a> <!-- Direct link -->
                    </div>

                    <!-- Card for Servicing -->
                    <div class="dashboard-card">
                        <div class="card-icon">&#128736;</div> <!-- Placeholder icon -->
                        <h2>Servicing</h2>
                        <p>Raise service requests and perform online member servicing.</p>
                        <a href="raise_service_request.html" class="card-link">Go to Servicing</a> <!-- Direct link -->
                    </div>


                    <!-- Card for Miscellaneous (Placeholder) -->
                    <div class="dashboard-card">
                        <div class="card-icon">&#9881;</div> <!-- Placeholder icon -->
                        <h2>Miscellaneous</h2>
                        <p>Access other tools and resources.</p>
                        <a href="customer_feedback.html" class="card-link">Go to Misc</a> <!-- Direct link -->
                    </div>
                </div>
            </div>
            <!-- Add divs for all other data-target IDs (Placeholder Content) -->
             <div id="policy-enquiry" class="module-content"><h2>Policy Enquiry</h2><p>Policy Enquiry Content Placeholder</p></div>
             <div id="policy-access" class="module-content"><h2>Policy & Sub Office Access</h2><p>Policy & Sub Office Access Content Placeholder</p></div>
             <div id="contact-info" class="module-content"><h2>Client Contact Information</h2><p>Client Contact Information Content Placeholder</p></div>
             <div id="download-premium-rate" class="module-content"><h2>Download Premium Rate</h2><p>Download Premium Rate Content Placeholder</p></div>
             <div id="download-nel" class="module-content"><h2>Download NEL</h2><p>Download NEL Content Placeholder</p></div>
             <div id="download-benefit-basis" class="module-content"><h2>Download Benefit Basis</h2><p>Download Benefit Basis Content Placeholder</p></div>
             <div id="download-premium-statement" class="module-content"><h2>Download Premium Statement</h2><p>Download Premium Statement Content Placeholder</p></div>
             <div id="download-member-listing" class="module-content"><h2>Download Member Listing</h2><p>Download Member Listing Content Placeholder</p></div>
             <div id="member-info" class="module-content"><h2>Member Information</h2><p>Member Information Content Placeholder</p></div>
             <div id="billing-enquiry" class="module-content"><h2>Bill Enquiry</h2><p>Bill Enquiry Content Placeholder</p></div>
             <div id="billing-payment" class="module-content"><h2>Bill Payment</h2><p>Bill Payment Content Placeholder</p></div>
             <div id="servicing-request" class="module-content"><h2>Raise Service Request</h2><p>Raise Service Request Content Placeholder</p></div>
             <div id="servicing-add" class="module-content"><h2>Online Servicing - Member Addition</h2><p>Online Servicing - Member Addition Content Placeholder</p></div>
             <div id="servicing-delete" class="module-content"><h2>Online Servicing - Member Deletion</h2><p>Online Servicing - Member Deletion Content Placeholder</p></div>
             <div id="servicing-income" class="module-content"><h2>Online Servicing - Change Income</h2><p>Online Servicing - Change Income Content Placeholder</p></div>
             <div id="servicing-name" class="module-content"><h2>Online Servicing - Change Name</h2><p>Online Servicing - Change Name Content Placeholder</p></div>
             <div id="servicing-designation" class="module-content"><h2>Online Servicing - Change Designation</h2><p>Online Servicing - Change Designation Content Placeholder</p></div>
             <div id="claims-intimation" class="module-content"><h2>Claims Intimation</h2><p>Claims Intimation Content Placeholder</p></div>
             <div id="claims-upload" class="module-content"><h2>Claims Upload Documents</h2><p>Claims Upload Documents Content Placeholder</p></div>
             <div id="claims-status" class="module-content"><h2>Claims Status Check</h2><p>Claims Status Check Content Placeholder</p></div>
             <div id="claims-forms" class="module-content"><h2>Claims Form Download</h2><p>Claims Form Download Content Placeholder</p></div>
             <div id="claims-faq" class="module-content"><h2>Claims FAQ</h2><p>Claims FAQ Content Placeholder</p></div>
             <div id="misc" class="module-content"><h2>Miscellaneous</h2><p>Miscellaneous Content Placeholder</p></div>
        </section>
    </main>

    <footer class="dashboard-footer">
        <p>&copy; 2025 Xangam. All rights reserved.</p>
    </footer>


       <%-- <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td bgcolor="#22bcb9" style="padding: 5px;">
                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="4%" align="left" valign="middle">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/button1.jpg" width="50" height="51" /></a>
                            </td>
                            <td width="4%" align="left" valign="middle">
                                <asp:ImageButton ID="imgLogout" runat="server" ImageUrl="App_Themes/Theme/Images/New/button2.jpg"
                                    Width="50" Height="51" ToolTip="Logout" AlternateText="" OnClick="imgLogout_Click" />                               
                            </td>
                            <td width="1.7%" align="center" valign="middle">
                                <img src="../App_Themes/Theme/Images/top_line.jpg" width="2" height="38" alt="" />
                            </td>
                            <td width="33.3%" align="left" valign="middle">
                                <a href="../Default_CL.aspx" target="_self">
                                    <img src="App_Themes/Theme/Images/tata_aia_web.png" width="133" height="19" border="0"
                                        title="Home" alt="" /></a>
                            </td>
                            <td width="25%" align="right" valign="middle">
                                &nbsp;
                            </td>
                            <td width="2%" align="left" valign="middle" style="padding-top: 2px;">
                                &nbsp;
                            </td>
                            <td width="30%" align="right" valign="middle">
                                <img src="App_Themes/Theme/Images/tata_pace.png" width="250" height="57" alt="" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#b3b3b3">
                    &nbsp;
                </td>
            </tr>
        </table>--%>
       <%-- <table width="988" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 25px;">
            <tr>
                <td width="285" align="left" valign="top">
                    <table border="0" cellspacing="0" cellpadding="0" bgcolor="#22bcb9" class="ContentDisplay">
                        <tr>
                            <td align="center" valign="middle" id="tdSideDisplay" style="font-size: 18px !important">
                                <strong>Welcome to A Group Policy Administration Portal</strong>
                            </td>
                        </tr>
                        <tr>
                            <td height="110px" valign="middle">
                                <img border="0" src="App_Themes/Theme/Images/New/button4.jpg" width="200px" height="100px" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="713" align="left" valign="top" style="padding-left: 20px;">
                    <table width="87%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td id="CreditLifeInformation" width="152" align="left" style="padding: 2px;">
                                <a href="CreditLifeInformation/CreditLifeInformation.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Policy-Information.png" width="150"
                                        height="150" /></a>
                            </td>
                            <td width="152" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/1.png" width="150" height="150" /></a>
                            </td>
                            <td id="MemberInformation" width="152" align="left" style="padding: 2px;">
                                <a href="MemberInformation_cr/MemberInformation_cr.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Member-Information.png" width="150"
                                        height="150" /></a>
                            </td>
                            <td width="100%" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/2.png" width="150" height="150" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td width="152" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/3.png" width="150" height="150" /></a>
                            </td>
                            <td id="BillingInformation" width="152" align="left" style="padding: 2px;">
                                 <a href="CreditLifeInformation/PremiumCalculation.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Billing-Payment.png" width="150"
                                        height="150" /></a>
                            </td>
                            <td width="152" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/4.png" width="150" height="150" /></a>
                            </td>
                            <td id="Miscellaneous" width="100%" align="left" style="padding: 2px;">
                                         
                                 <a href="ChangePassword/ChangePassword_cr.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Miscellaneous.png" width="150" height="150" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td id="Servicing" width="152" align="left" style="padding: 2px;">
                                <a href="Services_cr/service_cr.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Servicing.png" width="150" height="150" /></a>
                            </td>
                            <td width="152" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/5.png" width="150" height="150" /></a>
                            </td>
                            <td id="Claim" width="152" align="left" style="padding: 2px;">                                
                                 <a href="MIS/BillEnquiry_cr.aspx?id=ClientMIS">
                                    <img border="0" src="App_Themes/Theme/Images/New/Claims.png" width="150" height="150" /></a>
                            </td>
                            <td width="100%" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/6.png" width="150" height="150" /></a>
                            </td>
                        </tr>
                        <tr bgcolor="#F5F5F5">
                            <td height="60" align="left" style="padding: 2px;">
                                &nbsp;
                                <input type="hidden" id="TTSLInput" runat="server" />
                            </td>
                            <td align="left" style="padding: 2px;">
                                &nbsp;
                                <a href="Applicationform.aspx">  
                                    <img border="0" src="App_Themes/Theme/Images/New/Applicationformtest.png" width="150" height="150" /></a></td>
                            <td align="left" style="padding: 2px;">
                                &nbsp;
                            </td>
                            <td align="left" style="padding: 2px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

        </table>--%>
    </div>
    <%-- <table width="100%" border="2" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="Footer">
                &nbsp;
            </td>
        </tr>
    </table>--%>
    <script src="App_Themes/Theme/StyleSheets/dashboard_script.js" type="text/javascript"></script>
    </form>

</body>
</html>