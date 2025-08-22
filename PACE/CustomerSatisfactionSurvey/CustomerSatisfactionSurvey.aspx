<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    Inherits="CustomerSatisfactionSurvey_CustomerSatisfactionSurvey" Title="Customer Satisfaction"
    CodeBehind="~/CustomerSatisfactionSurvey/CustomerSatisfactionSurvey.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <th class="strip-title" valign="top" colspan="2">
                    Customer Feedback
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    <p>
                        Please rate the below questions on a scale of 1 to 10, where 10 stands for extremely
                        satisfied and 1 stands for extremely dissatisfied.</p>
                </td>
            </tr>
            <tr>
                <td width="2%">
                    <asp:Label ID="lblId1" runat="server"></asp:Label>.
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="lblQuestion1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table width="80%">
                        <tr>
                            <td align="left">
                                Extremely dissatisfied
                            </td>
                            <td align="right">
                                Extremely satisfied
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; padding-left: 30px;" colspan="2">
                    <asp:RadioButtonList ID="rbtAnswer1" runat="server" CellPadding="0" CellSpacing="0"
                        RepeatDirection="Horizontal" TabIndex="1" Width="80%">
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="30px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblId2" runat="server"></asp:Label>.
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="lblQuestion2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table width="80%">
                        <tr>
                            <td align="left">
                                Extremely dissatisfied
                            </td>
                            <td align="right">
                                Extremely satisfied
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; padding-left: 30px;" colspan="2">
                    <asp:RadioButtonList ID="rbtAnswer2" runat="server" CellPadding="0" CellSpacing="0"
                        RepeatDirection="Horizontal" TabIndex="1" Width="80%">
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p>
                        We care about your opinion. If you have any suggestions regarding our services,
                        please share the same with us</p>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table width="100%">
                        <tr>
                            <td width="20%">
                                Description
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" Width="75%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="2">
                    <asp:ImageButton ID="btnSubmit" runat="server" CssClass="sumbmint_btn" ToolTip="Submit Answers"
                        ImageUrl="~/App_Themes/Theme/Images/btn_Submit.png" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
