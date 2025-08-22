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
using System.Threading;

namespace PACE
{
    public partial class NewDefault : System.Web.UI.Page
    {
        //Added by Karunakar on 20-05-2016 START
        protected void Page_PreInit(object sender, EventArgs e)
        {
            TTSLInput.Value = Session["IsTTSL"].ToString();
        }
        //END
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[CommonConstantNames.USERUID] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {

                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    //Label labelDisplay = (Label)UpdateProgress1.FindControl("labelDisplay");
                    //if (labelDisplay != null)
                    //{
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "SessionEnd", "alert('Your Session is Expire please login again');", true);
                    //  labelDisplay.Text = "Your Session is Expire please login again";
                    Thread.Sleep(2000);
                    //}
                    Response.Redirect("~/LoginPage.aspx", true);
                }
            }
            else
            {
                //Label labelDisplay = (Label)UpdateProgress1.FindControl("labelDisplay");
                //if (labelDisplay != null)
                //{
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "SessionEnd", "alert('Your Session is Expire please login again');", true);
                //  labelDisplay.Text = "Your Session is Expire please login again";
                Thread.Sleep(2000);
                //}
                Response.Redirect("~/LoginPage.aspx", true);

            }
        }

        protected void imgLogout_Click(object sender, ImageClickEventArgs e)
        {
            CommonMethods.InsertingPageInfo("I", Convert.ToString(Session[CommonConstantNames.USERUID]), "Logout.aspx");
            
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
            //if (Request.Cookies["mycookie"] != null)
            //{
            //    Response.Cookies["mycookie"].Value = string.Empty;
            //    Response.Cookies["mycookie"].Expires = DateTime.Now.AddMonths(-20);
            //}
            Session[CommonConstantNames.USERUID] = string.Empty;
            Session[CommonConstantNames.USERNAME] = string.Empty;
            Session[CommonConstantNames.NAME] = string.Empty;
            Session[CommonConstantNames.SUBOFFICEUID] = string.Empty;
            Session[CommonConstantNames.ISLOGGEDIN] = string.Empty;
            Session[CommonConstantNames.LOGGEDINDATE] = string.Empty;
            Session["USERUID_LOGIN"] = string.Empty;
            Session["USERNAME_LOGIN"] = string.Empty;
            Session["NAME_LOGIN"] = string.Empty;
            Session["SUBOFFICEUID_LOGIN"] = string.Empty;
            Session["ISLOGGEDIN_LOGIN"] = string.Empty;
            Session["LOGGEDINDATE_LOGIN"] = string.Empty;

            
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            // Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["LoginPageURL"].ToString(), false);
            Response.Redirect("~/LoginPage.aspx", true);
        }
    }
}
