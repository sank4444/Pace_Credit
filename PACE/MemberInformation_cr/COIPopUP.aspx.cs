using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using GlimpsBAL;
using GlimpsDAL;
using PACE.Masters;
using Microsoft.Reporting.WebForms;


namespace PACE.MemberInformation_cr
{
    public partial class COIPopUP : System.Web.UI.Page
    {

        string COINoimneeDetails = ConfigurationManager.ConnectionStrings["COINoimneeDetails"].ToString().Trim();
        string GeneratingPDFDynamically = ConfigurationManager.ConnectionStrings["GeneratingPDFDynamically"].ToString().Trim();
        string strPDF = ConfigurationManager.ConnectionStrings["PDF"].ToString().Trim();
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString().Trim();

       // string strCon = ConfigurationManager.ConnectionStrings["ConnectionStringTermDB"].ToString().Trim();
        DataSet ds = new DataSet();
        DataSet dsCOI = new DataSet();
        string xml = string.Empty;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               generateAutoInvoice();
                //DetailsReport();
            }
        }

        protected void gvCOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            //gvCOI.PageIndex = e.NewPageIndex;
            if (ViewState["DataBind"] != null)
            {
               // BindGrid((DataTable)ViewState["DataBind"]);
            }
            
        }
        public void generateAutoInvoice()
        {
            try
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                //string filenameExtension;
               // xml = "<params><param><EmployeeNo>" + Session["EmpCode"].ToString() + "</EmployeeNo><COI>" + Session["COI"].ToString() + "</COI></param></params>";
                xml = "<params><param><EmployeeNo>" + "1740" + "</EmployeeNo><COI>" + "1000000001" + "</COI></param></params>";

                dsCOI = getCOIData(); //null;//
                if (dsCOI != null & dsCOI.Tables.Count > 0)
                {
                    if (dsCOI.Tables[0].Rows.Count > 0)
                    {
                        LocalReport report = new LocalReport(); 
                        ReportDataSource dataSource = new ReportDataSource("PDFDT", dsCOI.Tables[0]);
                        //
                        ReportDataSource rds = new ReportDataSource();
                        rds.Value = dsCOI.Tables[0];  

                        rvPremiumRateReport.LocalReport.DataSources.Clear();
                        rvPremiumRateReport.LocalReport.DataSources.Add(dataSource);

                        report.ReportPath = Server.MapPath("~/Report1.rdlc"); //ls 
                        
                      //  report.LocalReport.DataSources.Add(dataSource);

                        
                        report.DataSources.Add(rds);
                       // byte[] bytes = rvPremiumRateReport.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                        Byte[] bytes = report.Render("PDF", null, out encoding, out encoding, out mimeType, out streamids, out warnings);

                        //Response.Buffer = true;
                        //Response.Clear();
                        //Response.ContentType = mimeType;
                        //Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
                        //Response.Flush(); // send it to the client to download  
                       //// HttpContext.Current.ApplicationInstance.CompleteRequest();

                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.Buffer = true;
                        Response.Clear();
                      //  Response.ContentType = contentType;
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + "COIDetails.pdf");
                        Response.WriteFile(Server.MapPath("~/GeneratedPDF/" + "COIDetails.pdf"));

                        Response.Flush();
                        Response.Close();
                        Response.End();  


                    }
                    else
                    {
                        ErrorDisplay("no data found");
                    }
                }



            }
            catch (Exception ex)
            {
                ErrorDisplay(ex.Message);
                //throw ex;
            }
        }



        private DataSet getCOIData()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strCon))//Proc_Certificate_of_Insurance_Report_Web
                // using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    SqlCommand cm = new SqlCommand("Proc_Certificate_of_Insurance_Report_Pace", cn);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.Connection = cn;
                    cm.Parameters.AddWithValue("@xmlDataStr", xml);
                    cm.Parameters.AddWithValue("@Action", "COI");
                    cm.Parameters.AddWithValue("@UserUID", 59);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    cn.Open();
                    da.Fill(dsCOI);
                    cn.Close();
                    return dsCOI;
                }
            }
            catch (Exception ex)
            {
                 ErrorDisplay(ex.Message);
               // throw ex;
                return dsCOI;
            }

        }

        private void ErrorDisplay(string message)
        {
            Session["ErrorMessage"] = message;
            string js = "";
            js += "window.opener.location.href='" + GeneratingPDFDynamically + "';";
            js += "window.close();";
            ClientScript.RegisterStartupScript(this.GetType(), "redirect", js, true);
        }

        public void DetailsReport()//New
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report1.rdlc");

             xml = "<params><param><EmployeeNo>" + "1740" + "</EmployeeNo><COI>" + "1000000001" + "</COI></param></params>";

             dsCOI = getCOIData();

            //ReportDataSource reportDataSource = new ReportDataSource();
             ReportDataSource reportDataSource = new ReportDataSource("Customers", dsCOI.Tables[0]);
           // reportDataSource = dsCOI;
            localReport.DataSources.Add(reportDataSource);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn.microsoft.com/en-us/library/ms155397.aspx
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report
            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
           // Response.AddHeader("content-disposition", "attachment; filename=NorthWindCustomers." + fileNameExtension);
           // return File(renderedBytes, mimeType);
        }

    }
}
