<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="AllMember.aspx.cs" Inherits="PACE.MemberInformation_cr.AllMember"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

    <script src="../App_Themes/Theme/StyleSheets/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="../Scripts/windowshowmodaldialog.js" type="text/javascript"></script>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
    <script language="javascript" type="text/javascript">
    $(document).ready(function () {
    
        $("[id*=chkHeader]").live("click", function () {
            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    $("td", $(this).closest("tr")).addClass("selected");
                } else {
                    $(this).removeAttr("checked");
                    $("td", $(this).closest("tr")).removeClass("selected");
                }
            });
        });
    
         
    });
    </script>
   
    <script type="text/javascript">
     function HideImage(url)
     {
       $('#progessImage').hide();
       window.location.href=url;
     }   
    </script>

    <%--   <script language="javascript" type="text/javascript">
        var isChrome = !!window.chrome && !!window.chrome.webstore;
        $(document).ready(function () {
            if (isChrome) {
                window.showModalDialog = ChromePopup;
            }
        });
        function reloadPage(returnValue) {
            var timer = setInterval(function () {
                if (returnValue.closed) {
                    clearInterval(timer);
                    this.window.location.reload();
                }
            }, 1000);
        }
        function RefreshParent(isRefresh) {
            if (isChrome) {
                window.showModalDialog.refreshParent = isRefresh;
            }
        }
    
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="strip-title" colspan="4" valign="top">
                Download COI
            </td>
        </tr>
        <tr>
            <td colspan="4" style="width: 100%;">
                <div id="div3" style="width: 99%; border: 0px black solid;">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <%-- width="100%"--%>
                        <%--   <tr>
                            <td style="text-align: left; width: 15%">
                                Name
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtName" runat="server" CssClass="inputbg1">
                                </asp:TextBox>
                            </td>
                            <td style="width: 15%;">
                                Certificate No.
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtCoiNo" runat="server" CssClass="inputbg1">
                                </asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="text-align: left; width: 15%">
                                From Date
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtdateFrom" runat="server" CssClass="inputbg1"> 
                                </asp:TextBox>
                                <asp:ImageButton ID="imgPeriodFrom" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                    ImageAlign="Middle" Height="20px" Width="20px" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdateFrom"
                                    PopupButtonID="imgPeriodFrom">
                                </cc1:CalendarExtender>
                            </td>
                            <td>
                                TO Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtdateTo" runat="server" Enabled="true" CssClass="inputbg1">
                                </asp:TextBox>
                                <asp:ImageButton ID="imgPeriodTo" runat="server" ImageUrl="~/App_Themes/Theme/Images/Calendar.png"
                                    ImageAlign="Middle" Height="20px" Width="20px" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdateTo"
                                    PopupButtonID="imgPeriodTo">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%;">
                                Certificate No.
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtCoiNo" runat="server" CssClass="inputbg1">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 15%">
                            </td>
                            <td style="width: 35%;">
                            </td>
                        </tr>
                        <%-- OnClientClick="return Validation()" --%>
                          <tr>
                            <td colspan="4" style="height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left: 190px; text-align: right;">
                                <asp:ImageButton ID="btnSearchCOI" runat="server" ToolTip="Search" OnClick="btnSearchCOI_Click"
                                    Text="Search" ImageUrl="~/App_Themes/Theme/Images/btn_Search.png" />
                                &nbsp;
                            </td>
                          
                            <td colspan="2">
                                <asp:ImageButton ID="btnDownload" runat="server" ToolTip="Download" OnClick="DownloadFiles"
                                    Text="Download" ImageUrl="~/App_Themes/Theme/Images/btn_Download.png" />
                                &nbsp;
                            </td>
                           
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="divName" style="display: none;">
                                </div>
                            </td>
                        </tr>
                        <%-- <tr>
                            <td colspan="4" style="text-align: center; width: 100%">
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search_button"
                                    TabIndex="0" ToolTip="Search" OnClientClick="return Validation()" Height="29px" />
                            </td> 
                        </tr>--%>
                        <%--onrowcommand="gvAllMembeInfo_RowCommand"--%>
                        <tr>
                            <td colspan="4" style="height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label Style="width: 10px;" ID="lbl" runat="server"></asp:Label>
                                <asp:GridView ID="gvAllMembeInfo" runat="server" AllowPaging="false" GridLines="None"
                                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="gvAllMembeInfo_PageIndexChanging"
                                    DataKeyNames="PolicyMemberUID" PagerSettings-Mode="NumericFirstLast">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <%--  <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        PageButtonCount="3" />--%>
                                        
                                    <Columns>
                                    
                                        <%--  <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Select Data" ItemStyle-Width="10%">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkHeader" runat="server" />
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkView" runat="server" CausesValidation="False" CommandName="View"
                                                    Height="35px" Width="35px" ImageUrl="~/App_Themes/Theme/Images/View.png" ToolTip="Click to view member information details"
                                                    OnClientClick='<%# Eval("PolicyMemberUID","javascript: return popUp({0})") %>'
                                                    CommandArgument='<% #Eval("PolicyMemberUID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EmployeeNo" HeaderText="Loan Reference No" />
                                        <asp:BoundField DataField="InsuredName" HeaderText="Insured Name" />
                                        <asp:BoundField DataField="COI" HeaderText="COI No" />
                                        <%--<asp:BoundField DataField="Benefit_Coverage" HeaderText="Benefit Coverage" />--%>
                                        <%--<asp:BoundField DataField="EffectiveDateOfCoverage" HeaderText="Issued Date" />--%>
                                        <%--<asp:TemplateField HeaderText="Issued Date">
                                            <ItemTemplate>
                                                <%#Eval("EffectiveDateOfCoverage", "{0:dd-MM-yyyy}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <%-- <asp:BoundField DataField="PolicyYear" HeaderText="Policy Year" />--%>
                                    </Columns>
                                </asp:GridView>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td id="tdGrid" colspan="4" visible="true" runat="server">
                                <div style="overflow-x: auto; overflow-x: scroll; overflow-y: scroll; width: 99%;">
                                    <%--500px--%>
                                    <asp:Label ID="lblResult" runat="server" Visible="false" Text="No Record Found" ForeColor="red">
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        function popUp(PolicyMemberUID) {
             
             var clients = '<%= clientsCOIDwn %>';
             var strOpen = clients + PolicyMemberUID ;
              alert(strOpen);
             window.open(strOpen, 'popWindow', 'toolbar=0,titlebar=0,scrollbars=1,location=0,statusbar=0,status=1,fullscreen=0,menubar=0,resizable=1,width=920px,height=600px,left = 200,top = 100');
            __doPostBack('', '');
             
             // var hv = $('hdnCOILINK').val();  alert($('input#foo').val());
             // var valueURL =  $("#hdnCOILINK").val();  
             //var strOpen = "http://192.168.1.57:208/PDF_cr.aspx?PolicyMemberUID=" + PolicyMemberUID;
             //document.getElementById('#hdntxtbxTaksit');
             //var myHidden = $("#hdntxtbxTaksit").val(); // document.getElementById("hdntxtbxTaksit");$('#h_v').val();
             //alert( document.getElementById('#hdntxtbxTaksit'));
             //var strOpen = "http://192.168.1.57:313/Credit_Life_COI.aspx?PolicyMemberUID=" + PolicyMemberUID;
        }
    </script>

    <%--
 <script type="text/javascript">
    function GetSelected() {
        //Reference the GridView.
        var grid = document.getElementById("<%=gvAllMembeInfo.ClientID%>");
 
        //Reference the CheckBoxes in GridView.
        var checkBoxes = grid.getElementsByTagName("INPUT"); 
        var message = "PolicyMemberUID\n";
       
 
        //Loop through the CheckBoxes. chkSelect checkBoxes
        for (var i = 1; i < checkBoxes.length; i++) {
            if (checkBoxes[i].checked) {
           
                var row = checkBoxes[i].parentNode.parensstNode;
//                alert("DFFDFDFDF"+ checkBoxes[i] )
                message += row.cells[1].innerHTML;
               // message += "   " + row.cells[2].innerHTML;
                //message += "   " + row.cells[3].innerHTML;
                message += "\n";
            }
        }
 
        //Display selected Row data in Alert Box.
        alert(message);
        return false;
    }
</script>--%>
</asp:Content>
