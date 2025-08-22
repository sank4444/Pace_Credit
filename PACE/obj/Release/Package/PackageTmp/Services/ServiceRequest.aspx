<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceRequest.aspx.cs"
    Inherits="PACE.ServiceRequest" MasterPageFile="~/Masters/MenuMasterPage.master"%>
<%--
<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    Inherits="Services_service" Title="Online Policy Servicing" CodeBehind="service.aspx.cs" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="../Scripts/JScript1.js" type="text/javascript"></script>

    <style type="text/css">
        .label
        {
            background-position: 14% left;
        }
        #lblERRFor
        {
            padding-left: 10px;
        }
        .style1
        {
            width: 188px;
        }
        .style2
        {
            width: 3%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <table border="0" cellpadding="5" cellspacing="5" style="width: 98%">
        <tr>
            <th class="strip-title" valign="top" colspan="3">
                Service Request
            </th>
        </tr>
        <tr>
            <td style="width: 30%">
                Category <span class="span">*</span>
            </td>
            <td style="width: 60%">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="styled-select" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCategory" InitialValue="0" ErrorMessage="Please select Category."></asp:RequiredFieldValidator>
            </td>
            <td>
                <div id="Category" style="display: none;">
                </div>
            </td>
        </tr>
        <tr id="trchkPan" runat="server">
            <td colspan="3">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="gvCheckBox" runat="server" AutoGenerateColumns="false" Width="100%"
                        EmptyDataText="No Record Found" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvCheckBox_PageIndexChanging"
                        OnRowCommand="gvCheckBox_RowCommand">
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                            PageButtonCount="3" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="chk_CheckedChanged" />
                                    <asp:HiddenField ID="hndCommonListUID" runat="server" Value='<%#Eval("CommonListUID") %>'>
                                    </asp:HiddenField>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CommonListName" HeaderText="Name Of Document" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <%--Added by Karunakar as per new CR TTSL
        on date 16/05/2016
        start
        --%>
        <tr id="trFileUpload" runat="server">
            <%--
        END
        --%>
            <td colspan="3">
                <asp:UpdatePanel ID="UPFileUpload" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td style="width: 35%">
                                    Select file to Upload (.pdf only)
                                </td>
                                <td style="width: 30%">
                                    <asp:FileUpload ID="fuServiceRequest" runat="server" />
                                    <div id="fuUpload" style="display: none;">
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="imgSaveService" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <%--Added by Karunakar as per new CR TTSL
        on date 16/05/2016
        start
        --%>
        <tr id="trCallCenter" runat="server" visible="false">
            <td colspan="3" style="padding-right:50px;">
               <table border="0" cellpadding="5" cellspacing="5" style="width: 100%">
                    <tr>
                        <td style="width: 30%">
                            Name of call center executive
                            <span class="span">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtccExecutive" runat="server" CssClass="inputbg"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name of executive required!" ControlToValidate="txtccExecutive"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
             <%--        /*--Added by Karunakar as per new CR TTSL
                            *   on date 22/06/2016
                            as per dicuss with aswani
                            *  start
                            --*/--%>
                     <tr>
                        <td style="width: 30%">
                            Mobile number 
                            <span class="span">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="inputbg" MaxLength ="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Name of executive required!" ControlToValidate="txtccExecutive"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--end--%>
                    <tr>
                        <td>
                            Deatil of Qurey
                            <span class="span">*</span>
                        </td>
                        <td style="padding-left:10px">
                            <asp:TextBox ID="txtQuery" runat="server" TextMode="MultiLine" CssClass="TextBoxMulti" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter details of query!" ControlToValidate="txtQuery"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--
        END
        --%>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:ImageButton ID="imgSaveService" runat="server" ImageUrl="~/App_Themes/Theme/Images/btn_Save.png"
                    OnClick="imgSaveService_Click" />
                    <%--OnClientClick="return ServiceRequestValidation();" --%>
                <asp:HiddenField ID="hndCofirm" runat="server" Value="return javascript:Confirm(this);" />
            </td>
        </tr>
    </table>    
</asp:Content>
