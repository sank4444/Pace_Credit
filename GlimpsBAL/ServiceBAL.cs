using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using System.Data;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace GlimpsBAL
{
    public class ServiceBAL
    {
        #region Member Addition...

        /// <summary>
        /// Gets the premium rate chart report.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet InsertXMLInDataBase(int UserUID, string Action, DataSet ds)
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table1>", "<params><param>");
                XML.Replace("</Table1>", "</param></params>");
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("<Table1 />", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);

                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    XML += "<params><param>";

                //    //XML += "<SubofficeCode>" + ds.Tables[0].Rows[i]["SubofficeCode"] + "</SubofficeCode>";
                //    //XML += "<SchemeJoiningDate>" + ds.Tables[0].Rows[i]["SchemeJoiningDate"] + "</SchemeJoiningDate>";w
                //    //XML += "<ProposedFirstName>" + ds.Tables[0].Rows[i]["ProposedFirstName"] + "</ProposedFirstName>";
                //    //XML += "<Birthdate>" + ds.Tables[0].Rows[i]["Birthdate"] + "</Birthdate>";
                //    //XML += "<Gender>" + ds.Tables[0].Rows[i]["Gender"] + "</Gender>";
                //    //XML += "<EmploymentDate>" + ds.Tables[0].Rows[i]["EmploymentDate"] + "</EmploymentDate>";
                //    //XML += "<DateofIntimation>" + ds.Tables[0].Rows[i]["DateofIntimation"] + "</DateofIntimation>";
                //    //XML += "<EmployeeNo>" + ds.Tables[0].Rows[i]["EmployeeNo"] + "</EmployeeNo>";
                //    //XML += "<FSG>" + ds.Tables[0].Rows[i]["FSG"] + "</FSG>";
                //}
                return GlimpsDAL.ServicesDAL.InsertXMLInDataBase(UserUID, XML.ToString(), Action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        // public DataSet InsertXMLInDataBase_cr(int UserUID, string Action, DataSet ds)
        public DataSet InsertXMLInDataBase_cr(string Process, string SubProcess, string Upload, int policyUID, int UserUID, DataSet ds)//Int16 sApplicationUID,
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table1>", "<params><param>");
                XML.Replace("</Table1>", "</param></params>");
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("<Table1 />", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);

                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    XML += "<params><param>";

                //    //XML += "<SubofficeCode>" + ds.Tables[0].Rows[i]["SubofficeCode"] + "</SubofficeCode>";
                //    //XML += "<SchemeJoiningDate>" + ds.Tables[0].Rows[i]["SchemeJoiningDate"] + "</SchemeJoiningDate>";w
                //    //XML += "<ProposedFirstName>" + ds.Tables[0].Rows[i]["ProposedFirstName"] + "</ProposedFirstName>";
                //    //XML += "<Birthdate>" + ds.Tables[0].Rows[i]["Birthdate"] + "</Birthdate>";
                //    //XML += "<Gender>" + ds.Tables[0].Rows[i]["Gender"] + "</Gender>";
                //    //XML += "<EmploymentDate>" + ds.Tables[0].Rows[i]["EmploymentDate"] + "</EmploymentDate>";
                //    //XML += "<DateofIntimation>" + ds.Tables[0].Rows[i]["DateofIntimation"] + "</DateofIntimation>";
                //    //XML += "<EmployeeNo>" + ds.Tables[0].Rows[i]["EmployeeNo"] + "</EmployeeNo>";
                //    //XML += "<FSG>" + ds.Tables[0].Rows[i]["FSG"] + "</FSG>";
                //}
                //return GlimpsDAL.ServicesDAL.InsertXMLInDataBase_cr(UserUID, XML.ToString(), Action);
                return GlimpsDAL.ServicesDAL.InsertXMLInDataBase_cr(XML.ToString(), Process, SubProcess, policyUID, UserUID);//, sApplicationUID


             
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Upload_Premium_Calculation(int UserUID, DataSet ds)
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);
                return GlimpsDAL.ServicesDAL.Upload_Premium_Calculation(XML.ToString(), UserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Bulk_COI_Upload

        public DataSet Bulk_COI_Upload(int UserUID, DataSet ds)
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);
                return GlimpsDAL.ServicesDAL.Bulk_COI_Upload(XML.ToString(), UserUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MemberTermConfirm(int UserUID, string TransactionID, DataTable dtSelectedRecord)
        {
            string XML = string.Empty;
            try
            {
                
                for (int i = 0; i < dtSelectedRecord.Rows.Count; i++)
                {
                    XML += "<params><param>";
                    XML += "<COI>" + dtSelectedRecord.Rows[i]["COI"] + "</COI>";
                    XML += "<AAWFlag>" + dtSelectedRecord.Rows[i]["AAWFlag"] + "</AAWFlag>";
                    XML += "</param></params>";
                }
              
                return GlimpsDAL.ServicesDAL.MemberTermConfirm(UserUID, "TRMMemAdd", TransactionID,XML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LS
        public DataSet MemberTermConfirm_cr(string Process, string SubProcess, int PolicyUID, int UserUID, string TransactionID)
        {
            string XML = string.Empty;
            try
            {
                return GlimpsDAL.ServicesDAL.MemberTermConfirm_cr(Process,SubProcess,PolicyUID,UserUID, TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet MemberTermConfirm_undocr(string Process, string SubProcess, int PolicyUID, int UserUID, string TransactionID)
        {
            string XML = string.Empty;
            try
            {
                //MemberTermConfirm_undocr
                return GlimpsDAL.ServicesDAL.MemberTermConfirm_undocr(Process, SubProcess, PolicyUID, UserUID, TransactionID);
                // return GlimpsDAL.ServicesDAL.MemberTermConfirm_cr(UserUID, "TRMMemAdd", TransactionID, XML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet Autounderwriting_Job(int UserUID, string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.Autounderwriting_Job(UserUID, "TRMMemAdd", TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP(int UserUID, string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_UPLOAD_TEMP(UserUID, "TRMMemAdd", TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///LS
        public DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_cr(int UserUID, string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_UPLOAD_TEMP_cr(UserUID, "TRMMemAdd", TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MEMBER_BILLPROCESS_CONFIRM(int UserUID, string TransactionID, DataSet ds)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    XML += "<BillNo>" + ds.Tables[0].Rows[i]["Bill No"] + "</BillNo>";
                }
                XML += "</param></params>";
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_CONFIRM(UserUID, XML, TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet MEMBER_BILLPROCESS_CONFIRM_cr(int UserUID, string TransactionID, DataSet ds)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    XML += "<BillNo>" + ds.Tables[0].Rows[i]["Bill No"] + "</BillNo>";
                }
                XML += "</param></params>";
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_CONFIRM_cr(UserUID, XML, TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Member Deletion...

        /// <summary>
        /// Gets the premium rate chart report.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet InsertXMLInDataBaseForDeletion(int UserUID, string Action, DataSet ds, int policyUID, int PolServicingChangeUID)
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table1>", "<params><param>");
                XML.Replace("</Table1>", "</param></params>");
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("<Table1 />", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);
                //string XML = string.Empty;
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    XML += "<params><param>";
                //    XML += "<PolServicingChangeUID>" + PolServicingChangeUID + "</PolServicingChangeUID>";
                //    XML += "<PolicyUID>" + policyUID + "</PolicyUID>";
                //    XML += "<COI>" + ds.Tables[0].Rows[i]["COI"] + "</COI>";
                //    XML += "<ChangeEffectiveDate>" + ds.Tables[0].Rows[i]["ChangeEffectiveDate"] + "</ChangeEffectiveDate>";
                //    XML += "  <Terminationdt>" + ds.Tables[0].Rows[i]["Terminationdt"] + "</Terminationdt>";
                //    XML += "</param></params>";
                //}
                return GlimpsDAL.ServicesDAL.InsertXMLInDataBaseForDeletion(UserUID, XML.ToString(), Action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet InsertXMLInDataBaseForDeletion_cr(int UserUID, string Action, DataSet ds, int policyUID, int PolServicingChangeUID)
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table1>", "<params><param>");
                XML.Replace("</Table1>", "</param></params>");
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("<Table1 />", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);
                //string XML = string.Empty;
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    XML += "<params><param>";
                //    XML += "<PolServicingChangeUID>" + PolServicingChangeUID + "</PolServicingChangeUID>";
                //    XML += "<PolicyUID>" + policyUID + "</PolicyUID>";
                //    XML += "<COI>" + ds.Tables[0].Rows[i]["COI"] + "</COI>";
                //    XML += "<ChangeEffectiveDate>" + ds.Tables[0].Rows[i]["ChangeEffectiveDate"] + "</ChangeEffectiveDate>";
                //    XML += "  <Terminationdt>" + ds.Tables[0].Rows[i]["Terminationdt"] + "</Terminationdt>";
                //    XML += "</param></params>";
                //}
                return GlimpsDAL.ServicesDAL.InsertXMLInDataBaseForDeletion_cr(UserUID, XML.ToString(), Action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click member Deletion.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MemberTermConfirmDeletion(int UserUID,string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.MemberTermConfirmDeletion(UserUID, "TRMMemDel", TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LS
        public DataSet MemberTermConfirmDeletion_cr(int UserUID, string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.MemberTermConfirmDeletion_cr(UserUID, "TRMMemDel", TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet Autounderwriting_Job_Deletion(int UserUID, string ServiceReqNo)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.Autounderwriting_JobDeletion(UserUID, ServiceReqNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Autounderwriting_Job_Deletion_cr(int UserUID, string ServiceReqNo)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.Autounderwriting_JobDeletion_cr(UserUID, ServiceReqNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_Deletion(int UserUID,string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_UPLOAD_TEMP_Deletion(UserUID, "TRMMemDel", TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_Deletion_cr(int UserUID, string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_UPLOAD_TEMP_Deletion_cr(UserUID, "TRMMemDel", TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MEMBER_BILLPROCESS_CONFIRM_Deletion(int UserUID, DataSet ds,string TransactionID)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    XML += "<BillNo>" + ds.Tables[0].Rows[i]["Bill No"] + "</BillNo>";
                }
                XML += "</param></params>";
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_CONFIRM_Deletion(UserUID, XML,TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet MEMBER_BILLPROCESS_CONFIRM_Deletion_cr(int UserUID, DataSet ds, string TransactionID)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    XML += "<BillNo>" + ds.Tables[0].Rows[i]["Bill No"] + "</BillNo>";
                }
                XML += "</param></params>";
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_CONFIRM_Deletion_cr(UserUID, XML, TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region SumAssured
        /// <summary>
        /// Gets the premium rate chart report.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet InsertXMLInDataBaseForSumAssured(int UserUID, string Action, DataSet ds, int policyUID, int PolServicingChangeUID)
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table1>", "<params><param>");
                XML.Replace("</Table1>", "</param></params>");
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("<Table1 />", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);
                //string XML = string.Empty;
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    XML += "<params><param>";
                //    XML += "<PolServicingChangeUID>" + PolServicingChangeUID + "</PolServicingChangeUID>";
                //    XML += "<PolicyUID>" + policyUID + "</PolicyUID>";
                //    XML += "<COI>" + ds.Tables[0].Rows[i]["COI"] + "</COI>";
                //    XML += "<RequestDate>" + DateTime.Now.ToShortDateString() + "</RequestDate>";
                //    XML += "<ChangeEffectiveDate>" + ds.Tables[0].Rows[i]["ChangeEffectiveDate"] + "</ChangeEffectiveDate>";
                //    XML += "<FSG>" + ds.Tables[0].Rows[i]["FSG"] + "</FSG>";
                //    XML += "<FSA>" + ds.Tables[0].Rows[i]["FSA"] + "</FSA>";
                //    XML += "<AnnualIncome>" + ds.Tables[0].Rows[i]["AnnualIncome"] + "</AnnualIncome>";
                //    XML += "<DesignationCode>" + ds.Tables[0].Rows[i]["DesignationCode"] + "</DesignationCode>";
                //    // XML += "<RowNumber>" + ds.Tables[0].Rows[i]["RowNumber"] + "</RowNumber>";
                //    XML += "</param></params>";
                //}
                return GlimpsDAL.ServicesDAL.InsertXMLInDataBaseForSumAssured(UserUID, XML.ToString(), Action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click member Deletion.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MemberTermConfirmSumAssured(int UserUID, int PolServicingChangeUID, string Action)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                XML += "<PolServicingChangeUID>" + PolServicingChangeUID + "</PolServicingChangeUID>";
                XML += "</param></params>";

                return GlimpsDAL.ServicesDAL.MemberTermConfirmSumAssured(XML, UserUID, Action, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet Autounderwriting_Job_SumAssured(int UserUID, string ServiceReqNo)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.Autounderwriting_JobSumAssured(UserUID, ServiceReqNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Autounderwriting_Job_SumAssured_cr(int UserUID, string ServiceReqNo)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.Autounderwriting_JobSumAssured_cr(UserUID, ServiceReqNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_SumAssured(int UserUID, string Action, string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_UPLOAD_TEMP_SumAssured(UserUID, Action, TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS 
        public DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_SumAssured_cr(int UserUID, string Action, string TransactionID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_UPLOAD_TEMP_SumAssured_cr(UserUID, Action, TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MEMBER_BILLPROCESS_CONFIRM_SumAssured(int UserUID, DataSet ds, string transactionID)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    XML += "<BillNo>" + ds.Tables[0].Rows[i]["Bill No"] + "</BillNo>";
                }
                XML += "</param></params>";
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_CONFIRM_SumAssured(UserUID, XML, transactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet MEMBER_BILLPROCESS_CONFIRM_SumAssured_cr(int UserUID, DataSet ds, string transactionID)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    XML += "<BillNo>" + ds.Tables[0].Rows[i]["Bill No"] + "</BillNo>";
                }
                XML += "</param></params>";
                return GlimpsDAL.ServicesDAL.MEMBER_BILLPROCESS_CONFIRM_SumAssured_cr(UserUID, XML, transactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Minor Servicing changes
        /// <summary>
        /// Gets the premium rate chart report.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet InsertXMLInDataBaseForMinorServicingchanges(int UserUID, string Action, DataSet ds, int policyUID, int PolServicingChangeUID)
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table1>", "<params><param>");
                XML.Replace("</Table1>", "</param></params>");
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("<Table1 />", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);
                //string XML = string.Empty;
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    XML += "<params><param>";
                //    XML += "<PolServicingChangeUID>" + PolServicingChangeUID + "</PolServicingChangeUID>";
                //    XML += "<PolicyUID>" + policyUID + "</PolicyUID>";
                //    XML += "<COI>" + ds.Tables[0].Rows[i]["COI"] + "</COI>";
                //    XML += "<RequestDate>" + DateTime.Now.ToShortDateString() + "</RequestDate>";
                //    XML += "<ChangeEffectiveDate>" + ds.Tables[0].Rows[i]["ChangeEffectiveDate"] + "</ChangeEffectiveDate>";
                //    XML += "<EmployeeNo>" + ds.Tables[0].Rows[i]["EmployeeNo"] + "</EmployeeNo>";
                //    XML += "<Birthdate>" + ds.Tables[0].Rows[i]["Birthdate"] + "</Birthdate>";
                //    XML += "<Gender>" + ds.Tables[0].Rows[i]["Gender"] + "</Gender>";
                //    XML += "<ProposedTitle>" + ds.Tables[0].Rows[i]["ProposedTitle"] + "</ProposedTitle>";
                //    XML += "<ProposedLastName>" + ds.Tables[0].Rows[i]["ProposedLastName"] + "</ProposedLastName>";
                //    XML += "<ProposedFirstName>" + ds.Tables[0].Rows[i]["ProposedFirstName"] + "</ProposedFirstName>";
                //    XML += "<ProposedMiddleName>" + ds.Tables[0].Rows[i]["ProposedMiddleName"] + "</ProposedMiddleName>";

                //    // XML += "<RowNumber>" + ds.Tables[0].Rows[i]["RowNumber"] + "</RowNumber>";
                //    XML += "</param></params>";
                //}

                return GlimpsDAL.ServicesDAL.InsertXMLInDataBaseForMinorServicingchanges(UserUID, XML.ToString(), Action);                      
                }            
         
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet InsertXMLInDataBaseForMinorServicingchanges_cr(int UserUID, string Action, DataSet ds, int policyUID, int PolServicingChangeUID)
        {
            try
            {
                StringBuilder XML = new StringBuilder();
                XML.Append(ds.GetXml());
                XML.Replace("<Table1>", "<params><param>");
                XML.Replace("</Table1>", "</param></params>");
                XML.Replace("<Table>", "<params><param>");
                XML.Replace("</Table>", "</param></params>");
                XML.Replace("<NewDataSet>", string.Empty);
                XML.Replace("<Table1 />", string.Empty);
                XML.Replace("</NewDataSet>", string.Empty);
                XML.Replace("T00:00:00+05:30", string.Empty);
                //string XML = string.Empty;
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    XML += "<params><param>";
                //    XML += "<PolServicingChangeUID>" + PolServicingChangeUID + "</PolServicingChangeUID>";
                //    XML += "<PolicyUID>" + policyUID + "</PolicyUID>";
                //    XML += "<COI>" + ds.Tables[0].Rows[i]["COI"] + "</COI>";
                //    XML += "<RequestDate>" + DateTime.Now.ToShortDateString() + "</RequestDate>";
                //    XML += "<ChangeEffectiveDate>" + ds.Tables[0].Rows[i]["ChangeEffectiveDate"] + "</ChangeEffectiveDate>";
                //    XML += "<EmployeeNo>" + ds.Tables[0].Rows[i]["EmployeeNo"] + "</EmployeeNo>";
                //    XML += "<Birthdate>" + ds.Tables[0].Rows[i]["Birthdate"] + "</Birthdate>";
                //    XML += "<Gender>" + ds.Tables[0].Rows[i]["Gender"] + "</Gender>";
                //    XML += "<ProposedTitle>" + ds.Tables[0].Rows[i]["ProposedTitle"] + "</ProposedTitle>";
                //    XML += "<ProposedLastName>" + ds.Tables[0].Rows[i]["ProposedLastName"] + "</ProposedLastName>";
                //    XML += "<ProposedFirstName>" + ds.Tables[0].Rows[i]["ProposedFirstName"] + "</ProposedFirstName>";
                //    XML += "<ProposedMiddleName>" + ds.Tables[0].Rows[i]["ProposedMiddleName"] + "</ProposedMiddleName>";

                //    // XML += "<RowNumber>" + ds.Tables[0].Rows[i]["RowNumber"] + "</RowNumber>";
                //    XML += "</param></params>";
                //}

                return GlimpsDAL.ServicesDAL.InsertXMLInDataBaseForMinorServicingchanges_cr(UserUID, XML.ToString(), Action);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Next Click member MinorServicingchanges.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet MemberTermConfirmMinorServicingchanges(int UserUID, int PolServicingChangeUID, string Action, string TransactionID)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                XML += "<PolServicingChangeUID>" + PolServicingChangeUID + "</PolServicingChangeUID>";
                XML += "</param></params>";

                return GlimpsDAL.ServicesDAL.MemberTermConfirmMinorServicingchanges(XML, UserUID, Action, TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet MemberTermConfirmMinorServicingchanges_cr(int UserUID, int PolServicingChangeUID, string Action, string TransactionID)
        {
            try
            {
                string XML = string.Empty;
                XML += "<params><param>";
                XML += "<PolServicingChangeUID>" + PolServicingChangeUID + "</PolServicingChangeUID>";
                XML += "</param></params>";

                return GlimpsDAL.ServicesDAL.MemberTermConfirmMinorServicingchanges_cr(XML, UserUID, Action, TransactionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Next Click.
        /// </summary>
        /// <param name="rateCode">The rate code.</param>
        /// <returns></returns>
        public DataSet Autounderwriting_Job_MinorServicingchanges(int UserUID, string ServiceReqNo, string transactionUID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.Autounderwriting_JobMinorServicingchanges(UserUID, ServiceReqNo, transactionUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet Autounderwriting_Job_MinorServicingchanges_cr(int UserUID, string ServiceReqNo, string transactionUID)
        {
            try
            {
                return GlimpsDAL.ServicesDAL.Autounderwriting_JobMinorServicingchanges_cr(UserUID, ServiceReqNo, transactionUID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Service Request DropDown
        public DataSet ServiceRequestTypeDDL(string UserUID)
        {
            try
            {
                return ServicesDAL.ServiceRequestTypeDDL(UserUID, string.Empty, CommonConstantNames.PACESERVICING);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        //Sending Mail With Attachment
        public int SendinMailWithAttachment(string UserUID,byte[] AttachmentData,string ServicingRequestNo)
        {
            try
            {
                string XML = "<params><param><ServicingRequestNo>" + ServicingRequestNo + "</ServicingRequestNo></param></params>";
                return ServicesDAL.SendinMailWithAttachment(UserUID, XML, "SRSENDMAIL",AttachmentData );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region category DropDown
        public DataSet categoryDDL(string UserUID)
        {
            ServicesDAL objServicesDAL = null;
            try
            {
                objServicesDAL = new ServicesDAL();
                string XML = string.Empty;
                XML = string.Empty;
                return ServicesDAL.categoryDDL(UserUID, XML, "PACESUBCATSERVICING");
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        //ls2019 
        public DataSet categoryDDL_cr(string UserUID)
        {
            ServicesDAL objServicesDAL = null;
            try
            {
                objServicesDAL = new ServicesDAL();
                string XML = string.Empty;
                XML = string.Empty;
                return ServicesDAL.categoryDDL_cr(UserUID, XML, "PACESUBCATSERVICING");
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        #endregion

        #region Policy DropDown
        public DataSet PolicyDDL(string UserUID)
        {
            ServicesDAL objServicesDAL = null;
            try
            {
                objServicesDAL = new ServicesDAL();
                return ServicesDAL.PolicyDDL(UserUID, string.Empty, "");
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        #endregion

        #region COI DropDown
        public DataSet COIDDL(string UserUID)
        {
            ServicesDAL objServicesDAL = null;
            try
            {
                objServicesDAL = new ServicesDAL();
                return ServicesDAL.COIDDL(UserUID, string.Empty, "");
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        #endregion

        #region Saving Service Request

        public DataSet SavingServiceRequest(string userId, string FK_RequestTypeUID, string FK_SubRequestTypeUID, string COI, string FilePath, List<string> chlValues,string DateOfDeath,string CauseOfDeath)
        {
            string XML = string.Empty;
            try
            {
                XML += "<params><param>";
                XML += "<RequestType>" + FK_RequestTypeUID + "</RequestType>";
                XML += "<FK_SubRequestTypeUID>" + FK_SubRequestTypeUID + "</FK_SubRequestTypeUID>";
                XML += "<Documents>";
                for (int i = 0; i < chlValues.Count; i++)
                {
                    XML += "<FK_DocumentUID" + (i + 1) + ">" + chlValues[i] + "</FK_DocumentUID" + (i + 1) + ">";
                }
                XML += "</Documents>";
                XML += "<COI>" + COI + "</COI>";
                XML += "<FilePath>" + FilePath + "</FilePath>";
                XML += "<DateOfDeath>" + DateOfDeath + "</DateOfDeath>";
                XML += "<CauseOfDeath>" + CauseOfDeath + "</CauseOfDeath>";
                XML += "</param></params>";

                return ServicesDAL.SavingServiceRequest(userId, XML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls 2019 
        public DataSet SavingServiceRequest_cr(string userId, string FK_RequestTypeUID, string FK_SubRequestTypeUID, string COI, string FilePath, List<string> chlValues, string DateOfDeath, string CauseOfDeath)
        {
            string XML = string.Empty;
            try
            {
                XML += "<params><param>";
                XML += "<RequestType>" + FK_RequestTypeUID + "</RequestType>";
                XML += "<FK_SubRequestTypeUID>" + FK_SubRequestTypeUID + "</FK_SubRequestTypeUID>";
                XML += "<Documents>";
                for (int i = 0; i < chlValues.Count; i++)
                {
                    XML += "<FK_DocumentUID" + (i + 1) + ">" + chlValues[i] + "</FK_DocumentUID" + (i + 1) + ">";
                }
                XML += "</Documents>";
                XML += "<COI>" + COI + "</COI>";
                XML += "<FilePath>" + FilePath + "</FilePath>";
                XML += "<DateOfDeath>" + DateOfDeath + "</DateOfDeath>";
                XML += "<CauseOfDeath>" + CauseOfDeath + "</CauseOfDeath>";
                XML += "</param></params>";

                return ServicesDAL.SavingServiceRequest_cr(userId, XML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavingServiceRequest(string userId, string FK_RequestTypeUID, string FK_SubRequestTypeUID, string CCExcutive, string MobileNo, string Query)
        {
            string XML = string.Empty;
            try
            {
                XML += "<params><param>";
                XML += "<RequestType>" + FK_RequestTypeUID + "</RequestType>";
                XML += "<FK_SubRequestTypeUID>" + FK_SubRequestTypeUID + "</FK_SubRequestTypeUID>";
                XML += "<CCExcutive>" + CCExcutive + "</CCExcutive>";
                XML += "<MobileNoOfCaller>" + MobileNo + "</MobileNoOfCaller>";
                XML += "<Query>" + Query + "</Query>";
                XML += "</param></params>";

                return ServicesDAL.SavingServiceRequest(userId, XML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GET DATA OF CHECK BOX FOR DISPLAY
        public DataSet getDataCHK(string userid, string ddlCommonListValue)
        {
            string XML = string.Empty;
            XML += "<params><param>";
            XML += "<CommonListValue>" + ddlCommonListValue + "</CommonListValue>";
            XML += "</param></params>";
            return ServicesDAL.ServiceRequestTypeDDL(userid, XML, "CHECKBOXLIST");
            //return ServicesDAL.getDataCHK(userid, string.Empty,CommonConstantNames.PACESERVICING); 
        }
        //ls2019 
        public DataSet getDataCHK_cr(string userid, string ddlCommonListValue)
        {
            string XML = string.Empty;
            XML += "<params><param>";
            XML += "<CommonListValue>" + ddlCommonListValue + "</CommonListValue>";
            XML += "</param></params>";
            return ServicesDAL.ServiceRequestTypeDDL_cr(userid, XML, "CHECKBOXLIST");
            //return ServicesDAL.getDataCHK(userid, string.Empty,CommonConstantNames.PACESERVICING); 
        }
        #endregion

        #region get Service list data

        public DataSet GetServiceList(string UserID, string Action, string ServicingRequestNo)
        {
            try
            {
                string XML = string.Empty;

                XML += "<params><param>";
                XML += "<ServicingRequestNo>" + ServicingRequestNo + "</ServicingRequestNo>";
                XML += "</param></params>";


                return ServicesDAL.GetServiceList(UserID, XML, Action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet GetServiceList_cr(string UserID, string Action, string ServicingRequestNo)
        {
            try
            {
                string XML = string.Empty;

                XML += "<params><param>";
                XML += "<ServicingRequestNo>" + ServicingRequestNo + "</ServicingRequestNo>";
                XML += "</param></params>";


                return ServicesDAL.GetServiceList_cr(UserID, XML, Action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LS
        //public DataSet GetServiceList_cr(string UserID, string Action, string ServicingRequestNo)
        //{
        //    try
        //    {
        //        string XML = string.Empty;

        //        XML += "<params><param>";
        //        XML += "<ServicingRequestNo>" + ServicingRequestNo + "</ServicingRequestNo>";
        //        XML += "</param></params>";


        //        return ServicesDAL.GetServiceList_cr(UserID, XML, Action);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

        #region Get Service Request COI

        public DataSet GetServiceRequestCOI(string UserID, string SearchValue, string SearchItem, string Action)
        {
            try
            {
                string XML = string.Empty;

                XML += "<params><param>";
                XML += "<SearchValue>" + SearchValue + "</SearchValue>";
                XML += "<SearchItem>" + SearchItem + "</SearchItem>";
                XML += " </param></params>";


                return ServicesDAL.GetServiceRequestCOI(UserID, XML, Action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
