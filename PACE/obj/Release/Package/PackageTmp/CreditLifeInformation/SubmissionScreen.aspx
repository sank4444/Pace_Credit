<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmissionScreen.aspx.cs"
    Inherits="PACE.CreditLifeInformation.Submission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Submission Page</title>
    <link href="../App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Theme/StyleSheets/jquery.dataTables.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <script src="https://code.jquery.com/jquery-1.12.3.js" type="text/javascript"></script>

    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div>
        <table border="0" cellpadding="5" cellspacing="5" width="100%">
            <tr>
                <td style="color: Red">
                    <asp:Label ID="lblFilename" runat="server" Text=""></asp:Label>
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
                    <asp:LinkButton ID="OnLnkUpload" runat="server" OnClick="OnLnkUpload_Click" Style="background-color: Navy;
                        font-size: x-large" Font-Underline="False">Upload</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="OnLnkDownload" runat="server" OnClick="OnLnkDownload_Click" Style="background-color: Navy;
                        font-size: x-large" Font-Underline="False">Download</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
