<%@ Page Language="C#" AutoEventWireup="true" Inherits="LoginPage" EnableViewState="true" CodeBehind="LoginPage.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <script src="App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
      <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/JScript1.js" type="text/javascript"></script>


    <style>
        /* Basic Reset & Theme Variables */
        :root {
            --primary-navy: #003366;
            --primary-orange: #f97316;
            --light-blue-bg: #f0f9ff;
            --text-dark: #0f172a;
            --text-medium: #475569;
            --text-light: #64748b;
            --border-light: #e2e8f0;
            --card-bg: #ffffff;
            --input-bg: #f8fafc;
            --input-focus-shadow: rgba(0, 51, 102, 0.2);
            --separator-text: #94a3b8;
            --font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body.page-login {
            font-family: var(--font-family);
            background-color: var(--light-blue-bg);
            /* Override dashboard body styles for centering login form */
            display: flex;
            flex-direction: column; /* Keep column direction for header/footer */
            justify-content: center; /* Center login container vertically */
            align-items: center; /* Center login container horizontally */
            min-height: 100vh;
            color: var(--text-dark);
        }

        .login-container {
            width: 100%;
            padding: 20px;
        }

        .login-card {
            background-color: var(--card-bg);
            padding: 40px 30px;
            border-radius: 15px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.08);
            max-width: 400px;
            margin: auto;
            text-align: center;
        }

        .logo {
            width: 150px; /* Adjust as needed */
            height: auto; /* Maintain aspect ratio */
            max-height: 50px; /* Limit height */
            object-fit: contain;
            margin: 0 auto 25px auto;
        }

        .login-card h2 {
            margin-bottom: 10px;
            font-size: 24px;
            font-weight: 600;
            color: var(--primary-navy);
        }

        .login-card p {
            margin-bottom: 30px;
            color: var(--text-medium);
            font-size: 14px;
        }

        .input-group {
            margin-bottom: 20px;
            text-align: left;
        }

            .input-group label {
                display: block;
                margin-bottom: 5px;
                font-size: 14px;
                font-weight: 500;
                color: var(--text-medium); /* Adjusted from #334155 */
            }

        .input-with-icon {
            position: relative;
            display: flex;
            align-items: center;
            background-color: var(--input-bg);
            border: 1px solid var(--border-light);
            border-radius: 8px;
            padding: 0 10px;
            transition: border-color 0.3s ease, box-shadow 0.3s ease;
        }

            .input-with-icon:focus-within {
                border-color: var(--primary-navy);
                box-shadow: 0 0 0 2px var(--input-focus-shadow);
            }

            .input-with-icon .icon {
                color: var(--text-light);
                margin-right: 10px;
                font-size: 18px;
            }

            .input-with-icon input {
                width: 100%;
                padding: 12px 5px;
                border: none;
                background-color: transparent;
                outline: none;
                font-size: 14px;
                color: var(--text-dark);
            }

            .input-with-icon .toggle-password {
                position: absolute;
                right: 15px;
                cursor: pointer;
                color: var(--text-light);
            }

            .signin-btn:focus-visible{
                border:none;
            }

        .options {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 25px;
            font-size: 13px;
        }

        .remember-me {
            display: flex;
            align-items: center;
            color: var(--text-medium); /* Adjusted from #334155 */
        }

            .remember-me input[type="checkbox"] {
                margin-right: 8px;
                accent-color: var(--primary-orange);
            }

        .forgot-password {
            color: var(--primary-navy);
            text-decoration: none;
        }

            .forgot-password:hover {
                color: var(--primary-orange);
                text-decoration: underline;
            }

        .signin-btn {
            width: 100%;
            padding: 12px;
            background-color: var(--primary-orange);
            color: var(--card-bg);
            border: none;
            border-radius: 8px;
            font-size: 16px;
            font-weight: 600;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

            .signin-btn:hover {
                background-color: #ea580c; /* Darker orange on hover - kept direct for simplicity or could be a variable */
            }

        .separator {
            margin: 30px 0;
            text-align: center;
            color: var(--separator-text);
            font-size: 13px;
            display: flex;
            align-items: center;
        }

            .separator::before,
            .separator::after {
                content: '';
                flex: 1;
                border-bottom: 1px solid var(--border-light);
                margin: 0 10px;
            }

        .social-login {
            display: flex;
            justify-content: center;
            gap: 15px;
            margin-bottom: 30px;
        }

        .social-btn {
            width: 45px;
            height: 45px;
            border-radius: 8px;
            border: 1px solid var(--border-light);
            background-color: var(--input-bg);
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 20px;
            color: var(--text-medium);
            cursor: pointer;
            transition: background-color 0.3s ease, border-color 0.3s ease;
        }

            .social-btn:hover {
                background-color: var(--light-blue-bg);
                border-color: #cbd5e1; /* Could be a variable */
            }

        .signup-link {
            font-size: 14px;
            color: var(--text-medium);
        }

            .signup-link a {
                color: var(--primary-navy);
                text-decoration: none;
                font-weight: 500;
            }

                .signup-link a:hover {
                    color: var(--primary-orange);
                    text-decoration: underline;
                }

        /* Responsive adjustments */
        @media (max-width: 480px) {
            .login-card {
                padding: 30px 20px;
            }

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .login-card h2 {
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
</head>
<body class="login_body">

    <div class="login-container">
        <div class="login-card">
            <!-- Restore Logo in Login Card -->
            <img src="App_Themes/Theme/Images/tataAIA_life_logo.jpg" alt="Xangam Logo" class="logo">
            <h2>Welcome Back</h2>
            <p>Login to access your corporate dashboard</p>


            <form id="form1" runat="server" defaultbutton="btnLogin">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <div class="input-group">
                    <label for="username">Username</label>
                    <div class="input-with-icon">
                        <span class="icon">&#128100;</span>
                        <asp:TextBox ID="txtUserName" autocomplete="off" runat="server" Class="login_input" onkeypress="RemoveSpecialChar(this);"
                            onkeydown="RemoveSpecialChar(this);" Text="" onkeyup="RemoveSpecialChar(this);" ondrop="return false;"
                            AutoCompleteType="Disabled" onpaste="return false;"></asp:TextBox>
                    </div>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                        FilterType="Numbers, UppercaseLetters, LowercaseLetters" TargetControlID="txtUserName">
                    </ajaxToolkit:FilteredTextBoxExtender>
                    <label id="lblUserName" style="display: none; color: Red;">
                        Enter User Name</label>
                </div>

                <div class="input-group">
                    <label for="password">Password</label>
                    <div class="input-with-icon">
                        <span class="icon">&#128274;</span>

                        <asp:TextBox ID="txtPassword" runat="server" Class="validate[required] login_input"
                            ondrop="return false;" onpaste="return false;" autocomplete="off" Text="" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                        <span class="icon toggle-password" onclick="togglePasswordVisibility()">👁️</span>
                    </div>
                    <label id="lblPass" style="display: none; color: Red;">
                        Enter Password</label> 
                </div>

                <div class="options">
                    <label class="remember-me">
                        <input type="checkbox" id="remember">
                        Remember me
                    </label>
                    <a href="#" class="forgot-password">Forgot your password?</a>
                </div>

                <asp:Button ID="btnLogin" class="signin-btn" runat="server" Text="Sign In" OnClientClick="javascript:return LoginValidation();"
                    OnClick="butLogin_Click"></asp:Button>

                <div class="separator">OR</div>

                <div class="social-login">
                    <button type="button" class="social-btn github">G</button>
                    <button type="button" class="social-btn google">G</button>
                    <button type="button" class="social-btn facebook">f</button>
                </div>

                <p class="signup-link">
                    Don't have an account? <a href="#">Contact your administrator</a>
                </p>


            </form>
        </div>
    </div>
<script type="text/javascript"> 
    function togglePasswordVisibility() {
        var passwordInput = document.getElementById('<%= txtPassword.ClientID %>');
        var icon = document.querySelector('.toggle-password');
        
        if (passwordInput.type === "password") {
            passwordInput.type = "text";
            icon.textContent = "🙈"; 
        } else {
            passwordInput.type = "password";
            icon.textContent = "👁️";
        }
    }
</script>

</body>
</html>
