using System;
using System.Data;
using System.Web;
using GlimpsBAL;
using GlimpsDAL;
using System.Web.UI;
using System.Web.UI.WebControls;
using GlimpsDAL.Common;
using System.Web.UI.HtmlControls;

public partial class ContactInformation_CntactInformation : System.Web.UI.Page
{

    #region Private variables
    string UserUID = string.Empty;
    string subOfficeUID = string.Empty;
    DataSet dsInfo = null;
    #endregion

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
            ((HtmlTableCell)this.Page.Master.FindControl("PolicyInformation")).Attributes.Add("class", "tab_link_active");
            if (!IsPostBack)
            {
                CommonMethods.InsertingPageInfo("I", UserUID, "ContactInformation.aspx");
                dsInfo = GetInformationContact(Convert.ToInt32(UserUID));
                BindingGrid();
            }
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    #region Functions
    /*Binding Grigview*/
    private void BindingGrid()
    {
        try
        {
            if (dsInfo != null)
            {
                if (dsInfo.Tables[0].Rows.Count > 0)
                {
                    gvContactInfo.DataSource = dsInfo.Tables[1];
                    gvContactInfo.DataBind();
                    ViewState["DATA"] = dsInfo.Tables[1];
                }
                else
                {
                    Masters_MenuMasterPage.ShowNoResultFound(dsInfo.Tables[0], gvContactInfo);
                    gvContactInfo.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }
    /*Getting data from Database */
    private DataSet GetInformationContact(int UserUID)
    {
        DataSet ds = null;
        try
        {
            ds = new DataSet();
            ContactInfoBAL contactInfoBAL = new ContactInfoBAL();
            ds = contactInfoBAL.GetContactInfo(UserUID);

        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
        return ds;
    }
    #endregion

    protected void gvContactInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["DATA"] != null)
        {
            gvContactInfo.PageIndex = e.NewPageIndex;
            gvContactInfo.DataSource = (DataTable)ViewState["DATA"];
            gvContactInfo.DataBind();

        }
    }
}
