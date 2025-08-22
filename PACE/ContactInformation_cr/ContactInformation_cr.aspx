<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactInformation_cr.aspx.cs"
    MasterPageFile="~/Masters/MenuMasterPage_Cr.master"
    Inherits="PACE.ContactInformation_cr.ContactInformation_cr" %>

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
</html>
--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/inner_page_style.css" rel="stylesheet" />
    <%--<script src="App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>

    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap CSS -->
    <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">--%>

    <style type="text/css">
        @media (max-width: 780px) {
            .contactinfo {
                padding: 30px 20px;
            }

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .contactinfo h2 {
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
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .popupPanel {
            background-color: white;
            width: 900px;
            padding: 20px;
            border: solid 1px #333;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function popUp(ClientUnitUID) {

            strOpen = "popupContactinfo_cr.aspx?" + ClientUnitUID;
            window.open(strOpen, 'popWindow', 'toolbar=0,scrollbars=0,location=0,statusbar=0,addressbar=0,menubar=0,resizable=0,maximize=0,width=960,height=600,left = 90,top = 90');
            __doPostBack('', '');
        }

        function showModal() {
            // Remove any existing backdrops first
            $('.modal-backdrop').remove();
            $('body').removeClass('modal-open');

            var myModal = new bootstrap.Modal(document.getElementById('contactModal'));
            myModal.show();
        }

        function CloseModal() {
            var modal = bootstrap.Modal.getInstance(document.getElementById('contactModal'));
            if (modal) {
                modal.hide();
            } else {
                $('#contactModal').modal('hide');
            }

            // Force cleanup of backdrop and body class
            setTimeout(function () {
                $('.modal-backdrop').remove();
                $('body').removeClass('modal-open');
                $('#contactModal').removeClass('show');
                $('#contactModal').attr('aria-hidden', 'true');
                $('#contactModal').removeAttr('aria-modal');
                $('#contactModal').removeAttr('role');
            }, 300);

            return true; // Continue postback
        }

        // Enhanced cleanup when modal is hidden
        $(document).ready(function () {
            $('#contactModal').on('hidden.bs.modal', function () {
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
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <main class="dashboard-main">
        <div class="contactinfo">
            <div class="content-area">
                <h2 class="page-title">Client Contact Information</h2>

                <%--<div id="div3" style="width: 650px; border: 0px black solid;">--%>
                <div class="data-table-container">
                    <asp:GridView runat="server" ID="gvContactInfo" Width="100%" AutoGenerateColumns="False"
                        PageSize="5" AllowPaging="true" GridLines="None" CssClass="data-table" OnPageIndexChanging="gvContactInfo_PageIndexChanging" OnRowCommand="gvContactInfo_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <HeaderStyle CssClass=".GridViewHeaderStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                            PageButtonCount="3" />
                        <Columns>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <%-- <asp:ImageButton ID="lnkEdit" runat="server" CausesValidation="False" Text="Edit"
                                        Height="30" Width="33" ImageUrl="~/App_Themes/Theme/Images/View.png" OnClientClick='<%# Eval("ClientUnitUID","javascript: return popUp({0})") %>'
                                        ForeColor="Black"></asp:ImageButton>--%>
                                    <asp:ImageButton ID="lnkEdit" runat="server" CausesValidation="False" Text="Edit"
                                        Height="23" Width="23" ImageUrl="~/App_Themes/Theme/Images/View.png" CommandName="ShowPopup" CommandArgument='<%# Eval("ClientUnitUID") %>'
                                        ForeColor="Black"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClientUnitCode" HeaderText="Sub Office Code" HeaderStyle-Width="30%" />
                            <asp:BoundField DataField="ClientUnitName" HeaderText="Sub Office Name" HeaderStyle-Width="60%" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>--%>
    <!-- Bootstrap JS Bundle (includes Popper) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Modal Popup (Standardized with Bootstrap) -->
            <div class="modal fade" id="contactModal" tabindex="-1" aria-labelledby="contactModalLabel" aria-hidden="true" data-bs-backdrop="static" data-bs-keyboard="false">
                <div class="modal-dialog modal-lg modal-dialog-scrollable">
                    <!-- Use Bootstrap dialog classes -->
                    <div class="modal-content">
                        <div class="modal-header">
                            <h2 class="modal-title" id="contactModalLabel">Contact Information</h2>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            <!-- Standard Bootstrap close button -->
                        </div>
                        <div class="modal-body">

                            <div id="contactForm">
                                <div class="form-row">
                                    <label for="lblUnitCode">Sub Office Code</label>
                                    <asp:Label ID="lblUnitCode" runat="server" Width="100%">
                                    </asp:Label>
                                </div>
                                <div class="form-row">
                                    <label for="lblUnitName">Sub Office Name</label>
                                    <asp:Label ID="lblUnitName" runat="server" Width="100%">
                                    </asp:Label>
                                </div>
                                <div class="form-row">
                                    <label for="modalAddress">Address</label>
                                    <input id="txtAddress" runat="server" type="text" style="width: 100%;" disabled="True" />
                                    <span class="error-message">This field is required.</span>
                                </div>
                                <div class="form-row form-row-split">
                                    <div>
                                        <label for="modalContactName">Contact Person Name</label>
                                        <asp:TextBox ID="txtContPerName" runat="server" Enabled="False"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtContPerName"
                                            ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Please enter characters: Alphabets and space."
                                            ForeColor="Black" Visible="False" />
                                        <span class="error-message">This field is required.</span>
                                    </div>
                                    <div>
                                        <label for="modalContactNumber">Contact Number</label>
                                        <asp:TextBox ID="txtContactNo" runat="server" CssClass="inputbg" onkeypress="javascript:return isNumber(event)"
                                            Enabled="False"></asp:TextBox>
                                        <span class="error-message">This field is required.</span>
                                    </div>
                                </div>
                                <div class="form-row form-row-split">
                                    <div>
                                        <label for="modalContactEmail">Contact Person Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter valid mail "
                                            ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ForeColor="Black" Visible="False"></asp:RegularExpressionValidator>
                                        <span class="error-message">This field is required.</span>
                                    </div>
                                    <div>
                                        <label for="modalContactDesignation">Contact Person Designation</label>
                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="inputbg" Enabled="False"></asp:TextBox>
                                        <span class="error-message">This field is required.</span>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer modal-buttons">
                            <!-- Use standard modal-footer -->
                            <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-secondary" Text="Edit" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" Enabled="false" />
                            <%--<asp:Button ID="btnCancel" runat="server" CssClass="btn btn-light" Text="Cancel" OnClientClick="return CloseModal();" />--%>
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-light" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="CloseModal();" />
                            <%--<button type="button" id="cancelButton" class="btn btn-light" data-bs-dismiss="modal">Cancel</button>--%>
                            <!-- Use data-bs-dismiss -->
                            <asp:HiddenField ID="hdnModel" runat="server" />

                            <%--<asp:Button ID="btnCancel" runat="server" CssClass="cancel_button" OnClientClick="closeWin();" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
