//using System;
//using System.Collections;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
//using GlimpsDAL;
//using GlimpsBAL;
//using GlimpsDAL.Common;
//using Resources;
//using System.Text;
//using System.Collections.Generic;
//
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
using System.Collections.Generic;

namespace PACE
{
    public partial class ServiceRequest : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session[CommonConstantNames.USERUID] != null)
            {
                UserUID = Session[CommonConstantNames.USERUID].ToString();
                subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                /*--Added by Karunakar as per new CR TTSL
             *   on date 16/05/2016
             *  start
        --*/
                if (Session["IsTTSL"].ToString().ToUpper() == "Y")
                {
                    trFileUpload.Visible = false;
                    trCallCenter.Visible = true;
                    RequiredFieldValidator3.Enabled = true;
                }
                else
                {
                    trFileUpload.Visible = true;
                    trCallCenter.Visible = false;
                    imgSaveService.OnClientClick="return ServiceRequestValidation();";
                    RequiredFieldValidator3.Enabled = false;
                }
                //end
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }
            //((HtmlTableCell)this.Page.Master.FindControl("Servicing")).Attributes.Add("class", "active");
            //((HtmlTableCell)this.Page.Master.FindControl("Miscellaneous1")).Attributes.Add("class", "active");
            if (IsPostBack != true)
            {
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "ServiceRequest.aspx");
                ((HtmlTableCell)this.Page.Master.FindControl("Servicing")).Attributes.Add("class", "active");
                FillDropDownCategory();
            }
        }

        #region dyanamic checkboxes

        //Function to generate the dyanamic checkboxes
        private void AddCheckboxes(DataSet ds)
        {
            try
            {
                Panel1.Visible = true;
                Table tbldynamic = new Table();
                for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
                {
                    TableCell tc = new TableCell();
                    TableRow tr = new TableRow();
                    CheckBox _checkbox = new CheckBox();
                    _checkbox.Attributes.Add("TextAlign", "right");
                    _checkbox.ID = ("chk" + i).ToString();
                    _checkbox.Text = ds.Tables[0].Rows[i]["CommonListName"].ToString();
                    tc.Controls.Add(_checkbox);
                    tr.Cells.Add(tc);
                    tbldynamic.Rows.Add(tr);
                }
                Panel1.Controls.Add(tbldynamic);

            }

            catch (Exception exp)
            {

                throw new Exception(exp.Message);

            }

        }

        #endregion

        #region Category
        private void FillDropDownCategory()
        {
            ServiceBAL objConfigurationBAL = null;
            DataSet ds = null;

            try
            {
                objConfigurationBAL = new ServiceBAL();
                ds = new DataSet();

                ds = objConfigurationBAL.categoryDDL(UserUID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCategory.DataSource = ds;
                    ddlCategory.DataTextField = CommonConstantNames.COMMONLISTNAME;
                    ddlCategory.DataValueField = CommonConstantNames.COMMONLISTUID;
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
                    //DdlServiceRequestTypeChange();
                }
                else
                {
                    ddlCategory.Items.Insert(0, new ListItem("No Record", "0"));
                    ddlCategory.SelectedValue = "0";
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
            ServiceBAL objServiceBAL = new ServiceBAL();
            try
            {

                if (fuServiceRequest.HasFile == true && Session["IsTTSL"].ToString().ToUpper() != "Y")
                {
                    HttpPostedFile Myfile = fuServiceRequest.PostedFile;

                    string strFileType = System.IO.Path.GetExtension(Myfile.FileName).ToString().ToLower();
                    string strFileName = DateTime.Now.ToString(Resource.DateFormat_ddMMyyyy_HHmmss) + "ServiceRquest" + strFileType.ToString();
                    DataSet ds = new DataSet();
                    if (strFileType.ToUpper() == ".PDF")
                    {

                        //Saving in local folder
                        string FilePath = HttpContext.Current.Request.PhysicalApplicationPath + "FileUploades\\";
                        Myfile.SaveAs(Server.MapPath("~/FileUploades/" + strFileName.ToString()));

                        //redirecting to local excel 
                        string strNewPath = Server.MapPath("~/FileUploades/" + strFileName.ToString());
                        string type = "CGR";// ddlServiceRequestType.SelectedItem.Value.ToString();
                        string category = ddlCategory.SelectedItem.Value.ToString();


                        List<string> chkValues = gettingCheckBoxDataFromGrid();
                        if (chkValues.Count > 0)
                        {
                            if (chkValues.Count == gvCheckBox.Rows.Count)
                            {


                                //Inserting into data base
                                //int i = 0;
                                DataSet dsMsg = objServiceBAL.SavingServiceRequest(UserUID, type, category, string.Empty, FilePath, chkValues, string.Empty, string.Empty);
                                if (dsMsg.Tables[0].Rows.Count > 0)
                                {
                                    ClientScriptManager csm = Page.ClientScript;
                                    //  ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Enter data saved successfully');", true);
                                    byte[] bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/FileUploades/" + strFileName.ToString()));

                                    int i = objServiceBAL.SendinMailWithAttachment(UserUID, bytes, dsMsg.Tables[0].Rows[0]["ServicingRequestNo"].ToString());

                                    //Trm_Proc_Auto_mail_Send_Web  <ServicingRequestNo>dsMsg.Tables[0].Rows[0]["ServicingRequestNo"].ToString()</ServicingRequestNo>,<AttachFile1>Bytes</AttachFile1>
                                    //dsMsg.Tables[0].Rows[0]["ServicingRequestNo"].ToString()
                                    //Action="SRSSENDMAIL"
                                    //UsedId=45


                                    string strconfirm = "<script>if(window.confirm('" + dsMsg.Tables[0].Rows[0]["DisplayMessage"].ToString() + "Do you want to create new Request then press \"OK\" Cancel then move request list')){window.location.href='ServiceList.aspx'}</script>"; csm.RegisterClientScriptBlock(typeof(Page), "Confirm", strconfirm, false);
                                    //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "return Confirm();", true);
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('data not saved.');", true);
                                }
                                ClearControls();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Please select all Name Of Document!');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Please select Name Of Document!');", true);
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : Only PDF files are accepted!');", true);
                    }
                }

                else if (Session["IsTTSL"].ToString().ToUpper() == "Y" && trFileUpload.Visible == false)
                {
                    if (ddlCategory.SelectedItem.Value.ToString()=="0")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Please select catogery!');", true);
                        return;
                    }
               
                    string type = "CGR";
                    string category = ddlCategory.SelectedItem.Value.ToString();

                    DataSet dsMsg = objServiceBAL.SavingServiceRequest(UserUID, type, category, txtccExecutive.Text,txtMobileNo.Text, txtQuery.Text);
                    if (dsMsg.Tables[0].Rows.Count > 0)
                    {
                        ClientScriptManager csm = Page.ClientScript;
                        //  ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Enter data saved successfully');", true);
                        //byte[] bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/FileUploades/" + strFileName.ToString()));

                        //int i = objServiceBAL.SendinMailWithAttachment(UserUID, bytes, dsMsg.Tables[0].Rows[0]["ServicingRequestNo"].ToString());


                        string strconfirm = "<script>if(window.confirm('" + dsMsg.Tables[0].Rows[0]["DisplayMessage"].ToString() + "Do you want to create new Request then press \"OK\" Cancel then move request list')){window.location.href='ServiceList.aspx'}</script>"; csm.RegisterClientScriptBlock(typeof(Page), "Confirm", strconfirm, false);
                        //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "return Confirm();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('data not saved.');", true);
                    }
                    ClearControls();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : File is not Upload');", true);
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void DdlServiceRequestTypeChange()
        {

            DataSet dsCheckBox = null;
            ServiceBAL objConfigurationBAL = null;
            try
            {
                dsCheckBox = new DataSet();
                objConfigurationBAL = new ServiceBAL();



                //FillDropDownCategory();
                //if (ddlServiceRequestType.SelectedItem.Text.Equals("Claim Request"))
                //{
                //    trCOI.Visible = true;
                //}
                //else
                //{
                //    trCOI.Visible = false;
                //}


                //For Displaying check box data
                dsCheckBox = objConfigurationBAL.getDataCHK(UserUID, ddlCategory.SelectedItem.Value.ToString());

                if (dsCheckBox != null)
                {
                    if (dsCheckBox.Tables[0].Rows.Count > 0)
                    {
                        gvCheckBox.DataSource = dsCheckBox;
                        ViewState["dsCheckBox"] = dsCheckBox;
                        gvCheckBox.DataBind();
                    }
                    else
                    {
                        Masters_MenuMasterPage.ShowNoResultFound(dsCheckBox.Tables[0], gvCheckBox);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<string> gettingCheckBoxDataFromGrid()
        {
            //int i=0;
            List<string> chkValues = new List<string>();
            //string[]   chkValues  =new string[]();
            foreach (GridViewRow row in gvCheckBox.Rows)
            {

                if (((CheckBox)row.FindControl("chk")).Checked == true)
                {
                    chkValues.Add(((HiddenField)row.FindControl("hndCommonListUID")).Value.ToString());
                    //chkValues.Insert(i, ((HiddenField)row.FindControl("hndCommonListUID")).Value.ToString());
                    //chkValues.Append(((HiddenField)row.FindControl("hndCommonListUID")).Value.ToString());
                    //i++;
                }
            }
            return chkValues;
        }

        private void ClearControls()
        {
            // ddlServiceRequestType.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            //txtCOI.Text = string.Empty;
            //trchkPan.Visible = false;
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            // ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpSearch", "window.showmodaldialog('../Services/PopUpCommonSearch.aspx?"+txtCOI.Text+"','#1','dialogHeight: 300px; dialogWidth: 600px;' +'dialogTop: 190px;  dialogLeft: 220px; edge: Raised; center: Yes;' + 'help: No; resizable: No; status: No;'", true);

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpSearch", "window.open('../Services/PopUpCommonSearch.aspx?COI=" + string.Empty + "&DDlSecond=" + ddlCategory.SelectedItem.Value.ToString().Trim() + "', '_blank', 'width=960,height=600, scrollbars=yes,resizable=yes')", true);

        }



        protected void gvCheckBox_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if ((DataSet)ViewState["dsCheckBox"] != null)
            {
                gvCheckBox.PageIndex = e.NewPageIndex;
                gvCheckBox.DataSource = (DataSet)ViewState["dsCheckBox"];
                gvCheckBox.DataBind();
            }
        }


        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            //if (txtCOI.Visible == true && !string.IsNullOrEmpty(txtCOI.Text))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpSearch", "alert('Please select COI.')", true);
            //}
        }

        protected void gvCheckBox_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (gvCheckBox.Visible == true)
            {
                foreach (GridViewRow row in gvCheckBox.Rows)
                {
                    if (((CheckBox)row.FindControl("chk")).Checked == true)
                    {
                        //if (txtCOI.Visible == true && !string.IsNullOrEmpty(txtCOI.Text))
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpSearch", "alert('Please select COI.')", true);
                        //}
                    }
                }
            }
        }

        protected void chk_CheckedChanged1(object sender, EventArgs e)
        {
            //if (txtCOI.Visible == true && !string.IsNullOrEmpty(txtCOI.Text))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpSearch", "alert('Please select COI.')", true);
            //}
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*--Added by Karunakar as per new CR TTSL
             *   on date 16/05/2016
             *  start
           --*/
            if (Session["IsTTSL"].ToString().ToUpper() != "Y")
            {
                DdlServiceRequestTypeChange();
            }
            else if (Session["IsTTSL"].ToString().ToUpper() == "Y")
            {
                trchkPan.Visible = false;
            }
            //end
        }
    }
}
