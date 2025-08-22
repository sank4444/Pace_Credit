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

namespace PACE.CreditLifeInformation
{
   
    public partial class COpyPolicySubOfficeAccess_cr : System.Web.UI.Page
    {
        private string SearchText
        {
            get => ViewState["SearchText"]?.ToString() ?? "";
            set => ViewState["SearchText"] = value;
        }
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
                CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "COpyPolicySubOfficeAccess_cr.aspx");
                //InsertingPageInfo_cr PolicySubOfficeAccess_cr.aspx  COpyPolicySubOfficeAccess_cr.aspx

                //((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation1")).Attributes.Add("class", "top_newtab_link");  //commented by Sanket on 16/5/2025

                //((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation")).Attributes.Add("class", "tab_link_active"); tab_link_active 
                objPolicyInformationBAL = new PolicyInformationBAL();
                dt = new DataTable();
                if (!IsPostBack)
                {
                    BindGrid();
                }
                //added by Sanket on 31/5/2025
                else
                {
                    gvPolAccess.UseAccessibleHeader = true;
                    gvPolAccess.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                //--------------------------------------
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }

        }
        private void BindGrid()
        {
           
            dt = objPolicyInformationBAL.GetPolicySubOfficeAccess_cr(UserUID, "S");
            //dt = objPolicyInformationBAL.GetPolicySubOfficeAccess(UserUID, "S");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    gvPolAccess.DataSource = dt;
                    ViewState["DATA"] = dt;
                    gvPolAccess.DataBind();
                    gvPolAccess.UseAccessibleHeader = true;
                    gvPolAccess.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //added by Sanket on 5/6/2025
                    int startIndex = gvPolAccess.PageIndex * gvPolAccess.PageSize + 1;
                    int endIndex = Math.Min(startIndex + gvPolAccess.PageSize - 1, dt.Rows.Count);

                    lblPagingSummary.Text = $"Showing {startIndex} to {endIndex} of {dt.Rows.Count} entries";
                    //---------------------------------------------
                }
                else
                {
                    //LS Masters_MenuMasterPage.ShowNoResultFound(dt, gvPolAccess);
                     PACE.Masters.MenuMasterPage_Cr.ShowNoResultFound(dt, gvPolAccess);
                }
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "changingGrid", "displayingGrid();", true);
            }
        }
        protected void gvPolAccess_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
               // Session["PolicyUID"] = string.Empty;

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
                        int i = 0; //GetPolicySubOfficeAccessSelect_Cr
                        i = objPolicyInformationBAL.GetPolicySubOfficeAccessSelect_Cr(UserUID, e.CommandArgument.ToString(), "U");
                        if (i > 0)
                        {
                            BindGrid();
                            if (ViewState["DATA"] != null)
                            {
                                DataTable dt = ((DataTable)ViewState["DATA"]);

                               if(dt.Rows[RowIndex]["SELECTEDFLAG"].ToString().ToUpper() == "Y")
                                {
                                    Session["PolicyUID"] = dt.Rows[RowIndex]["PolicyUID"].ToString().ToUpper();
                                    BindGrid();

                                }
                                if (dt.Rows[RowIndex]["ClientDetailFlag"].ToString().ToUpper() == "N")
                                {
                                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "", "alert('Please update suboffice contact detail.');", true);
                                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "", "window.location = '../ContactInformation/ContactInformation.aspx';", true);
                                    //Response.Redirect("../ContactInformation/ContactInformation.aspx");
                                }
                                
                                //Response.Clear();
                                //Response.Redirect("COpyPolicySubOfficeAccess_cr.aspx");
                                //Response.End();
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('" + ((HiddenField)gvPolAccess.Rows[RowIndex].FindControl("hndDisplayMessage")).Value.ToString() + "');", true);
                    }

                }
               // Response.Redirect("COpyPolicySubOfficeAccess_cr.aspx");
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
                if (gvPolAccess.Rows.Count > 1)
                {
                    for (int i = 0; i < gvPolAccess.Rows.Count; i++)
                    {
                        if (((HiddenField)gvPolAccess.Rows[i].FindControl("hndSelectedFlag")).Value.ToString().ToUpper() == "Y")
                        {
                            gvPolAccess.Rows[i].ForeColor = System.Drawing.Color.Black;
                            ((LinkButton)gvPolAccess.Rows[i].FindControl("lnkSelectPolicy")).Text = "Selected";
                            //Session["PolicyUID"] =  gvPolAccess.Rows[0]["PolicyUID"].ToString();
                        }
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
        protected void search_TextChanged(object sender, EventArgs e)
        {
            SearchText = search.Text.Trim();
            gvPolAccess.PageIndex = 0; // reset to first page
            BindGrid();
        }
        protected void entries_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPolAccess.PageSize = Convert.ToInt32(entries.SelectedValue);
            BindGrid();
        }
    }
}
