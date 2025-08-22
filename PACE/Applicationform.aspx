<%@ Page Language="C#"    AutoEventWireup="true" CodeBehind="Applicationform.aspx.cs" Inherits="PACE.Applicationform" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

   
    <title>ApplicationForm</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }

        /* Navbar styles */
        .navbar {
            width: 100%;
            background-color: #4CAF50;
            color: white;
            padding: 15px 20px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            position: fixed;
            top: 0;
            left: 0;
            box-sizing: border-box;
            z-index: 1001;
            cursor: pointer;
        }

        .navbar .brand {
            font-size: 20px;
            font-weight: bold;
        }

        .navbar a {
            color: white;
            text-decoration: none;
            margin-left: 20px;
        }

        /* Sidebar styles */
        .sidebar {
            height: 100vh;
            width: 250px;
            background-color: #333;
            color: white;
            transition: all 0.3s ease;
            padding: 20px;
            box-sizing: border-box;
            position: fixed;
            top: 60px;
            /* Below the navbar */
            overflow-y: auto;
        }

        .sidebar.hide {
            width: 0;
            padding: 0;
            overflow: hidden;
        }

        .accordion {
            cursor: pointer;
            padding: 10px;
            font-size: 16px;
            border-bottom: 1px solid #575757;
            text-transform: uppercase;
        }

        .accordion:hover {
            background-color: #575757;
        }

        .panel {
            display: none;
            padding-left: 10px;
            overflow: hidden;
        }

        .panel.show {
            /* Class to show the panel */
            display: block;
        }

        .panel a {
            display: block;
            padding: 8px;
            color: white;
            text-decoration: none;
            border-bottom: none;
        }

        .panel a:hover {
            background-color: #575757;
        }

        /* Main content styles */
        .main-content {
            margin-left: 250px;
            padding: 80px 20px 20px;
            /* Top padding for navbar space */
            transition: margin-left 0.3s ease;
            flex-grow: 1;
        }

        .main-content.full {
            margin-left: 0;
        }

        /* Search bar styles */
        #search {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            box-sizing: border-box;
        }

        .form-container {
            background-color: white;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 978px;
        }

        .form-title {
            text-align: center;
            margin-bottom: 24px;
            font-size: 24px;
            color: #3f51b5;
        }

        .form-group {
            position: relative;
            margin-bottom: 24px;
        }

        .form-group label {
            position: absolute;
            top: 10px;
            left: 10px;
            color: #757575;
            transition: 0.3s ease-out;
            pointer-events: none;
            font-size: 16px;
        }

        .form-group input,
        .form-group select {
            width: 100%;
            padding: 10px 10px 10px 10px;
            border: none;
            border-bottom: 2px solid #ccc;
            outline: none;
            font-size: 16px;
            background: transparent;
            transition: border-bottom 0.3s;
        }

        .form-group input:focus,
        .form-group select:focus {
            border-bottom: 2px solid #3f51b5;
        }

        .form-group input:focus+label,
        .form-group input:valid+label,
        .form-group select:valid+label {
            top: -14px;
            font-size: 12px;
            color: #3f51b5;
        }

        .radio-group,
        .button-group {
            margin-bottom: 24px;
        }

        .radio-group label {
            margin-right: 20px;
            font-size: 16px;
            color: #555;
            cursor: pointer;
        }

        .radio-group input {
            margin-right: 8px;
        }

        .button {
            width: 100%;
            background-color: #3f51b5;
            color: white;
            border: none;
            padding: 14px;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .button:hover {
            background-color: #303f9f;
        }

        select {
            appearance: none;
            background: transparent;
            padding: 10px 5px;
            cursor: pointer;
        }

           .form-group::after {
            content: "";
            position: absolute;
            right: 10px;
            top: 12px;
            color: #757575;
            pointer-events: none;
        }

        .selectTab::after {
    content: "▼";
   /* position: absolute;*/
   position:relative;
    right: 10px;
    top: 12px;
    color: #757575;
    pointer-events: none;
}

        .row {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            /* Adds space between columns */
        }

        .col-6 {
            flex: 0 0 calc(40% - 20px);
            /* Ensures two items per row, with space between */
            box-sizing: border-box;
        }
    </style>
</head>
<body>
    <div class="navbar" id="navbar">
        <div class="brand" id="dashboardTitle">Application Form</div>
       
    </div>

    <form id="form1" runat="server" style="margin-top: 50px; padding: 30px">
        <div>
            <h3 style="color: #3498db;">Ex- Details</h3>
            <hr />
            <br />
            <asp:label  ID="LabelClientcode" style="font-size:12px;" runat="server" Visible="false"></asp:label>
            <asp:label  ID="LabelPolicyNumber" style="font-size:12px;" runat="server" Visible="false"></asp:label>

            <!-- Client Name and Policy Number Dropdowns Side by Side -->
            <div>
                            <div class="form-group selectTab">
                            <asp:DropDownList ID="DdlClient" runat="server"  Width="30%" required="true" AutoPostBack="true" OnSelectedIndexChanged="DdlClient_SelectedIndexChanged" ValidationGroup="vgAccountingView" DataTextField="ClientName" DataValueField="ClientUID" style="font-size:12px;">
                </asp:DropDownList>
                </div>
                <div class="form-group selectTab">
                <asp:DropDownList ID="DdlPolicyNo" runat="server"  Width="30%" required="true" AutoPostBack="true" ValidationGroup="vgAccountingView" DataTextField="PolicyNumber" DataValueField="PolicyNumber">
                </asp:DropDownList>
            </div>
            </div>
            <h3 style="color: #3498db;">Channel- Details</h3>
            <hr />
            <br />
            <div>

                    <div class="form-group"> 
                <label for="TxtSMSBranchCode" style="font-size:12px;">SMS Branch Code </label><br />  <%--alphanum---%>
                &nbsp;<asp:TextBox ID="TxtSMSBranchCode" runat="server" Width="30%" required="true"></asp:TextBox>
                    </div>

                  <div class="form-group">
                  <label for="TxtSMSLgCode" style="font-size:12px;">SMS Lg Code</label><br /> <%--alphanum---%> 
                &nbsp;<asp:TextBox ID="TxtSMSLgCode"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="TxtDsaCode" style="font-size:12px;">Dsa Code</label><br />  <%--alphanum---%>
                &nbsp;<asp:TextBox ID="TxtDsaCode"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="TxtBranchCode" style="font-size:12px;">Branch Code</label><br />  <%--alphanum-- and 5 digit only--%>
                &nbsp;<asp:TextBox ID="TxtBranchCode"  runat="server" Width="30%" required="true" MaxLength="5"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="TxtBranchLGCode" style="font-size:12px;">Branch LG Code</label><br /> <%--alphanum---%>
                &nbsp;<asp:TextBox ID="TxtBranchLGCode"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtLoanReferenceId" style="font-size:12px;">Loan Reference Id</label><br />  <%--alphanum---%>
                &nbsp;<asp:TextBox ID="TxtLoanReferenceId"  runat="server" Width="30%" required="true" ></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="TxtLoanAccountNo" style="font-size:12px;">Loan Account No</label><br /> <%--alphanum---%>
                &nbsp;<asp:TextBox ID="TxtLoanAccountNo"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

               <%-- <div class="form-group">
                  <label for="TxtApplicantType">Applicant Type</label><br />
                &nbsp;<asp:TextBox ID="TxtApplicantType"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>--%>

                  <div class="form-group selectTab">
                    <label for="ApplicantTypeDropDownList1" style="font-size:12px;">Applicant Type</label><br />
                <asp:DropDownList ID="ApplicantTypeDropDownList1" runat="server" required="true" style="font-size:12px;" Width="30%" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Applicant Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Staff</asp:ListItem>
                    <asp:ListItem>Non-Staff</asp:ListItem>
                </asp:DropDownList>
                </div>

                 <div class="form-group">
                  <label for="TxtPremiumPaidFromLoan" style="font-size:12px;">Premium Paid From Loan</label><br />
                &nbsp;<asp:TextBox ID="TxtPremiumPaidFromLoan"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtAnnualIncome" style="font-size:12px;">Annual Income</label><br />
                &nbsp;<asp:TextBox ID="TxtAnnualIncome"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                 <div class="form-group">
                  <label for="TxtClientId" style="font-size:12px;">Client Id</label><br /> <%--alphanum--%>
                &nbsp;<asp:TextBox ID="TxtClientId"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="TxtRLFCode" style="font-size:12px;">RLF Code</label><br />
                &nbsp;<asp:TextBox ID="TxtRLFCode"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
            </div>
             <%--<asp:ListItem>select the value</asp:ListItem>--%>
            
            <h3 style="color: #3498db;">Plan Details</h3>
            <hr />
            <br />
            
            <!-- Client Name and Policy Number Dropdowns Side by Side -->
            <div>

                 <div class="form-group">
                  <label for="TxtPlanDLoanAmount" style="font-size:12px;">Loan Amount</label><br />
                &nbsp;<asp:TextBox ID="TxtPlanDLoanAmount"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtSumAssured" style="font-size:12px;">Sum Assured</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssured"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group selectTab">
                    <label for="TxtSelectLoanTypeDropDownList3" style="font-size:12px;">Loan Type</label><br />
                <asp:DropDownList ID="TxtSelectLoanTypeDropDownList3" runat="server" required="true" Width="30%" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Loan Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem Value="HL">Home Loan</asp:ListItem>
                     <asp:ListItem Value="pL">Personal Loan</asp:ListItem>
                     <asp:ListItem Value="EL">Educational Loan</asp:ListItem>
                     <asp:ListItem Value="AL">Vehicle Loan</asp:ListItem>
                     <asp:ListItem Value="BL">Business Loan</asp:ListItem>
                     <asp:ListItem Value="GL">Gold Loan</asp:ListItem>
                     <asp:ListItem Value="4">Agriculture loan</asp:ListItem>
                     <asp:ListItem Value="SHL">Staff housing loan</asp:ListItem>

                                          
                </asp:DropDownList>
                </div>
                <div class="form-group">
                  <label for="TxtPlandLoanInterestRate" style="font-size:12px;">Loan Interest Rate</label><br />
                &nbsp;<asp:TextBox ID="TxtPlandLoanInterestRate"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group selectTab">
                       <label for="SelectStaffDropDownList4" style="font-size:12px;">Staff</label><br />
                <asp:DropDownList ID="SelectStaffDropDownList4" runat="server" required="true" Width="30%" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                   <asp:ListItem Text="Select Staff" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="true">Yes</asp:ListItem>
                    <asp:ListItem Value="false">No</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group selectTab">
                       <label for="PremiumTypeDropDownList5" style="font-size:12px;">Premium Type</label><br />
                <asp:DropDownList ID="PremiumTypeDropDownList5" runat="server" required="true" Width="30%" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Premium Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="SP">Single</asp:ListItem>
                    <asp:ListItem Value="RP">Regular</asp:ListItem>
                    <asp:ListItem Value="LP">Limited</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group selectTab">
                        <label for="SumAssuredTypeDropDownList6" style="font-size:12px;">Sum Assured Type</label><br />
                <asp:DropDownList ID="SumAssuredTypeDropDownList6" runat="server" required="true" Width="30%" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Sum Assured Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Reducing Term</asp:ListItem>
                    <asp:ListItem>Level Term</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group selectTab">
                        <label for="InsuranceTypeDropDownList7" style="font-size:12px;">Insurance Type</label><br />
                <asp:DropDownList ID="InsuranceTypeDropDownList7" runat="server" required="true" Width="30%" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Insurance Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Employer-Employee</asp:ListItem>
                    <asp:ListItem>Non Employer-Employee</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group selectTab">
                        <label for="BenifitCoverageDropDownList8" style="font-size:12px;">Benifit Coverage</label><br />
                <asp:DropDownList ID="BenifitCoverageDropDownList8" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Benifit Coverage" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>001</asp:ListItem>
                    <asp:ListItem>002</asp:ListItem>
                    <asp:ListItem>003</asp:ListItem>
                    <asp:ListItem>004</asp:ListItem>
                    <asp:ListItem>005</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group selectTab">
                        <label for="PaymentFrequencyDropDownList9" style="font-size:12px;">Payment Frequency</label><br />
                <asp:DropDownList ID="PaymentFrequencyDropDownList9" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <asp:ListItem Text="Select Payment Frequency" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="0">Single</asp:ListItem>
                    <asp:ListItem Value="1">Yearly</asp:ListItem>
                     <asp:ListItem Value="4">Quarterly</asp:ListItem>
                    <asp:ListItem Value="2">Half Yearly</asp:ListItem> 
                    <asp:ListItem  Value="12">Monthly</asp:ListItem>    
                </asp:DropDownList> 
                </div>

                 <div class="form-group selectTab">
                        <label for="DeathOptionDropDownList10" style="font-size:12px;">Death Option</label><br />
                <asp:DropDownList ID="DeathOptionDropDownList10" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Death Option" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Lumpsum</asp:ListItem>
                    <asp:ListItem>Income</asp:ListItem>
                </asp:DropDownList>
                </div>
                 <%--  <div class="form-group"> 
              
                 <asp:TextBox ID="TextBox3" placeholder="Enter DSA Code" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox4" placeholder="Enter Branch Code" runat="server"></asp:TextBox>
            </div>--%>
                  
                 <div class="form-group selectTab">
                        <label for="DeathOptionIncomeYearsDropDownList12" style="font-size:12px;">Death Option Income Yrs</label><br />
                <asp:DropDownList ID="DeathOptionIncomeYearsDropDownList12" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Death Option Income Years" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                      <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                      <asp:ListItem>1</asp:ListItem>
                </asp:DropDownList>
                </div>

                 <div class="form-group">
                  <label for="TxtPlanDetPolicyTerm" style="font-size:12px;">Policy Term</label><br />
                &nbsp;<asp:TextBox ID="TxtPlanDetPolicyTerm"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                   <div class="form-group selectTab">
                  <label for="TxtPlanDetPolicyTerm" style="font-size:12px;">Premium Paying Term</label><br />
                <asp:DropDownList ID="PremiumPayingTermDropDownList13" runat="server" required="true" style="font-size:12px;" Width="30%" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Premium Paying Term" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Single</asp:ListItem>
                    <asp:ListItem>Yearly</asp:ListItem>
                     <asp:ListItem>Quarterly</asp:ListItem>
                    <asp:ListItem>Half Yearly</asp:ListItem> 
                    <asp:ListItem>Monthly</asp:ListItem>    
                    <asp:ListItem>3-Years</asp:ListItem>
                </asp:DropDownList>
                </div>

                 <div class="form-group selectTab">
                  <label for="MoratoriumPeriodDropDownList14" style="font-size:12px;">Moratorium Period</label><br />
                <asp:DropDownList ID="MoratoriumPeriodDropDownList14" runat="server" required="true" style="font-size:12px;" Width="30%" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Moratorium Period" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group selectTab">
                  <label for="InterestDuringMoratoriumPeriodDropDownList15" style="font-size:12px;">Interest During Moratorium Period</label><br />

                <asp:DropDownList ID="InterestDuringMoratoriumPeriodDropDownList15" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Interest During Moratorium Period" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group selectTab">
                  <label for="DropDownList16" style="font-size:12px;">Application Type</label><br />
                <asp:DropDownList ID="DropDownList16" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Application Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Single</asp:ListItem>
                    <asp:ListItem>Joint</asp:ListItem>
                </asp:DropDownList>
                </div>

                    <div class="form-group selectTab">
                  <label for="DropDownList17" style="font-size:12px;">Number of Applicants</label><br />
                <asp:DropDownList ID="DropDownList17" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Number of Applicants" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
                </div>

                    <div class="form-group selectTab">
                  <label for="BenifitOptionDropDownList18" style="font-size:12px;">Benifit Option</label><br />
                <asp:DropDownList ID="BenifitOptionDropDownList18" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Benifit Option" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Reducing Term</asp:ListItem>
                    <asp:ListItem>Level Term</asp:ListItem>
                </asp:DropDownList>
                </div><br />
            </div>
            <div>
                <h6>Note: Please check if Under Insurance Declaration form has been provided and enter correct ?Proposed Loan Amount? and ?Proposed Insured Term?.</h6>


            </div>
            <h3 style="color: #3498db;">Insurance and Loan Details</h3>
            <hr />
            <br />

             <div>
                   <div class="form-group">
                  <label for="TxtLoanRefId" style="font-size:12px;">Loan Ref Id</label><br />
                &nbsp;<asp:TextBox ID="TxtLoanRefId"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtLoanType" style="font-size:12px;">Loan Type</label><br />
                &nbsp;<asp:TextBox ID="TxtLoanType" value="PL" runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab">
                  <label for="NewLoanDropDownList19" style="font-size:12px;">New Loan</label><br />
                <asp:DropDownList ID="NewLoanDropDownList19" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select New Loan" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group">
                  <label for="TxtOldLoanAccountNumber" style="font-size:12px;">Old Loan Account Number</label><br />
                &nbsp;<asp:TextBox ID="TxtOldLoanAccountNumber"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                 <div class="form-group">
                  <label for="TxtLoanAmount" style="font-size:12px;">Loan Amount</label><br />
                &nbsp;<asp:TextBox ID="TxtLoanAmount"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                 <div class="form-group">
                  <label for="TxtLoanTenure" style="font-size:12px;">Loan Tenure</label><br />
                &nbsp;<asp:TextBox ID="TxtLoanTenure"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                   <div class="form-group selectTab">
                  <label for="StaffDropDownList20" style="font-size:12px;">Staff</label><br />
                <asp:DropDownList ID="StaffDropDownList20" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Staff" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="true">Yes</asp:ListItem>
                    <asp:ListItem Value="false">No</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group selectTab">
                  <label for="SumAssuredTypeDropDownList21" style="font-size:12px;">Sum Assured Type</label><br />
                <asp:DropDownList ID="SumAssuredTypeDropDownList21" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Sum Assured Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Reducing Term</asp:ListItem>
                    <asp:ListItem>Level Term</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group selectTab">
                  <label for="InsuranceTypeDropDownList22" style="font-size:12px;">Insurance Type</label><br />
                <asp:DropDownList ID="InsuranceTypeDropDownList22" runat="server" required="true"   style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Insurance Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Employer-Employee</asp:ListItem>
                    <asp:ListItem>Non Employer-Employee</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group selectTab">
                  <label for="PremiumPaymentFrequencyDropDownList23" style="font-size:12px;">Premium Payment Frequency</label><br />

                <asp:DropDownList ID="PremiumPaymentFrequencyDropDownList23" runat="server" required="true"  style="font-size:12px;" Width="30%" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Premium Payment Frequency" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem Value="0">Single</asp:ListItem>
                    <asp:ListItem Value="1">Yearly</asp:ListItem>
                     <asp:ListItem Value="4">Quarterly</asp:ListItem>
                    <asp:ListItem Value="2">Half Yearly</asp:ListItem> 
                    <asp:ListItem  Value="12">Monthly</asp:ListItem>  
                </asp:DropDownList>
                </div>

                    <div class="form-group">
                  <label for="TxtLoanInterestRate" style="font-size:12px;">Loan Interest Rate</label><br />
                &nbsp;<asp:TextBox ID="TxtLoanInterestRate"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                
                   <div class="form-group">
                  <label for="TxtSumAssured1stBorrower" style="font-size:12px;">Sum Assured 1st Borrower</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssured1stBorrower"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
                  <div class="form-group">
                  <label for="TxtSumAssured2ndBorrower" style="font-size:12px;">Sum Assured 2nd Borrower</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssured2ndBorrower"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
                  <div class="form-group">
                  <label for="TxtSumAssured3rdBorrower" style="font-size:12px;">Sum Assured 3rd Borrower</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssured3rdBorrower"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
                  <div class="form-group">
                  <label for="TxtSumAssured4thBorrower" style="font-size:12px;">Sum Assured 4th Borrower</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssured4thBorrower"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>



                   <div class="form-group selectTab">
                  <label for="PremiumPaidFromLoanDropDownList28" style="font-size:12px;">Premium Paid From Loan</label><br />

                <asp:DropDownList ID="PremiumPaidFromLoanDropDownList28" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Premium Paid From Loan" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Single</asp:ListItem>
                    <asp:ListItem>Regular</asp:ListItem>
                    <asp:ListItem>Limited</asp:ListItem>

                </asp:DropDownList>
                </div>


                   <div class="form-group selectTab">
                  <label for="BenifitsOptionsDropDownList29" style="font-size:12px;">Benifits options</label><br />

                <asp:DropDownList ID="BenifitsOptionsDropDownList29" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Benifits Options" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Reducing Term</asp:ListItem>
                    <asp:ListItem>Level Term</asp:ListItem>
                </asp:DropDownList>
                </div>

                     <div class="form-group">
                  <label for="TxtAnnualIncomeForPrimaryInsured" style="font-size:12px;">Annual Income For Primary Insured</label>
                &nbsp;<asp:TextBox ID="TxtAnnualIncomeForPrimaryInsured"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtSinglePremiumAnnualPremiumExcludingTaxes" style="font-size:12px;">Single Premium/Annual Premium Excluding Taxes</label>
                &nbsp;<asp:TextBox ID="TxtSinglePremiumAnnualPremiumExcludingTaxes"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab">
                  <label for="DropDownList30" style="font-size:12px;">Death Option</label><br />

                <asp:DropDownList ID="DropDownList30" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Death Option" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Lumpsum</asp:ListItem>
                    <asp:ListItem>Income</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group selectTab">
                  <label for="DropDownList31" style="font-size:12px;">Death Option Income Years</label><br />

                <asp:DropDownList ID="DropDownList31" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Death Option Income Years" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                     <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
                </asp:DropDownList>
                </div>

                 <div class="form-group">
                  <label for="TxtACOwnedBy" style="font-size:12px;">A/C Owned By</label><br />
                &nbsp;<asp:TextBox ID="TxtACOwnedBy" value="Primary" runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtBankAccountHolderName" style="font-size:12px;">Bank Account Holder Name</label><br />
                &nbsp;<asp:TextBox ID="TxtBankAccountHolderName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group">
                  <label for="TxtPolicyTerm" style="font-size:12px;">Policy Term</label><br />
                &nbsp;<asp:TextBox ID="TxtPolicyTerm"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                   <div class="form-group selectTab">
                  <label for="DropDownList32" style="font-size:12px;">Premium Paying Term</label><br />
                <asp:DropDownList ID="DropDownList32" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Premium Paying Term" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Single</asp:ListItem>
                    <asp:ListItem>Regular</asp:ListItem>
                    <asp:ListItem>Limited</asp:ListItem>

                </asp:DropDownList>
                </div>

                 <div class="form-group">
                  <label for="TxtInterestDuringMoratoriumPeriod" style="font-size:12px;">Interest During Moratorium Period</label><br />
                &nbsp;<asp:TextBox ID="TxtInterestDuringMoratoriumPeriod"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TextBox28" style="font-size:12px;">Moratorium Interest</label><br />
                &nbsp;<asp:TextBox ID="TextBox29"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtInstallmentPremiumWithoutTaxes" style="font-size:12px;">Installment Premium Without Taxes</label><br />
                &nbsp;<asp:TextBox ID="TxtInstallmentPremiumWithoutTaxes"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtInstallmentPremiumIncludingTaxes" style="font-size:12px;">Installment Premium Including Taxes </label><br />
                &nbsp;<asp:TextBox ID="TxtInstallmentPremiumIncludingTaxes"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TextBox28" style="font-size:12px;">Installment Premium Including Taxes </label><br />
                &nbsp;<asp:TextBox ID="TextBox32"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
              </div>
              <div class="form-group  col-6">
                  <label for="TxtPremiumPaymentTerm" style="font-size:12px;">Premium Payment Term</label><br />
                &nbsp;<asp:TextBox ID="TxtPremiumPaymentTerm"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
              </div>
            
<%--               <h3 style="color: #3498db;">Other- Details</h3>
            <hr />
            <br />
            <div>
                 <div class="form-group  col-6">
                  <label for="TextBox28">Is First Claim</label><br />
                &nbsp;<asp:TextBox ID="TextBox33"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                <div class="form-group  col-6">
                  <label for="TextBox34">Lab Test Request Form No</label><br />
                &nbsp;<asp:TextBox ID="TextBox34"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox35">Joint Lab Test Request Form No</label><br />
                &nbsp;<asp:TextBox ID="TextBox35"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox36">Lab Test Request Form Code</label><br />
                &nbsp;<asp:TextBox ID="TextBox36"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group  col-6">
                  <label for="TextBox36">Is Spa</label><br />
                &nbsp;<asp:TextBox ID="TextBox37"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group  col-6">
                  <label for="TextBox38">Spa Transction Date</label><br />
                &nbsp;<asp:TextBox ID="TextBox38"  runat="server" Width="30%" required="true" TextMode="Date" ></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TextBox39">Borrower Lab Test Request Form Date</label><br />
                &nbsp;<asp:TextBox ID="TextBox39"  runat="server" Width="30%" required="true" TextMode="Date"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox40">Fi Category</label><br />
                &nbsp;<asp:TextBox ID="TextBox40"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TextBox41">Limited Premium Change</label><br />
                &nbsp;<asp:TextBox ID="TextBox41"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox42">STD</label><br />
                &nbsp;<asp:TextBox ID="TextBox42"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TextBox43">Phone</label><br />
                &nbsp;<asp:TextBox ID="TextBox43"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox44">Client Contact No</label><br />
                &nbsp;<asp:TextBox ID="TextBox44"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TextBox45">Share</label><br />
                &nbsp;<asp:TextBox ID="TextBox45"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox46">Trans ID</label><br />
                &nbsp;<asp:TextBox ID="TextBox46"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group  col-6">
                  <label for="TextBox47">File Path</label><br />
                &nbsp;<asp:TextBox ID="TextBox47"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox48">File Path 1</label><br />
                &nbsp;<asp:TextBox ID="TextBox48"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox49">File Path 2</label><br />
                &nbsp;<asp:TextBox ID="TextBox49"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox50">File Path 3</label><br />
                &nbsp;<asp:TextBox ID="TextBox50"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group  col-6">
                  <label for="TextBox51">File Path 4</label><br />
                &nbsp;<asp:TextBox ID="TextBox51"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox52">Status</label><br />
                &nbsp;<asp:TextBox ID="TextBox52"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                <div class="form-group  col-6">
                  <label for="TextBox53">Payment Mode</label><br />
                &nbsp;<asp:TextBox ID="TextBox53"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
            </div>
            --%>
             <h3 style="color: #3498db;">Quote Details</h3>
            <hr />
            <br />

            <div>

                <div class="form-group  col-6">
                  <label for="TxtSumAssuredForPrimeLife" style="font-size:12px;">Sum Assured For Prime Life</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssuredForPrimeLife"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TxtSumAssuredForSecondLife" style="font-size:12px;">Sum Assured For Second Life</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssuredForSecondLife"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TxtSumAssuredForThirdLife" style="font-size:12px;">Sum Assured For Third Life</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssuredForThirdLife"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TxtSumAssuredForFourthLife" style="font-size:12px;">Sum Assured For Fourth Life</label><br />
                &nbsp;<asp:TextBox ID="TxtSumAssuredForFourthLife"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TxtQuoteDetSingleAnnualPremiumExcludingTaxes"  style="font-size:12px;">Single/Annual Premium Excluding Taxes</label><br />
                &nbsp;<asp:TextBox ID="TxtQuoteDetSingleAnnualPremiumExcludingTaxes"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TxtQuotedetInstallmentPremiumIncludingTaxes"  style="font-size:12px;">Installment Premium Including Taxes</label><br />
                &nbsp;<asp:TextBox ID="TxtQuotedetInstallmentPremiumIncludingTaxes"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TxtQuoteDetInstallmentPremiumExcludingTaxes" style="font-size:12px;">Installment Premium Excluding Taxes</label><br />
                &nbsp;<asp:TextBox ID="TxtQuoteDetInstallmentPremiumExcludingTaxes"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

            </div>

            <h3 style="color: #3498db;">Vernacular Uneducated Details</h3>
            <hr />
            <br />

            <div>

                  <div class="form-group  col-6">
                  <label for="TxtNameOftheDeclarant" style="font-size:12px;">Name Of the Declarant</label><br />
                &nbsp;<asp:TextBox ID="TxtNameOftheDeclarant"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TxtMobileNo" style="font-size:12px;">Mobile No</label><br />
                &nbsp;<asp:TextBox ID="TxtMobileNo"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TxtDeclarantAddress" style="font-size:12px;">Declarant Address</label><br />
                &nbsp;<asp:TextBox ID="TxtDeclarantAddress"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TxtLanguage" style="font-size:12px;">Language</label><br />
                &nbsp;<asp:TextBox ID="TxtLanguage"  runat="server" Width="30%" required="true"></asp:TextBox>
                      </div>

                        <div class="form-group  col-6">
                  <label for="TxtSingleAnnualPremiumExcludingTaxes" style="font-size:12px;">Single/Annual Premium Excluding Taxes</label><br />
                &nbsp;<asp:TextBox ID="TxtSingleAnnualPremiumExcludingTaxes"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                    <div class="form-group  col-6">
                  <label for="TxtInstallmentPremiumExcludingTaxes" style="font-size:12px;">Installment Premium Excluding Taxes</label><br />
                &nbsp;<asp:TextBox ID="TxtInstallmentPremiumExcludingTaxes"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                      <div class="form-group  col-6">
                  <label for="TxtVCInstallmentPremiumIncludingTaxes"  style="font-size:12px;">Installment Premium Including Taxes</label><br />
                &nbsp;<asp:TextBox ID="TxtVCInstallmentPremiumIncludingTaxes"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

            </div> 
            
            <h3 style="color: #3498db;">Ecs Details</h3>
            <hr />
            <br />

            <div>
                 <div class="form-group  col-6">
                  <label for="TxtUMRNNumber" style="font-size:12px;">UMRN Number</label><br />
                &nbsp;<asp:TextBox ID="TxtUMRNNumber"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                 <div class="form-group  col-6">
                  <label for="TxtSponserBankCode" style="font-size:12px;">Sponser Bank Code</label><br />
                &nbsp;<asp:TextBox ID="TxtSponserBankCode"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                 <div class="form-group  col-6">
                  <label for="TxtUtilityCode" style="font-size:12px;">Utility Code</label><br />
                &nbsp;<asp:TextBox ID="TxtUtilityCode"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                 <div class="form-group  col-6">
                  <label for="TxtApplicationNumber"  style="font-size:12px;">Application Number</label><br />
                &nbsp;<asp:TextBox ID="TxtApplicationNumber"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                 <div class="form-group  col-6">
                  <label for="TxtECSBankName"  style="font-size:12px;">Bank Name</label><br />
                &nbsp;<asp:TextBox ID="TxtECSBankName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab col-6">
                  <label for="AccountTypeDropDownList33"  style="font-size:12px;">Account Type</label><br />

                <asp:DropDownList ID="AccountTypeDropDownList33" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Account Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Single</asp:ListItem>
                    <asp:ListItem>Limited</asp:ListItem>
                </asp:DropDownList>
                </div>

                
                 <div class="form-group  col-6">
                  <label for="TxtIFSCCode" style="font-size:12px;">IFSC Code</label>
                &nbsp;<asp:TextBox ID="TxtIFSCCode"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                
                 <div class="form-group  col-6">
                  <label for="TxtMICRCODE"  style="font-size:12px;">MICR CODE</label><br />
                &nbsp;<asp:TextBox ID="TxtMICRCODE"  runat="server" Width="30%" required="true" ></asp:TextBox>
                  </div>

                 <div class="form-group selectTab col-6">
                  <label for="DebitTypeDropDownList34"  style="font-size:12px;">Debit Type</label><br />

                <asp:DropDownList ID="DebitTypeDropDownList34" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Debit Type" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                </div>

                 <div class="form-group selectTab col-6">
                  <label for="FrequencyDropDownList35"  style="font-size:12px;">Frequency</label><br />

                <asp:DropDownList ID="FrequencyDropDownList35" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Frequency" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                </div>

                        <div class="form-group selectTab col-6">
                  <label for="DropDownList36"  style="font-size:12px;">Period</label><br />
                                              
                <asp:DropDownList ID="DropDownList36" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select Period" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                </div>
                </div>

            <%--<p style="color: #3498db;">File Attachment</p>--%>
            <%--<hr />--%>
            <%--<br />--%>
             <%--<h2 style="color: #3498db;">Upload a File</h2>--%>
             <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
            <%--<br /><br />--%>

             <h3 style="color: #3498db;">Personal Details of Life Assured</h3>
            <hr />
            <br />
         
            <div>

                <div class="form-group selectTab">
                <asp:DropDownList ID="PD1SalutationDropDownList37" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                     <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Mrs</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group">
                  <label for="Txt1perDetFirstName"  style="font-size:12px;">First Name</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetFirstName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="Txt1perDetMiddleName" style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetMiddleName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt1perDetLastName" style="font-size:12px;">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetLastName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group selectTab col-6">
                <asp:DropDownList ID="PdDet1_Gender_DropDownList38" runat="server" required="true"   style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group  col-6">
                  <label for="Txt1perDetDateofBirth" style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetDateofBirth"  runat="server" Width="30%" required="true" TextMode="Date"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetAge" style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetAge"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetEmail" style="font-size:12px;">Email</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetEmail"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetMobileNo" style="font-size:12px;">Mobile No</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetMobileNo"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetPanNumber"  style="font-size:12px;">Pan Number</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetPanNumber"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetOccupation" style="font-size:12px;">Occupation</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetOccupation"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetNatureOfDuties"  style="font-size:12px;">Nature Of Duties</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetNatureOfDuties"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetAddress1"  style="font-size:12px;">Address 1</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetAddress1"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetAddress2"  style="font-size:12px;">Address 2</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetAddress2"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetAddress3"  style="font-size:12px;">Address 3</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetAddress3"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetPincode" style="font-size:12px;">Pincode</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetPincode"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt1perDetCity" style="font-size:12px;">City</label><br />
                &nbsp;<asp:TextBox ID="Txt1perDetCity"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
                 <div class="form-group selectTab col-6">
                  <label for="PD1StateDropDownList39" style="font-size:12px;">State</label><br />

                <asp:DropDownList ID="PD1StateDropDownList39" runat="server" required="true" Width="30%" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select State" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                    <asp:ListItem>Andhra Pradesh</asp:ListItem>
                    <asp:ListItem>Assam</asp:ListItem>
                    <asp:ListItem>Bihar</asp:ListItem>
                </asp:DropDownList>
                </div>

                 <div class="form-group selectTab col-6">
                  <label for="PD1JointLifeOptionDropDownList40" style="font-size:12px;">Joint Life Option</label><br />

                <asp:DropDownList ID="PD1JointLifeOptionDropDownList40" runat="server" OnSelectedIndexChanged="PD1JointLifeOptionDropDownList40_SelectedIndexChanged" AutoPostBack="True" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Joint Life Option" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="true">Yes</asp:ListItem>
                    <asp:ListItem Value="false">No</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group selectTab">
                  <label for="PD1JointLifeBasisDropDownList41" style="font-size:12px;">Joint Life Option</label><br />

                <asp:DropDownList ID="PD1JointLifeBasisDropDownList41" runat="server" Onclick="PD1JointLifeOptionDropDownList40_SelectedIndexChanged()"  style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Joint Life Basis" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Accelarated</asp:ListItem>
                    <asp:ListItem>Reducing</asp:ListItem> 
                    <asp:ListItem>Sharing</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group selectTab">
                  <label for="PD1KnowEngDropDownList42" style="font-size:12px;">Do You Understand English</label><br />

                <asp:DropDownList ID="PD1KnowEngDropDownList42" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Know English" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group selectTab">
                  <label for="PD1IlliterateDropDownList43" style="font-size:12px;">Are You Illiterate</label><br />

                <asp:DropDownList ID="PD1IlliterateDropDownList43" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select Are You Illiterate" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group selectTab">
                  <label for="PD1NoofLifeCoveredDropDownList44" style="font-size:12px;">No of Life to be covered</label><br />
                <asp:DropDownList ID="PD1NoofLifeCoveredDropDownList44" runat="server" onchange="toggleDivs(this)" required="true"  style="font-size:12px;" Width="30%">
                    <asp:ListItem Text="select" Value="" Disabled="True" Selected="True">select</asp:ListItem>
                    <asp:ListItem Value="0">0</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                      <asp:ListItem Value="3">3</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group">
                  <label for="TxtPD1firstJointBorrowerShare" style="font-size:12px;">Joint Borrower Share %</label><br />
                &nbsp;<asp:TextBox ID="TxtPD1JointBorrowerShare"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="TxtPD1secondBorrowershare" style="font-size:12px;">2nd  Borrower Share %</label><br />
                &nbsp;<asp:TextBox ID="TextBox91"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="TxtPD1thirdBorrowershare" style="font-size:12px;">3rd  Borrower Share %</label><br />
                &nbsp;<asp:TextBox ID="TextBox92"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                   <div class="form-group">
                  <label for="TxtPD1fourthBorrowershare" style="font-size:12px;">4Th  Borrower Share %</label><br />
                &nbsp;<asp:TextBox ID="TextBox93"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

             </div>

             <p style="color: #3498db;">Health</p>
            <hr />
            <br />
            <div>
                   <div class="form-group">
                  <label for="Txt1stLifeHeightInfeet" style="font-size:12px;">Height(In feet)</label><br />
                &nbsp;<asp:TextBox ID="Txt1stLifeHeightInfeet"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
            
                   <div class="form-group">
                  <label for="Txt1stLifeHeightInInches" style="font-size:12px;">Height(In Inches)</label><br />
                &nbsp;<asp:TextBox ID="Txt1stLifeHeightInInches"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>
            
                   <div class="form-group">
                  <label for="Txt1stLifeWeight" style="font-size:12px;">Weight(In Kg)</label><br />
                &nbsp;<asp:TextBox ID="Txt1stLifeWeight"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>
                </div>

                        <p style="color: #3498db;">Medical Questionare</p>
            <hr />
            <br />
            
<div><h5>
1) I am to the best of my knowledge and belief, in good health and free from all symptoms of illness and disease?
</h5></div> 
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion1" runat="server"  required="true" Width="15%"  >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
  
<div><h5>
2) None of my family members have been diagnosed with diabetes, heart disease, high BP, elevated blood fats, cancer, mental illness, HIV, stroke or had any hereditary disorder?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion2" runat="server"  required="true"  width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
3) Do not intend to participate or participate in any hazardous sports or activities?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion3" runat="server"  required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
4) I do not currently live or intend to live or travel outside India for more than six months in a financial year? If yes, I will provide full details of countries to be visited along with purpose of visit and duration
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion4" runat="server" required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

<div><h5>
5) I am not currently taking any medications/drugs, other than minor condition (eg cold and flu), either prescribed or not prescribed by a doctor, or have not suffered from any illness, disorder, disability, injury during past 5 years which has required any form of medical or specialised examination (including chest x-rays, gynaecological investigations, pap smear, or blood tests), consultation, hospitalisation, surgery or have any condition for which hospitalization / surgery has been advised or is contemplated?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion5" runat="server" required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
6) I have no congenital / birth defects, pain or problems in back, spine, muscles or joint, arthritis, gout, severe injury or other physical disability and have not been incapable of working / attending the office during the last two years for more than three consecutive days or I am not currently incapable of working / attending office? For females only â€“I have not ever suffered from or suffering or is currently suffering any diseases of breast / uterus / cervix, or not presently pregnant?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion6" runat="server"  required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

    <div><h5>
7) I do not suffer from or ever had any medical ailments such as diabetes, high blood pressure, cancer, respiratory disease (including asthma), kidney or liver disease, stroke, paralysis, auto immune disorder, any blood disorder, heart problems, Hepatitis B or C, or tuberculosis, psychiatric disorder, depression, colitis, or any other stomach problems, have not undergone any transplants, thyroid disorders, reproductive organs, HIV AIDS or a related infection?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion7" runat="server"  required="true"  width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

<div><h5>
8) I have never ever taken drugs, or been advised to reduce alcohol consumption or received or have been counselled to receive treatment for drug addiction or alcoholism?
    </h5></div>
     <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion8" runat="server"  required="true"  width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
9) I have never been refused life insurance or offered insurance modified in any way?
  </h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion9" runat="server"  required="true"  width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
10) I am not suffering from disorder/ disease not mentioned above?
   </h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredMedQuestion10" runat="server" required="true"  width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

     

             <p style="color: #3498db;">Covid Questionare</p>
            <hr />
            <br />

      <div><h5>
        1) Are you, or have you been (If yes to any of below please provide details)
      </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion1" runat="server" required="true"  width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
        a) In close contact with anyone who has been quarantined or who has been diagnosed with novel 
        coronavirus (SARS-CoV-2/COVID-19)?
       </h5></div>

         <div><h5>    
       b) Quarantined due to a possible exposure to novel coronavirus (SARSCoV2/COVID-19)?
       </h5></div>

        <div><h5>    
        c) Tested positive for the novel coronavirus or await the result of such test?
       </h5></div>

        <div><h5> 
        d) Advised to be tested to rule in, or rule out, a diagnosis of novel coronavirus?    
         </h5></div>

        <div><h5>   
          2) Have you experienced any of the following symptoms within the last 14 days?
        </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion2" runat="server" required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
         <div><h5> 
          Any fever /Cough/Shortness of breath /Malaise (flu-like tiredness)
          hinorrhea (mucus discharge from the nose) /Sore throat
          Gastro-intestinal symptoms such as nausea, vomiting and/or diarrhea
         </h5></div>

        <div><h5>
         3) Please provide your travel patterns over the past 14 days/ next 30 days (provide details if Yes)
     </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion3" runat="server"  required="true"  width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
       4) Are you currently in good Health?
     </h5></div>
            
    <div><h5>
      Does your occupation fall within any of the below mentioned? (If yes please provide details)
  </h5></div>

     <div><h5>
      Doctor/ medical professional
     Nursing personnel
      Pharmacist 
   </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion4" runat="server" required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
  <div><h5>
      5)Does your occupation fall within any of the below mentioned? (If yes please provide details)
    </h5></div>


      <div><h5>
          Doctor/ medical professiona
          Pharmacist
         Police/Military staff
         Pilots/ Cabin Crew personnel
          Any other occupation which has higher exposure to a large population. If yes, please specify
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion5" runat="server" required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
            6) Do you have any history of conviction under any criminal proceedings, in India or abroad?
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion6" runat="server" required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
           <div><h5>
          7) Is your occupation associated with any specific hazards which would render you susceptible to any injury or illness, 
          (e.g. chemical factory, mines, explosives, corrosive chemicals, etc.?)
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion7" runat="server" required="true"  width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
          8) Has your weight altered (Gain/Loss) by more than 5 kg in the last 1 year? If yes details required
    </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion8" runat="server" required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
          9) Have you ever or are you currently suffering from any other illness,
          impairment or disability or any surgery not mentioned in the application form?

        </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life1AssuredCovidQuestion9" runat="server" required="true" width="15%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <!-- Example div sections to show/hide based on dropdown selection -->
<div id="section1" class="additional-section" style="display:none;">
            <p style="color: #3498db;">Second Life Assured</p>
            <hr />
            <br />
         <div>
            <div class="form-group selectTab col-6">
                <asp:DropDownList ID="PD2SalutationDropDownList45" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                  <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                     <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Mrs</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group  col-6">
                  <label for="Txt2perDetFirstName">First Name</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetFirstName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt2perDetMiddleName">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetMiddleName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt2perDetLastName">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetLastName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group selectTab col-6">
                <asp:DropDownList ID="PdDet2s_Gender_DropDownList46" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group  col-6">
                  <label for="Txt2perDetDateofBirth">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetDateofBirth"  runat="server" Width="30%" TextMode="Date"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetAge">Age</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetAge"  runat="server" Width="30%" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetEmail">Email</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetEmail"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetMobileNo">Mobile No</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetMobileNo"  runat="server" Width="30%" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetPanNumber">Pan Number</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetPanNumber"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetOccupation">Occupation</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetOccupation"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetNatureOfDuties">Nature Of Duties</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetNatureOfDuties"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetAddress1">Address 1</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetAddress1"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetAddress2">Address 2</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetAddress2"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetAddress3">Address 3</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetAddress3"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetPincode">Pincode</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetPincode"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt2perDetCity">City</label><br />
                &nbsp;<asp:TextBox ID="Txt2perDetCity"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group selectTab col-6">
                <asp:DropDownList ID="PD2StateDropDownList47" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="State" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                    <asp:ListItem>Andhra Pradesh</asp:ListItem>
                    <asp:ListItem>Assam</asp:ListItem>
                    <asp:ListItem>Bihar</asp:ListItem>
                </asp:DropDownList>
                </div>  

             </div>

             <p style="color: #3498db;">Health</p>
            <hr />
            <br />
            <div>
                   <div class="form-group  col-6">
                  <label for="Txt2LifeHeightInfeet">Height(In feet)</label><br />
                &nbsp;<asp:TextBox ID="Txt2LifeHeightInfeet"  runat="server" Width="30%"></asp:TextBox>
                  </div>
            
                   <div class="form-group  col-6">
                  <label for="Txt2LifeHeightInInches">Height(In Inches)</label><br />
                &nbsp;<asp:TextBox ID="Txt2LifeHeightInInches"  runat="server" Width="30%"></asp:TextBox>
                  </div>
            
                   <div class="form-group  col-6">
                  <label for="Txt2LifeWeightInkg">Weight(In Kg)</label><br />
                &nbsp;<asp:TextBox ID="Txt2LifeWeightInkg"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                </div>

                <p style="color: #3498db;">Medical Questionare</p>
            <hr />
            <br />
            
<div><h5>
1) I am to the best of my knowledge and belief, in good health and free from all symptoms of illness and disease?
</h5></div> 
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion1" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
  
<div><h5>
2) None of my family members have been diagnosed with diabetes, heart disease, high BP, elevated blood fats, cancer, mental illness, HIV, stroke or had any hereditary disorder?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion2" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
3) Do not intend to participate or participate in any hazardous sports or activities?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion3" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
4) I do not currently live or intend to live or travel outside India for more than six months in a financial year? If yes, I will provide full details of countries to be visited along with purpose of visit and duration
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion4" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

<div><h5>
5) I am not currently taking any medications/drugs, other than minor condition (eg cold and flu), either prescribed or not prescribed by a doctor, or have not suffered from any illness, disorder, disability, injury during past 5 years which has required any form of medical or specialised examination (including chest x-rays, gynaecological investigations, pap smear, or blood tests), consultation, hospitalisation, surgery or have any condition for which hospitalization / surgery has been advised or is contemplated?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion5" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
6) I have no congenital / birth defects, pain or problems in back, spine, muscles or joint, arthritis, gout, severe injury or other physical disability and have not been incapable of working / attending the office during the last two years for more than three consecutive days or I am not currently incapable of working / attending office? For females only â€“I have not ever suffered from or suffering or is currently suffering any diseases of breast / uterus / cervix, or not presently pregnant?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion6" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

    <div><h5>
7) I do not suffer from or ever had any medical ailments such as diabetes, high blood pressure, cancer, respiratory disease (including asthma), kidney or liver disease, stroke, paralysis, auto immune disorder, any blood disorder, heart problems, Hepatitis B or C, or tuberculosis, psychiatric disorder, depression, colitis, or any other stomach problems, have not undergone any transplants, thyroid disorders, reproductive organs, HIV AIDS or a related infection?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion7" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

<div><h5>
8) I have never ever taken drugs, or been advised to reduce alcohol consumption or received or have been counselled to receive treatment for drug addiction or alcoholism?
    </h5></div>
     <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion8" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
9) I have never been refused life insurance or offered insurance modified in any way?
  </h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion9" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
10) I am not suffering from disorder/ disease not mentioned above?
   </h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredMedicalQuestion10" runat="server"  >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

     

             <p style="color: #3498db;">Covid Questionare</p>
            <hr />
            <br />

      <div><h5>
        1) Are you, or have you been (If yes to any of below please provide details)
      </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion1" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
        a) In close contact with anyone who has been quarantined or who has been diagnosed with novel 
        coronavirus (SARS-CoV-2/COVID-19)?
       </h5></div>

         <div><h5>    
       b) Quarantined due to a possible exposure to novel coronavirus (SARSCoV2/COVID-19)?
       </h5></div>

        <div><h5>    
        c) Tested positive for the novel coronavirus or await the result of such test?
       </h5></div>

        <div><h5> 
        d) Advised to be tested to rule in, or rule out, a diagnosis of novel coronavirus?    
         </h5></div>

        <div><h5>   
          2) Have you experienced any of the following symptoms within the last 14 days?
        </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion2" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
         <div><h5> 
          Any fever /Cough/Shortness of breath /Malaise (flu-like tiredness)
          hinorrhea (mucus discharge from the nose) /Sore throat
          Gastro-intestinal symptoms such as nausea, vomiting and/or diarrhea
         </h5></div>

        <div><h5>
         3) Please provide your travel patterns over the past 14 days/ next 30 days (provide details if Yes)
     </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion3" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
       4) Are you currently in good Health?
     </h5></div>
            
    <div><h5>
      Does your occupation fall within any of the below mentioned? (If yes please provide details)
  </h5></div>

     <div><h5>
      Doctor/ medical professional
     Nursing personnel
      Pharmacist 
   </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion4" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
  <div><h5>
      5)Does your occupation fall within any of the below mentioned? (If yes please provide details)
    </h5></div>


      <div><h5>
          Doctor/ medical professiona
          Pharmacist
         Police/Military staff
         Pilots/ Cabin Crew personnel
          Any other occupation which has higher exposure to a large population. If yes, please specify
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion5" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
            6) Do you have any history of conviction under any criminal proceedings, in India or abroad?
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion6" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
           <div><h5>
          7) Is your occupation associated with any specific hazards which would render you susceptible to any injury or illness, 
          (e.g. chemical factory, mines, explosives, corrosive chemicals, etc.?)
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion7" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
          8) Has your weight altered (Gain/Loss) by more than 5 kg in the last 1 year? If yes details required
    </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion8" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
          9) Have you ever or are you currently suffering from any other illness,
          impairment or disability or any surgery not mentioned in the application form?

        </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life2AssuredCovidQuestion9" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    </div>
        <div id="section2" class="additional-section" style="display:none;">

              <p style="color: #3498db;">Third Life Assured</p>
            <hr />
            <br />
         
             <div>
            <div class="form-group selectTab col-6">
                <asp:DropDownList ID="PD3SalutationDropDownList53" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Assam Bank</asp:ListItem>
                    <asp:ListItem>State BANK</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group  col-6">
                  <label for="Txt3perDetFirstName">First Name</label><br />
                &nbsp;<asp:TextBox ID="Txt3perDetFirstName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt3perDetMiddleName">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="Txt3perDetMiddleName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt3perDetLastName">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txt3perDetLastName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group selectTab col-6">
                <asp:DropDownList ID="PdDets3_Gender_DropDownList54" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group  col-6">
                  <label for="Txt3perDetDateofBirth">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txt3perDetDateofBirth"  runat="server" Width="30%" TextMode="Date"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="Txt3perDetAge">Age</label><br />
                &nbsp;<asp:TextBox ID="Txt3perDetAge"  runat="server" Width="30%" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox80">Email</label><br />
                &nbsp;<asp:TextBox ID="TextBox124"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox81">Mobile No</label><br />
                &nbsp;<asp:TextBox ID="TextBox125"  runat="server" Width="30%" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox82">Pan Number</label><br />
                &nbsp;<asp:TextBox ID="TextBox126"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox83">Occupation</label><br />
                &nbsp;<asp:TextBox ID="TextBox127"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox84">Nature Of Duties</label><br />
                &nbsp;<asp:TextBox ID="TextBox128"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox85">Address 1</label><br />
                &nbsp;<asp:TextBox ID="TextBox129"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox86">Address 2</label><br />
                &nbsp;<asp:TextBox ID="TextBox130"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox87">Address 3</label><br />
                &nbsp;<asp:TextBox ID="TextBox131"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox88">Pincode</label><br />
                &nbsp;<asp:TextBox ID="TextBox132"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox89">City</label><br />
                &nbsp;<asp:TextBox ID="TextBox133"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group selectTab col-6">
                <asp:DropDownList ID="DropDownList55" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="State" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                    <asp:ListItem>Andhra Pradesh</asp:ListItem>
                    <asp:ListItem>Assam</asp:ListItem>
                    <asp:ListItem>Bihar</asp:ListItem>
                </asp:DropDownList>
                </div>
             </div>

             <p style="color: #3498db;">Health</p>
            <hr />
            <br />
            <div>
                   <div class="form-group  col-6">
                  <label for="Txt3LifeHeightInfeet">Height(In feet)</label><br />
                &nbsp;<asp:TextBox ID="Txt3LifeHeightInfeet"  runat="server" Width="30%"></asp:TextBox>
                  </div>
            
                   <div class="form-group  col-6">
                  <label for="Txt3LifeHeightInInches">Height(In Inches)</label><br />
                &nbsp;<asp:TextBox ID="Txt3LifeHeightInInches"  runat="server" Width="30%"></asp:TextBox>
                  </div>
            
                   <div class="form-group  col-6">
                  <label for="Txt3LifeWeightInKg">Weight(In Kg)</label><br />
                &nbsp;<asp:TextBox ID="Txt3LifeWeightInKg"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                </div>

         <p style="color: #3498db;">Medical Questionare</p>
            <hr />
            <br />
            
<div><h5>
1) I am to the best of my knowledge and belief, in good health and free from all symptoms of illness and disease?
</h5></div> 
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion1" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
  
<div><h5>
2) None of my family members have been diagnosed with diabetes, heart disease, high BP, elevated blood fats, cancer, mental illness, HIV, stroke or had any hereditary disorder?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion2" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
3) Do not intend to participate or participate in any hazardous sports or activities?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion3" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
4) I do not currently live or intend to live or travel outside India for more than six months in a financial year? If yes, I will provide full details of countries to be visited along with purpose of visit and duration
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion4" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

<div><h5>
5) I am not currently taking any medications/drugs, other than minor condition (eg cold and flu), either prescribed or not prescribed by a doctor, or have not suffered from any illness, disorder, disability, injury during past 5 years which has required any form of medical or specialised examination (including chest x-rays, gynaecological investigations, pap smear, or blood tests), consultation, hospitalisation, surgery or have any condition for which hospitalization / surgery has been advised or is contemplated?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion5" runat="server" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
6) I have no congenital / birth defects, pain or problems in back, spine, muscles or joint, arthritis, gout, severe injury or other physical disability and have not been incapable of working / attending the office during the last two years for more than three consecutive days or I am not currently incapable of working / attending office? For females only â€“I have not ever suffered from or suffering or is currently suffering any diseases of breast / uterus / cervix, or not presently pregnant?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion6" runat="server" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

    <div><h5>
7) I do not suffer from or ever had any medical ailments such as diabetes, high blood pressure, cancer, respiratory disease (including asthma), kidney or liver disease, stroke, paralysis, auto immune disorder, any blood disorder, heart problems, Hepatitis B or C, or tuberculosis, psychiatric disorder, depression, colitis, or any other stomach problems, have not undergone any transplants, thyroid disorders, reproductive organs, HIV AIDS or a related infection?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion7" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

<div><h5>
8) I have never ever taken drugs, or been advised to reduce alcohol consumption or received or have been counselled to receive treatment for drug addiction or alcoholism?
    </h5></div>
     <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion8" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
9) I have never been refused life insurance or offered insurance modified in any way?
  </h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion9" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
10) I am not suffering from disorder/ disease not mentioned above?
   </h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredMedicalQuestion10" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

     

             <p style="color: #3498db;">Covid Questionare</p>
            <hr />
            <br />

      <div><h5>
        1) Are you, or have you been (If yes to any of below please provide details)
      </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion1" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
        a) In close contact with anyone who has been quarantined or who has been diagnosed with novel 
        coronavirus (SARS-CoV-2/COVID-19)?
       </h5></div>

         <div><h5>    
       b) Quarantined due to a possible exposure to novel coronavirus (SARSCoV2/COVID-19)?
       </h5></div>

        <div><h5>    
        c) Tested positive for the novel coronavirus or await the result of such test?
       </h5></div>

        <div><h5> 
        d) Advised to be tested to rule in, or rule out, a diagnosis of novel coronavirus?    
         </h5></div>

        <div><h5>   
          2) Have you experienced any of the following symptoms within the last 14 days?
        </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion2" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
         <div><h5> 
          Any fever /Cough/Shortness of breath /Malaise (flu-like tiredness)
          hinorrhea (mucus discharge from the nose) /Sore throat
          Gastro-intestinal symptoms such as nausea, vomiting and/or diarrhea
         </h5></div>

        <div><h5>
         3) Please provide your travel patterns over the past 14 days/ next 30 days (provide details if Yes)
     </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion3" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
       4) Are you currently in good Health?
     </h5></div>
            
    <div><h5>
      Does your occupation fall within any of the below mentioned? (If yes please provide details)
  </h5></div>

     <div><h5>
      Doctor/ medical professional
     Nursing personnel
      Pharmacist 
   </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion4" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
  <div><h5>
      5)Does your occupation fall within any of the below mentioned? (If yes please provide details)
    </h5></div>


      <div><h5>
          Doctor/ medical professiona
          Pharmacist
         Police/Military staff
         Pilots/ Cabin Crew personnel
          Any other occupation which has higher exposure to a large population. If yes, please specify
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion5" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
            6) Do you have any history of conviction under any criminal proceedings, in India or abroad?
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion6" runat="server" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
           <div><h5>
          7) Is your occupation associated with any specific hazards which would render you susceptible to any injury or illness, 
          (e.g. chemical factory, mines, explosives, corrosive chemicals, etc.?)
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion7" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
          8) Has your weight altered (Gain/Loss) by more than 5 kg in the last 1 year? If yes details required
    </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion8" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
          9) Have you ever or are you currently suffering from any other illness,
          impairment or disability or any surgery not mentioned in the application form?

        </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life3AssuredCovidQuestion9" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
        <div id="section3" class="additional-section" style="display:none;">

                   <p style="color: #3498db;">Fourth Life Assured</p>
            <hr />
            <br />
         
             <div>
            <div class="form-group selectTab col-6">
                <asp:DropDownList ID="DropDownList61" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Assam Bank</asp:ListItem>
                    <asp:ListItem>State BANK</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group  col-6">
                  <label for="TextBox66">First Name</label><br />
                &nbsp;<asp:TextBox ID="TextBox138"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TextBox66">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="TextBox139"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="TextBox66">Last Name</label><br />
                &nbsp;<asp:TextBox ID="TextBox140"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                  <div class="form-group selectTab col-6">
                <asp:DropDownList ID="DropDownList62" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group  col-6">
                  <label for="TextBox66">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="TextBox141"  runat="server" Width="30%" TextMode="Date"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox79">Age</label><br />
                &nbsp;<asp:TextBox ID="TextBox142"  runat="server" Width="30%" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox80">Email</label><br />
                &nbsp;<asp:TextBox ID="TextBox143"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox81">Mobile No</label><br />
                &nbsp;<asp:TextBox ID="TextBox144"  runat="server" Width="30%" TextMode="Number"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox82">Pan Number</label><br />
                &nbsp;<asp:TextBox ID="TextBox145"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox83">Occupation</label><br />
                &nbsp;<asp:TextBox ID="TextBox146"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox84">Nature Of Duties</label><br />
                &nbsp;<asp:TextBox ID="TextBox147"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox85">Address 1</label><br />
                &nbsp;<asp:TextBox ID="TextBox148"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox86">Address 2</label><br />
                &nbsp;<asp:TextBox ID="TextBox149"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox87">Address 3</label><br />
                &nbsp;<asp:TextBox ID="TextBox150"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox88">Pincode</label><br />
                &nbsp;<asp:TextBox ID="TextBox151"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group  col-6">
                  <label for="TextBox89">City</label><br />
                &nbsp;<asp:TextBox ID="TextBox152"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                 <div class="form-group selectTab col-6">
                <asp:DropDownList ID="DropDownList63" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="State" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                    <asp:ListItem>Andhra Pradesh</asp:ListItem>
                    <asp:ListItem>Assam</asp:ListItem>
                    <asp:ListItem>Bihar</asp:ListItem>
                </asp:DropDownList>
                </div>

             </div>
             <p style="color: #3498db;">Health</p>
            <hr />
            <br />
            <div>
                   <div class="form-group  col-6">
                  <label for="Txt4LifeHeightInfeet">Height(In feet)</label><br />
                &nbsp;<asp:TextBox ID="Txt4LifeHeightInfeet"  runat="server" Width="30%"></asp:TextBox>
                  </div>
            
                   <div class="form-group  col-6">
                  <label for="Txt4LifeHeightInInches">Height(In Inches)</label><br />
                &nbsp;<asp:TextBox ID="Txt4LifeHeightInInches"  runat="server" Width="30%"></asp:TextBox>
                  </div>
            
                   <div class="form-group  col-6">
                  <label for="Txt4LifeWeightInKg">Weight(In Kg)</label><br />
                &nbsp;<asp:TextBox ID="Txt4LifeWeightInKg"  runat="server" Width="30%"></asp:TextBox>
                  </div>
                </div>


   <p style="color: #3498db;">Medical Questionare</p>
            <hr />
            <br />
            
<div><h5>
1) I am to the best of my knowledge and belief, in good health and free from all symptoms of illness and disease?
</h5></div> 
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion1" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
  
<div><h5>
2) None of my family members have been diagnosed with diabetes, heart disease, high BP, elevated blood fats, cancer, mental illness, HIV, stroke or had any hereditary disorder?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion2" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
3) Do not intend to participate or participate in any hazardous sports or activities?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion3" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
4) I do not currently live or intend to live or travel outside India for more than six months in a financial year? If yes, I will provide full details of countries to be visited along with purpose of visit and duration
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion4" runat="server" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

<div><h5>
5) I am not currently taking any medications/drugs, other than minor condition (eg cold and flu), either prescribed or not prescribed by a doctor, or have not suffered from any illness, disorder, disability, injury during past 5 years which has required any form of medical or specialised examination (including chest x-rays, gynaecological investigations, pap smear, or blood tests), consultation, hospitalisation, surgery or have any condition for which hospitalization / surgery has been advised or is contemplated?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion5" runat="server" >
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
<div><h5>
6) I have no congenital / birth defects, pain or problems in back, spine, muscles or joint, arthritis, gout, severe injury or other physical disability and have not been incapable of working / attending the office during the last two years for more than three consecutive days or I am not currently incapable of working / attending office? For females only â€“I have not ever suffered from or suffering or is currently suffering any diseases of breast / uterus / cervix, or not presently pregnant?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion6" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

    <div><h5>
7) I do not suffer from or ever had any medical ailments such as diabetes, high blood pressure, cancer, respiratory disease (including asthma), kidney or liver disease, stroke, paralysis, auto immune disorder, any blood disorder, heart problems, Hepatitis B or C, or tuberculosis, psychiatric disorder, depression, colitis, or any other stomach problems, have not undergone any transplants, thyroid disorders, reproductive organs, HIV AIDS or a related infection?
</h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion7" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

<div><h5>
8) I have never ever taken drugs, or been advised to reduce alcohol consumption or received or have been counselled to receive treatment for drug addiction or alcoholism?
    </h5></div>
     <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion8" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
9) I have never been refused life insurance or offered insurance modified in any way?
  </h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion9" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
10) I am not suffering from disorder/ disease not mentioned above?
   </h5></div>
             <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredMedicalQuestion10" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>

     

             <p style="color: #3498db;">Covid Questionare</p>
            <hr />
            <br />

      <div><h5>
        1) Are you, or have you been (If yes to any of below please provide details)
      </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion1" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
        a) In close contact with anyone who has been quarantined or who has been diagnosed with novel 
        coronavirus (SARS-CoV-2/COVID-19)?
       </h5></div>

         <div><h5>    
       b) Quarantined due to a possible exposure to novel coronavirus (SARSCoV2/COVID-19)?
       </h5></div>

        <div><h5>    
        c) Tested positive for the novel coronavirus or await the result of such test?
       </h5></div>

        <div><h5> 
        d) Advised to be tested to rule in, or rule out, a diagnosis of novel coronavirus?    
         </h5></div>

        <div><h5>   
          2) Have you experienced any of the following symptoms within the last 14 days?
        </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion2" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
         <div><h5> 
          Any fever /Cough/Shortness of breath /Malaise (flu-like tiredness)
          hinorrhea (mucus discharge from the nose) /Sore throat
          Gastro-intestinal symptoms such as nausea, vomiting and/or diarrhea
         </h5></div>

        <div><h5>
         3) Please provide your travel patterns over the past 14 days/ next 30 days (provide details if Yes)
     </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion3" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                   <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
    <div><h5>
       4) Are you currently in good Health?
     </h5></div>
            
    <div><h3>
      Does your occupation fall within any of the below mentioned? (If yes please provide details)
  </h3></div>

     <div><h5>
      Doctor/ medical professional
     Nursing personnel
      Pharmacist 
   </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion4" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
  <div><h5>
      5)Does your occupation fall within any of the below mentioned? (If yes please provide details)
    </h5></div>


      <div><h5>
          Doctor/ medical professiona
          Pharmacist
         Police/Military staff
         Pilots/ Cabin Crew personnel
          Any other occupation which has higher exposure to a large population. If yes, please specify
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion5" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
            6) Do you have any history of conviction under any criminal proceedings, in India or abroad?
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion6" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
           <div><h5>
          7) Is your occupation associated with any specific hazards which would render you susceptible to any injury or illness, 
          (e.g. chemical factory, mines, explosives, corrosive chemicals, etc.?)
           </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion7" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
          8) Has your weight altered (Gain/Loss) by more than 5 kg in the last 1 year? If yes details required
    </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion8" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
        <div><h5>
          9) Have you ever or are you currently suffering from any other illness,
          impairment or disability or any surgery not mentioned in the application form?

        </h5></div>
            <div class="form-group selectTab">
                <asp:DropDownList ID="Life4AssuredCovidQuestion9" runat="server">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Select" Value="" Disabled="True" Selected="True"></asp:ListItem>
                     <asp:ListItem value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>

              <h3 style="color: #3498db;">Nominee 1</h3>
            <hr />
            <br />
            <div >
                <div class="form-group selectTab col-6">


                    <label for="Txt1stNominee_Name" style="font-size:12px;">Salutation</label><br />
                <asp:DropDownList ID="SalutationDropDownList11" runat="server"  required="true" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="select" Value="select"></asp:ListItem><%--Disabled="True"--%>
                    <asp:ListItem value="Mr">Mr</asp:ListItem>
                    <asp:ListItem Value="Ms">Ms</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group  col-6">
                  <label for="Txt1stNominee_Name" style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txt1stNominee_Name"  runat="server" Width="30%" required="true"></asp:TextBox>
<%--<asp:RequiredFieldValidator ID="Nominee1rfvName" runat="server" ControlToValidate="Txt1stNominee_Name" ErrorMessage="Name is required." ForeColor="Red" Display="Dynamic" />--%>

                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt1stNominee_MiddleName"  style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="Txt1stNominee_MiddleName"  runat="server" Width="30%" ></asp:TextBox>
                      

                  </div>
<%--<asp:RequiredFieldValidator ID="Nominee1rfvMiddleName" runat="server" ControlToValidate="Txt1stNominee_MiddleName" ErrorMessage="Middle Name is required." ForeColor="Red" Display="Dynamic" />--%>
                <div class="form-group  col-6">
                  <label for="Txt1stNominee_LastName"   style="font-size:12px;">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txt1stNominee_LastName"  runat="server" Width="30%" required="true"></asp:TextBox>
<%--<asp:RequiredFieldValidator ID="Nominee1rfvLastName" runat="server" ControlToValidate="Txt1stNominee_LastName" ErrorMessage="Last Name is required." ForeColor="Red" Display="Dynamic" />--%>

                  </div>

                 <div class="form-group selectTab col-6">
                <asp:DropDownList ID="GenderDropDownList24" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
<%--<asp:RequiredFieldValidator ID="Nominee1rfvGender" runat="server" ControlToValidate="GenderDropDownList24" ErrorMessage="Gender is required." ForeColor="Red" Display="Dynamic" />--%>

                </div>

                   <div class="form-group  col-6">
                  <label for="Txt1stNominee_DateofBirth" style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txt1stNominee_DateofBirth"  runat="server" Width="30%" required="true" TextMode="Date"></asp:TextBox>
<%--<asp:RequiredFieldValidator ID="Nominee1rfvDob" runat="server" ControlToValidate="Txt1stNominee_DateofBirth" ErrorMessage="Dob is required." ForeColor="Red" Display="Dynamic" />--%>

                  </div>

                <div class="form-group selectTab col-6">
                <asp:DropDownList ID="RelationDropDownList25" runat="server"  required="true" style="font-size:12px;" Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
<%--<asp:RequiredFieldValidator ID="Nominee1rfvRelation" runat="server" ControlToValidate="RelationDropDownList25" ErrorMessage="Relation is required." ForeColor="Red" Display="Dynamic" />--%>

                </div>

                <div class="form-group  col-6">
                  <label for="Txt1stNominee_Age"  style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txt1stNominee_Age"  runat="server" Width="30%"  required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="Txt1stNominee_PercentageofEntitlementonlyincaseofNominee" style="font-size:12px;">Percentage of Entitlement only in case of Nominee</label>
                &nbsp;<asp:TextBox ID="Txt1stNominee_PercentageofEntitlementonlyincaseofNominee"  runat="server" Width="30%" required="true"></asp:TextBox>
<%--<asp:RequiredFieldValidator ID="Nominee1rfvPercentage" runat="server" ControlToValidate="Txt1stNominee_PercentageofEntitlementonlyincaseofNominee" ErrorMessage="Percentage is required." ForeColor="Red" Display="Dynamic" />--%>

                  </div>

                <div class="form-group  col-6">
                  <label for="Txt1stNomineeMobileNumber" style="font-size:12px;">Mobile Number</label><br />
                &nbsp;<asp:TextBox ID="Txt1stNomineeMobileNumber"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="Nominee1rfvMobileNumber" runat="server" ControlToValidate="Txt1stNomineeMobileNumber" ErrorMessage="MobileNo is required." ForeColor="Red" Display="Dynamic" />--%>

                  </div>

            </div>


            <h3 style="color: #3498db;">Nominee 2</h3>
            <hr />
            <br />
            <div>
                <div class="form-group selectTab col-6">
                <asp:DropDownList ID="SalutationDropDownList26" runat="server" required="true" width="30%" style="font-size:12px;">
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group  col-6">
                  <label for="Txt2ndName" style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txt2ndName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt2ndMiddleName"  style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="Txt2ndMiddleName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="Txt2ndLastName" style="font-size:12px;">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txt2ndLastName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab col-6">
                <asp:DropDownList ID="GenderDropDownList27" runat="server"  required="true" width="30%" style="font-size:12px;">
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group  col-6">
                  <label for="TxtDateofBirth"  style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="TxtDateofBirth"  runat="server" Width="30%"  required="true" TextMode="Date"></asp:TextBox>
                  </div>

                <div class="form-group selectTab col-6">
                <asp:DropDownList ID="RelationDropDownList67" runat="server"  required="true" width="30%" style="font-size:12px;">
                    <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group  col-6">
                  <label for="Txt2ndAge">Age</label><br />
                &nbsp;<asp:TextBox ID="Txt2ndAge"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="Txt2ndNominee_PercentageofEntitlementonlyincaseofNominee" style="font-size:12px;">Percentage of Entitlement only in case of Nominee</label>
                &nbsp;<asp:TextBox ID="Txt2ndNominee_PercentageofEntitlementonlyincaseofNominee"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox86"  style="font-size:12px;">Mobile Number</label><br />
                &nbsp;<asp:TextBox ID="TextBox168"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>

                  </div>

            </div>

           

            <h3 style="color: #3498db;">Nominee 3</h3>
            <hr />
            <br />
            <div>
                <div class="form-group selectTab col-6">
                <asp:DropDownList ID="SalutationDropDownList77" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group  col-6">
                  <label for="Txt3rdNomineeName"  style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txt3rdNomineeName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt3rdNomineeMiddleName"  style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="Txt3rdNomineeMiddleName"  runat="server" Width="30%" ></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="Txt3rdNomineeLastName" style="font-size:12px;">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txt3rdNomineeLastName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab col-6">
                <asp:DropDownList ID="GenderDropDownList78" runat="server"  required="true"  style="font-size:12px;" Width="30%">
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group  col-6">
                  <label for="Txt3rdNomineeDob"  style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txt3rdNomineeDob"  runat="server" Width="30%" required="true" TextMode="Date"></asp:TextBox>
                  </div>

                <div class="form-group selectTab col-6">
                <asp:DropDownList ID="RelationDropDownList79" runat="server" required="true" style="font-size:12px;" Width="30%">
                    <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group  col-6">
                  <label for="Txt3rdNomineeAge"  style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txt3rdNomineeAge"  runat="server" Width="30%"  required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="Txt3rdNominee_PercentageofEntitlementonlyincaseofNominee" style="font-size:12px;">Percentage of Entitlement only in case of Nominee</label>
                &nbsp;<asp:TextBox ID="Txt3rdNominee_PercentageofEntitlementonlyincaseofNominee"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="TextBox86"  style="font-size:12px;">Mobile Number</label><br />
                &nbsp;<asp:TextBox ID="TextBox182"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

            </div>

            <h3 style="color: #3498db;">Nominee 4</h3>
            <hr />
            <br />
            <div>
                <div class="form-group selectTab col-6">
                <asp:DropDownList ID="SalutationDropDownList80" runat="server"  required="true"  style="font-size:12px;"  Width="30%">
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group  col-6">
                  <label for="Txt4thNomineeName"  style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txt4thNomineeName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                  <div class="form-group  col-6">
                  <label for="Txt4thMiddleName"  style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="Txt4thMiddleName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group  col-6">
                  <label for="Txt4thLastName"  style="font-size:12px;">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txt4thLastName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab col-6">
                <asp:DropDownList ID="GenderDropDownList81" runat="server" required="true"  style="font-size:12px;" Width="30%">
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group  col-6">
                  <label for="Txt4thNomineeDob"  style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txt4thNomineeDob"  runat="server" Width="30%"  required="true" TextMode="Date"></asp:TextBox>
                  </div>

                <div class="form-group selectTab col-6">
                <asp:DropDownList ID="RelationDropDownList82" runat="server" required="true" style="font-size:12px;"  Width="30%" >
                    <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group">
                  <label for="Txt4thNomineeAge" style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txt4thNomineeAge"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="Txt4thNominee_PercentageofEntitlementonlyincaseofNominee" style="font-size:12px;">Percentage of Entitlement only in case of Nominee</label>
                &nbsp;<asp:TextBox ID="Txt4thNominee_PercentageofEntitlementonlyincaseofNominee"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="TextBox86" style="font-size:12px;">Mobile Number</label><br />
                &nbsp;<asp:TextBox ID="TextBox189"  runat="server" Width="30%"  required="true" TextMode="Number"></asp:TextBox>
                  </div>

            </div>

         <%--   <h3 style="color: #3498db;">Nominee 5</h3>
            <hr />
            <br />
            <div >--%>
                <%--<div class="form-group selectTab">
                <asp:DropDownList ID="SalutationDropDownList83" runat="server" Width="30%"  required="true" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <%--<asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>--%>
                <%--</asp:DropDownList>--%>
                <%--</div>--%>

                 <%-- <div class="form-group">
                  <label for="Txt5thNomineeName"  style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txt5thNomineeName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                  <div class="form-group ">
                  <label for="Txt5thMiddleName"  style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="Txt5thMiddleName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>--%>

               <%-- <div class="form-group ">
                  <label for="Txt5thLastName" style="font-size:12px;">Last Name</label>
                &nbsp;<asp:TextBox ID="Txt5thLastName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>--%>

                 <%--<div class="form-group selectTab">
                <asp:DropDownList ID="GenderDropDownList84" runat="server" Width="30%"  required="true" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <%--<asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>--%>
                    <%--<asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>--%>
              <%--  </div>--%>

                 <%--  <div class="form-group">
                  <label for="Txt5tNomineeDob"  style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txt5tNomineeDob"  runat="server" Width="30%"  required="true" TextMode="Date"></asp:TextBox>
                  </div>--%>

             <%--   <div class="form-group selectTab">
                <asp:DropDownList ID="RelationDropDownList85" runat="server" Width="30%" required="true" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                  <%--  <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
                <%--</div>--%>

              <%--  <div class="form-group">
                  <label for="Txt5thNomineeAge" style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txt5thNomineeAge"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>--%>

               <%-- <div class="form-group  col-6">
                  <label for="Txt5thNomineePercentageofEntitlementonlyincaseofNominee"  style="font-size:12px;">Percentage of Entitlement only in case of Nominee</label>
                &nbsp;<asp:TextBox ID="Txt5thNomineePercentageofEntitlementonlyincaseofNominee"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>--%>

             <%--   <div class="form-group  col-6">
                  <label for="TextBox86"  style="font-size:12px;">Mobile Number</label><br />
                &nbsp;<asp:TextBox ID="TextBox196"  runat="server" Width="30%"  required="true" TextMode="Number"></asp:TextBox>
                  </div>

            </div>--%>

            <h3 style="color: #3498db;">Appointee 1</h3>
            <hr />
            <br />
            <div>
                <div class="form-group selectTab">
                <asp:DropDownList ID="app1SalutationDropDownList74" runat="server" Width="30%" required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group">
                  <label for="Txtapp1Name"  style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txtapp1Name"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtaPP1MiddleName" style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="TxtaPP1MiddleName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="Txtapp1LastName"  style="font-size:12px;">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txtapp1LastName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab">
                <asp:DropDownList ID="App1GenderDropDownList75" runat="server" Width="30%" required="true" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group">
                  <label for="Txtapp1DateofBirth" style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txtapp1DateofBirth"  runat="server" Width="30%" required="true" TextMode="Date"></asp:TextBox>
                  </div>

                <div class="form-group selectTab">
                <asp:DropDownList ID="App1RelationDropDownList76" runat="server"  Width="30%" required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group">
                  <label for="Txtapp1Age"  style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txtapp1Age"  runat="server" Width="30%"  required="true" TextMode="Number"></asp:TextBox>
                  </div>
            </div>
             <h3 style="color: #3498db;">Appointee 2</h3>
            <hr />
            <br />
            <div >
                <div class="form-group selectTab">
                <asp:DropDownList ID="app2SalutationDropDownList86" runat="server" Width="30%"  required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group">
                  <label for="Txtapp2Name"  style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txtapp2Name"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtaPP2MiddleName">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="TxtaPP2MiddleName"  runat="server" Width="30%" ></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="Txtapp2LastName"  style="font-size:12px;">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txtapp2LastName"  runat="server" Width="30%" required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab">
                <asp:DropDownList ID="App2GenderDropDownList87" runat="server" Width="30%" required="true" style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group">
                  <label for="Txtapp2DateofBirth"  style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txtapp2DateofBirth"  runat="server" Width="30%"  required="true" TextMode="Date"></asp:TextBox>
                  </div>

                <div class="form-group selectTab">
                <asp:DropDownList ID="App2RelationDropDownList88" runat="server" Width="30%"  required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group">
                  <label for="Txtapp2Age" style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txtapp2Age"  runat="server" Width="30%"  required="true" TextMode="Number"></asp:TextBox>
                  </div>
            </div>
             <h3 style="color: #3498db;">Appointee 3</h3>
            <hr />
            <br />
            <div>
                <div class="form-group selectTab">
                <asp:DropDownList ID="app3SalutationDropDownList89" runat="server" Width="30%"  required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group">
                  <label for="Txtapp3Name"  style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txtapp3Name"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtaPP3MiddleName" style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="TxtaPP3MiddleName"  runat="server" Width="30%" ></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="Txtapp3LastName" style="font-size:12px;">Last Name</label>
                &nbsp;<asp:TextBox ID="Txtapp3LastName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab">
                <asp:DropDownList ID="App3GenderDropDownList90" runat="server" Width="30%" required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group">
                  <label for="Txtapp3DateofBirth">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txtapp3DateofBirth"  runat="server" Width="30%" required="true" TextMode="Date"></asp:TextBox>
                  </div>

                <div class="form-group selectTab">
                <asp:DropDownList ID="App3RelationDropDownList91" runat="server" Width="30%"  required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group">
                  <label for="Txtapp3Age" style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txtapp3Age"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
            </div>
             <h3 style="color: #3498db;">Appointee 4</h3>
            <hr />
            <br />
            <div>
                <div class="form-group selectTab">
                <asp:DropDownList ID="app4SalutationDropDownList92" runat="server" Width="30%"  required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Salutation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Ms</asp:ListItem>
                </asp:DropDownList>
                </div>

                  <div class="form-group">
                  <label for="Txtapp4Name" style="font-size:12px;">Name</label><br />
                &nbsp;<asp:TextBox ID="Txtapp4Name"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                  <div class="form-group">
                  <label for="TxtaPP4MiddleName" style="font-size:12px;">Middle Name</label><br />
                &nbsp;<asp:TextBox ID="TxtaPP4MiddleName"  runat="server" Width="30%"  required="true"></asp:TextBox>
                  </div>

                <div class="form-group">
                  <label for="Txtapp4LastName"  style="font-size:12px;">Last Name</label><br />
                &nbsp;<asp:TextBox ID="Txtapp4LastName"  runat="server" Width="30%"></asp:TextBox>
                  </div>

                 <div class="form-group selectTab">
                <asp:DropDownList ID="App4GenderDropDownList93" runat="server" required="true"  style="font-size:12px;"  Width="30%">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Gender" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                </div>

                   <div class="form-group">
                  <label for="Txtapp4DateofBirth"  style="font-size:12px;">Date of Birth</label><br />
                &nbsp;<asp:TextBox ID="Txtapp4DateofBirth"  runat="server" Width="30%"  required="true" TextMode="Date"></asp:TextBox>
                  </div>

                <div class="form-group selectTab">
                <asp:DropDownList ID="App4RelationDropDownList94" runat="server" Width="30%" required="true"  style="font-size:12px;">
                    <%--<asp:ListItem>select the value</asp:ListItem>--%>
                    <asp:ListItem Text="Relation" Value="" Disabled="True" Selected="True"></asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Husband</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                </asp:DropDownList>
                </div>

                <div class="form-group">
                  <label for="Txtapp4Age"  style="font-size:12px;">Age</label><br />
                &nbsp;<asp:TextBox ID="Txtapp4Age"  runat="server" Width="30%" required="true" TextMode="Number"></asp:TextBox>
                  </div>
            </div>
            <div class="form-group">
                <%--<asp:ListItem>select the value</asp:ListItem>--%>

            </div>
      
                <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button11" onclick="Button11_Click" runat="server" Text="Submit" BackColor="#33CCFF" Height="45px" Width="150px" />
                <asp:Button ID="Button12" OnClientClick="Reset()" runat="server" Text="Reset" BackColor="#33CCFF" Height="45px" Width="150px" />


        </p>

    </form>
    <script>
        function Reset() {
            alert("Reset Sucessfully!");
            document.getElementById("form1").reset();
        }

        function confirmMsg() {
            //if (confirm('Record Updated Successfully For COI : ' + COI + ' Do you want move to QualityCheck List')) {
            alert("Record Saved Successfully");
            /*  window.location = "QCDashboard.aspx";*/
        }



        function toggleDivs(PD1NoofLifeCoveredDropDownList44) {
            // Get the selected value
            var selectedValue = PD1NoofLifeCoveredDropDownList44.value;

            // Hide all sections by default
            var sections = document.querySelectorAll('.additional-section');
            sections.forEach(function (section) {
                section.style.display = 'none';
            });

            // Based on the selected value, show the relevant sections
            if (selectedValue === "1") {
                document.getElementById('section1').style.display = 'block';
            } else if (selectedValue === "2") {
                document.getElementById('section1').style.display = 'block';
                document.getElementById('section2').style.display = 'block';
            } else if (selectedValue === "3") {
                document.getElementById('section1').style.display = 'block';
                document.getElementById('section2').style.display = 'block';
                document.getElementById('section3').style.display = 'block';
            }
        }



    </script>
</body>
</html>

