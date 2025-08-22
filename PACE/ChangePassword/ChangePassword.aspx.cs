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
using GlimpsBAL;
using System.Data.SqlClient;
using GlimpsDAL.Common;
using System.Drawing.Imaging;
using PACE.WebReference;


public partial class ChangePassword_ChangePassword : System.Web.UI.Page
{
    string userUID = "";
    string subOfficeUID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[CommonConstantNames.USERUID] != null)
        {
            userUID = Session[CommonConstantNames.USERUID].ToString();
            subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
        }
        else
        {
            Response.Redirect("~/LoginPage.aspx", true);
        }

        ((HtmlTableCell)this.Page.Master.FindControl("Miscellaneous")).Attributes.Add("class", "active");

        if (!IsPostBack)
        {

            CommonMethods.InsertingPageInfo("I", userUID, "ChangePassword.aspx");
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LoginCredentialBAL loginCredentialBAL = null;
        try
        {
            loginCredentialBAL = new LoginCredentialBAL();
           
            string sUserUID = Session[CommonConstantNames.USERUID].ToString();


            if (Session["CaptchaImageText"] != null)
            {

                if (this.TxtCaptchaCode.Text == this.Session["CaptchaImageText"].ToString())
                {
                    /*LDAP Changed Password Request*/
                    UserAuthenticationInterfaceExport1_UserAuthenticationInterfaceHttpService UIUIH = new UserAuthenticationInterfaceExport1_UserAuthenticationInterfaceHttpService();
                    ChangePasswordReq objChangePasswordReq = new ChangePasswordReq();
                    changePassword objchangePassword = new changePassword();
                    objChangePasswordReq.oldPassword = txtOldPassword.Text;
                    objChangePasswordReq.newPassword = txtNewPassword.Text;
                    //For UAT
                    //string username = "uid=" + Session["USERNAME_LOGIN"].ToString() + ",cn=users,ou=elife,dc=aiu,dc=aig,dc=com";
                    //For Production
                    objChangePasswordReq.userId = "uid=" + Session["USERNAME_LOGIN"].ToString() + ",cn=users,ou=glimpseportal,dc=aiu,dc=aig,dc=com";

                    objchangePassword.ChangePwdReq = objChangePasswordReq;
                    ChangePasswordRes objChangePasswordRes = new ChangePasswordRes();
                    changePasswordResponse objchangePasswordResponse = new changePasswordResponse();
                    objchangePasswordResponse = UIUIH.changePassword(objchangePassword);

                    objChangePasswordRes = objchangePasswordResponse.ChangePwdRes;
                    string isChanged = objChangePasswordRes.response;
                    string ErrorMessage = objChangePasswordRes.errorMessage;
                    if (isChanged.ToLower() == "true")
                    {
                        DataSet ds = loginCredentialBAL.CHANGEPASSWORD(txtNewPassword.Text, txtOldPassword.Text, sUserUID);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["PasswordChangeFlag"].ToString() == "Y")
                            {
                                Session[CommonConstantNames.USERUID] = ds.Tables[0].Rows[0][CommonConstantNames.USERUID].ToString();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "ReturningDefault();", true);
                            }
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert('Password is wrong');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert('Password is wrong');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Msg", "alert('Please Enter Correct CaptchaCode');", true);
                }
            }
        }
        catch (SqlException ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert(" + ex.Message + ");", true);
        }
    }

    // Function to generate random string with Random class.
    private string GenerateRandomCode()
    {
        Random r = new Random();
        string s = "";
        for (int j = 0; j < 5; j++)
        {
            int i = r.Next(3);
            int ch;
            switch (i)
            {
                case 1:
                    ch = r.Next(0, 9);
                    s = s + ch.ToString();
                    break;
                case 2:
                    ch = r.Next(65, 90);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
                case 3:
                    ch = r.Next(97, 122);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
                default:
                    ch = r.Next(97, 122);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
            }
            r.NextDouble();
            r.Next(100, 1999);
        }
        return s;
    }
}


