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

namespace PACE.CreditLifeInformation
{
    public partial class PremiumRates_cr : System.Web.UI.Page
    {
        
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["ratecode"] != null)
                {
                    BindPremiumRateReport(Session["ratecode"].ToString());
                }

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
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "PremiumRates_cr.aspx");
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                    BindGrid(UserUID, subOfficeUID);
                   
                    
                }
               //LS ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "New Window", "javascript:DataTableInGrid()", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void BindGrid(string UserId, string subofficeUId)
        {
            PolicyInformationBAL policyInformationBAL = new PolicyInformationBAL();
            DataTable dtPolicyInformation = policyInformationBAL.PremiumRates_cr(UserId);
            ViewState["Data"] = dtPolicyInformation;
            if (dtPolicyInformation != null)
            {
                if (dtPolicyInformation.Rows.Count > 0)
                {
                    gvPremiumRates.DataSource = dtPolicyInformation;
                    gvPremiumRates.DataBind();
                    gvPremiumRates.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvPremiumRates.UseAccessibleHeader = true;
                   
                }
                else
                {
                    BaseClass.ShowNoResultFound(dtPolicyInformation, gvPremiumRates);
                }
            }
        }
        protected void gvPremiumRates_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "VIEWRATECODE":
                  //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "New Window", "window.open('../Reports/PremiumRateReport_cr.aspx?RateCode=" + e.CommandArgument.ToString() + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
                  //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Resource.GLIMPSEResource.ResourceMsgKey, "window.open('../../Reports/PremiumRateReport.aspx?RateCode=" + ddlRateCode.SelectedValue + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=700,height=500');", true);// LS new
                    //working in local
                 //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NewWindow", "window.open('../Report_CreditLife/PremiumRateReport_cr.aspx?RateCode=" + e.CommandArgument.ToString() + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
                    string reate = e.CommandArgument.ToString().Trim();
                    Session["ratecode"] = reate;
                   // BindPremiumRateReport(reate);
                  break;
            }
            Response.Redirect("PremiumRates_cr.aspx");
           // 
        }

        //Ls Test Start
        private void BindPremiumRateReport(string ratecodeValue)
        {
            try
            {

                ReportingBAL reports = new ReportingBAL();
                DataTable dt = new DataTable();
               // string ratecode = Request.QueryString["RateCode"].ToString();
                dt = reports.GetPremiumRateChartReport_cr(ratecodeValue);

                //ReportingBAL reports = new ReportingBAL();
                //DataTable dt = new DataTable();
                //string ratecode = Request.QueryString["RateCode"].ToString();
                //dt = (DataTable)ViewState["Data"]; //reports.GetPremiumRateChartReport_cr(ratecode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ViewState["Data"] = dt;
                    //gvPremiumRates.DataSource = dt;
                    //gvPremiumRates.DataBind();
                    
                    rvPremiumRateReport.Visible = true;
                    lblNoTextMsg.Visible = false;

                    //rvPremiumRateReport.LocalReport.DataSources.Clear(); //LS
                    //Creating a datasource 
                    ReportDataSource dataSource = new ReportDataSource("dsPremiumRateReport_dtPremiumRateReport", dt);
                    //Clearing records before fill report with data
                  
                    //Adding data to report
                    rvPremiumRateReport.LocalReport.DataSources.Add(dataSource);
                    // Refreshing report for new data add to report

                    rvPremiumRateReport.ProcessingMode = ProcessingMode.Local;
                    LocalReport _report = rvPremiumRateReport.LocalReport;
                    _report.ReportPath = @"Report_CreditLife/PremiumRateReport.rdlc";
                    
                    rvPremiumRateReport.LocalReport.Refresh();
                    //trReport.Visible = true;

                 

                }
                else
                {
                    //MenuMasterPage_Cr.ShowNoResultFound(dt, gvPremiumRate);
                    //If there is no data in data set then
                    //rvPremiumRateReport.Visible = false;
                    lblNoTextMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }






    }
}
