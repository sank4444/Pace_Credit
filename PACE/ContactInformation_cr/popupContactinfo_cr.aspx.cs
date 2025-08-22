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
namespace PACE.ContactInformation_cr
{
    public partial class popupContactinfo_cr : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        //_objConfigurationBAL objBAL = null;
        ContactInfoBAL contactInfoBAL = null;
        ContactInfo contactInfo = null;
        DataSet ds = new DataSet();
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
                    CommonMethods.InsertingPageInfo_cr("I", UserUID, "PopUpContactInfo_cr.aspx");
                    //get data table and checking is it dataset 
                    ContactInfoBAL contactInfoBAL = new ContactInfoBAL();
                    ds = contactInfoBAL.GetContactInfoPopUp_cr(UserUID);

                    Data(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        #region Fuctions

        /*Retriving Data for specific row values using Linq*/
        private void Data(DataTable dt)
        {
            //getting selected value of gridview row from ContactInfo.aspx
            string queryString = Request.QueryString.ToString();
            //getting select record from parentpage
            var SelectData = from data in dt.AsEnumerable()
                             where data.Field<Int32>("ClientUnitUID") == Convert.ToInt32(queryString)
                             select data;
            DataTable dtfiltter = SelectData.CopyToDataTable();
            fillControls(dtfiltter);
        }

        /*Filling Controls*/
        private void fillControls(DataTable dtfiltter)
        {
            try
            {
                ViewState["ClientUnitUID"] = dtfiltter.Rows[0]["ClientUnitUID"].ToString();

                lblUnitCode.Text = "&nbsp; " + dtfiltter.Rows[0]["ClientUnitCode"].ToString();
                txtContactNo.Text = dtfiltter.Rows[0]["ContactPersonContact"].ToString();
                txtEmail.Text = dtfiltter.Rows[0]["ContactPersonEmail"].ToString();
                txtContPerName.Text = dtfiltter.Rows[0]["ContactPerson"].ToString();
                txtDesignation.Text = dtfiltter.Rows[0]["ContactPersonDesignation"].ToString();
                txtAddress.Value = dtfiltter.Rows[0]["ADDRESS"].ToString();
                lblUnitName.Text = "&nbsp; " + dtfiltter.Rows[0]["ClientUnitName"].ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        #endregion

        #region Click Event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                contactInfo = new ContactInfo();
                contactInfoBAL = new ContactInfoBAL();
                contactInfo.EmailID = txtEmail.Text;
                contactInfo.Mobile = txtContactNo.Text;
                contactInfo.Designation = txtDesignation.Text;
                contactInfo.ContPerName = txtContPerName.Text;
                contactInfo.RegAdd = txtAddress.Value;
                contactInfo.ClientUnitUID = ViewState["ClientUnitUID"].ToString();
                int i = 0;
                i = contactInfoBAL.SaveContactInfoPopUp_cr(contactInfo, UserUID, "SU");
                if (i > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopUpMeassage", "alert('" + Resources.Resource.RecordSavedSucessfully + "');window.close();", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopUpMeassage", "closeWin();", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        #endregion

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtAddress.Disabled = false;
            txtContactNo.Enabled = true;
            txtContPerName.Enabled = true;
            txtDesignation.Enabled = true;
            txtEmail.Enabled = true;
            btnSave.Enabled = true;
        }

    }
}
