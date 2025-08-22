<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="SubmissionScreen_cr.aspx.cs" Inherits="PACE.CreditLifeInformation.SubmissionScreen_cr"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <%--<asp:View ID="ExcelUploadedData" runat="server">--%>
    <table cellspacing="0" style="width: 100%;">
        <tr>
            <td>
                <asp:LinkButton ID="OnLnkUpload" runat="server" OnClick="OnLnkUpload_Click" Style="background-color: Navy;
                    font-size: x-large" Font-Underline="False">Upload</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="OnLnkDownload" runat="server" OnClick="OnLnkDownload_Click" Style="background-color: Navy;
                    font-size: x-large" Font-Underline="False">Download</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="color: Red">
                <asp:Label ID="lblFilename" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="fileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server">
                    <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                        NextPageText="Next" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <%-- </asp:View>--%>
</asp:Content>
