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

namespace PACE.Claims
{
    public partial class ClaimFAQ : System.Web.UI.Page
    {
        string userUID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[CommonConstantNames.USERUID] != null)
            {
                userUID = Session[CommonConstantNames.USERUID].ToString();
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }
            ((HtmlTableCell)this.Page.Master.FindControl("Claims")).Attributes.Add("class", "active");
            if (!IsPostBack)
            {
                CommonMethods.InsertingPageInfo("I", userUID, "ClaimFAQ.aspx");
            }
            Label uniqueReference = (Label)Master.FindControl("uniqueReference");
            if (uniqueReference!=null)
            {
                uniqueReference.Visible = false;
            }
        }
    }
}
