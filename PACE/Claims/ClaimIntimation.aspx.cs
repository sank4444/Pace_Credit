using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using GlimpsDAL;
using GlimpsBAL;
using GlimpsDAL.Common;
using Resources;
using System.Collections.Generic;

namespace PACE.Claims
{
    public partial class ClaimIntimation : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[CommonConstantNames.USERUID] != null)
            {
                UserUID = Session[CommonConstantNames.USERUID].ToString();
                subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                //TTSL Change
                //Added by Karunakar on 28-04-2016 START
                if (Session["IsTTSL"].ToString().Trim().ToLower() == "y") trTTSL.Visible = true;
                else trTTSL.Visible = false;
                //END
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }
            ((HtmlTableCell)this.Page.Master.FindControl("Claims")).Attributes.Add("class", "active");
            if (IsPostBack != true)
            {
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "ServiceRequest.aspx");
                FillDropDownCategory();
                if (Request.QueryString.Count > 0)
                {
                    txtCOI.Text = Request.QueryString["COI"].ToString();
                    txtInsuredMember.Text = Request.QueryString["InsuredName"].ToString();
                }
            }
        }

        #region Category
        private void FillDropDownCategory()
        {
            ClaimBAL objConfigurationBAL = null;
            DataSet ds = null;
            try
            {
                objConfigurationBAL = new ClaimBAL();
                ds = new DataSet();
                ds = objConfigurationBAL.categoryDDL(UserUID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCategory.DataSource = ds;
                    ddlCategory.DataTextField = CommonConstantNames.COMMONLISTNAME;
                    ddlCategory.DataValueField = CommonConstantNames.COMMONLISTUID;
                    ddlCategory.DataBind();
                }
                else
                {
                    ddlCategory.Items.Insert(0, new ListItem("No Record", "0"));
                    ddlCategory.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        #endregion

        protected void imgSaveService_Click(object sender, ImageClickEventArgs e)
        {

            HttpPostedFile Myfile = fuServiceRequest.PostedFile;
            ClaimInfo objClaimInfo = new ClaimInfo();
            string strFileType = System.IO.Path.GetExtension(Myfile.FileName).ToString().ToLower();
            string strFileName = DateTime.Now.ToString(Resource.DateFormat_ddMMyyyy_HHmmss) + "ServiceRquest" + strFileType.ToString();
            DataSet ds = new DataSet();
            if ((strFileType.ToUpper() == ".PDF" && strFileType.ToUpper() != "") || (strFileType.ToUpper() == ""))
            {
                ClaimBAL objClaimBAL = new ClaimBAL();
                ServiceBAL objServiceBAL = new ServiceBAL();
                //Saving in local folder
                string FilePath = HttpContext.Current.Request.PhysicalApplicationPath + "FileUploades\\";
                Myfile.SaveAs(Server.MapPath("~/FileUploades/" + strFileName.ToString()));

                //redirecting to local excel 
                objClaimInfo.FilePath = Server.MapPath("~/FileUploades/" + strFileName.ToString());
                string type = "CLR";
                objClaimInfo.category = ddlCategory.SelectedItem.Value.ToString();
                objClaimInfo.COI = txtCOI.Text.ToString();
                objClaimInfo.DtofDeath = txtDtofDeath.Text;
                objClaimInfo.CauseDeath = txtCauseDeath.Text;
                objClaimInfo.NameCaler = txtNameCaler.Text;
                objClaimInfo.RelcalInsured = txtRelcalInsured.Text;
                objClaimInfo.Address = txtAddress.Text;
                objClaimInfo.MobileNoCaler = txtMobileCler.Text;
                //Inserting into data base
                DataSet dsMsg = objClaimBAL.SavingClaimRequest(objClaimInfo, UserUID, type);
                if (dsMsg.Tables[0].Rows.Count > 0)
                {
                    ClientScriptManager csm = Page.ClientScript;
                    string strconfirm = "<script>if(window.alert('" + dsMsg.Tables[0].Rows[0]["DisplayMessage"].ToString() + ". If you want to log in another claim intimation, please click ok.')){window.location.href='OnlineClaimTracking.aspx'}</script>"; csm.RegisterClientScriptBlock(typeof(Page), "Confirm", strconfirm, false);
                    byte[] bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/FileUploades/" + strFileName.ToString()));
                    int i = objServiceBAL.SendinMailWithAttachment(UserUID, bytes, dsMsg.Tables[0].Rows[0]["ServicingRequestNo"].ToString());
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('data not saved');", true);
                }

                ClearControls();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : Only PDF files are accepted!');", true);
            }
        }

        private void ClearControls()
        {
            ddlCategory.SelectedIndex = 0;
            txtCOI.Text = string.Empty;
            txtInsuredMember.Text = string.Empty;
            txtCauseDeath.Text = string.Empty;
            txtDtofDeath.Text = string.Empty;

            //Added by Karunakar on 20-05-2016 for ttsl start

            txtAddress.Text = string.Empty;
            txtNameCaler.Text = string.Empty;
            txtMobileCler.Text = string.Empty;
            txtRelcalInsured.Text = string.Empty;
            //end
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpSearch", "window.open('../Services/PopUpCommonSearch.aspx', '_blank', 'width=960,height=600, scrollbars=yes,resizable=yes')", true);
        }
    }
}
