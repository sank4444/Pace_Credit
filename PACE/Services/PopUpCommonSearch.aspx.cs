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
using Resources;
using GlimpsDAL;

namespace PACE.Services
{
    public partial class PopUpCommonSearch : System.Web.UI.Page
    {
        ServiceBAL objServiceBAL = new ServiceBAL();
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        string COI = string.Empty;
        string DDLFirst = string.Empty;
        string DDlSecond = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    // string[] split = Request.QueryString.ToString().Split(',');
                    //COI = Request.QueryString["COI"].ToString();
                    //DDLFirst = Request.QueryString["DDLFirst"].ToString();
                    //DDlSecond = Request.QueryString["DDlSecond"].ToString();
                }
                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();

                    //TTSL Change
                    //Added by Karunakar on 28-04-2016 START
                    if (Session["IsTTSL"].ToString().Trim().ToLower() == "y")
                    {
                        ddlSearch.Items.FindByValue("MobileNo").Enabled = true;
                        ddlSearch.Items.FindByValue("MobileNo").Selected = true;
                        ddlSearch.Enabled = false;
                    }
                    else
                    {
                        ddlSearch.Items.FindByValue("MobileNo").Enabled = false;
                        ddlSearch.Enabled = true;
                    }
                    //END
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx", true);
                }
                if (!Page.IsPostBack)
                {
                    CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "PopUpCommonSearch.aspx");
                    DataSet ds = objServiceBAL.GetServiceRequestCOI(UserUID, txtSearch.Text, ddlSearch.SelectedValue.ToString(), "COISEARCH");
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GVpopupCOI.DataSource = ds;
                            ViewState["Data"] = ds;
                            GVpopupCOI.DataBind();
                        }
                        else
                        {
                            Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], GVpopupCOI);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Resource.WebResource, "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }

        protected void GVpopupCOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if ((DataSet)ViewState["Data"] != null)
            {
                GVpopupCOI.PageIndex = e.NewPageIndex;
                GVpopupCOI.DataSource = (DataSet)ViewState["Data"];
                GVpopupCOI.DataBind();
            }
        }



        protected void GVpopupCOI_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GVpopupCOI.SelectedRow;
            string b = row.Cells[1].Text;
            string c = row.Cells[2].Text;

        }

        protected void gvrecords_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //  string path;
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("imgSelect");
               // GridViewRow row = (GridViewRow)GVpopupCOI.Rows[Convert.ToInt32(lnkbtnresult.CommandArgument)];

                string COI = ((Label)e.Row.FindControl("lblCOI")).Text.ToString();
                string InsuredName = ((Label)e.Row.FindControl("lblInsuredName")).Text.ToString();

                if (lnkbtnresult.CommandName == "select")
                {
                    // path = "../Forms/AddIncidentRequest.aspx?COI=" + COI + "&DDLFirst=" + Request.QueryString["DDLFirst"].ToString() + "&DDlSecond=" + Request.QueryString["DDlSecond"].ToString();
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return closeWindow('" + COI + "&DDLFirst=" +"&InsuredName=" + InsuredName + "')");
                }
            }

        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            DataSet ds = objServiceBAL.GetServiceRequestCOI(UserUID, txtSearch.Text, ddlSearch.SelectedValue.ToString(), "COISEARCH");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVpopupCOI.DataSource = ds;
                    ViewState["Data"] = ds;
                    GVpopupCOI.DataBind();
                }
                else
                {
                    Masters_MenuMasterPage.ShowNoResultFound(ds.Tables[0], GVpopupCOI);
                }
            }
        }


    }
}
