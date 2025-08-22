using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class LongRunningProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(Session["divDisplay"].ToString()))
        //{
        //    // Padding to circumvent IE's buffer.
        //    Response.Write(new string('*', 256));
        //    Response.Flush();
        //    if (Convert.ToString(Session["divDisplay"]) == "Updating")
        //    {
        //        // Initialization
        //        UpdateProgress("Processing....");
                
        //    }
        //    if (Session["divDisplay"] == "Confirm")
        //    {
        //        // Gather data.
        //        UpdateProgress("Updating...");
                
        //    }
        //    if (Session["divDisplay"] == "Job")
        //    {
        //        // Process data.
        //        UpdateProgress("Job is running...");
                
        //    }
        //    if (Session["divDisplay"] == "MemberUpload")
        //    {
        //        // Clean up.
        //        UpdateProgress("Member Upload is uploading...");
                
        //    }
        //    if (Session["divDisplay"] == "BillIssue")
        //    {
        //        // All finished!
        //        UpdateProgress("Bill Issuing...");
        //    }
        //    if (Session["divDisplay"] == "Billgenerating")
        //    {
        //        // All finished!
        //        UpdateProgress("Bill generating...");

        //        UpdateProgress("Bill generated!");
        //    }
            
        //}
    }
    protected void UpdateProgress(string Message)
    {
        // Write out the parent script callback.
        Response.Write(String.Format("<script type=\"text/javascript\">parent.UpdateProgress('{0}');</script>", Message));
        // To be sure the response isn't buffered on the server.    
        Response.Flush();
    }
}
