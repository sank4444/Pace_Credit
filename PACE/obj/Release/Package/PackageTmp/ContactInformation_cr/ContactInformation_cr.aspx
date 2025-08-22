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
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

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

    <script language="javascript" type="text/javascript">

        function popUp(ClientUnitUID) {

            strOpen = "popupContactinfo_cr.aspx?" + ClientUnitUID;
            window.open(strOpen, 'popWindow', 'toolbar=0,scrollbars=0,location=0,statusbar=0,addressbar=0,menubar=0,resizable=0,maximize=0,width=960,height=600,left = 90,top = 90');
            __doPostBack('', '');
        }

       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server" >
    <main class="dashboard-main">
    <div class="contactinfo">
         <div class="content-area">
        <h2 class="page-title">Client Contact Information</h2>
            
                <%--<div id="div3" style="width: 650px; border: 0px black solid;">--%>
                    <div class="data-table-container">
                    <asp:GridView runat="server" ID="gvContactInfo" Width="100%" AutoGenerateColumns="False"
                        PageSize="5" AllowPaging="true" GridLines="None" CssClass="data-table" OnPageIndexChanging="gvContactInfo_PageIndexChanging">
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
                                    <asp:ImageButton ID="lnkEdit" runat="server" CausesValidation="False" Text="Edit"
                                        Height="30" Width="33" ImageUrl="~/App_Themes/Theme/Images/View.png" OnClientClick='<%# Eval("ClientUnitUID","javascript: return popUp({0})") %>'
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
</asp:Content>
