<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    CodeBehind="OnlineClaimTracking.aspx.cs" Inherits="PACE.Claims.OnlineClaimTracking"
    Title="Online Claim Tracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table border="0" cellpadding="5" cellspacing="5" style="width: 98%">
        <tr>
            <th class="strip-title" valign="top" colspan="3">
                Claim Status Enquiry
            </th>
        </tr>
        <tr id="trServiceList">
            <td colspan="0">
                <table border="0" width="100%">
                    <tr>
                        <td style="width: 30%;">
                            Service Request No./ Name of Employee
                        </td>
                        <td style="width: 20%;">
                            <asp:TextBox ID="txtServiceList" runat="server" CssClass="inputbg"></asp:TextBox>
                        </td>
                        <td style="text-align: left;">
                            <asp:ImageButton ID="imgSearchServ" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png"
                                OnClick="imgSearchServ_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="0" style="width: 100%;">
                <div style="width: 920px; overflow: scroll;">
                    <asp:GridView ID="gvServiceList" runat="server" AllowPaging="True" autogeneratecolumn="true" DataKeyNames="SR No" 
                        RowStyle-Wrap="false" AlternatingRowStyle-Wrap="false" PageSize="5" EmptyDataText="No record found"
                        GridLines="None" Width="100%" OnPageIndexChanging="gvServiceList_PageIndexChanging"
                        OnRowCommand="gvServiceList_RowCommand">
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                            PageButtonCount="3" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <Columns>
                            <asp:TemplateField ItemStyle-Wrap="true">
                                <ItemTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSelect" runat="server" ToolTip="Send Mail" CommandName="s"
                                                 CssClass="select_button" />
                                            
                                            <asp:FileUpload ID="FU" runat="server" Width="160px" />
                                            <asp:Label ID="lblSRNo" runat="server" Text='<%#Eval("SR No") %>' Visible="false" ></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSelect" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
