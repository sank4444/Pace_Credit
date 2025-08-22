<%@ Page Language="C#" MasterPageFile="~/Masters/Copy of MenuMasterPage_Cr.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PACE.CreditLifeInformation.WebForm1" Title="Untitled Page" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<body>
        <form id="form1" runat="server">
        <div>
          <table  border="0" cellpadding="5" cellspacing="5" style="width: 98%">
                <tr>
                    <td>
                        <asp:Label ID="lblFilename" runat="server" Text="Browse:"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="fileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="OnLnkUpload" runat="server" OnClick="OnLnkUpload_Click" Font-Underline="False">Upload</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="OnLnkDownload" runat="server" OnClick="OnLnkDownload_Click" Font-Underline="False">Download</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </body>
</asp:Content>
