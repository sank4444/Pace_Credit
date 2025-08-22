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

public partial class PolicyDocuments : System.Web.UI.Page
{
    string UserUID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[CommonConstantNames.USERUID] != null)
        {
            UserUID = Session[CommonConstantNames.USERUID].ToString();
           
        }
        else
        {
            Response.Redirect("~/LoginPage.aspx", true);
        }
        if (!IsPostBack)
        {
            CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "PolicyDocuments.aspx");
        }
    }
}
