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
using GlimpsDAL.Common;
using Resources;
using GlimpsDAL;
using GlimpsBAL;
using System.IO;

namespace PACE.Claims
{
    public partial class OnlineClaimTracking : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        DataSet ds = null;
        ServiceBAL objServiceBAL = null;
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
                objServiceBAL = new ServiceBAL();
                ds = new DataSet();
                ((HtmlTableCell)this.Page.Master.FindControl("Claims")).Attributes.Add("class", "active");
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "OnlineClaimTracking.aspx");

                    ds = objServiceBAL.GetServiceList(UserUID, "Claims", "");
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            gvServiceList.DataSource = ds.Tables[0];
                            ViewState["Data"] = ds.Tables[0];
                            gvServiceList.DataBind(); 
                        }
                        else
                        {
                            Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], gvServiceList);
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

        protected void gvServiceList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            if ((DataTable)ViewState["Data"] != null)
            {
                gvServiceList.PageIndex = e.NewPageIndex;
                gvServiceList.DataSource = (DataTable)ViewState["Data"];
                gvServiceList.DataBind();
            }
        }

        protected void imgSearchServ_Click(object sender, ImageClickEventArgs e)
        {
            ds = objServiceBAL.GetServiceList(UserUID, "Claims", txtServiceList.Text);
            if (ds != null)
            {
                gvServiceList.DataSource = ds.Tables[0];
                ViewState["Data"] = ds.Tables[0];
                gvServiceList.DataBind();
            }
        }
        protected void gvServiceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Button bts = e.CommandSource as Button;
            if (e.CommandName.ToLower() != "s")
            {
                return;
            }
            FileUpload fu = bts.FindControl("FU") as FileUpload;
            Label lblSRNo = bts.FindControl("lblSRNo") as Label;
            
            if (fu.HasFile)
            {
                bool upload = true;
                string fleUpload = Path.GetExtension(fu.FileName.ToString());
                if (fleUpload.Trim().ToLower() == ".pdf")
                {
                    fu.SaveAs(Server.MapPath("~/FileUploades/" + fu.FileName.ToString()));
                    string uploadedFile = (Server.MapPath("~/FileUploades/" + fu.FileName.ToString()));
                    byte[] bytes = System.IO.File.ReadAllBytes(uploadedFile.ToString());
                    int i = objServiceBAL.SendinMailWithAttachment(UserUID, bytes, lblSRNo.Text);
                }
                else
                {
                    upload = false;
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : Please upload only .pdf!');", true);
                }
                if (upload)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message :  Uploaded file send mail successfully.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : Please upload file!');", true);
            }
        }
    }
}
