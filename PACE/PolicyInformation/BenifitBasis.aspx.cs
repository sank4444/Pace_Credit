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

public partial class PolicyInformation_BenifitBasis : System.Web.UI.Page
{
    string UserUID = string.Empty;
    PolicyInformationBAL objPolicyInformationBAL = null;

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
        try
        {
            if (!IsPostBack)
            {
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "BenfitBasis.aspx");
                objPolicyInformationBAL = new PolicyInformationBAL();
                DataSet ds = objPolicyInformationBAL.GetBenifitBasis(UserUID, "", "S");
                BindGrid(ds);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvBenifitBasis_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "view")
            {
                objPolicyInformationBAL = new PolicyInformationBAL();
               
                DataSet dsDisplay = objPolicyInformationBAL.GetBenifitBasis(UserUID, Convert.ToString(e.CommandArgument), "List");
                if (dsDisplay != null)
                {
                    if (dsDisplay.Tables[0].Rows.Count > 0)
                    {
                        gvDisplay.DataSource = dsDisplay;
                        ViewState["DATASETDis"] = dsDisplay;
                        gvDisplay.DataBind();
                        trViewGrid.Visible = true;
                        gvDisplay.Visible = true;
                    }
                    else
                    {
                        ViewState["DATASETDis"] = null;
                        trViewGrid.Visible = false;
                        gvDisplay.Visible = false;
                        Masters_MenuMasterPage.ShowNoResultFound(dsDisplay.Tables[0], gvDisplay);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void BindGrid(DataSet dsGrid)
    {
        if (dsGrid != null)
        {
            gvBenifitBasis.DataSource = dsGrid;
            gvBenifitBasis.DataBind();
            ViewState["DATASET"] = dsGrid;
        }
        else
        {
            ViewState["DATASET"] = null;
            Masters_MenuMasterPage.ShowNoResultFound(dsGrid.Tables[0], gvBenifitBasis);
        }
    }

    protected void gvDisplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["DATASETDis"] != null)
        {
            gvDisplay.PageIndex = e.NewPageIndex;
            gvDisplay.DataSource = (DataSet)ViewState["DATASETDis"];
            gvDisplay.DataBind();
        }
    }

    protected void gvBenifitBasis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["DATASET"]!=null)
        {
            gvBenifitBasis.PageIndex = e.NewPageIndex;
            gvBenifitBasis.DataSource = (DataSet)ViewState["DATASET"];
            gvBenifitBasis.DataBind();
        }
    }
}
