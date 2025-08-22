using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using System.Data;

namespace GlimpsBAL
{
    public class PolicyInformationBAL
    {
        PolicyInformationDAL PolicyInformationDAL_AppForm = new PolicyInformationDAL();
        public DataSet GetAllClients(int? sUserUID, int? sApplicationUID)     //ramesh 18/02/2025
        {
            try
            {
                string XmlData = "<params><param><ClientUID></ClientUID></param></params>";
                string searchCriteria = "Client";
                return PolicyInformationDAL.GetAllClients(XmlData, searchCriteria, sUserUID, sApplicationUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllPolicyByClientUID(Int64 clientUID, Int16 sUserUID, Int16 sApplicationUID)
        {
            try
            {
                string XmlData = "<params><param><ClientUID>" + clientUID + "</ClientUID></param></params>";
                string searchCriteria = "Clientpolicy";
                return PolicyInformationDAL.GetAllPolicyByClientUID(XmlData, searchCriteria, sUserUID, sApplicationUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PolicyInformationDetails(string UserUID, string SubOfficeUID)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();
            string XmlData = "<params><param><UserUID>" + UserUID + "</UserUID></param></params>";

            return policyInformationDAL.PolicyInformationDetails(XmlData, UserUID, SubOfficeUID);
            //return policyInformationDAL.PolicyInformationDetails(UserUID, SubOfficeUID);

        }
        //Ls fro Creadit
        public DataTable PolicyInformationDetails_cr(string UserUID, string SubOfficeUID)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();
            string XmlData = "<params><param><UserUID>" + UserUID + "</UserUID></param></params>";

            return policyInformationDAL.PolicyInformationDetails_cr(XmlData, UserUID, SubOfficeUID);
            //return policyInformationDAL.PolicyInformationDetails(UserUID, SubOfficeUID);

        }

        public DataTable PremiumRates(string UserUID)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = "<params><param><UserUID>" + UserUID + "</UserUID></param></params>";
            //string XmlData = "<params><param><UserUID>"+UserUID+"</UserUID></param></params>";

            return policyInformationDAL.PremiumRates(XmlData, "S", UserUID);

        }
        //LS
        public DataTable PremiumRates_cr(string UserUID)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = "<params><param><UserUID>" + UserUID + "</UserUID></param></params>";
            //string XmlData = "<params><param><UserUID>"+UserUID+"</UserUID></param></params>";

            return policyInformationDAL.PremiumRates_cr(XmlData, "S", UserUID);
            // return policyInformationDAL.PremiumRates(XmlData, "S", UserUID);
        }
        public DataTable BALNEL_cr(Int16 policyUID, string UserUID)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = "<params><param><Fk_PolicyUID>" + policyUID + "</Fk_PolicyUID></param></params>";
            //string XmlData = "<params><param><UserUID>"+UserUID+"</UserUID></param></params>";

            return policyInformationDAL.DALNEL_cr(XmlData, "S", UserUID);
            // return policyInformationDAL.PremiumRates(XmlData, "S", UserUID);
        }
        //For NeL  LS 
        public DataSet GetPolicyNonMedicalRevise_cr(int MedicalNonMedicalMappingUID, int userID)
        {
            try
            {
                PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

                string XmlData = "<params><param><MedicalNonMedicalMappingUID>" + MedicalNonMedicalMappingUID + "</MedicalNonMedicalMappingUID></param></params>";
                return policyInformationDAL.GetPolicyMedicalNonMedicalGrid_cr(XmlData,"" , userID); //CommonConstants.ProcedureAction.R.ToString()
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPolicyNonMedicalLimit_cr(string NMLCode, string Action, string userID)
        {
            try
            {
                PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

                string XmlData = "<params><param><NonMedicalLimitCode>" + NMLCode + "</NonMedicalLimitCode></param></params>";
                return policyInformationDAL.GetPolicyNonMedicalLimit_cr(XmlData, Action, userID); //CommonConstants.ProcedureAction.R.ToString()
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //ls
        public DataTable GetPolicySubOfficeAccess_cr(string UserUID, string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = string.Empty;
            //string XmlData = "<params><param><UserUID>"+UserUID+"</UserUID></param></params>";
            //return policyInformationDAL.GetPolicySubOfficeAccess(XmlData, Action, UserUID);
            return policyInformationDAL.GetPolicySubOfficeAccess_cr(XmlData, Action, UserUID);

        }
        public DataTable GetPolicySubOfficeAccess(string UserUID, string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = string.Empty;
            //string XmlData = "<params><param><UserUID>"+UserUID+"</UserUID></param></params>";

            return policyInformationDAL.GetPolicySubOfficeAccess(XmlData, Action, UserUID);

        }

        public int GetPolicySubOfficeAccessSelect(string UserUID, string UserClientUnitUID, string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = string.Empty;
            XmlData = "<params><param><UserClientUnitUID>" + UserClientUnitUID + "</UserClientUnitUID></param></params>";

            return policyInformationDAL.GetPolicySubOfficeAccessSelect(XmlData, Action, UserUID);

        }
        //LS GetPolicySubOfficeAccessSelect_Cr 
        public int GetPolicySubOfficeAccessSelect_Cr(string UserUID, string UserClientUnitUID, string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = string.Empty;
            XmlData = "<params><param><UserClientUnitUID>" + UserClientUnitUID + "</UserClientUnitUID></param></params>";

            return policyInformationDAL.GetPolicySubOfficeAccessSelect_cr(XmlData, Action, UserUID);
            //GetPolicySubOfficeAccessSelect_Cr
        }

        public DataSet GetBenifitBasis(string UserUID, string PlanMasterCode, string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = string.Empty;
            XmlData = "<params><param><PlanMasterCode>" + PlanMasterCode + "</PlanMasterCode></param></params>";

            return policyInformationDAL.GetBenifitBasis(XmlData, Action, UserUID);

        }

        //LS

        public DataSet GetBenifitBasis_cr(string UserUID, string PlanMasterCode, string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

            string XmlData = string.Empty;
            XmlData = "<params><param><PlanMasterCode>" + PlanMasterCode + "</PlanMasterCode></param></params>";
            return policyInformationDAL.GetBenifitBasis_cr(XmlData, Action, UserUID);
            //return policyInformationDAL.GetBenifitBasis(XmlData, Action, UserUID);

        }

        public DataTable GetPolicyQuoteListing(string UserUID, string action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();
            string XmlData = "<params><param><UserUID>" + UserUID + "</UserUID></param></params>";

            return policyInformationDAL.GetPolicyQuoteListing(XmlData, UserUID, action);
            //return policyInformationDAL.PolicyInformationDetails(UserUID, SubOfficeUID);

        }
        //ARCHIVAL FOR PHASE 2 10/10/2016
        public DataTable GetArchive(string UserUID, string PolicyYear, string PolicyDocumentUID, string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();
            string XmlData = "<params><param><PolicyYear>" + PolicyYear + "</PolicyYear><PolicyDocumentUID>" + PolicyDocumentUID + "</PolicyDocumentUID></param></params>";

            return policyInformationDAL.GetArchive(XmlData, UserUID, Action);
            //return policyInformationDAL.PolicyInformationDetails(UserUID, SubOfficeUID);

        }
        //Receipts and Payments FOR PHASE 2 10/10/2016
        public DataTable GetReceiptsandPaymentsDDL(string UserUID,  string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();
            return policyInformationDAL.GetReceiptsandPaymentsDDL( UserUID, Action);
            //return policyInformationDAL.PolicyInformationDetails(UserUID, SubOfficeUID);

        }
        //ls
        public DataTable GetReceiptsandPaymentsDDL_cr(string UserUID, string Action)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();
            return policyInformationDAL.GetReceiptsandPaymentsDDL_cr(UserUID, Action);
            //return policyInformationDAL.PolicyInformationDetails(UserUID, SubOfficeUID);

        }


        public DataSet GetReceiptsAndPaymentsGrid(string UserUID, string Action,string FromDate,string ToDate)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();
            string XmlData = "<params><param><FromDate>" + FromDate + "</FromDate><ToDate>" + ToDate + "</ToDate></param></params>";
            return policyInformationDAL.GetReceiptsAndPaymentsGrid(XmlData,UserUID, Action);
            //return policyInformationDAL.PolicyInformationDetails(UserUID, SubOfficeUID);

        }
        //LS
        public DataSet GetReceiptsAndPaymentsGrid_cr(string UserUID, string Action, string FromDate, string ToDate)
        {
            PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();
            string XmlData = "<params><param><FromDate>" + FromDate + "</FromDate><ToDate>" + ToDate + "</ToDate></param></params>";
            return policyInformationDAL.GetReceiptsAndPaymentsGrid_cr(XmlData, UserUID, Action);
            //return policyInformationDAL.PolicyInformationDetails(UserUID, SubOfficeUID);

        }

    }
}
