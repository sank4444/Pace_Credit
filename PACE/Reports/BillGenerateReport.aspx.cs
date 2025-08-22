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
using Microsoft.Reporting.WebForms;
using GlimpsBAL;
using GlimpsDAL;

public partial class Services_BillGenerateReport : System.Web.UI.Page
{
    int UserUID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[CommonConstantNames.USERUID] != null)
        {
            UserUID =Convert.ToInt32( Session[CommonConstantNames.USERUID].ToString());
            
        }
        else
        {
            Response.Redirect("~/LoginPage.aspx", true);
        }
        if (!IsPostBack)
        {
            CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "BillGenerateReport.aspx");
            long BillNo =Int64.Parse(Request.QueryString["BillNo"]);
            GetData(BillNo);
            rvBILL.ProcessingMode = ProcessingMode.Local;
            LocalReport _report = rvBILL.LocalReport;
            _report.ReportPath = @"Reports\TermInvoiceReport.rdlc";
        }
    }

    private void GetData(long Billno)
    {
        ReportingBAL objReportingBAL = new ReportingBAL();
        DataSet dsResult = new DataSet();

        dsResult = objReportingBAL.GetBillReport(Billno, UserUID);
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                rvBILL.Visible = true;
                ReportDataSource datasource = new ReportDataSource("dsPremiumRateReport_dtTermInvoice", dsResult.Tables[0]);
                rvBILL.LocalReport.DataSources.Add(datasource);
                rvBILL.LocalReport.Refresh();
            }
            else
            {
                rvBILL.Visible = false;
                lblnomessage.Visible = true;
            }
        }
    }
}
