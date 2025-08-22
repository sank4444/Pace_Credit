<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    CodeBehind="COpyPolicySubOfficeAccess.aspx.cs" Inherits="PACE.PolicyInformation.COpyPolicySubOfficeAccess"
    Title="Policy Sub Office Access" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            $('.display').DataTable();
            //  $('#<%=gvPolAccess.ClientID %>').DataTable();
        });
    </script>

    <style>
        div.container
        {
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" >
        <tr>
            <th class="strip-title" valign="top">
                Sub Office Access
            </th>
        </tr>
        <tr>
            <td>
                <div>
                  <%--  <asp:GridView ID="gvPolAccess" runat="server" CssClass="display " OnRowCommand="gvPolAccess_RowCommand"
                        OnPreRender="gvPolAccess_PreRender">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <Columns>
                            <asp:BoundField DataField="UserClientUnitUID" HeaderText="ServicingRequestUID" Visible="false" />
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelectPolicy" runat="server" Text="Select" CommandName="Select"
                                        ToolTip="Select Policy" CommandArgument='<%#Eval("UserClientUnitUID")%>'></asp:LinkButton>
                                    <asp:HiddenField ID="hndSelectedFlag" runat="server" Value='<%#Eval("SelectedFlag")%>' />
                                    <asp:HiddenField ID="hndPolSubStatusName" runat="server" Value='<%#Eval("PolSubStatusName")%>' />
                                    <asp:HiddenField ID="hndDisplayMessage" runat="server" Value='<%#Eval("DisplayMessage")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClientCode" HeaderText="Client Code" HeaderStyle-Width="10%" />
                            <asp:BoundField DataField="ClientName" HeaderText="Client Name" HeaderStyle-Width="35%" />
                            <asp:BoundField DataField="ClientUnitCode" HeaderText="Sub Office Code" HeaderStyle-Width="15%" />
                            <asp:BoundField DataField="ClientUnitName" HeaderText="Sub Office Name" HeaderStyle-Width="30%" />
                            <asp:BoundField DataField="PolicyNumber" HeaderText="Policy No" HeaderStyle-Width="15%" />
                        </Columns>
                    </asp:GridView>--%>
                </div>
                <asp:GridView ID="gvPolAccess" runat="server" AllowPaging="True" autogeneratecolumn="false"
                    EmptyDataText="No record found" GridLines="None" Width="100%" AutoGenerateColumns="False"
                    PageSize="5" OnRowCommand="gvPolAccess_RowCommand" OnPreRender="gvPolAccess_PreRender"
                    OnPageIndexChanging="gvPolAccess_PageIndexChanging">
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                        PageButtonCount="3" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="UserClientUnitUID" HeaderText="ServicingRequestUID" Visible="false" />
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelectPolicy" runat="server" Text="Select" CommandName="Select"
                                    ToolTip="Select Policy" CommandArgument='<%#Eval("UserClientUnitUID")%>'></asp:LinkButton>
                                <asp:HiddenField ID="hndSelectedFlag" runat="server" Value='<%#Eval("SelectedFlag")%>' />
                                <asp:HiddenField ID="hndPolSubStatusName" runat="server" Value='<%#Eval("PolSubStatusName")%>' />
                                <asp:HiddenField ID="hndDisplayMessage" runat="server" Value='<%#Eval("DisplayMessage")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ClientCode" HeaderText="Client Code" HeaderStyle-Width="10%" />
                        <asp:BoundField DataField="ClientName" HeaderText="Client Name" HeaderStyle-Width="35%" />
                        <asp:BoundField DataField="ClientUnitCode" HeaderText="Sub Office Code" HeaderStyle-Width="15%" />
                        <asp:BoundField DataField="ClientUnitName" HeaderText="Sub Office Name" HeaderStyle-Width="30%" />
                        <asp:BoundField DataField="PolicyNumber" HeaderText="Policy No" HeaderStyle-Width="15%" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
