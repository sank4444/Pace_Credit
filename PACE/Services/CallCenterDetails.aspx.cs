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

namespace PACE.Services
{
    public partial class CallCenterDetails : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        DataSet ds = null;
        ServiceBAL objServiceBAL = null;
        string SRNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
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
            objServiceBAL = new ServiceBAL();
            ds = new DataSet();
            
            if (!IsPostBack)
            {
                if (Request.QueryString.Count>0)
                {
                    SRNumber = Request.QueryString["SRNo"].ToString();
                }
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "ServiceList.aspx");
                ds = objServiceBAL.GetServiceList(UserUID, "CD", SRNumber);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtComplaint.Text = ds.Tables[0].Rows[0]["Query"].ToString();
                        txtComplaintName.Text = ds.Tables[0].Rows[0]["SRName"].ToString();
                        txtQueresStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                    }
                    
                }
            }
        }
    }
}
