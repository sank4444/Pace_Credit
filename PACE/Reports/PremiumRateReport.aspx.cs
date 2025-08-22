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
public partial class Reports_PremiumRateReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        try
        { if (Session[CommonConstantNames.USERUID] != null)
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
               
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "PremiumRateReport.aspx");
                //Calling database for records to show
                BindPremiumRateReport();

                //processing reports from local 
                //rvPremiumRateReport.ProcessingMode = ProcessingMode.Local;
                //Displaying data in reports
                // LocalReport _report = rvPremiumRateReport.LocalReport;
                //_report.ReportPath = @"Reports/PremiumRateReport.rdlc";

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    private void BindPremiumRateReport()
    {
        try
        {
            ReportingBAL reports = new ReportingBAL();
            DataTable dt = new DataTable();
            string ratecode = Request.QueryString["RateCode"].ToString();
            dt = reports.GetPremiumRateChartReport(ratecode);
            if (dt != null && dt.Rows.Count > 0)
            {
                ViewState["Data"] = dt;
                gvPremiumRate.DataSource = dt;
                gvPremiumRate.DataBind();
                //if there is records in dataset 
                //rvPremiumRateReport.Visible = true;
                //lblNoTextMsg.Visible = false;

                //Creating a datasource 
                ReportDataSource dataSource = new ReportDataSource("dsPremiumRateReport_dtPremiumRateReport", dt);
                //Clearing records before fill report with data
                //rvPremiumRateReport.LocalReport.DataSources.Clear();
                //Adding data to report
                //rvPremiumRateReport.LocalReport.DataSources.Add(dataSource);
                //Refreshing report for new data add to report
                // rvPremiumRateReport.LocalReport.Refresh();
            }
            else
            {
                Masters_MenuMasterPage.ShowNoResultFound(dt, gvPremiumRate);
                //If there is no data in data set then
                //rvPremiumRateReport.Visible = false;
                //lblNoTextMsg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    protected void gvPremiumRate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Data"] != null)
        {
            gvPremiumRate.PageIndex = e.NewPageIndex;
            gvPremiumRate.DataSource = ViewState["Data"];
            gvPremiumRate.DataBind();
        }
    }
}
