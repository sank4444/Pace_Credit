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


namespace PACE.Report_CreditLife
{
    public partial class DelineLetter : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        string MemberPolicyID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                    MemberPolicyID =  Session[CommonConstantNames.POLICYMEMBERUID].ToString();
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx", true);
                }
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "DeclineLetterReport.aspx");
                    //Calling database for records to show
                    BindDeclineLetterReport();

                    rvDeclineReport.ProcessingMode = ProcessingMode.Local;
                    LocalReport _report = rvDeclineReport.LocalReport;
                    _report.ReportPath = Server.MapPath("~/Report_CreditLife/DeclineReport.rdlc");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        private void BindDeclineLetterReport()
        {
            try
            {
                ReportingBAL reports = new ReportingBAL();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                //string ratecode = Request.QueryString["RateCode"].ToString();
                ds = reports.GetDeclineLetterReport_cr(MemberPolicyID, Convert.ToInt32(UserUID));
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    ViewState["Data"] = dt;
                    gvDecline.DataSource = dt;
                    gvDecline.DataBind();
                    //if there is records in dataset 
                    rvDeclineReport.Visible = true;
                    lblNoTextMsg.Visible = false;

                    //Creating a datasource 
                    ReportDataSource dataSource = new ReportDataSource("dsDeclineLetter_dsDeclineReport_dtDeclineReport", dt);
                    //Clearing records before fill report with data
                    rvDeclineReport.LocalReport.DataSources.Clear();
                    //Adding data to report
                    rvDeclineReport.LocalReport.DataSources.Add(dataSource);
                    // Refreshing report for new data add to report
                    rvDeclineReport.LocalReport.Refresh();
                }
                else
                {
                    MenuMasterPage_Cr.ShowNoResultFound(dt, gvDecline);
                    //If there is no data in data set then
                    rvDeclineReport.Visible = false;
                    lblNoTextMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void gvDecline_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["Data"] != null)
            {
                gvDecline.PageIndex = e.NewPageIndex;
                gvDecline.DataSource = ViewState["Data"];
                gvDecline.DataBind();
            }
        }
    }
}
