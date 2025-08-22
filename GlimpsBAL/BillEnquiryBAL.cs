using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using System.Data;

namespace GlimpsBAL
{
    public class BillEnquiryBAL
    {
        public DataSet GetBillEnquiry(string billNo, int UserUID, string PeriodFromDate, string PeriodToDate)
        {
            BillEnquiryDAL objBillEnquiryDAL = null;
            try
            {
                objBillEnquiryDAL = new BillEnquiryDAL();
                string XmlData = "<params><param><BillNo>" + billNo + "</BillNo><BillFromDate>" +
                    PeriodFromDate + "</BillFromDate><BillToDate>" +
                    PeriodToDate + "</BillToDate></param></params>";
                string action = "BI";
                return objBillEnquiryDAL.GetBillEnquiry(billNo, XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LS
        //public DataSet GetBillEnquiry_cr(string billNo, int UserUID, string PeriodFromDate, string PeriodToDate)
        public DataSet GetBillEnquiry_cr(int UserUID, string PeriodFromDate, string PeriodToDate, string Searchaction)
        {
            BillEnquiryDAL objBillEnquiryDAL = null;
            try
            {
                //objBillEnquiryDAL = new BillEnquiryDAL();
                //string XmlData = "<params><param><BillNo>" + billNo + "</BillNo><BillFromDate>" +
                //    PeriodFromDate + "</BillFromDate><BillToDate>" +
                //    PeriodToDate + "</BillToDate></param></params>";
                objBillEnquiryDAL = new BillEnquiryDAL();
                string XmlData = "<params><param><BillFromDate>" +
                    PeriodFromDate + "</BillFromDate><BillToDate>" +
                    PeriodToDate + "</BillToDate></param></params>";
                //string action = "BI";
                //return objBillEnquiryDAL.GetBillEnquiry_cr(billNo, XmlData, UserUID, action);
                return objBillEnquiryDAL.GetBillEnquiry_cr(XmlData, UserUID, Searchaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BALGetDashBoard_cr(int UserUID, string PeriodFromDate, string PeriodToDate, string action)
        {
            BillEnquiryDAL objBillEnquiryDAL = null;
            try
            {
               
                objBillEnquiryDAL = new BillEnquiryDAL();
                string XmlData = "<params><param><BillFromDate>" +
                    PeriodFromDate + "</BillFromDate><BillToDate>" +
                    PeriodToDate + "</BillToDate></param></params>";
                //string action = "BI";
                //return objBillEnquiryDAL.GetBillEnquiry_cr(billNo, XmlData, UserUID, action);
                return objBillEnquiryDAL.GetDashBoard_cr(XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBillEnquiryUID(string billNo, int UserUID, DateTime PeriodFromDate, DateTime PeriodToDate)
        {
            BillEnquiryDAL objBillEnquiryDAL = null;
            try
            {
                objBillEnquiryDAL = new BillEnquiryDAL();
                string XmlData = "<params><param><BillUID>" + billNo + "</BillUID></param></params>";
                string action = "MBI";
                return objBillEnquiryDAL.GetBillEnquiry(billNo, XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetPopUpBillEnquiry(string billNo, int UserUID)
        {
            BillEnquiryDAL objBillEnquiryDAL = null;

            try
            {
                objBillEnquiryDAL = new BillEnquiryDAL();
                string XmlData = "<params><param><BillNo>" + billNo + "</BillNo></param></params>";
                string action = "MBI";
                return objBillEnquiryDAL.GetPopUpBillEnquiry(XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet GetPopUpBillEnquiry_cr(string billNo, int UserUID)
        {
            BillEnquiryDAL objBillEnquiryDAL = null;

            try
            {
                objBillEnquiryDAL = new BillEnquiryDAL();
                string XmlData = "<params><param><BillNo>" + billNo + "</BillNo></param></params>";
                string action = "MBI";
                return objBillEnquiryDAL.GetPopUpBillEnquiry_cr(XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBillPayMent(string sUserUID, string BillperiodTo, string BillperiodFrom, string ACTION)
        {
            try
            {
                string XmlData = string.Empty;


                XmlData += "<params><param>";
                XmlData += "<BillperiodFrom>" + BillperiodFrom + "</BillperiodFrom>";
                XmlData += "<BillperiodTo>" + BillperiodTo + "</BillperiodTo>";
                XmlData += "</param></params>";
                return BillEnquiryDAL.GetBillPayMent(XmlData, ACTION, sUserUID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet GetBillPayMent_cr(string sUserUID, string BillperiodTo, string BillperiodFrom, string ACTION)
        {
            try
            {
                string XmlData = string.Empty;


                XmlData += "<params><param>";
                XmlData += "<BillperiodFrom>" + BillperiodFrom + "</BillperiodFrom>";
                XmlData += "<BillperiodTo>" + BillperiodTo + "</BillperiodTo>";
                XmlData += "</param></params>";
                return BillEnquiryDAL.GetBillPayMent_cr(XmlData, ACTION, sUserUID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetNonFloat(string sUserUID, string ACTION)
        {
            try
            {
                string XmlData = string.Empty;
                return BillEnquiryDAL.GetNonFloat(XmlData, ACTION, sUserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet GetNonFloat_cr(string sUserUID, string ACTION)
        {
            try
            {
                string XmlData = string.Empty;
                return BillEnquiryDAL.GetNonFloat_cr(XmlData, ACTION, sUserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetFloat(string sUserUID, string ACTION)
        {
            try
            {
                string XmlData = string.Empty;
                try
                {
                    return BillEnquiryDAL.GetFloat(XmlData, ACTION, sUserUID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       //ls
        public DataSet GetFloat_cr(string sUserUID, string ACTION)
        {
            try
            {
                string XmlData = string.Empty;
                try
                {
                    return BillEnquiryDAL.GetFloat_cr(XmlData, ACTION, sUserUID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertBillPayment(string sUserUID, string XmlData, string ACTION)
        {

            try
            {
                return BillEnquiryDAL.InsertBillPayment(XmlData, ACTION, sUserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public int InsertBillPayment_cr(string sUserUID, string XmlData, string ACTION)
        {

            try
            {
                return BillEnquiryDAL.InsertBillPayment_cr(XmlData, ACTION, sUserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
