<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" MasterPageFile="~/Masters/MenuMasterPage_Cr.master" Inherits="PACE.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      <meta name="viewport" content="width=device-width, initial-scale=1">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/inner_page_style.css" rel="stylesheet" />
    <%--<script src="App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>

    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server" >
     <main class="dashboard-main">
     <div class="contactinfo">
     <div class="content-area">
     <h2 class="page-title">Forgot Password</h2>
<asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Placeholder="New Password" CssClass="form-control"></asp:TextBox>
<asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" OnClick="btnResetPassword_Click" CssClass="btn btn-success" />
<asp:Label ID="lblResetStatus" runat="server" ForeColor="Green"></asp:Label>
     </div>
     </div>
     </main>
</asp:Content>