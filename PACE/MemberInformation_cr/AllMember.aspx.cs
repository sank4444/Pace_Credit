using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI;
using GlimpsBAL;
using GlimpsDAL;
using GlimpsDAL.Common;
using System.Web.UI.HtmlControls;
using PACE.Masters;
using System.IO;
using System.Collections.Generic;
using Ionic.Zip;
using System.Text;
using System.Net;

namespace PACE.MemberInformation_cr
{
    public partial class AllMember : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        //string DownloadCOILink = ConfigurationManager.ConnectionStrings["DownloadCOI"].ToString().Trim();
        string DownloadCOILink = "COIPrintingReport.aspx";
        public string clientsCOIDwn;
        MemberInfoBAL memberInfoBAL = null;
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                this.clientsCOIDwn = DownloadCOILink;
               
                
                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    // subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
                //((HtmlTableCell)this.Page.Master.FindControl("MemberInformation_cr")).Attributes.Add("class", "active");  //Commented by sanket on 27/5/2025

                if (!IsPostBack)
                {
                    BindGrid("", "", "");
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "AllMember.aspx");
                    //gvAllMembeInfo.Visible = false;
                    //lblResult.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }


        protected void btnSearchCOI_Click(object sender, EventArgs e)
        {
            try
            {
                string FromDate = txtdateFrom.Text.ToString().Trim();
                string FromTo = txtdateTo.Text.ToString().Trim();
                string COINo = txtCoiNo.Text.ToString().Trim(); 

                memberInfoBAL = new MemberInfoBAL();
                DataSet ds = memberInfoBAL.ALLGetMemberInfo_cr(Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString()), FromDate, FromTo, COINo);
                ViewState["DATA"] = ds.Tables[0];

                if ((DataTable)ViewState["DATA"] != null)
                {
                    if (((DataTable)ViewState["DATA"]).Rows.Count > 0)
                    {
                        gvAllMembeInfo.DataSource = (DataTable)ViewState["DATA"];
                        gvAllMembeInfo.DataBind();
                        //added by Sanket on 28/5/2025
                        gvAllMembeInfo.UseAccessibleHeader = true;
                        gvAllMembeInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
                        //---------------------------------
                    }
                    else
                    {
                        MenuMasterPage_Cr.ShowNoResultFound((DataTable)ViewState["DATA"], gvAllMembeInfo);
                        gvAllMembeInfo.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        private void BindGrid(string FromDate, string FromTo, string COINo)
        {
            memberInfoBAL = new MemberInfoBAL();
            DataSet ds = memberInfoBAL.ALLGetMemberInfo_cr(Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString()), FromDate, FromTo, COINo);
            ViewState["DATA"] = ds.Tables[0];
            
            if ((DataTable)ViewState["DATA"] != null)
            {
                if (((DataTable)ViewState["DATA"]).Rows.Count > 0)
                {
                    gvAllMembeInfo.DataSource = (DataTable)ViewState["DATA"];
                    gvAllMembeInfo.DataBind();
                    //added by Sanket on 28/5/2025
                    gvAllMembeInfo.UseAccessibleHeader = true;
                    gvAllMembeInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //---------------------------------
                }
                else
                {
                    MenuMasterPage_Cr.ShowNoResultFound((DataTable)ViewState["DATA"], gvAllMembeInfo);
                    gvAllMembeInfo.DataBind();
                }
            }
        }
        protected void gvAllMembeInfo_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            
        }
        
        protected void DownloadFiles(object sender, EventArgs e)
        {
            string saveLoc = Server.MapPath("~/Download_COI_Pdf/");
            Response.ContentType = "application/zip";

            string url = "";
            string PolicyMemberUID = "";
            bool blnFound = false;
            using (ZipFile zip = new ZipFile())
            {
                int count = 0;
                foreach (GridViewRow gr in gvAllMembeInfo.Rows)
                {
                    CheckBox chk = (CheckBox)gr.FindControl("chkSelect");
                    if (chk.Checked)
                    {
                        blnFound = true;
                        PolicyMemberUID =  PolicyMemberUID +"," +Convert.ToString(gvAllMembeInfo.DataKeys[gr.RowIndex].Value) ;
                    }
                    ++count; 
                }
                if (blnFound == true)
                {
                    PolicyMemberUID = PolicyMemberUID.Remove(0, 1);
                    url = "" + DownloadCOILink + "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NewWindow", "window.open('../MemberInformation_cr/COIPrintingReport.aspx?PolicyMemberUID=" + PolicyMemberUID + "','PolicyMemberUID','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
                   // Response.Redirect(url);
                    //Thread.Sleep(1000);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "myfunc", "HideImage('" + url + "')", true);
                   
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Please select atleast one file to download');", true);
                }
                //zip.Save(Response.OutputStream);
            }
        }
            
        //protected void DownloadFiles(object sender, EventArgs e)
        //{
        //    using (ZipFile zip = new ZipFile())
        //    {
        //        //zip.AlternateEncodingUsage = ZipOption.AsNecessary;
        //        zip.AddDirectoryByName("Files");
        //        List<string> imagespath = new List<string>();
        //        //foreach (GridViewRow row in gvAllMembeInfo.Rows)
        //        foreach (GridViewRow row in gvAllMembeInfo.Rows)
        //        {
        //            if ((row.FindControl("chkSelect") as CheckBox).Checked)
        //            {
        //                int PolicyMemberUID = Convert.ToInt32(gvAllMembeInfo.DataKeys[row.RowIndex].Value);

        //                string filePath =  "" + DownloadCOILink + "" + PolicyMemberUID + ""; ;//(row.FindControl("lblFilePath") as Label).Text;
        //                string file = GetImage(filePath);

        //                imagespath.Add(file);
        //                zip.AddFile(file, "Files");
        //            }
        //        }
        //        Response.Clear();
        //        Response.BufferOutput = false;
        //        string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //        Response.ContentType = "application/zip";
        //        Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        //        zip.Save(Response.OutputStream);
        //        string folderPath = Server.MapPath("TempImages/");

        //        foreach (var path in imagespath)
        //        {
        //            if (File.Exists(path))
        //            {
        //                File.Delete(path);
        //            }
        //        }
        //        Response.End();
        //    }
        //}

        //private string GetImage(string url)
        //{
        //    string filename = Path.GetFileName(url);
        //    string folderPath = Server.MapPath("Download_COI_Pdf/");
        //    string saveLoc = folderPath + filename;
        //    if (!Directory.Exists(folderPath))
        //    {
        //        Directory.CreateDirectory(folderPath);
        //    }
        //    using (WebClient wc = new WebClient())
        //    {
        //        byte[] fileBytes = wc.DownloadData(url);
        //        System.IO.File.WriteAllBytes(saveLoc, fileBytes);
        //    }
        //    return saveLoc;
        //}



        //private string GetImage(string url)
        //{
        //    string filename = Path.GetFileName(url);
        //    string folderPath = Server.MapPath("Download_COI_Pdf/");
        //    string saveLoc = folderPath + filename;
        //    if (!Directory.Exists(folderPath))
        //    {
        //        Directory.CreateDirectory(folderPath);
        //    }
        //    using (WebClient wc = new WebClient())
        //    {
        //        byte[] fileBytes = wc.DownloadData(url);
        //        System.IO.File.WriteAllBytes(saveLoc, fileBytes);
        //    }
        //    return saveLoc;
        //}


        //protected void DownloadFiles(object sender, EventArgs e)
        //{

        //    using (ZipFile zip = new ZipFile())
        //    {

        //        //zip.AlternateEncodingUsage = ZipOption.AsNecessary;

        //        zip.AddDirectoryByName("Files");

        //        //foreach (GridViewRow row in gvAllMembeInfo.Rows)
        //        //{
        //        //    if ((row.FindControl("chkSelect") as CheckBox).Checked)
        //        //    {
        //        //        string filePath = (row.FindControl("lblFilePath") as Label).Text;
        //        //        zip.AddFile(filePath, "Files");
        //        //    }
        //        //}
        //        //***********
        //        //foreach (GridViewRow gvrow in gvAllMembeInfo.Rows)
        //        //{
        //        //    var checkbox = gvrow.FindControl("chkSelect") as CheckBox;
        //        //    if (checkbox.Checked)
        //        //    {
        //        //    }
        //        //}
        //        //***********

        //        foreach (GridViewRow row in gvAllMembeInfo.Rows)
        //        {
        //            if (row.RowType == DataControlRowType.DataRow)
        //            {
        //                CheckBox chkRow = (row.Cells[0].FindControl("chkSelect") as CheckBox);
        //                if (chkRow.Checked)
        //                {

        //                }
        //            }
        //        }



        //        Response.Clear();

        //        Response.BufferOutput = false;

        //        string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));

        //        Response.ContentType = "application/zip";

        //        Response.AddHeader("content-disposition", "attachment; filename=" + zipName);

        //        zip.Save(Response.OutputStream);

        //        Response.End();

        //    }

        //}

        //protected void gvAllMembeInfo_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        //{
        //     if (e.CommandName == "View")
        //     {
        //         Session[CommonConstantNames.POLICYMEMBERUID] = e.CommandArgument.ToString();

        //         //LS
        //         //Response.Clear();
        //         //Response.Redirect("MemberInfoDetails_cr.aspx?PolicyMemberUID=" + e.CommandArgument.ToString() + "",true);
        //         //Response.End();
        //     }
        //}
        

        //protected void gvAllMembeInfo_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "View")
        //    {
        //        Session[CommonConstantNames.POLICYMEMBERUID] = e.CommandArgument.ToString();

        //        //LS
        //        //Response.Clear();
        //        //Response.Redirect("MemberInfoDetails_cr.aspx?PolicyMemberUID=" + e.CommandArgument.ToString() + "",true);
        //        //Response.End();
        //    }
        //}
        //LS New Added
        //protected void lnkCoi_Click(object sender, EventArgs e)
        //{
        //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../COIPopUP.aspx?" + "COIID" + "','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
        //    // int oPolicyUID;
        //    //int oCOI;
        //    // oPolicyUID = Convert.ToInt32(Session[CommonConstantNames.POLICYUID]);
        //    // Response.Redirect("Default2.aspx?UserId="+txtUserId.Text+"&UserName="+txtUserName.Text);
        //    //COI_cr = Convert.ToInt32(Session["COI_cr"]);
        //    //  Response.Redirect("http://192.168.1.57:310/PDF_cr.aspx?PolicyMemberUID=" + PolicyMemberUID);
        //    //LS  Response.Redirect("http://192.168.1.57:208/PDF_cr.aspx?PolicyMemberUID=" + PolicyMemberUID);

        //    //hdnMemberID.Value = PolicyMemberUID.ToString();
        //    //string js = "";
        //    //js += "window.opener.location.href='" + GeneratingPDFDynamically + "" + PolicyMemberUID + "';";
        //    //ClientScript.RegisterStartupScript(this.GetType(), "redirect", js, true);


        //    string url = "" + GeneratingPDFDynamically + "" + PolicyMemberUID + "";

        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<script type = 'text/javascript'>");

        //    sb.Append("window.open('");

        //    sb.Append(url);

        //    sb.Append("');");

        //    sb.Append("</script>");

        //    ClientScript.RegisterStartupScript(this.GetType(),

        //            "script", sb.ToString());

        //}

    }
}
