using System;
using System.Data;
using System.Web;
using System.Web.UI;
using GlimpsBAL;
using GlimpsDAL;
using GlimpsDAL.Common;
using System.Web.UI.HtmlControls;
using PACE.Masters;
using System.Web.UI.WebControls;

namespace PACE.MemberInformation_cr
{
    public partial class MemberInformation_cr : System.Web.UI.Page
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
                    Response.Redirect("~/LoginPage.aspx");
                }
                //((HtmlTableCell)this.Page.Master.FindControl("MemberInformation_cr")).Attributes.Add("class", "active");  //commented by Sanket on 19/5/2025
                
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "MemberInformation_cr.aspx");
                    gvMembeInfo.Visible = false;
                    lblResult.Visible = false;
                    
                    // FillPolicy();
                }
                if (Session["CoiNo"] != null || Session["MemberInfoName"] != null || Session["LoanRefNo"] != null)
                {
                    //var master = (MenuMasterPage_Cr)this.Master;
                    //master.headerMaster.Visible = false;
                    //master.InfoBarMaster.Visible = false;
                    //master.FooteMaster.Visible = false;
                    //MemberInfoDetails.Visible = false;
                    txtCoiNo.Text = Session["CoiNo"].ToString();
                    txtName.Text = Session["MemberInfoName"].ToString();
                    txtLoanRefNo.Text = Session["LoanRefNo"].ToString();
                    BindGridAfterMemberDetails();
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        //private void FillPolicy()
        //{
        //    try
        //    {
        //        DataSet dsSumassured = new DataSet();
        //        _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();

        //        dsSumassured = objConfigurationBAL.PolicyBAL(UserUID, "");
        //        if (dsSumassured.Tables[0].Rows.Count > 0)
        //        {
        //            ddlPolicy.DataSource = dsSumassured;
        //            ddlPolicy.DataValueField = dsSumassured.Tables[0].Columns["PolicyUID"].ToString();
        //            ddlPolicy.DataTextField = dsSumassured.Tables[0].Columns["PolicyNumber"].ToString();
        //            ddlPolicy.DataBind();
        //            ddlPolicy.Items.Insert(0, (new ListItem("Select Policy", "0")));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        //    }
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            MemberInfoBAL memberInfoBAL = null;
            try
            {
                lblResult.Visible = false;
                memberInfoBAL = new MemberInfoBAL();
                DataSet ds = memberInfoBAL.GetMemberInfo_cr( Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString()), Convert.ToString(txtCoiNo.Text), Convert.ToString(txtName.Text),  Convert.ToString(txtLoanRefNo.Text));

               
                //For Bind Grid 
                ViewState["DATA"] = ds.Tables[0];
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //creating for MemberInfopopup page data  
                        Session[CommonConstantNames.POLICYUID] = ds.Tables[0].Rows[0][CommonConstantNames.POLICYUID];
                        //tdGrid.Visible = true;  //commented by Sanket on 19/5/2025
                        gvMembeInfo.Visible = true;
                        BindGrid();
                    }
                    else
                    {
                        //Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], gvMembeInfo);
                        MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvMembeInfo);
                        //tdGrid.Visible = true;   //commented by Sanket on 19/5/2025
                        gvMembeInfo.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }

        }
        protected void gvMembeInfo_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvMembeInfo.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        private void BindGrid()
        {

            if ((DataTable)ViewState["DATA"] != null)
            {
                if (((DataTable)ViewState["DATA"]).Rows.Count > 0)
                {
                    gvMembeInfo.DataSource = (DataTable)ViewState["DATA"];
                    gvMembeInfo.DataBind();
                    //added by Sanket on 26/5/2025
                    gvMembeInfo.UseAccessibleHeader = true;
                    gvMembeInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //added by Sanket on 8/8/2025
                    int startIndex = gvMembeInfo.PageIndex * gvMembeInfo.PageSize + 1;
                    int endIndex = Math.Min(startIndex + gvMembeInfo.PageSize - 1, ((DataTable)ViewState["DATA"]).Rows.Count);
                    lblPagingSummary.Text = $"Showing {startIndex} to {endIndex} of {((DataTable)ViewState["DATA"]).Rows.Count} entries";
                    //------------------------
                }
                else
                {
                    MenuMasterPage_Cr.ShowNoResultFound((DataTable)ViewState["DATA"], gvMembeInfo);
                    gvMembeInfo.DataBind();
                }
            }
        }
        private void BindGridAfterMemberDetails()
        {
            MemberInfoBAL memberInfoBAL = null;
            try
            {
                lblResult.Visible = false;
                memberInfoBAL = new MemberInfoBAL();
                DataSet ds = memberInfoBAL.GetMemberInfo_cr(Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString()), Convert.ToString(txtCoiNo.Text), Convert.ToString(txtName.Text), Convert.ToString(txtLoanRefNo.Text));


                //For Bind Grid 
                ViewState["DATA"] = ds.Tables[0];
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //creating for MemberInfopopup page data  
                        Session[CommonConstantNames.POLICYUID] = ds.Tables[0].Rows[0][CommonConstantNames.POLICYUID];
                        //tdGrid.Visible = true;  //commented by Sanket on 19/5/2025
                        gvMembeInfo.Visible = true;
                        gvMembeInfo.DataSource = ds.Tables[0];
                        gvMembeInfo.DataBind();
                        //added by Sanket on 8/8/2025
                        int startIndex = gvMembeInfo.PageIndex * gvMembeInfo.PageSize + 1;
                        int endIndex = Math.Min(startIndex + gvMembeInfo.PageSize - 1, ((DataTable)ViewState["DATA"]).Rows.Count);
                        lblPagingSummary.Text = $"Showing {startIndex} to {endIndex} of {((DataTable)ViewState["DATA"]).Rows.Count} entries";
                        //------------------------
                        Session["CoiNo"] =null;
                        Session["MemberInfoName"] =null;
                        Session["LoanRefNo"] =null;
                    }
                    else
                    {
                        //Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], gvMembeInfo);
                        MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvMembeInfo);
                        //tdGrid.Visible = true;   //commented by Sanket on 19/5/2025
                        gvMembeInfo.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void gvMembeInfo_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //added by Sanket on 8/8/2025
                Session["CoiNo"] = txtCoiNo.Text;
                Session["MemberInfoName"] = txtName.Text;
                Session["LoanRefNo"] = txtLoanRefNo.Text;
                Session[CommonConstantNames.POLICYMEMBERUID] = e.CommandArgument.ToString();
                string PolicyMemberUID = e.CommandArgument.ToString();
                string url = $"MemberInfoDetails_cr.aspx?PolicyMemberUID={PolicyMemberUID}";

                // Use JavaScript to set iframe src and show it
                string script = $@"
                                  document.getElementById('{childFrame.ClientID}').src='{url}';
                                  document.getElementById('{childFrame.ClientID}').style.display='block';
                                  document.getElementById('{memberEnquiryBlock.ClientID}').style.display='none';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "loadFrame", script, true);
                
                //LS
                //Response.Clear();
                //Response.Redirect("MemberInfoDetails_cr.aspx?PolicyMemberUID=" + e.CommandArgument.ToString() + "",true);
                //Response.End();
            }
        }

    }
}
