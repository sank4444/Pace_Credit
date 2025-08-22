using System;
using System.Data;
using System.Web;
using GlimpsBAL;
using GlimpsDAL;
using System.Web.UI;
using System.Web.UI.WebControls;
using GlimpsDAL.Common;
using System.Web.UI.HtmlControls;
using PACE.Masters;


namespace PACE.ContactInformation_cr
{
    public partial class ContactInformation_cr : System.Web.UI.Page
    {
        #region Private variables
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        DataSet dsInfo = null;
        //added by Sanket on 30/5/2025 for model popup
        ContactInfoBAL contactInfoBAL = null;
        ContactInfo contactInfo = null;
        DataSet ds = new DataSet();
        #endregion

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
                //((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation1")).Attributes.Add("class", "tab_link_active");  //commented by Sanket on 16/5/2025
              
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", UserUID, "ContactInformation_cr.aspx");
                    dsInfo = GetInformationContact(Convert.ToInt32(UserUID));
                    BindingGrid();
                }
                //added by Sanket on 29/5/2025
                else
                {
                    gvContactInfo.UseAccessibleHeader = true;
                    gvContactInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
                    
                }
                //if(hdnModel.Value== "Hide")
                //{
                //    string script = @"
                //const modalElement = document.getElementById('contactModal');
                //const modalInstance = bootstrap.Modal.getInstance(modalElement);
                //if (modalInstance) {
                //modalInstance.hide();
                //}
                // document.body.classList.remove('modal-open');
                // document.querySelectorAll('.modal-backdrop').forEach(el => el.remove());
                //";

                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", script, true);
                //}
                //--------------------------------
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        #region Functions
        //added by Sanket on 30/5/2025
        /*Retriving Data for specific row values using Linq*/
        private void Data(DataTable dt, string clientunitid)
        {
            //getting selected value of gridview row from ContactInfo.aspx
            //getting select record from parentpage
            var SelectData = from data in dt.AsEnumerable()
                             where data.Field<Int32>("ClientUnitUID") == Convert.ToInt32(clientunitid)
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
        //--------------------------------------------------------------

        /*Binding Grigview*/
        private void BindingGrid()
        {
            try
            {
                if (dsInfo != null)
                {
                    if (dsInfo.Tables[0].Rows.Count > 0)
                    {
                        gvContactInfo.DataSource = dsInfo.Tables[1];
                        gvContactInfo.DataBind();
                        ViewState["DATA"] = dsInfo.Tables[1];
                        //added by sanket on 16/5/2025
                        gvContactInfo.UseAccessibleHeader = true;
                        gvContactInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
                        //--------------------------------//
                    }
                    else
                    {
                        // Masters_MenuMasterPage.ShowNoResultFound(dsInfo.Tables[0], gvContactInfo);
                        MenuMasterPage_Cr.ShowNoResultFound(dsInfo.Tables[0], gvContactInfo);   
                        gvContactInfo.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        /*Getting data from Database */
        private DataSet GetInformationContact(int UserUID)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                ContactInfoBAL contactInfoBAL = new ContactInfoBAL();
                 ds = contactInfoBAL.GetContactInfo_cr(UserUID);
               // ds = contactInfoBAL.GetContactInfo(UserUID);

            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
            return ds;
        }

        private DataSet GetInformationContact_cr(int UserUID)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                ContactInfoBAL contactInfoBAL = new ContactInfoBAL();
                ds = contactInfoBAL.GetContactInfo_cr(UserUID);
                // ds = contactInfoBAL.GetContactInfo(UserUID);

            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
            return ds;
        }
        #endregion

        protected void gvContactInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["DATA"] != null)
            {
                gvContactInfo.PageIndex = e.NewPageIndex;
                gvContactInfo.DataSource = (DataTable)ViewState["DATA"];
                gvContactInfo.DataBind();
                //added by sanket on 29/5/2025
                gvContactInfo.UseAccessibleHeader = true;
                gvContactInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
                //--------------------------------------
            }
        }
        //added by Sanket 30/5/2025
        protected void gvContactInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPopup")
            {
                string clientunitid = e.CommandArgument.ToString();
                //added by Sanket on 30/5/2025  for model popup
                //get data table and checking is it dataset 
                UserUID = Session[CommonConstantNames.USERUID].ToString();
                ContactInfoBAL contactInfoBAL = new ContactInfoBAL();
                ds = contactInfoBAL.GetContactInfoPopUp_cr(UserUID);

                Data(ds.Tables[0], clientunitid);               

                // Show the modal popup
                //ModalPopupExtender1.Show();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#contactModal').modal('show');", true);
                //-------------------------------------
            }
        }
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
                //added by Sanket on 7/8/2025
                // Inject JavaScript to hide modal and remove backdrop
                string script = @"
                const modalElement = document.getElementById('contactModal');
                const modalInstance = bootstrap.Modal.getInstance(modalElement);
                if (modalInstance) {
                modalInstance.hide();
                }
                 document.body.classList.remove('modal-open');
                 document.querySelectorAll('.modal-backdrop').forEach(el => el.remove());
                ";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", script, true);
                //------------------------------------------------------------

                //txtAddress.Disabled = true;
                //txtContactNo.Enabled = false;
                //txtContPerName.Enabled = false;
                //txtDesignation.Enabled = false;
                //txtEmail.Enabled = false;
                //btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtAddress.Disabled = false;
            txtContactNo.Enabled = true;
            txtContPerName.Enabled = true;
            txtDesignation.Enabled = true;
            txtEmail.Enabled = true;
            btnSave.Enabled = true;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#contactModal').modal('show');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //hdnModel.Value ="Hide";
            string script = @"
                const modalElement = document.getElementById('contactModal');
                const modalInstance = bootstrap.Modal.getInstance(modalElement);
                if (modalInstance) {
                modalInstance.hide();
                }
                 document.body.classList.remove('modal-open');
                 document.querySelectorAll('.modal-backdrop').forEach(el => el.remove());
                ";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", script, true);
        }
        //-----------------------------------------------
    }
}
