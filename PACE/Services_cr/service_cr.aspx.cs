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
using System.Threading;

namespace PACE.Services_cr
{
    public partial class service_cr : System.Web.UI.Page
    {
        #region Private variables..
        string ExcelConnection = string.Empty;
        int UserUID = 0;
        string MEMBERADDITION = "Member Addition";
        //string MEMBERDELETION = "Member Deletion";
        string PolicyUID = string.Empty;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PolicyUID"] != null)
            {
                UserUID = Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString());
                PolicyUID = Session[CommonConstantNames.POLICYUID].ToString();
                //Session[CommonConstantNames.POLICYUID].ToString()

                //if (Session["IsTTSL"].ToString().ToUpper() == "Y")
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "TTSLErrorFlag();", true);
                //}
                //END

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : Please Select Policy from SubOffice Access Page');", true);
                // Response.Redirect("~/CreditLifeInformation/COpyPolicySubOfficeAccess_cr.aspx", true);
                //  Response.Redirect("~/LoginPage.aspx", true);
            }
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["confirm"])== "confirm")
                {
                    Session["confirm"] = "";
                    FillDropDown();
                    if (Session["dsAfterUpload"] != null)
                    {
                        DataSet dsAfterUpload = (DataSet)Session["dsAfterUpload"];
                        if (dsAfterUpload.Tables[0].Rows.Count == 0 && dsAfterUpload.Tables[1].Rows.Count == 0 && dsAfterUpload.Tables[2].Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "alert('Please insert new Record It already  Uploaded.');", true);
                        }
                        //STARTS
                        else
                        {
                            if (dsAfterUpload.Tables.Count > 0)
                                lblCount.Text = "Success :  " + Convert.ToString(dsAfterUpload.Tables[2].Rows.Count > 0 ? dsAfterUpload.Tables[2].Rows.Count.ToString() : "0") +
                                    " Duplicate : " + Convert.ToString(dsAfterUpload.Tables[1].Rows.Count > 0 ? dsAfterUpload.Tables[1].Rows.Count.ToString() : "0") +
                                    " Error : " + Convert.ToString(dsAfterUpload.Tables[0].Rows.Count > 0 ? dsAfterUpload.Tables[0].Rows.Count.ToString() : "0");
                            grdConform.DataSource = dsAfterUpload.Tables[2]; //LS dsAfterUpload.Tables[0]
                            grdDuplicate.DataSource = dsAfterUpload.Tables[1];
                            grdErrorLog.DataSource = dsAfterUpload.Tables[0]; //LS dsAfterUpload.Tables[2]
                            if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                            {
                                TabContainer1.ActiveTabIndex = 0;
                                TabContainer1.Visible = true;
                                grdConform.DataSource = dsAfterUpload.Tables[2];//Tables[3]
                                grdConform.DataBind();
                            }

                            grdConform.DataBind();
                            grdDuplicate.DataBind();
                            grdErrorLog.DataBind();

                            //only for Member addition
                            if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_DOB
                                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN)
                            {
                                if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                                {
                                    if (dsAfterUpload.Tables[2].Rows.Count > 0)
                                    {
                                        ViewState["dsAfterUpload"] = dsAfterUpload;
                                        TabContainer1.ActiveTabIndex = 0;//3
                                        chkValidation_CheckedChanged(this, EventArgs.Empty);
                                    }
                                    else
                                    {
                                        TabContainer1.ActiveTabIndex = 0;
                                    }

                                }
                                if (dsAfterUpload.Tables[2].Rows.Count > 0)
                                {
                                    if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                                    {
                                        if (dsAfterUpload.Tables[2].Rows.Count > 0)
                                        {
                                            TabContainer1.ActiveTabIndex = 1;//3
                                        }
                                        else
                                        {
                                            TabContainer1.ActiveTabIndex = 0;
                                        }
                                    }

                                    else
                                    {
                                        TabContainer1.ActiveTabIndex = 0;
                                    }
                                    Session[CommonConstantNames.TRANSACTIONID] = dsAfterUpload.Tables[2].Rows[0][CommonConstantNames.TRANSACTIONID].ToString();
                                    imgbtn_Confirm.Visible = true;
                                }
                                //Duplicate tab
                                else if (dsAfterUpload.Tables[1].Rows.Count > 0)
                                {
                                    TabContainer1.ActiveTabIndex = 2;
                                    imgbtn_Confirm.Visible = false;
                                }
                                //Error tab
                                else if (dsAfterUpload.Tables[0].Rows.Count > 0)
                                {
                                    TabContainer1.ActiveTabIndex = 1;
                                    imgbtn_Confirm.Visible = false;
                                }
                            }
                            MV_UploadSR_View.ActiveViewIndex = 2;
                        }
                    }
                    else
                    {
                        lblMessageUpload.Text = string.Empty;
                        CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "Service_cr.aspx");
                        ((HtmlTableCell)this.Page.Master.FindControl("Servicing1")).Attributes.Add("class", "active");
                        ViewState["PolServicingChangeUID"] = string.Empty;
                        ViewState[CommonConstantNames.DATASET] = null;
                        ViewState[CommonConstantNames.DROPDOWNLISTDATA] = string.Empty;
                        ViewState[CommonConstantNames.POLICYUID] = string.Empty;
                        FillDropDown();
                    }
                }
                else
                {
                    lblMessageUpload.Text = string.Empty;
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "Service_cr.aspx");
                    //((HtmlTableCell)this.Page.Master.FindControl("Servicing1")).Attributes.Add("class", "active");  //commented by Sanket on 5/8/2025
                    ViewState["PolServicingChangeUID"] = string.Empty;
                    ViewState[CommonConstantNames.DATASET] = null;
                    ViewState[CommonConstantNames.DROPDOWNLISTDATA] = string.Empty;
                    ViewState[CommonConstantNames.POLICYUID] = string.Empty;
                    FillDropDown();
                }

                
            }
        }

        private void ExcelDataImportToGridView()
        {
            try
            {
                DataSet ds = new DataSet();
                ServiceBAL objServiceBAL = new ServiceBAL();
                if (FUploadfile.HasFile == true)
                {
                    HttpPostedFile Myfile = FUploadfile.PostedFile;
                    string strFileType = System.IO.Path.GetExtension(Myfile.FileName).ToString().ToLower();
                    string strFileName = DateTime.Now.ToString(Resource.DateFormat_ddMMyyyy_HHmmss);
                    if (strFileType == ".xls" || strFileType == ".xlsx" || strFileType == ".csv" || strFileType == ".txt")
                    {
                        _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();
                        //Saving in local folder
                        // Myfile.SaveAs(@"D:\Talic_reports\User Take File\FileUploades\" + strFileName + strFileType);
                        Myfile.SaveAs(Server.MapPath("~/FileUploades/" + strFileName + strFileType));
                        //redirecting to local excel 
                        //string strNewPath = @"D:\Talic_reports\User Take File\FileUploades\" + strFileName + strFileType;
                        string strNewPath = Server.MapPath("../FileUploades/" + strFileName + strFileType);
                        //Converting Excel into XML via dataset values 
                        ds = objConfigurationBAL.CreateDataSet_cr(strNewPath, strFileType);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //ds.Tables[0].Rows[0].Delete();   //commented by Sanket on 05/8/2025
                            //checking for required columns 
                            if (CheckExcelValidation(ds) == false)
                            {
                                return;
                            }
                            ds.AcceptChanges();
                        }
                        ViewState[CommonConstantNames.DATASET] = ds;

                        if (ExcelDataValidation())
                        {
                            grdExcelUploadedData.DataSource = ds;
                            grdExcelUploadedData.DataBind();
                            MV_UploadSR_View.ActiveViewIndex = 1;//Next
                            lblMessageUpload.Text = string.Empty;
                        }
                        /*else
                        {
                            if (File.Exists(Server.MapPath("~/FileUploades/" + strFileName + strFileType)))
                            {
                                File.Delete(Server.MapPath("~/FileUploades/" + strFileName + strFileType));
                            }
                        }*/
                        Session[CommonConstantNames.USERUID] = UserUID.ToString();
                    }

                }
                else
                {
                    string errorMsg = Resources.Resource.msgErrNoFile;
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "alert('Message : " + errorMsg + "');", true);
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void imgBtnUpload_Click(object sender, EventArgs e)
        {
            ExcelDataImportToGridView();
        }

        private void FillDropDown()
        {

            try
            {
                DataSet dsddlService = new DataSet();
                _objConfigurationBAL objConfigurationBAL = new _objConfigurationBAL();


                ddlServicingChange.DataSource = objConfigurationBAL.GetServicingList_cr(UserUID);
                DataSet dsddlData = objConfigurationBAL.GetServicingList_cr(UserUID);
                ViewState[CommonConstantNames.DROPDOWNLISTDATA] = dsddlData.Tables[0];
                DataSet dsPolicyUId = objConfigurationBAL.GetPolicyUID_cr(UserUID);
                if (dsPolicyUId.Tables[0].Rows.Count > 0)
                {
                    //getting policyUID parameter because for servicing member deletion need Insert policyUID
                    ViewState[CommonConstantNames.POLICYUID] = dsPolicyUId.Tables[0].Rows[0][CommonConstantNames.POLICYUID].ToString();

                    ddlServicingChange.DataTextField = CommonConstantNames.POL_SERVICING_CHANGE_NAME;
                    ddlServicingChange.DataValueField = CommonConstantNames.POL_SERVICING_CHANGE_CODE;
                    ddlServicingChange.DataBind();
                    //ddlServicingChange.Items.Insert(0, (new ListItem("Select servicing list", "0")));
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "PopUpErrorMessage", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private void UploadFile(string ReqNumber)
        {
            try
            {
                string Path = "~/FileUploades/" + ReqNumber.Trim();
                if (FUploadfile.HasFile)
                {

                    HttpPostedFile Myfile = FUploadfile.PostedFile;
                    Myfile.SaveAs(Server.MapPath(Path));
                    //hdnFileNamePath.Value = Path;
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        //private bool CheckExcelValidation_old(DataSet dsExcel)
        //{
        //    try
        //    {
        //        //ddlServicingChange.SelectedItem.Value = "TRMMemAdd";
        //        //LS 2019 if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
        //        if (CommonConstantNames.MEMBER_ADDITION == "TRMMemAdd")
        //        {
        //            if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.SUBOFFICECODE) == false)
        //            {
        //                DisplayMessage(Resource.subOffnotEx);
        //                return false;
        //            }//RegionName
        //            else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.REGIONCODE) == false)
        //            {
        //                DisplayMessage(Resource.Regioncode);
        //                return false;
        //            }
        //            else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.SALESMNGRUID) == false)
        //            {
        //                DisplayMessage(Resource.SalesMngrUID);
        //                return false;
        //            }
        //            //else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.SCHEMEJOININGDATE) == false)
        //            //{
        //            //    DisplayMessage(Resource.SchemeJoiningDtNE);
        //            //    return false;
        //            //}
        //            else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.PROPOSEDFIRSTNAME) == false)
        //            {
        //                DisplayMessage(Resource.PropFirstNamenotExst);
        //                return false;
        //            }
        //            else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.BIRTHDATE) == false)
        //            {
        //                DisplayMessage(Resource.BirthDTntExst);
        //                return false;
        //            }
        //            else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.GENDER) == false)
        //            {
        //                DisplayMessage(Resource.GenderntExst);
        //                return false;
        //            }
        //            //else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.EMPLOYMENTDATE) == false)
        //            //{
        //            //    DisplayMessage(Resource.EmpDtntExst);
        //            //    return false;
        //            //}
        //            //else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.EMPLOYEENO) == false)
        //            //{
        //            //    DisplayMessage(Resource.EmpNontExs);
        //            //    return false;
        //            //}
        //        }
        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION)
        //        {
        //            if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //            {
        //                DisplayMessage(Resource.COInotExs);
        //                return false;
        //            }
        //            else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.CHANGEEFFECTIVEDATE) == false)
        //            {
        //                DisplayMessage(Resource.ChangeEfftDatentExt);
        //                return false;
        //            }
        //            else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.TERMINATIONDT) == false)
        //            {
        //                DisplayMessage(Resource.TermdtntExst);
        //                return false;
        //            }

        //        }

        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY)
        //        {
        //            if (dsExcel.Tables[0].Columns.Count == 4)
        //            {
        //                if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //                {
        //                    DisplayMessage(Resource.COInotExs);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.CHANGEEFFECTIVEDATE) == false)
        //                {
        //                    DisplayMessage(Resource.ChangeEfftDatentExt);
        //                    return false;
        //                }

        //                else if (dsExcel.Tables[0].Columns.Contains("AnnualIncome") == false)
        //                {
        //                    DisplayMessage(Resource.FSGExst);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
        //                {
        //                    DisplayMessage("Employee Number is not exist");
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                DisplayMessage("file is not correct format");
        //                return false;
        //            }
        //        }
        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA)
        //        {
        //            if (dsExcel.Tables[0].Columns.Count == 4)
        //            {
        //                if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //                {
        //                    DisplayMessage(Resource.COInotExs);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.CHANGEEFFECTIVEDATE) == false)
        //                {
        //                    DisplayMessage(Resource.ChangeEfftDatentExt);
        //                    return false;
        //                }

        //                else if (dsExcel.Tables[0].Columns.Contains("FSA") == false)
        //                {
        //                    DisplayMessage(Resource.FSGExst);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
        //                {
        //                    DisplayMessage("Employee no doesn\'t exist in file.");
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                DisplayMessage("file is not correct format");
        //                return false;
        //            }
        //        }
        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG)
        //        {
        //            if (dsExcel.Tables[0].Columns.Count == 4)
        //            {
        //                if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //                {
        //                    DisplayMessage(Resource.COInotExs);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.CHANGEEFFECTIVEDATE) == false)
        //                {
        //                    DisplayMessage(Resource.ChangeEfftDatentExt);
        //                    return false;
        //                }

        //                else if (dsExcel.Tables[0].Columns.Contains("FSG") == false)
        //                {
        //                    DisplayMessage(Resource.FSGExst);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
        //                {
        //                    DisplayMessage("Employee no doesn\'t exist in file.");
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                DisplayMessage("file is not correct format");
        //                return false;
        //            }
        //        }
        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt)
        //        {
        //            if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //            {
        //                DisplayMessage(Resource.COInotExs);
        //                return false;
        //            }


        //            else if (dsExcel.Tables[0].Columns.Contains("DesignationCode") == false)
        //            {
        //                DisplayMessage(Resource.FSGExst);
        //                return false;
        //            }
        //            else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
        //            {
        //                DisplayMessage(Resource.EmpNontExs);
        //                return false;
        //            }
        //        }
        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.DOB)
        //        {
        //            if (dsExcel.Tables[0].Columns.Count == 4)
        //            {
        //                if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //                {
        //                    DisplayMessage(Resource.COInotExs);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains("ChangeEffectiveDate") == false)
        //                {
        //                    DisplayMessage(Resource.ChangeEfftDatentExt);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains("Birthdate") == false)
        //                {
        //                    DisplayMessage(Resource.BirthDTntExst);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
        //                {
        //                    DisplayMessage(Resource.EmpNontExs);
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                DisplayMessage("file is not correct format");
        //                return false;
        //            }
        //        }

        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO)
        //        {
        //            if (dsExcel.Tables[0].Columns.Count == 3)
        //            {
        //                if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //                {
        //                    DisplayMessage(Resource.COInotExs);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
        //                {
        //                    DisplayMessage(Resource.EmpNontExs);
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                DisplayMessage("file is not correct format");
        //                return false;
        //            }
        //        }
        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN)
        //        {
        //            if (dsExcel.Tables[0].Columns.Count == 4)
        //            {
        //                if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //                {
        //                    DisplayMessage(Resource.COInotExs);
        //                    return false;
        //                }

        //                else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.GENDER) == false)
        //                {
        //                    DisplayMessage(Resource.GenderntExst);
        //                    return false;
        //                }
        //                else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.EMPLOYEENO) == false)
        //                {
        //                    DisplayMessage(Resource.EmpNontExs);
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                DisplayMessage("file is not correct format");
        //                return false;
        //            }
        //        }

        //        else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME)
        //        {
        //            if (dsExcel.Tables[0].Columns.Count == 7)
        //            {
        //                if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
        //                {
        //                    DisplayMessage(Resource.COInotExs);
        //                    return false;
        //                }

        //                else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.EMPLOYEENO) == false)
        //                {
        //                    DisplayMessage(Resource.EmpNontExs);
        //                    return false;
        //                }

        //                else if (dsExcel.Tables[0].Columns.Contains("ProposedFirstName") == false)
        //                {
        //                    DisplayMessage("ProposedFirstName is not exist");
        //                    return false;
        //                }

        //            }
        //            else
        //            {
        //                DisplayMessage("file is not correct format");
        //                return false;
        //            }
        //        }

        //        else if (dsExcel.Tables[0].Rows.Count == 0)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Incorrect Excel File');", true);
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        //        return false;
        //    }
        //}

        private bool CheckExcelValidation(DataSet dsExcel)
        {
            try
            {

                if (CommonConstantNames.MEMBER_ADDITION == "TRMMemAdd" && dsExcel.Tables[0].Columns.Contains(CommonConstantNames.SUBOFFICECODE) == false)
                {
                       DisplayMessage(Resource.subOffnotEx);
                        return false;
                    }//RegionName
                    //else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.REGIONCODE) == false)
                    //{
                    //    DisplayMessage(Resource.Regioncode);
                    //    return false;
                    //}
                    //else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.SALESMNGRUID) == false)
                    //{
                    //    DisplayMessage(Resource.SalesMngrUID);
                    //    return false;
                    //}
                   
                    else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.PROPOSEDFIRSTNAME) == false)
                    {
                        DisplayMessage(Resource.PropFirstNamenotExst);
                        return false;
                    }
                    else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.BIRTHDATE) == false)
                    {
                        DisplayMessage(Resource.BirthDTntExst);
                        return false;
                    }
                    else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.GENDER) == false)
                    {
                        DisplayMessage(Resource.GenderntExst);
                        return false;
                    }

                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION)
                {
                    if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                    {
                        DisplayMessage(Resource.COInotExs);
                        return false;
                    }
                    else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.CHANGEEFFECTIVEDATE) == false)
                    {
                        DisplayMessage(Resource.ChangeEfftDatentExt);
                        return false;
                    }
                    else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.TERMINATIONDT) == false)
                    {
                        DisplayMessage(Resource.TermdtntExst);
                        return false;
                    }

                }



                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY)
                {
                    if (dsExcel.Tables[0].Columns.Count == 4)
                    {
                        if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                        {
                            DisplayMessage(Resource.COInotExs);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.CHANGEEFFECTIVEDATE) == false)
                        {
                            DisplayMessage(Resource.ChangeEfftDatentExt);
                            return false;
                        }

                        else if (dsExcel.Tables[0].Columns.Contains("AnnualIncome") == false)
                        {
                            DisplayMessage(Resource.FSGExst);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
                        {
                            DisplayMessage("Employee Number is not exist");
                            return false;
                        }
                    }
                    else
                    {
                        DisplayMessage("file is not correct format");
                        return false;
                    }
                }



                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA)
                {
                    if (dsExcel.Tables[0].Columns.Count == 4)
                    {
                        if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                        {
                            DisplayMessage(Resource.COInotExs);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.CHANGEEFFECTIVEDATE) == false)
                        {
                            DisplayMessage(Resource.ChangeEfftDatentExt);
                            return false;
                        }

                        else if (dsExcel.Tables[0].Columns.Contains("FSA") == false)
                        {
                            DisplayMessage(Resource.FSGExst);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
                        {
                            DisplayMessage("Employee no doesn\'t exist in file.");
                            return false;
                        }
                    }
                    else
                    {
                        DisplayMessage("file is not correct format");
                        return false;
                    }
                }

                //aaaa
                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG)
                {
                    if (dsExcel.Tables[0].Columns.Count == 4)
                    {
                        if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                        {
                            DisplayMessage(Resource.COInotExs);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.CHANGEEFFECTIVEDATE) == false)
                        {
                            DisplayMessage(Resource.ChangeEfftDatentExt);
                            return false;
                        }

                        else if (dsExcel.Tables[0].Columns.Contains("FSG") == false)
                        {
                            DisplayMessage(Resource.FSGExst);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
                        {
                            DisplayMessage("Employee no doesn\'t exist in file.");
                            return false;
                        }
                    }
                    else
                    {
                        DisplayMessage("file is not correct format");
                        return false;
                    }
                }
                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt)
                {
                    if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                    {
                        DisplayMessage(Resource.COInotExs);
                        return false;
                    }


                    else if (dsExcel.Tables[0].Columns.Contains("DesignationCode") == false)
                    {
                        DisplayMessage(Resource.FSGExst);
                        return false;
                    }
                    else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
                    {
                        DisplayMessage(Resource.EmpNontExs);
                        return false;
                    }
                }
                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.DOB)
                {
                    if (dsExcel.Tables[0].Columns.Count == 4)
                    {
                        if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                        {
                            DisplayMessage(Resource.COInotExs);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains("ChangeEffectiveDate") == false)
                        {
                            DisplayMessage(Resource.ChangeEfftDatentExt);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains("Birthdate") == false)
                        {
                            DisplayMessage(Resource.BirthDTntExst);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
                        {
                            DisplayMessage(Resource.EmpNontExs);
                            return false;
                        }
                    }
                    else
                    {
                        DisplayMessage("file is not correct format");
                        return false;
                    }
                }

                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO)
                {
                    if (dsExcel.Tables[0].Columns.Count == 3)
                    {
                        if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                        {
                            DisplayMessage(Resource.COInotExs);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains("EmployeeNo") == false)
                        {
                            DisplayMessage(Resource.EmpNontExs);
                            return false;
                        }
                    }
                    else
                    {
                        DisplayMessage("file is not correct format");
                        return false;
                    }
                }
                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN)
                {
                    if (dsExcel.Tables[0].Columns.Count == 4)
                    {
                        if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                        {
                            DisplayMessage(Resource.COInotExs);
                            return false;
                        }

                        else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.GENDER) == false)
                        {
                            DisplayMessage(Resource.GenderntExst);
                            return false;
                        }
                        else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.EMPLOYEENO) == false)
                        {
                            DisplayMessage(Resource.EmpNontExs);
                            return false;
                        }
                    }
                    else
                    {
                        DisplayMessage("file is not correct format");
                        return false;
                    }
                }

                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME)
                {
                    if (dsExcel.Tables[0].Columns.Count == 7)
                    {
                        if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.COI) == false)
                        {
                            DisplayMessage(Resource.COInotExs);
                            return false;
                        }

                        else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.EMPLOYEENO) == false)
                        {
                            DisplayMessage(Resource.EmpNontExs);
                            return false;
                        }

                        else if (dsExcel.Tables[0].Columns.Contains("ProposedFirstName") == false)
                        {
                            DisplayMessage("ProposedFirstName is not exist");
                            return false;
                        }

                    }
                    else
                    {
                        DisplayMessage("file is not correct format");
                        return false;
                    }
                }

                else if (dsExcel.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Incorrect Excel File');", true);
                    return false;
                }
                //aaaa


                return true;
                   
                } 
                
               


        
            
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
                return false;
            }
        }


        private void DisplayMessage(string Message)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Error Messages", "alert('" + Message + "');", true);
        }

        protected void imgbtn_Back_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                MV_UploadSR_View.ActiveViewIndex = 0;
                lblMessageUpload.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        private bool ExcelDataValidation()
        {
            DataSet _ds = new DataSet();
            _ds = (DataSet)ViewState[CommonConstantNames.DATASET];
            if (_ds.Tables[0].Rows.Count != 0)
            {
                DataColumnCollection columns = _ds.Tables[0].Columns;
                foreach (DataRow row in _ds.Tables[0].Rows)
                {
                    if (columns.Contains("ChangeEffectiveDate"))
                    {
                        string _effectiveDate = (row["ChangeEffectiveDate"]).ToString();
                        if (!string.IsNullOrEmpty(_effectiveDate))
                        {
                            if (_effectiveDate.Substring(0, 2).Contains('/') || _effectiveDate.Substring(0, 2).Contains("-")
                                || _effectiveDate.Substring(0, 2).Contains("."))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Change Effective Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_effectiveDate.Substring(0, 2)) > 12)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Change Effective Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_effectiveDate.Substring(6, 1) + _effectiveDate.Substring(7, 1)) > 20)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Change Effective Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                        }
                    }

                    if (columns.Contains("Terminationdt"))
                    {
                        string _terminationDate = (row["Terminationdt"]).ToString();
                        if (!string.IsNullOrEmpty(_terminationDate))
                        {
                            if (_terminationDate.Substring(0, 2).Contains('/') || _terminationDate.Substring(0, 2).Contains("-")
                                || _terminationDate.Substring(0, 2).Contains("."))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Termination Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_terminationDate.Substring(0, 2)) > 12)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Change Termination Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_terminationDate.Substring(6, 1) + _terminationDate.Substring(7, 1)) > 20)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Change Termination Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                        }
                    }

                    if (columns.Contains("MemberEffectiveDate"))
                    {
                        string _membereffectiveDate = (row["MemberEffectiveDate"]).ToString();
                        if (!string.IsNullOrEmpty(_membereffectiveDate))
                        {
                            if (_membereffectiveDate.Substring(0, 2).Contains('/') || _membereffectiveDate.Substring(0, 2).Contains("-")
                                || _membereffectiveDate.Substring(0, 2).Contains("."))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Member Effective Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_membereffectiveDate.Substring(0, 2)) > 12)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Member Effective Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_membereffectiveDate.Substring(6, 1) + _membereffectiveDate.Substring(7, 1)) > 20)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Member Effective Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                        }
                    }

                    if (columns.Contains("Birthdate"))
                    {
                        string _birthDate = (row["Birthdate"]).ToString();
                        if (!string.IsNullOrEmpty(_birthDate))
                        {
                            if (_birthDate.Substring(0, 2).Contains('/') || _birthDate.Substring(0, 2).Contains("-")
                               || _birthDate.Substring(0, 2).Contains("."))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Birth Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_birthDate.Substring(0, 2)) > 12)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Birth Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_birthDate.Substring(6, 1) + _birthDate.Substring(7, 1)) > 20)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Birth Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                        }
                    }

                    if (columns.Contains("DateofIntimation"))
                    {
                        string _dateofIntimation = (row["DateofIntimation"]).ToString();
                        if (!string.IsNullOrEmpty(_dateofIntimation))
                        {
                            if (_dateofIntimation.Substring(0, 2).Contains('/') || _dateofIntimation.Substring(0, 2).Contains("-")
                                || _dateofIntimation.Substring(0, 2).Contains("."))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Date Of Intimation in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_dateofIntimation.Substring(0, 2)) > 12)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Enter Date Of Intimation in MM-DD-YYYY format');", true);
                                return false;
                            }
                            if (Convert.ToInt32(_dateofIntimation.Substring(6, 1) + _dateofIntimation.Substring(7, 1)) > 20)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Change Member Birtth Date in MM-DD-YYYY format');", true);
                                return false;
                            }
                        }
                    }
                    //LS str
                    if (columns.Contains("subofficeCode"))
                    {
                        string _subofficeCode = (row["subofficeCode"]).ToString();
                        if (string.IsNullOrEmpty(_subofficeCode))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Suboffice code');", true);
                            return false;
                        }
                    }
                    if (columns.Contains("SalesMngrUID"))
                    {
                        string _subofficeCode = (row["SalesMngrUID"]).ToString();
                        if (string.IsNullOrEmpty(_subofficeCode))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Sales Manager ID');", true);
                            return false;
                        }
                    }
                    if (columns.Contains("RegionCode"))
                    {
                        string _subofficeCode = (row["RegionCode"]).ToString();
                        if (string.IsNullOrEmpty(_subofficeCode))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Region Code');", true);
                            return false;
                        }
                    }
                    if (columns.Contains("ProposedFirstName"))
                    {
                        string _subofficeCode = (row["ProposedFirstName"]).ToString();
                        if (string.IsNullOrEmpty(_subofficeCode))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Proposed First Name');", true);
                            return false;
                        }
                    }
                    //End Ls
                    //LS if (columns.Contains("Gender"))
                    //{
                    //    string _gender = (row["Gender"]).ToString();
                    //    if (!string.IsNullOrEmpty(_gender))
                    //    {
                    //        if (string.Compare(_gender, "M") != 0 || string.Compare(_gender, "F") != 0)
                    //        {
                    //            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Gender as M of F');", true);
                    //            return false;
                    //        }

                    //    }
                    //}

                    if (columns.Contains("AnnualIncome"))
                    {
                        string _annualIncome = (row["AnnualIncome"]).ToString();
                        if (!string.IsNullOrEmpty(_annualIncome))
                        {
                            foreach (char c in _annualIncome)
                            {
                                if (c < '0' || c > '9')
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Only Digits in Annual Income');", true);
                                }
                            }

                        }

                    }
                }
            }
            return true;
        }

        protected void imgbtn_Next_Click(object sender, ImageClickEventArgs e)
        {
            ServiceBAL objServiceBAL = null;
            int PolServicingChangeUID = 0;

            ddlServicingChange.SelectedItem.Value = CommonConstantNames.MEMBER_ADDITION; //"TRMMemAdd"; //ls

            try
            {
                UserUID = Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString());

                objServiceBAL = new ServiceBAL();
                int policyUID = Convert.ToInt32(ViewState[CommonConstantNames.POLICYUID].ToString());

                DataTable ddlTable = (DataTable)ViewState[CommonConstantNames.DROPDOWNLISTDATA];
                if (ddlTable != null && ddlTable.Rows.Count > 0)
                {
                    //Using linq here because for Servicing Deletion,policyUID is need 
                    var query = (from pol in ddlTable.AsEnumerable()
                                 where pol.Field<string>(CommonConstantNames.POL_SERVICING_CHANGE_CODE) == ddlServicingChange.SelectedItem.Value
                                 select new { pol }).Single();
                    PolServicingChangeUID = Convert.ToInt32(query.pol.ItemArray[0].ToString());

                    ViewState["PolServicingChangeUID"] = PolServicingChangeUID;//For SumAssured
                }

                //if (ExcelDataValidation())
                //{
                if (true)
                {
                    //Uploading is finished and Next Start
                    //Return 3 tables
                    DataSet dsAfterUpload = null;
                    if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                    {
                        //dsAfterUpload = objServiceBAL.InsertXMLInDataBase_cr(UserUID, ddlServicingChange.SelectedItem.Value, (DataSet)ViewState[CommonConstantNames.DATASET]);
                        dsAfterUpload = objServiceBAL.InsertXMLInDataBase_cr(

                            CommonConstantNames.EasyAdmin_Process,
                            CommonConstantNames.Upload.ToString(),
                            ddlServicingChange.SelectedItem.Value,
                            Convert.ToInt32(PolicyUID.ToString()),
                            Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString()),

                            (DataSet)ViewState[CommonConstantNames.DATASET]);

                        Session["dsAfterUpload"] = dsAfterUpload;
                    }
                    // if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION)
                    //{
                    //    dsAfterUpload = objServiceBAL.InsertXMLInDataBaseForDeletion_cr(UserUID, ddlServicingChange.SelectedItem.Value, (DataSet)ViewState[CommonConstantNames.DATASET], policyUID, PolServicingChangeUID);
                    //}
                    //else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY
                    //    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA
                    //    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG
                    //    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt
                    //    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME
                    //    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO
                    //    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_DOB
                    //    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN)
                    //{
                    //    dsAfterUpload = objServiceBAL.InsertXMLInDataBaseForMinorServicingchanges_cr(UserUID, ddlServicingChange.SelectedItem.Value, (DataSet)ViewState[CommonConstantNames.DATASET], policyUID, PolServicingChangeUID);
                    //}
                    if (dsAfterUpload.Tables[0].Rows.Count == 0 && dsAfterUpload.Tables[1].Rows.Count == 0 && dsAfterUpload.Tables[2].Rows.Count == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "alert('Please insert new Record It already  Uploaded.');", true);
                    }
                    //STARTS
                    else
                    {
                        if (dsAfterUpload.Tables.Count > 0)
                            lblCount.Text = "Success :  " + Convert.ToString(dsAfterUpload.Tables[2].Rows.Count > 0 ? dsAfterUpload.Tables[2].Rows.Count.ToString() : "0") +
                                " Duplicate : " + Convert.ToString(dsAfterUpload.Tables[1].Rows.Count > 0 ? dsAfterUpload.Tables[1].Rows.Count.ToString() : "0") +
                                " Error : " + Convert.ToString(dsAfterUpload.Tables[0].Rows.Count > 0 ? dsAfterUpload.Tables[0].Rows.Count.ToString() : "0");
                        grdConform.DataSource = dsAfterUpload.Tables[2]; //LS dsAfterUpload.Tables[0]
                        grdDuplicate.DataSource = dsAfterUpload.Tables[1];
                        grdErrorLog.DataSource = dsAfterUpload.Tables[0]; //LS dsAfterUpload.Tables[2]
                        if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                        {
                            TabContainer1.ActiveTabIndex = 0;
                            TabContainer1.Visible = true;
                            grdConform.DataSource = dsAfterUpload.Tables[2];//Tables[3]
                            grdConform.DataBind();
                        }

                        grdConform.DataBind();
                        grdDuplicate.DataBind();
                        grdErrorLog.DataBind();

                        //only for Member addition
                        if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_DOB
                            || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN)
                        {
                            if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                            {
                                if (dsAfterUpload.Tables[2].Rows.Count > 0)
                                {
                                    ViewState["dsAfterUpload"] = dsAfterUpload;
                                    TabContainer1.ActiveTabIndex = 0;//3
                                    chkValidation_CheckedChanged(this, EventArgs.Empty);
                                }
                                else
                                {
                                    TabContainer1.ActiveTabIndex = 0;
                                }

                            }
                            if (dsAfterUpload.Tables[2].Rows.Count > 0)
                            {
                                if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                                {
                                    if (dsAfterUpload.Tables[2].Rows.Count > 0)
                                    {
                                        TabContainer1.ActiveTabIndex = 1;//3
                                    }
                                    else
                                    {
                                        TabContainer1.ActiveTabIndex = 0;
                                    }
                                }

                                else
                                {
                                    TabContainer1.ActiveTabIndex = 0;
                                }
                                Session[CommonConstantNames.TRANSACTIONID] = dsAfterUpload.Tables[2].Rows[0][CommonConstantNames.TRANSACTIONID].ToString();
                                imgbtn_Confirm.Visible = true;
                            }
                            //Duplicate tab
                            else if (dsAfterUpload.Tables[1].Rows.Count > 0)
                            {
                                TabContainer1.ActiveTabIndex = 2;
                                imgbtn_Confirm.Visible = false;
                            }
                            //Error tab
                            else if (dsAfterUpload.Tables[0].Rows.Count > 0)
                            {
                                TabContainer1.ActiveTabIndex = 1;
                                imgbtn_Confirm.Visible = false;
                            }
                        }
                        MV_UploadSR_View.ActiveViewIndex = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
                ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
                MV_UploadSR_View.ActiveViewIndex = 1;
            }

            //UpdateProgress UpdateProgress1 = (UpdateProgress)Page.Master.FindControl("UpdateProgress1");
            //if (UpdateProgress1 != null)
            //{
            //    UpdateProgress1.AssociatedUpdatePanelID = "dummu";
            //    //UpdateProgress1.Dispose();
            //}
            Session["confirm"] = "confirm";
            Response.Redirect("service_cr.aspx");
            
            //Thread.Sleep(1000);            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myfunc", "HideImage", true);
        }

        protected void imgbtn_Confirm_Click(object sender, ImageClickEventArgs e)
        {
            ServiceBAL objServiceBAL = null;
            try
            {
                objServiceBAL = new ServiceBAL();
                DataSet dsNext = new DataSet();
                DataSet dsJob = new DataSet();
                string ServiceReqNo = string.Empty;

                if (ddlServicingChange.SelectedItem.Text == MEMBERADDITION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                {
                    dsNext = objServiceBAL.MemberTermConfirm_cr(CommonConstantNames.EasyAdmin_Process, CommonConstantNames.Upload.ToString(), Convert.ToInt32(PolicyUID.ToString()), UserUID, Session[CommonConstantNames.TRANSACTIONID].ToString());
                    if (dsNext.Tables.Count > 0)//dsAfterUpload.Tables.Count > 0
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Data save Successfully');", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myfunc", "ShowRedirect()", true);
                        //criptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "getdisplay()", true);
                        imgbtn_Confirm.Visible = false;
                        //ls Response.Redirect("~//Services_cr//service_cr.aspx");
                        //ls ScriptManager.RegisterStartupScript(this, this.GetType(), "myconfirm", "confirm('No Rule Type Ids found for This Rule.');", true);
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myconfirm", "confirm('No Rule Type Ids found for This Rule.');", true);
                    }
                    //Response.Redirect("~/Services_cr/service_cr.aspx", true);
                    //Response.Redirect("service_cr.aspx", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
                ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
                MV_UploadSR_View.ActiveViewIndex = 2;
            }
          
        }

        protected void imgbtn_Undo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                MV_UploadSR_View.ActiveViewIndex = 0;
                lblMessageUpload.Text = string.Empty;
                DataSet undoDs = new DataSet();
                ServiceBAL objServiceBAL_undo = new ServiceBAL();
                //MemberTermConfirm_undocr
                undoDs = objServiceBAL_undo.MemberTermConfirm_undocr(CommonConstantNames.EasyAdmin_Process, CommonConstantNames.Upload.ToString(), Convert.ToInt32(PolicyUID.ToString()), UserUID, Session[CommonConstantNames.TRANSACTIONID].ToString());
                if (undoDs == null && undoDs.Tables.Count > 0)//dsAfterUpload.Tables.Count > 0
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Undo Successfully ');", true);

                }
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Data Undo Successfully ');", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myconfirm", "confirm('No Rule Type Ids found for This Rule.');", true);
            }
            catch (Exception ex)
            {

                //ExceptionFramework.WriteErrorLogs_cr("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void chkValidation_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewState["dsAfterUpload"] != null)
            {
                if (((DataSet)ViewState["dsAfterUpload"]).Tables[2].Rows.Count > 0) //ls 0
                {

                }
            }
        }
    }
}