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
using System.Data.OleDb;



namespace PACE.CreditLifeInformation
{
    public partial class Submission : System.Web.UI.Page
    {
        string filename = string.Empty;
        OleDbConnection Econ;

        string file_path, constr, Query;

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void ExcelConn(string FilePath)
        {
            //constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 12.0;Persist Security Info=False";
            //constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);

            constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
               FilePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            Econ = new OleDbConnection(constr);

        }

        private void ReadExcelRecords(string FilePath)
        {

            //constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);
            //Econ = new OleDbConnection(constr);

            //if (Econ.State == ConnectionState.Closed)
            //{ 
            //string fileLocation = Server.MapPath("~/Content/") + Request.Files[0].FileName;
            ExcelConn(Server.MapPath("~/Files_LS/") + fileUpload1.FileName);

            Query = string.Format("Select PolicyNumber,PolicyName FROM [{0}]", "Sheet1$");
            //Query = string.Format("Select PolicyNumber,PolicyName FROM Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);

            oda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            Econ.Close();
            //}
            //else
            //{
            //    ExcelConn(FilePath);

            //    //Query = string.Format("Select PolicyNumber,PolicyName FROM [{0}]", "Sheet1$");
            //    Query = string.Format("Select PolicyNumber,PolicyName FROM Sheet1$");
            //    OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            //    Econ.Open();

            //    DataSet ds = new DataSet();
            //    OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);

            //    oda.Fill(ds);
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //    Econ.Close();

            //}

        }
        protected void OnLnkUpload_Click(object sender, EventArgs e)
        {

            if (Path.GetFileName(fileUpload1.PostedFile.FileName) != "")
            {
                filename = Path.GetFileName(fileUpload1.PostedFile.FileName);
                file_path = "~/Files_LS/" + fileUpload1.FileName; //System.IO.Path.GetFullPath(Server.MapPath("~/Files_LS/"));
                Session["file_path"] = file_path.ToString();
                ReadExcelRecords(file_path);


                fileUpload1.SaveAs(Server.MapPath("~/Files_LS/" + filename));
                Response.Write("File uploaded sucessfully.");
                // lblFilename.Text = "~/Files_LS/" + fileUpload1.FileName;
            }
            else
            {
                lblFilename.Text = "Please select exl file for upload";
            }

        }

        // To download uplaoded file
        protected void OnLnkDownload_Click(object sender, EventArgs e)
        {
            //if (lblFilename.Text == "Please select exl file for upload" && lblFilename.Text == "")//string.Empty
            //{
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
                Response.TransmitFile(Server.MapPath(Session["file_path"].ToString()));// filePath 
                Response.End();
            //}
            //else
            //{
            //    lblFilename.Text = "File uploaded then download";
            //}

        }
    }
}
