<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage.master" AutoEventWireup="true"
    Inherits="OnlineRequest_OnlineRequest" Title="Untitled Page" CodeBehind="~/OnlineRequest/OnlineRequest.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" class="table" width="100%">
            <tr>
                <th class="strip-title" colspan="4" valign="top">
                    Email Us
                </th>
            </tr>
            <tr>
                <td class="EmptyCell">
                </td>
            </tr>
            <tr>
                <td style="width: 100%;">
                    <table cellpadding="0" cellspacing="0" border="0" class="table" width="100%">
                        <tr>
                            <td colspan="4" style="font-size: smaller; font-weight: bold;">
                                Questions?Suggestions?More Information? Just drop in a quick email and We'll get
                                back to you.
                            </td>
                        </tr>
                        <tr>
                            <td class="EmptyCell">
                            </td>
                        </tr>
                        <tr>
                            <td class="DisplayTable">
                                Subject
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server" TabIndex="0"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="DisplayTable">
                                Description
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="50px"
                                    Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="EmptyCell">
                            </td>
                        </tr>
                        <tr>
                            <td class="DisplayTable">
                                Attachment
                            </td>
                            <td>
                                <asp:FileUpload ID="fuAttachment" runat="server" TabIndex="2" Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="EMptyCell">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnUpload" runat="server" TabIndex="3" CausesValidation="false" Text="Upload" CssClass="upload_input"
                                    Width="150px" OnClick="btnUpload_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
