<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NEL_cr.aspx.cs" MasterPageFile="~/Masters/MenuMasterPage_Cr.master"
Inherits="PACE.CreditLifeInformation.NEL_cr" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
           <title>NEL</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />

    <script src="App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>
    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .change-password-header-bar {
            background-color: #cccccc; /* Grey background */
            padding: 8px 15px;
            font-weight: bold;
            margin-bottom: 20px;
            border-radius: 4px;
        }
  
        }
     </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server" >
    <main class="dashboard-main">
        <div class="content-area">
            <h2 class="page-title">Non Medical Limit (NML)</h2>
                 <div class="data-table-container">
                                <asp:GridView ID="gvMedicalNonMedical" runat="server" CssClass="data-table" OnRowCommand="gvMedicalNonMedical_RowCommand"
                                    DataKeyNames="MedicalNonMedicalMappingUID" AllowPaging="true" PageSize="5"
                                    AutoGenerateColumns="false" OnPageIndexChanging="gvMedicalNonMedical_PageIndexChanging">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        PageButtonCount="3" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass=".GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Medical Chart Code" Visible ="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkButMediChartcode" runat="server" Text='<%#Eval("MedicalChartCode")%>'
                                                    ToolTip='<%#Eval("MedicalChartCode")%>' CommandName="VIEWMEDICODE" CommandArgument='<%#Eval("MedicalChartCode")%>'
                                                    ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Non Medical Chart Code">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkButNonMediChartcode" runat="server" Text='<%#Eval("NonMedicalChartCode")%>'
                                                    ToolTip='<%#Eval("NonMedicalChartCode")%>' CommandName="VIEWNONMEDICODE" CommandArgument='<%#Eval("NonMedicalChartCode")%>'
                                                    ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FromDate" HeaderText="From Date"></asp:BoundField>
                                        <asp:BoundField DataField="ToDate" HeaderText="To Date"></asp:BoundField>
                                        <asp:BoundField DataField="Freeze" HeaderText="Freeze"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
             </div>
            <div id="divNonMedicalCodeDetails" class="change-password-header-bar" runat="server" style="margin-top:20px" visible="false">Non Medical Chart Details</div>
            <div class="data-table-container">
                                <asp:GridView ID="gvNonMedicalCodeDetails" runat="server" CssClass="data-table" AllowPaging="true" PageSize="5"
                                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="gvNonMedicalCodeDetails_PageIndexChanging">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        PageButtonCount="3" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass=".GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="NonMedicalLimitCode" HeaderText="NM Code"></asp:BoundField>
                                        <asp:BoundField DataField="From_AGE" HeaderText="From Age"></asp:BoundField>
                                        <asp:BoundField DataField="To_AGE" HeaderText="To Age"></asp:BoundField>
                                        <asp:BoundField DataField="Sum_Assured" HeaderText="Sum Assured"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
            </div>
        </main>
     <script src="App_Themes/Theme/StyleSheets/dashboard_script.js" type="text/javascript"></script>
   </asp:Content>
<%--<body>
    <form id="form1" runat="server">
         
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <div>
                <table width="100%" border="0" cellpadding="5" cellspacing="5">
                    <tr>
                        <th class="strip-title" valign="top">
                            Non Medical Limit (NML)
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 100%;">
                                <asp:GridView ID="gvMedicalNonMedical" runat="server" OnRowCommand="gvMedicalNonMedical_RowCommand"
                                    DataKeyNames="MedicalNonMedicalMappingUID" AllowPaging="true" PageSize="5" Width="700px"
                                    AutoGenerateColumns="false" OnPageIndexChanging="gvMedicalNonMedical_PageIndexChanging">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        PageButtonCount="3" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Medical Chart Code" Visible ="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkButMediChartcode" runat="server" Text='<%#Eval("MedicalChartCode")%>'
                                                    ToolTip='<%#Eval("MedicalChartCode")%>' CommandName="VIEWMEDICODE" CommandArgument='<%#Eval("MedicalChartCode")%>'
                                                    ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Non Medical Chart Code">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkButNonMediChartcode" runat="server" Text='<%#Eval("NonMedicalChartCode")%>'
                                                    ToolTip='<%#Eval("NonMedicalChartCode")%>' CommandName="VIEWNONMEDICODE" CommandArgument='<%#Eval("NonMedicalChartCode")%>'
                                                    ForeColor="Blue" CausesValidation="False"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FromDate" HeaderText="From Date"></asp:BoundField>
                                        <asp:BoundField DataField="ToDate" HeaderText="To Date"></asp:BoundField>
                                        <asp:BoundField DataField="Freeze" HeaderText="Freeze"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr id="trgv" runat="server" >
                        <td class="strip-title" valign="top">
                            Non Medical Chart Details
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 50%;">
                                <asp:GridView ID="gvNonMedicalCodeDetails" runat="server" AllowPaging="true" PageSize="5"
                                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="gvNonMedicalCodeDetails_PageIndexChanging">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        PageButtonCount="3" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="NonMedicalLimitCode" HeaderText="NM Code"></asp:BoundField>
                                        <asp:BoundField DataField="From_AGE" HeaderText="From Age"></asp:BoundField>
                                        <asp:BoundField DataField="To_AGE" HeaderText="To Age"></asp:BoundField>
                                        <asp:BoundField DataField="Sum_Assured" HeaderText="Sum Assured"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="tbReport" runat="server" visible="false">
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="rptNEL" runat="server" Height="470px" Width="100%" ShowPrintButton="False"
                                Visible="False">
                            </rsweb:ReportViewer>
                            <asp:Label runat="server" ID="lblNoTextMsg" Visible="false" Text="No Records Found">
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
            <div class="UpdateProgressmodal">
                <div class="UpdateProgresscenter">
                    <asp:Label ID="labelDisplay" runat="server" Text="Processing..."></asp:Label>
                    <br />
                    <img id="progessImage" src="../App_Themes/Theme/Images/loading.gif" alt="" width="70" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>--%>

