using System;
using GlimpsDAL;
using GlimpsBAL;
using GlimpsDAL.Common;
using Resources;
using System.Web.UI;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PACE.Masters;


namespace PACE.Services_cr
{
    public partial class ServiceList_cr : System.Web.UI.Page
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
                   
                    if (Session["IsTTSL"].ToString().ToUpper() == "Y")
                    {
                        tdSRNo.InnerText = "Mobile Number";
                        REGNumber.Enabled = true;
                        trExcel.Visible = true;
                    }
                    else
                    {
                        REGNumber.Enabled = false;
                        trExcel.Visible = false;
                    }
                    //END
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx", true);
                }
                objServiceBAL = new ServiceBAL();
                ds = new DataSet();
                ((HtmlTableCell)this.Page.Master.FindControl("Servicing1")).Attributes.Add("class", "active");
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "ServiceList_cr.aspx");

                    ds = objServiceBAL.GetServiceList_cr(UserUID, "S", "");
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
                            MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvServiceList);
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
            if (!string.IsNullOrEmpty(txtServiceList.Text))
            {
                ds = objServiceBAL.GetServiceList_cr(UserUID, "S", txtServiceList.Text);
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
                        MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvServiceList);
                    }
                }
            }
        }

        protected void imgExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();
        }

        protected void ExportToExcel()
        {
            if ((DataTable)ViewState["Data"] != null)
            {
                gvServiceList.AllowPaging = false;
                gvServiceList.DataSource = (DataTable)ViewState["Data"];
                gvServiceList.DataBind();
                gvServiceList.Columns[0].Visible = false;
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Call_Center_History" + DateTime.Now.ToShortDateString() + ".xls");
                Response.Charset = String.Empty;
                Response.ContentType = "application/ms-excel";
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(stringWriter);
                gvServiceList.RenderControl(HtmlTextWriter);
                //Response.Write(stringWriter.ToString());
                Response.Output.Write(stringWriter.ToString());
                Response.Flush();
                Response.Clear();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
    }
}
