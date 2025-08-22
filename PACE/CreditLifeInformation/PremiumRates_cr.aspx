<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PremiumRates_cr.aspx.cs" MasterPageFile="~/Masters/MenuMasterPage_Cr.master"
 Inherits="PACE.CreditLifeInformation.PremiumRates_cr" %>


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
</html>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Premium Rates</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/jquery.dataTables.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <script src="https://code.jquery.com/jquery-1.12.3.js" type="text/javascript"></script>

    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>

     <style type="text/css">
        @media (max-width: 780px) {
            .premiumrates {
                padding: 30px 20px;
            }

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .premiumrates h2 {
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
       <style type="text/css">
        .pager-style {
       background-color: #f5f5f5;
    text-align: center;
    padding: 10px;
    background-color: #e9ecef;
    color: #333;
    border-radius: 4px;
    margin-top: 10px;
        }

        .pager-style a {
      color: #003366;
          background-color: #f8f9fa;
        padding: 5px 10px;
        margin: 2px;
        text-decoration: none;
           border: 1px solid #ddd;
        border-radius: 4px;
        }

        .pager-style a:hover {
          background-color: #e9ecef;
        color: #003366;
        }

        .pager-style span {
        font-weight: bold;
        color: white;
         background-color: var(--primary-color);
        padding: 5px 10px;
         border-color: var(--primary-color);
            border-radius: 4px;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function showModal() {
            var myModal = new bootstrap.Modal(document.getElementById('PremiumRateModal'));
            myModal.show();
        }


       
    </script>

    <script language="javascript" type="text/javascript">

        function popUp(ClientUnitUID) {

            strOpen = "popupPremiumRates_cr.aspx?" + ClientUnitUID;
            window.open(strOpen, 'popWindow', 'toolbar=0,scrollbars=0,location=0,statusbar=0,addressbar=0,menubar=0,resizable=0,maximize=0,width=960,height=600,left = 90,top = 90');
            __doPostBack('', '');
        }

        function showModal() {
            // Remove any existing backdrops first
            $('.modal-backdrop').remove();
            $('body').removeClass('modal-open');

            var myModal = new bootstrap.Modal(document.getElementById('PremiumRateModal'));
            myModal.show();
        }

        function CloseModal() {
            var modal = bootstrap.Modal.getInstance(document.getElementById('PremiumRateModal'));
            if (modal) {
                modal.hide();
            } else {
                $('#PremiumRateModal').modal('hide');
            }

            // Force cleanup of backdrop and body class
            setTimeout(function () {
                $('.modal-backdrop').remove();
                $('body').removeClass('modal-open');
                $('#PremiumRateModal').removeClass('show');
                $('#PremiumRateModal').attr('aria-hidden', 'true');
                $('#PremiumRateModal').removeAttr('aria-modal');
                $('#PremiumRateModal').removeAttr('role');
            }, 300);

            return true; // Continue postback
        }

        // Enhanced cleanup when modal is hidden
        $(document).ready(function () {
            $('#PremiumRateModal').on('hidden.bs.modal', function () {
                $('.modal-backdrop').remove();
                $('body').removeClass('modal-open');
                $(this).removeClass('show');
                $(this).attr('aria-hidden', 'true');
                $(this).removeAttr('aria-modal');
                $(this).removeAttr('role');
            });
        });

        // Additional cleanup for UpdatePanel postbacks
        function pageLoad() {
            // This runs after every UpdatePanel postback
            if ($('.modal-backdrop').length > 0) {
                $('.modal-backdrop').remove();
                $('body').removeClass('modal-open');
            }
        }
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server" >
            <!-- Main Content Area -->
    <main class="dashboard-main">
        <div class="content-area">
            <h2 class="page-title">Premium Rates Credit Life</h2>
               <div class="data-table-container">
                            <asp:GridView ID="gvPremiumRates" runat="server" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
                                CssClass="data-table" OnRowCommand="gvPremiumRates_RowCommand">
                                <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />--%>
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass=".GridViewHeaderStyle" />
                                <Columns>
                                    
                                    <asp:BoundField DataField="SegmentName" HeaderText="Segment Name"></asp:BoundField>
                                    <asp:BoundField DataField="RatePerName" HeaderText="Base Unit"></asp:BoundField>
                                    <asp:BoundField DataField="RateofInterest" HeaderText="Rate of Interest"></asp:BoundField>
                                    <asp:BoundField DataField="SumAssuredTypeName" HeaderText="Sum Assured Type"></asp:BoundField>
                                    
                                    <asp:BoundField DataField="Sex" HeaderText="Gender"></asp:BoundField>
                                    <asp:BoundField DataField="PolicyYear" HeaderText="Policy Year"></asp:BoundField>
                                    <asp:BoundField DataField="Moratorium" HeaderText="Moratorium"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Rate Code">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LnkButRateCode" runat="server" Text='<%#Eval("PremRateCode")%>'
                                                ToolTip='<%#Eval("PremRateCode")%>' CommandName="VIEWRATECODE" CommandArgument='<%#Eval("PremRateCode")%>'
                                                ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                   <div class="table-footer">
                       <asp:Label ID="lblPagingSummaryMain" runat="server" />
                    </div>  
                        </div>
        </div>
    </main>

       <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>--%>
     <!-- Bootstrap JS Bundle (includes Popper) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
     <!-- Modal Popup (Standardized with Bootstrap) -->
    <div class="modal fade" id="PremiumRateModal" tabindex="-1" aria-labelledby="contactModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-scrollable"> <!-- Use Bootstrap dialog classes -->
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title" id="contactModalLabel">Premium Rate Report</h2>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button> <!-- Standard Bootstrap close button -->
                </div>
                <div class="modal-body">
                      <div class="data-table-container">
                 <asp:GridView ID="gvPremiumRateReport" runat="server"  Visible="false" CssClass="data-table"
                    AllowPaging="true" PageSize="5" Width="100%" AutoGenerateColumns="true" OnPageIndexChanging="gvPremiumRateReport_PageIndexChanging"
                     PagerSettings-Mode="NumericFirstLast" 
                     PagerSettings-Position="Bottom"
                     PagerStyle-HorizontalAlign="Center">
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                        PageButtonCount="5" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="pager-style" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass=".GridViewHeaderStyle" />
                    <Columns>
                    </Columns>
                </asp:GridView>
                <asp:Label runat="server" ID="lblNoTextMsg" Visible="false" Text="No Records Found">
                </asp:Label>
                          
                </div>
                    <div>
                       <asp:Label ID="lblPagingSummary" runat="server" />
                    </div>  
                </div>
                 <div class="modal-footer modal-buttons"> <!-- Use standard modal-footer -->
                    <%--<button type="button" id="cancelButton" class="btn btn-primary" data-bs-dismiss="modal">Cancel</button>--%> 
                     <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btncancel_Click" OnClientClick="CloseModal();" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<%--<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
            
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>                    
            
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
            <div class="UpdateProgressmodal">
                <div class="UpdateProgresscenter">
                    <asp:Label ID="labelDisplay" runat="server" Text="Processing..."></asp:Label>
                    <br />
                    <img id="progessImage" src="../App_Themes/Theme/Images/loading.gif" alt="" width="70" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>--%>

