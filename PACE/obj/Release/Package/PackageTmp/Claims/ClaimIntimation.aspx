<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    CodeBehind="ClaimIntimation.aspx.cs" Inherits="PACE.Claims.ClaimIntimation" Title="Online Claim Intimation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>
     <script src="../Scripts/JScript2.js" type="text/javascript"></script>


    <script type="text/javascript">
        $(document).ready(function() {
            function openPopUpService(coi, serviceReq, categor) {
                window.open("../../Services/PopUpCommonSearch.aspx?COI=" + coi.ToString().Trim() + "&DDLFirst=" + serviceReq.ToString().Trim() + "&DDlSecond=" + categor.ToString().Trim() + "', '_blank', 'width=960,height=600, scrollbars=yes,resizable=yes,maximize=yes')", true)
            }
        });     //Ready
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table border="0" cellpadding="5" cellspacing="5" style="width: 98%">
        <tr>
            <th class="strip-title" valign="top" colspan="3">
                Claim Intimation
            </th>
        </tr>
        <tr>
            <td style="width: 31%">
                Category <span class="span">*</span>
            </td>
            <td style="padding-left: 0px;">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="styled-select" Enabled="false">
                </asp:DropDownList>
            </td>
            <td>
                <div id="Category" style="display: none;">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table width="100%">
                    <tr>
                        <td style="width: 30%">
                            Certificate of Insurance (COI)
                        </td>
                        <td>
                            <asp:TextBox ID="txtCOI" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">
                            Name of Insured member <span class="span">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInsuredMember" runat="server" CssClass="inputbg" Enabled="false"></asp:TextBox>
                            <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/App_Themes/Theme/Images/icon_4.png"
                                Width="30px" Height="25px" OnClick="imgSearch_Click" />
                            <div id="InsuredMember">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date of Death
                        </td>
                        <td>
                            <asp:TextBox ID="txtDtofDeath" runat="server" CssClass="inputbg"></asp:TextBox>
                            <asp:Image ID="imgDtofDeath" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                Height="20px" Width="20px" ImageAlign="Middle" />
                            <ajaxToolkit:CalendarExtender ID="CEIntimation" runat="server" Format="MM/dd/yyyy"
                                Animated="true" TargetControlID="txtDtofDeath" PopupButtonID="imgDtofDeath">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Cause of Death
                        </td>
                        <td>
                            <asp:TextBox ID="txtCauseDeath" runat="server" CssClass="inputbg"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%-- TTSL Change
                    Added by Karunakar on 28-04-2016 START--%>
        <tr id="trTTSL" runat="server" visible="false">
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td style="width: 30%">
                            Name of caller<span class="span">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNameCaler" runat="server" CssClass="inputbg"></asp:TextBox>
                            <div id="Namecaler">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">
                            Mobile number of caller<span class="span">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobileCler" runat="server" CssClass="inputbg" MaxLength="13" CausesValidation="true"></asp:TextBox>
                            <div id="MobileCler">
                            </div>
                            <asp:RegularExpressionValidator ID="REVMobileNoValidation" ControlToValidate="txtMobileCler"
                                ValidationExpression="[0-9]{10}" Display="Dynamic" runat="server" ErrorMessage="Invalid mobile number!"
                                BackColor="Red" Font-Bold="true" ForeColor="White"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">
                            Relationship of caller with insured<span class="span">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRelcalInsured" runat="server" CssClass="inputbg"></asp:TextBox>
                            <div id="RelcalInsured">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address<span class="span">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="inputbg"></asp:TextBox>
                            <div id="Address">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--END--%>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UPFileUpload" runat="server">
                    <ContentTemplate>
                        <table width="92%" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td style="width: 34%">
                                    Upload claim documents<br />
                                    (.pdf only upto 3MB)
                                </td>
                                <td>
                                    <asp:FileUpload ID="fuServiceRequest" runat="server" BorderColor="LightGray" BorderStyle="Groove"
                                        BorderWidth="3px" />
                                    <div id="fuUpload" style="display: none;">
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="imgSaveService" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:ImageButton ID="imgSaveService" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Save.png"
                    OnClick="imgSaveService_Click" OnClientClick="return ClaimIntimationValidation();" />
                <asp:HiddenField ID="hndCofirm" runat="server" Value="return javascript:Confirm(this);" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span class="span">* </span>Note: Notifications of claim, submission of claim forms
                and/or claim documents to the Company shall not be construed as an admission of
                liabilities of the Company.
            </td>
        </tr>
    </table>
</asp:Content>
