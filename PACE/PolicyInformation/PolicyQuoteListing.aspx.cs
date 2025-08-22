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

namespace PACE.PolicyInformation
{
    public partial class PolicyQuoteListing : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        PolicyInformationBAL objPolicyInformation = null; 
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
                objPolicyInformation = new PolicyInformationBAL();
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "PolicyQuoteListing.aspx");
                DataTable dt = objPolicyInformation.GetPolicyQuoteListing(UserUID, "S");
                if (dt != null)
                {
                    ViewState["DATA"] = dt;
                    gvPolicyQuoteList.DataSource = dt;
                    gvPolicyQuoteList.DataBind();
                }
                

            }
        }

        protected void grdPolicyQuoteList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["DATA"]!=null)
            {
                gvPolicyQuoteList.PageIndex = e.NewPageIndex;
                gvPolicyQuoteList.DataSource = (DataTable)ViewState["DATA"];
                gvPolicyQuoteList.DataBind();
            }
        }
    }
}
