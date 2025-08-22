<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    Inherits="MemberInformation_MemberInformation" Title="Member Information" CodeBehind="MemberInformation.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <th class="strip-title" colspan="4" valign="top">
                Member Enquiry
            </th>
        </tr>
        <tr>
            <td style="width: 100%;">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 15%;">
                            Name
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtName" runat="server" CssClass="inputbg">
                            </asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            Certificate No.
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtCoiNo" runat="server" CssClass="inputbg">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="divName" style="display: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search_button"
                                TabIndex="0" ToolTip="Search" OnClientClick="return Validation()" Height="29px"
                                Width="100%" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Style="width: 10px;" ID="lbl" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td id="tdGrid" visible="false" runat="server">
                <div style="overflow-x: auto; width: 100%;">
                    <asp:GridView ID="gvMembeInfo" runat="server" AllowPaging="True" autogeneratecolumn="false"
                        PageSize="5" GridLines="None" Width="100%" AutoGenerateColumns="False" OnPageIndexChanging="gvMembeInfo_PageIndexChanging"
                        PagerSettings-Mode="NumericFirstLast" OnRowCommand="gvMembeInfo_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                            PageButtonCount="3" />
                        <Columns>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkView" runat="server" CausesValidation="False" CommandName="View"
                                        Height="35px" Width="35px" ImageUrl="~/App_Themes/Theme/Images/View.png" ToolTip="Click to view member information details"
                                        OnClientClick='<%# Eval("PolicyMemberUID","javascript: return popUp({0})") %>'
                                        CommandArgument='<% #Eval("PolicyMemberUID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EmployeeNo" HeaderText="Employee No" />
                            <asp:BoundField DataField="InsuredName" HeaderText="Insured Name" />
                            <asp:BoundField DataField="COI" HeaderText="COI No" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="PolicyYear" HeaderText="Policy Year" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblResult" runat="server" Visible="false" Text="No Record Found" ForeColor="red">
                    </asp:Label>
                </div>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">

        function popUp(PolicyMemberUID) {
            strOpen = "MemberInfoDetails.aspx?PolicyMemberUID=" + PolicyMemberUID;
            window.open(strOpen, 'popWindow', 'toolbar=0,titlebar=0,scrollbars=1,location=0,statusbar=0,status=1,fullscreen=0,menubar=0,resizable=1,width=920px,height=600px,left = 200,top = 100');
            __doPostBack('', '');
        }

        function Validation() {
            var NAME = $('#<%=txtName.ClientID %>').val();
            var COINO = $('#<%=txtCoiNo.ClientID %>').val();
            if (NAME == "" && COINO == "") {
                $('#divName').css('display', 'inline');
                $('#divName').html('<span id="DisplayingError" class="DisplayingError">Name and COI No can\'t be Empty </span>');
                $('#<%=txtName.ClientID %>').focus();
                $('#DisplayingError').click(function() { $('#<%=txtName.ClientID %>').focus(); });
                return false;
            }
            else {
                return true;
            }
        }
    </script>

</asp:Content>
