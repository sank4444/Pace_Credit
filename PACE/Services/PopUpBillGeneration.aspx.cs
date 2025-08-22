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
using GlimpsDAL;
using GlimpsBAL;

public partial class Services_PopUpBillGeneration : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        long BillUID;
        int UserUID=0;
        BillUID = Convert.ToInt32(Session["BillUID"]);
        if (Session[CommonConstantNames.USERUID] != null)
        {
            UserUID =Convert.ToInt32( Session[CommonConstantNames.USERUID]);
           
        }
        else
        {
            Response.Redirect("~/LoginPage.aspx", true);
        }
        
        if (!IsPostBack)
        {

            BillUID =Convert.ToInt64(Session[CommonConstantNames.BILLUID]);
            CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "PopUpBillGeneration.aspx");
            GetDataForReport(BillUID,UserUID);
            rpt1.ProcessingMode = ProcessingMode.Local;
            LocalReport _report = rpt1.LocalReport;
            _report.ReportPath = @"Reports\TermInvoiceReport.rdlc";
        }
    }
    protected void GetDataForReport(long BillUID ,int UserUID)
    {
        ReportingBAL objReportingBAL = new ReportingBAL();
        DataSet dsResult = new DataSet();

        dsResult = objReportingBAL.GetBillReport(BillUID, UserUID);
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                rpt1.Visible = true;
                ReportDataSource datasource = new ReportDataSource("dsPremiumRateReport_dtTermInvoice", dsResult.Tables[0]);
                rpt1.LocalReport.DataSources.Add(datasource);
                rpt1.LocalReport.Refresh();
            }
            else
            {
                rpt1.Visible = false;
                lblnomessage.Visible = true;
            }
        }
    }
}
