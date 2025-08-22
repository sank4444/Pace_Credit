<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="SurrenderCalculation.aspx.cs" Inherits="PACE.CreditLifeInformation.SurrenderCalculation"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

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
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:UpdatePanel ID="UPInsured" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" runat="server" cellspacing="0" style="font-size: 12px !important;"
                width="100%">
                <tr>
                    <td class="strip-title" colspan="4" valign="top">
                        Surrender Calculation
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="width: 100%;">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="style1" style="text-align: left; width: 15%;">
                                    <p style="height: 30px">
                                        Policy
                                    </p>
                                </td>
                                <td class="style1" style="text-align: left; width: 15%;">
                                    <asp:DropDownList ID="ddlPolicy" runat="server" CssClass="styled-select1">
                                    </asp:DropDownList>
                                </td>
                                <td style="ext-align: left; width: 5%;">
                                </td>
                                <td class="style1" style="text-align: left; width: 15%;">
                                    <p style="height: 30px">
                                    </p>
                                </td>
                                <td style="width: 35%;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 35px;" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="width: 100%;">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="style1" style="text-align: left; width: 15%;">
                                    <p style="height: 30px">
                                        COI
                                    </p>
                                </td>
                                <td class="style1" style="text-align: left; width: 15%;">
                                    <asp:TextBox ID="txtCOI" runat="server" CssClass="inputbg1">
                                    </asp:TextBox>
                                </td>
                                <td style="ext-align: left; width: 5%;">
                                </td>
                                <td class="style1" style="text-align: left; width: 15%;">
                                    <p style="height: 30px">
                                        As On Date
                                    </p>
                                </td>
                                <td style="width: 35%;">
                                    <asp:TextBox ID="txtasondate" Enabled="false" runat="server" CssClass="inputbg1">
                                    </asp:TextBox>
                                    <asp:ImageButton ID="imgPeriodFrom" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                        ImageAlign="Middle" Height="20px" Width="20px" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtasondate"
                                        PopupButtonID="imgPeriodFrom">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 35px;" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; width: 100%; line-height: 30px;">
                        <div id="div1" style="width: 999px; border: 0px black solid;">
                            <asp:ImageButton ID="btnSearch" runat="server" ToolTip="Search" OnClick="btnSearch_Click"
                                Text="Search" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px;" colspan="4">
                    </td>
                </tr>
                <tr id="trExcel" runat="server" visible="false">
                    <td colspan="4" style="text-align: right;">
                        <asp:ImageButton ID="imgExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                            Width="50px" Height="50px" AlternateText="Export" ToolTip="Export To Excel" OnClick="imgExportToExcel_Click" />
                    </td>
                </tr>
                <tr>
                    <td id="tdGrid" visible="true" runat="server" colspan="4">
                        <div id="div" style="width: 999px; overflow-x: scroll; overflow-y: scroll; border: 0px black solid;">
                            <asp:GridView runat="server" ID="gvSurrCal" AutoGenerateColumns="False" GridLines="Both"
                                Width="100%" PageSize="5" EmptyDataText="No record found" Visible="true" AllowPaging="True"
                                OnPageIndexChanging="gvSurrCal_PageIndexChanging">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <Columns>
                                    <asp:BoundField DataField="MemberName" HeaderText="Member Name" />
                                    <asp:BoundField DataField="COI" HeaderText="COI" />
                                    <asp:BoundField DataField="GrossPremium" HeaderText="GrossPremium" />
                                    <asp:BoundField DataField="UnexpiredPolicyTerm" HeaderText="UnexpiredPolicyTerm" />
                                    <asp:BoundField DataField="TotalPolicyTerm" HeaderText="TotalPolicyTerm" />
                                    <asp:BoundField DataField="SurenderAmount" HeaderText="SurenderAmount" />
                                    <asp:BoundField DataField="SumInsuredAtTheTimeofSurrender" HeaderText="SumInsuredAtTheTimeofSurrender" />
                                    <asp:BoundField DataField="SumInsuredAtInception" HeaderText="SumInsuredAtInception" />
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblResult" runat="server" Visible="false" Text="No Record Found" ForeColor="red">
                            </asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td id="SurrenderDoc" visible="true" runat="server" colspan="4">
                        <div style="padding-left: 10px;">
                            <ui><h3><b>Surrender list of documents.</b></h3>
                    <li>NOC/ Foreclosure letter issued by Policyholder.</li>
                    <li>Certificate of Insurance.</li>
                    <li>Duly signed letter from your end to cancel the policy mentioning policy no, certificate no OR Loan no.</li>
                    <li>Personalized Cancelled Cheque.</li>
                    <li>Self-Attested copy of Aadhar and Pan Card.</li>
                    </ui>
                            <ui><h3><b><asp:Label ID="lblFormulaName" runat="server" Text=""></asp:Label></b></h3>
                    <asp:Label ID="lblFormula" runat="server" Text=""></asp:Label>
                    </ui>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
