<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="Contactus_cr.aspx.cs" Inherits="PACE.ContactUs.Contactus_cr" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>
    <style type="text/css">
         .change-password-header-bar {
            background-color: #cccccc; /* Grey background */
            padding: 8px 15px;
            font-weight: bold;
            margin-bottom: 20px;
            border-radius: 4px;
        }
        .mailimage {
            display: flex;
            align-items: center;
            gap: 10px;
            margin-top: 15px;
        }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
     <!-- Main Content Area -->
    <main class="dashboard-main">
        <div class="changepassword">
        <div class="content-box">
             <div class="change-password-header-bar">Contact us</div>
            <div >
                <div class="mb-3 row" style="display: flex; flex-wrap: wrap;">
                <label for="contactus" class="col-sm-4 col-form-label">For any enquiries please</label>
                    </div>
                <div class="mailimage" style="display: flex; flex-wrap: wrap;">
                <img src="../App_Themes/Theme/Images/New/message.png" height="10px" width="10px"
                    alt="Number" />
                write to us on <a href="mailto:csindia@tataaia.com">csindia@tataaia.com</a>
                    </div>
            </div>
        </div>
        </div>
            </main>
   <%-- <table cellpadding="5" cellspacing="5" border="0" width="100%">
        <tr>
            <th class="strip-title" colspan="3" valign="top">
                Contact us
            </th>
        </tr>
        <tr>
            <td>
                For any enquiries please
            </td>
        </tr>
       
        <tr>
            <td>
                <img src="../App_Themes/Theme/Images/New/message.png" height="10px" width="10px"
                    alt="Number" />
                write to us on <a href="mailto:csindia@tataaia.com">csindia@tataaia.com</a>
            </td>
        </tr>
    </table>--%>
</asp:Content>
