<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword_cr.aspx.cs" Inherits="PACE.ChangePassword.ChangePassword_cr"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function ReturningDefault() {
            alert("Password changed successfully.");
            window.location = "../Default_CL.aspx";
        }
    </script>
     <meta name="viewport" content="width=device-width, initial-scale=1">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .change-password-header-bar {
            background-color: #cccccc; /* Grey background */
            padding: 8px 15px;
            font-weight: bold;
            margin-bottom: 20px;
            border-radius: 4px;
        }
        .form-label {
            font-weight: 500; /* Slightly bolder labels */
        }
        .submit-button-container {
            text-align: center; /* Center the submit button */
            margin-top: 30px;
        }
        .form-container {
            max-width: 600px; /* Limit form width */
            margin: 0 auto; /* Center the form */
            padding: 20px;
        }
        /* CAPTCHA Styles */
        .captcha-container {
            display: flex;
            align-items: center;
            gap: 10px;
            margin-top: 15px;
        }
        #captchaText {
            font-family: 'Courier New', Courier, monospace;
            font-size: 1.5em;
            font-weight: bold;
            padding: 5px 10px;
            background-color: #f0f0f0;
            border: 1px solid #ccc;
            border-radius: 4px;
            user-select: none; /* Prevent text selection */
            text-decoration: line-through; /* Add line-through for visual effect */
            letter-spacing: 2px;
        }
        #refreshCaptcha {
            background: none;
            border: none;
            font-size: 1.2em;
            cursor: pointer;
            color: var(--primary-navy);
        }
        #captchaInput {
            margin-top: 10px;
        }
    </style>
     <style type="text/css">

         @media (max-width: 780px) {
            .changepassword {
                padding: 30px 20px;
            }

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .changepassword h2 {
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
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Link Dashboard Script for header functionality -->
    <script src="dashboard_script.js"></script>
    <!-- CAPTCHA Script -->
     <script  type="text/javascript">
         const captchaTextElement = document.getElementById('captchaText');
         const captchaInputElement = document.getElementById('TxtCaptchaCode');
         const refreshButton = document.getElementById('refreshCaptcha');
         const changePasswordForm = document.getElementById('changePasswordForm');
         let currentCaptcha = '';

         function generateCaptcha() {
             const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
             let captcha = '';
             for (let i = 0; i < 6; i++) {
                 captcha += chars.charAt(Math.floor(Math.random() * chars.length));
             }
             currentCaptcha = captcha;
             if (captchaTextElement) { // Check if element exists
                 captchaTextElement.textContent = captcha;
             }
             if (captchaInputElement) { // Check if element exists
                 captchaInputElement.value = ''; // Clear input on refresh
             }
         }

         if (captchaTextElement && captchaInputElement && refreshButton && changePasswordForm) { // Check if all elements exist
             refreshButton.addEventListener('click', generateCaptcha);

             changePasswordForm.addEventListener('submit', function (event) {
                 event.preventDefault(); // Prevent default form submission

                 const enteredCaptcha = captchaInputElement.value;
                 const newPassword = document.getElementById('newPassword').value;
                 const confirmPassword = document.getElementById('confirmPassword').value;

                 // Basic validation (add more as needed)
                 if (newPassword !== confirmPassword) {
                     alert('New password and confirm password do not match.');
                     generateCaptcha(); // Refresh captcha on error
                     return;
                 }

                 if (enteredCaptcha !== currentCaptcha) {
                     alert('CAPTCHA verification failed. Please try again.');
                     generateCaptcha(); // Refresh captcha on error
                 } else {
                     // CAPTCHA is correct, proceed with password change logic (simulation)
                     alert('CAPTCHA verified! Password change submitted (simulation).');
                     // Here you would typically send the form data to the server
                     // For now, just reset the form and captcha
                     changePasswordForm.reset();
                     generateCaptcha();
                 }
             });

             // Initial CAPTCHA generation on page load
             generateCaptcha();
         } else {
             console.error("CAPTCHA elements not found on this page.");
         }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
      <!-- Main Content Area -->
    <main class="dashboard-main">
        <div class="changepassword">
        <div class="content-box">
            <div class="change-password-header-bar">Change Password</div>

            <div class="form-container">
                <form id="changePasswordForm">
                    <!-- Current Password -->
                    <div class="mb-3 row">
                        <label for="currentPassword" class="col-sm-4 col-form-label">Current Password:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <!-- New Password -->
                    <div class="mb-3 row">
                        <label for="newPassword" class="col-sm-4 col-form-label">New Password:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <!-- Confirm New Password -->
                    <div class="mb-3 row">
                        <label for="confirmPassword" class="col-sm-4 col-form-label">Confirm New Password:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                             ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm password should be match new password"
                              Font-Names="Verdana" Font-Size="Small">
                            </asp:CompareValidator>
                        </div>
                    </div>

                    <!-- CAPTCHA Section -->
                    <div class="mb-3 row">
                        <label class="col-sm-4 col-form-label">Verification:</label>
                        <div class="col-sm-8">
                            <div class="captcha-container">
                                <%--<span id="captchaText"></span>
                                <button type="button" id="refreshCaptcha" title="Refresh CAPTCHA"><i class="fas fa-sync-alt"></i></button>--%>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/CImage.aspx" />
                            </div>
                            <asp:TextBox ID="TxtCaptchaCode" runat="server" CssClass="form-control" placeholder="Enter the text above"> 
                            </asp:TextBox>
                        </div>
                    </div>

                    <!-- Submit Button -->
                    <div class="submit-button-container">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Change Password" UseSubmitBehavior="false"
                                        OnClick="btnLogOut_Click" />
                    </div>
                </form>
            </div> <!-- End Form Container -->

        </div> <!-- End Content Box -->
    </main>

    <!-- Standard Footer -->
  <%--  <footer class="dashboard-footer">
        &copy; 2025 PACE Portal. All Rights Reserved.
    </footer>--%>

    
   

<%-- <table width="100%" border="0" cellpadding="2" cellspacing="0">
        <tr>
            <th class="strip-title" colspan="2" valign="top">
                Change Password
            </th>
        </tr>
        <tr>
            <td width="200px" align="left" style="text-align: left; padding-left: 5px;">
                Old Password
            </td>
            <td>
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="inputbg"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword"
                    ErrorMessage="*">
                </asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td align="left" style="text-align: left; padding-left: 5px;">
                New Password
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="inputbg"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="text-align: left; padding-left: 5px;">
                Confirm Password
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="inputbg"></asp:TextBox>
                 <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                    ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm password should be match new password"
                    Font-Names="Verdana" Font-Size="Small">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/CImage.aspx" />
            </td>
        </tr>
        <tr align="left">
            <td align="left" style="text-align: left; padding-left: 15px;">
                Enter above text
            </td>
            <td nowrap="nowrap">
                <asp:TextBox ID="TxtCaptchaCode" runat="server" CssClass="inputbg"> 
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="font-family: Verdana; font-size: small">
            </td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Submit.png"
                    Width="100px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
    </table>--%>
</asp:Content>
