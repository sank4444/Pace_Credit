using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using GlimpsDAL;
using GlimpsBAL;
using GlimpsDAL.Common;
using Resources;

namespace PACE.PolicyInformation
{
    public partial class COpyPolicySubOfficeAccess : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        DataTable dt = null;
        PolicyInformationBAL objPolicyInformationBAL = null;
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
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "PolicySubOfficeAccess.aspx");

                ((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation")).Attributes.Add("class", "tab_link_active");
                objPolicyInformationBAL = new PolicyInformationBAL();
                dt = new DataTable();
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }

        }
        private void BindGrid()
        {
            dt = objPolicyInformationBAL.GetPolicySubOfficeAccess(UserUID, "S");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    gvPolAccess.DataSource = dt;
                    ViewState["DATA"] = dt;
                    gvPolAccess.DataBind();
                    gvPolAccess.UseAccessibleHeader = true;
                    gvPolAccess.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    Masters_MenuMasterPage.ShowNoResultFound(dt, gvPolAccess);
                }
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "changingGrid", "displayingGrid();", true);
            }
        }
        protected void gvPolAccess_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                objPolicyInformationBAL = new PolicyInformationBAL();
                if (e.CommandName == "Select")
                {
                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    int RowIndex = gvr.RowIndex;
                    if (((HiddenField)gvPolAccess.Rows[RowIndex].FindControl("hndPolSubStatusName")).Value.ToString().ToUpper() != "LAPSED" &&
                        ((HiddenField)gvPolAccess.Rows[RowIndex].FindControl("hndPolSubStatusName")).Value.ToString().ToUpper() != "TERMINATED")
                    {
                        if (((HiddenField)gvPolAccess.Rows[RowIndex].FindControl("hndPolSubStatusName")).Value.ToString().ToUpper() == "GRACE")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('" + ((HiddenField)gvPolAccess.Rows[RowIndex].FindControl("hndDisplayMessage")).Value.ToString() + "');", true);
                        }
                        int i = 0;
                        i = objPolicyInformationBAL.GetPolicySubOfficeAccessSelect(UserUID, e.CommandArgument.ToString(), "U");
                        if (i > 0)
                        {
                            BindGrid();
                            if (ViewState["DATA"] != null)
                            {
                                DataTable dt = ((DataTable)ViewState["DATA"]);
                                if (dt.Rows[RowIndex]["ClientDetailFlag"].ToString().ToUpper() == "N")
                                {
                                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "", "alert('Please update suboffice contact detail.');", true);
                                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "", "window.location = '../ContactInformation/ContactInformation.aspx';", true);
                                    // Response.Redirect("../ContactInformation/ContactInformation.aspx");
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('" + ((HiddenField)gvPolAccess.Rows[RowIndex].FindControl("hndDisplayMessage")).Value.ToString() + "');", true);
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void gvPolAccess_PreRender(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvPolAccess.Rows.Count; i++)
                {
                    if (((HiddenField)gvPolAccess.Rows[i].FindControl("hndSelectedFlag")).Value.ToString().ToUpper() == "Y")
                    {
                        gvPolAccess.Rows[i].ForeColor = System.Drawing.Color.Black;
                        ((LinkButton)gvPolAccess.Rows[i].FindControl("lnkSelectPolicy")).Text = "Selected";
                    }
                }
                
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void gvPolAccess_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["DATA"] != null)
            {
                gvPolAccess.PageIndex = e.NewPageIndex;
                gvPolAccess.DataSource = (DataTable)ViewState["DATA"];
                gvPolAccess.DataBind();
            }
        }
    }
}
