<%@ Page Language="C#" MasterPageFile="~/Masters/MenuMasterPage_Cr.Master" AutoEventWireup="true"
    CodeBehind="Contactus_cr.aspx.cs" Inherits="PACE.ContactUs.Contactus_cr" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
        <tr>
            <th class="strip-title" colspan="3" valign="top">
                Contact us
            </th>
        </tr>
        <tr>
            <td>
                For any enquiries please
            </td>
        </tr>
       
        <tr>
            <td>
                <img src="../App_Themes/Theme/Images/New/message.png" height="10px" width="10px"
                    alt="Number" />
                write to us on <a href="mailto:csindia@tataaia.com">csindia@tataaia.com</a>
            </td>
        </tr>
         <tr>
            <td>
               <%-- <img src="../App_Themes/Theme/Images/New/Phone.png" height="10px" width="10px" alt="Number" />
                Operations and Sales/ Service Manager contact nos. 022-66479097 (Narendra Ghag)
                or--%>
            </td>
        </tr>
        <tr>
            <td>
               <%-- <img src="../App_Themes/Theme/Images/New/message.png" height="10px" width="10px"
                    alt="Number" />
                Escalation (Sales & Operations) matrix - Narendra Ghag / CC – Vinod More <a href="mailto:csindia@tataaia.com">
                    csindia@tataaia.com</a>--%>
            </td>
        </tr>
    </table>
</asp:Content>
