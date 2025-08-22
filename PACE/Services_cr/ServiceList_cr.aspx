<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/MenuMasterPage_Cr.master"
    CodeBehind="ServiceList_cr.aspx.cs" Inherits="PACE.Services_cr.ServiceList_cr" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table border="0" cellpadding="5" cellspacing="5" style="width: 100%">
        <tr>
            <th class="strip-title" valign="top" colspan="4">
                Service List Credit Life
            </th>
        </tr>
        <tr id="trServiceList">
            <td   colspan="4" width="100%">
            <div id="div1" style="width: 800px;  border: 0px black solid;">
                <table  border="0" cellpadding="0" cellspacing="0" width="75%">
                    <tr>
                        <td id="tdSRNo" runat="server" style="width: 30%;">
                            Service Rquest No
                        </td>
                        <td style="width: 40%;">
                            <asp:TextBox ID="txtServiceList" runat="server" CssClass="inputbg3"></asp:TextBox><asp:RegularExpressionValidator
                                Enabled="false" ID="REGNumber" ValidationExpression="^[0-9]+$" SetFocusOnError="true"
                                ControlToValidate="txtServiceList" runat="server" ForeColor="Red" ErrorMessage="enter valid mobile numbers"></asp:RegularExpressionValidator>
                        </td>
                        <td style="text-align: left;width: 15%;">
                            <asp:ImageButton ID="imgSearchServ" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png"
                                OnClick="imgSearchServ_Click" />
                        </td>
                    </tr>
                </table>
                </div>
            </td>
            <td>
            </td>
        </tr>
        <tr id="trExcel" runat="server" visible="false">
            <td colspan="4" style="text-align: right; width: 920px;">
                <asp:ImageButton ID="imgExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                    Visible="true" Width="50px" Height="50px" AlternateText="Export" ToolTip="Export To Excel"
                    OnClick="imgExportToExcel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="width: 100%;">
                <div style="width:99%; overflow: scroll; overflow-x: scroll;">
                    <asp:UpdatePanel ID="UPInsured" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvServiceList" runat="server" AllowPaging="True" AutoGenerateColumns="true"
                                HeaderStyle-Wrap="false" RowStyle-Wrap="false" PageSize="5" EmptyDataText="No record found"
                                GridLines="None" Width="100%" OnPageIndexChanging="gvServiceList_PageIndexChanging">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    PageButtonCount="3" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgHistory" runat="server" ToolTip="History details" ImageUrl="~/App_Themes/Theme/Images/View.png"
                                                OnClientClick='<%# String.Format("javascript:return openWindow(\"{0}\")", Eval("SR No").ToString()) %>'
                                                CssClass="view_button" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="imgExportToExcel" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        function openWindow(SRNO) {
            window.open('CallCenterDetails_cr.aspx?SRNo=' + SRNO, 'popWindow', 'toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=1,width=920,height=540,left = 90,top = 90');
        }
    </script>

</asp:Content>
