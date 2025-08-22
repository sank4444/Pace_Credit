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
using GlimpsBAL;
using GlimpsDAL;
using System.Globalization;
using System.IO;
using System.Drawing;
using GlimpsDAL.Common;
using System.Collections.Generic;


public partial class Bill_Enquiry_BillEnquiry : System.Web.UI.Page
{
    #region private variables
    string UserUID = string.Empty;
    string subOfficeUID = string.Empty;
    #endregion

    #region Page event

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
                CommonMethods.InsertingPageInfo("I", UserUID, "BillEnquiry.aspx");
                ((HtmlTableCell)this.Page.Master.FindControl("BillEnquiry")).Attributes.Add("class", "active");
            }
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }
    #endregion

    #region Click Events..
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BillEnquiryBAL objBillEnquiryBAL = null;
        DataSet ds = null;
        try
        {
            string billNo = txtBillNo.Text.ToString().Trim();
            string FromDate = txtPeriodFrom.Text.ToString().Trim();
            string FromTo = txtPeriodTo.Text.ToString().Trim();

            ds = new DataSet();
            objBillEnquiryBAL = new BillEnquiryBAL();
            ds = objBillEnquiryBAL.GetBillEnquiry(billNo, int.Parse(UserUID), FromDate, FromTo);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataBind"] = ds.Tables[0];

                    BindGrid(ds.Tables[0]);
                }
                else
                {
                    Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], gvBillEnuiry);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    protected void imgExportToExcel_Click(object sender, ImageClickEventArgs e)
    {
        ExportToExcel();
    }

    protected void gvBillEnuiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        if (ViewState["DataBind"] != null)
        {
            gvBillEnuiry.PageIndex = e.NewPageIndex;
            BindGrid((DataTable)ViewState["DataBind"]);
        }
    }
    #endregion

    #region Functions..

    private void BindGrid(DataTable dt)
    {
        try
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                imgExportToExcel.Visible = true;
                gvBillEnuiry.DataSource = dt;
                ViewState["DataBind"] = dt;
                gvBillEnuiry.Visible = true;
                gvBillEnuiry.DataBind();
                trExcel.Visible = true;
                trGrid.Visible = true;
            }
            else
            {
                trExcel.Visible = false;
                Masters_MenuMasterPage.ShowNoResultFound(dt, gvBillEnuiry);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    #endregion

    #region Export to Excel
    //Export to Excel
    protected void ExportToExcel()
    {
        if (ViewState["DataBind"] != null)
        {
            gvBillEnuiry.Visible = true;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=BillPayment.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gvBillEnuiry.AllowPaging = false;
                gvBillEnuiry.DataSource = (DataTable)ViewState["DataBind"];
                gvBillEnuiry.DataBind();
                gvBillEnuiry.Columns[0].Visible = false;
                gvBillEnuiry.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvBillEnuiry.HeaderRow.Cells)
                {
                    cell.BackColor = gvBillEnuiry.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvBillEnuiry.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvBillEnuiry.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvBillEnuiry.RowStyle.BackColor;
                        }
                        //cell.CssClass = "textmode";
                        List<Control> controls = new List<Control>();

                        //Add controls to be removed to Generic List
                        foreach (Control control in cell.Controls)
                        {
                            controls.Add(control);
                        }

                        //Loop through the controls to be removed and replace then with Literal
                        foreach (Control control in controls)
                        {
                            if (control.GetType().Name == "Label")
                            {
                                cell.Controls.Add(new Literal { Text = (control as Label).Text });

                                cell.Controls.Remove(control);

                            }
                        }
                    }
                }

                gvBillEnuiry.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .GridViewStyle { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.Clear();
                Response.End();
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {/* Verifies that the control is rendered */}
    #endregion
    protected void gvBillEnuiry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "printPdf")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "openWindowInvoice(" + e.CommandArgument.ToString() + ");", true);
        }
    }
}
