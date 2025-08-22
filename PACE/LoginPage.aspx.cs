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
using System.Data.SqlClient;
using PACE.WebReference;
using PACE;

public partial class LoginPage : System.Web.UI.Page
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    /*
     * added by karunakar on 19-01-2017
     * Reason : Cross site request forgery 
     */
    protected void Page_Init(object sender, EventArgs e)
    {
        //First, check for the existence of the Anti-XSS cookie
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;

        //If the CSRF cookie is found, parse the token from the cookie.
        //Then, set the global page variable and view state user
        //key. The global variable will be used to validate that it matches in the view state form field in the Page.PreLoad
        //method.
        if (requestCookie != null && requestCookie.Value != string.Empty)
        {
            //Set the global token variable so the cookie value can be
            //validated against the value in the view state form field in
            //the Page.PreLoad method.
            _antiXsrfTokenValue = requestCookie.Value;

            //Set the view state user key, which will be validated by the
            //framework during each request
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        //If the CSRF cookie is not found, then this is a new session.
        else
        {
            //Generate a new Anti-XSRF token
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");

            //Set the view state user key, which will be validated by the
            //framework during each request
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            //Create the non-persistent CSRF cookie
            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                //Set the HttpOnly property to prevent the cookie from
                //being accessed by client side script
                HttpOnly = true,

                //Add the Anti-XSRF token to the cookie value
                Value = _antiXsrfTokenValue
            };

            //If we are using SSL, the cookie should be set to secure to
            //prevent it from being sent over HTTP connections
            if (FormsAuthentication.RequireSSL &&
            Request.IsSecureConnection)
                responseCookie.Secure = true;

            //Add the CSRF cookie to the response
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        //During the initial page load, add the Anti-XSRF token and user
        //name to the ViewState
        if (!IsPostBack)
        {
            //Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;

            //If a user name is assigned, set the user name
            ViewState[AntiXsrfUserNameKey] =
            Context.User.Identity.Name ?? String.Empty;
        }
        //During all subsequent post backs to the page, the token value from
        //the cookie should be validated against the token in the view state
        //form field. Additionally user name should be compared to the
        //authenticated users name
        else
        {
            //Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
            || (string)ViewState[AntiXsrfUserNameKey] !=
            (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }
    //end

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }

            Session[CommonConstantNames.USERUID] = string.Empty;
            Session[CommonConstantNames.USERNAME] = string.Empty;
            Session[CommonConstantNames.NAME] = string.Empty;
            Session[CommonConstantNames.SUBOFFICEUID] = string.Empty;
            Session[CommonConstantNames.ISLOGGEDIN] = string.Empty;
            Session[CommonConstantNames.LOGGEDINDATE] = string.Empty;

            Session["PolicyID"] = string.Empty;
            Session["USERUID_LOGIN"] = string.Empty;
            Session["USERNAME_LOGIN"] = string.Empty;
            Session["NAME_LOGIN"] = string.Empty;
            Session["SUBOFFICEUID_LOGIN"] = string.Empty;
            Session["ISLOGGEDIN_LOGIN"] = string.Empty;
            Session["LOGGEDINDATE_LOGIN"] = string.Empty;
            Session[CommonConstantNames.POLICYUID] = string.Empty;

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }
    }

    protected void butLogin_Click(object sender, EventArgs e)
    {

        LoginCredentialBAL loginCredentialBAL = null;
        try
        {
            loginCredentialBAL = new LoginCredentialBAL();
            Session.Clear();
            Session.RemoveAll();
            Session[CommonConstantNames.USERUID] = string.Empty;
            Session[CommonConstantNames.USERNAME] = string.Empty;
            Session[CommonConstantNames.NAME] = string.Empty;
            Session[CommonConstantNames.SUBOFFICEUID] = string.Empty;
            Session[CommonConstantNames.ISLOGGEDIN] = string.Empty;
            Session[CommonConstantNames.LOGGEDINDATE] = string.Empty;
            Session[CommonConstantNames.POLICYUID] = string.Empty;

            Session["USERUID_LOGIN"] = string.Empty;
            Session["USERNAME_LOGIN"] = string.Empty;
            Session["NAME_LOGIN"] = string.Empty;
            Session["SUBOFFICEUID_LOGIN"] = string.Empty;
            Session["ISLOGGEDIN_LOGIN"] = string.Empty;
            Session["LOGGEDINDATE_LOGIN"] = string.Empty;
            Session["PolicyID"] = string.Empty;



            //Used for LDAP authentication 
            /*
             *It used for client reqiurment 
             *web service is used for authotication of user  
             *starts         
             */
            UserAuthenticationInterfaceExport1_UserAuthenticationInterfaceHttpService UAIE = new UserAuthenticationInterfaceExport1_UserAuthenticationInterfaceHttpService();
            //UAT
            string username = "uid=" + txtUserName.Text + ",cn=users,ou=elife,dc=aiu,dc=aig,dc=com";
            string password = txtPassword.Text;
            //Production
            //string username = "uid=" + txtUserName.Text + ",cn=users,ou=glimpseportal,dc=aiu,dc=aig,dc=com";//"glimpseuser1";//Convert.ToString(txtUserName.Text);
            //string password = "Password1";//txtPassword.Text;//"talicwebadm";// Convert.ToString(txtPassword.Text);

            getCredentialCheck objgetCredentialCheck = new getCredentialCheck();
            CredentialReqBO objCredentialReqBO = new CredentialReqBO();
            objCredentialReqBO.userId = username;
            objCredentialReqBO.password = password;
            objgetCredentialCheck.CredentialReq = objCredentialReqBO;

            getCredentialCheckResponse objgetCredentialCheckResponse = new getCredentialCheckResponse();

            if (UAIE.Proxy == null)
            {
                bool isValidUser, isValid;

                isValid = Convert.ToBoolean(ConfigurationManager.AppSettings["isValidUser"].ToString());

                if (isValid == false)
                {
                    isValidUser = true;
                }
                else
                {
                    objgetCredentialCheckResponse = UAIE.getCredentialCheck(objgetCredentialCheck);
                    CredentialResBO objCredentialResBO = new CredentialResBO();
                    objCredentialResBO = objgetCredentialCheckResponse.CredentialRes;
                    isValidUser = objCredentialResBO.response;
                    string ErrorMsg = objCredentialResBO.errorMessage;
                    string ErrorCode = objCredentialResBO.errorCode;
                }

                if (isValidUser == true)
                {
                    //end here LDAP
                    DataSet ds = loginCredentialBAL.UserValidation(txtUserName.Text, txtPassword.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            //Authentication layer for Ageis network
                            //foreach (string strAegisUserName in ConfigurationManager.ConnectionStrings["AegisUserNames"].ConnectionString.ToString().Split(';'))
                            //    {
                            //        if (ds.Tables[0].Rows[0][CommonConstantNames.USERNAME].ToString().Equals(strAegisUserName) && !string.IsNullOrEmpty(strAegisUserName))
                            //        {
                            //            if (IsAegisNetwork(ds.Tables[0].Rows[0]["IpAddress"].ToString().Split('|')))
                            //            {
                            //                //ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert('" + Request.ServerVariables["HTTP_X_FORWARDED_FOR"] + "<BR/>" + Request.ServerVariables["REMOTE_ADDR"] + " is not athourised !');", true);
                            //                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert('" + " your not authorised!" + "');", true);
                            //                return;
                            //            }
                            //        }
                            //    }

                            if (ds.Tables[0].Rows[0]["PasswordChangeFlag"].ToString() == "Y")
                        {
                            // createa a new GUID and save into the session
                            string guid = Guid.NewGuid().ToString();
                            Session["AuthToken"] = guid;
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                            string guid1 = Guid.NewGuid().ToString();
                            //Added for HTTPONLY Error in Security 

                            //if (ds.Tables[0].Rows[0]["PolicyActiveFlag"].ToString() == "Y")
                            if (ds.Tables[0].Rows[0]["ApplicationAccessFlag"].ToString() == "C")
                            {
                                //Added by Karunakar on 28-04-2016 START
                                Session["IsTTSL"] = ds.Tables[0].Rows[0]["TTSLFlag"].ToString();
                                //Session["IsTTSL"] = "N";
                                Session["USERUID_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.USERUID].ToString();
                                Session["USERNAME_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.USERNAME].ToString();
                                Session["NAME_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.NAME].ToString();
                                Session["SUBOFFICEUID_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.SUBOFFICEUID].ToString();
                                Session["ISLOGGEDIN_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.ISLOGGEDIN].ToString();
                                Session["LOGGEDINDATE_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.LOGGEDINDATE].ToString();
                                Session["PolicyID"] = ds.Tables[0].Rows[0][CommonConstantNames.POLICYUID].ToString();

                                Session[CommonConstantNames.POLICYUID] = Session["PolicyID"];
                                Session[CommonConstantNames.USERUID] = Session["USERUID_LOGIN"];
                                Session[CommonConstantNames.USERNAME] = Session["USERNAME_LOGIN"];
                                Session[CommonConstantNames.NAME] = Session["NAME_LOGIN"];
                                Session[CommonConstantNames.SUBOFFICEUID] = Session["SUBOFFICEUID_LOGIN"];
                                Session[CommonConstantNames.ISLOGGEDIN] = Session["ISLOGGEDIN_LOGIN"];
                                Session[CommonConstantNames.LOGGEDINDATE] = Session["LOGGEDINDATE_LOGIN"];

                                CommonMethods.InsertingPageInfo("I", Convert.ToString(Session[CommonConstantNames.USERUID]), "LoginPage.aspx");
                                    Response.Redirect("~/Default_CL.aspx");
                                    //Response.Redirect("~/DefaultNew.aspx");
                                }
                            else if (ds.Tables[0].Rows[0]["ApplicationAccessFlag"].ToString() == "G")
                            {
                                //Added by Karunakar on 28-04-2016 START
                                Session["IsTTSL"] = ds.Tables[0].Rows[0]["TTSLFlag"].ToString();
                                //Session["IsTTSL"] = "N";
                                Session["USERUID_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.USERUID].ToString();
                                Session["USERNAME_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.USERNAME].ToString();
                                Session["NAME_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.NAME].ToString();
                                Session["SUBOFFICEUID_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.SUBOFFICEUID].ToString();
                                Session["ISLOGGEDIN_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.ISLOGGEDIN].ToString();
                                Session["LOGGEDINDATE_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.LOGGEDINDATE].ToString();
                                Session["PolicyID"] = ds.Tables[0].Rows[0][CommonConstantNames.POLICYUID].ToString();

                                Session[CommonConstantNames.POLICYUID] = Session["PolicyID"];
                                Session[CommonConstantNames.USERUID] = Session["USERUID_LOGIN"];
                                Session[CommonConstantNames.USERNAME] = Session["USERNAME_LOGIN"];
                                Session[CommonConstantNames.NAME] = Session["NAME_LOGIN"];
                                Session[CommonConstantNames.SUBOFFICEUID] = Session["SUBOFFICEUID_LOGIN"];
                                Session[CommonConstantNames.ISLOGGEDIN] = Session["ISLOGGEDIN_LOGIN"];
                                Session[CommonConstantNames.LOGGEDINDATE] = Session["LOGGEDINDATE_LOGIN"];

                                CommonMethods.InsertingPageInfo("I", Convert.ToString(Session[CommonConstantNames.USERUID]), "LoginPage.aspx");
                                Response.Redirect("~/Default.aspx");
                            }
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["PolicyActiveFlag"].ToString() == "Y")
                            {
                                if (ds.Tables[0].Rows[0]["ApplicationAccessFlag"].ToString() == "G")
                                {
                                    // createa a new GUID and save into the session
                                    string guid = Guid.NewGuid().ToString();
                                    Session["AuthToken"] = guid;
                                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                                    //Added by Karunakar on 28-04-2016 START
                                    Session["IsTTSL"] = ds.Tables[0].Rows[0]["TTSLFlag"].ToString();
                                    //Session["IsTTSL"] = "N";
                                    Session["USERUID_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.USERUID].ToString();
                                    Session["USERNAME_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.USERNAME].ToString();
                                    Session["NAME_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.NAME].ToString();
                                    Session["SUBOFFICEUID_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.SUBOFFICEUID].ToString();
                                    Session["ISLOGGEDIN_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.ISLOGGEDIN].ToString();
                                    Session["LOGGEDINDATE_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.LOGGEDINDATE].ToString();
                                    Session["PolicyID"] = ds.Tables[0].Rows[0][CommonConstantNames.POLICYUID].ToString();

                                    Session[CommonConstantNames.POLICYUID] = Session["PolicyID"];
                                    Session[CommonConstantNames.USERUID] = Session["USERUID_LOGIN"];
                                    Session[CommonConstantNames.USERNAME] = Session["USERNAME_LOGIN"];
                                    Session[CommonConstantNames.NAME] = Session["NAME_LOGIN"];
                                    Session[CommonConstantNames.SUBOFFICEUID] = Session["SUBOFFICEUID_LOGIN"];
                                    Session[CommonConstantNames.ISLOGGEDIN] = Session["ISLOGGEDIN_LOGIN"];
                                    Session[CommonConstantNames.LOGGEDINDATE] = Session["LOGGEDINDATE_LOGIN"];
                                    Response.Redirect("~/ChangePassword/ChangePassword.aspx");
                                }

                                if (ds.Tables[0].Rows[0]["ApplicationAccessFlag"].ToString() == "C")
                                {
                                    // createa a new GUID and save into the session
                                    string guid = Guid.NewGuid().ToString();
                                    Session["AuthToken"] = guid;
                                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                                    //Added by Karunakar on 28-04-2016 START
                                    Session["IsTTSL"] = ds.Tables[0].Rows[0]["TTSLFlag"].ToString();
                                    //Session["IsTTSL"] = "N";
                                    Session["USERUID_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.USERUID].ToString();
                                    Session["USERNAME_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.USERNAME].ToString();
                                    Session["NAME_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.NAME].ToString();
                                    Session["SUBOFFICEUID_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.SUBOFFICEUID].ToString();
                                    Session["ISLOGGEDIN_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.ISLOGGEDIN].ToString();
                                    Session["LOGGEDINDATE_LOGIN"] = ds.Tables[0].Rows[0][CommonConstantNames.LOGGEDINDATE].ToString();
                                    Session["PolicyID"] = ds.Tables[0].Rows[0][CommonConstantNames.POLICYUID].ToString();

                                    Session[CommonConstantNames.POLICYUID] = Session["PolicyID"];
                                    Session[CommonConstantNames.USERUID] = Session["USERUID_LOGIN"];
                                    Session[CommonConstantNames.USERNAME] = Session["USERNAME_LOGIN"];
                                    Session[CommonConstantNames.NAME] = Session["NAME_LOGIN"];
                                    Session[CommonConstantNames.SUBOFFICEUID] = Session["SUBOFFICEUID_LOGIN"];
                                    Session[CommonConstantNames.ISLOGGEDIN] = Session["ISLOGGEDIN_LOGIN"];
                                    Session[CommonConstantNames.LOGGEDINDATE] = Session["LOGGEDINDATE_LOGIN"];
                                    Response.Redirect("~/ChangePassword/ChangePassword_cr.aspx");
                                }
                            }
                        }
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert('SQL: Username & Password are wrong');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert('LDAP: Username & Password are wrong');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert('LDAP: Server is not available.');", true);
            }
        }
        catch (SqlException ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert(\"" + ex.Message + "\");", true);
        }
    }

    /*
     * Checking for Public IP addrres validation
     * Added by Karunakar : 25/11/2016
     * start
     */
    private bool IsAegisNetwork(string[] IpAddress)
    {
        try
        {
            string remoteIpAddress = string.Empty;
            //string Address = string.Empty;

            foreach (string strIpAddress in IpAddress)
            {
                remoteIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (String.IsNullOrEmpty(remoteIpAddress))
                {

                    remoteIpAddress = Request.ServerVariables["REMOTE_ADDR"];

                }
                // Address += remoteIpAddress + "," + strIpAddress + ";";
                //remoteIpAddress = "114.31.251.0";

                if (remoteIpAddress.Trim() == strIpAddress.Trim())
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert(\"" + remoteIpAddress + "\");", true);
                    //Response.Write("<em>Your Remote IP Address is:  " + remoteIpAddress + "</em><br />");
                    return false;
                }
                //Response.Write("<em>Your Remote IP Address is:  " + strIpAddress.Trim() + "</em><br />");

            }
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert(\"" + remoteIpAddress + "\");", true);
            //Response.Write("<em>Your Remote IP Address is:  " + remoteIpAddress + "</em><br />");
            return true;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "alert(\"" + ex.Message + "\");", true);
            return false;
        }
    }
    /*END*/
}
