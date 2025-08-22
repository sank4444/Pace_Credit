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

namespace PACE.CrediteLifeInformation
{
    public partial class CreditLifeInformation : System.Web.UI.Page
    {
        PolicyInformationBAL policyInformationBAL = null;
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
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
                    Response.Redirect("~/LoginPage.aspx");
                }
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "CreditLifeInformation.aspx");
                    //((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation1")).Attributes.Add("class", "tab_link_active");  //commented by Sanket on 16/5/2025

                    policyInformationBAL = new PolicyInformationBAL();
                    dt = policyInformationBAL.PolicyInformationDetails_cr(UserUID, subOfficeUID);

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            lblClient.Text = "&nbsp;" + dt.Rows[0]["ClientName"].ToString();
                            lblPolicyNo.Text = "&nbsp; " + dt.Rows[0]["PolicyNumber"].ToString();
                            lblPolicyStaus.Text = "&nbsp; " + dt.Rows[0]["PolicyStatus"].ToString();
                            lblInceptionDate.Text = "&nbsp; " + dt.Rows[0]["InceptionDate"].ToString();
                            lblAnniversaryDate.Text = "&nbsp; " + dt.Rows[0]["AnniversaryDate"].ToString();
                            lblminEntryAge.Text = "&nbsp; " + dt.Rows[0]["MinEntryAge"].ToString();
                            lblMaxEntryAge.Text = "&nbsp; " + dt.Rows[0]["MaxEntryAge"].ToString();
                            lblClientCode.Text = "&nbsp; " + dt.Rows[0]["ClientCode"].ToString();
                            lblProducName.Text = "&nbsp; " + dt.Rows[0]["ProductName"].ToString();
                            lblProductUINNo.Text = "&nbsp; " + dt.Rows[0]["UIN_No"].ToString();
                            lblServiceManager.Text = "&nbsp; " + dt.Rows[0]["Service_ManagerName"].ToString();
                            lblAB.Text = "&nbsp; " + dt.Rows[0]["AgentName"].ToString();
                            lblModeofPolicy.Text = "&nbsp; " + dt.Rows[0]["PremiumFrequencyName"].ToString();
                            lblNumberofmembercovered.Text = "&nbsp; " + dt.Rows[0]["Numberofmembercovered"].ToString();
                            lblSegmentType.Text = "&nbsp; " + dt.Rows[0]["Segments"].ToString();
                            lblRateInterest.Text = "&nbsp; " + dt.Rows[0]["Rate_Interest"].ToString();
                            Session["PolicyUID"] = dt.Rows[0]["PolicyUID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
    }
}
