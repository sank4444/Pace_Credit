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
using Microsoft.Reporting.WebForms;
using GlimpsBAL;
using System.IO;
using System.Drawing;

public partial class PolicyInformation_UserManual : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Redirect("~/ClaimDocuments/Vendor_TALIC_Group Life_Portal_PACE_User_Manual-Vr.1_PS_Final.pdf");
        //string script = "<script type='text/javascript'>if(window.open)window.open('../ClaimDocuments/Vendor_TALIC_Group Life_Portal_PACE_User_Manual-Vr.1_PS_Final.pdf','_blank');else alert('IE 11 not compatible') </script>";
    }

    
}
