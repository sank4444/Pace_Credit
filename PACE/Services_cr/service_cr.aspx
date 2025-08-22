<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="service_cr.aspx.cs" MasterPageFile="~/Masters/MenuMasterPage_Cr.master"
    Inherits="PACE.Services_cr.service_cr" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">--%>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/online_servicing_style.css" rel="stylesheet" type="text/css" />
    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="../Scripts/JScript.js" type="text/javascript"></script>

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
            border-top-right-radius: 5px;
            border-top-left-radius: 5px;
        }
        .NewsTab .ajax__tab_hover .ajax__tab_outer
        {
            background-color: Gray;
        }
        .NewsTab .ajax__tab_hover .ajax__tab_inner
        {
            background: url(       "../Images/tab_left_active.png" ) no-repeat left;
        }
        .NewsTab .ajax__tab_active .ajax__tab_outer
        {
            background: url(       "../Images/tab_right_active.png" ) no-repeat right;
        }
        .NewsTab .ajax__tab_active .ajax__tab_inner
        {
            background-color: Gray;
        }
    </style>
    <script type="text/javascript">
     function ShowRedirect()
     {
        alert('Data save Successfully');
        window.location.href='service_cr.aspx';
     }   
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
              <div class="UpdateProgressmodal" runat="server">
                <div class="UpdateProgresscenter" runat="server">
                    <asp:Label ID="lblService" runat="server" ></asp:Label>
                    <br />
                    <img id="progessImage" src="../App_Themes/Theme/Images/loading.gif" alt="" width="70" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
     <!-- Main Content Area -->
    <main class="dashboard-main">
        <div class="content-box">
    <asp:MultiView ID="MV_UploadSR_View" runat="server" ActiveViewIndex="0">
        <asp:View ID="View_UploadFile" runat="server">
             <h4 class="page-title">Member Upload</h4>
                  <div class="row mb-3 align-items-center"  style="display: none;">
                      <label for="servicecharge" class="col-sm-3 col-form-label">Servicing Change</label>
                                        <div>
                                            <asp:DropDownList ID="ddlServicingChange" runat="server" Enabled="false" CssClass="styled-select"
                                                onchange="javascript:dropDownChange(this);">
                                            </asp:DropDownList>
                                        </div>
                            </div>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                <div class="row mb-3 align-items-center">
                    <label for="fileUpload" class="col-sm-3 col-form-label">Select file to Upload</label>
                    <div class="col-sm-9 fileUpload-border">
                        <asp:FileUpload ID="FUploadfile" CssClass="form-control" runat="server" />
                    </div>
                      </ContentTemplate>
                      <Triggers>
                      <asp:PostBackTrigger ControlID="imgBtnUpload" />
                      </Triggers>
                      </asp:UpdatePanel>
                </div>
              <%--  <div class="row mb-4">
                    <div class="col-sm-9 offset-sm-3">
                        <p class="form-text text-muted">
                            Note*: Please download the sample template for the selected servicing change before uploading.
                        </p>
                    </div>
                </div>--%>
                <div class="row">
                    <div class="col-sm-9 offset-sm-3 d-flex justify-content-start">
                      <%--<button type="button" class="btn logout-btn me-2"><i class="fas fa-upload"></i> Upload</button>--%>
                         <asp:Button ID="imgBtnUpload" runat="server" OnClientClick="javascript:return ServiceValidation();"
                                            ToolTip="Click here to Upload Excel" Text="Upload" CssClass="btn btn-primary" OnClick="imgBtnUpload_Click">
                                        </asp:Button>
                        <%--<button type="button" class="btn btn-secondary"><i class="fas fa-download"></i> Sample</button>--%>
                        &nbsp;
                         <%--<a id="BtnDownload" title="Click here to download a sample file" href="../DownloadFormate/EasyAdmin_Upload.xls"
                                            target="_blank">
                                            <img src="../App_Themes/Theme/Images/btn_download_sample_file.png" style="border: none;" alt="" /></a>--%>
                         <asp:Button ID="BtnDownload" runat="server" OnClientClick="javascript:return redirect();"
                                            ToolTip="Click here to download a sample file" Text="Sample" CssClass="btn btn-secondary">
                                        </asp:Button>
                    </div>
                </div>
                <div class="pt-3">
                     <p>
                        <b>Note</b><span style="color: Red">*</span>:- Please download the upload file by clicking on sample
                      </p>
                     
                    </div>
                  <div id="fileUpload" style="position: absolute; display: none; width: 70%">
                            </div>
                            &nbsp;
                            <div id="ddlSC" style="position: absolute; display: none; width: 70%">
                            </div>
                    <div>
                        <asp:Label ID="lblMessageUpload" runat="server" Font-Names="Tahoma" Font-Size="Small"></asp:Label>
                        </div>
                

           <%-- <div id="div1" style="width: 99%; border: 0px black solid;">
                <table width="100%" border="0" cellspacing="5" cellpadding="5">
                    <tr>
                        <th class="strip-title" colspan="4" valign="top">
                            Member Upload
                        </th>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 60%">
                            <div>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td style="width: 30%">
                                            Servicing Change
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlServicingChange" runat="server" Enabled="false" CssClass="styled-select"
                                                onchange="javascript:dropDownChange(this);">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UPFileUpload" runat="server">
                                <ContentTemplate>
                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                        <tr>
                                            <td style="width: 32%">
                                                Select file to Upload
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="FUploadfile" runat="server" Width="200px" />
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
                                        <asp:Button ID="imgBtnUpload" runat="server" OnClientClick="javascript:return ServiceValidation();"
                                            ToolTip="Click here to Upload Excel" CssClass="upload_input" OnClick="imgBtnUpload_Click">
                                        </asp:Button>
                                    </td>
                                    <td id="tdA1">
                                        <a id="BtnDownload" title="Click here to download a sample file" href="../DownloadFormate/EasyAdmin_Upload.xls"
                                            target="_blank">
                                            <img src="../App_Themes/Theme/Images/btn_download_sample_file.png" style="border: none;" alt="" /></a>
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
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                
                    <asp:Label ID="lblMessageUpload" runat="server" Font-Names="Tahoma" Font-Size="Small"></asp:Label>
                </table>
            </div>--%>
        </asp:View>
        <asp:View ID="ExcelUploadedData" runat="server">
            <h4 class="page-title"> Verify Data</h4>
            <div class="row mb-3 align-items-center">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"></asp:Label>
                </div>
             <div class="data-table-container" >
                 <asp:GridView ID="grdExcelUploadedData" CssClass="data-table" runat="server" AllowPaging="true">
                                <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass=".GridViewHeaderStyle" />
                            </asp:GridView>
                 </div>
            <div class="col-md-12 text-center" style="width: 100%;">
                            <div style="background-image: url('../../../App_Themes/Cocotree/Images/Header.png');
                                float: left; width: 100%;">
                                <asp:ImageButton ID="imgbtn_Back" runat="server" ImageUrl="~/App_Themes/Theme/Images/arrow-left.png"
                                    OnClick="imgbtn_Back_Click" CssClass="btn btn-primary" style="width:4%" />
                                &nbsp;<asp:ImageButton ID="imgbtn_Next" runat="server" ImageUrl="~/App_Themes/Theme/Images/arrow-right.png"
                                    OnClick="imgbtn_Next_Click" CssClass="btn btn-primary" style="width:4%" />
                            </div>
                        </div>
            <table cellspacing="0" style="width: 100%;">
                
                <tr>
                    <td style="text-align: left; padding-left: 10px; height: 10px;">
                        <%--<asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 100%;">
                        <div style="width: 999px; height: 450px; ">
                           <%-- <asp:GridView ID="grdExcelUploadedData" runat="server" AllowPaging="true">
                                <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                            </asp:GridView>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left;" valign="top">
                       <%-- <div style="width: 100%;">
                            <div style="background-image: url('../../../App_Themes/Cocotree/Images/Header.png');
                                float: left; width: 100%;">
                                <asp:ImageButton ID="imgbtn_Back" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Back.png"
                                    OnClick="imgbtn_Back_Click" />
                                &nbsp;<asp:ImageButton ID="imgbtn_Next" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Next.png"
                                    OnClick="imgbtn_Next_Click" />
                            </div>
                        </div>--%>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View_ShowLog" runat="server">
            <h4 class="page-title"> View Log</h4>
            <div class="row mb-3 align-items-center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"></asp:Label>
                </div>
            <%--<table cellspacing="0" style="width: 100%;" border="0">--%>
                <%--<tr>
                    <th class="strip-title" valign="top">
                        View Log
                    </th>
                </tr>--%>
                <%--Added by karunakar for displaying count of uploades summary 15072016--%>
               <%-- <tr>
                    <td>
                        <asp:Label ID="lblCount" runat="server" BorderColor="White" Width="500px" BorderStyle="Groove"
                            BorderWidth="1px" Font-Bold="True" Font-Italic="True" Font-Underline="True" ForeColor="#22BCB9"></asp:Label>
                    </td>
                </tr>--%>
                <%--End--%>
               <%-- <tr>
                    <td style="text-align: left; width: 700px; padding-left: 12px;">--%>
                <div class="view-log-section">
                        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="700px" ActiveTabIndex="0"
                            CssClass="NewsTab" BorderStyle="None">
                            <ajaxToolkit:TabPanel ID="pnlErrorLog" runat="server" HeaderText="Success" BackColor="#22bcb9"
                                BorderColor="#22bc9">
                                <HeaderTemplate>
                                    Success
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <%--Visible="false"--%>
                                    <%--<div style="width: 700px; height: 450px; overflow: auto;">--%>
                                    <div class="table-responsive log-table" style="overflow: auto;">
                                        <asp:GridView ID="grdConform" runat="server" Visible="true" class="table table-bordered table-striped data-table">
                                            <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                                NextPageText="Next" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass=".GridViewHeaderStyle" />
                                        </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Duplicate" BackColor="#22bcb9"
                                BorderColor="#22bc9">
                                <HeaderTemplate>
                                    Duplicate
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <%--<div style="width: 700px; height: 450px; overflow: auto;">--%>
                                    <div class="table-responsive log-table" style="overflow: auto;">
                                        <asp:GridView ID="grdDuplicate" runat="server" class="table table-bordered table-striped data-table">
                                            <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                                NextPageText="Next" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass=".GridViewHeaderStyle" />
                                        </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Error" BackColor="#22bcb9"
                                BorderColor="#22bc9">
                                <HeaderTemplate>
                                    Error
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <%--<div style="width: 700px; height: 421px; overflow: auto;">--%>
                                    <div class="table-responsive log-table" style="overflow: auto;">
                                        <asp:GridView ID="grdErrorLog" runat="server" class="table table-bordered table-striped data-table">
                                            <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                                NextPageText="Next" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <%--<ajaxToolkit:TabPanel ID="TabPanel3" runat="server" BackColor="#22bcb9" Visible="false"
                                BorderColor="#22bc9">
                                <ContentTemplate>
                                    <div style="width: 700px; height: 421px; overflow: auto;" style="border: none !important">
                                        <asp:GridView ID="gvAWW" runat="server" GridLines="None">
                                            <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                                NextPageText="Next" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAll(this);" Width="25px" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this);" />
                                                        <asp:Label ID="lblCOI" runat="server" Text='<%#Eval("COI") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div>
                                        <b><span style="font-size: 26px; color: Red;">*</span>Note :</b> We wish to inform
                                        you that all additions/Sum assured change needs to be intimated to us within 31
                                        days from their date of joining.
                                        <br />
                                        In case of any late intimation we would require confirmation that all members are
                                    </div>
                                    <div>
                                        1) Actively at Work" on a full time permanent basis and performing in the customary
                                        manner all the regular duties of his/her work.
                                    </div>
                                    <div>
                                        2) Has not been absent from work due to illness/injury for more than 5 consecutive
                                        days in the last 3 months.
                                    </div>
                                    <div>
                                        3) To the best of our knowledge and belief the employee is in good health and has
                                        not been suffering from any long-term illness.
                                    </div>
                                    <div>
                                        <asp:RadioButtonList runat="server" TextAlign="left" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="I Accept" Value="Y" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RadioButton ID="chkValidation" runat="server" Text="I Accept" TextAlign="Left"
                                            AutoPostBack="true" Checked="false" OnCheckedChanged="chkValidation_CheckedChanged" />
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>--%>
                        </ajaxToolkit:TabContainer>
                    </div>
                  <%--  </td>
                </tr>--%>
                                <!-- Action Buttons -->
                <div class="row mt-4">
                    <div class="col-12 d-flex justify-content-start">
                            <div style="background-image: url('../../../App_Themes/Cocotree/Images/Header.png');
                                float: left; height: 30px; width: 100%;">
                                <asp:ImageButton ID="imgbtn_Undo" runat="server" AlternateText="Undo" ImageUrl="~/App_Themes/Theme/Images/btn_Undo.png"
                                    OnClick="imgbtn_Undo_Click" />
                                &nbsp;
                                <asp:ImageButton ID="imgbtn_Confirm" runat="server" AlternateText="Confirm" ImageUrl="~/App_Themes/Theme/Images/btn_Confirm.png"
                                    OnClick="imgbtn_Confirm_Click" />
                            </div>
                        </div>
                    </div>
                
            <%--</table>--%>
        </asp:View>
        <%--<asp:View ID="vwJob" runat="server">
            <table cellspacing="0" style="width: 100%;">
                <tr>
                    <th class="strip-title" valign="top" visible="false">
                        Job
                    </th>
                </tr>
                <tr>
                    <td style="text-align: left; width: 100%;" visible="false">
                        <div style="width: 980px; height: 450px; overflow: auto;">
                            <asp:GridView ID="gvJob" runat="server">
                                <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left;" valign="top">
                        <div style="width: 100%;">
                            <div style="background-image: url('../../../App_Themes/Cocotree/Images/Header.png');
                                float: left; height: 30px; width: 100%;">
                                <asp:ImageButton ID="imgUndo" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Undo.png"
                                    OnClick="imgbtn_Back_Click" />
                                &nbsp;<asp:ImageButton ID="imgBillGenerate" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Generate.png"
                                    OnClick="imgBillGenerate_Click" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vwBillGenerate" runat="server">
            <table cellspacing="0" style="width: 100%;">
                <tr>
                    <th class="strip-title" valign="top">
                        Bill Generate
                    </th>
                </tr>
                <tr>
                    <td style="text-align: left; width: 100%;">
                        <div style="width: 980px; height: 450px; overflow: auto;">
                            <asp:GridView ID="grBillGeneration" runat="server">
                                <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left;" valign="top">
                        <div style="width: 100%;">
                            <div style="background-image: url('../../../App_Themes/Cocotree/Images/Header.png');
                                float: left; height: 30px; width: 100%;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Undo.png"
                                    OnClick="imgbtn_Back_Click" />
                                &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Issue.png"
                                    OnClick="imgIssueBill_Click" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vwIssueBill" runat="server">
            <table cellspacing="0" style="width: 100%;">
                <tr>
                    <th class="strip-title" valign="top">
                        Bill Issue
                    </th>
                </tr>
                <tr>
                    <td style="text-align: left; width: 100%;">
                        <div style="width: 980px; height: 450px; overflow: auto;">
                            <asp:GridView ID="gvBillIssue" runat="server" OnRowCommand="gvBillIssue_RowCommand">
                                <PagerSettings PreviousPageText="Previous" FirstPageText="<" LastPageText=">" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="BillGenerationPdf" runat="server" CommandName="view" ImageUrl="~/App_Themes/Theme/Images/View.png"
                                                Height="35px" Width="35px" ToolTip="Download" CommandArgument='<%#Eval("BillUID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left;" valign="top">
                        <div style="width: 100%;">
                            <div style="background-image: url('../../../App_Themes/Cocotree/Images/Header.png');
                                float: left; height: 30px; width: 100%;">
                                <asp:ImageButton ID="imgIssueUndo" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Finish.png"
                                    OnClick="imgbtn_Back_Click" />
                                &nbsp;<asp:ImageButton ID="imgIssueBill" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Issue.png"
                                    Enabled="false" OnClick="imgIssueBill_Click" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:View>--%>
    </asp:MultiView>
        </div>
        </main>
    <%-- <script type="text/javascript">

        $(document).ready(function() {

            $("#A1").click(function() {
                var eDropDownList = $("#<%=ddlServicingChange.ClientID%>");
                var selectedValue = eDropDownList.val();
                if (selectedValue == "0") {

                    alert("Please select Servicing change");
                    $("tdA1").style("display","inline");
                    eDropDownList.focus(); this.visible = false;
                }
                else this.visible = true;
            }); //A1 Click
        });           //Ready

        //     
        function BackFunction() {
            window.location.href("~/Services/service.aspx");
        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows
                        row.style.backgroundColor = "#68e4ce";
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked
                        //uncheck all checkboxes
                        //and change rowcolor back to original
                        if (row.rowIndex % 2 == 0) {
                            //Alternating Row Color
                            row.style.backgroundColor = "#F7F6F3";
                        }
                        else {
                            row.style.backgroundColor = "#FFFFFF";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }

        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                row.style.backgroundColor = "#68e4ce";
            }
            else {
                //If not checked change back to original color
                if (row.rowIndex % 2 == 0) {
                    //Alternating Row Color
                    row.style.backgroundColor = "#F7F6F3";
                }
                else {
                    row.style.backgroundColor = "#FFFFFF";
                }
            }
            //Get the reference of GridView
            var GridView = row.parentNode;
            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];
                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
        }

        /*
        *On dropdown change index changing downloading template
        */
        function dropDownChange(eDropDownList) {

            var eAnchor = document.getElementById("A1");
            //var eAnchor = $("input[id*='A1']");
            var selectedValue = eDropDownList.options[eDropDownList.selectedIndex].value;

            if (selectedValue != "0") {
                $('#A1').unbind("click", false);
                switch (selectedValue) {
                    case "TRMMemAdd":
                        eAnchor.href = "../DownloadFormate/PACE_POS_Add_Member.xls";
                        break;
                }
            }
            else { $('#A1').unbind("click", true); }  //$('#A1').click(function() { return false; }); }
        }
    </script>--%>

    <script type="text/javascript">
    function getdisplay()
    {
        alert("Member upload successfully.");
        window.location.href = "service_cr.aspx";
        }
        function redirect() {
            location.href = '../DownloadFormate/EasyAdmin_Upload.xls';
        }
    </script>

</asp:Content>
