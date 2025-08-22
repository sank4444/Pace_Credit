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
using System.IO;
using GlimpsBAL;
using GlimpsDAL;

namespace PACE.PolicyInformation
{
    public partial class ServiceHistory : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        ////DataSet dtPolicyYear = null;
        //_objConfigurationBAL _objConfigurationBAL = null;
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
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "ServiceHistory.aspx");
                BindMemberListing();
            }
        }
        private void BindMemberListing()
        {
            try
            {
                ReportingBAL reports = new ReportingBAL();
                DataSet ds = new DataSet();
                //string ratecode = Request.QueryString["RateCode"].ToString();
                ds = reports.GetMemberlisting(Convert.ToInt32(UserUID), "");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Data"] = ds;
                        gvServiceHistory.DataSource = ds.Tables[0];
                        gvServiceHistory.DataBind();
                    }
                    else
                    {
                        ViewState["Data"] = null;
                        Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], gvServiceHistory);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["Data"] != null)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=ServicingHistory.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvServiceHistory.AllowPaging = false;
                    gvServiceHistory.DataSource = (DataSet)ViewState["Data"];
                    gvServiceHistory.DataBind();

                    //gvServiceHistory.HeaderRow.BackColor = System.Web.Color.White;
                    foreach (TableCell cell in gvServiceHistory.HeaderRow.Cells)
                    {
                        cell.BackColor = gvServiceHistory.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvServiceHistory.Rows)
                    {
                        // row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvServiceHistory.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvServiceHistory.RowStyle.BackColor;
                            }
                            //cell.CssClass = "textmode";
                        }
                    }

                    gvServiceHistory.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.Clear();
                    Response.End();
                    //gvServiceHistory.DataSource = ds;
                    //gvServiceHistory.DataBind();
                    //Response.Clear();
                    //Response.AddHeader("content-disposition", "attachment;filename=PolicyWiseMemberList.xls");
                    //Response.Charset = String.Empty;
                    //Response.ContentType = "application/ms-excel";
                    //StringWriter stringWriter = new StringWriter();
                    //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(stringWriter);
                    //gvServiceHistory.RenderControl(HtmlTextWriter);
                    //Response.Write(stringWriter.ToString());
                    //Response.End();
                }
            }
        }

        protected void gvServiceHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["Data"] != null)
            {

                gvServiceHistory.PageIndex = e.NewPageIndex;

                gvServiceHistory.DataSource = (DataSet)ViewState["Data"];
                gvServiceHistory.DataBind();
            }
        }
    }
}
