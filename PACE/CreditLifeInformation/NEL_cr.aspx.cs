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


namespace PACE.CreditLifeInformation
{
    public partial class NEL_cr : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        string PolicyUID = string.Empty;   //added by sanket on 8/7/2025

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["sPolicyNMLCode"] = null;
                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                   
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx", true);
                }
                if(IsPostBack)
                {
                    gvMedicalNonMedical.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvMedicalNonMedical.UseAccessibleHeader = true;
                }
               
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "NEL_cr.aspx");
                    //Calling database for records to show
                    BindNEL(UserUID, subOfficeUID);
                    //processing reports from local 

                    //commented by Sanket on 27/5/2025
                    //rptNEL.ProcessingMode = ProcessingMode.Local;
                    //Displaying data in reports
                    //LocalReport _report = rptNEL.LocalReport;
                    //_report.ReportPath = @"Reports/NELReport.rdlc";
                    //-------------------------------------------


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);

            }
        }

        private void BindNEL(string UserId, string subofficeUId)
        {
            try
            {
                PolicyUID = Session[CommonConstantNames.POLICYUID].ToString();    //added by Sannket on 8/8/2025
                ReportingBAL reports = new ReportingBAL();
                DataTable dt = new DataTable();
                //DataSet ds = new DataSet();
                //string ratecode = Request.QueryString["RateCode"].ToString();
                PolicyInformationBAL policyInformationBAL = new PolicyInformationBAL();

                //DataTable dtCreditInformation_NEL = policyInformationBAL.BALNEL_cr(Convert.ToInt16(1), UserId);//Session[CommonConstants.sPOLICY_UID].ToString()  //commented by Sanket on 8/8/2025
                DataTable dtCreditInformation_NEL = policyInformationBAL.BALNEL_cr(Convert.ToInt16(PolicyUID), UserId);

                //dt = reports.GetMedicalNonMedical_cr(Convert.ToInt32(UserUID));

                //dt = ds.Tables[0];
                if (dtCreditInformation_NEL != null)
                {
                    if (dtCreditInformation_NEL.Rows.Count > 0)
                    {
                        gvMedicalNonMedical.DataSource = dtCreditInformation_NEL;//dt
                        ViewState["DATATABLE"] = dtCreditInformation_NEL;
                        gvMedicalNonMedical.DataBind();

                        gvMedicalNonMedical.HeaderRow.TableSection = TableRowSection.TableHeader;
                        gvMedicalNonMedical.UseAccessibleHeader = true;
                    }
                    else
                    {
                        ViewState["DATATABLE"] = null;
                        MenuMasterPage_Cr.ShowNoResultFound(dtCreditInformation_NEL, gvMedicalNonMedical);
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
            PolicyInformationBAL policyInformationBAL = new PolicyInformationBAL();
            DataSet dsPolicyRate = new DataSet();
            //trgv.Visible = true; 
            divNonMedicalCodeDetails.Visible = true;  //added by Sanket on 27/5/2025
            //if (e.CommandName == "AddMLCode")
            //{
                try
                {
                    //tbReport.Visible = true;
                    //ReportingBAL reports = new ReportingBAL();
                    //DataTable dt = new DataTable();
                    ////dt = reports.GetNELChartReport(Convert.ToInt32(UserUID));
                    // dt = reports.GetNELChartReport_cr(Convert.ToInt32(UserUID));
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    //if there is records in dataset 
                    //    rptNEL.Visible = true;
                    //    lblNoTextMsg.Visible = false;
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NewWindow", "window.open('../Report_CreditLife/PremiumRateReport_cr.aspx?RateCode=" + e.CommandArgument.ToString() + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
                    //    //Creating a datasource 
                    //    ReportDataSource dataSource = new ReportDataSource("dsPremiumRateReport_dtNEL", dt);
                    //    //Clearing records before fill report with data
                    //    rptNEL.LocalReport.DataSources.Clear();
                    //    //Adding data to report
                    //    rptNEL.LocalReport.DataSources.Add(dataSource);
                    //    //Refreshing report for new data add to report
                    //    rptNEL.LocalReport.Refresh();
                    //}
                    //else
                    //{
                    //    //If there is no data in data set then
                    //    rptNEL.Visible = false;
                    //    lblNoTextMsg.Visible = true;
                    //}

                    switch (e.CommandName)
                    {
                        case "VIEWMEDICODE":
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NewWindow", "window.open('../Report_CreditLife/MedicalGridReport_cr.aspx?RateCode=" + e.CommandArgument.ToString() + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
                            break;
                        case "VIEWNONMEDICODE":
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NewWindow", "window.open('../Report_CreditLife/PremiumRateReport_cr.aspx?RateCode=" + e.CommandArgument.ToString() + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
                            string MedicalNonMedicalMappingUID = e.CommandArgument.ToString();// Convert.ToInt16(item.GetDataKeyValue("MedicalNonMedicalMappingUID"));
                            Session["sPolicyNMLCode"] = MedicalNonMedicalMappingUID;
                            dsPolicyRate = policyInformationBAL.GetPolicyNonMedicalLimit_cr(MedicalNonMedicalMappingUID,"S", UserUID);
                            ViewState["DATATABLE_Non"] = dsPolicyRate.Tables[0];
                            gvNonMedicalCodeDetails.DataSource = dsPolicyRate.Tables[0];
                            gvNonMedicalCodeDetails.DataBind();
                            //added by Sanket on 27/5/2025
                            gvNonMedicalCodeDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                            gvNonMedicalCodeDetails.UseAccessibleHeader = true;
                            //------------------------------------
                        break;

                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
                }
            //}
        }

        protected void gvMedicalNonMedical_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["DATATABLE"] != null)
            {
                gvMedicalNonMedical.PageIndex = e.NewPageIndex;
                gvMedicalNonMedical.DataSource = ViewState["DATATABLE"];
                gvMedicalNonMedical.DataBind();
                //added by Sanket on 27/5/2025
                gvMedicalNonMedical.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvMedicalNonMedical.UseAccessibleHeader = true;
                //------------------------------------
            }
        }
        //gvNonMedicalCodeDetails_PageIndexChanging
        protected void gvNonMedicalCodeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["DATATABLE_Non"] != null)
            {
                gvNonMedicalCodeDetails.PageIndex = e.NewPageIndex;
                gvNonMedicalCodeDetails.DataSource = ViewState["DATATABLE_Non"];
                gvNonMedicalCodeDetails.DataBind();
                //added by Sanket on 27/5/2025
                gvNonMedicalCodeDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvNonMedicalCodeDetails.UseAccessibleHeader = true;
                //------------------------------------
            }
        }
    }
}
