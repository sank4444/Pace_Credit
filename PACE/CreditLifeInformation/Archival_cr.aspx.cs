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
using System.IO;
using PACE.Masters;


namespace PACE.CreditLifeInformation
{
    public partial class Archival_cr : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        DataSet dtPolicyYear = null;
        _objConfigurationBAL _objConfigurationBAL = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.gvArchival);
                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "Archival_cr.aspx");
                    _objConfigurationBAL = new _objConfigurationBAL();
                    dtPolicyYear = _objConfigurationBAL.GetPolicyYear_cr(UserUID, "POLICYYEARARCHIVAL");
                    if (dtPolicyYear != null)
                    {
                        ddlPolicyYear.DataSource = dtPolicyYear;
                        ddlPolicyYear.DataTextField = "Select";
                        ddlPolicyYear.DataValueField = "SelectValue";
                        ddlPolicyYear.DataBind();
                        ddlPolicyYear.Items.Insert(0, (new ListItem("Select Period", "0")));
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
            finally
            {
                dtPolicyYear = null;
                _objConfigurationBAL = null;
            }
        }

        protected void ddlPolicyYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            PolicyInformationBAL _objPolicyInformationBAL = null;
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                _objPolicyInformationBAL = new PolicyInformationBAL();
                dt = _objPolicyInformationBAL.GetArchive(UserUID, ddlPolicyYear.SelectedItem.Value.ToString(), "", "S");
                if (dt != null && dt.Rows.Count > 0)
                {
                    //if (dt.Rows.Count > 0)
                    //{
                    ViewState["DATA"] = dt;
                    gvArchival.DataSource = dt;
                    gvArchival.DataBind();

                    gvArchival.UseAccessibleHeader = true;
                    gvArchival.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "changingGrid", "$('.display').DataTable();", true);
                }
                else
                {
                    MenuMasterPage_Cr.ShowNoResultFound(dt, gvArchival);
                    
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
            finally
            {
                _objPolicyInformationBAL = null;
                dt = null;
            }
        }



        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void gvArchival_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                switch (Convert.ToString(e.CommandName))
                {
                    case "download":

                        string filePath = Convert.ToString(e.CommandArgument);
                        if (File.Exists(filePath))
                        {
                            HttpContext.Current.Response.ContentType = ContentType;
                            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                            HttpContext.Current.Response.WriteFile(filePath);
                            HttpContext.Current.Response.End();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : file is not exist!');", true);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
    }
}
