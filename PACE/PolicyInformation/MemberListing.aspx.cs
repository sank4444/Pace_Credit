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
using Microsoft.Reporting.WebForms;
using GlimpsBAL;
using System.IO;
using System.Drawing;

public partial class PolicyInformation_MemberListing : System.Web.UI.Page
{
    string UserUID = string.Empty;
    DataSet dtPolicyYear = null;
    _objConfigurationBAL _objConfigurationBAL = null;

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
            CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "MemberListing.aspx");
            _objConfigurationBAL = new _objConfigurationBAL();
            dtPolicyYear = _objConfigurationBAL.GetPolicyYear(UserUID, "POLICYYEAR");
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

    private void BindMemberListing()
    {
        try
        {
            ReportingBAL reports = new ReportingBAL();
            DataSet ds = new DataSet();
            ds = reports.GetMemberlisting(Convert.ToInt32(UserUID), ddlPolicyYear.SelectedItem.Value.ToString());
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DATA"] = ds.Tables[0];
                    gvMemberList.DataSource = ds.Tables[0];
                    gvMemberList.DataBind();
                    btnExportToExcel.Visible = true;
                }
                else
                {
                    btnExportToExcel.Visible = false;
                    Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], gvMemberList);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    { }

    protected void ddlPolicyYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMemberListing();
    }

    protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
    {
        if ((DataTable)ViewState["DATA"] != null)
        {
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=MemberListing.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gvMemberList.AllowPaging = false;
                gvMemberList.DataSource = (DataTable)ViewState["DATA"];
                gvMemberList.DataBind();

                gvMemberList.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvMemberList.HeaderRow.Cells)
                {
                    cell.BackColor = gvMemberList.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvMemberList.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvMemberList.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvMemberList.RowStyle.BackColor;
                        }
                        //cell.CssClass = "textmode";
                    }
                }

                for (int i = 0; i < gvMemberList.Rows.Count; i++)
                {
                    GridViewRow row = gvMemberList.Rows[i];
                    for (int J = 0; J < row.Cells.Count; J++)
                    {
                        row.Cells[J].Attributes.Add("class", "textmode");
                    }
                }

                gvMemberList.RenderControl(hw);

                //style to format numbers to string

                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.Clear();
                Response.End();
            }
        }
    }

    protected void gvMemberList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["DATA"] != null)
        {
            gvMemberList.PageIndex = e.NewPageIndex;
            gvMemberList.DataSource = (DataTable)ViewState["DATA"];
            gvMemberList.DataBind();

        }
    }
}
