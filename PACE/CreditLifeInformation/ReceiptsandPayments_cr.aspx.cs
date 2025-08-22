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
using GlimpsDAL.Common;
using GlimpsBAL;
using System.Drawing;
using System.IO;
using System.Globalization;
using PACE.Masters;

namespace PACE.CreditLifeInformation
{
    public partial class ReceiptsandPayments_cr : System.Web.UI.Page
    {
        //IFormatProvider culture = new System.Globalization.CultureInfo("En-Uk", true);
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        PolicyInformationBAL objPolicyInformationBAL = null;
        //DataSet dsInfo = null;
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
                ((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation")).Attributes.Add("class", "tab_link_active");
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", UserUID, "ContactInformation_cr.aspx");
                    // ContactInformation_cr.aspx Pending

                    FillDropDown();
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void FillDropDown()
        {
            objPolicyInformationBAL = new PolicyInformationBAL();
            try
            {
                ddlSelection.DataSource = objPolicyInformationBAL.GetReceiptsandPaymentsDDL_cr(UserUID, "RP");
                // GetReceiptsandPaymentsDDL_cr
                ddlSelection.DataTextField = "NAME";
                ddlSelection.DataValueField = "CODE";
                ddlSelection.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
            finally
            {
                objPolicyInformationBAL = null;
            }
        }

        protected void BindingGrid(string ACTION)
        {
            objPolicyInformationBAL = new PolicyInformationBAL();

            try
            {
                ReportingBAL reports = new ReportingBAL();
                DataSet ds = new DataSet();
                ds = objPolicyInformationBAL.GetReceiptsAndPaymentsGrid_cr(UserUID, ACTION, txtPeriodFrom.Text != string.Empty ? DateTime.ParseExact(txtPeriodFrom.Text, "dd/MM/yyyy", new CultureInfo("en-US")).ToString("MM/dd/yyyy") : string.Empty, txtPeriodTo.Text != string.Empty ? DateTime.ParseExact(txtPeriodTo.Text, "dd/MM/yyyy", new CultureInfo("en-US")).ToString("MM/dd/yyyy") : string.Empty);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DATA"] = ds.Tables[0];
                        gvReceiptPaymnet.Visible = true;
                        btnExportToExcel.Visible = true;
                        BindReceiptsPaymentsGrid(ds.Tables[0]);
                        gvReceiptPaymnet.UseAccessibleHeader = true;
                        gvReceiptPaymnet.HeaderRow.TableSection = TableRowSection.TableHeader;
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "changingGrid", "$('.display').DataTable({ 'lengthMenu': [[5, 10, 15, -1], [5, 10, 15, 'All']]});", true);
                    }
                    else
                    {
                        MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvReceiptPaymnet);
                        btnExportToExcel.Visible = false;
                    }
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
            finally
            {
                objPolicyInformationBAL = null;
            }
        }

        protected void ddlSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSelection.SelectedItem.Text.ToString() != "SELECT")
            {
                if (ddlSelection.SelectedItem.Text.ToString() != "Payment")
                {
                    // trPayMentDate.Visible = false;
                    //  trPayMentsearch.Visible = false;
                    BindingGrid(ddlSelection.SelectedItem.Text.ToString());

                }
                else
                {
                    gvReceiptPaymnet.Visible = false;
                    btnExportToExcel.Visible = false;
                    //trPayMentDate.Visible = true;
                    //trPayMentsearch.Visible = true;
                }
            }
            else
            {
                gvReceiptPaymnet.Visible = false;
                btnExportToExcel.Visible = false;
                //trPayMentDate.Visible = false;
                //trPayMentsearch.Visible = false;
            }
        }
        //protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        //{

        //}
        public override void VerifyRenderingInServerForm(Control control)
        { }


        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if ((DataTable)ViewState["DATA"] != null)
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + ddlSelection.SelectedItem.Text + ".xls");
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);

                        //To Export all pages
                        gvReceiptPaymnet.AllowPaging = false;
                        BindReceiptsPaymentsGrid((DataTable)ViewState["DATA"]);


                        //gvReceiptPaymnet.HeaderRow.BackColor = Color.White;
                        //foreach (TableCell cell in gvReceiptPaymnet.HeaderRow.Cells)
                        //{
                        //    cell.BackColor = gvReceiptPaymnet.HeaderStyle.BackColor;
                        //}
                        //foreach (GridViewRow row in gvReceiptPaymnet.Rows)
                        //{
                        //    row.BackColor = Color.White;
                        //    foreach (TableCell cell in row.Cells)
                        //    {
                        //        if (row.RowIndex % 2 == 0)
                        //        {
                        //            cell.BackColor = gvReceiptPaymnet.AlternatingRowStyle.BackColor;
                        //        }
                        //        else
                        //        {
                        //            cell.BackColor = gvReceiptPaymnet.RowStyle.BackColor;
                        //        }
                        //        //cell.CssClass = "textmode";
                        //    }
                        //}

                        gvReceiptPaymnet.RenderControl(hw);

                        //style to format numbers to string
                        //string style = @"<style> .textmode { } </style>";
                        //HttpContext.Current.Response.Write(style);
                        HttpContext.Current.Response.Output.Write(sw.ToString());
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void gvReceiptPaymnet_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gvReceiptPaymnet.PageIndex = e.NewSelectedIndex;
        }

        private void BindReceiptsPaymentsGrid(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                gvReceiptPaymnet.DataSource = dt;
                gvReceiptPaymnet.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlSelection.SelectedItem.Value != "0" && ddlSelection.SelectedItem.Text.ToLower() != "select")
            { BindingGrid(ddlSelection.SelectedItem.Text.ToString()); }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "validation", "alert('Message : Please select Receipts and Payment');", true);
                gvReceiptPaymnet.Visible = false;
                btnExportToExcel.Visible = false;
            }
        }

        protected void gvReceiptPaymnet_PreRender(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "displaying Grid", "displayingGrid()", true);
        }
    }
}
