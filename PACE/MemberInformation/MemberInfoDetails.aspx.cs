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

public partial class MemberInformation_MemberInfoDetails : System.Web.UI.Page
{
    string UserUID = string.Empty;
    string subOfficeUID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsMemberDetails = new DataSet();
        try
        {
            if (!IsPostBack)
            {
                CommonMethods.InsertingPageInfo("I", Convert.ToString(UserUID), "MemberInfoDetails.aspx");
                MemberInfoBAL memberInfoBAL = new MemberInfoBAL();
                int PolicyMemberUID = Convert.ToInt32(Request.QueryString["PolicyMemberUID"].ToString());

                Session["PolicyMemberUID"] = Convert.ToString(PolicyMemberUID);//Used session for Servicing History tab

                if (Session[CommonConstantNames.USERUID] != null)
                {
                    UserUID = Session[CommonConstantNames.USERUID].ToString();
                    subOfficeUID = Session[CommonConstantNames.SUBOFFICEUID].ToString();
                    /*
                   * ADDED BY KARUNAKAR 02-04-2016
                   * AS PER NEW CR TTSL
                   * START ->
                   */
                    if (Session["IsTTSL"].ToString().ToUpper().Trim() == "Y")
                    {
                        TabPanel3.Visible = false;
                        tbSMS.Visible = true;
                        tbNominee.Visible = true;
                        TabPanel3.HeaderText = string.Empty;
                        tdEmployeeNo.InnerText = "Mobile No";
                    }
                    else
                    {
                        TabPanel3.HeaderText = "Premium Details";
                        TabPanel3.Visible = true;
                        tbSMS.HeaderText = string.Empty;
                        tbNominee.HeaderText = string.Empty;
                        tbSMS.Visible = false;
                        tbNominee.Visible = false;
                        tdEmployeeNo.InnerText = "Employee No";
                    }

                    //END
                }

                else
                {
                    Response.Write("<script>window.close();</" + "script>");
                    Response.End();

                    Response.Redirect("~/LoginPage.aspx", true);
                }
                int PolicyUID, RenewalNoUID;
                if (Session[CommonConstantNames.POLICYUID] != null) //commented by sonali for testing manually value pass for test
            
                {
                    PolicyUID = Convert.ToInt32(Session[CommonConstantNames.POLICYUID]);
                    RenewalNoUID = Convert.ToInt32(Session[CommonConstantNames.RENEWALNOUID]);
                    dsMemberDetails = memberInfoBAL.GetMemberInfoPopUp(Convert.ToInt32(UserUID), PolicyMemberUID, PolicyUID, RenewalNoUID);
                }

                 //Added by sonali on 04/08/2017
                if (dsMemberDetails.Tables[0].Rows[0]["RejectFlag"].ToString() == "R")
                {
                    TabContainerREJECT.Visible = true;
                    tabComtainer.Visible = false;

                    if (dsMemberDetails != null && dsMemberDetails.Tables[0].Rows.Count > 0)  
                    {
                        lbl_Name.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientName"]).Trim();
                        lbl_Gender.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Gender"]).Trim();
                        lbl_DOB.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["DOB"]).Trim();
                        lbl_Age.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["InsuredAge"]).Trim();
                        lbl_Circl.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Circle"]).Trim();
                        lbl_Validty.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Validity"]).Trim();
                        lbl_MbNo.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["EmployeeNo"]).Trim();
                       
                        lbl_RCharDt.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["RechargeDt"]).Trim();
                        lbl_MemberStatus.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["MemberStatus"]).Trim(); 
                       lbl_Remark.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Remark"]).Trim();
                        
                    }
                   
                    
                }
                else
                {
                    tabComtainer.Visible = true;
                    TabContainerREJECT.Visible = false;

                    if (dsMemberDetails != null && dsMemberDetails.Tables[0].Rows.Count > 0)
                    {
                        LblClientNameText.Text = "&nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientName"]).Trim();
                        LblPolicyNoText.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PolicyNumber"]).Trim();

                        LblSubOfficeCodeText.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientUnitCode"]).Trim();
                        LblSubOfficeText.Text = " &nbsp;" + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ClientUnitName"]).Trim();

                        LblCertificateofInsuranceNoText.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["COI"]).Trim();
                        LblYear.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["PolicyYear"]).Trim();
                        lblEmployeeNo.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["EmployeeNo"]).Trim();

                        lblInitialEffDate.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["InitialEffectiveDate"]).Trim();

                        lblTerminationDate.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Terminationdt"]).Trim();
                        lblMemberStatus.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["MemberStatus"]).Trim();

                        lblInsuredTitle.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ProposedTitle"]).Trim() == null ? " " : "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["ProposedName"]).Trim();

                        lblGender.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["Gender"]).Trim();
                        lblInsuredDOB.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["DOB"]).Trim();
                        lblInsuredAge.Text = "&nbsp; " + Convert.ToString(dsMemberDetails.Tables[0].Rows[0]["InsuredAge"]).Trim();
                                             
                        lblMHUIDno.Text = "&nbsp; " + dsMemberDetails.Tables[0].Rows[0]["MHUIDno"].ToString().Trim();
                        lblExpiryDate.Text = "&nbsp; " + dsMemberDetails.Tables[0].Rows[0]["ExpiryDate"].ToString().Trim();//Added by karunkar on 10-06-2016
                        lblCircle.Text = "&nbsp; " + dsMemberDetails.Tables[0].Rows[0]["Circle"].ToString().Trim();
                        lblValidity.Text = "&nbsp; " + dsMemberDetails.Tables[0].Rows[0]["Validity"].ToString().Trim();

                        if (dsMemberDetails.Tables[2].Rows.Count > 0)
                        {
                            gvProductBenefit.DataSource = dsMemberDetails.Tables[2];
                            gvProductBenefit.DataBind();
                        }
                        else
                        {
                            Masters_MenuMasterPage.ShowNoResultFound(dsMemberDetails.Tables[2], gvProductBenefit);
                        }
                        if (dsMemberDetails.Tables[3].Rows.Count > 0)
                        {
                            gvPremiumDetail.DataSource = dsMemberDetails.Tables[3];
                            ViewState["PremiumDetail"] = dsMemberDetails.Tables[3];
                            gvPremiumDetail.DataBind();
                        }
                        else
                        {
                            Masters_MenuMasterPage.ShowNoResultFound(dsMemberDetails.Tables[3], gvPremiumDetail);
                        }
                        
                        if (dsMemberDetails.Tables[4].Rows.Count > 0)
                        {
                            gvSMS.DataSource = dsMemberDetails.Tables[4];
                            gvSMS.DataBind();
                           
                        }
                        if (dsMemberDetails.Tables[5].Rows.Count > 0)
                        {
                            lblNAge.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["NaomineeAge"].ToString().Trim();
                            lblNName.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["NomineeName"].ToString().Trim();
                            lblNRelation.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["NomineeRelation"].ToString().Trim();
                            lblAddress.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["NomineeAddress"].ToString().Trim();
                            //  lblMobileNo.Text = dsMemberDetails.Tables[5].Rows[0]["MobileNo"].ToString().Trim();
                            lblIdentityNo.Text = "&nbsp; " + dsMemberDetails.Tables[5].Rows[0]["IdentityNo"].ToString().Trim();
                        }
                        //END

                    }

                    else
                    {

                        // Masters_MenuMasterPage.ShowNoResultFound(dsMemberDetails.Tables[0], gvProductBenefit);
                    }
                }
            }
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    protected void lnkMemberHistory_Click(object sender, EventArgs e)
    {

        try
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../MemberInfoPopUp.aspx?" + "MemberServicing" + "','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "MsgAlert", "alert('Message : " + CommonMethods.DisplayErrorMsg(ex) + "');", true);
        }
    }

    protected void lnkBillDetail_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open(~/../MemberInfoPopUp.aspx?ReceiptDetail','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
    }

    protected void lnkBillDetail_Click1(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../MemberInfoPopUp.aspx?MemberHistory','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
    }

    protected void lnkBillDetail_Click2(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../MemberInfoPopUp.aspx?PremiumHistory','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
    }

    protected void lnkBtnReceiptDetails_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BlockName", "window.open('~/../MemberInfoPopUp.aspx?" + "PremiumServicing" + "','null','dialogHeight: 600px; dialogWidth: 850px; dialogTop: 180px; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');", true);
    }

    protected void gvPremiumDetail_OnDataBound(object sender, EventArgs e)
    {
        if (ViewState["PremiumDetail"] != null)
        {
            if (((DataTable)ViewState["PremiumDetail"]).Rows.Count > 0)
            {
                DataTable dt = (DataTable)ViewState["PremiumDetail"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Medical"].ToString() == "Y")
                    {
                        ((ImageButton)gvPremiumDetail.Rows[i].FindControl("imgPDF")).Visible = true;
                    }
                    else
                    {
                        ((ImageButton)gvPremiumDetail.Rows[i].FindControl("imgPDF")).Visible = false;
                    }
                }

            }
        }
    }

    protected void gvPremiumDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowMTRF")
        {
            // Response.Redirect("~/Reports/ShowMTRF.aspx",true);
            ScriptManager.RegisterClientScriptBlock(gvPremiumDetail, this.GetType(), "BlockName", "window.open('../Reports/ShowMTRF.aspx','MTRF','toolbar=yes; location=no; status=yes; menubar=no; resizable=yes; scrollbars=no; fullscreen=yes;');", true);
        }
    }
}
