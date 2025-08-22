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
using PACE.Masters;

namespace PACE.MemberInformation_cr
{
    public partial class MemberInfoPopUp_cr : System.Web.UI.Page
    {
        string UserUID = string.Empty;
        string subOfficeUID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dsMemberDetails = new DataSet();
                if (!IsPostBack)
                {
                    CommonMethods.InsertingPageInfo_cr("I", Convert.ToString(UserUID), "MemberinfoPopUp_cr.aspx");
                    string queryString = Request.QueryString.ToString();
                    MemberInfoBAL memberInfoBAL = new MemberInfoBAL();
                    int PolicyMemberUID = Convert.ToInt32(Session["PolicyMemberUID"]);
                    if (Session[CommonConstantNames.USERUID] != null)
                    {
                        UserUID = Session[CommonConstantNames.USERUID].ToString();
                        subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                    }
                    else
                    {
                        Response.Redirect("~/LoginPage.aspx", true);
                    }
                    //int PolicyUID, RenewalNoUID;
                    if (Session["PolicyMemberUID"] != null)
                    {
                        //PolicyUID = Convert.ToInt32(Session[CommonConstantNames.POLICYUID]);
                        //RenewalNoUID = Convert.ToInt32(Session[CommonConstantNames.RENEWALNOUID]);
                        if (queryString == "BillDetail")
                        {
                            thHeader.InnerText = "BillDetail";
                            dsMemberDetails = memberInfoBAL.GetMemberInfoBillDetails_cr(Convert.ToInt32(UserUID), PolicyMemberUID, queryString);

                        }
                        else if (queryString == "ReceiptDetail")
                        {
                            thHeader.InnerText = "ReceiptDetail";
                            dsMemberDetails = memberInfoBAL.GetMemberInfoReceiptDetail_cr(Convert.ToInt32(UserUID), PolicyMemberUID, queryString);

                        }
                        else if (queryString == "MemberServicing")
                        {
                            thHeader.InnerText = "MemberServicing";

                            dsMemberDetails = memberInfoBAL.GetMemberInfoMemberHistory_cr(Convert.ToInt32(UserUID), PolicyMemberUID, queryString);

                        }
                        else if (queryString == "PremiumServicing")
                        {
                            thHeader.InnerText = "PremiumServicing";
                            dsMemberDetails = memberInfoBAL.GetMemberInfoPremiumHistory_cr(Convert.ToInt32(UserUID), PolicyMemberUID, queryString);

                        }


                    }
                    if (dsMemberDetails != null && dsMemberDetails.Tables[0].Rows.Count > 0)
                    {
                        BindGrid(dsMemberDetails.Tables[0]);
                        ViewState["DataBind"] = dsMemberDetails.Tables[0];
                    }
                    else
                    {
                        // Masters_MenuMasterPage.ShowNoResultFound(dsMemberDetails.Tables[0], gvServicing);
                        MenuMasterPage_Cr.ShowNoResultFound(dsMemberDetails.Tables[0], gvServicing);
                        // BaseClass.ShowNoResultFound(dsMemberDetails.Tables[0], gvServicing);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }


        protected void lnkBtnReceiptDetails_Click(object sender, EventArgs e)
        {

            try
            {
                //Session[CommonConstants.sCOI] = LblCertificateofInsuranceNoText.Text;
                //Session[CommonConstants.sPOLICY_UID] = LblPolicyNoText.Text;
                //Session[CommonConstants.sPOLICY_YEAR] = Session[CommonConstants.sPOLICY_YEAR];

                //Session[CommonConstants.sCLIENTNAME] = LblClientNameText.Text;
                //Session["memname"] = "Suryakanth";

                //string mname = "";
                //if (!DdlInsuredTitle.Text.Equals("Select"))
                //    mname = DdlInsuredTitle.Text;
                //if (!TxtInsuredFirstName.Text.Equals(""))
                //    mname = mname + " " + TxtInsuredFirstName.Text;
                //if (!TxtInsuredMiddleName.Text.Equals(""))
                //    mname = mname + " " + TxtInsuredMiddleName.Text;
                //if (!TxtInsuredLastName.Text.Equals(""))
                //    mname = mname + " " + TxtInsuredLastName.Text;



                //Session[CommonConstants.MEMBER_NAME] = mname;


                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.showModalDialog('../../FormsGroupTerm/Underwriting/PopupTPolicyBillDetails.aspx','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
            }
        }
        private void BindGrid(DataTable dt)
        {
            ViewState["DataBind"] = dt;
            gvServicing.DataSource = dt;
            gvServicing.DataBind();
        }
        protected void gvBillEnuiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvServicing.PageIndex = e.NewPageIndex;
            if (ViewState["DataBind"] != null)
            {
                BindGrid((DataTable)ViewState["DataBind"]);
            }
        }
    }
}
