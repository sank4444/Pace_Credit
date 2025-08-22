<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    CodeBehind="ClaimDownload.aspx.cs" Inherits="PACE.Claims.ClaimDownload" Title="Claim Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ulDownLoad
        {
            line-height: 25px;
            background-color: #FFFFFF;
            list-style-image: url('../App_Themes/Theme/Images/New/Copy_of_arrow.png');
            list-style-position: inside;
            z-index: -1;
            line-height: 20px;
            background-color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table border="0" cellspacing="5" cellpadding="5" width="100%">
        <tr>
            <th class="strip-title" valign="top">
                Download
            </th>
        </tr>
        <tr>
            <td>
                <h3>
                    Claim Forms</h3>
                <ul class="ulDownLoad">
                    <li><a style="text-decoration: underline; color: #646463;" target="_blank" href="../ClaimDocuments/EDLI_Claim_form.pdf"
                        title="click to download EDLI Claim form">EDLI Claim form</a></li>
                    <li><a href="../ClaimDocuments/Gratuity_Claim_Form.pdf" target="_blank" style="text-decoration: underline;
                        color: #646463;" title="click to download Gratuity Claim Form">Gratuity Claim Form</a></li>
                    <li><a href="../ClaimDocuments/GTL_Claim_form.pdf" target="_blank" style="text-decoration: underline;
                        color: #646463;" title="click to download GTL Claim form">GTL Claim form</a></li>
                </ul>
                <h3>
                    Requirements</h3>
                <ul class="ulDownLoad">
                    <li><a href="../ClaimDocuments/EDLI_Claim_requirements.pdf" target="_blank" style="text-decoration: underline;
                        color: #646463;" title="click to download EDLI Claim requirements">EDLI Claim requirements</a></li>
                    <li><a href="../ClaimDocuments/GTL_Claims_requirements.pdf" title="click to download GTL Claims requirements"
                        target="_blank" style="color: #646463; text-decoration: underline;">GTL Claims requirements</a></li>
                    <li><a href="../ClaimDocuments/Pension_claim_requirements.pdf" title="click to download Pension claim requirements"
                        target="_blank" style="color: #646463; text-decoration: underline;">Pension claim
                        requirements</a></li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Content>
