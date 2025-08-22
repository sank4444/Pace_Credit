<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillEnquiry_cr.aspx.cs"
    MasterPageFile="~/Masters/MenuMasterPage_Cr.master" Inherits="PACE.MIS.BillEnquiry_cr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>
    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .page-title {
    font-size: 28px;
}
        @media (max-width: 780px) {
            .billenquiry {
                padding: 3px 10px;
            }

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .billenquiry h2 {
                font-size: 22px;
            }

            .options {
                flex-direction: column;
                align-items: flex-start;
                gap: 10px;
            }

            .forgot-password {
                align-self: flex-start;
            }
        }
         </style>
     <style type="text/css">
        .pager-style {
       background-color: #f5f5f5;
    text-align: center;
    padding: 10px;
    background-color: #e9ecef;
    color: #333;
    border-radius: 4px;
    margin-top: 10px;
        }

        .pager-style a {
      color: #003366;
          background-color: #f8f9fa;
        padding: 5px 10px;
        margin: 2px;
        text-decoration: none;
           border: 1px solid #ddd;
        border-radius: 4px;
        }

        .pager-style a:hover {
          background-color: #e9ecef;
        color: #003366;
        }

        .pager-style span {
        font-weight: bold;
        color: white;
         background-color: var(--primary-color);
        padding: 5px 10px;
         border-color: var(--primary-color);
            border-radius: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
     <main class="dashboard-main">

    <div class="billenquiry">
         <div class="content-area">
    <asp:UpdatePanel ID="UPInsured" runat="server">
        <ContentTemplate>
            <h4 class="page-title"><asp:Label ID="lblreportname" runat="server" Text=""></asp:Label></h4>

             <!-- Search Section -->
            <div class="search-section mb-4 p-3 border rounded bg-light row">
                <div class="row align-items-end">
                    <div class="col-md-4 mb-2">
                         <label for="periodfrom" class="form-label">Period from </label>
                        <div class="input-group date" id="datepickerFrom">
                         <asp:TextBox ID="txtPeriodFrom" runat="server" CssClass="form-control"> 
                                        </asp:TextBox>
                                        <asp:ImageButton ID="imgPeriodFrom" runat="server"  CssClass="calendar-block" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                            ImageAlign="Middle" style="border: 1px solid #80808057;" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtPeriodFrom"
                                            PopupButtonID="imgPeriodFrom">
                                        </cc1:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-md-4 mb-2">
                        <label for="periodto" class="form-label">Period To </label>
                       <div class="input-group date" id="datepickerTo">
                       <asp:TextBox ID="txtPeriodTo" runat="server" Enabled="true" CssClass="form-control">
                                        </asp:TextBox>
                                        <asp:ImageButton ID="imgPeriodTo" runat="server" CssClass="calendar-block" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                            ImageAlign="Middle" style="border: 1px solid #80808057;" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtPeriodTo"
                                            PopupButtonID="imgPeriodTo">
                                        </cc1:CalendarExtender>
                       </div>
                    </div>
                  
                    <div class="col-md-4 mb-2">
                           <label for="" class="form-label"></label>
                 <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary w-100" Text="Search" UseSubmitBehavior="false" OnClientClick="if(!Validation()) return false;"
                                        OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>


                    <div class="results-section">
                <div class="d-flex justify-content-end mb-2">
                   <asp:ImageButton ID="imgExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                                            Width="40px" Height="40px" AlternateText="Export" ToolTip="Export To Excel" OnClick="imgExportToExcel_Click" />
                </div>
                <div class="table-responsive data-table-container">

                        <asp:GridView runat="server" ID="gvBillEnuiry" CssClass="table table-bordered data-table" AutoGenerateColumns="true" GridLines="Both"
                                                PageSize="5" EmptyDataText="No record found" Visible="true" AllowPaging="True" 
                                                OnPageIndexChanging="gvBillEnuiry_PageIndexChanging" OnRowCommand="gvBillEnuiry_RowCommand">
                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                  PageButtonCount="5" />
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="pager-style" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="table-header-light-blue" />
                              
                                            </asp:GridView>

             
                </div>

             
            </div>

               
      
            <div class="data-table-container" >
             
                </div>

           <%-- <table border="0" cellpadding="0" cellspacing="0" width="100%">

                <tr>
                    <td colspan="4" width="100%">
                        <div id="div2" style="width: 999px; border: 0px black solid;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="text-align: left; width: 15%">
                                        Period From
                                    </td>
                                    <td style="width: 35%;">
                                        <asp:TextBox ID="txtPeriodFrom" runat="server" CssClass="inputbg1"> 
                                        </asp:TextBox>
                                        <asp:ImageButton ID="imgPeriodFrom" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                            ImageAlign="Middle" Height="20px" Width="20px" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPeriodFrom"
                                            PopupButtonID="imgPeriodFrom">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td>
                                        Period To
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPeriodTo" runat="server" Enabled="true" CssClass="inputbg1">
                                        </asp:TextBox>
                                        <asp:ImageButton ID="imgPeriodTo" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                            ImageAlign="Middle" Height="20px" Width="20px" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPeriodTo"
                                            PopupButtonID="imgPeriodTo">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div id="divName" style="display: none;">
                                        </div>
                                    </td>
                                    <td >
                                        <div id="divPeriodTo" style="display: none;">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 20px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center; line-height: 30px;">
                                        <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" ToolTip="Search"
                                            OnClientClick="return Validation()" Text="Search" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png" />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="trExcel" runat="server" visible="false">
                                    
                                    <td colspan="4" style="text-align: right;">
                                        <asp:ImageButton ID="imgExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                                            Width="40px" Height="40px" AlternateText="Export" ToolTip="Export To Excel" OnClick="imgExportToExcel_Click" />
                                       
                                    </td>
                                </tr>
                                <tr id="trGrid" runat="server" visible="true">
                                    <td colspan="4" style="text-align: left;">
                                        <div id="div" style="width: 999px; overflow-x: scroll; overflow-y: scroll; border: 0px black solid;">
                                            <asp:GridView runat="server" ID="gvBillEnuiry" AutoGenerateColumns="true" GridLines="Both"
                                                PageSize="3" EmptyDataText="No record found" Visible="true" AllowPaging="True"
                                                OnPageIndexChanging="gvBillEnuiry_PageIndexChanging" OnRowCommand="gvBillEnuiry_RowCommand">
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
                        
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
            </table>--%>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript" language="javascript">
        function openWindow(code) {
            window.open('PopUpBillEnquiry_cr.aspx?BillNo=' + code, 'popWindow', 'toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=1,width=920,height=540,left = 90,top = 90');
        }
        function openWindowInvoice(code) {
            window.open('../Reports/BillGenerateReport.aspx?BillNo=' + code, 'popWindow', 'toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=1,width=920,height=540,left = 90,top = 90');
        }
        $(function() {
            //$("#div").accordion();
        });
        
        
  function Validation() {
            var Periodfrm = $('#<%=txtPeriodFrom.ClientID %>').val();
          var PeriodTo = $('#<%=txtPeriodTo.ClientID %>').val();
          if (Periodfrm == "" || PeriodTo == "" ) {
                $('#divName').css('display', 'inline');
                $('#divName').html('<span id="DisplayingError" class="DisplayingError">Please enter Period From and To can\'t be Empty </span>');
                $('#<%=txtPeriodFrom.ClientID %>').focus();
                $('#DisplayingError').click(function() { $('#<%=txtPeriodFrom.ClientID %>').focus(); });
                return false;
            }
//            else if ( PeriodTo == "") {
//                $('#divPeriodTo').css('display', 'inline');
//                $('#divPeriodTo').html('<span id="DisplayingError" class="DisplayingError">Please enter Period To can\'t be Empty </span>');
//                $('#<%=txtPeriodTo.ClientID %>').focus();
//                $('#DisplayingError').click(function() { $('#<%=txtPeriodTo.ClientID %>' ).focus(); });
//                return false;
//            }
            else {
                return true;
            }
        }
    </script>
   </div>
    </div>
   </main>
</asp:Content>
