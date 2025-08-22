using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using System.Data;

namespace GlimpsBAL
{
    public class ReportingBAL
    {
        /// <summary>
        /// Gets the premium rate chart report.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataTable GetPremiumRateChartReport(string rateCode)
        {
            try
            {
                return ReportDAL.GetPremiumRateChartReport(rateCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Ls
        public DataTable GetPremiumRateChartReport_cr(string rateCode)
        {
            try
            {
                return ReportDAL.GetPremiumRateChartReport_cr(rateCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public DataSet GetDeclineLetterReport_cr(string MemberUID, int UserID)
        {
            try
            {


                string XML = string.Empty;
                XML += "<params><param>";
               // XML += "<BillUID>" + BillUID + "</BillUID>";
                XML += "</param></params>";
                string action = "Decline_Latter";
                return ReportDAL.DALGetDeclineLetterReport_cr(XML,action, MemberUID, UserID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetPostponeLetterReport_cr
        public DataSet GetPostponeLetterReport_cr(string MemberUID, int UserID)
        {
            try
            {


                string XML = string.Empty;
                XML += "<params><param>";
                // XML += "<BillUID>" + BillUID + "</BillUID>";
                XML += "</param></params>";
                string action = "Postpone_Latter";
                return ReportDAL.DALGetPostponeLetterReport_cr(XML, action, MemberUID, UserID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetMedicalReport_cr(string rateCode)
        {
            try
            {
                return ReportDAL.GetMedicalReport_cr(rateCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetNELChartReport(int  UserUID)
        {
            try
            {
                return ReportDAL.GetNELChartReport(UserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls
        public DataTable GetNELChartReport_cr(int UserUID)
        {
            try
            {
                return ReportDAL.GetNELChartReport_cr(UserUID);
                //return ReportDAL.GetNELChartReport(UserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetMedicalNonMedical(int UserUID)
        {
            try
            {
                return ReportDAL.GetMedicalNonMedical(UserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       //ls
        //public DataTable GetMedicalNonMedical_cr(int UserUID)
        //{
        //    PolicyInformationDAL policyInformationDAL = new PolicyInformationDAL();

        //    string XmlData = "<params><param><UserUID>" + UserUID + "</UserUID></param></params>";
        //   // return policyInformationDAL.GetMedicalNonMedical_cr(XmlData, "S", UserUID);
        //    // return policyInformationDAL.PremiumRates(XmlData, "S", UserUID);

        //    //try
        //    //{
        //      //  return ReportDAL.GetMedicalNonMedical_cr(UserUID);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}
        public DataSet GetBillReport(long BillUID, int UserUID)
        {
            try
            {

                string XML = string.Empty;
                XML += "<params><param>";
                XML += "<BillUID>" + BillUID + "</BillUID>";
                XML += "</param></params>";
                return ReportDAL.GetBillReport(XML,UserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMemberlisting(int UserUID,string PolicyYear)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                XML += "<PolicyYear>" + PolicyYear + "</PolicyYear>";
                XML += "</param></params>";
                return ReportDAL.GetMemberlisting(UserUID, XML, "MEMBERUPLOADLIST");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPremiumStatement(int UserUID,string XML)
        {
            try
            {
                return ReportDAL.GetPremiumStatement(UserUID, XML, "PREMIUMSTATEMENT");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet GetPremiumStatement_cr(int UserUID, string XML)
        {
            try
            {
                return ReportDAL.GetPremiumStatement_cr(UserUID, XML, "PREMIUMSTATEMENT");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
