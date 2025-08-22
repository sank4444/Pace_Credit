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
using GlimpsDAL.Common;
using Microsoft.Reporting.WebForms;

namespace PACE.Reports
{
    public partial class ShowMTRFaspx : System.Web.UI.Page
    {
        string UserUID;
        ReportDataSource rptSource;

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
                ShowMTRFReport();
            }
        }
        private void ShowMTRFReport()
        {
            try
            {
                DataSet dsInsuredResult = null;
                
                dsInsuredResult = MemberInfoDAL.GetInsuredDetailsAndMTRF(UserUID, Session[CommonConstantNames.POLICYMEMBERUID].ToString());


                if (dsInsuredResult.Tables[0].Rows.Count > 0)
                {
                    rvMTRF.Visible = true;

                    rvMTRF.LocalReport.DataSources.Clear();
                    rvMTRF.LocalReport.ReportPath = @"Reports\\MTRFForm.rdlc";

                    rptSource = new ReportDataSource("DataSet1_Proc_PolicyMemberMedicalTest_Policy", dsInsuredResult.Tables[0]);
                    rvMTRF.LocalReport.DataSources.Add(rptSource);

                    if (dsInsuredResult.Tables[0].Rows.Count > 0)
                    {
                        rptSource = new ReportDataSource("DataSet1_dtMedicalTest", dsInsuredResult.Tables[1]);
                        rvMTRF.LocalReport.DataSources.Add(rptSource);
                    }

                    rvMTRF.LocalReport.Refresh();
                }
                else
                {
                    rvMTRF.Visible = false;
                    lblnomessage.Visible = true;
                }

            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "ErrorReport", "alert('" + ex.Message+ "');", true);
            }
        }
    }
}
