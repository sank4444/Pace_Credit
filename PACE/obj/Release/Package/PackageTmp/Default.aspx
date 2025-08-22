<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PACE.NewDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to PACE</title>
    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <script src="App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="Scripts/JScript1.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function() {
            $("#PolicyInformation").hover(function() {
                $("#tdSideDisplay").text("View policy related information, download premium statement, member listing and a host of other information");
            }, function() {
                $("#tdSideDisplay").html("<strong>Welcome to TATA AIA<br /> Corporate Client Portal</strong>");
            })//end Hover
            $("#MemberInformation").hover(function() {
                $("#tdSideDisplay").text("View member level details");
            }, function() {
                $("#tdSideDisplay").html("Welcome to TATA AIA<br /> Corporate Client Portal");
            })//end Hover
            $("#BillingInformation").hover(function() {
                $("#tdSideDisplay").text("View past premium information and make bill payments");
            }, function() {
                $("#tdSideDisplay").html("Welcome to TATA AIA<br /> Corporate Client Portal");
            })//end Hover
            $("#ContactInformation").hover(function() {
                $("#tdSideDisplay").text("You can view the reserves held under the Group Term Life Policy which can applied towards future enrolments in the policy.You can also apply the reserves held in the policy towards premium.");
            }, function() {
                $("#tdSideDisplay").html("Welcome to TATA AIA<br /> Corporate Client Portal");
            })//end Hover
            $("#Servicing").hover(function() {
                $("#tdSideDisplay").text("A self service section to enroll new employees, terminate coverage, update salary changes and various other servicing options");
            }, function() {
                $("#tdSideDisplay").html("Welcome to TATA AIA<br /> Corporate Client Portal");
            })//end Hover
            $("#Miscellaneous").hover(function() {
                $("#tdSideDisplay").text("Contact us, share feedback and change password");
            }, function() {
                $("#tdSideDisplay").html("Welcome to TATA AIA<br /> Corporate Client Portal");
            })//end Hover
            $("#Claim").hover(function() {
                $("#tdSideDisplay").text("Inform us about a claim, check the status, upload claim documents and keep track of the payouts.");
            }, function() {
                $("#tdSideDisplay").html("Welcome to TATA AIA<br /> Corporate Client Portal");
            })//end Hover

        });
    </script>

    <style type="text/css">
        body
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px !important;
            line-height: 18px;
        }
        .uniqueReference
        {
            color: #000;
            cursor: auto;
            height: 69px;
            line-height: 69px;
            margin: 0;
            padding: 0;
            position: fixed;
            text-align: center;
            width: 244px;
            text-align: center;
            font-size: 12px !important;
            line-height: 14px !important;
            bottom: -26px;
            left: -40px;
        }
        .Footer
        {
            background-color: #23bcb9;
            width: 100%;
            text-align: center;
            font-size: 12px !important;
            line-height: 14px !important;
            bottom: -226px;
            left: 0px;
            height: 14px;
            margin: 0;
            padding: 0;
            position: absolute;
            color: #000;
            cursor: auto;
        }
    </style>
</head>
<body style="background-color: #F5F5F5;">
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td bgcolor="#22bcb9" style="padding: 5px;">
                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="4%" align="left" valign="middle">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/button1.jpg" width="50" height="51" /></a>
                            </td>
                            <td width="4%" align="left" valign="middle">
                                <%--<a href="LoginPage.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/button2.jpg" width="50" height="51" /></a>--%>
                                <asp:ImageButton ID="imgLogout" runat="server" ImageUrl="App_Themes/Theme/Images/New/button2.jpg"
                                    Width="50" Height="51" ToolTip="Logout" AlternateText="" OnClick="imgLogout_Click" />
                                <%--<a href="../LoginPage.aspx">
                                        <img src="../App_Themes/Theme/Images/ico3.png" width="40" height="40" border="0"
                                            title="Logout" alt="" /></a>--%>
                            </td>
                            <td width="1.7%" align="center" valign="middle">
                                <img src="../App_Themes/Theme/Images/top_line.jpg" width="2" height="38" alt="" />
                            </td>
                            <td width="33.3%" align="left" valign="middle">
                                <a href="../Default.aspx" target="_self">
                                    <img src="App_Themes/Theme/Images/tata_aia_web.png" width="133" height="19" border="0"
                                        title="Home" alt="" /></a>
                            </td>
                            <td width="25%" align="right" valign="middle">
                                &nbsp;
                            </td>
                            <td width="2%" align="left" valign="middle" style="padding-top: 2px;">
                                &nbsp;
                            </td>
                            <td width="30%" align="right" valign="middle">
                                <img src="App_Themes/Theme/Images/tata_pace.png" width="250" height="57" alt="" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#b3b3b3">
                    &nbsp;
                </td>
            </tr>
        </table>
        <table width="988" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 25px;">
            <tr>
                <td width="285" align="left" valign="top">
                    <table border="0" cellspacing="0" cellpadding="0" bgcolor="#22bcb9" class="ContentDisplay">
                        <tr>
                            <td align="center" valign="middle" id="tdSideDisplay" style="font-size: 18px !important">
                                <strong>Welcome to TATA AIA<br />
                                    Corporate Client Portal</strong>
                            </td>
                        </tr>
                        <tr>
                            <td height="110px" valign="middle">
                                <img border="0" src="App_Themes/Theme/Images/New/button4.jpg" width="200px" height="100px" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="713" align="left" valign="top" style="padding-left: 20px;">
                    <table width="87%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td id="PolicyInformation" width="152" align="left" style="padding: 2px;">
                                <a href="PolicyInformation/PolicyInformation.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Policy-Information.png" width="150"
                                        height="150" /></a>
                            </td>
                            <td width="152" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/1.png" width="150" height="150" /></a>
                            </td>
                            <td id="MemberInformation" width="152" align="left" style="padding: 2px;">
                                <a href="MemberInformation/MemberInformation.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Member-Information.png" width="150"
                                        height="150" /></a>
                            </td>
                            <td width="100%" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/2.png" width="150" height="150" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td width="152" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/3.png" width="150" height="150" /></a>
                            </td>
                            <td id="BillingInformation" width="152" align="left" style="padding: 2px;">
                                <a href="BillEnquiry/BillPayment.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/B_oldilling-Payment.png" width="150"
                                        height="150" /></a>
                            </td>
                            <td width="152" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/4.png" width="150" height="150" /></a>
                            </td>
                            <td id="Miscellaneous" width="100%" align="left" style="padding: 2px;">
                                <a href="CustomerSatisfactionSurvey/CustomerSatisfactionSurvey.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Miscellaneous.png" width="150" height="150" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td id="Servicing" width="152" align="left" style="padding: 2px;">
                                <a href="Services/service.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Servicing.png" width="150" height="150" /></a>
                            </td>
                            <td width="152" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/5.png" width="150" height="150" /></a>
                            </td>
                            <td id="Claim" width="152" align="left" style="padding: 2px;">
                                <a href="Claims/ClaimDefult.aspx">
                                    <img border="0" src="App_Themes/Theme/Images/New/Claims_old.png" width="150" height="150" /></a>
                            </td>
                            <td width="100%" align="left" style="padding: 2px;">
                                <a href="#">
                                    <img border="0" src="App_Themes/Theme/Images/New/6.png" width="150" height="150" /></a>
                            </td>
                        </tr>
                        <tr bgcolor="#F5F5F5">
                            <td height="60" align="left" style="padding: 2px;">
                                &nbsp;
                                <input type="hidden" id="TTSLInput" runat="server" />
                            </td>
                            <td align="left" style="padding: 2px;">
                                &nbsp;
                            </td>
                            <td align="left" style="padding: 2px;">
                                &nbsp;
                            </td>
                            <td align="left" style="padding: 2px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="15px" class="uniqueReference">
                    <blockquote>
                        L&C/Misc/2016/Feb/082
                    </blockquote>
                </td>
            </tr>
        </table>
    </div>
    <%-- <table width="100%" border="2" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="Footer">
                &nbsp;
            </td>
        </tr>
    </table>--%>
    </form>

    <script type="text/javascript">
//        var policyType = document.getElementById("<%=TTSLInput.ClientID%>"); ;
//        $('#PolicyInformation').click(function() {
//            if (policyType.value == 'Y') {

//                location.href = "history.go();return false;";
//            }
//        });
//        $('#BillingInformation').click(function() {
//            if (policyType.value == 'Y') {
//                history.back();
//            }
//        });
//        $('#Miscellaneous').click(function() {
//            if (policyType.value == 'Y') {
//                history.back();
//            }
//        });        
    </script>

</body>
</html>
