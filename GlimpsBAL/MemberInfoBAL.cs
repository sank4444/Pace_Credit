using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using GlimpsDAL.Common;
using System.Data;

namespace GlimpsBAL
{
    public class MemberInfoBAL
    {
        MemberInfoDAL memberInfoDAL = null;
        //CircleInfo objCircleInfo = null;
        //Added by sonali on 08/08/2017 foe circle details
        public DataSet GetCircleDetails(Int16 sUserId)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();

                string XML = "<params><param><CircleUID></CircleUID></param></params>";

                return memberInfoDAL.GetCircleDetails(XML, sUserId, CommonConstantNames.Action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Added by sonali on 08/08/2017
        public int SaveCircleDetails(CircleInfo objCircleInfo)
        {
            //contactInfoDAL = new ContactInfoDAL();        
            try
            {
                string XML = "<params><param>";
                XML += "<CircleCode>" + objCircleInfo.CircleCode + "</CircleCode>";
                XML += "<CircleName>" + objCircleInfo.CircleName + "</CircleName>";
                XML += "<RechargeValue>" + objCircleInfo.RechargeValue + "</RechargeValue>";
                XML += "<SumAssured>" + objCircleInfo.SumAsured + "</SumAssured>";
                XML += "<Validity>" + objCircleInfo.Validity + "</Validity>";
                XML += "<Status>" + objCircleInfo.IsActive + "</Status>";
                XML += "</param></params>";
                return memberInfoDAL.SaveCircleDetails(XML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //added by sonali on 08/08/2017
        public int UpdateDeleteCircleDetails(CircleInfo objCircleInfo, string StateAction)
        {
            //int intXmlData;
            DataTable dt;
            DataRow dr;
            StringBuilder xmlData = new StringBuilder();
            DataSet dsResult = new DataSet("params");
            try
            {
                if (StateAction == "U")
                {
                    dt = new DataTable("param");
                    dt.Columns.Add("CircleUID", typeof(string));
                    dt.Columns.Add("CircleCode", typeof(string));
                    dt.Columns.Add("CircleName", typeof(string));
                    dt.Columns.Add("RechargeValue", typeof(int));
                    dt.Columns.Add("SumAsured", typeof(int));
                    dt.Columns.Add("Validity", typeof(string));
                    dt.Columns.Add("Status", typeof(string));

                    dr = dt.NewRow();
                    dr["CircleUID"] = objCircleInfo.CircleUID;
                    dr["CircleCode"] = objCircleInfo.CircleCode;
                    dr["CircleName"] = objCircleInfo.CircleName;
                    dr["RechargeValue"] = objCircleInfo.RechargeValue;
                    dr["SumAsured"] = objCircleInfo.SumAsured;
                    dr["Validity"] = objCircleInfo.Validity;
                    dr["Status"] = objCircleInfo.IsActive;
                    // dr["UpdatedBy"] = objCircleInfo.UserID;

                    dt.Rows.Add(dr);

                    dsResult.Merge(dt);
                    //xmlData.Append(dsResult.GetXml());
                    xmlData.Append(dsResult.GetXml());
                
                }
                else if (StateAction == "D")
                {
                    xmlData.Append("<params><param><UpdatedBy>" + objCircleInfo.UserID + "</UpdatedBy><CircleUID>" + objCircleInfo.CircleUID + "</CircleUID></param></params>");
                }

                int XmlData = memberInfoDAL.UpdateDeleteCircleDetails(xmlData.ToString(), StateAction);

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
                //if(ex.Message!="")
                //   return 1;
            }
        }

        //public int SaveContactInfo(ContactInfo contactInfo)
        //{
        //    contactInfoDAL = new ContactInfoDAL();
        //    contactInfo = new ContactInfo();
        //    return contactInfoDAL.SaveContactInfo(contactInfo);
        //}
        //}

        public DataSet GetMemberInfo(int UserUID, string COI, string SearchName)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XmlData = "<params><param><COI>" + COI + "</COI><SearchName>" + SearchName + "</SearchName></param></params>";
                string action = "SEARCH";
                return memberInfoDAL.GetMemberInfo(XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //ls
        public DataSet GetPremiumCal_cr(int UserUID, string COI, string AsOndate)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XmlData = "<params><param><COI>" + COI + "</COI><AsOnDate>" + AsOndate + "</AsOnDate></param></params>";
                //string XmlData = "<params><param><SearchName>" + SearchName + "</SearchName></param></params>";
                string action = "SEARCH";
                return memberInfoDAL.GetPremiumCal(XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public DataSet GetSurrenderCal_cr(int UserUID, string COI, string AsOndate, string PolicyUID)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XmlData = "<params><param><COI>" + COI + "</COI><AsOnDate>" + AsOndate + "</AsOnDate><PolicyUID>" + PolicyUID + "</PolicyUID></param></params>";
                string action = "SEARCH";
                return memberInfoDAL.GetSurrenderCal_cr(XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMemberInfo_cr(int UserUID, string COI, string SearchName, string LoanRefNo)
        {
            try
            {
                

                memberInfoDAL = new MemberInfoDAL();
                string XmlData = "<params><param><COI>" + COI + "</COI><SearchName>" + SearchName + "</SearchName><Loan_Reference_No>" + LoanRefNo + "</Loan_Reference_No></param></params>";
                //string XmlData = "<params><param><SearchName>" + SearchName + "</SearchName></param></params>";
                string action = "SEARCH";
                return memberInfoDAL.GetMemberInfo_cr(XmlData, UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ALLGetMemberInfo_cr
        public DataSet ALLGetMemberInfo_cr(int UserUID, string FrmData, string todate, string COINo)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XmlData = "<params><param><BillFromDate>" + FrmData + "</BillFromDate><BillToDate>" + todate + "</BillToDate><COI>" + COINo + "</COI></param></params>";
                //string XmlData = "<params><param> <BillFromDate> " + FrmData + " </BillFromDate> <BillToDate> " + todate + " </BillToDate> <COI> " + COINo + " </COI></param></params>";
                //string XmlData =  "<params><param><SearchName>" + SearchName + "</SearchName></param></params>";
                string action = "SEARCH";
                return memberInfoDAL.ALLGetMemberInfo_cr(XmlData,UserUID, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetPremiumDataBAL
        public DataSet GetPremiumDataBAL(string PolicyUID, int UserUID, string name, string Rider,
           string rateofIns, string DOB, string SumassuredType, string PremiumModeType, string Gender,
            string Tenure, string PolicyTenure, string Loan_Tenure, string name2, string Gender2, string DOB2, string SegmentCode, string Moratorium, string Cover, string SharingValue
            )
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();

                string XML = "<params><param>";
                XML += "<PolicyUID>" + PolicyUID + "</PolicyUID>";
                XML += "<Name>" + name + "</Name>";
                XML += "<RiderUID>" + Rider + "</RiderUID>";
                XML += "<DOB>" + DOB + "</DOB>";
                XML += "<Gender>" + Gender + "</Gender>";
                XML += "<Gender2>" + Gender2 + "</Gender2>";
                XML += "<DOB2>" + DOB2 + "</DOB2>";
                XML += "<Name2>" + name2 + "</Name2>";
                XML += "<RateofInterest>" + rateofIns + "</RateofInterest>";
                XML += "<PremiumModeTypeUID>" + PremiumModeType + "</PremiumModeTypeUID>";
                XML += "<SumAssuredTypeUID>" + SumassuredType + "</SumAssuredTypeUID>";
                XML += "<Tenure>" + Tenure + "</Tenure>";
                XML += "<PolicyTenure>" + PolicyTenure + "</PolicyTenure>";
                XML += "<LoanTenure>" + Loan_Tenure + "</LoanTenure>";
                XML += "<Segment>" + SegmentCode + "</Segment>";
                XML += "<Moratorium>" + Moratorium + "</Moratorium>";
                XML += "<Cover>" + Cover + "</Cover>";
                XML += "<SharingPer>" + SharingValue + "</SharingPer>";
                XML += "</param></params>";

                return memberInfoDAL.GetPremiumDataDAL(XML, UserUID);//GetPremiumDataDAL
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //MemberInformation PopUp
        public DataSet GetMemberInfoPopUp(int UserUID, int PolicyMemberUID, int PolicyUID, int RenewalNoUID)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoPopUp(UserUID, PolicyMemberUID, PolicyUID, RenewalNoUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls
        public DataSet GetMemberInfoPopUp_cr(int UserUID, int PolicyMemberUID, int PolicyUID, int RenewalNoUID)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoPopUp_cr(UserUID, PolicyMemberUID, PolicyUID, RenewalNoUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls2019
        public DataSet GetViolation_cr(int PolicyMemberUID)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "<MemberList>" + "DataEntryQCPendingList" + "</MemberList>";
                XML += "</param></params>";
                return memberInfoDAL.GetViolation_cr(XML); //PolicyMemberUID,
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetALLMemberInfo_cr(int UserUID, int PolicyMemberUID, int PolicyUID, int RenewalNoUID)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetALLMemberInfo_cr(UserUID, PolicyMemberUID, PolicyUID, RenewalNoUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetMemberInfoBillDetails(int UserUID, int PolicyMemberUID, string action)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoBillDetails(UserUID, XML, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls
        public DataSet GetMemberInfoBillDetails_cr(int UserUID, int PolicyMemberUID, string action)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoBillDetails_cr(UserUID, XML, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetMemberInfoReceiptDetail(int UserUID, int PolicyMemberUID, string action)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoBillDetails(UserUID, XML, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS 18
        public DataSet GetMemberInfoReceiptDetail_cr(int UserUID, int PolicyMemberUID, string action)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoBillDetails_cr(UserUID, XML, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetMemberInfoMemberHistory(int UserUID, int PolicyMemberUID, string action)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoBillDetails(UserUID, XML, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet GetMemberInfoMemberHistory_cr(int UserUID, int PolicyMemberUID, string action)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoBillDetails_cr(UserUID, XML, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetMemberInfoPremiumHistory(int UserUID, int PolicyMemberUID, string action)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoBillDetails(UserUID, XML, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls
        public DataSet GetMemberInfoPremiumHistory_cr(int UserUID, int PolicyMemberUID, string action)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";
                XML += "<PolicyMemberUID>" + PolicyMemberUID + "</PolicyMemberUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberInfoBillDetails_cr(UserUID, XML, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMemberUnderwritingInfo_cr(int UserUID,string Module,string MemberList, int COI, int PolicyUID, int RenewalNoUID)
        {
            try
            {
                memberInfoDAL = new MemberInfoDAL();
                string XML = "<params><param>";                
                XML += "<MemberList>" + MemberList + "</MemberList>";
                XML += "<Module>" + Module + "</Module>";
                XML += "<COI>" + COI + "</COI>";
                XML += "<PolicyUID>" + PolicyUID + "</PolicyUID>";
                XML += "<RenewalNoUID>" + RenewalNoUID + "</RenewalNoUID>";
                XML += "</param></params>";
                return memberInfoDAL.GetMemberUnderwritingInfo_cr(XML,UserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region MemberIfoDetails
        //ls  public DataSet GetSumAssured(string XmlData, string SearchCateria, int UserUID, string ApplicationId)
        //N'<params><param><PolicyUID>1</PolicyUID></param></params>',@SEARCHCATERIA=N'PolicyBenefit',@USERUID=662,@APPLICATIONUID=1
        public DataSet SumAssure_cr(string UserUID, string PolicyUID)
        {
            string SearchCateria = "SumAssuredType";
            string ApplicationID = string.Empty;

            memberInfoDAL = new MemberInfoDAL();
            string xmldata = "'<params><param><PolicyUID>" + PolicyUID + " </PolicyUID></param></params>'";
            return memberInfoDAL.GetSumAssured(xmldata, SearchCateria, UserUID, ApplicationID);
        }
        #endregion



    }
}
