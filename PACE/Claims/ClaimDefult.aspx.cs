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

namespace PACE.Claims
{
    public partial class ClaimDefult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlTableCell)this.Page.Master.FindControl("Claims")).Attributes.Add("class", "active");
        }
    }
}
