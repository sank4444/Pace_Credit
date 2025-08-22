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
using System.Threading;


namespace PACE.Masters
{
    public partial class MenuMasterPage_Cr : System.Web.UI.MasterPage
    {
        public HtmlGenericControl headerMaster
        {
            get { return MasterHeader; }
        }
        public HtmlGenericControl InfoBarMaster
        {
            get { return MasterInfoBar; }
        }
        public HtmlGenericControl FooteMaster
        {
            get { return MasterFooter; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[CommonConstantNames.USERUID] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                //Added by Karunakar on 28-04-2016 START
                if (Session["IsTTSL"].ToString().ToUpper() == "Y")
                {
                    //commented by Sanket on 16/5/2025
                    //BillEnquiry1.Visible = false;
                    //divPolicyInfo1.Visible = false;
                    //Miscellaneous1.Visible = false;
                    //---------------------------------//
                }
                //END
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Label labelDisplay = (Label)UpdateProgress1.FindControl("labelDisplay");
                    if (labelDisplay != null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "SessionEnd", "alert('Your Session is Expire please login again');", true);
                        labelDisplay.Text = "Your Session is Expire please login again";
                        Thread.Sleep(1000);
                    }
                    Response.Redirect("~/LoginPage.aspx", true);
                }
                else
                {
                    DataTable dtBanner = CommonMethods.DisplayMessageForBanner_cr(Session[CommonConstantNames.USERUID].ToString());
                    //lblmarquee.InnerText = dtBanner.Rows.Count > 0 ? dtBanner.Rows[0]["MessageDisplay"].ToString() : "GOOD PROTECTS EVERYTHING THAT\'S GOOD IN LIFE";   //commented by sanket on 16/5/2025
                    lblPolicyNo.Text = dtBanner.Rows.Count > 0 ? dtBanner.Rows[0]["PolicyNumber"].ToString() : "";
                    Session["PolicyNo"] = lblPolicyNo.Text;
                    //Session["PolicyUID"] = dtBanner.Rows.Count > 0 ? dtBanner.Rows[0]["PolicyUID"].ToString() : "";

                    lblSubOfficeCode.Text = dtBanner.Rows.Count > 0 ? dtBanner.Rows[0]["ClientUnitCode"].ToString() : "";
                    lblSubOfficeName.Text = dtBanner.Rows.Count > 0 ? dtBanner.Rows[0]["ClientUnitName"].ToString() : "";

                }

                //Added by Sanket on 1/8/2025
                if (Session["USERNAME_LOGIN"] != null)
                {
                    lblusername.Text = Session["USERNAME_LOGIN"].ToString();
                }
                //-------------------------------------------
            }
            else
            {
                Label labelDisplay = (Label)UpdateProgress1.FindControl("labelDisplay");
                if (labelDisplay != null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "SessionEnd", "alert('Your Session is Expire please login again');", true);
                    labelDisplay.Text = "Your Session is Expire please login again";
                    Thread.Sleep(1000);
                }
                Response.Redirect("~/LoginPage.aspx", true);

            }

        }


        public static void ShowNoResultFound(DataTable source, GridView gv)
        {
            try
            {
                source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable
                // Bind the DataTable which contain a blank row to the GridView
                gv.DataSource = source;
                gv.DataBind();
                // Get the total number of columns in the GridView to know what the Column Span should be
                int columnsCount = gv.Columns.Count;
                gv.Rows[0].Cells.Clear();// clear all the cells in the row
                gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                //You can set the styles here
                gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                gv.Rows[0].Cells[0].Font.Bold = true;
                //set No Results found to the new added cell
                gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            CommonMethods.InsertingPageInfo("I", Convert.ToString(Session[CommonConstantNames.USERUID]), "Logout.aspx");

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }
            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }
            //if (Request.Cookies["mycookie"] != null)
            //{
            //    Response.Cookies["mycookie"].Value = string.Empty;
            //    Response.Cookies["mycookie"].Expires = DateTime.Now.AddMonths(-20);
            //}
            Session[CommonConstantNames.USERUID] = string.Empty;
            Session[CommonConstantNames.USERNAME] = string.Empty;
            Session[CommonConstantNames.NAME] = string.Empty;
            Session[CommonConstantNames.SUBOFFICEUID] = string.Empty;
            Session[CommonConstantNames.POLICYUID] = string.Empty; //LS
             
            Session[CommonConstantNames.ISLOGGEDIN] = string.Empty;
            Session[CommonConstantNames.LOGGEDINDATE] = string.Empty;
            Session["USERUID_LOGIN"] = string.Empty;
            Session["USERNAME_LOGIN"] = string.Empty;
            Session["NAME_LOGIN"] = string.Empty;
            Session["SUBOFFICEUID_LOGIN"] = string.Empty;
            Session["ISLOGGEDIN_LOGIN"] = string.Empty;
            Session["LOGGEDINDATE_LOGIN"] = string.Empty;
            Session["IsTTSL"] = string.Empty;

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            // Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["LoginPageURL"].ToString(), false);
            Response.Redirect("~/LoginPage.aspx", true);
        }
    }
}
