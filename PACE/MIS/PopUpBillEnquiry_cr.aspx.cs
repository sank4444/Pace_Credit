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
using GlimpsDAL;
using GlimpsBAL;
using System.Drawing;
using GlimpsDAL.Common;

namespace PACE.MIS
{
    public partial class PopUpBillEnquiry_cr : System.Web.UI.Page
    {
        #region private variables
        int UserUID = 0;
        string subOfficeUID = string.Empty;
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session[CommonConstantNames.USERUID] != null)
                    {
                        UserUID = Convert.ToInt32(Session[CommonConstantNames.USERUID]);
                        subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                    }
                    else
                    {
                        Response.Redirect("~/LoginPage.aspx", true);
                    }
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "PopUpBillEnquiry_cr.aspx");
                    BillEnquiryBAL objBillEnquiryBAL = null;
                    DataSet dsMemberWiseBillingDetails = null;
                    try
                    {
                        string billNo = Request.QueryString["BillNo"].ToString().Trim();
                        dsMemberWiseBillingDetails = new DataSet();
                        objBillEnquiryBAL = new BillEnquiryBAL();
                        dsMemberWiseBillingDetails = objBillEnquiryBAL.GetPopUpBillEnquiry_cr(billNo, UserUID);
                        if (dsMemberWiseBillingDetails != null)
                        {
                            ViewState["DataBind"] = dsMemberWiseBillingDetails.Tables[0];
                            if (dsMemberWiseBillingDetails.Tables[0].Rows.Count > 0)
                            {
                                txtClient.Text = Convert.ToString(dsMemberWiseBillingDetails.Tables[0].Rows[0][CommonConstantNames.CLIENTNAME]).Trim();
                                txtPolicyNo.Text = Convert.ToString(dsMemberWiseBillingDetails.Tables[0].Rows[0][CommonConstantNames.POLICYNUMBER]).Trim();
                                txtSubOffice.Text = Convert.ToString(dsMemberWiseBillingDetails.Tables[0].Rows[0]["Sub_Office_Name"]).Trim();
                                txtBillNo.Text = Convert.ToString(dsMemberWiseBillingDetails.Tables[0].Rows[0]["BillNo"]).Trim();
                                BindGrid((DataTable)ViewState["DataBind"]);
                            }
                            else
                            {
                                ShowNoResultFound(dsMemberWiseBillingDetails.Tables[0], gvExportgridid);
                                gvExportgridid.Visible = true;
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('" + Resources.Resource.MsgRecordNotFound + "');close_window();", true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        #endregion

        private void ShowNoResultFound(DataTable source, GridView gv)
        {
            try
            {
                source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable
                // Bind the DataTable which contain a blank row to the GridView
                gv.DataSource = source;
                gv.DataBind();
                // Get the total number of columns in the GridView to know what the Column Span should be
                int columnsCount = gv.Columns.Count;
                gv.Rows[0].Cells.Clear();// clear all the cells in the row
                gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                //You can set the styles here
                gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                gv.Rows[0].Cells[0].Font.Bold = true;
                //set No Results found to the new added cell
                gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }


        private void BindGrid(DataTable dt)
        {
            try
            {
                gvExportgridid.DataSource = dt;
                gvExportgridid.Visible = true;
                gvExportgridid.DataBind();

            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void ImgBtnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            ConfigureExport(gvExportgridid, txtPolicyNo.Text);
        }

        public void ConfigureExport(GridView PendingGridView, string Fname)
        {
            gvExportgridid.Visible = true;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + Fname + "_MemberWiseBill.xls");
            Response.Charset = String.Empty;
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gvExportgridid.AllowPaging = false;
                gvExportgridid.DataSource = (DataTable)ViewState["DataBind"];
                gvExportgridid.DataBind();
                gvExportgridid.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvExportgridid.HeaderRow.Cells)
                {
                    cell.BackColor = gvExportgridid.HeaderStyle.BackColor;

                }
                foreach (GridViewRow row in gvExportgridid.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvExportgridid.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvExportgridid.RowStyle.BackColor;
                        }
                        //cell.CssClass = "textmode";
                    }
                }

                gvExportgridid.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                gvExportgridid.Visible = false;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        { }
        protected void gvExportgridid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExportgridid.PageIndex = e.NewPageIndex;
            if (ViewState["DataBind"] != null)
            {
                BindGrid((DataTable)ViewState["DataBind"]);
            }

        }
    }
}
