
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // add for key
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Collections; // added based on creditlifeinformation.cs
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using GlimpsDAL;
using GlimpsBAL;






namespace PACE
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AppointeeDetail
    {
        public string relationship { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public int? age { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string salutation { get; set; }
        public string firstName { get; set; }
        public string SQ { get; set; }
    }

    public class ChannelDetails
    {
        public string premiumPaidFromLoan { get; set; }
        public string bankname { get; set; }
        public string smsBranchCode { get; set; }
        public string smsLgCode { get; set; }
        public string branchCode { get; set; }
        public string clientId { get; set; }
        public string dsaCode { get; set; }
        public int? annualIncome { get; set; }
        public string loanRefId { get; set; }
        public string applicantType { get; set; }
        public string loanAccountNo { get; set; }
        public string preApproavedFlag { get; set; }
        public string isGLPPredirect { get; set; }
        public string branchLgCode { get; set; }
    }

    public class DisbursementDetails
    {
        public string transactionAmount { get; set; }
        public string transactionId { get; set; }
        public string disbursementDate { get; set; }
        public string disbursementAmount { get; set; }
        public string premiumCreditDate { get; set; }
    }

    public class EcsDetails
    {
        public string periodTo { get; set; }
        public string applicationNumber { get; set; }
        public string micrCode { get; set; }
        public string accountType { get; set; }
        public string debitType { get; set; }
        public string bankName { get; set; }
        public string frequency { get; set; }
        public string ifscCode { get; set; }
        public string utilityCode { get; set; }
        public string periodFrom { get; set; }
        public string sponsorBankCode { get; set; }
        public string umrnNumber { get; set; }
    }

    public class ExDetails
    {

        [JsonIgnore]
        public string ClientName { get; set; }
        public string source { get; set; }
        public string productCode { get; set; }
        public string clientCode { get; set; }
        public string policyNumber { get; set; }
        public string ipAddress { get; set; }
    }

    public class HealthDetail
    {
        public double? weightInKg { get; set; }
        public double? heightInFeet { get; set; }
        public int? covidQue1 { get; set; }
        public int? covidQue2 { get; set; }
        public int? covidQue3 { get; set; }
        public int? covidQue4 { get; set; }
        public int? covidQue5 { get; set; }
        public int? covidQue3a { get; set; }
        public int? covidQue6 { get; set; }
        public int? covidQue7 { get; set; }
        public int? covidQue8 { get; set; }
        public int? covidQue9 { get; set; }
        public double? heightInInches { get; set; }
        public int? covidQue5a { get; set; }
        public string SQ { get; set; }
        public int? medicalQue8 { get; set; }
        public int? medicalQue9 { get; set; }
        public int? medicalQue1 { get; set; }
        public int? medicalQue2 { get; set; }
        public int? medicalQue3 { get; set; }
        public int? medicalQue4 { get; set; }
        public int? medicalQue5 { get; set; }
        public int? medicalQue6 { get; set; }
        public int? medicalQue7 { get; set; }
        public int? medicalQue10 { get; set; }
        public int? covidQue10 { get; set; }
        public int? covidQue10a { get; set; }
    }

    public class InsuranceAndLoanDetails
    {
        public string oldLoanAccountNumber { get; set; }
        public int? sumAssuredFor3rdBorrower { get; set; }
        public int? sumAssuredFor2ndBorrower { get; set; }
        public int? annualIncomeForPrimaryInsured { get; set; }
        public int? loanAmount { get; set; }
        public int? installmentPremiumIncludingTaxes { get; set; }
        public string premiumPaidFromLoan { get; set; }
        public int? moratoriumPeriod { get; set; }
        public string premiumPaymentFrequency { get; set; }
        public string bankAccountHolderName { get; set; }
        public string newLoan { get; set; }
        public int? loanTenure { get; set; }
        public string sumAssuredType { get; set; }
        public string benefitOption { get; set; }
        public int? loanInterest { get; set; }
        public int? installmentPremiumWithoutTaxes { get; set; }
        public int? sumAssuredFor4thBorrower { get; set; }
        public int? premiumPaymentTerm { get; set; }
        public bool staff { get; set; }
        public string loanRefId { get; set; }
        public int? policyTerm { get; set; }
        public int? singleAnnualPremiumExcludingTaxes { get; set; }
        public string loanType { get; set; }
        public string premiumType { get; set; }
        public string accountOwnedBy { get; set; }
        public string insuranceType { get; set; }
        public int? sumAssuredFor1stBorrower { get; set; }
    }

    public class LlpsPlanDataRequest
    {
        // public List<NomineeDetail> nomineeDetails { get; set; }
        public NomineeDetail[] nomineeDetails { get; set; }
        public PlanDetails planDetails { get; set; }
        public InsuranceAndLoanDetails insuranceAndLoanDetails { get; set; }
        public ChannelDetails channelDetails { get; set; }
        public VernacularUneducatedDetails vernacularUneducatedDetails { get; set; }
        public EcsDetails ecsDetails { get; set; }
        public List<HealthDetail> healthDetails { get; set; }
        public List<AppointeeDetail> appointeeDetails { get; set; }
        public List<PersonalDetail> personalDetails { get; set; }
        public DisbursementDetails disbursementDetails { get; set; }
        public ExDetails exDetails { get; set; }
        public QuoteDetails quoteDetails { get; set; }
    }

    public class NomineeDetail
    {
        // mobile no not in payload
        public string middleName { get; set; }
        public string relationship { get; set; }
        public string lastName { get; set; }
        public int? percentageOfEntitlement { get; set; }
        public int? age { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string salutation { get; set; }
        public string firstName { get; set; }
        public string SQ { get; set; }
    }

    public class PersonalDetail
    {
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string occupation { get; set; }
        public string state { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string natureOfDuties { get; set; }
        public string address3 { get; set; }
        public string panNumber { get; set; }
        public string SQ { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string email { get; set; }
        public string age { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string mobileNumber { get; set; }
        public string firstName { get; set; }
        public string salutation { get; set; }
        public string nsdlPanStatus { get; set; }
        public string fourthBorrowerShare { get; set; }
        public int? thirdBorrowerShare { get; set; }
        public int? secondBorrowerShare { get; set; }
        public int? numberOfLifesToBeCovered { get; set; }
        public int? jointBorrowerShare { get; set; }
        public string jointLifeBasis { get; set; }
        public bool? jointLifeOption { get; set; }
        public int? firstBorrowerShare { get; set; }
        public bool? doYouUnderstandEnglish { get; set; }
        public bool? areYouIlliterate { get; set; }
    }

    public class PlanDetails
    {
        public int? interestMoratoriumPeriod { get; set; }
        public int? loanInterestRate { get; set; }
        public int? loanAmount { get; set; }
        public string uwFlag { get; set; }
        public int? fourthLifePremiumRate { get; set; }
        public string sumAssuredType { get; set; }
        public string benefitOption { get; set; }
        public string disbursementDate { get; set; }
        public bool staffFlag { get; set; }
        public string loanType { get; set; }
        public int? thirdLifePremiumRate { get; set; }
        public int? premiumAmount { get; set; }
        public string benefitOptionCode { get; set; }
        public string deathOptionIncomeYears { get; set; }
        public double firstLifePremiumRate { get; set; }
        public int? moratoriumPeriod { get; set; }
        public string paymentFrequency { get; set; }
        public int? secondLifePremiumRate { get; set; }
        public int? premiumPayingTerm { get; set; }
        public int? policyTerm { get; set; }
        public int? sumAssured { get; set; }
        public string premiumType { get; set; }
        public string insuranceType { get; set; }
        public string deathOption { get; set; }
        public string premiumDebitDate { get; set; }
    }

    public class QuoteDetails
    {
        public int? sumAssuredForFourthLife { get; set; }
        public int? installmentPremiumExcludingTaxes { get; set; }
        public int? installmentPremiumIncludingTaxes { get; set; }
        public int? singleAnnualPremiumExcludingTaxes { get; set; }
        public string sumAssuredForSecondaryLife { get; set; }
        public int? sumAssuredForPrimeLife { get; set; }
        public int? sumAssuredForThirdLife { get; set; }
    }

    public class Root
    {
        public LlpsPlanDataRequest llpsPlanDataRequest { get; set; }
    }

    public class VernacularUneducatedDetails
    {
        public int? installmentPremiumExcludingTaxes { get; set; }
        public int? installmentPremiumIncludingTaxes { get; set; }
        public int? singleAnnualPremiumExcludingTaxes { get; set; }
        public string language { get; set; }
        public string nameOfTheDeclarant { get; set; }
        public string mobileNumber { get; set; }
        public string declarantAddress { get; set; }
    }



    public partial class Applicationform : System.Web.UI.Page
   {

        //start add from creditlife
        PolicyInformationBAL policyInformationBAL = null;
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        DataTable dt = null;
        // end
        DataSet dsResults = null; //glimpse
        PolicyInformationBAL policyInformationBAL_AppForm = null; //glimpse

        protected void Page_Load(object sender, EventArgs e)
       {
                        PD1JointLifeBasisDropDownList41.Enabled = false;

                
            //start add from creditlife

            try
            {
                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                    /*
            * ADDED BY KARUNAKAR ON 02-05-2016
            * AS PER NEW CR TTSL
            * START
            */
                    if (Session["IsTTSL"].ToString().ToUpper() == "Y")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "TTSLErrorFlag();", true);
                    }
                    //END
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "CreditLifeInformation.aspx");
                    //((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation1")).Attributes.Add("class", "tab_link_active"); // comment by ramesh

                    policyInformationBAL = new PolicyInformationBAL();
                    dt = policyInformationBAL.PolicyInformationDetails_cr(UserUID, subOfficeUID);

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            //lblClient.Text = "&nbsp;" + dt.Rows[0]["ClientName"].ToString();
                            string ClientName=  dt.Rows[0]["ClientName"].ToString();
                            //lblPolicyNo.Text = "&nbsp; " + dt.Rows[0]["PolicyNumber"].ToString();
                            string PolicyNumber = dt.Rows[0]["PolicyNumber"].ToString();
                            //lblPolicyStaus.Text = "&nbsp; " + dt.Rows[0]["PolicyStatus"].ToString();
                            //lblInceptionDate.Text = "&nbsp; " + dt.Rows[0]["InceptionDate"].ToString();
                            //lblAnniversaryDate.Text = "&nbsp; " + dt.Rows[0]["AnniversaryDate"].ToString();
                            //lblminEntryAge.Text = "&nbsp; " + dt.Rows[0]["MinEntryAge"].ToString();
                            //lblMaxEntryAge.Text = "&nbsp; " + dt.Rows[0]["MaxEntryAge"].ToString();
                            //lblClientCode.Text = "&nbsp; " + dt.Rows[0]["ClientCode"].ToString();
                            string ClientCode = dt.Rows[0]["ClientCode"].ToString();

                            //lblProducName.Text = "&nbsp; " + dt.Rows[0]["ProductName"].ToString();
                            //lblProductUINNo.Text = "&nbsp; " + dt.Rows[0]["UIN_No"].ToString();
                            //lblServiceManager.Text = "&nbsp; " + dt.Rows[0]["Service_ManagerName"].ToString();
                            //lblAB.Text = "&nbsp; " + dt.Rows[0]["AgentName"].ToString();
                            //lblModeofPolicy.Text = "&nbsp; " + dt.Rows[0]["PremiumFrequencyName"].ToString();
                            //lblNumberofmembercovered.Text = "&nbsp; " + dt.Rows[0]["Numberofmembercovered"].ToString();
                            //lblSegmentType.Text = "&nbsp; " + dt.Rows[0]["Segments"].ToString();
                            //lblRateInterest.Text = "&nbsp; " + dt.Rows[0]["Rate_Interest"].ToString();
                            Session["PolicyUID"] = dt.Rows[0]["PolicyUID"].ToString();
                        }
                    }

                    GetAllClients();
                }

               
                //GetAllClients();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }

            // end

            //Txt1stNominee_Name.Enabled = false;
            //Txt1stNominee_MiddleName.Enabled = false;
            //Txt1stNominee_LastName.Enabled = false;
            //GenderDropDownList24.Enabled = false;
            //Txt1stNominee_DateofBirth.Enabled = false;
            //RelationDropDownList25.Enabled = false;
            //Txt1stNominee_PercentageofEntitlementonlyincaseofNominee.Enabled = false;
            //Txt1stNomineeMobileNumber.Enabled = false;

            //Nominee1rfvName.Enabled = false;
            //Nominee1rfvMiddleName.Enabled = false;
            //Nominee1rfvLastName.Enabled = false;
            //Nominee1rfvGender.Enabled = false;
            //Nominee1rfvDob.Enabled = false;
            //Nominee1rfvRelation.Enabled = false;
            //Nominee1rfvPercentage.Enabled = false;
            //Nominee1rfvMobileNumber.Enabled = false;
        }

        void WriteLogs(string logMessage)
        {

            string strLogMessage = string.Empty;
            string strLogFile = System.Configuration.ConfigurationManager.AppSettings["LOG_FILE_PATH"].ToString();
            StreamWriter swLog;
            strLogMessage = logMessage;

            if (!File.Exists(strLogFile))
            {
                swLog = new StreamWriter(strLogFile);
            }
            else
            {
                swLog = File.AppendText(strLogFile);
            }

            swLog.WriteLine(strLogMessage);
            swLog.WriteLine();

            swLog.Close();
        }
        protected void Button11_Click(object sender, EventArgs e)
        {  
            LlpsPlanDataRequest Lobj = new LlpsPlanDataRequest(); //add for test
            ExDetails exobj = new ExDetails();
            ChannelDetails chobj = new ChannelDetails();
            InsuranceAndLoanDetails InsloandObj = new InsuranceAndLoanDetails();
            VernacularUneducatedDetails VernacularObj = new VernacularUneducatedDetails();
            EcsDetails EcsObj = new EcsDetails();
            PlanDetails Planobj = new PlanDetails();
            QuoteDetails QuoteObj = new QuoteDetails();
            DisbursementDetails Disburseobj = new DisbursementDetails();
            //HealthDetail Hdobj = new HealthDetail();
            exobj.source = "LLPS";
            exobj.productCode = "Group Loan Protect Plan";
            GetAllClients();
            exobj.clientCode = LabelClientcode.Text;
            exobj.ClientName = DdlClient.SelectedValue;
            exobj.policyNumber = DdlPolicyNo.SelectedValue;
            exobj.ipAddress = "10.1.4.204";
            string exobjjson = JsonConvert.SerializeObject(exobj, Formatting.Indented);

            Lobj.exDetails = exobj; //add for test
            string jsonPayload = JsonConvert.SerializeObject(Lobj, Formatting.Indented); //add for test

            chobj.smsBranchCode = TxtSMSBranchCode.Text;
            chobj.smsLgCode = TxtSMSLgCode.Text;
            chobj.dsaCode = TxtDsaCode.Text;
            chobj.branchCode = TxtBranchCode.Text;
            chobj.branchLgCode = TxtBranchLGCode.Text;
            chobj.loanRefId = TxtLoanReferenceId.Text;
            //// ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Please enter the LoanreferenceId--!');", true);
            //if (TxtLoanReferenceId.Text="" || )
            //{

            //}
            chobj.loanAccountNo = TxtLoanAccountNo.Text;
            chobj.applicantType = ApplicantTypeDropDownList1.SelectedValue;
            chobj.premiumPaidFromLoan = TxtPremiumPaidFromLoan.Text;
            chobj.annualIncome = string.IsNullOrEmpty(TxtAnnualIncome.Text) ? 0 : Convert.ToInt32(TxtAnnualIncome.Text);

            chobj.clientId = TxtClientId.Text;
            chobj.bankname = "Sbi";       // in ui Bank name not present and exist in payload
            chobj.preApproavedFlag = null; //in ui preApproavedFlag not present and exist in payload
            chobj.isGLPPredirect = null;   //in ui isGLPPredirect not present and exist in payload
            string chobjjson = JsonConvert.SerializeObject(chobj, Formatting.Indented);

            Lobj.channelDetails = chobj; //add for test
            string jsonPayloadnew = JsonConvert.SerializeObject(Lobj, Formatting.Indented); //add for test


            InsloandObj.oldLoanAccountNumber = TxtOldLoanAccountNumber.Text;
            InsloandObj.sumAssuredFor3rdBorrower = string.IsNullOrEmpty(TxtSumAssured3rdBorrower.Text) ? 0 : Convert.ToInt32(TxtSumAssured3rdBorrower.Text);
            InsloandObj.sumAssuredFor2ndBorrower = string.IsNullOrEmpty(TxtSumAssured2ndBorrower.Text) ? 0 : Convert.ToInt32(TxtSumAssured2ndBorrower.Text);
            InsloandObj.annualIncomeForPrimaryInsured = string.IsNullOrEmpty(TxtAnnualIncomeForPrimaryInsured.Text) ? 0 : Convert.ToInt32(TxtAnnualIncomeForPrimaryInsured.Text);
            InsloandObj.loanAmount = string.IsNullOrEmpty(TxtLoanAmount.Text) ? 0 : Convert.ToInt32(TxtLoanAmount.Text);

            InsloandObj.installmentPremiumIncludingTaxes = string.IsNullOrEmpty(TxtInstallmentPremiumIncludingTaxes.Text) ? 0 : Convert.ToInt32(TxtInstallmentPremiumIncludingTaxes.Text);
            InsloandObj.premiumPaidFromLoan = PremiumPaidFromLoanDropDownList28.SelectedValue;
            InsloandObj.moratoriumPeriod = string.IsNullOrEmpty(TxtInterestDuringMoratoriumPeriod.Text) ? 0 : Convert.ToInt32(TxtInterestDuringMoratoriumPeriod.Text);
            InsloandObj.premiumPaymentFrequency = PremiumPaymentFrequencyDropDownList23.SelectedValue;
            InsloandObj.bankAccountHolderName = TxtBankAccountHolderName.Text;
            InsloandObj.newLoan = NewLoanDropDownList19.SelectedValue;
            InsloandObj.loanTenure = string.IsNullOrEmpty(TxtLoanTenure.Text) ? 0 : Convert.ToInt32(TxtLoanTenure.Text);

            InsloandObj.sumAssuredType = SumAssuredTypeDropDownList21.SelectedValue;
            InsloandObj.benefitOption = BenifitsOptionsDropDownList29.SelectedValue;
            InsloandObj.loanInterest = string.IsNullOrEmpty(TxtLoanInterestRate.Text) ? 0 : Convert.ToInt32(TxtLoanInterestRate.Text);
            InsloandObj.installmentPremiumWithoutTaxes = string.IsNullOrEmpty(TxtInstallmentPremiumWithoutTaxes.Text) ? 0 : Convert.ToInt32(TxtInstallmentPremiumWithoutTaxes.Text);
            InsloandObj.sumAssuredFor4thBorrower = string.IsNullOrEmpty(TxtSumAssured4thBorrower.Text) ? 0 : Convert.ToInt32(TxtSumAssured4thBorrower.Text);
            InsloandObj.premiumPaymentTerm = string.IsNullOrEmpty(TxtPremiumPaymentTerm.Text) ? 0 : Convert.ToInt32(TxtPremiumPaymentTerm.Text);
            InsloandObj.staff = true;//Convert.ToBoolean(StaffDropDownList20.SelectedValue);
            InsloandObj.loanRefId = TxtLoanRefId.Text;
            InsloandObj.policyTerm = string.IsNullOrEmpty(TxtPolicyTerm.Text) ? 0 : Convert.ToInt32(TxtPolicyTerm.Text);
            InsloandObj.singleAnnualPremiumExcludingTaxes = string.IsNullOrEmpty(TxtSinglePremiumAnnualPremiumExcludingTaxes.Text) ? 0 : Convert.ToInt32(TxtSinglePremiumAnnualPremiumExcludingTaxes.Text);
            InsloandObj.loanType = TxtLoanType.Text; // SET VALUE = PL as per payload
            InsloandObj.accountOwnedBy = TxtACOwnedBy.Text; // SET VALUE= Primary as per payload
            InsloandObj.insuranceType = InsuranceTypeDropDownList22.SelectedValue;
            InsloandObj.sumAssuredFor1stBorrower = string.IsNullOrEmpty(TxtSumAssured1stBorrower.Text) ? 0 : Convert.ToInt32(TxtSumAssured1stBorrower.Text);

            string InsloandObjJson = JsonConvert.SerializeObject(InsloandObj, Formatting.Indented);
            Lobj.insuranceAndLoanDetails = InsloandObj; // add for test
            VernacularObj.installmentPremiumExcludingTaxes = string.IsNullOrEmpty(TxtInstallmentPremiumExcludingTaxes.Text) ? 0 : Convert.ToInt32(TxtInstallmentPremiumExcludingTaxes.Text);
            VernacularObj.installmentPremiumIncludingTaxes = string.IsNullOrEmpty(TxtVCInstallmentPremiumIncludingTaxes.Text) ? 0 : Convert.ToInt32(TxtVCInstallmentPremiumIncludingTaxes.Text);
            VernacularObj.singleAnnualPremiumExcludingTaxes = string.IsNullOrEmpty(TxtSingleAnnualPremiumExcludingTaxes.Text) ? 0 : Convert.ToInt32(TxtSingleAnnualPremiumExcludingTaxes.Text);
            VernacularObj.language = TxtLanguage.Text;
            VernacularObj.nameOfTheDeclarant = TxtNameOftheDeclarant.Text;
            VernacularObj.mobileNumber = TxtMobileNo.Text;
            VernacularObj.declarantAddress = TxtDeclarantAddress.Text;
            string VernacularObjJson = JsonConvert.SerializeObject(VernacularObj, Formatting.Indented);
            Lobj.vernacularUneducatedDetails = VernacularObj; // add for test
            EcsObj.periodTo = null; // SET VALUE AS Null (in ui not exist and exist in payload and period exist in ui)
            EcsObj.applicationNumber = TxtApplicationNumber.Text;
            EcsObj.micrCode = TxtMICRCODE.Text;
            EcsObj.accountType = AccountTypeDropDownList33.SelectedValue;
            EcsObj.debitType = DebitTypeDropDownList34.SelectedValue;
            EcsObj.bankName = TxtECSBankName.Text;
            EcsObj.frequency = FrequencyDropDownList35.SelectedValue;
            EcsObj.ifscCode = TxtIFSCCode.Text;
            EcsObj.utilityCode = TxtUtilityCode.Text;
            EcsObj.periodFrom = null;  // SET VALUE AS Null (in ui not exist and exist in payload)
            EcsObj.sponsorBankCode = TxtSponserBankCode.Text;
            EcsObj.umrnNumber = TxtUMRNNumber.Text;

            string EcsObjJson = JsonConvert.SerializeObject(EcsObj, Formatting.Indented);

            Lobj.ecsDetails = EcsObj; // add for test

            Planobj.interestMoratoriumPeriod = 0;//InterestDuringMoratoriumPeriodDropDownList15.SelectedValue;
            Planobj.loanInterestRate = string.IsNullOrEmpty(TxtPlandLoanInterestRate.Text) ? 0 : Convert.ToInt32(TxtPlandLoanInterestRate.Text);

            Planobj.loanAmount = string.IsNullOrEmpty(TxtPlanDLoanAmount.Text) ? 0 : Convert.ToInt32(TxtPlanDLoanAmount.Text);
            Planobj.uwFlag = null; // not in ui and exist in payload
            Planobj.fourthLifePremiumRate = 0; // not in ui and exist in payload
            Planobj.sumAssuredType = SumAssuredTypeDropDownList6.SelectedValue;
            Planobj.benefitOption = "0"; // BenifitOptionDropDownList18.SelectedValue; need to check yes or no
            Planobj.disbursementDate = null; // "01/08/2022" not in ui and exist in payload
            Planobj.staffFlag = true;//Convert.ToBoolean(SelectStaffDropDownList4.SelectedValue);
            Planobj.loanType = TxtSelectLoanTypeDropDownList3.SelectedValue;
            Planobj.thirdLifePremiumRate = 2; // not in ui and exist in payload
            Planobj.premiumAmount = 1000;        // not in ui and exist in payload
            Planobj.benefitOptionCode = BenifitCoverageDropDownList8.SelectedValue;//ui it is Benifit Coverage
            Planobj.deathOptionIncomeYears = DeathOptionIncomeYearsDropDownList12.SelectedValue;
            Planobj.firstLifePremiumRate = 1; // not in ui and exist in payload
            Planobj.moratoriumPeriod = string.IsNullOrEmpty(MoratoriumPeriodDropDownList14.SelectedValue) ? 0 : Convert.ToInt32(MoratoriumPeriodDropDownList14.SelectedValue);
            Planobj.paymentFrequency = PaymentFrequencyDropDownList9.SelectedValue;
            Planobj.secondLifePremiumRate = 2;
            Planobj.premiumPayingTerm = 1;//PremiumPayingTermDropDownList13.SelectedIndex;
            Planobj.policyTerm = string.IsNullOrEmpty(TxtPlanDetPolicyTerm.Text) ? 0 : Convert.ToInt32(TxtPlanDetPolicyTerm.Text);

            Planobj.sumAssured = string.IsNullOrEmpty(TxtSumAssured.Text) ? 0 : Convert.ToInt32(TxtSumAssured.Text);
            Planobj.premiumType =PremiumTypeDropDownList5.SelectedValue;
            Planobj.insuranceType = InsuranceTypeDropDownList7.Text;
            Planobj.deathOption = DeathOptionDropDownList10.Text;
            Planobj.premiumDebitDate = "01/08/2022"; // not in ui and exist in payload
            string PlanobjJson = JsonConvert.SerializeObject(Planobj, Formatting.Indented);

            Lobj.planDetails = Planobj; // add for test

            QuoteObj.sumAssuredForFourthLife = string.IsNullOrEmpty(TxtSumAssuredForFourthLife.Text) ? 0 : Convert.ToInt32(TxtSumAssuredForFourthLife.Text);


            QuoteObj.installmentPremiumExcludingTaxes = string.IsNullOrEmpty(TxtQuoteDetInstallmentPremiumExcludingTaxes.Text) ? 0 : Convert.ToInt32(TxtQuoteDetInstallmentPremiumExcludingTaxes.Text);


            QuoteObj.installmentPremiumIncludingTaxes = string.IsNullOrEmpty(TxtQuotedetInstallmentPremiumIncludingTaxes.Text) ? 0 : Convert.ToInt32(TxtQuotedetInstallmentPremiumIncludingTaxes.Text);


            QuoteObj.singleAnnualPremiumExcludingTaxes = string.IsNullOrEmpty(TxtQuoteDetSingleAnnualPremiumExcludingTaxes.Text) ? 0 : Convert.ToInt32(TxtQuoteDetSingleAnnualPremiumExcludingTaxes.Text);

            QuoteObj.sumAssuredForSecondaryLife = TxtSumAssuredForSecondLife.Text;
            QuoteObj.sumAssuredForPrimeLife = string.IsNullOrEmpty(TxtSumAssuredForPrimeLife.Text) ? 0 : Convert.ToInt32(TxtSumAssuredForPrimeLife.Text);

            QuoteObj.sumAssuredForThirdLife = string.IsNullOrEmpty(TxtSumAssuredForThirdLife.Text) ? 0 : Convert.ToInt32(TxtSumAssuredForThirdLife.Text);
            string QuoteObjJson = JsonConvert.SerializeObject(QuoteObj, Formatting.Indented);

            Lobj.quoteDetails = QuoteObj; //add for test

            Disburseobj.transactionAmount = null;
            Disburseobj.transactionId = null;
            Disburseobj.disbursementDate = null;
            Disburseobj.disbursementAmount = null;
            Disburseobj.premiumCreditDate = null;
            string DisburseobjJson = JsonConvert.SerializeObject(Disburseobj, Formatting.Indented);

            Lobj.disbursementDetails = Disburseobj; // add for test

            //Nominee1


            string first_middleName = Txt1stNominee_MiddleName.Text;
            string first_relationship = RelationDropDownList25.SelectedValue;
            string first_lastName = Txt1stNominee_LastName.Text;
            int? first_percentageOfEntitlement = string.IsNullOrEmpty(Txt1stNominee_PercentageofEntitlementonlyincaseofNominee.Text) ? (int?)null : Convert.ToInt32(Txt1stNominee_PercentageofEntitlementonlyincaseofNominee.Text);
            int? first_age = string.IsNullOrEmpty(Txt1stNominee_Age.Text) ? 0 : Convert.ToInt32(Txt1stNominee_Age.Text);
            string first_dob = Txt1stNominee_DateofBirth.Text;
            string first_gender = GenderDropDownList24.Text;
            string first_salutation = SalutationDropDownList11.SelectedValue;
            string first_firstName = Txt1stNominee_Name.Text;
            string first_SQ = "0";

            //Nominee2
            string second_middleName = Txt2ndMiddleName.Text;
            string second_relationship = RelationDropDownList67.SelectedValue;
            string second_lastName = Txt2ndLastName.Text;
            int? second_percentageOfEntitlement = string.IsNullOrEmpty(Txt2ndNominee_PercentageofEntitlementonlyincaseofNominee.Text) ? 0 : Convert.ToInt32(Txt2ndNominee_PercentageofEntitlementonlyincaseofNominee.Text);
            int? second_age = string.IsNullOrEmpty(Txt2ndAge.Text) ? 0 : Convert.ToInt32(Txt2ndAge.Text);
            string second_dob = TxtDateofBirth.Text;
            string second_gender = GenderDropDownList27.SelectedValue;
            string second_salutation = SalutationDropDownList26.SelectedValue;
            string second_firstName = Txt2ndName.Text;
            string second_SQ = "1";

            //Nominee3
            string thirdmiddleName = Txt3rdNomineeMiddleName.Text;
            string thirdrelationship = RelationDropDownList79.SelectedValue;
            string thirdlastName = Txt3rdNomineeLastName.Text;
            int? thirdpercentageOfEntitlement = string.IsNullOrEmpty(Txt3rdNominee_PercentageofEntitlementonlyincaseofNominee.Text) ? 0 : Convert.ToInt32(Txt3rdNominee_PercentageofEntitlementonlyincaseofNominee.Text);
            int? thirdage = string.IsNullOrEmpty(Txt3rdNomineeAge.Text) ? 0 : Convert.ToInt32(Txt3rdNomineeAge.Text);
            string thirddob = Txt3rdNomineeDob.Text;
            string thirdgender = GenderDropDownList78.SelectedValue;
            string thirdsalutation = SalutationDropDownList77.SelectedValue;
            string thirdfirstName = Txt3rdNomineeName.Text;
            string thirdSQ = "2";

            //Nominee4
            string fourthmiddleName = Txt4thMiddleName.Text;
            string fourthrelationship = RelationDropDownList82.Text;
            string fourthlastName = Txt4thLastName.Text;
            int? fourthpercentageOfEntitlement = string.IsNullOrEmpty(Txt4thNominee_PercentageofEntitlementonlyincaseofNominee.Text) ? 0 : Convert.ToInt32(Txt4thNominee_PercentageofEntitlementonlyincaseofNominee.Text);
            int? fourthage = string.IsNullOrEmpty(Txt4thNomineeAge.Text) ? 0 : Convert.ToInt32(Txt4thNomineeAge.Text);
            string fourthdob = Txt4thNomineeDob.Text;
            string fourthgender = GenderDropDownList81.Text;
            string fourthsalutation = SalutationDropDownList80.SelectedValue;
            string fourthfirstName = Txt4thNomineeName.Text;
            string fourthSQ = "3";

            //Nominee5 use in future
            //string fifthmiddleName =
            //string fifthrelationship =
            //string fifthlastName =
            //int ? fifthpercentageOfEntitlement =
            //int ? fifthage =
            //string fifthdob =
            //string fifthgender =
            //string fifthsalutation =
            //string fifthfirstName =
            //string fifthSQ = "4";

            // string Mname = TxtSumAssuredForSecondLife.Text;


            NomineeDetail[] nomineeDetails = new NomineeDetail[]
        {
                new NomineeDetail
                {
                     relationship=first_relationship,
                     middleName=first_middleName,
                     lastName=first_lastName,
                     percentageOfEntitlement=first_percentageOfEntitlement,
                     age=first_age,
                     dob=first_dob,
                     gender=first_gender,
                     firstName=first_firstName,
                     salutation=first_salutation,
                     SQ="0"

                },
                new NomineeDetail
                {
                    relationship=second_relationship,
                     middleName=second_middleName,
                     lastName=second_lastName,
                     percentageOfEntitlement=second_percentageOfEntitlement,
                     age=second_age,
                     dob=second_dob,
                     gender=second_gender,
                     firstName=second_firstName,
                     salutation=second_salutation,
                     
                     SQ="1"

                },
                new NomineeDetail
                {
                   relationship=thirdrelationship,
                     middleName=thirdmiddleName,
                     lastName=thirdlastName,
                     percentageOfEntitlement=thirdpercentageOfEntitlement,
                     age=thirdage,
                     dob=thirddob,
                     gender=thirdgender,
                     firstName=thirdfirstName,
                     salutation=thirdsalutation,
                     SQ="2"
                },
                new NomineeDetail
                {
                     relationship=fourthrelationship,
                     middleName=fourthmiddleName,
                     lastName=fourthlastName,
                     percentageOfEntitlement=fourthpercentageOfEntitlement,
                     age=fourthage,
                     dob=fourthdob,
                     gender=fourthgender,
                     firstName=fourthfirstName,
                     salutation=fourthsalutation,
                     SQ="3"
                }
        };
            //Txt1stNominee_Name

            //if (!string.IsNullOrEmpty(Txt1stNominee_Name.Text) && !string.IsNullOrEmpty(Txt2ndName.Text) && !string.IsNullOrEmpty(Txt3rdNomineeName.Text) && !string.IsNullOrEmpty(Txt3rdNomineeName.Text))
            //{
            //nomineeDetails.(nomineeDetails[0]); // Remove index 3 first
            //}


            string NomineeobjJson = JsonConvert.SerializeObject(nomineeDetails, Formatting.Indented);

            Lobj.nomineeDetails = nomineeDetails; //add for test

            //----------

            List<HealthDetail> healthDetails = new List<HealthDetail>
        {
            new HealthDetail                                                               // Health1
            {
                weightInKg =
                            string.IsNullOrEmpty(Txt1stLifeWeight.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt1stLifeWeight.Text),

                heightInFeet =
                string.IsNullOrEmpty(Txt1stLifeHeightInfeet.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt1stLifeHeightInfeet.Text),


                covidQue1 = string.IsNullOrEmpty(Life1AssuredCovidQuestion1.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion1.SelectedValue),
                covidQue2 = string.IsNullOrEmpty(Life1AssuredCovidQuestion2.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion2.SelectedValue),
                covidQue3 = string.IsNullOrEmpty(Life1AssuredCovidQuestion3.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion3.SelectedValue),
                covidQue4 = string.IsNullOrEmpty(Life1AssuredCovidQuestion4.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion4.SelectedValue),
                covidQue5 = string.IsNullOrEmpty(Life1AssuredCovidQuestion5.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion5.SelectedValue),
                covidQue3a = 1, //not added in ui
                covidQue6 = string.IsNullOrEmpty(Life1AssuredCovidQuestion6.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion5.SelectedValue),
                covidQue7 = string.IsNullOrEmpty(Life1AssuredCovidQuestion7.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion5.SelectedValue),
                covidQue8 = string.IsNullOrEmpty(Life1AssuredCovidQuestion8.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion5.SelectedValue),
                covidQue9 = string.IsNullOrEmpty(Life1AssuredCovidQuestion9.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion5.SelectedValue),
                heightInInches =
                string.IsNullOrEmpty(Txt1stLifeHeightInInches.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt1stLifeHeightInInches.Text),
                covidQue5a = 1,
                covidQue10=1,
                covidQue10a=1,
                SQ = "0",
                medicalQue8 = string.IsNullOrEmpty(Life1AssuredMedQuestion8.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion8.SelectedValue),
                medicalQue9 = string.IsNullOrEmpty(Life1AssuredMedQuestion9.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion9.SelectedValue),
              medicalQue1 = string.IsNullOrEmpty(Life1AssuredMedQuestion1.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion1.SelectedValue),

            medicalQue2 =string.IsNullOrEmpty(Life1AssuredMedQuestion2.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion2.SelectedValue),
                medicalQue3 = string.IsNullOrEmpty(Life1AssuredMedQuestion3.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion3.SelectedValue),
                medicalQue4 = string.IsNullOrEmpty(Life1AssuredMedQuestion4.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion4.SelectedValue),
                medicalQue5 = string.IsNullOrEmpty(Life1AssuredMedQuestion5.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion5.SelectedValue),
                medicalQue6 = string.IsNullOrEmpty(Life1AssuredMedQuestion6.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion6.SelectedValue),
                medicalQue7 = string.IsNullOrEmpty(Life1AssuredMedQuestion7.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion7.SelectedValue),
                medicalQue10 = string.IsNullOrEmpty(Life1AssuredMedQuestion10.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredMedQuestion10.SelectedValue)
            },
            new HealthDetail                                                   // health 2
            {
                weightInKg =
                string.IsNullOrEmpty(Txt2LifeWeightInkg.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt2LifeWeightInkg.Text),
                heightInFeet =
                string.IsNullOrEmpty(Txt2LifeHeightInfeet.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt2LifeHeightInfeet.Text),
                covidQue1 = string.IsNullOrEmpty(Life2AssuredCovidQuestion1.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion1.SelectedValue),
                covidQue2 = string.IsNullOrEmpty(Life2AssuredCovidQuestion2.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life1AssuredCovidQuestion2.SelectedValue),
                covidQue3 = string.IsNullOrEmpty(Life2AssuredCovidQuestion3.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredCovidQuestion3.SelectedValue),
                covidQue4 = string.IsNullOrEmpty(Life2AssuredCovidQuestion4.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredCovidQuestion4.SelectedValue),
                covidQue5 = string.IsNullOrEmpty(Life2AssuredCovidQuestion5.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredCovidQuestion5.SelectedValue),
                covidQue3a = 1, //not in ui
                covidQue6 = string.IsNullOrEmpty(Life2AssuredCovidQuestion6.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredCovidQuestion6.SelectedValue),
                covidQue7 = string.IsNullOrEmpty(Life2AssuredCovidQuestion7.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredCovidQuestion7.SelectedValue),
                covidQue8 = string.IsNullOrEmpty(Life2AssuredCovidQuestion8.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredCovidQuestion8.SelectedValue),
                covidQue9 = string.IsNullOrEmpty(Life2AssuredCovidQuestion9.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredCovidQuestion9.SelectedValue),
                heightInInches =
                string.IsNullOrEmpty(Txt2LifeHeightInInches.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt2LifeHeightInInches.Text),
                covidQue10=1,
                covidQue10a=1,
                covidQue5a = 1,
                SQ = "1",
                medicalQue8 = string.IsNullOrEmpty(Life2AssuredMedicalQuestion8.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion8.SelectedValue),
                medicalQue9 = string.IsNullOrEmpty(Life2AssuredMedicalQuestion9.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion9.SelectedValue),
                medicalQue1 = string.IsNullOrEmpty(Life2AssuredMedicalQuestion1.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion1.SelectedValue),
                medicalQue2 = string.IsNullOrEmpty(Life2AssuredMedicalQuestion2.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion2.SelectedValue),
                medicalQue3 =string.IsNullOrEmpty(Life2AssuredMedicalQuestion3.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion3.SelectedValue),
                medicalQue4 = string.IsNullOrEmpty(Life2AssuredMedicalQuestion4.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion4.SelectedValue),
                medicalQue5 =string.IsNullOrEmpty(Life2AssuredMedicalQuestion5.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion5.SelectedValue),
                medicalQue6 = string.IsNullOrEmpty(Life2AssuredMedicalQuestion6.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion6.SelectedValue),
                medicalQue7 = string.IsNullOrEmpty(Life2AssuredMedicalQuestion7.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion7.SelectedValue),
                medicalQue10 = string.IsNullOrEmpty(Life2AssuredMedicalQuestion10.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life2AssuredMedicalQuestion10.SelectedValue),
            },
            new HealthDetail                          // Health 3
            {
        covidQue10=1,

        weightInKg=
        string.IsNullOrEmpty(Txt3LifeWeightInKg.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt3LifeWeightInKg.Text),

        heightInFeet=
        string.IsNullOrEmpty(Txt3LifeHeightInfeet.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt3LifeHeightInfeet.Text),
        covidQue1 =null,
        covidQue2= null,
        covidQue3= null,
        covidQue4= null,
        covidQue3a= 1,
        covidQue5= null,
        covidQue6= null,
        covidQue7= null,
        covidQue8= null,
        covidQue9= null,
        heightInInches=
        string.IsNullOrEmpty(Txt3LifeHeightInInches.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt3LifeHeightInInches.Text),
        covidQue10a= 1,
        covidQue5a= 1,
        SQ= "2",
        medicalQue8= null,
        medicalQue9= null,
        medicalQue1= string.IsNullOrEmpty(Life3AssuredMedicalQuestion1.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life3AssuredMedicalQuestion1.SelectedValue),
        medicalQue2= string.IsNullOrEmpty(Life3AssuredMedicalQuestion2.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life3AssuredMedicalQuestion2.SelectedValue),
        medicalQue3= string.IsNullOrEmpty(Life3AssuredMedicalQuestion3.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life3AssuredMedicalQuestion3.SelectedValue),
        medicalQue4= string.IsNullOrEmpty(Life3AssuredMedicalQuestion4.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life3AssuredMedicalQuestion4.SelectedValue),
        medicalQue5= string.IsNullOrEmpty(Life3AssuredMedicalQuestion5.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life3AssuredMedicalQuestion5.SelectedValue),
        medicalQue6= string.IsNullOrEmpty(Life3AssuredMedicalQuestion6.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life3AssuredMedicalQuestion6.SelectedValue),
        medicalQue10= string.IsNullOrEmpty(Life3AssuredMedicalQuestion10.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life3AssuredMedicalQuestion10.SelectedValue),
        medicalQue7= string.IsNullOrEmpty(Life3AssuredMedicalQuestion7.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life3AssuredMedicalQuestion7.SelectedValue)
        },

         new HealthDetail                                     // Health 4
        {
        weightInKg=
        string.IsNullOrEmpty(Txt4LifeWeightInKg.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt4LifeWeightInKg.Text),

        covidQue10=1,
        heightInFeet=
        string.IsNullOrEmpty(Txt4LifeHeightInfeet.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt4LifeHeightInfeet.Text),

        covidQue1=string.IsNullOrEmpty(Life4AssuredCovidQuestion1.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion1.SelectedValue),
        covidQue2=string.IsNullOrEmpty(Life4AssuredCovidQuestion2.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion2.SelectedValue),
        covidQue3=string.IsNullOrEmpty(Life4AssuredCovidQuestion3.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion3.SelectedValue),
        covidQue4=string.IsNullOrEmpty(Life4AssuredCovidQuestion4.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion4.SelectedValue),
        covidQue3a=1,
        covidQue5=string.IsNullOrEmpty(Life4AssuredCovidQuestion5.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion5.SelectedValue),
        covidQue6=string.IsNullOrEmpty(Life4AssuredCovidQuestion6.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion6.SelectedValue),
        covidQue7=string.IsNullOrEmpty(Life4AssuredCovidQuestion7.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion7.SelectedValue),
        covidQue8=string.IsNullOrEmpty(Life4AssuredCovidQuestion8.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion8.SelectedValue),
        covidQue9=string.IsNullOrEmpty(Life4AssuredCovidQuestion9.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredCovidQuestion9.SelectedValue),
        heightInInches=
         string.IsNullOrEmpty(Txt4LifeHeightInInches.Text)
    ? (double?)null
    : (double?)Convert.ToDouble(Txt4LifeHeightInInches.Text),
        covidQue5a=1,
        covidQue10a=1,
        SQ="3",
        medicalQue8=string.IsNullOrEmpty(Life4AssuredMedicalQuestion8.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion8.SelectedValue),
        medicalQue9=string.IsNullOrEmpty(Life4AssuredMedicalQuestion9.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion9.SelectedValue),
        medicalQue1=string.IsNullOrEmpty(Life4AssuredMedicalQuestion1.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion1.SelectedValue),
        medicalQue2=string.IsNullOrEmpty(Life4AssuredMedicalQuestion2.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion2.SelectedValue),
        medicalQue3=string.IsNullOrEmpty(Life4AssuredMedicalQuestion3.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion3.SelectedValue),
        medicalQue4=string.IsNullOrEmpty(Life4AssuredMedicalQuestion4.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion4.SelectedValue),
        medicalQue5=string.IsNullOrEmpty(Life4AssuredMedicalQuestion5.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion5.SelectedValue),
        medicalQue6=string.IsNullOrEmpty(Life4AssuredMedicalQuestion6.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion6.SelectedValue),
        medicalQue10=string.IsNullOrEmpty(Life4AssuredMedicalQuestion10.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion10.SelectedValue),
        medicalQue7=string.IsNullOrEmpty(Life4AssuredMedicalQuestion7.SelectedValue)
    ? (int?)null
    : (int?)Convert.ToInt32(Life4AssuredMedicalQuestion7.SelectedValue),
        }
        };

            string Helobjjson = JsonConvert.SerializeObject(healthDetails, Formatting.Indented);
            Lobj.healthDetails = healthDetails; // add for test

            List<AppointeeDetail> appointeeDetails = new List<AppointeeDetail>
            {
                 new AppointeeDetail
                 {
               relationship = App1RelationDropDownList76.SelectedValue,
               middleName =  TxtaPP1MiddleName.Text,
               lastName = Txtapp1LastName.Text,
               age = string.IsNullOrEmpty(Txtapp1Age.Text) ? 0 :Convert.ToInt32(Txtapp1Age.Text),
               dob = Txtapp1DateofBirth.Text,
               gender = App1GenderDropDownList75.SelectedValue,
               firstName = Txtapp1Name.Text,
               salutation =app1SalutationDropDownList74.Text,
               SQ = "0"
               },

                 new AppointeeDetail
                 {
               relationship = App2RelationDropDownList88.SelectedValue,
               middleName =  TxtaPP2MiddleName.Text,
               lastName = Txtapp2LastName.Text,
               age = string.IsNullOrEmpty(Txtapp2Age.Text) ? 0 :Convert.ToInt32(Txtapp2Age.Text),
               dob = Txtapp2DateofBirth.Text,
               gender =App2GenderDropDownList87.SelectedValue,
               firstName = Txtapp2Name.Text,
               salutation =app2SalutationDropDownList86.SelectedValue,
               SQ = "1"
                 },

                  new AppointeeDetail
                 {
               relationship = App3RelationDropDownList91.SelectedValue,
               middleName =  TxtaPP3MiddleName.Text,
               lastName = Txtapp3LastName.Text,
               age = string.IsNullOrEmpty(Txtapp3Age.Text) ? 0 :Convert.ToInt32(Txtapp3Age.Text),
               dob = Txtapp3DateofBirth.Text,
               gender =App3GenderDropDownList90.SelectedValue,
               firstName = Txtapp3Name.Text,
               salutation =app3SalutationDropDownList89.SelectedValue,
               SQ = "2"
                 },

                     new AppointeeDetail
                 {
               relationship = App4RelationDropDownList94.SelectedValue,
               middleName =  TxtaPP4MiddleName.Text,
               lastName = Txtapp4LastName.Text,
               age = string.IsNullOrEmpty(Txtapp4Age.Text) ? 0 :Convert.ToInt32(Txtapp4Age.Text),
               dob = Txtapp4DateofBirth.Text,
               gender =App4GenderDropDownList93.SelectedValue,
               firstName = Txtapp4Name.Text,
               salutation =app4SalutationDropDownList92.SelectedValue,
               SQ = "3"
                 }
            };
            string AppointeeJson = JsonConvert.SerializeObject(appointeeDetails, Formatting.Indented);

            Lobj.appointeeDetails = appointeeDetails; //add for test

            

            List<PersonalDetail> personalDetails = new List<PersonalDetail>
        {
            new PersonalDetail
            {
        middleName=Txt1perDetMiddleName.Text,
        lastName=Txt1perDetLastName.Text,
        occupation=Txt1perDetOccupation.Text,
        state=PD1StateDropDownList39.SelectedValue,
        address1=Txt1perDetAddress1.Text,
        address2=Txt1perDetAddress2.Text,
        natureOfDuties=Txt1perDetNatureOfDuties.Text,
        address3=Txt1perDetAddress1.Text,
        panNumber=Txt1perDetPanNumber.Text,
        SQ= "0",
        city=Txt1perDetCity.Text,
        pincode=Txt1perDetPincode.Text,
        email=Txt1perDetEmail.Text,
        age=Txt1perDetAge.Text,
        dob=Txt1perDetDateofBirth.Text,
        gender=PdDet1_Gender_DropDownList38.SelectedValue,
        mobileNumber=Txt1perDetMobileNo.Text,
        firstName=Txt1perDetFirstName.Text,
        salutation=PD1SalutationDropDownList37.SelectedValue,
        nsdlPanStatus="Y",
        numberOfLifesToBeCovered=Convert.ToInt32(PD1NoofLifeCoveredDropDownList44.SelectedValue),
        jointLifeOption=Convert.ToBoolean(PD1JointLifeOptionDropDownList40.SelectedValue),
        jointLifeBasis = PD1JointLifeBasisDropDownList41.SelectedValue

            },
            //2
            new PersonalDetail
                {
        middleName=Txt2perDetMiddleName.Text,
        lastName=Txt2perDetLastName.Text,
        occupation=Txt2perDetOccupation.Text,
        state=PD2StateDropDownList47.SelectedValue, 
        address1=Txt2perDetAddress1.Text,
        address2=Txt2perDetAddress2.Text,
        natureOfDuties=Txt2perDetNatureOfDuties.Text,
        address3=Txt2perDetAddress1.Text,
        panNumber=Txt2perDetPanNumber.Text,
        SQ= "1",
        city=Txt2perDetCity.Text,
        pincode=Txt2perDetPincode.Text,
        email=Txt2perDetEmail.Text,
        age=Txt2perDetAge.Text,
        dob=Txt2perDetDateofBirth.Text,
        gender=PdDet2s_Gender_DropDownList46.SelectedValue,
        mobileNumber=Txt2perDetMobileNo.Text,
        firstName=Txt2perDetFirstName.Text,
        salutation=PD2SalutationDropDownList45.SelectedValue,
        nsdlPanStatus="Y"
        },
            new PersonalDetail
                {
        middleName=Txt2perDetMiddleName.Text,
        lastName=Txt2perDetLastName.Text,
        occupation=Txt2perDetOccupation.Text,
        state=DropDownList55.SelectedValue,
        address1=Txt2perDetAddress1.Text,
        address2=Txt2perDetAddress2.Text,
        natureOfDuties=Txt2perDetNatureOfDuties.Text,
        address3=Txt2perDetAddress1.Text,
        panNumber=Txt2perDetPanNumber.Text,
        SQ= "2",
        city=Txt2perDetCity.Text,
        pincode=Txt2perDetPincode.Text,
        email=Txt2perDetEmail.Text,
        age=Txt2perDetAge.Text,
        dob=Txt2perDetDateofBirth.Text,
        gender=PdDet2s_Gender_DropDownList46.SelectedValue,
        mobileNumber=Txt2perDetMobileNo.Text,
        firstName=Txt2perDetFirstName.Text,
        salutation=PD2SalutationDropDownList45.SelectedValue,
        nsdlPanStatus="Y"
        },
        new PersonalDetail
                {
        middleName=Txt2perDetMiddleName.Text,
        lastName=Txt2perDetLastName.Text,
        occupation=Txt2perDetOccupation.Text,
        state=DropDownList63.SelectedValue,
        address1=Txt2perDetAddress1.Text,
        address2=Txt2perDetAddress2.Text,
        natureOfDuties=Txt2perDetNatureOfDuties.Text,
        address3=Txt2perDetAddress1.Text,
        panNumber=Txt2perDetPanNumber.Text,
        SQ= "3",
        city=Txt2perDetCity.Text,
        pincode=Txt2perDetPincode.Text,
        email=Txt2perDetEmail.Text,
        age=Txt2perDetAge.Text,
        dob=Txt2perDetDateofBirth.Text,
        gender=PdDet2s_Gender_DropDownList46.SelectedValue,
        mobileNumber=Txt2perDetMobileNo.Text,
        firstName=Txt2perDetFirstName.Text,
        salutation=PD2SalutationDropDownList45.SelectedValue,
        nsdlPanStatus="Y"
        },

    };

            //string PersonalDetailsJson = JsonConvert.SerializeObject(personalDetails, Formatting.Indented);

            int selectedValue = int.Parse(PD1NoofLifeCoveredDropDownList44.SelectedValue);
            //List<PersonalDetail> personalDetails = new List<PersonalDetail>();

            if (selectedValue == 0 && selectedValue < personalDetails.Count)
            {
                personalDetails.RemoveAt(3); // Remove index 3 first
                personalDetails.RemoveAt(2); // Then index 2
                personalDetails.RemoveAt(1); // Then index 1

                healthDetails.RemoveAt(3); // Remove index 3 first
                healthDetails.RemoveAt(2); // Then index 2
                healthDetails.RemoveAt(1); // Then index 1

            }

            if (selectedValue == 1 && selectedValue < personalDetails.Count)
            {
                
                personalDetails.Remove(personalDetails[3]);
                personalDetails.Remove(personalDetails[2]);

                healthDetails.Remove(healthDetails[3]);
                healthDetails.Remove(healthDetails[2]);

            }

            if (selectedValue == 2 && selectedValue < personalDetails.Count)
            {
                personalDetails.Remove(personalDetails[3]);
                healthDetails.Remove(healthDetails[3]);
            }


            string PersonalDetailsJson = JsonConvert.SerializeObject(personalDetails, Formatting.Indented);

            Lobj.personalDetails = personalDetails; //add for test
            string LlpsRequestPayload = JsonConvert.SerializeObject(Lobj, Formatting.Indented);


            string json = "{\"llpsPlanDataRequest\":" + LlpsRequestPayload + "}";

            // var jsonBody = serializer.Serialize(requestBodyToCallApi);
            //var data = Encoding.UTF8.GetBytes(jsonBody);
          //  var serializer = new JavaScriptSerializer();
           // var jsonBody = serializer.Serialize(json);
            var data = Encoding.UTF8.GetBytes(json);
            WriteLogs("RequestBodyToCall--LLPSAPI: " + json);
            var tokenUrl = "http://10.1.10.20:8080/llpsplan_data/saveLlpsPlanData";
            // Create the request
            var request = (HttpWebRequest)WebRequest.Create(tokenUrl);
           request.Method = "POST";
           request.ContentType = "application/json"; // Ensure Content-Type is correct

            // Send the request and get the response
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    WriteLogs("stream: " + stream);
                }

                // Send the request and get the response
                string responseBody;
                //WriteLogs("before response: ");
                using (var response = (HttpWebResponse)request.GetResponse())

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {

                    responseBody = streamReader.ReadToEnd();
                    WriteLogs("After response: " + responseBody);
                    WriteLogs("--------------------------------------------------------");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "confirmMsg()", true);
                }

            }
        catch (WebException ex)
            {
                WriteLogs("Error ex message: " + ex.Message);
                using (var response = (HttpWebResponse)ex.Response)
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string errorResponse = reader.ReadToEnd();
                     
                     WriteLogs("Error: " + errorResponse);
                    // return errorResponse;
                }
            }

        }

        protected void PD1JointLifeOptionDropDownList40_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;

            // Enable or disable the dependent dropdown based on selection
            if (ddl.SelectedValue == "true") // If "Yes" is selected
            {
                PD1JointLifeBasisDropDownList41.Enabled = true;
            }
            else if (ddl.SelectedValue == "false") // If "Yes" is selected
            {
                PD1JointLifeBasisDropDownList41.Enabled = false;
            }
          
        }


        //protected void SalutationDropDownList11_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (SalutationDropDownList11.SelectedValue == "select")
        //    {
        //        Txt1stNominee_Name.Enabled = false;
        //        Txt1stNominee_MiddleName.Enabled = false;
        //        Txt1stNominee_LastName.Enabled = false;
        //        GenderDropDownList24.Enabled = false;
        //        Txt1stNominee_DateofBirth.Enabled = false;
        //        RelationDropDownList25.Enabled = false;
        //        Txt1stNominee_PercentageofEntitlementonlyincaseofNominee.Enabled = false;
        //        Txt1stNomineeMobileNumber.Enabled = false;

        //        Nominee1rfvName.Enabled = false;
        //        Nominee1rfvMiddleName.Enabled = false;
        //        Nominee1rfvLastName.Enabled = false;
        //        Nominee1rfvGender.Enabled = false;
        //        Nominee1rfvDob.Enabled = false;
        //        Nominee1rfvRelation.Enabled = false;
        //        Nominee1rfvPercentage.Enabled = false;
        //        Nominee1rfvMobileNumber.Enabled = false;
        //    }
        //    else
        //    {
        //        bool isEnabled = !string.IsNullOrEmpty(SalutationDropDownList11.SelectedValue);

        //        Txt1stNominee_Name.Enabled = isEnabled;
        //        Txt1stNominee_MiddleName.Enabled = isEnabled;
        //        Txt1stNominee_LastName.Enabled = isEnabled;
        //        GenderDropDownList24.Enabled = isEnabled;
        //        Txt1stNominee_DateofBirth.Enabled = isEnabled;
        //        RelationDropDownList25.Enabled = isEnabled;
        //        Txt1stNominee_PercentageofEntitlementonlyincaseofNominee.Enabled = isEnabled;
        //        Txt1stNomineeMobileNumber.Enabled = isEnabled;
        //        // Set other textboxes similarly

        //        Nominee1rfvName.Enabled = isEnabled;
        //        Nominee1rfvMiddleName.Enabled = isEnabled;
        //        Nominee1rfvLastName.Enabled = isEnabled;
        //        Nominee1rfvGender.Enabled = isEnabled;
        //        Nominee1rfvDob.Enabled = isEnabled;
        //        Nominee1rfvRelation.Enabled = isEnabled;
        //        Nominee1rfvPercentage.Enabled = isEnabled;
        //        Nominee1rfvMobileNumber.Enabled = isEnabled;
        //    }

        //}

        public void GetAllClients()
        {
            PolicyInformationBAL policyInformationBAL_AppForm = new PolicyInformationBAL();
            int? sUserUID = null;
            int? sApplicationUID = null;
            try
            {

              //  policyInformationBAL_AppForm = new PolicyInformationBAL();
                dsResults = new DataSet();
                dsResults = policyInformationBAL_AppForm.GetAllClients(sUserUID, sApplicationUID);
                //DdlClient.Items.Clear();
                if (dsResults.Tables[0].Rows.Count > 0)
                {
                    ExDetails exobj = new ExDetails();
                    DdlClient.DataTextField = "ClientName";
                    DdlClient.DataValueField = "ClientUID";
                    DdlClient.DataSource = dsResults.Tables[0].DefaultView;
                    DdlClient.DataBind();
                    DdlClient.Items.Insert(0, new ListItem("Select Client Name", ""));
                    LabelClientcode.Text = dsResults.Tables[0].Rows[0]["clientCode"].ToString();
                    //LabelPolicyNumber.Text = dsResults.Tables[0].Rows[0]["PolicyNumber"].ToString();

                }
                else
                {
                   DdlClient.Items.Insert(0, new ListItem("NoRecords", "0"));
                }
            }
            catch (Exception ex)
            {
               
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void DdlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 sUserUID = 0;
            Int16 sApplicationUID = 0;
            try
            {
                DdlPolicyNo.Items.Clear();
                if (DdlClient.SelectedIndex > 0)
                {
                    policyInformationBAL_AppForm = new PolicyInformationBAL();
                    dsResults = new DataSet();
                    dsResults = policyInformationBAL_AppForm.GetAllPolicyByClientUID(Convert.ToInt64(DdlClient.SelectedValue), sUserUID, sApplicationUID);
                    if (dsResults.Tables[0].Rows.Count > 0)
                    {
                        DdlPolicyNo.DataTextField = "PolicyNumber";
                        DdlPolicyNo.DataValueField = "PolicyNumber";
                        DdlPolicyNo.DataSource = dsResults.Tables[0].DefaultView;
                        DdlPolicyNo.DataBind();
                        DdlPolicyNo.Items.Insert(0, new ListItem("Policy Number", ""));
                    }
                    else
                    {
                        DdlPolicyNo.Items.Insert(0, new ListItem("No Records", "0"));
                    }
                }
                else
                {
                    DdlPolicyNo.Items.Insert(0, new ListItem("No Records", "0"));
                }

                //DdlClient.SelectedIndex=0
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
    }
}
//reference    string data = "{\"inputData\":" + json + "}";
//string.IsNullOrEmpty() ? 0 : Convert.ToInt32(Txt4thNomineeAge.Text);


// Note:  1) InsloandObj.staff = true;  bool values is hardcoded
//2)Planobj.staffFlag = true;

// sq2 --- 3a,5a
//sq3    ---3a,5a
//sq1   --- 3a,5a,10,10a
//sq0   ---
