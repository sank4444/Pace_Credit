<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.master" AutoEventWireup="true"
    CodeBehind="CreditLifeInformation.aspx.cs" Inherits="PACE.CrediteLifeInformation.CreditLifeInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />

    <script src="App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="Scripts/JScript1.js" type="text/javascript"></script>

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
            width: 188px;
        }
        .style2
        {
            width: 3%;
        }

        
         /* Responsive adjustments */
        @media (max-width: 780px) {
            .clientlifeinfo {
               padding: 5px 5px;
            }

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .clientlifeinfo h2 {
                font-size: 22px;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

      <!-- Main Content Area -->
    <main class="dashboard-main">
        <div class="clientlifeinfo">
        <!-- Policy Enquiry Content -->
        <div class="content-area">
            <h2 class="page-title">Credit Life Policy Enquiry</h2>
            <!-- MODIFIED: Replaced info-grid with Bootstrap row/col layout -->
            <div class="row mt-3">
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Policy No</label>
                    <p class="form-control-plaintext ps-1">
                        <asp:Label ID="lblPolicyNo" Width="100%" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Client Code</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblClientCode" Width="100%" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Client</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblClient" Width="100%" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Policy Status</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblPolicyStaus" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Inception Date</label>
                    <p class="form-control-plaintext ps-1">
                          <asp:Label ID="lblInceptionDate" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Anniversary Date</label>
                    <p class="form-control-plaintext ps-1">
                        <asp:Label ID="lblAnniversaryDate" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Min Entry Age</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblminEntryAge" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Max Entry Age</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblMaxEntryAge" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Product Name</label>
                    <p class="form-control-plaintext ps-1">
                        <asp:Label ID="lblProducName" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Product UIN No</label>
                    <p class="form-control-plaintext ps-1">
                        <asp:Label ID="lblProductUINNo" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Service Manager Name</label>
                    <p class="form-control-plaintext ps-1">
                        <asp:Label ID="lblServiceManager" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Agent / Broker</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblAB" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                 <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Mode of policy</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblModeofPolicy" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                 <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Active Members</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblNumberofmembercovered" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                  <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold"> Segment Type</label>
                    <p class="form-control-plaintext ps-1">
                         <asp:Label ID="lblSegmentType" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
                  <div class="col-md-4 mb-3">
                    <label class="form-label fw-bold">Rate of Interest</label>
                    <p class="form-control-plaintext ps-1">
                        <asp:Label ID="lblRateInterest" runat="server" Width="100%"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
        </div>
    </main>

   <%-- <div id="content_1" class="content">
        <table border="0" cellpadding="0" cellspacing="0" style="font-size: 12px !important;"
            width="98%">
            <tr>
                <th class="strip-title" colspan="2" valign="top">
                    Credit Life Policy Enquiry
                </th>
            </tr>
            <tr>
                <td valign="top" align="left" width="80%">
                    <table border="0" cellpadding="0" cellspacing="5">
                        <tr>
                            <td style="text-align: left;" valign="top" class="style1">
                                <p style="height: 30px">
                                    Policy No</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td style="width: 70%;">
                                <asp:Label ID="lblPolicyNo" Width="90%" runat="server">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="rc" runat="server" BorderColor="#b3b3b3" Radius="10"
                                    Corners="All" TargetControlID="lblPolicyNo">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Client Code</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td height="34px">
                                <asp:Label ID="lblClientCode" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender20" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblClientCode">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Client</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblClient" Width="90%" runat="server">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblClient">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Policy Status</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblPolicyStaus" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblPolicyStaus">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Inception Date</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblInceptionDate" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblInceptionDate">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Anniversary Date</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblAnniversaryDate" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblAnniversaryDate">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Min Entry Age</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblminEntryAge" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender6" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblminEntryAge">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Max Entry Age</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblMaxEntryAge" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender7" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblMaxEntryAge">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Product Name</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblProducName" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender11" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblProducName">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Product UIN No</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblProductUINNo" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender12" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblProductUINNo">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Service Manager Name</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblServiceManager" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender13" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblServiceManager">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Agent / Broker</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblAB" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender15" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblAB">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Mode of policy</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblModeofPolicy" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender16" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblModeofPolicy">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Active Members</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblNumberofmembercovered" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender18" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblNumberofmembercovered">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Segment Type</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblSegmentType" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender17" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblSegmentType">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Rate of Interest</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblRateInterest" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender8" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblRateInterest">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>--%>

    <script type="text/javascript">        !window.jQuery && document.write(unescape('%3Cscript src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"%3E%3C/script%3E'))</script>
      <script src="App_Themes/Theme/StyleSheets/dashboard_script.js" type="text/javascript"></script>
    <script src="App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"
        type="text/javascript"></script>

    <script type="text/javascript">

        (function($) {
            $(window).load(function() {
                $("#content_1").mCustomScrollbar({
                    scrollButtons: {
                        enable: true
                    }
                });
            });
        })(jQuery);
    </script>

</asp:Content>
