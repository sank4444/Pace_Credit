<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopUpCommonSearch.aspx.cs"
    Inherits="PACE.Services.PopUpCommonSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>COI Search</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table>
                    <tr>
                        <td style="width: 12%;">
                            Search value:
                        </td>
                        <td style="width: 20%;">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="inputbg"></asp:TextBox>
                        </td>
                        <td style="width: 12%;">
                            Search Item :
                        </td>
                        <td style="width: 30%; background-position: center;">
                            <asp:DropDownList ID="ddlSearch" runat="server" Width="250px">
                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="COI" Value="COI"></asp:ListItem>
                                <asp:ListItem Text="Employee Code" Value="EmpCode"></asp:ListItem>
                                <asp:ListItem Text="Name" Value="Name"></asp:ListItem>
                             <%--   <!--
                                ADDED BY KARUNAKAR ON 28-04-2016 START
                                -->--%>
                                <asp:ListItem Text="Mobile Number" Value="MobileNo"></asp:ListItem>
                            <%--    <!--END -->--%>
                            </asp:DropDownList>
                            &nbsp; &nbsp;
                            <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/App_Themes/Theme/Images/icon_4.png"
                                Width="35px" Height="35px" OnClick="imgSearch_Click" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GVpopupCOI" runat="server" AllowPaging="true" PageSize="8" OnPageIndexChanging="GVpopupCOI_PageIndexChanging"
                    Width="100%" AutoGenerateColumns="true" OnRowDataBound="gvrecords_RowDataBound">
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                        PageButtonCount="3" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="3%">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgSelect" runat="server" CausesValidation="false" AlternateText="Select"
                                    ToolTip="Please Select" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                    CommandName="select" ImageUrl="~/App_Themes/Theme/Images/ico_select.png" Width="30px"
                                    Height="30px" />
                                <asp:Label ID="lblCOI" runat="server" Text='<%#Eval("COI") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblInsuredName" runat="server" Text='<%#Eval("[Insured Name]") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
            <div class="UpdateProgressmodal">
                <div class="UpdateProgresscenter">
                    <asp:Label ID="labelDisplay" runat="server" Text="Processing..."></asp:Label>
                    <br />
                    <img id="progessImage" src="../App_Themes/Theme/Images/loading.gif" alt="" width="70" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>

    <script type="text/javascript">
        function closeWindow(PathSearchItem) {
            //window.opener.location.href = PathSearchItem;

            window.opener.location.href = "../claims/claimintimation.aspx?COI=" + PathSearchItem;
            window.close();   // Closes the new window

        }


    </script>

</body>
</html>
