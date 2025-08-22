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

public partial class OnlineRequest_OnlineRequest : System.Web.UI.Page
{
    string UserUID = string.Empty;
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
            CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "OnlineRequest.aspx");
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuAttachment.HasFile)
        {
            try
            {
                HttpPostedFile file = (HttpPostedFile)fuAttachment.PostedFile;
                if (file.ContentLength > 0 && (file.ContentType.Contains("image") || file.ContentType.Contains("excel") || file.ContentType.Contains("powerpoint")))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successfully", "alert('" + Resources.Resource.successfulFileUplod.ToString() + file.ContentType.ToString() + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
    }
}
