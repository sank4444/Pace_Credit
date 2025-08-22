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
using System.IO;
using System.Data.OleDb;
using System.Text;
using GlimpsBAL;
using System.Xml;
using System.Drawing;
using Resources;
using GlimpsDAL.Common;

namespace PACE.SubmissionScreen
{
    public partial class Submission : System.Web.UI.Page
    {
        int UserUID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[CommonConstantNames.USERUID] != null)
            {
                UserUID = Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString());

                if (!IsPostBack)
                {
                    FillDropDown();
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }

        }
        //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (Session["IsTTSL"].ToString().ToUpper() != "Y")
        //    {
        //        DdlServiceRequestTypeChange();
        //    }
        //    else if (Session["IsTTSL"].ToString().ToUpper() == "Y")
        //    {
        //        trchkPan.Visible = false;
        //    }

        //}
        private void FillDropDown()
        {
            try
            {
                _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();
                DataSet dsPolicyUId = objConfigurationBAL.Summsion_cr(UserUID);
                if (dsPolicyUId.Tables[0].Rows.Count > 0)
                {
                    ddlclint.DataSource = dsPolicyUId.Tables[0];
                    ddlclint.DataTextField = "ClientName";  //Convert.ToString(dsPolicyUId.Tables[0].Rows[0]["ClientName"]);//  CommonConstantNames.CLIENTUNITCODE;
                    ddlclint.DataValueField = "ClientCode"; //Convert.ToString(dsPolicyUId.Tables[0].Rows[0]["ClientCode"]); //CommonConstantNames.CLIENTUNITNAME; // CommonConstantNames.POL_SERVICING_CHANGE_CODE;
                    ddlclint.DataBind();
                    //ddlclint.Items.Insert(0, (new ListItem("Select servicing list", "0")));
                }

            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }

            //try
            //{
            //    DataSet dsddlService = new DataSet();
            //    _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();


            //    ddlServicingChange.DataSource = objConfigurationBAL.GetServicingList_cr(UserUID);
            //    DataSet dsddlData = objConfigurationBAL.GetServicingList_cr(UserUID);
            //    ViewState[CommonConstantNames.DROPDOWNLISTDATA] = dsddlData.Tables[0];
            //    DataSet dsPolicyUId = objConfigurationBAL.GetPolicyUID_cr(UserUID);
            //    if (dsPolicyUId.Tables[0].Rows.Count > 0)
            //    {
            //        //getting policyUID parameter because for servicing member deletion need Insert policyUID
            //        ViewState[CommonConstantNames.POLICYUID] = dsPolicyUId.Tables[0].Rows[0][CommonConstantNames.POLICYUID].ToString();

            //        ddlServicingChange.DataTextField = CommonConstantNames.POL_SERVICING_CHANGE_NAME;
            //        ddlServicingChange.DataValueField = CommonConstantNames.POL_SERVICING_CHANGE_CODE;
            //        ddlServicingChange.DataBind();
            //        ddlServicingChange.Items.Insert(0, (new ListItem("Select servicing list", "0")));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            //}
        }
    }
}
