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
using System.IO;
using System.Data.SqlClient;

namespace PACE.CreditLifeInformation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string filename = string.Empty;

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void OnLnkUpload_Click(object sender, EventArgs e)
        {
            filename = Path.GetFileName(fileUpload1.PostedFile.FileName);

            fileUpload1.SaveAs(Server.MapPath("~/Files_LS/" + filename));

            Response.Write("File uploaded sucessfully.");
            lblFilename.Text = "~/Files_LS/" + fileUpload1.FileName;
        }

        // To download uplaoded file
        protected void OnLnkDownload_Click(object sender, EventArgs e)
        {
            if (lblFilename.Text != string.Empty)
            {
                if (lblFilename.Text.EndsWith(".txt"))
                {
                    Response.ContentType = "application/txt";
                }
                else if (lblFilename.Text.EndsWith(".pdf"))
                {
                    Response.ContentType = "application/pdf";
                }
                else if (lblFilename.Text.EndsWith(".docx"))
                {
                    Response.ContentType = "application/docx";
                }
                else
                {
                    Response.ContentType = "image/jpg";
                }

                string filePath = lblFilename.Text;

                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                Response.TransmitFile(Server.MapPath(filePath));
                Response.End();
            }
        }
    }
}
