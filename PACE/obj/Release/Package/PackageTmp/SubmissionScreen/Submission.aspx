<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="Submission.aspx.cs" Inherits="PACE.SubmissionScreen.Submission" Title="Untitled Page" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>

    <style type="text/css">
        .NewsTab .ajax__tab_header
        {
            color: Gray;
            font-weight: bold;
            background-color: White;
            margin-left: 10px;
        }
        .NewsTab .ajax__tab_outer
        {
            background-color: White;
        }
        .NewsTab .ajax__tab_inner
        {
            color: #ffffff;
            padding: 6px;
            margin-right: 1px;
            margin-left: 1px;
            margin-top: 1px;
            margin-bottom: 1px;
            background-color: #22bcb9;
       
        }
        .NewsTab .ajax__tab_hover .ajax__tab_outer
        {
            background-color: Gray;
        }
        .NewsTab .ajax__tab_hover .ajax__tab_inner
        {
            background: url(      "../Images/tab_left_active.png" ) no-repeat left;
        }
        .NewsTab .ajax__tab_active .ajax__tab_outer
        {
            background: url(      "../Images/tab_right_active.png" ) no-repeat right;
        }
        .NewsTab .ajax__tab_active .ajax__tab_inner
        {
            background-color: Gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:MultiView ID="MV_UploadSR_View" runat="server" ActiveViewIndex="0">
        <asp:View ID="View_UploadFile" runat="server">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td class="strip-title" colspan="4" valign="top">
                        Submission File Attachments
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;">
                        Client Name <span class="span">*</span>
                    </td>
                    <td style="width: 35%;">
                        <%--OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"--%>
                        <asp:DropDownList ID="ddlclint" runat="server" CssClass="styled-select">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCategory" InitialValue="0" ErrorMessage="Please select Category."></asp:RequiredFieldValidator>--%>
                    </td>
                    <td style="width: 15%;">
                    </td>
                    <td style="width: 25%;">
                        Policy No<span class="span">*</span>
                    </td>
                    <td style="width: 35%;">
                        <%--OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"--%>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="styled-select">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCategory" InitialValue="0" ErrorMessage="Please select Category."></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <div id="divName" style="display: none;">
                        </div>
                    </td>
                </tr>
            </table>
           <table id ="tbl" runat="server" style="height:50px" >
           <tr>
           </tr>
            </table>
            
            <table width="100%" border="0" cellspacing="2" cellpadding="2">
              
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UPFileUpload" runat="server">
                            <ContentTemplate>
                                <table width="94%" cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td style="width:25%">
                                            Select file
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FUploadfile" runat="server" Width="270px" />
                                            &nbsp
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="imgBtnUpload" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <%--OnClick="imgBtnUpload_Click"  OnClientClick="javascript:return ServiceValidation();"--%>
                                    <asp:Button ID="imgBtnUpload" runat="server" ToolTip="Click here to Upload Excel"
                                        CssClass="upload_input"></asp:Button>
                                    <%-- <asp:LinkButton ID="OnLnkUpload" runat="server" OnClick="OnLnkUpload_Click" Style="background-color: Navy;
                                     font-size: x-large" Font-Underline="False">Upload</asp:LinkButton>--%>
                                </td>
                                <td id="tdA1">
                                    <a id="BtnDownload" title="Click here to download a sample file" href="../DownloadFormate/TermMemberPOS_Upload-Group Life.xls"
                                        title="Click here to download a sample file" target="_blank">
                                        <img src="../App_Themes/Theme/Images/btn_download_sample_file.png" style="border: none;" /></a>
                                    <%-- <a id="BtnDownload" title="Click here to download a sample file" href="../DownloadFormate/TermMemberPOS_Upload-Group Life.xls"
                                            title="Click here to download a sample file" target="_blank">
                                            <img src="../App_Themes/Theme/Images/btn_download_sample_file.png" style="border: none;" /></a>--%>
                                    <%-- <a id="A1"  title="Click here to download a sample file" style="border: none; 
                                        text-decoration: none; border-collapse: collapse;" target="_blank"  >
                                        <img src="../App_Themes/Theme/Images/btn_download_sample_file.png" width="101" height="29" id="imgA1"
                                            style="border: none; text-decoration: none;" /></a>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>
                            <b>Note</b><span style="color: Red">*</span>:- Please download the upload file by
                            clicking on sample
                        </p>
                    </td>
                    <td style="text-align: left;" valign="top">
                        <div id="fileUpload" style="position: absolute; display: none; width: 20%">
                        </div>
                        &nbsp;
                        <div id="ddlSC" style="position: absolute; display: none; width: 20%">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="4" style="width: 100%; text-align: center;" valign="top">
                        <div style="width: 100%;" >
                            <asp:Button ID="imgBtnUpload" runat="server" OnClientClick="return Validation();"
                                CssClass="upload_input"  OnClick="imgBtnUpload_Click" />
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td  style="text-align:center;padding-right:80px;">
                        <a id="BtnDownload" href="../DownloadFormate/TermMemberPOS_Upload-Group Life.xls" title="Click here to download a sample file"
                            target="_blank"><img src="../App_Themes/Theme/Images/btn_download_sample_file.png" style="border:none;"/></a>
                        <asp:LinkButton ID="LnkBtnDownload" PostBackUrl="~/DownloadFormate/TermMemberPOS_Upload-Group Life.xls" runat="server">Download Format File</asp:LinkButton>
                    </td>
                </tr>--%>
                <asp:Label ID="lblMessageUpload" runat="server" Font-Names="Tahoma" Font-Size="Small"></asp:Label>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
