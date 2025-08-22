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

public partial class NEL : System.Web.UI.Page
{
    string UserUID = string.Empty;
    string subOfficeUID = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
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
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "NEL.aspx");
                //Calling database for records to show
                BindNEL();
                //processing reports from local 
                rptNEL.ProcessingMode = ProcessingMode.Local;
                //Displaying data in reports
                LocalReport _report = rptNEL.LocalReport;
                _report.ReportPath = @"Reports/NELReport.rdlc";


            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);

        }
    }

    private void BindNEL()
    {
        try
        {
            ReportingBAL reports = new ReportingBAL();
            DataTable dt = new DataTable();
            //string ratecode = Request.QueryString["RateCode"].ToString();
            dt = reports.GetMedicalNonMedical(Convert.ToInt32(UserUID));
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    gvMedicalNonMedical.DataSource = dt;
                    ViewState["DATATABLE"] = dt;
                    gvMedicalNonMedical.DataBind();
                }
                else
                {
                    ViewState["DATATABLE"] = null;
                    Masters_MenuMasterPage.ShowNoResultFound(dt, gvMedicalNonMedical);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    protected void gvMedicalNonMedical_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddMLCode")
        {
            try
            {
                tbReport.Visible = true;
                ReportingBAL reports = new ReportingBAL();
                DataTable dt = new DataTable();
                dt = reports.GetNELChartReport(Convert.ToInt32(UserUID));
                if (dt != null && dt.Rows.Count > 0)
                {
                    //if there is records in dataset 
                    rptNEL.Visible = true;
                    lblNoTextMsg.Visible = false;

                    //Creating a datasource 
                    ReportDataSource dataSource = new ReportDataSource("dsPremiumRateReport_dtNEL", dt);
                    //Clearing records before fill report with data
                    rptNEL.LocalReport.DataSources.Clear();
                    //Adding data to report
                    rptNEL.LocalReport.DataSources.Add(dataSource);
                    //Refreshing report for new data add to report
                    rptNEL.LocalReport.Refresh();
                }
                else
                {
                    //If there is no data in data set then
                    rptNEL.Visible = false;
                    lblNoTextMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
    }

    protected void gvMedicalNonMedical_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["DATATABLE"] != null)
        {
            gvMedicalNonMedical.PageIndex = e.NewPageIndex;
            gvMedicalNonMedical.DataSource = ViewState["DATATABLE"];
            gvMedicalNonMedical.DataBind();
        }
    }
}
