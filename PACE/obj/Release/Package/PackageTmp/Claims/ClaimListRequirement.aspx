<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    CodeBehind="ClaimListRequirement.aspx.cs" Inherits="PACE.Claims.ClaimListRequirement"
    Title="List of Claim Reuirement" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/Theme/StyleSheets/tata-aia.css" rel="stylesheet" type="text/css" />
<link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table border="0">
        <tr>
            <td>
                <div class="inner_container">
                    <h1 class="pink_ttl">
                        Death (all causes of death)</h1>
                    <div class="prod_cont">
                        <ul>
                            <li>Claim Forms <a target="_blank" href="../download-forms.html">(Download this form
                                in other Language)</a>
                                <ol>
                                    <li><a target="_blank" href="../pdf/claims/death-claim-form.pdf">Part I: Application
                                        Form for Death Claim (Claimant's Statement) along with NEFT form</a> </li>
                                    <li><a target="_blank" href="../pdf/claims/physician-statement.pdf">Part II: Physician's
                                        Statement - to be filled by last attending physician</a> </li>
                                </ol>
                            </li>
                            <li>Death Certificate issued by a local government body like Municipal Corporation /
                                Village Panchayat</li>
                            <li>Medical Records (Admission Notes, Discharge/Death Summary, Indoor Case Papers, Test
                                Reports etc) <sup>*</sup> </li>
                            <li>Original Policy document</li>
                            <li>Claimant's Photo ID with age proof & relationship with the Insured along with Address
                                proof of the claimant and Cancelled cheque with name and account number printed
                                or cancelled cheque with copy of Bank Passbook / Bank Statement</li>
                        </ul>
                        <strong>If no nomination - Proof of legal title to the claim proceeds (e.g. legal succession
                            paper).</strong>
                        <hr />
                        <strong>If Death due to Accident (to be submitted in addition to the above)</strong>
                        <ul>
                            <li>Postmortem report (Autopsy report) & Chemical Viscera report - if performed</li>
                            <li>All Police Papers – Panchnama, Inquest, First Information Report (FIR) and Final
                                Investigation Report</li>
                            <li>Newspaper cutting / Photographs of the accident - if available</li>
                        </ul>
                        <hr />
                        <strong>Please Note:</strong>
                        <ul>
                            <li>Please submit copies of the following documents certified / attested by the issuing
                                authority. ( Original Seen Verified (OSV) by Branch Personnel will also be accepted)
                                -
                                <ol>
                                    <li>All Police papers – Panchnama, Inquest, First Information Report and Final Investigation
                                        Report</li>
                                    <li>Medical Records (Admission Notes, Discharge/Death Summary, Indoor Case Papers, Test
                                        Reports etc) <sup>*</sup> </li>
                                    <li>Postmortem report (Autopsy report) & Chemical Viscera report (certified by Police
                                        / Magistrate / Court will also be accepted)</li>
                                </ol>
                            </li>
                            <li>Copies of the other documents to be submitted by self attestation of the claimant</li>
                            <li>In case the claim warrants any additional requirement, TALIC reserves the right
                                to call for the same.</li>
                            <li>Notification of claim & submission of the claim requirements does not mean admission
                                of the claim liability by the Company.</li>
                            <li>No agent is authorized to admit any liabilities on behalf of the Company, nor to
                                alter this list of documents or any claims requirements called for by the Company.</li>
                        </ul>
                        <p>
                            <sup>*</sup> This is applicable if insured was in hospital at the time of death
                            or any time prior to the date of death.
                        </p>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
