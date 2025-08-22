<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberInformation_cr.aspx.cs"
    MasterPageFile="~/Masters/MenuMasterPage_Cr.master" Inherits="PACE.MemberInformation_cr.MemberInformation_cr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      <meta name="viewport" content="width=device-width, initial-scale=1">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />
     <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">--%>
     <%--<script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>--%>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

     <style type="text/css">

         @media (max-width: 480px) {
            .memberinfo {
                padding: 30px 20px;
            }

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .memberinfo h2 {
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
            .search_button {
                width: 100%;
                margin-top: 10px;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server" >
   <div class="memberinfo">
     <!-- Main Content Area -->
    <main class="dashboard-main">
        <div class="content-box">
            <h2 class="page-title">Member Enquiry</h2>

            <!-- Search Controls -->
            <div class="row mb-4 align-items-end gy-3" style="display: flex; flex-wrap: wrap;">
                <div class="col-md-4">
                    <label for="searchName" class="form-label">Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter name..">
                                </asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="searchCertNo" class="form-label">Certificate No.</label>
                    <asp:TextBox ID="txtCoiNo" runat="server" CssClass="form-control" placeholder="Enter certificate no..">
                                </asp:TextBox>
                </div>
                 <div class="col-md-4">
                    <label for="loanrefNo" class="form-label">Loan Reference No.</label>
                    <asp:TextBox ID="txtLoanRefNo" runat="server" CssClass="form-control" placeholder="Enter loan referance no..">
                                </asp:TextBox>
                </div>
                <div class="col-md-4">
                     <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search_button"
                                    TabIndex="0" ToolTip="Search" Height="29px" />
                </div>
                <div>
                    <asp:Label Style="width: 10px;" ID="lbl" runat="server"></asp:Label>
                </div>
            </div>

            <!-- Member Enquiry Table -->
            <div class="table-responsive data-table-container">
                 <asp:GridView ID="gvMembeInfo" runat="server" CssClass="table table-bordered table-striped data-table member-enquiry-table" AllowPaging="True" autogeneratecolumn="false"
                                        PageSize="5" GridLines="None" Width="100%" AutoGenerateColumns="False" OnPageIndexChanging="gvMembeInfo_PageIndexChanging"
                                        PagerSettings-Mode="NumericFirstLast" OnRowCommand="gvMembeInfo_RowCommand">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                            PageButtonCount="3" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="lnkView" runat="server" CausesValidation="False" CommandName="View"
                                                        Height="35px" Width="35px" ImageUrl="~/App_Themes/Theme/Images/View.png" ToolTip="Click to view member information details"
                                                        OnClientClick='<%# Eval("PolicyMemberUID","javascript: return popUp({0})") %>'
                                                        CommandArgument='<% #Eval("PolicyMemberUID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="EmployeeNo" HeaderText="Loan Reference No" />
                                            <asp:BoundField DataField="InsuredName" HeaderText="Insured Name" />
                                            <asp:BoundField DataField="COI" HeaderText="COI No" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                            <%-- <asp:BoundField DataField="PolicyYear" HeaderText="Policy Year" />--%>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="lblResult" runat="server" Visible="false" Text="No Record Found" ForeColor="red">
                                    </asp:Label>
            </div>

        </div> <!-- End Content Box -->
    </main>
   </div>
    <script language="javascript" type="text/javascript">

        function popUp(PolicyMemberUID) {
            strOpen = "MemberInfoDetails_cr.aspx?PolicyMemberUID=" + PolicyMemberUID;
            window.open(strOpen, 'popWindow', 'toolbar=0,titlebar=0,scrollbars=1,location=0,statusbar=0,status=1,fullscreen=0,menubar=0,resizable=1,width=920px,height=600px,left = 200,top = 100');
            __doPostBack('', '');
        }

        function Validation() {
            var NAME = $('#<%=txtName.ClientID %>').val();
            var COINO = $('#<%=txtCoiNo.ClientID %>').val();
          if (NAME == "" && COINO == "") {
                $('#divName').css('display', 'inline');
                $('#divName').html('<span id="DisplayingError" class="DisplayingError">Name and COI No can\'t be Empty </span>');
                $('#<%=txtName.ClientID %>').focus();
                // $('#DisplayingError').click(function() { $('#<%=txtName.ClientID %>').focus(); });
                return false;
            }
            else {
                return true;
            }
        }
    </script>

</asp:Content>
