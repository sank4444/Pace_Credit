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

public partial class Services_service : System.Web.UI.Page
{
    #region Private variables..
    string ExcelConnection = string.Empty;
    int UserUID = 0;
    string MEMBERADDITION = "Member Addition";
    string MEMBERDELETION = "Member Deletion";

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[CommonConstantNames.USERUID] != null)
        {
            UserUID = Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString());
            /*
             * ADDED BY KARUNAKAR ON 02-05-2016
             * AS PER NEW CR TTSL
             * START
             */
            if (Session["IsTTSL"].ToString().ToUpper() == "Y")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "TTSLErrorFlag();", true);
            }
            //END
        }
        else
        {
            Response.Redirect("~/LoginPage.aspx", true);
        }

        if (!IsPostBack)
        {
            lblMessageUpload.Text = string.Empty;
            CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "Service.aspx");
            ((HtmlTableCell)this.Page.Master.FindControl("Servicing")).Attributes.Add("class", "active");
            ViewState["PolServicingChangeUID"] = string.Empty;
            ViewState[CommonConstantNames.DATASET] = null;
            ViewState[CommonConstantNames.DROPDOWNLISTDATA] = string.Empty;
            ViewState[CommonConstantNames.POLICYUID] = string.Empty;
            FillDropDown();
        }
    }

    /*displaying excel data in gridview   
     * Common for every process
     */
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
                    ds = objConfigurationBAL.CreateDataSet(strNewPath, strFileType);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Tables[0].Rows[0].Delete();
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
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
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


            ddlServicingChange.DataSource = objConfigurationBAL.GetServicingList(UserUID);
            DataSet dsddlData = objConfigurationBAL.GetServicingList(UserUID);
            ViewState[CommonConstantNames.DROPDOWNLISTDATA] = dsddlData.Tables[0];
            DataSet dsPolicyUId = objConfigurationBAL.GetPolicyUID(UserUID);
            if (dsPolicyUId.Tables[0].Rows.Count > 0)
            {
                //getting policyUID parameter because for servicing member deletion need Insert policyUID
                ViewState[CommonConstantNames.POLICYUID] = dsPolicyUId.Tables[0].Rows[0][CommonConstantNames.POLICYUID].ToString();

                ddlServicingChange.DataTextField = CommonConstantNames.POL_SERVICING_CHANGE_NAME;
                ddlServicingChange.DataValueField = CommonConstantNames.POL_SERVICING_CHANGE_CODE;
                ddlServicingChange.DataBind();
                ddlServicingChange.Items.Insert(0, (new ListItem("Select servicing list", "0")));
            }
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
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
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    /// <summary>
    /// Check Excel Validations
    /// </summary>
    /// <param name="dsExcel"></param>
    /// <returns></returns>
    /// 
    private bool CheckExcelValidation(DataSet dsExcel)
    {
        try
        {
            if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
            {
                if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.DATEOFINTIMATION) == false)
                {
                    DisplayMessage(Resource.DtofIntimationnotExs);
                    return false;
                }
                //else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.SUBOFFICECODE) == false)
                //{
                //    DisplayMessage(Resource.subOffnotEx);
                //    return false;
                //}
                //else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.SCHEMEJOININGDATE) == false)
                //{
                //    DisplayMessage(Resource.SchemeJoiningDtNE);
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
                else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.EMPLOYMENTDATE) == false)
                {
                    DisplayMessage(Resource.EmpDtntExst);
                    return false;
                }


                else if (dsExcel.Tables[0].Columns.Contains(CommonConstantNames.EMPLOYEENO) == false)
                {
                    DisplayMessage(Resource.EmpNontExs);
                    return false;
                }
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
            return true;
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            return false;
        }
    }
    //For Error Displaying 
    private void DisplayMessage(string Message)
    {
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Error Messages", "alert('" + Message + "');", true);
    }

    #region ...Upload Request

    protected void imgbtn_Back_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MV_UploadSR_View.ActiveViewIndex = 0;
            lblMessageUpload.Text = string.Empty;
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
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
                        if(_effectiveDate.Substring(0, 2).Contains('/') || _effectiveDate.Substring(0, 2).Contains("-")
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

                if (columns.Contains("Gender"))
                {
                    string _gender = (row["Gender"]).ToString();
                    if (!string.IsNullOrEmpty(_gender))
                    {
                        if (string.Compare(_gender, "M") != 0 || string.Compare(_gender, "F") != 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Gender as M of F');", true);
                            return false;
                        }
                        
                    }
                }

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

        try
        {
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

            if (ExcelDataValidation())
            {
                //Uploading is finished and Next Start
                //Return 3 tables
                DataSet dsAfterUpload = null;
                if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                {
                    dsAfterUpload = objServiceBAL.InsertXMLInDataBase(UserUID, ddlServicingChange.SelectedItem.Value, (DataSet)ViewState[CommonConstantNames.DATASET]);
                }
                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION)
                {
                    dsAfterUpload = objServiceBAL.InsertXMLInDataBaseForDeletion(UserUID, ddlServicingChange.SelectedItem.Value, (DataSet)ViewState[CommonConstantNames.DATASET], policyUID, PolServicingChangeUID);
                }
                else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY
                    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA
                    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG
                    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt
                    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME
                    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO
                    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_DOB
                    || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN)
                {
                    dsAfterUpload = objServiceBAL.InsertXMLInDataBaseForMinorServicingchanges(UserUID, ddlServicingChange.SelectedItem.Value, (DataSet)ViewState[CommonConstantNames.DATASET], policyUID, PolServicingChangeUID);
                }
                if (dsAfterUpload.Tables[0].Rows.Count == 0 && dsAfterUpload.Tables[1].Rows.Count == 0 && dsAfterUpload.Tables[2].Rows.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "alert('The Uploaded Excel is Empty. Please insert atleast One Record.');", true);
                }
               
                //STARTS
                else
                {
                    if (dsAfterUpload.Tables.Count > 0)
                        lblCount.Text = "Success :  " + Convert.ToString(dsAfterUpload.Tables[0].Rows.Count > 0 ? dsAfterUpload.Tables[0].Rows.Count.ToString() : "0") +
                            " Duplicate : " + Convert.ToString(dsAfterUpload.Tables[1].Rows.Count > 0 ? dsAfterUpload.Tables[1].Rows.Count.ToString() : "0") +
                            " Error : " + Convert.ToString(dsAfterUpload.Tables[2].Rows.Count > 0 ? dsAfterUpload.Tables[2].Rows.Count.ToString() : "0");
                    //END
                   // grdConform.DataSource = dsAfterUpload.Tables[0];
                    grdDuplicate.DataSource = dsAfterUpload.Tables[1];
                    grdErrorLog.DataSource = dsAfterUpload.Tables[2];
                    if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                    {
                        TabPanel3.Visible = true;
                        gvAWW.DataSource = dsAfterUpload.Tables[3];
                        gvAWW.DataBind();
                    }
                    else
                    {
                        TabPanel3.Visible = false;
                        TabPanel3.HeaderText = string.Empty;
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
                            if (dsAfterUpload.Tables[3].Rows.Count > 0)
                            {
                                ViewState["dsAfterUpload"] = dsAfterUpload;
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please select i accept AAW');", true);
                                TabContainer1.ActiveTabIndex = 3;
                                chkValidation_CheckedChanged(this, EventArgs.Empty);
                            }

                            else
                            {
                                TabContainer1.ActiveTabIndex = 0;
                            }

                        }
                        if (dsAfterUpload.Tables[0].Rows.Count > 0)
                        {
                            if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
                            {
                                if (dsAfterUpload.Tables[3].Rows.Count > 0)
                                {
                                    TabContainer1.ActiveTabIndex = 3;
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
                            Session[CommonConstantNames.TRANSACTIONID] = dsAfterUpload.Tables[0].Rows[0][CommonConstantNames.TRANSACTIONID].ToString();
                            imgbtn_Confirm.Visible = true;
                        }
                        //Duplicate tab
                        else if (dsAfterUpload.Tables[2].Rows.Count > 0)
                        {
                            TabContainer1.ActiveTabIndex = 2;
                            imgbtn_Confirm.Visible = false;
                        }
                        //Error tab
                        else if (dsAfterUpload.Tables[1].Rows.Count > 0)
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
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = Color.Red;
            MV_UploadSR_View.ActiveViewIndex = 1;
        }

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
            #region CONFIRM..
            //Calling following data  Insert into database 
            if (ddlServicingChange.SelectedItem.Text == MEMBERADDITION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
            {
                DataTable dtSelectedRecord = GetSelectedRecord();
                dsNext = objServiceBAL.MemberTermConfirm(UserUID, Session[CommonConstantNames.TRANSACTIONID].ToString(), dtSelectedRecord);
            }
            else if (ddlServicingChange.SelectedItem.Text == MEMBERDELETION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION)
            {
                dsNext = objServiceBAL.MemberTermConfirmDeletion(UserUID, Session[CommonConstantNames.TRANSACTIONID].ToString());
                ServiceReqNo = dsNext.Tables[0].Rows[0]["ServiceReqNo"].ToString();
            }

            else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt
                 || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_DOB
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN
                )
            {

                dsNext = objServiceBAL.MemberTermConfirmMinorServicingchanges(UserUID, Convert.ToInt32(Convert.ToString(ViewState["PolServicingChangeUID"])), Convert.ToString(ddlServicingChange.SelectedItem.Value.ToString()), Convert.ToString(Session[CommonConstantNames.TRANSACTIONID]));
                ServiceReqNo = dsNext.Tables[0].Rows[0]["ServiceReqNo"].ToString();
            }
            Session["divDisplay"] = "Confirm";

            #endregion

            #region JOB RUN..

            //  labelDisplayingText.Text = "Job is running...";

            //Executing job and calculating premium
            Session["divDisplay"] = "Job";
            if (ddlServicingChange.SelectedItem.Text == MEMBERADDITION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
            {
                if (dsNext.Tables[0].Rows.Count > 0)
                {
                    dsJob = objServiceBAL.Autounderwriting_Job(UserUID, Session[CommonConstantNames.TRANSACTIONID].ToString());
                    ViewState["JobRun"] = dsJob;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Members status are in  dataentry cannot be issued because not sufficient suboffice balance');", true);
                }
            }
            else if (ddlServicingChange.SelectedItem.Text == MEMBERDELETION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION)
            {
                dsJob = objServiceBAL.Autounderwriting_Job_Deletion(UserUID, ServiceReqNo);
                ViewState["JobRun"] = dsJob;
            }
            else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt)
            {
                dsJob = objServiceBAL.Autounderwriting_Job_SumAssured(UserUID, ServiceReqNo);
                ViewState["JobRun"] = dsJob;
            }
            else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_DOB
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN)
            {
                dsJob = objServiceBAL.Autounderwriting_Job_MinorServicingchanges(UserUID, ServiceReqNo, Convert.ToString(Session[CommonConstantNames.TRANSACTIONID]));
                ViewState["JobRun"] = dsJob;
            }
            if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_NAME
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_EMPNO
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_DOB
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.SERVICE_GEN)
            {
                imgBillGenerate.Visible = false;
            }

            MV_UploadSR_View.ActiveViewIndex = 3;

            Session["divDisplay"] = "MemberUpload";
            //span.InnerText = "Member Upload is running...";

            //Display A new grid use dsJob  
            //New button Generate bill 
            //Generate Bill for above insert into the database
            if (ViewState["JobRun"] != null)
            {
                gvJob.DataSource = ViewState["JobRun"] as DataSet;
                gvJob.DataBind();
            }
            #endregion

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = Color.Red;
            MV_UploadSR_View.ActiveViewIndex = 2;
        }
    }

    protected void imgBillGenerate_Click(object sender, ImageClickEventArgs e)
    {
        ServiceBAL objServiceBAL = null;
        try
        {
            objServiceBAL = new ServiceBAL();
            DataSet dsBillTemp = new DataSet();
            //span.InnerText = "Member Upload is running...";

            if (ddlServicingChange.SelectedItem.Text == MEMBERADDITION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
            {
                dsBillTemp = objServiceBAL.MEMBER_BILLPROCESS_UPLOAD_TEMP(UserUID, Session[CommonConstantNames.TRANSACTIONID].ToString());
            }
            else if (ddlServicingChange.SelectedItem.Text == MEMBERDELETION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION)
            {
                dsBillTemp = objServiceBAL.MEMBER_BILLPROCESS_UPLOAD_TEMP_Deletion(UserUID, Session[CommonConstantNames.TRANSACTIONID].ToString());
            }
            else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt)
            {
                dsBillTemp = objServiceBAL.MEMBER_BILLPROCESS_UPLOAD_TEMP_SumAssured(UserUID, ddlServicingChange.SelectedItem.Value.ToString(), Convert.ToString(Session[CommonConstantNames.TRANSACTIONID]));
            }
            Session["divDisplay"] = "Billgenerating";
            //span.InnerText = "Bill generating is running...";

            //you will get a Dataset convert it into exml pass it into below procedure  
            //Issue Bill 
            ViewState["dsBillTemp"] = dsBillTemp;
            MV_UploadSR_View.ActiveViewIndex = 4;
            grBillGeneration.DataSource = dsBillTemp;
            grBillGeneration.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = Color.Red;
            MV_UploadSR_View.ActiveViewIndex = 3;
        }
    }

    protected void imgIssueBill_Click(object sender, ImageClickEventArgs e)
    {
        DataSet dsBillIssue = new DataSet();
        ServiceBAL objServiceBAL = null;
        try
        {
            Session["divDisplay"] = "BillIssue";

            objServiceBAL = new ServiceBAL();
            if (ddlServicingChange.SelectedItem.Text == MEMBERADDITION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_ADDITION)
            {
                dsBillIssue = objServiceBAL.MEMBER_BILLPROCESS_CONFIRM(UserUID, Session[CommonConstantNames.TRANSACTIONID].ToString(), (DataSet)ViewState["dsBillTemp"]);
            }
            else if (ddlServicingChange.SelectedItem.Text == MEMBERDELETION && ddlServicingChange.SelectedItem.Value == CommonConstantNames.MEMBER_DELETION)
            {
                dsBillIssue = objServiceBAL.MEMBER_BILLPROCESS_CONFIRM_Deletion(UserUID, (DataSet)ViewState["dsBillTemp"], Session[CommonConstantNames.TRANSACTIONID].ToString());
            }
            else if (ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMSALARY
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSA
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMFSG
                || ddlServicingChange.SelectedItem.Value == CommonConstantNames.TRMDesignt)
            {
                dsBillIssue = objServiceBAL.MEMBER_BILLPROCESS_CONFIRM_SumAssured(UserUID, (DataSet)ViewState["dsBillTemp"], Session[CommonConstantNames.TRANSACTIONID].ToString());
            }

            MV_UploadSR_View.ActiveViewIndex = 5;
            gvBillIssue.DataSource = dsBillIssue;
            gvBillIssue.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = Color.Red;
            MV_UploadSR_View.ActiveViewIndex = 4;
        }
    }

    protected void imgbtn_Undo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            MV_UploadSR_View.ActiveViewIndex = 0;
            lblMessageUpload.Text = string.Empty;
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    #endregion


    protected void gvBillIssue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "view")
        {
            Session[CommonConstantNames.BILLUID] = e.CommandArgument.ToString();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "BlockName", "window.open('../Services/PopUpBillGeneration.aspx','Download','toolbar=no; directories=no; location=no; status=yes; menubar=no; resizable=yes; scrollbars=no;fullscreen=yes;');", true);
        }
    }

    protected void chkValidation_CheckedChanged(object sender, EventArgs e)
    {
        if (ViewState["dsAfterUpload"] != null)
        {
            if (((DataSet)ViewState["dsAfterUpload"]).Tables[0].Rows.Count > 0)
            {

            }
        }
    }

    protected DataTable GetSelectedRecord()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("AAWFlag"), new DataColumn("COI") });
        foreach (GridViewRow row in gvAWW.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                if (chkRow.Checked)
                {
                    string AAWFlag = (chkRow.Checked) ? "Y" : "N";
                    string COI = (row.Cells[0].FindControl("lblCOI") as Label).Text;
                    dt.Rows.Add(AAWFlag, COI);
                }
            }
        }
        return dt;
    }


}
