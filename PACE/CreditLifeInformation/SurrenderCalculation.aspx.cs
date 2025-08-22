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

    public partial class SurrenderCalculation : System.Web.UI.Page
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
                    PolicyUID = Session["PolicyUID"].ToString();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : Please Select Policy from SubOffice Access Page');", true);
                   // Response.Redirect("~/LoginPage.aspx");
                }
               // ((HtmlTableCell)this.Page.Master.FindControl("Calculation1")).Attributes.Add("class", "active");  //commented by Sanket 6/8/2025
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "SurrenderCalculation.aspx");
                    //trExcel.Visible = false;
                    divExport.Visible = false;  //added by Sanket on 5/8/2025
                    FillPolicy();
                }
            }
            catch (Exception ex)
            {
                
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
                
            }


        }

        //gvSurrCal_PageIndexChanging
        protected void gvSurrCal_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvSurrCal.PageIndex = e.NewPageIndex;
            GridBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GridBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void GridBind()
        {
            MemberInfoBAL memberInfoBAL = new MemberInfoBAL();
            try
            {
                PolicyUID = Convert.ToString(Session["PolicyUID"]);
                PolicyUID = Convert.ToString(ddlPolicy.SelectedValue.ToString());

                DataSet ds = memberInfoBAL.GetSurrenderCal_cr(Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString()), Convert.ToString(txtCOI.Text), Convert.ToString(txtasondate.Text), PolicyUID);
                ViewState["DATA"] = ds.Tables[0];
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //trExcel.Visible = true;
                        divExport.Visible = true;  //added by Sanket on 5/8/2025
                        gvSurrCal.Visible = true;
                        gvSurrCal.DataSource = ds;
                        gvSurrCal.DataBind();
                        lblFormulaName.Text = ds.Tables[0].Rows[0]["FormulaName"].ToString();
                        lblFormula.Text = ds.Tables[0].Rows[0]["Formula"].ToString();
                    }
                    else
                    {
                        //MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvMembeInfo);
                        PACE.Masters.MenuMasterPage_Cr.ShowNoResultFound(ds.Tables[0], gvSurrCal);
                       // tdGrid.Visible = true;  //commented by Sanket on 6/8/2025
                        gvSurrCal.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void FillPolicy()
        {
            try
            {
                DataSet dsSumassured = new DataSet();
                _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();

                dsSumassured = objConfigurationBAL.PolicyBAL(UserUID, PolicyUID);
                if (dsSumassured.Tables[0].Rows.Count > 0)
                {
                    ddlPolicy.DataSource = dsSumassured;
                    ddlPolicy.DataValueField = dsSumassured.Tables[0].Columns["PolicyUID"].ToString();
                    ddlPolicy.DataTextField = dsSumassured.Tables[0].Columns["PolicyNumber"].ToString();
                    ddlPolicy.DataBind();
                    ddlPolicy.Items.Insert(0, (new ListItem("Select Policy", "0")));
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        //protected void imgExportToExcel_Click(object sender, ImageClickEventArgs e)
        //{
        //    ExportToExcel();
        //}
        //added by Sanket on 6/8/2025
        protected void imgExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        //---------------------------------
        protected void ExportToExcel()
        {
            if (ViewState["DATA"] != null)
            {
                gvSurrCal.Visible = true;
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Surrender.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvSurrCal.AllowPaging = false;
                    gvSurrCal.DataSource = (DataTable)ViewState["DATA"];
                    gvSurrCal.DataBind();
                    gvSurrCal.Columns[0].Visible = false;
                    gvSurrCal.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvSurrCal.HeaderRow.Cells)
                    {
                        cell.BackColor = gvSurrCal.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvSurrCal.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvSurrCal.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvSurrCal.RowStyle.BackColor;
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

                    gvSurrCal.RenderControl(hw);
                    //style to format numbers to string   
                    //string style = @"<style> .GridViewStyle { } </style>";
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
