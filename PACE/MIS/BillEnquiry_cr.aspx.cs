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
using PACE.Masters;


namespace PACE.MIS
{
    public partial class BillEnquiry_cr : System.Web.UI.Page
    {
        

        #region private variables
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        string exlName = string.Empty; 
        #endregion

        #region Page event

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if (id.ToString() == "ClientMIS")
            {
                lblreportname.Text = "Client MIS Enquiry";
                exlName = "ClientMIS";
            }
            else if (id.ToString() == "IssMIS")
            {
                lblreportname.Text = "Issuance MIS Enquiry";
                exlName = "IssuanceMIS";
            }
            else if (id.ToString() == "MediMIS")
            {
                lblreportname.Text = "Medical MIS Enquiry";
                exlName = "MedicalMIS";
            }
            else if (id.ToString() == "PendMIS")
            {
                lblreportname.Text = "Pending MIS Enquiry";
                exlName = "PendingMIS";
            }
            else if (id.ToString() == "RefMIS")
            {
                lblreportname.Text = "Refund MIS Enquiry";
                exlName = "RefundMIS";
            }
            else if (id.ToString() == "FreeMIS")
            {
                lblreportname.Text = "Free Look MIS Enquiry";
                exlName = "FreeLookMIS";
            }
            else if (id.ToString() == "SurrMIS")
            {
                lblreportname.Text = "Surrender MIS Enquiry";
                exlName = "SurrenderMIS";
            }
            else if (id.ToString() == "SnapMIS")
            {
                lblreportname.Text = "Snapshot Branch Wise MIS Enquiry";
                exlName = "SnapshotBranchMIS";
                //lblreportname.Text = "Certificate of Insurance Dispatch MIS Enquiry";
            }
           // exlName = lblreportname.Text;
            //else if (id.ToString() == "ClaimMIS")
            //{
            //    lblreportname.Text = "Claim MIS Enquiry";
            //}

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
                    CommonMethods.InsertingPageInfo_cr("I", UserUID, "BillEnquiry_cr.aspx");
                    //((HtmlTableCell)this.Page.Master.FindControl("BillEnquiry1")).Attributes.Add("class", "active");   //commented by Sanket on 21/05/2025
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
            string Searchaction = string.Empty; 

            imgExportToExcel.Visible = true;

            BillEnquiryBAL objBillEnquiryBAL = null;
            DataSet ds = null;
            try
            {
                //if (ds != null) //lblReportName.Text = "ClaimMIS"
                //{
                    // string billNo = txtBillNo.Text.ToString().Trim();

                     Searchaction =  Request.QueryString["id"];
                //string FromDate = txtPeriodFrom.Text.ToString().Trim();
                string FromDate = Convert.ToDateTime(txtPeriodFrom.Text).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);   //added by Sanket on 7/8/2025
                //string FromTo = txtPeriodTo.Text.ToString().Trim();
                string FromTo = Convert.ToDateTime(txtPeriodTo.Text).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);    //added by Sanket on 7/8/2025

                ds = new DataSet();
                    objBillEnquiryBAL = new BillEnquiryBAL();
                    //ds = objBillEnquiryBAL.GetBillEnquiry_cr(billNo, int.Parse(UserUID), FromDate, FromTo);
                    ds = objBillEnquiryBAL.GetBillEnquiry_cr(int.Parse(UserUID), FromDate, FromTo, Searchaction);
                   
                if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ViewState["DataBind"] = ds.Tables[0];

                            BindGrid(ds.Tables[0]);
                        }
                        else
                        {
                            MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvBillEnuiry);
                        }
                    }
                }
          //  }
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
                    //trExcel.Visible = true; commneted by sanket on 21/05/2025
                    //trGrid.Visible = true;
                    //added by sanket on 21/05/2025
                    gvBillEnuiry.UseAccessibleHeader = true;
                    gvBillEnuiry.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //-------------------------------------
                }
                else
                {
                    //trExcel.Visible = false;  commneted by sanket on 21/05/2025
                    MenuMasterPage_Cr.ShowNoResultFound(dt, gvBillEnuiry);
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
                Response.AddHeader("content-disposition", "attachment;filename=" + exlName + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvBillEnuiry.AllowPaging = false;
                    gvBillEnuiry.DataSource = (DataTable)ViewState["DataBind"];
                    gvBillEnuiry.DataBind();
                    gvBillEnuiry.RenderControl(hw);
                    string style = @"<style> .textmode { } </style>";
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
}
