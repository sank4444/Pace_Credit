using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using GlimpsDAL;

namespace PACE.ContactUs
{
    public partial class Contactus : System.Web.UI.Page
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
            ((HtmlTableCell)this.Page.Master.FindControl("Miscellaneous")).Attributes.Add("class", "active");
            if (!IsPostBack)
            {
                CommonMethods.InsertingPageInfo("I", UserUID, "ContactUs.aspx");
            }
        }
    }
}
