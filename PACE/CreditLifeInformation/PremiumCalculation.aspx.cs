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
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace PACE.CreditLifeInformation
{
    public partial class PremiumCalculation1 : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string PolicyUID = string.Empty;
        string subOfficeUID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["PolicyUID"] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                    PolicyUID = Session[CommonConstantNames.POLICYUID].ToString();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : Please Select Policy from SubOffice Access Page');", true);
                }
              //((HtmlTableCell)this.Page.Master.FindControl("Calculation1")).Attributes.Add("class", "active");  //commented by Sanket on 6/8/2025
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "PremiumCalculation.aspx");
                    FillDropDownRider();
                    FillDrop_RATEOFINTEREST();
                    FillSumassuredType();
                    FillPremiummodeType();
                    FillSegmentCode();
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            MemberInfoBAL memberInfoBAL = new MemberInfoBAL();
            try
            {
                DataSet ds = memberInfoBAL.GetPremiumDataBAL(
                    PolicyUID.ToString(),
                    Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString()),
                    Convert.ToString(txtname.Text),
                    ddlRider.SelectedItem.Value.ToString(),
                    ddlrateIns.SelectedItem.Value.ToString(),
                    Convert.ToString(txtDob.Text),
                    ddlSumassuredType.SelectedItem.Value.ToString(),
                    ddlPremiumModeType.SelectedItem.Value.ToString(),
                    ddlGender.SelectedItem.Value.ToString(),
                    string.Empty,
                    Convert.ToString(txtPolicyTenure.Text),
                    Convert.ToString(txtLoanTenure.Text),
                    Convert.ToString(txtname2.Text),
                    ddlGender2.SelectedItem.Value.ToString(),
                    Convert.ToString(txtDob2.Text),
                    ddlSegment.SelectedValue.ToString(),
                    txtMoratorium.Text,
                    Convert.ToString(txtCover.Text),
                    txtSharing.Text
                    );

                ViewState["DATA"] = ds.Tables[0];
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //trExcel.Visible = true;  //commented by Sanket on 6/8/2025
                        imgExportToExcel.Visible = true;  //added by Sanket on 6/8/2025
                        gvPreCal.Visible = true;
                        gvPreCal.DataSource = ds.Tables[0];
                        gvPreCal.DataBind();

                    }
                    else
                    {
                        PACE.Masters.MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvPreCal);
                        //trGrid.Visible = true;  //commented by Sanket on 6/8/2025
                        gvPreCal.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }

        }

        private void FillDropDownRider()
        {
            try
            {
                DataSet dsddlService = new DataSet();
                _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();

                DataSet dsRider = objConfigurationBAL.premiumDll_cr(UserUID, PolicyUID);
                if (dsRider.Tables[0].Rows.Count > 0)
                {
                    ddlRider.DataSource = dsRider;
                    ddlRider.DataTextField = dsRider.Tables[0].Columns["RiderName"].ToString();
                    ddlRider.DataValueField = dsRider.Tables[0].Columns["RiderUID"].ToString();
                    ddlRider.DataBind();
                    ddlRider.Items.Insert(0, (new ListItem("Select Rider list", "0")));
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        //RATEOFINTEREST 
        private void FillDrop_RATEOFINTEREST()
        {
            try
            {
                DataSet dsRateOFInterest = new DataSet();
                _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();

                 dsRateOFInterest = objConfigurationBAL.RateOfInterest_cr(UserUID, PolicyUID);
                if (dsRateOFInterest.Tables[0].Rows.Count > 0)
                {
                    ddlrateIns.DataSource = dsRateOFInterest;
                    ddlrateIns.DataValueField = dsRateOFInterest.Tables[0].Columns["Record"].ToString();
                    ddlrateIns.DataValueField = dsRateOFInterest.Tables[0].Columns["Value"].ToString();
                    ddlrateIns.DataBind();
                    ddlrateIns.Items.Insert(0, (new ListItem("Select Rate of Interest", "0")));
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void FillPremiummodeType()
        {
            try
            {
                DataSet dsPremiummode = new DataSet();
                _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();

                dsPremiummode = objConfigurationBAL.PremiummodeTypeBAL(UserUID, PolicyUID);//PremiummodeType
                if (dsPremiummode.Tables[0].Rows.Count > 0)
                {
                    ddlPremiumModeType.DataSource = dsPremiummode;
                    ddlPremiumModeType.DataValueField = dsPremiummode.Tables[0].Columns["CommonListUID"].ToString();
                    ddlPremiumModeType.DataTextField = dsPremiummode.Tables[0].Columns["CommonListName"].ToString();
                    ddlPremiumModeType.DataBind();
                    ddlPremiumModeType.Items.Insert(0, (new ListItem("Select Premium mode Type list", "0")));
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void FillSumassuredType()
        {
            try
            {
                DataSet dsSumassured = new DataSet();
                _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();

                dsSumassured = objConfigurationBAL.SumassuredTypeBAL(UserUID, PolicyUID);
                if (dsSumassured.Tables[0].Rows.Count > 0)
                {
                    ddlSumassuredType.DataSource = dsSumassured;
                    ddlSumassuredType.DataValueField = dsSumassured.Tables[0].Columns["CommonListUID"].ToString();
                    ddlSumassuredType.DataTextField = dsSumassured.Tables[0].Columns["CommonListName"].ToString();
                    ddlSumassuredType.DataBind();
                    ddlSumassuredType.Items.Insert(0, (new ListItem("Select Sum Assured Type", "0")));
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void FillSegmentCode()
        {
            try
            {
                DataSet dsSumassured = new DataSet();
                _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();

                dsSumassured = objConfigurationBAL.SegmentCodeBAL(UserUID, PolicyUID);
                if (dsSumassured.Tables[0].Rows.Count > 0)
                {
                    ddlSegment.DataSource = dsSumassured;
                    ddlSegment.DataValueField = dsSumassured.Tables[0].Columns["Segmentcode"].ToString();
                    ddlSegment.DataTextField = dsSumassured.Tables[0].Columns["SegmentName"].ToString();
                    ddlSegment.DataBind();
                    ddlSegment.Items.Insert(0, (new ListItem("Select Segment Code", "0")));
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }



        protected void imgExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        protected void ExportToExcel()
        {
            if (ViewState["DATA"] != null)
            {
                //gvPreCal.Visible = true;
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=PremiumCalculation.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvPreCal.AllowPaging = false;
                    gvPreCal.DataSource = (DataTable)ViewState["DATA"];
                    gvPreCal.DataBind();
                    gvPreCal.Columns[0].Visible = false;
                    gvPreCal.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvPreCal.HeaderRow.Cells)
                    {
                        cell.BackColor = gvPreCal.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvPreCal.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvPreCal.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvPreCal.RowStyle.BackColor;
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

                    gvPreCal.RenderControl(hw);
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



    }
}
