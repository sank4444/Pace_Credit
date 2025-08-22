using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using GlimpsBAL;
using GlimpsDAL;
using PACE.Masters;
using System.Text;

namespace PACE.MemberInformation_cr
{
    public partial class MemberInfoDetails_cr : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        string PolicyID = string.Empty;
        //int COI_cr;
        int PolicyMemberUID = 0;
        string GeneratingPDFDynamically = ConfigurationManager.ConnectionStrings["GeneratingPDFDynamically"].ToString().Trim();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dsMemberDetails = new DataSet();
            DataSet dsMemberUWAlphaDetails = new DataSet();
            DataSet dsMemberUWRequirementDecisionDetails = new DataSet();
            DataSet dsviolation = new DataSet();
            //PolicyMemberUID
            try
            {
              
               PolicyMemberUID = Convert.ToInt32(Request.QueryString["PolicyMemberUID"].ToString());
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "MemberInfoDetails_cr.aspx");
                    MemberInfoBAL memberInfoBAL = new MemberInfoBAL();




                    Session["PolicyMemberUID"] = Convert.ToString(PolicyMemberUID);//Used session for Servicing History tab
                    ClearAll();
                    if (Session[CommonConstantNames.USERUID] != null)
                    {
                        UserUID = Session[CommonConstantNames.USERUID].ToString();
                        subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                        PolicyID = Session[CommonConstantNames.POLICYUID].ToString();

                        if (Session["IsTTSL"].ToString().ToUpper().Trim() == "Y")
                        {
                            TabPanel3.Visible = false;
                            TabPanel3.HeaderText = string.Empty;
                        }
                        else
                        {
                            TabPanel3.Visible = false;
                        }
                    }

                    else
                    {
                        Response.Write("<script>window.close();</" + "script>");
                        Response.End();

                        Response.Redirect("~/LoginPage.aspx", true);
                    }
                    int PolicyUID, RenewalNoUID, COI;
                    if (Session[CommonConstantNames.POLICYUID] != null) 
                    {
                        PolicyUID = Convert.ToInt32(Session[CommonConstantNames.POLICYUID]);
                        RenewalNoUID = Convert.ToInt32(Session[CommonConstantNames.RENEWALNOUID]);
                        COI = Convert.ToInt32(Session[CommonConstantNames.COI]);
                        dsMemberDetails = memberInfoBAL.GetMemberInfoPopUp_cr(Convert.ToInt32(UserUID), PolicyMemberUID, PolicyUID, RenewalNoUID);  //
                        //dsviolation
                        
                        dsviolation = memberInfoBAL.GetViolation_cr(PolicyMemberUID);
                        gvViolation.DataSource = dsviolation.Tables[0];
                        gvViolation.DataBind();


                        gvViolation_Occu.DataSource = dsviolation.Tables[1];
                        gvViolation.DataBind();


                        if (dsMemberDetails != null && dsMemberDetails.Tables[0].Rows.Count > 0)
                        {
                            COI = Convert.ToInt32(dsMemberDetails.Tables[0].Rows[0]["COI"]);
                            Session["COI_cr"] = Convert.ToInt32(dsMemberDetails.Tables[0].Rows[0]["COI"]);

                            dsMemberUWAlphaDetails = memberInfoBAL.GetMemberUnderwritingInfo_cr(Convert.ToInt32(UserUID), "", "UWAlphaDetails", COI, PolicyUID, RenewalNoUID);
                            gvPremiumDetail.DataSource = dsMemberUWAlphaDetails;
                            gvPremiumDetail.DataBind();
                            dsMemberUWRequirementDecisionDetails = memberInfoBAL.GetMemberUnderwritingInfo_cr(Convert.ToInt32(UserUID), "QC", "UWMemberList", COI, PolicyUID, RenewalNoUID);
                            gvMemReq.DataSource = dsMemberUWRequirementDecisionDetails;
                            gvMemReq.DataBind();
                        }
                    }

                    if (dsMemberDetails != null && dsMemberDetails.Tables[0].Rows.Count > 0)
                    {
                       
                        if (dsMemberDetails.Tables[0].Rows[0]["subStatusName"].ToString() == "Issued")
                        {
                            lnkCOIGeneration.Enabled = true;
                        }
                        else
                        {
                            lnkCOIGeneration.Enabled = false;
                        }
                        lblSourcingBranch.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["SourcingBranchName"]).Trim();
                        lblSrcBranchCode.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["SourcingBranchCode"]).Trim();
                        lblclmCode.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CLMCode"]).Trim();
                        lblclmName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CLMName"]).Trim();
                        lblClientName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientName"]).Trim();
                        lblPolicyNmbr.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PolicyNumber"]).Trim();
                        lblSubOffCode.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientUnitCode"]).Trim();
                        lblSuboffname.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientUnitName"]).Trim();
                        lblZone.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["RegionName"]).Trim();
                        lblCOINo.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["COI"]).Trim();
                        lblSourcBrnch.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientName"]).Trim();
                        lblSalesPer.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PolicyHolder_SalesPersonName"]).Trim();
                        lblRegion.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["RegionName"]).Trim();
                        lblProductname.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ProductName"]).Trim();
                        lblSumAssuredType.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CoverTypeName"]).Trim();
                        lblProInsTrm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ProposedInsuranceTerm"]).Trim();
                        lblBenefit.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Benefit_Coverage"]).Trim();
                        lblLoanTerm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Loan_Tenure"]).Trim();
                        lblloanAc.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Loan_Reference_No"]).Trim();
                        lblRateOfInterest.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Interest_Rate"]).Trim();
                        txtLoanEffDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["LoanEffectiveDt"]).Trim();
                        txtLonDisDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["LoanDisbursementDt"]).Trim();
                        lblOutstloanAmt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["LoanOutstandingAmt"]).Trim();
                        lblprososedloanAmt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["sumassured"]).Trim();//ProposedInsuranceTerm
                        lblmoratoPer.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Moratorium"]).Trim();
                        lblInsAmt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["SAInterestAmount"]).Trim();
                        lblPremiumMode.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PremiumModeCode"]).Trim();
                        lblPremiumType.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PremiumTypeCode"]).Trim();
                        lblCheqJournal.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Insured_ChequeJournalNo"]).Trim();
                        lblAmount.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Insured_ChequeAmounts"]).Trim();
                        lblPreAmtApp.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PremiumAmount"]).Trim();

                        lblCitrm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CriticalIllnessTenure"]).Trim();

                        lblDateSig.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Dtapplsignedproposedinsured"]).Trim();
                        lblplaceSigIns.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Placeapplsignedproposedinsured"]).Trim();
                        lbldateSigPoHol.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["DtApplsignedpolicyholder"]).Trim();
                        lblPlaSigpolHo.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Placeapplsignedpolicyholder"]).Trim();
                        lblPremiumFrequency.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PremiumFrequencyCode"]).Trim();
                        lblSegment.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["SegmentCode"]).Trim();
                        lblNoOfUnit.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["NoUnits"]).Trim();
                        lblApplicationType.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ApplicantType"]).Trim();
                        lblNumberOfApplicants.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["NoOfCoapplicant"]).Trim();
                        lblcovEffDate.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CoverageEffectiveDate"]).Trim();
                        lblCovTerDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CoverageTerminationDate"]).Trim();
                        lblpreDueDT.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PremiumDueDate"]).Trim();
                        lblGracePreDuDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["GracePremiumDueDate"]).Trim();
                        lblCoIssDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["COIIssuedDate"]).Trim();
                        lblMemTerDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["MemberTerminationDate"]).Trim();
                        lblpayDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PaidToDate"]).Trim();
                        lblMemEffDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["MemberEffectiveDate"]).Trim();
                        
                        
                        lblIntiDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["DateOfIntimation"]).Trim();
                        lblCstID.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CustomerID"]).Trim();
                        lblMemRefID.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PolicyMemberUID"]).Trim();
                        lblPriLoanAppName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Insured_PrimaryLoanAppName"]).Trim();
                        lblRelaPriLoanApp.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Insured_RelationshipLoanApplicant"]).Trim();
                        lblName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ProposedTitle"]).Trim();
                        FrtName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["FirstName"]).Trim();
                        lblMdlName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["MiddleName"]).Trim();
                        lbllstName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["LastName"]).Trim();
                        lbllndmark.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Landmark"]).Trim();
                        lblAddrs1.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Address1"]).Trim();
                        lblAddrs2.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Address2"]).Trim();
                        lblAddrs3.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Address3"]).Trim();
                        lblAddrs4.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Address4"]).Trim();
                        lblCountryofResidence.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CountryResidenceName"]).Trim();
                        lblState.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["StateName"]).Trim();
                        lblGender.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Gender"]).Trim();
                        lblcity.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CityName"]).Trim();
                        lblPincode.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Pincode"]).Trim();
                        lblLandline.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Phone"]).Trim();
                        lblMobile.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PhoneNo1"]).Trim();
                        lblemail.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Emailid"]).Trim();
                        lblDOB.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["DOB"]).Trim();
                        lblAge.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["InsuredAge"]).Trim();
                        lblNationality.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["NationalityName"]).Trim();
                        lblResiSts.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["CountryResidenceCode"]).Trim();
                        lblAnnIncome.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["AnnualIncome"]).Trim();
                        lblPanNumbr.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PANCardNo"]).Trim();
                        lblIdentityCardType.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["IdentityCardTypeCode"]).Trim();
                        lblIndentityCrdNo.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["IdentiyCardNumber"]).Trim();
                        lblHeight.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Height"]).Trim();
                        lblWeight.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Weight"]).Trim();
                        lblPhysicianName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["FamilyPhysicianTitle"]).Trim();
                        lblPhyFirstNm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["FamilyPhysicianFName"]).Trim();
                        lblPhyMidlNm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["FamilyPhysicianMName"]).Trim();
                        lblPhyLstNm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["FamilyPhysicianLName"]).Trim();
                        lblhlthAddress.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["FamilyPhysicianAdd1"]).Trim();
                        lblhlthLandline.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["FamilyPhysicianPhone"]).Trim();
                        lblhlthmob.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["FamilyPhysicianMobile"]).Trim();
                        lblNmeEmp.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["EmployersName"]).Trim();
                        lblOrganizationType.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["fk_InsuredOrganizationTypeUID"]).Trim();
                        lblOccPtioncd.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["OccupationCode"]).Trim();
                        lblOccupation.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["OccupationName"]).Trim();

                        lblInsShare.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PercentageSharing"]).Trim();

                        GridPremium.DataSource = dsMemberDetails.Tables[5];
                        GridPremium.DataBind();//gvProductBenefit
                        //dsviolation
                        

                        if (dsMemberDetails.Tables[1].Rows.Count > 0)
                        {
                            lbl_co_CustomerId.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CustomerID"]).Trim();
                            lbl_co_MemberRefId.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["PolicyMemberUID"]).Trim();
                            lbl_co_Title.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantTitle"]).Trim();
                            lbl_co_FName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantFirstName"]).Trim();
                            lbl_co_MName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantMiddleName"]).Trim();
                            lbl_co_LName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantLastName"]).Trim();
                            lbl_co_Address1.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantAddress1"]).Trim();
                            lbl_co_Address2.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantAddress2"]).Trim();
                            lbl_co_Address3.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantAddress3"]).Trim();
                            lbl_co_Address4.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantAddress4"]).Trim();
                            lbl_co_CountryofResidence.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantCountryResidenceName"]).Trim();
                            lbl_co_State.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoAppStateName"]).Trim(); ////chng
                            lbl_co_Gender.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantGender"]).Trim();
                            lbl_co_city.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantCityName"]).Trim(); //chng 
                            lbl_co_LandMark.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoApplicant_Landmark"]).Trim();//chng LS

                            lbl_co_Pincode.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoAppPincodeCode"]).Trim();
                            lbl_co_Landline.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantPhone"]).Trim();
                            lbl_co_Mobile.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantPhone1"]).Trim();
                            lbl_co_email.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantEmailid"]).Trim();
                            //lbl_co_DOB.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["BirthDate"]).Trim();  //label not present in design page
                            //lbl_co_Age.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantAge"]).Trim();   //label not present in design page
                            lbl_co_Nationality.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["NationalityName"]).Trim();
                            lbl_co_ResiSts.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoApplicant_ResidentialStatus"]).Trim();
                            lbl_co_AnnIncome.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantAnnualIncome"]).Trim();
                            lbl_co_PanNumbr.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["PanCardNo"]).Trim();
                            lbl_co_IdentityCardType.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantIdentityCardTypeName"]).Trim();
                            lbl_co_IndentityCrdNo.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantIdentiyCardNumber"]).Trim();
                            lbl_co_Height.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantHeight"]).Trim();
                            lbl_co_Weight.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantWeight"]).Trim();
                            lbl_co_PhysicianName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantFamilyPhysicianTitle"]).Trim();
                            lbl_co_PhyFirstNm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantFamilyPhysicianFName"]).Trim();
                            //lbl_co_PhyMidlNm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantFamilyPhysicianMName"]).Trim();  //label not present in design page
                            //lbl_co_PhyLstNm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantFamilyPhysicianLName"]).Trim();   //label not present in design page
                            lbl_co_hlthAddress.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantFamilyPhysicianAdd1"]).Trim();
                            lbl_co_hlthLandline.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantFamilyPhysicianPhone"]).Trim();
                            lbl_co_hlthmob.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantFamilyPhysicianPhone1"]).Trim();
                            lbl_co_NmeEmp.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantEmployersName"]).Trim();
                            lbl_co_OrganizationType.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantOccupation_CompanyName"]).Trim();
                            lbl_co_OccPtioncd.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantOccupationCode"]).Trim();
                            lbl_co_Occupation.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoapplicantOccupationName"]).Trim();

                            lbl_co_InsShare.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoApp_PercentageSharing"]).Trim();
                            lbl_Co_RelationshipwithPrimaryApplicant.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[1].Rows[0]["CoApplicant_RelationshipPrimaryApplicant"]).Trim();

                        }

                        if (dsMemberDetails.Tables[2].Rows.Count > 0)
                        {

                            lblNomineeName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineeTitle"]).Trim();
                            lblFrstNm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineeFName"]).Trim();
                            lblNmneMdlName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineeMName"]).Trim();
                            lblNmneLstNm.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineeLName"]).Trim();
                            lblNominee1Relation.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineeRelationCode"]).Trim();
                            lblNomiAg1.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineeAge"]).Trim();
                            lblNomiDOB1.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineeDOB"]).Trim();
                            lblNomiPerctg1.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineePercentage"]).Trim();
                            lblNomineeGen.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["NomineeGender"]).Trim(); //LS added 


                            lblApointeeTitle.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["ApointeeTitle"]).Trim();
                            lblApointeeFName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["ApointeeFName"]).Trim();
                            lblApointeeMName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["ApointeeMName"]).Trim();
                            lblApointeeLName.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["ApointeeLName"]).Trim();
                            lblAppointeeRelation.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["AppointeeRelation"]).Trim();
                            lblApointeeAge.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["ApointeeAge"]).Trim();
                            lblAppointeeIdentityCardType.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["AppointeeIdentityCardType"]).Trim();
                            lblAppointeeIdentiyCardNumber.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[2].Rows[0]["AppointeeIdentiyCardNumber"]).Trim();
                        }
                    }

                    if (dsMemberUWAlphaDetails != null && dsMemberUWAlphaDetails.Tables[0].Rows.Count > 0)
                    {

                    }

                    #region SonaliCode
                    //Added by sonali on 04/08/2017
                    //if (dsMemberDetails.Tables[0].Rows[0]["RejectFlag"].ToString() == "R" || dsMemberDetails.Tables[0].Rows[0]["RejectFlag"].ToString() == "")
                    //{
                    //    //LS TabContainerREJECT.Visible = true;
                    //    //LS tabComtainer.Visible = false;

                    //    if (dsMemberDetails != null && dsMemberDetails.Tables[0].Rows.Count > 0)
                    //    {
                    //        lbl_Name.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientName"]).Trim();
                    //        lbl_Gender.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Gender"]).Trim();
                    //        lbl_DOB.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["DOB"]).Trim();
                    //        lbl_Age.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["InsuredAge"]).Trim();
                    //        lbl_Circl.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Circle"]).Trim();
                    //        lbl_Validty.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Validity"]).Trim();
                    //        lbl_MbNo.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["EmployeeNo"]).Trim();

                    //        lbl_RCharDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["RechargeDt"]).Trim();
                    //        lbl_MemberStatus.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["MemberStatus"]).Trim();
                    //        lbl_Remark.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Remark"]).Trim();

                    //    }


                    //}
                    //else
                    //{
                    //    tabComtainer.Visible = true;
                    //    TabContainerREJECT.Visible = false;

                    //    if (dsMemberDetails != null && dsMemberDetails.Tables[0].Rows.Count > 0)
                    //    {
                    //        //LblClientNameText.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientName"]).Trim();
                    //        //LblPolicyNoText.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PolicyNumber"]).Trim();

                    //        //LblSubOfficeCodeText.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientUnitCode"]).Trim();
                    //        //LblSubOfficeText.Text = " &nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientUnitName"]).Trim();

                    //        //LblCertificateofInsuranceNoText.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["COI"]).Trim();
                    //        //LblYear.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PolicyYear"]).Trim();
                    //        //lblEmployeeNo.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["EmployeeNo"]).Trim();

                    //        //lblInitialEffDate.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["InitialEffectiveDate"]).Trim();

                    //        //lblTerminationDate.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Terminationdt"]).Trim();
                    //        //lblMemberStatus.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["MemberStatus"]).Trim();

                    //        //lblInsuredTitle.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ProposedTitle"]).Trim() == null ? " " : "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ProposedName"]).Trim();

                    //        //lblGender.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Gender"]).Trim();
                    //        //lblInsuredDOB.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["DOB"]).Trim();
                    //        //lblInsuredAge.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["InsuredAge"]).Trim();

                    //        //lblMHUIDno.Text = "&nbsp; " + dsMemberDetails.Tables[0].Rows[0]["MHUIDno"].ToString().Trim();
                    //        //lblExpiryDate.Text = "&nbsp; " + dsMemberDetails.Tables[0].Rows[0]["ExpiryDate"].ToString().Trim();//Added by karunkar on 10-06-2016
                    //        //lblCircle.Text = "&nbsp; " + dsMemberDetails.Tables[0].Rows[0]["Circle"].ToString().Trim();
                    //        //lblValidity.Text = "&nbsp; " + dsMemberDetails.Tables[0].Rows[0]["Validity"].ToString().Trim();

                    //        if (dsMemberDetails.Tables[2].Rows.Count > 0)
                    //        {
                    //            gvProductBenefit.DataSource = dsMemberDetails.Tables[2];
                    //            gvProductBenefit.DataBind();
                    //        }
                    //        else
                    //        {
                    //            MenuMasterPage_Cr.ShowNoResultFound(dsMemberDetails.Tables[2], gvProductBenefit);
                    //            //Masters_MenuMasterPage.ShowNoResultFound(dsMemberDetails.Tables[2], gvProductBenefit);
                    //        }
                    //        if (dsMemberDetails.Tables[3].Rows.Count > 0)
                    //        {
                    //            gvPremiumDetail.DataSource = dsMemberDetails.Tables[3];
                    //            ViewState["PremiumDetail"] = dsMemberDetails.Tables[3];
                    //            gvPremiumDetail.DataBind();
                    //        }
                    //        else
                    //        {
                    //            MenuMasterPage_Cr.ShowNoResultFound(dsMemberDetails.Tables[3], gvPremiumDetail);
                    //            //Masters_MenuMasterPage.ShowNoResultFound(dsMemberDetails.Tables[3], gvPremiumDetail);
                    //        }

                    //        if (dsMemberDetails.Tables[4].Rows.Count > 0)
                    //        {
                    //            gvSMS.DataSource = dsMemberDetails.Tables[4];
                    //            gvSMS.DataBind();

                    //        }
                    //        if (dsMemberDetails.Tables[5].Rows.Count > 0)
                    //        {
                    //            lblNAge.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["NaomineeAge"].ToString().Trim();
                    //            lblNName.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["NomineeName"].ToString().Trim();
                    //            lblNRelation.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["NomineeRelation"].ToString().Trim();
                    //            lblAddress.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["NomineeAddress"].ToString().Trim();
                    //            //  lblMobileNo.Text = dsMemberDetails.Tables[5].Rows[0]["MobileNo"].ToString().Trim();
                    //            //lblIdentityNo.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["IdentityNo"].ToString().Trim();
                    //        }
                    //        //END

                    //    }

                    //    else
                    //    {

                    //        // Masters_MenuMasterPage.ShowNoResultFound(dsMemberDetails.Tables[0], gvProductBenefit);
                    //        MenuMasterPage_Cr.ShowNoResultFound(dsMemberDetails.Tables[0], gvProductBenefit);
                    //    }
                    //} 
                    #endregion
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        /// <summary>
        ///  Fill Drop Downlist Bind  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region BindDropdownlist
        ///string PolicyUID, string UserUID, string ApplicationID )
        

        public void ClearAll()
        {
            try
            {
                /***Underwriting****/

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        protected void lnkMemberHistory_Click(object sender, EventArgs e)
        {

            try
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../MemberInfoPopUp_cr.aspx?" + "MemberServicing" + "','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void lnkBillDetail_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open(~/../MemberInfoPopUp.aspx?ReceiptDetail','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
        }

        protected void lnkBillDetail_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../MemberInfoPopUp.aspx?MemberHistory','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
        }

        protected void lnkBillDetail_Click2(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../MemberInfoPopUp.aspx?PremiumHistory','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
        }

        protected void lnkBtnReceiptDetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../MemberInfoPopUp_cr.aspx?" + "PremiumServicing" + "','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
        }

        protected void lnkCoi_Click(object sender, EventArgs e)
        {
           //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../COIPopUP.aspx?" + "COIID" + "','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
           // int oPolicyUID;
           //int oCOI;
           // oPolicyUID = Convert.ToInt32(Session[CommonConstantNames.POLICYUID]);
           // Response.Redirect("Default2.aspx?UserId="+txtUserId.Text+"&UserName="+txtUserName.Text);
           //COI_cr = Convert.ToInt32(Session["COI_cr"]);
           //  Response.Redirect("http://192.168.1.57:310/PDF_cr.aspx?PolicyMemberUID=" + PolicyMemberUID);
           //LS  Response.Redirect("http://192.168.1.57:208/PDF_cr.aspx?PolicyMemberUID=" + PolicyMemberUID);
           
            //hdnMemberID.Value = PolicyMemberUID.ToString();
            //string js = "";
            //js += "window.opener.location.href='" + GeneratingPDFDynamically + "" + PolicyMemberUID + "';";
            //ClientScript.RegisterStartupScript(this.GetType(), "redirect", js, true);


            string url = "" + GeneratingPDFDynamically + "" + PolicyMemberUID + "";

            StringBuilder sb = new StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.open('");

            sb.Append(url);

            sb.Append("');");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(),

                    "script", sb.ToString());

        }

        protected void lnkDeclineLetter_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Report_CreditLife/DeclineLetterReport.aspx", true);
        }
        // 
        protected void lnkSurrenderletter_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Report_CreditLife/PostponeLetter.aspx", true);
        }


        protected void gvPremiumDetail_OnDataBound(object sender, EventArgs e)
        {
            if (ViewState["PremiumDetail"] != null)
            {
                if (((DataTable)ViewState["PremiumDetail"]).Rows.Count > 0)
                {
                    DataTable dt = (DataTable)ViewState["PremiumDetail"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Medical"].ToString() == "Y")
                        {
                            ((ImageButton)gvPremiumDetail.Rows[i].FindControl("imgPDF")).Visible = true;
                        }
                        else
                        {
                            ((ImageButton)gvPremiumDetail.Rows[i].FindControl("imgPDF")).Visible = false;
                        }
                    }

                }
            }
        }

        protected void gvPremiumDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowMTRF")
            {
                // Response.Redirect("~/Reports/ShowMTRF.aspx",true);
                ScriptManager.RegisterClientScriptBlock(gvPremiumDetail, this.GetType(), "BlockName", "window.open('../Reports/ShowMTRF.aspx','MTRF','toolbar=yes; location=no; status=yes; menubar=no; resizable=yes; scrollbars=no; fullscreen=yes;');", true);
            }
        }
        protected void btnRedirectToMemberEnquiry_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../MemberInformation_cr/MemberInformation_cr.aspx", true);
            string redirectUrl = "../MemberInformation_cr/MemberInformation_cr.aspx";
            string script = $"<script type='text/javascript'>top.location.href='{redirectUrl}';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", script);
        }
    }
}
