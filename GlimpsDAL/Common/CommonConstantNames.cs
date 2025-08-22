using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data.SqlClient;
using GlimpsDAL.Common;
using System.Data;

namespace GlimpsDAL
{
    /*Connection String Starts*/
    enum ConnectionType
    {
        AppDb = 0,
        TermDB = 1,
        Credit = 2
    }

    public enum ProcedureAction
    {
        A, E, D, I, U, S, R, F, M, C, SU, UR, W, T, CU, APPROVE
    };
    public class CommonConstantNames
    {

        public const string EasyAdmin_Process = "Easy Admin";
        public const string Upload = "Upload";
        /*END*/
        /*Policy Information STARTS*/
        public const string Action = "DISPLAY";
        public const string sCircle_UID = "CircleUID";

        public const string SQL_ERROR_CODE = "2627";
        public const string USERUID = "UserUID";
        public const string USERNAME = "UserName";
        public const string NAME = "Name";
        public const string SUBOFFICEUID = "SubOfficeUID";
       // public const string POLICYUID = "PolicyUID"; //ls
        public const string ISLOGGEDIN = "IsLoggedIn";
        public const string LOGGEDINDATE = "LoggedInDate";
        public const string PASSWORD = "Password";
        public const string USERID = "UserID";
        //public const string SUBOFFICEUID = "subOfficeUID";
        /*END*/
        /*MEMBER INFORMATION STARTS*/
        public const string POLICYUID = "PolicyUID";
        public const string RENEWALNOUID = "RenewalNoUID";
        public const string CLIENTUNITCODE = "ClientUnitCode";
        public const string CLIENTUNITNAME = "ClientUnitName";
        public const string REGIONNAME = "RegionName";
        public const string REGIONCODE = "Regioncode";
        public const string COI = "COI";
        public const string PRODUCTCODE = "ProductCode";
        public const string PRODTYPE = "ProdType";
        public const string BASEUNITNAME = "BaseUnitName";
        public const string SABENBASISCODE = "SABenBasisCode";
        public const string PREMIUMRATECODE = "PremiumRateCode";
        public const string NOEVIDENCELIMIT = "NoEvidenceLimit";
        public const string FSA = "FSA";
        public const string FSG = "FSG";
        public const string DTAPPLSIGNEDPROPOSEDINSURED = "Dtapplsignedproposedinsured";
        public const string CUSTOMERID = "CustomerID";
        public const string POLICYMEMBERUID = "PolicyMemberUID";
        public const string EMPLOYEENO = "EmployeeNo";
        public const string PANCARDNO = "PanCardNo";
        public const string IDENTITYCARDTYPECODE = "IdentityCardTypeCode";
        public const string IDENTIYCARDNUMBER = "IdentiyCardNumber";
        public const string DATEOFREQUESTRECEIVED = "DateOfRequestReceived";
        public const string DATEOFINTIMATION = "DateOfIntimation";
        public const string INITIALEFFECTIVEDATE = "InitialEffectiveDate";
        public const string CHANGEEFFECTIVEDATE = "ChangeEffectiveDate";
        public const string TERMINATIONDT = "Terminationdt";
        public const string MEMBERSTATUS = "MemberStatus";
        public const string AAWCONFIRMFLAG = "AAWConfirmFlag";
        public const string PROPOSEDTITLE = "ProposedTitle";
        public const string FIRSTNAME = "FirstName";
        public const string MIDDLENAME = "MiddleName";
        public const string LASTNAME = "LastName";
        public const string ADDRESS1 = "Address1";
        public const string ADDRESS2 = "Address2";
        public const string ADDRESS3 = "Address2";
        public const string ADDRESS4 = "Address2";
        public const string COUNTRYRESIDENCECODE = "CountryResidenceCode";
        public const string STATECODE = "StateCode";
        public const string CITYCODE = "CityCode";
        public const string PINCODE = "Pincode";
        public const string PHONE = "Phone";
        public const string PHONENO1 = "PhoneNo1";
        public const string EMAILID = "Emailid";
        public const string GENDER = "Gender";
        public const string DOB = "DOB";
        public const string INSUREDAGE = "InsuredAge";
        public const string NATIONALITYCODE = "NationalityCode";
        public const string MARITALSTATUSCODE = "MaritalStatusCode";
        public const string PAYEENAME = "PayeeName";
        public const string BANKCODE = "BankCode";
        public const string BANKACCOUNT = "BankAccount";
        public const string HEIGHT = "Height";
        public const string WEIGHT = "Weight";
        public const string BMI = "BMI";
        public const string SMOKERAPPFLAG = "SmokerAppFlag";
        public const string FAMILYPHYSICIANTITLE = "FamilyPhysicianTitle";
        public const string FAMILYPHYSICIANFNAME = "FamilyPhysicianFName";
        public const string FAMILYPHYSICIANMNAME = "FamilyPhysicianMName";
        public const string FAMILYPHYSICIANLNAME = "FamilyPhysicianLName";
        public const string FAMILYPHYSICIANADD1 = "FamilyPhysicianAdd1";
        public const string FAMILYPHYSICIANPHONE = "FamilyPhysicianPhone";
        public const string FAMILYPHYSICIANMOBILE = "FamilyPhysicianMobile";
        public const string DEPARTMENTCODE = "DepartmentCode";
        public const string DESIGNATIONCODE = "DesignationCode";
        public const string MONTHLYSAL = "MonthlySal";
        public const string ANNUALINCOME = "AnnualIncome";
        public const string OCCUPATIONCODE = "OccupationCode";
        public const string OCCUPATIONNAME = "OccupationName";
        public const string OCCUPATIONCLASS = "OccupationClass";
        public const string EMPLOYMENTDATE = "EmploymentDate";
        public const string NATUREOFDUTIES = "NatureofDuties";
        public const string EMPLOYERSNAME = "EmployersName";
        public const string ALLQUESTIONSFLAG = "AllQuestionsFlag";
        public const string ANYQUESTIONSFLAG = "AnyQuestionsFlag";
        public const string RIDERUID = "RiderUID";
        public const string RIDERNAME = "RiderName";
        public const string BENEFITTYPE = "BenefitType";
        public const string sXmlData = "sXmlData";

        /*END*/
        /*MEMBER INFORMATION DETAILS STARTS*/
        public const string STATE = "State";
        public const string CITY = "City";
        public const string NATIONALITY = "Nationality";
        public const string SALEMANAGER = "SaleManager";
        public const string ZONE = "Zone";


        public const string SALESMNGRUID = "SalesMngrUID";
        /*END*/

        /*BILLING INFO STARTS*/
        public const string CLIENTNAME = "ClientName";
        public const string POLICYNUMBER = "PolicyNumber";
        public const string SUB_OFFICE_NAME = "Sub_Office_Name";
        public const string TRMPOLICYFLOATSUSPENSEAMTSUBOFFICEWISE = "TRMPOLICYFLOATSUSPENSEAMTSUBOFFICEWISE";

        /*END*/

        /*LS Pace CreditLife Start*/

        public const string MEMBER_ADDITION_Cr = "MemAdd_cr";
        public const string MEMBER_DELETION_Cr = "MemDel_Cr";
        /*end*/


        /* Start Credit Life */
        public const string TRMSALARY_cr = "TRMSalary_cr";
        public const string TRMFSA_cr = "TRMFSA_cr";
        public const string TRMFSG_cr = "TRMFSG_cr";
        public const string TRMDesignt_cr = "TRMDesignt_cr";
        public const string SERVICE_NAME_cr = "TRMName_cr";
        public const string SERVICE_EMPNO_cr = "TRMEmpNo_cr";
        public const string SERVICE_DOB_cr = "DOB";
        public const string SERVICE_GEN_cr = "TRMGender_cr";
        /* End */


        /*SERVICING*/
        public const string SERVICING_CHANGE_NAME = "SERVICINGCHANGENAME";
        public const string POL_SERVICING_CHANGE_NAME = "PolServicingChangeName";
        public const string POL_SERVICING_CHANGE_CODE = "PolServicingChangeCode";
        public const string BILLUID = "BillUID";
        public const string MEMBER_ADDITION = "TRMMemAdd";
        public const string MEMBER_DELETION = "TRMMemDel";
        public const string DATASET = "Dataset";
        public const string DROPDOWNLISTDATA = "DropDownListData";
        public const string TRANSACTIONID = "TransactionID";
        public const string BIRTHDATE = "Birthdate";
        public const string PROPOSEDFIRSTNAME = "ProposedFirstName";
        public const string SCHEMEJOININGDATE = "SchemeJoiningDate";
        public const string SUBOFFICECODE = "SubofficeCode";
        public const string TRMSALARY = "TRMSalary";
        public const string TRMFSA = "TRMFSA";
        public const string TRMFSG = "TRMFSG";
        public const string TRMDesignt = "TRMDesignt";
        public const string POLSERVICINGCHANGEUID = "PolServicingChangeUID";
        public const string REQUESTDATE = "RequestDate";
        public const string ROWNUMBER = "RowNumber";
        public const string SERVICE_NAME = "TRMName";
        public const string SERVICE_DOB = "TRMDOB";
        public const string SERVICE_EMPNO = "TRMEmpNo";
        public const string SERVICE_GEN = "TRMGender";
        public const string PACESERVICING = "PaceServicing";
        public const string PACESUBCATSERVICING = "PACESUBCATSERVICINGCLR";
        public const string COMMONLISTUID = "CommonListUID";
        public const string COMMONLISTNAME = "CommonListName";


        public const string Client_Code = "ClientCode";
        public const string Client_Name = "ClientName";
        /*END*/

    }
    public class CommonMethods
    {
        public static string DisplayErrorMsg(Exception ex)
        {
            StringBuilder StrDisMsg = new StringBuilder();
            StackTrace st = new StackTrace(ex, true);
            string exMessage = null;

            StrDisMsg.Append(ex.Message);
            // StrDisMsg.Append(st.GetFrame(1).GetFileName().ToString());
            //  StrDisMsg.Append(" Line No : " + st.GetFrame(1).GetFileLineNumber().ToString());
            StrDisMsg.Append(" Line No : " + st.GetFrame(st.FrameCount - 1).GetFileLineNumber().ToString());


            exMessage = StrDisMsg.ToString();

            exMessage = exMessage.Replace("'", " ");
            exMessage = exMessage.Replace("\n", " ");
            exMessage = exMessage.Replace("\r", " ");

            return exMessage;
        }
        public static DataSet InsertingPageInfo(string action, string UserUID,string PageName)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = null;
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                //SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_BACKEND_CONTROL_MONITORING_WEB, con);  //commented by Sanket on 8/8/2025
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_Backend_Control_Monitoring_Web_PACE, con);  //added by Sanket on 8/8/2025
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.action, action);
                cmd.Parameters.AddWithValue("@ControlName", PageName);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //LS
        public static DataSet InsertingPageInfo_cr(string action, string UserUID, string PageName)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = null;
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                //SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_BACKEND_CONTROL_MONITORING_WEB, con);
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_BACKEND_CONTROL_MONITORING_WEB_Pace, con);
                //TRM_Proc_Backend_Control_Monitoring_Web_PACE
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.action, action);
                cmd.Parameters.AddWithValue("@ControlName", PageName);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //LS
        public static DataTable DisplayMessageForBanner_cr(string UserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = null;
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.action, "BANNER");
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, string.Empty);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds.Tables[0];
        }

        public static DataTable DisplayMessageForBanner( string UserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = null;
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_MASTER_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.action, "BANNER");
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, string.Empty);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds.Tables[0];
        }
    }
}
