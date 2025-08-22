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

public partial class PolicyInformation_PremiumRates : System.Web.UI.Page
{
    string UserUID = string.Empty;
    string subOfficeUID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session[CommonConstantNames.USERUID] != null)
            {
                UserUID = Session[CommonConstantNames.USERUID].ToString();
                subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }
            if (!IsPostBack)
            {
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "PremiumRates.aspx");
                subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                BindGrid(UserUID, subOfficeUID);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "New Window", "javascript:DataTableInGrid()", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    private void BindGrid(string UserId, string subofficeUId)
    {
        PolicyInformationBAL policyInformationBAL = new PolicyInformationBAL();
        DataTable dtPolicyInformation = policyInformationBAL.PremiumRates(UserId);
        if (dtPolicyInformation != null)
        {
            if (dtPolicyInformation.Rows.Count > 0)
            {
                gvPremiumRates.DataSource = dtPolicyInformation;
                gvPremiumRates.DataBind();
                gvPremiumRates.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvPremiumRates.UseAccessibleHeader = true;
                
            }
            else
            {
                BaseClass.ShowNoResultFound(dtPolicyInformation, gvPremiumRates);
            }
        }
    }
    protected void gvPremiumRates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "VIEWRATECODE":
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "New Window", "window.open('../Reports/PremiumRateReport.aspx?RateCode=" + e.CommandArgument.ToString() + "','PolicyPremiumRateCode','location=0,status=1,scrollbars=1,resizable=1,width=900,height=600, left=70');", true);
                break;
        }
    }
}
