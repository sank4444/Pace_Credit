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

public partial class PolicyInformation : System.Web.UI.Page
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
            //((HtmlGenericControl)Master.FindControl("lblmarquee")).InnerText = "GOOD DELIVERS EVERYTHING LITTLE PROMISE IT MAKES"; 
            if (!IsPostBack)
            {

                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "PolicyInformation.aspx");
                ((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation")).Attributes.Add("class", "tab_link_active");

                policyInformationBAL = new PolicyInformationBAL();
                dt = policyInformationBAL.PolicyInformationDetails(UserUID, subOfficeUID);


                if (dt != null)
                    if (dt.Rows.Count > 0)
                    {
                        /*Policy Info*/
                        // lblProductName.Text = dt.Rows[0]["ProductName"].ToString();
                        lblClient.Text = "&nbsp;" + dt.Rows[0]["ClientName"].ToString();
                        lblPlan.Text = "&nbsp; " + dt.Rows[0]["ClientUnitName"].ToString();
                        lblPolicyNo.Text = "&nbsp; " + dt.Rows[0]["PolicyNumber"].ToString();
                        //lblProductType.Text = dt.Rows[0]["ProductType"].ToString();
                        lblPolicyStaus.Text = "&nbsp; " + dt.Rows[0]["PolicyStatus"].ToString();
                        lblInceptionDate.Text = "&nbsp; " + dt.Rows[0]["InceptionDate"].ToString();
                        lblAnniversaryDate.Text = "&nbsp; " + dt.Rows[0]["AnniversaryDate"].ToString();
                        // lblPolicyDate.Text = dt.Rows[0]["PolicyDate"].ToString();
                        //lblTerminationDate.Text = dt.Rows[0]["TerminationDate"].ToString();
                        //lblProductType.Text = dt.Rows[0]["ProductType"].ToString();
                        // lblPolicyDate.Text = dt.Rows[0]["PolicyDate"].ToString();
                        //  lblPolRenewal.Text = dt.Rows[0]["RenewalDate"].ToString();
                        lblminEntryAge.Text = "&nbsp; " + dt.Rows[0]["MinEntryAge"].ToString();
                        lblMaxEntryAge.Text = "&nbsp; " + dt.Rows[0]["MaxEntryAge"].ToString();
                        //  lblMinSum.Text = "&nbsp; " + dt.Rows[0]["MinSum_Assured"].ToString();
                        // lblMaxSum.Text = "&nbsp; " + dt.Rows[0]["MaxSum_Assured"].ToString();
                        lblSubOfficeCode.Text = "&nbsp; " + dt.Rows[0]["ClientUnitCode"].ToString();
                        lblERRFor.Text = "&nbsp; " + dt.Rows[0]["ERRFormulaName"].ToString();
                        lblProducName.Text = "&nbsp; " + dt.Rows[0]["ProductName"].ToString();
                        lblProductUINNo.Text = "&nbsp; " + dt.Rows[0]["UIN_No"].ToString();
                        lblServiceManager.Text = "&nbsp; " + dt.Rows[0]["Service_ManagerName"].ToString();
                        // lblSourceBusiness.Text = "&nbsp; " + dt.Rows[0]["AgentTypeName"].ToString();
                        lblAB.Text = "&nbsp; " + dt.Rows[0]["AgentName"].ToString();
                        lblModeofPolicy.Text = "&nbsp; " + dt.Rows[0]["PremiumFrequencyName"].ToString();
                        lblPolicyYear.Text = "&nbsp; " + dt.Rows[0]["PolicyYear"].ToString();
                        lblNumberofmembercovered.Text = "&nbsp; " + dt.Rows[0]["Numberofmembercovered"].ToString();
                    }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }
}
