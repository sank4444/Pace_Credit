using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using GlimpsDAL;
using GlimpsBAL;
using System.Data.SqlClient;
using GlimpsDAL.Common;
using System.Configuration;

namespace GLIMPSE.Web.Reports
{
    public partial class COIPrintingReport : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        Int16 sApplicationUID = 0;
        int PrintFlg;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserUID = Session[CommonConstantNames.USERUID].ToString();
                string PolicyMemberUID = string.Empty;
                if (!Page.IsPostBack)
                {
                    PolicyMemberUID = Request.QueryString["PolicyMemberUID"];
                   // CreateXMLData(PolicyMemberUID);
                    string PolicyMemberUIDXml= CreateXMLData(PolicyMemberUID).ToString();
                    DataSet dsResult = new DataSet();
                    dsResult = BindCOIPrintingReportForPace(PolicyMemberUIDXml);
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        RptCOIPrintReport.Visible = true;
                        lblNoTextMsg.Visible = false;

                        RptCOIPrintReport.LocalReport.DataSources.Clear();

                        ReportDataSource datasource = new ReportDataSource("dsCOIPrintingReport_dtCOIPrinting", dsResult.Tables[0]);
                        RptCOIPrintReport.LocalReport.DataSources.Add(datasource);

                        RptCOIPrintReport.LocalReport.Refresh();
                        RptCOIPrintReport.ProcessingMode = ProcessingMode.Local;
                        LocalReport _report = RptCOIPrintReport.LocalReport;
                        _report.ReportPath = @"MemberInformation_cr\COIPrintingReport_1.rdlc";
                    }
                    else
                    {
                        RptCOIPrintReport.Visible = false;
                        lblNoTextMsg.Visible = true;
                    }

                }


                //if (Convert.ToString(Session[CommonConstantNames.sModule]) == CommonConstants.cPRINT)
                //{
                 //   BindCOIPrintingReport();
                    //RptCOIPrintReport.ProcessingMode = ProcessingMode.Local;
                    //LocalReport _report = RptCOIPrintReport.LocalReport;
                    //if (Request.QueryString["PF"] == "Y")
                    //{
                    //    _report.ReportPath = @"Reports\COIPrintingReportNew1.rdlc";
                       
                    //}
                    //else
                    //{
                    //    _report.ReportPath = @"Reports\COIPrintingReport.rdlc";

                    //}

                    
               // }
                //else
                //{
                //    BindCOISaveReport();
                //    RptCOIPrintReport.ProcessingMode = ProcessingMode.Local;
                //    LocalReport _report = RptCOIPrintReport.LocalReport;
                //    _report.ReportPath = @"Reports\COISaveReport.rdlc";

                //    //RptCOIPrintReport.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                    
                //}
            }
            catch (Exception ex)
            {
                //ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                //ExceptionFramework.WriteErrorLogsToDB("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace, sUserUID);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.GLIMPSEResource.ResourceMsgKey, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        private StringBuilder CreateXMLData(string PolicyMemberUID)
        {
            string[] PolicyMemberUIDs = PolicyMemberUID.Split(',');
            StringBuilder xmlBuilder = new StringBuilder();

            foreach(string uid in PolicyMemberUIDs)
            {
                xmlBuilder.AppendLine("<params><param>");
                xmlBuilder.AppendLine($"<PolicyMemberUID>{uid}</PolicyMemberUID>");
                xmlBuilder.AppendLine("</param></params>");
            }
            return xmlBuilder;
        }

        //public DataTable GetCOIPrintData()  //FOR BAL
        //{
        //    try
        //    {
        //        return GetPremiumRateChartReport_cr();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static DataSet BindCOIPrintingReportForPace(string PolicyMemberUIDXml)    // FOR DAL
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
              
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PROC_PPOL_MEMBER_COI_PRINTING_New_Pace, con);
                    //PEN_PREMIUM_RATE_PACE
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyMemberUIDXml, PolicyMemberUIDXml);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindCOIPrintingReport(string PolicyMemberUID)
        {
            try
            {
                //ReportingBAL reports = new ReportingBAL();
                DataSet dsResult = new DataSet();
                string sXmlData = PolicyMemberUID;
                Session[CommonConstantNames.sXmlData] = sXmlData;
                //dsResult = GetCOIPrintData(Session[CommonConstantNames.sXmlData], UserUID);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    RptCOIPrintReport.Visible = true;
                    lblNoTextMsg.Visible = false;

                    RptCOIPrintReport.LocalReport.DataSources.Clear();

                    ReportDataSource datasource = new ReportDataSource("dsCOIPrintingReport_dtCOIPrinting", dsResult.Tables[0]);
                    RptCOIPrintReport.LocalReport.DataSources.Add(datasource);

                    RptCOIPrintReport.LocalReport.Refresh();
                }
                else
                {
                    RptCOIPrintReport.Visible = false;
                    lblNoTextMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                //ExceptionFramework.WriteErrorLogsToDB("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace, sUserUID);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.GLIMPSEResource.ResourceMsgKey, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        //private void BindCOISaveReport()
        //{
        //    try
        //    {
        //        COISubmissionBAL reports = new COISubmissionBAL();
        //        DataSet dsResult = new DataSet();

        //        dsResult = reports.GetCOIPrintData(Convert.ToString(Session[CommonConstants.sXmlData]), Convert.ToString(Session[CommonConstants.sDateValue]),Convert.ToString(Session[CommonConstants.sToDate]), sUserUID, sApplicationUID);
        //        if (dsResult.Tables[0].Rows.Count > 0)
        //        {
        //            RptCOIPrintReport.Visible = true;
        //            lblNoTextMsg.Visible = false;

        //            RptCOIPrintReport.LocalReport.DataSources.Clear();

        //            ReportDataSource datasource = new ReportDataSource("dsCOIPrintingReport_dtCOIPrinting", dsResult.Tables[0]);
        //            RptCOIPrintReport.LocalReport.DataSources.Add(datasource);

        //            datasource = new ReportDataSource("dsCOIPrintingReport_dtCOIPrintFooter", dsResult.Tables[1]);
        //            RptCOIPrintReport.LocalReport.DataSources.Add(datasource);

        //            RptCOIPrintReport.LocalReport.Refresh();
        //        }
        //        else
        //        {
        //            RptCOIPrintReport.Visible = false;
        //            lblNoTextMsg.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
        //        ExceptionFramework.WriteErrorLogsToDB("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace, sUserUID);
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.GLIMPSEResource.ResourceMsgKey, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        //    }
        //}

        //void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        //{
        //    COISubmissionBAL reports = new COISubmissionBAL();
        //    DataSet dsResult = new DataSet();
        //    dsResult = reports.GetCOIPrintData(Convert.ToString(Session[CommonConstants.sXmlData]), Convert.ToString(Session[CommonConstants.sDateValue]), Convert.ToString(Session[CommonConstants.sToDate]), sUserUID, sApplicationUID);
        //    e.DataSources.Add(new ReportDataSource("dsCOIPrintingReport_dtCOIPrinting", dsResult.Tables[0]));
        //}
    }
}
