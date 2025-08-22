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
using GlimpsDAL;

namespace PACE.CustomerSatisfactionSurvey
{
    public partial class CutomerSatisfacation_cr : System.Web.UI.Page
    {
        int UserUID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[CommonConstantNames.USERUID] != null)
            {
                UserUID = Convert.ToInt32(Session[CommonConstantNames.USERUID]);
                /*
                * ADDED BY KARUNAKAR ON 02-05-2016
                * AS PER NEW CR TTSL
                * START
                */
                if (Session["IsTTSL"].ToString().ToUpper() == "Y")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Services Error", "TTSLErrorFlag();", true);
                }
                //END
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }
            ((HtmlTableCell)this.Page.Master.FindControl("Miscellaneous1")).Attributes.Add("class", "active");
            if (!IsPostBack)
            {
                DataSet dsSurvey = null;

                CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "CutomerSatisfacation_cr.aspx");

                GlimpsBAL.CustomerSatisfactionSurveyBAL objSurveyBAL = null;
                try
                {
                    dsSurvey = new DataSet();
                    objSurveyBAL = new GlimpsBAL.CustomerSatisfactionSurveyBAL();
                    //dsSurvey = objSurveyBAL.GetCustomerSatisfactionSurvey();
                    dsSurvey = objSurveyBAL.GetCustomerSatisfactionSurvey_cr();
                    ViewState["SurveyData"] = dsSurvey;
                    for (int i = 0; i < dsSurvey.Tables[0].Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            fillControls(dsSurvey.Tables[0], i, lblId1, lblQuestion1, rbtAnswer1);
                        }
                        else if (i == 1)
                        {
                            fillControls(dsSurvey.Tables[0], i, lblId2, lblQuestion2, rbtAnswer2);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void fillControls(DataTable dtControls, int i, Label lblId, Label lblQuestion, RadioButtonList RadioButtonList)
        {

            lblId.Text = dtControls.Rows[i]["ID"].ToString().Trim();
            lblQuestion.Text = dtControls.Rows[i]["Question"].ToString().Trim();
        }
        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            CustomerSatisfactionSurveyInfo objCustomerSatisfactionSurveyInfo = new CustomerSatisfactionSurveyInfo();
            GlimpsBAL.CustomerSatisfactionSurveyBAL obj = new GlimpsBAL.CustomerSatisfactionSurveyBAL();
            try
            {
                objCustomerSatisfactionSurveyInfo.answer1 = rbtAnswer1.SelectedItem.Text;
                objCustomerSatisfactionSurveyInfo.answer2 = rbtAnswer2.SelectedItem.Text;
                objCustomerSatisfactionSurveyInfo.Description = txtDescription.Text;
                int Result = obj.UpdateCustomerSatisfactionSurvey_cr(objCustomerSatisfactionSurveyInfo, UserUID);
                if (Result >= 0)
                {
                    txtDescription.Text = "";
                    rbtAnswer1.ClearSelection();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('We thank you for your valuable time to provide us with your feedback.')", true);
                }
                else if (Result < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Data not update')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
