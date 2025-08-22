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

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        if (Session[CommonConstantNames.USERUID] != null)
        {
            UserUID = Session[CommonConstantNames.USERUID].ToString();
            subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
        }
        else
        {
            Session[CommonConstantNames.USERUID] = 0;
            Response.Expires = -1;
            Response.CacheControl = "no-cache";
            Session.Clear();
            Session.Abandon();

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            Session.RemoveAll();
           // Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["LoginPageURL"].ToString(), false);
            Response.Redirect("~/LoginPage.aspx",false);
        }
    }
}
