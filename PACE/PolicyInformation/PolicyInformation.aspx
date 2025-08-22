<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    Inherits="PolicyInformation" Title="Policy Information" CodeBehind="PolicyInformation.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>

    <style type="text/css">
        .label
        {
            background-position: 14% left;
        }
        #lblERRFor
        {
            padding-left: 10px;
        }
        .style1
        {
            width: 188px;
        }
        .style2
        {
            width: 3%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div id="content_1" class="content">
        <table border="0" cellpadding="0" cellspacing="0" style="font-size: 12px !important;"
            width="98%">
            <tr>
                <th class="strip-title" colspan="2" valign="top">
                    Policy Enquiry
                </th>
            </tr>
            <tr>
                <td valign="top" align="left" width="80%">
                    <table border="0" cellpadding="0" cellspacing="5">
                        <tr>
                            <td style="text-align: left;" valign="top" class="style1">
                                <p style="height: 30px">
                                    Policy No</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td style="width: 70%;">
                                <asp:Label ID="lblPolicyNo" Width="90%" runat="server" CssClass="label">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="rc" runat="server" BorderColor="#b3b3b3" Radius="10"
                                    Corners="All" TargetControlID="lblPolicyNo">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Client</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblClient" Width="90%" runat="server">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblClient">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Sub Office Code</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td height="34px">
                                <asp:Label ID="lblSubOfficeCode" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender20" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblSubOfficeCode">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Sub Office Name</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td height="34px">
                                <asp:Label ID="lblPlan" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblPlan">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Sub Policy Status</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblPolicyStaus" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblPolicyStaus">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Inception Date</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblInceptionDate" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblInceptionDate">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Anniversary Date</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblAnniversaryDate" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblAnniversaryDate">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Min Entry Age</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblminEntryAge" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender6" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblminEntryAge">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Max Entry Age</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblMaxEntryAge" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender7" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblMaxEntryAge">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    ERR Formula</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblERRFor" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender10" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblERRFor">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Product Name</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblProducName" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender11" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblProducName">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Product UIN No</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblProductUINNo" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender12" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblProductUINNo">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Service Manager Name</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblServiceManager" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender13" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblServiceManager">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Agent / Broker</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblAB" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender15" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblAB">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Mode of policy</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblModeofPolicy" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender16" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblModeofPolicy">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Policy Year</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblPolicyYear" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender17" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblPolicyYear">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style1">
                                <p style="height: 30px">
                                    Active Members</p>
                            </td>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:Label ID="lblNumberofmembercovered" runat="server" Width="90%">&nbsp;</asp:Label>
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender18" runat="server" BorderColor="#b3b3b3"
                                    Radius="10" Corners="All" TargetControlID="lblNumberofmembercovered">
                                </cc1:RoundedCornersExtender>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">        !window.jQuery && document.write(unescape('%3Cscript src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"%3E%3C/script%3E'))</script>

    <script src="../App_Themes/Theme/StyleSheets/jquery.mCustomScrollbar.concat.min.js"
        type="text/javascript"></script>

    <script type="text/javascript">

        (function($) {
            $(window).load(function() {
                $("#content_1").mCustomScrollbar({
                    scrollButtons: {
                        enable: true
                    }
                });
            });
        })(jQuery);
    </script>

</asp:Content>
