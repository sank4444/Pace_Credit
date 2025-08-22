<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    CodeBehind="PolicyDownload.aspx.cs" Inherits="PACE.PolicyInformation.PolicyDownload"
    Title="Policy Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="../App_Themes/Theme/StyleSheets/gw_style.css" />
    <style type="text/css">
        .ulDownLoad
        {
            line-height: 25px;
            background-color: #FFFFFF;
            list-style-image: url( '../App_Themes/Theme/Images/New/Copy_of_arrow.png' );
            list-style-position: inside;
            z-index: -1;
            line-height: 20px;
            background-color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table id="thDownload" border="0" cellspacing="5" cellpadding="5" width="100%" style="color: White;
        border: #ffffff;">
        <tr>
            <th class="strip-title" valign="top">
                Download
            </th>
        </tr>
        <tr>
            <td style="text-decoration: inline-through; color: Black;">
                <ul class="ulDownLoad">
                    <li><a id="PremiumRates" style="text-decoration: underline; color: #646463;" href="javascript:WindowOpen('PremiumRates.aspx');"
                        title="click to download Premium Rates" shape="circle">Premium Rates </a></li>
                    <li><a id="NEL" href="javascript:WindowOpen('NEL.aspx');" style="text-decoration: underline;
                        color: #646463;" title="click to download medical non medical ">No Evidence Limit
                        (NEL)</a></li>
                    <li><a id="BenifitBasis" href="javascript:WindowOpen('BenifitBasis.aspx');" style="text-decoration: underline;
                        color: #646463;" title="click to download benifits basis">Benefit Basis</a></li>
                    <li><a id="PremiumStatement" href="javascript:WindowOpen('PremiumStatement.aspx');"
                        style="text-decoration: underline; color: #646463;" title="click to download Premium statement">
                        Premium Statement</a></li>
                    <li><a id="MemberListing" href="javascript:WindowOpen('MemberListing.aspx');" title="click to download Member listing"
                        style="color: #646463; text-decoration: underline;">Member Listing</a></li>
                    <%--<li><a  title="click to download User Documents" href="javascript:WindowOpen('../ClaimDocuments/EDLI_Claim_form.pdf');" 
                        style="color: #646463; text-decoration: underline;">User Documents</a></li>--%>
                    <%--href="../DownloadFormate/PACE_POS_Add_Member.xls"--%>
                    <li><a id="UserManual" href="javascript:winopen('../ClaimDocuments/Vendor_TALIC_Group Life_Portal_PACE_User_Manual-Vr.1_PS_Final.pdf')"
                        title="click to download User Manual" style="color: #646463; text-decoration: underline;">
                        User Manual</a><asp:Image ID="ImgNew" ImageUrl="../App_Themes/Theme/Images/new_animated.gif"
                            runat="server" /></li>
                    <%--href="javascript:WindowOpen('../../ClaimDocuments/Vendor_TALIC_Group Life_Portal_PACE_User_Manual-Vr.1_PS_Final.pdf')"--%>
                    <li><a id="a1" href="javascript:WindowOpen('Archival.aspx');" title="click to download archival documents"
                        style="color: #646463; text-decoration: underline;">Archival</a><asp:Image ID="image1"
                            ImageUrl="../app_themes/theme/images/new_animated.gif" runat="server" /></li>
                </ul>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        function winopen(pagename) {
            window.open(pageName, '_blank', 'width=960,height=600, scrollbars=yes,resizable=yes');
        }</script>

</asp:Content>
