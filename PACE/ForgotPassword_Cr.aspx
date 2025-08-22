<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword_Cr.aspx.cs" MasterPageFile="~/Masters/MenuMasterPage_Cr.master" Inherits="PACE.ForgotPassword" %>

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
    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Enter your email" CssClass="form-control"></asp:TextBox>
<asp:Button ID="btnSendResetLink" runat="server" Text="Send Reset Link" OnClick="btnSendResetLink_Click" CssClass="btn btn-primary" />
<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
     </div>
     </div>
     </main>
</asp:Content>