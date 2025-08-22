using System;
using System.Data;
using System.Web;
using System.Web.UI;
using GlimpsBAL;
using GlimpsDAL;
using GlimpsDAL.Common;
using System.Web.UI.HtmlControls;

public partial class MemberInformation_MemberInformation : System.Web.UI.Page
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
                Response.Redirect("~/LoginPage.aspx");
            }
            ((HtmlTableCell)this.Page.Master.FindControl("MemberInformation")).Attributes.Add("class", "active");
            if (!IsPostBack)
            {
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "MemberInformation.aspx");
                gvMembeInfo.Visible = false;
                lblResult.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        MemberInfoBAL memberInfoBAL = null;
        try
        {
            lblResult.Visible = false;
            memberInfoBAL = new MemberInfoBAL();
            DataSet ds = memberInfoBAL.GetMemberInfo(Convert.ToInt32(Session[CommonConstantNames.USERUID].ToString()), Convert.ToString(txtCoiNo.Text), Convert.ToString(txtName.Text));



            //For Bind Grid 
            ViewState["DATA"] = ds.Tables[0];
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //creating for MemberInfopopup page data  
                    Session[CommonConstantNames.POLICYUID] = ds.Tables[0].Rows[0][CommonConstantNames.POLICYUID];
                    tdGrid.Visible = true;
                    gvMembeInfo.Visible = true;
                    BindGrid();
                }
                else
                {
                    Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], gvMembeInfo);
                    tdGrid.Visible = true;
                    gvMembeInfo.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionFramework.WriteErrorLogs("Message: " + ex.Message + "\n StackTrace: " + ex.StackTrace);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }

    }
    protected void gvMembeInfo_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvMembeInfo.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    private void BindGrid()
    {

        if ((DataTable)ViewState["DATA"] != null)
        {
            if (((DataTable)ViewState["DATA"]).Rows.Count > 0)
            {
                gvMembeInfo.DataSource = (DataTable)ViewState["DATA"];
                gvMembeInfo.DataBind();
            }
            else
            {
                Masters_MenuMasterPage.ShowNoResultFound((DataTable)ViewState["DATA"], gvMembeInfo);
                gvMembeInfo.DataBind();
            }
        }
    }


    protected void gvMembeInfo_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Session[CommonConstantNames.POLICYMEMBERUID] = e.CommandArgument.ToString();
        }
    }


}
