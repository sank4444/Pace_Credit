<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    Inherits="ContactInformation_CntactInformation" Title="Contact Information" CodeBehind="ContactInformation.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">

        function popUp(ClientUnitUID) {

            strOpen = "popupContactinfo.aspx?" + ClientUnitUID;
            window.open(strOpen, 'popWindow', 'toolbar=0,scrollbars=0,location=0,statusbar=0,addressbar=0,menubar=0,resizable=0,maximize=0,width=960,height=600,left = 90,top = 90');
            __doPostBack('', '');
        }

       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <th class="strip-title" valign="top">
                    Client Contact Information
                </th>
            </tr>
            <tr>
                <td style="width: 1000px">
                    <asp:GridView runat="server" ID="gvContactInfo" Width="100%" AutoGenerateColumns="False"
                        PageSize="5" AllowPaging="true" GridLines="None" CssClass="GridBackStyle" OnPageIndexChanging="gvContactInfo_PageIndexChanging">
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
                                    <asp:ImageButton ID="lnkEdit" runat="server" CausesValidation="False" Text="Edit"
                                        Height="30" Width="33" ImageUrl="~/App_Themes/Theme/Images/View.png" OnClientClick='<%# Eval("ClientUnitUID","javascript: return popUp({0})") %>'
                                        ForeColor="Black"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClientUnitCode" HeaderText="Sub Office Code" HeaderStyle-Width="30%" />
                            <asp:BoundField DataField="ClientUnitName" HeaderText="Sub Office Name" HeaderStyle-Width="60%" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
