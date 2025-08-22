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
using GlimpsDAL;
using System.IO;
using GlimpsBAL;
using System.Drawing;
using System.Collections.Generic;
using PACE.Masters;

namespace PACE.MIS
{
    public partial class BillPayment_cr : System.Web.UI.Page
    {
        #region private variables
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        BillEnquiryBAL objBillEnquiryBAL = null;
        DataSet dsBillPayment = null;
        DataSet dsFloat = null;
        DataSet dsNonFloat = null;
        System.Globalization.DateTimeFormatInfo pattern = new System.Globalization.DateTimeFormatInfo();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];

            if (Session[CommonConstantNames.USERUID] != null)
            {
                UserUID = Session[CommonConstantNames.USERUID].ToString();
                
                if (Session["IsTTSL"].ToString().ToUpper() == "Y")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "TTSLErrorFlag();", true);
                }
               
                subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }


            if (!IsPostBack)
            {
                CommonMethods.InsertingPageInfo_cr("I", UserUID, "BillPayment_cr.aspx");
                ((HtmlTableCell)this.Page.Master.FindControl("BillEnquiry1")).Attributes.Add("class", "active");
                GetBillPayMent(string.Empty, string.Empty);
                GetNonFloat();
                GetFloat();
            }
        }

        #region ...Page Methods

        private void GetBillPayMent(string ToDate, string FromDate)
        {
            try
            {
                objBillEnquiryBAL = new BillEnquiryBAL();
                dsBillPayment = new DataSet();
                string ACTION = string.Empty;
                string convToDate = ToDate == "" ? ToDate : Convert.ToDateTime(ToDate, pattern).ToString("MM/dd/yyyy");
                string convFromDate = FromDate == "" ? FromDate : Convert.ToDateTime(FromDate, pattern).ToString("MM/dd/yyyy");
                dsBillPayment = objBillEnquiryBAL.GetBillPayMent_cr(UserUID, convToDate, convFromDate, ACTION);

                if (dsBillPayment != null)
                {
                    if (dsBillPayment.Tables[0].Rows.Count > 0)
                    {
                        trGrid.Visible = true;
                        trPayBtn.Visible = true;
                        ImgBtnExportToExcel.Visible = true;
                        ViewState["DATA"] = dsBillPayment.Tables[0];
                        gvBillPayment.DataSource = dsBillPayment.Tables[0];
                        gvBillPayment.DataBind();
                    }
                    else
                    {
                        MenuMasterPage_Cr.ShowNoResultFound(dsBillPayment.Tables[0], gvBillPayment);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        /// <summary>
        /// Control Enablity
        /// </summary>
        private void _ClearControl()
        {
            try
            {
                txtFloatSuspenseAmt.Text = string.Empty;
                txtPolicySuspenseAmt.Text = string.Empty;
                txtSubOffFloatAmt.Text = string.Empty;
                txtSubOffSuspenseAmt.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void GetNonFloat()
        {
            try
            {
                objBillEnquiryBAL = new BillEnquiryBAL();
                dsNonFloat = new DataSet();
                string ACTION = "SUSPENSEAMOUNT";
                // dsNonFloat = objBillEnquiryBAL.GetNonFloat(UserUID, ACTION);
                dsNonFloat = objBillEnquiryBAL.GetNonFloat_cr(UserUID, ACTION);
                if (dsNonFloat != null && dsNonFloat.Tables.Count > 0 && dsNonFloat.Tables[0].Rows.Count > 0)
                {
                    txtPolicySuspenseAmt.Text = dsNonFloat.Tables[0].Rows[0]["PolSubOfficeSuspenseAmt"].ToString();// == null ? "0.00" : dsNonFloat.Tables[0].Rows[0]["PolSubOfficeSuspenseAmt"].ToString();
                    txtFloatSuspenseAmt.Text = dsNonFloat.Tables[0].Rows[0]["FloatSubOfficeSuspenseAmt"].ToString();// == null ? "0.00" : dsNonFloat.Tables[0].Rows[0]["FloatSubOfficeSuspenseAmt"].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void GetFloat()
        {
            try
            {
                objBillEnquiryBAL = new BillEnquiryBAL();
                dsFloat = new DataSet();
                string ACTION = "FLOATSUSPENSEAMOUNT";
                dsFloat = objBillEnquiryBAL.GetFloat_cr(UserUID, ACTION);
                if (dsFloat != null && dsFloat.Tables.Count > 0 && dsFloat.Tables[0].Rows.Count > 0)
                {
                    txtSubOffSuspenseAmt.Text = dsFloat.Tables[0].Rows[0]["PolSubOfficeSuspenseAmt"].ToString();
                    txtSubOffFloatAmt.Text = dsFloat.Tables[0].Rows[0]["FloatSubOfficeSuspenseAmt"].ToString();
                    txtCountofOutstandingBill.Text = dsFloat.Tables[0].Rows[0]["CountOfBill"].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        #endregion

        #region ...Export To Excel
        public override void VerifyRenderingInServerForm(Control control)
        { }
        protected void ImgBtnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            ConfigureExport(gvBillPayment);
        }

        public void ConfigureExport(GridView PendingGridView)
        {
            if ((DataTable)ViewState["DATA"] != null)
            {
                gvBillPayment.Visible = true;
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=BillPayment.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvBillPayment.AllowPaging = false;
                    gvBillPayment.DataSource = (DataTable)ViewState["DATA"];
                    gvBillPayment.DataBind();

                    gvBillPayment.HeaderRow.BackColor = Color.White;

                    foreach (TableCell cell in gvBillPayment.HeaderRow.Cells)
                    {
                        cell.BackColor = gvBillPayment.HeaderStyle.BackColor;
                        if (cell.Text.ToLower().Equals("select") || cell.Text.ToLower().Equals("float"))
                        {
                            cell.Visible = false;
                        }
                    }
                    foreach (GridViewRow row in gvBillPayment.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            List<Control> controls = new List<Control>();

                            //Add controls to be removed to Generic List
                            foreach (Control control in cell.Controls)
                            {
                                controls.Add(control);
                            }

                            //Loop through the controls to be removed and replace then with Literal
                            foreach (Control control in controls)
                            {

                                cell.Controls.Remove(control);
                                cell.Visible = false;
                            }
                        }
                    }

                    gvBillPayment.RenderControl(hw);

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







        #endregion


        protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
        {
            _ClearControl();
        }

        protected void imgPay_Click(object sender, ImageClickEventArgs e)
        {
            BillEnquiryBAL objBillEnquiryBAL = null;
            try
            {
                objBillEnquiryBAL = new BillEnquiryBAL();
                string XML = string.Empty;
                for (int i = 0; i < gvBillPayment.Rows.Count; i++)
                {
                    XML += "<params><param>";
                    bool chk = ((CheckBox)gvBillPayment.Rows[i].FindControl("chkPay")).Checked;
                    string FloatFlag = ((DropDownList)gvBillPayment.Rows[i].FindControl("ddlFloat")).SelectedItem.Value;
                    string BillUID = ((HiddenField)gvBillPayment.Rows[i].FindControl("hndBillUID")).Value;

                    if (chk == true)
                    {
                        XML += "<BillUID>" + BillUID + "</BillUID><FloatFlag>" + FloatFlag + "</FloatFlag>";
                    }
                    XML += "</param></params>";
                }


                int Error = 0;
                Error = objBillEnquiryBAL.InsertBillPayment_cr(UserUID, XML, "");
                if (Error > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Bill paid successfully.');", true);
                    GetBillPayMent(string.Empty, string.Empty);
                    GetFloat();
                    GetNonFloat();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Bill payment not processed.');", true);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void chkPay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkPay = (CheckBox)sender;
                double OutstandResultYesTotal = 0.0;
                double OutstandResultNoTotal = 0.0;
                foreach (GridViewRow row in gvBillPayment.Rows)
                {
                    if (((CheckBox)row.FindControl("chkPay")).Checked == true)
                    {
                        DropDownList ddlFloat = (DropDownList)row.FindControl("ddlFloat");
                        double outstandamt = Convert.ToDouble(((Label)row.FindControl("LblOutstandingAmt")).Text);

                        if (ddlFloat.SelectedValue == "Y" && outstandamt > 0.00)
                        {
                            OutstandResultYesTotal += outstandamt;
                            if (OutstandResultYesTotal > Convert.ToDouble(txtSubOffFloatAmt.Text))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Sub Office Level Float Suspense Amount is not Sufficient.');", true);
                                chkPay.Checked = false;
                                ddlFloat.Focus();
                                imgPay.Visible = false;

                            }
                            else
                            {
                                imgPay.Visible = true;
                            }
                        }
                        else if (ddlFloat.SelectedValue == "N")
                        {
                            OutstandResultNoTotal += outstandamt;
                            if (OutstandResultNoTotal > Convert.ToDouble(txtSubOffSuspenseAmt.Text))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Sub Office Level Suspense Amount is not Sufficient.');", true);
                                chkPay.Checked = false;
                                ddlFloat.Focus();
                                imgPay.Visible = false;
                            }
                            else
                            {
                                imgPay.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void gvBillPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["DATA"] != null)
            {
                gvBillPayment.PageIndex = e.NewPageIndex;
                gvBillPayment.DataSource = (DataTable)ViewState["DATA"];
                gvBillPayment.DataBind();
            }
        }
    }
}
