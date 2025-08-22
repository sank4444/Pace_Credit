<%@ Page Language="C#" AutoEventWireup="true" Inherits="BillEnquiry_PopUpBillEnquiry"
    CodeBehind="PopUpBillEnquiry.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Member wise Bill View</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="background-image: url('../App_Themes/Theme/Images/Title_Bg.png'); background-repeat: repeat;
                                        color: #FFFFFF; font-size: 14px; width: 90%;">
                                        Member wise Bill View
                                    </td>
                                    <td>
                                        <img src="../App_Themes/Theme/Images/Title_Left.png" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="60%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Client
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtClient" runat="server" CssClass="inputbg"></asp:TextBox>
                                    </td>
                                    <td>
                                        Policy No.
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolicyNo" runat="server" CssClass="inputbg"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sub Officce
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSubOffice" runat="server" CssClass="inputbg"></asp:TextBox>
                                    </td>
                                    <td>
                                        Bill No.
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBillNo" runat="server" CssClass="inputbg"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: right; float: right;">
                            <asp:ImageButton ID="ImgBtnExportToExcel" runat="server" ImageUrl="~/App_Themes/Theme/Images/Export.png"
                                Height="45px" Width="45px" ToolTip="Export to excel" OnClick="ImgBtnExportToExcel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UPInsured" runat="server">
                                <ContentTemplate>
                                    <asp:GridView runat="server" ID="gvExportgridid" Width="100%" AutoGenerateColumns="true"
                                        PageSize="10" EmptyDataText="No Records Found" Visible="false" AllowPaging="True"
                                        OnPageIndexChanging="gvExportgridid_PageIndexChanging">
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                            PageButtonCount="3" />
                                        <EmptyDataRowStyle BorderWidth="0px" VerticalAlign="Middle" Height="20px" Wrap="False" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <Columns>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="ImgBtnExportToExcel" />
                                </Triggers>
                            </asp:UpdatePanel>
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
</body>
</html>
