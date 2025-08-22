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
using GlimpsBAL;
using Microsoft.Reporting.WebForms;
using GlimpsDAL;

public partial class PolicyInformation_PremiumStatement : System.Web.UI.Page
{
    string UserUID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[CommonConstantNames.USERUID] != null)
        {
            UserUID = Session[CommonConstantNames.USERUID].ToString();
            
        }
        else
        {
            Response.Redirect("~/LoginPage.aspx", true);
        }
        if (!IsPostBack)
        {
            CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "PremiumStatement.aspx");
        }
    }
    private void BindPremiumState(string XML)
    {
        try
        {
            ReportingBAL reports = new ReportingBAL();
            DataSet dsResult = new DataSet();
            //string ratecode = Request.QueryString["RateCode"].ToString();
            dsResult =  reports.GetPremiumStatement(Convert.ToInt32(UserUID), XML);
            if (dsResult != null)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    //if there is records in dataset 
                    rptPremiumStatement.Visible = true;
                    lblNoTextMsg.Visible = false;

                    //Creating a datasource 


                     rptPremiumStatement.LocalReport.DataSources.Clear();
                    //rptPremiumStatement.LocalReport.Refresh();
                    ReportDataSource datasource = new ReportDataSource("dsTermPremiumStatementFirstYearReport_dtTermPolicyDetail", dsResult.Tables[0]);
                    rptPremiumStatement.LocalReport.DataSources.Add(datasource);
                    
                    datasource = new ReportDataSource("dsTermPremiumStatementFirstYearReport_dtTermReceiptDetail", dsResult.Tables[1]);
                    rptPremiumStatement.LocalReport.DataSources.Add(datasource);
                    
                    datasource = new ReportDataSource("dsTermPremiumStatementFirstYearReport_dtTermBillDetail", dsResult.Tables[2]);
                    rptPremiumStatement.LocalReport.DataSources.Add(datasource);
                    
                    datasource = new ReportDataSource("dsTermPremiumStatementFirstYearReport_dtTermReportTag", dsResult.Tables[3]);
                    rptPremiumStatement.LocalReport.DataSources.Add(datasource);
                    
                    datasource = new ReportDataSource("dsTermPremiumStatementFirstYearReport_dtTermReportAmounts", dsResult.Tables[4]);
                    rptPremiumStatement.LocalReport.DataSources.Add(datasource);
                    rptPremiumStatement.LocalReport.Refresh();
                    //rptPremiumStatement.LocalReport.Refresh();
                    //Clearing records before fill report with data
                    //rptPremiumStatement.LocalReport.DataSources.Clear();
                    //Adding data to report
                    //rptPremiumStatement.LocalReport.DataSources.Add(datasource);
                    //Refreshing report for new data add to report
                   //rptPremiumStatement.LocalReport.Refresh();
                }
                else
                {
                    rptPremiumStatement.Visible = false;
                    lblNoTextMsg.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            


            string XML = "<params><param>";
            if (txtFromDate.Text!=string.Empty)
            {
                XML += "<FromDate>" + Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy") + "</FromDate>";    
            }
            if (txtToDate.Text != string.Empty)
            {
                XML += "<ToDate>" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "</ToDate>";
            }
            XML += "</param></params>";
            //Calling database for records to show
            BindPremiumState(XML);

            //Refreshing report for new data add to report
            rptPremiumStatement.LocalReport.Refresh();

            //processing reports from local 
            rptPremiumStatement.ProcessingMode = ProcessingMode.Local;
            ////Displaying data in reports
            LocalReport _report = rptPremiumStatement.LocalReport;
            _report.ReportPath = @"Reports/TermPremiumStatementFirstYearReport.rdlc";


            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("TALICHeaderNameParam", "Tata AIA Life Insurance Company Limited", true);
            rptPremiumStatement.LocalReport.SetParameters(param);
            trReport.Visible = true;   
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }
}
