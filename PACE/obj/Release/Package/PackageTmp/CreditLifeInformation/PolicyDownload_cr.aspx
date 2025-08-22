<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicyDownload_cr.aspx.cs" 
MasterPageFile="~/Masters/MenuMasterPage_Cr.master" Inherits="PACE.CreditLifeInformation.PolicyDownload_cr" %>

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
                    <li><a id="PremiumRates" style="text-decoration: underline; color: #646463;" href="javascript:WindowOpen('PremiumRates_cr.aspx');"
                        title="click to download Premium Rates Credit Life" shape="circle">Premium Rates Credit Life </a></li>
                    
                    <li><a id="NEL" href="javascript:WindowOpen('NEL_cr.aspx');" style="text-decoration: underline;
                        color: #646463;" title="click to download medical non medical Credit Life ">Non Medical Limit (NML)</a></li>
                        
              <%--       <li><a id="A1" href="../Services_cr/BullMemberUpload.aspx" style="text-decoration: underline;
                        color: #646463;" title="click to upload COI">COI Upload</a></li>--%>
                        
                         <%--<li>
                         <a id="A2" href="../PACE/Services_cr/BullMemberUpload.aspx"  style="text-decoration: underline;
                        color: #646463;" title="click to download COI" >COI Download </a>
                        </li>--%>
                        <%--<li><a id="A2" href="../PACE/MemberInformation_cr/AllMember.aspx " style="text-decoration: underline;
                        color: #646463;" title="click to download COI" >COI Download</a></li>--%>
                        
                        <li>
                         <a id="A21" href="../MemberInformation_cr/AllMember.aspx"  style="text-decoration: underline;
                        color: #646463;" title="click to download COI" >COI Download </a>
                        </li>
                        
                </ul>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        function winopen(pagename) {
            window.open(pageName, '_blank', 'width=960,height=600, scrollbars=yes,resizable=yes');
        }</script>

</asp:Content>