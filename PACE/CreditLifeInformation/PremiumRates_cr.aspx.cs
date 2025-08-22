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
using PACE.Masters;
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
                else
                {
                        gvPremiumRates.HeaderRow.TableSection = TableRowSection.TableHeader;
                        gvPremiumRates.UseAccessibleHeader = true;
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "New Window", "javascript:DataTableInGrid()", true);
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
            if (dtPolicyInformation != null)
            {
                if (dtPolicyInformation.Rows.Count > 0)
                {
                    gvPremiumRates.DataSource = dtPolicyInformation;
                    gvPremiumRates.DataBind();
                    gvPremiumRates.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvPremiumRates.UseAccessibleHeader = true;
                    //added by Sanket on 20/6/2025
                    int startIndex = gvPremiumRates.PageIndex * gvPremiumRates.PageSize + 1;
                    int endIndex = Math.Min(startIndex + gvPremiumRates.PageSize - 1, dtPolicyInformation.Rows.Count);
                    lblPagingSummaryMain.Text = $"Showing {startIndex} to {endIndex} of {dtPolicyInformation.Rows.Count} entries";
                    //------------------------
                    //

                }
                else
                {
                    BaseClass.ShowNoResultFound(dtPolicyInformation, gvPremiumRates);
                }
            }
        }
        protected void gvPremiumRates_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //commeted by Sanket on 31/5/2025
            //switch (e.CommandName)
            //{
            //    case "VIEWRATECODE":
            //      //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "New Window", "window.open('../Reports/PremiumRateReport_cr.aspx?RateCode=" + e.CommandArgument.ToString() + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
            //      //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Resource.GLIMPSEResource.ResourceMsgKey, "window.open('../../Reports/PremiumRateReport.aspx?RateCode=" + ddlRateCode.SelectedValue + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=700,height=500');", true);// LS new

            //      ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NewWindow", "window.open('../Report_CreditLife/PremiumRateReport_cr.aspx?RateCode=" + e.CommandArgument.ToString() + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
            //        break;
            //}
            //--------------------------------
            //added by Sanket on 31/5/2025
            if (e.CommandName == "VIEWRATECODE")
            {
                string RateCode = e.CommandArgument.ToString();
                BindPremiumRateReport(RateCode);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#PremiumRateModal').modal('show');", true);
            }
                //-------------------------------
        }

        //added by Sanket on 31/5/2025
        private void BindPremiumRateReport(string RateCode)
        {
            try
            {
                ReportingBAL reports = new ReportingBAL();
                DataTable dt = new DataTable();
                dt = reports.GetPremiumRateChartReport_cr(RateCode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ViewState["Data"] = dt;
                    gvPremiumRateReport.DataSource = dt;
                    gvPremiumRateReport.DataBind();
                    gvPremiumRateReport.Visible = true;
                    lblNoTextMsg.Visible = false;
                    int startIndex = gvPremiumRateReport.PageIndex * gvPremiumRateReport.PageSize + 1;
                    int endIndex = Math.Min(startIndex + gvPremiumRateReport.PageSize - 1, dt.Rows.Count);
                    lblPagingSummary.Text = $"Showing {startIndex} to {endIndex} of {dt.Rows.Count} entries";
                    //------------------------
                }
                else
                {
                    MenuMasterPage_Cr.ShowNoResultFound(dt, gvPremiumRateReport);
                    gvPremiumRateReport.Visible = false;
                    lblNoTextMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        protected void gvPremiumRateReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["Data"] != null)
            {
                gvPremiumRateReport.PageIndex = e.NewPageIndex;
                gvPremiumRateReport.DataSource = ViewState["Data"];
                gvPremiumRateReport.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#PremiumRateModal').modal('show');", true);
            }
        }

        //-----------------------------
        protected void btncancel_Click(object sender, EventArgs e)
        {
            // Inject JavaScript to hide modal and remove backdrop
            string script = @"
                const modalElement = document.getElementById('PremiumRateModal');
                const modalInstance = bootstrap.Modal.getInstance(modalElement);
                if (modalInstance) {
                modalInstance.hide();
                }
                 document.body.classList.remove('modal-open');
                 document.querySelectorAll('.modal-backdrop').forEach(el => el.remove());
                ";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", script, true);
        }
    }
}
