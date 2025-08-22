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
using GlimpsDAL;
using GlimpsBAL;
using Microsoft.Reporting.WebForms;
using PACE.Masters;
using GlimpsDAL.Common;
using System.IO;

namespace PACE.Report_CreditLife  //gvMedicalRate_PageIndexChanging
{
    public partial class MedicalGridReport_cr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserUID = string.Empty;
            string subOfficeUID = string.Empty;
            try
            {
                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx", true);
                }
                if (!IsPostBack)
                {

                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "MedicalGridReport_cr.aspx");
                    //Calling database for records to show
                    BindMedicalRateReport();

                    // processing reports from local 
                    rvMedicalRate1.ProcessingMode = ProcessingMode.Local;
                    // Displaying data in reports
                    LocalReport _report = rvMedicalRate1.LocalReport;
                    _report.ReportPath = Server.MapPath("~/Reports/MedicalGridReport.rdlc");//@"Report/MedicalGridReport.rdlc"; 
                                         // Server.MapPath("~/Report_CreditLife/MedicalGridReport.rdlc");
                                         // @"Report_CreditLife/MedicalGridReport.rdlc"; 
                    string rr = _report.ReportPath;
                    LogError(rr);
                }
            }
            catch (Exception ex)
            {
               
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        public void LogError(string ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
        //public void LogError(string ex)
        //{
        //    string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        //    message += Environment.NewLine;
        //    message += "-----------------------------------------------------------";
        //    message += Environment.NewLine;
        //    message += string.Format("Message: {0}", ex);
        //    message += Environment.NewLine;
        //    message += "-----------------------------------------------------------";
        //    message += Environment.NewLine;
        //    string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
        //    using (StreamWriter writer = new StreamWriter(path, true))
        //    {
        //        writer.WriteLine(message);
        //        writer.Close();
        //    }
        //}

        private void BindMedicalRateReport()
        {
            try
            {
                ReportingBAL reports = new ReportingBAL();
                DataTable dt = new DataTable();
                string ratecode = Request.QueryString["RateCode"].ToString();
                dt = reports.GetMedicalReport_cr(ratecode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ViewState["Data"] = dt;
                    gvMedicalRate.DataSource = dt;
                    gvMedicalRate.DataBind();
                    //if there is records in dataset 
                    rvMedicalRate1.Visible = true;
                    lblNoTextMsg.Visible = false;

                    //Creating a datasource 
                    ReportDataSource dataSource = new ReportDataSource("dsMedicalGridReport_dtMedicalGrid", dt);
                    //Clearing records before fill report with data
                    rvMedicalRate1.LocalReport.DataSources.Clear();
                    //Adding data to report
                    rvMedicalRate1.LocalReport.DataSources.Add(dataSource);
                    // Refreshing report for new data add to report
                    rvMedicalRate1.LocalReport.Refresh();
                }
                else
                {
                    MenuMasterPage_Cr.ShowNoResultFound(dt, gvMedicalRate);
                    //Masters_MenuMasterPage.ShowNoResultFound(dt, gvMedicalRate);
                    //  If there is no data in data set then
                    rvMedicalRate1.Visible = false;
                    lblNoTextMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void gvMedicalRate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["Data"] != null)
            {
                gvMedicalRate.PageIndex = e.NewPageIndex;
                gvMedicalRate.DataSource = ViewState["Data"];
                gvMedicalRate.DataBind();
            }
        }
    }
}
