<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="COpyPolicySubOfficeAccess_cr.aspx.cs"
    MasterPageFile="~/Masters/MenuMasterPage_Cr.master" Inherits="PACE.CreditLifeInformation.COpyPolicySubOfficeAccess_cr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="App_Themes/Theme/StyleSheets/gw_style.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg==" crossorigin="anonymous" referrerpolicy="no-referrer" /> <!-- Added Font Awesome -->
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link href="App_Themes/Theme/StyleSheets/navigation_style.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Theme/StyleSheets/cards_style.css" rel="stylesheet" type="text/css" />

    <script src="https://code.jquery.com/jquery-1.12.3.js" type="text/javascript"></script>

    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>

    <style type="text/css">
        .dataTables_length
        {
            color: #ffffff;
        }
         @media (max-width: 780px) {
            .policysuboff {
                padding: 30px 20px;
            }

            .logo {
                width: 120px;
                max-height: 40px;
            }

            .policysuboff h2 {
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

    <script type="text/javascript">
        $(document).ready(function() {
            displayingGrid();
        });

        function displayingGrid() {
            $('.display').DataTable({
                "scrollCollapse": true,
                "order": [[0, "desc"]],
                "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
                "columnDefs":
                 [{
                     "targets": 0,
                     "sorting": false,
                     "orderable": false}]
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server" >
    <main class="dashboard-main">
        <div class="policysuboff">
   <div class="content-area">
       <h2 class="page-title">Policy selection</h2>
        <div class="data-table-container">

                <div class="table-controls">

                    <div class="show-entries" style="display: flex; flex-wrap: wrap;">

                        <label for="entries">Show </label>

                        <asp:DropDownList ID="entries" runat="server" AutoPostBack="true" OnSelectedIndexChanged="entries_SelectedIndexChanged">
                         <asp:ListItem Value="5">5</asp:ListItem>
                         <asp:ListItem Value="10">10</asp:ListItem>
                         <asp:ListItem Value="25">25</asp:ListItem>
                         <asp:ListItem Value="50">50</asp:ListItem>
                         </asp:DropDownList>

                        <label for="entries"> entries</label>

                    </div>

                    <div class="search-box" style="display: flex; flex-wrap: wrap;">

                        <label for="search">Search:</label>

                        <%--<input type="search" id="search" name="search">--%>
                        <asp:TextBox runat="server" ID ="search" AutoPostBack="true" OnTextChanged="search_TextChanged"></asp:TextBox>
                    </div>

                </div>
                </div>
        
                <%--<div id="div3" style="width:99%; border: 0px black solid;">--%>
                    <div class="data-table-container">
                    <asp:GridView ID="gvPolAccess" runat="server" CssClass="data-table" OnRowCommand="gvPolAccess_RowCommand"
                        Width="100%" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPreRender="gvPolAccess_PreRender">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <HeaderStyle CssClass=".GridViewHeaderStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <Columns>
                            <asp:BoundField DataField="UserClientUnitUID" HeaderText="ServicingRequestUID" Visible="false" />
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelectPolicy" runat="server" Text="Select" CommandName="Select"
                                        ToolTip="Select Policy" CommandArgument='<%#Eval("UserClientUnitUID")%>'></asp:LinkButton>
                                    <asp:HiddenField ID="hndSelectedFlag" runat="server" Value='<%#Eval("SelectedFlag")%>' />
                                    <asp:HiddenField ID="hndPolSubStatusName" runat="server" Value='<%#Eval("PolSubStatusName")%>' />
                                    <asp:HiddenField ID="hndDisplayMessage" runat="server" Value='<%#Eval("DisplayMessage")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClientCode" HeaderText="Client Code" HeaderStyle-Width="20%" />
                            <asp:BoundField DataField="ClientName" HeaderText="Client Name" HeaderStyle-Width="45%" />
                            <asp:BoundField DataField="PolicyNumber" HeaderText="Policy Number" HeaderStyle-Width="35%" />
                        </Columns>
                    </asp:GridView>
                </div>
  </div>
  </div>
  </main>
</asp:Content>
