
//Added by Karunakar on 28-04-2016 START
//var srcl = "TATA AIA LIFE INSURANCE  ";
//function marqtitle() {
//    srcl = srcl.substring(1, srcl.length) + srcl.substring(0, 1);
//    document.title = srcl;
//    setTimeout("marqtitle()", 500);
//}

function TTSLErrorFlag() {
    alert('Your not authorised to view this page');
    //history.back();
    window.location.href = "../Default.aspx";
}


//END

function myFunction(dd) {
    //var divID = dd.InnerHml();
    if (dd == 'PolicyNumber') {
        $("#myDropdown").toggleClass("show");
        $("#Div1").removeClass("show");
        $("#Div2").removeClass("show");
        $("#Div3").removeClass("show");
        $("#Div4").removeClass("show");
        $("#Div5").removeClass("show");
    }
    else if (dd == 'MemberInformation') {
        $("#Div1").toggleClass("show");
        $("#myDropdown").removeClass("show");
        $("#Div2").removeClass("show");
        $("#Div3").removeClass("show");
        $("#Div4").removeClass("show");
        $("#Div5").removeClass("show");

    }
    else if (dd == 'Billing') {
        $("#Div2").toggleClass("show");
        $("#myDropdown").removeClass("show");
        $("#Div1").removeClass("show");
        $("#Div3").removeClass("show");
        $("#Div4").removeClass("show");
        $("#Div5").removeClass("show");

    }
    else if (dd == 'Servicing') {
        $("#Div3").toggleClass("show");
        $("#myDropdown").removeClass("show");
        $("#Div2").removeClass("show");
        $("#Div1").removeClass("show");
        $("#Div4").removeClass("show");
        $("#Div5").removeClass("show");

    }
    else if (dd == 'Miscellaneous') {
        $("#Div4").toggleClass("show");
        $("#myDropdown").removeClass("show");
        $("#Div2").removeClass("show");
        $("#Div3").removeClass("show");
        $("#Div1").removeClass("show");
        $("#Div5").removeClass("show");

    }
    else if (dd == 'Claims') {

        $("#Div5").toggleClass("show");
        $("#myDropdown").removeClass("show");
        $("#Div2").removeClass("show");
        $("#Div3").removeClass("show");
        $("#Div4").removeClass("show");
        $("#Div1").removeClass("show");

    }


}


function dropDownChange(eDropDownList) {
    var eAnchor = $("input[id*='A1']");
    var selectedValue = eDropDownList.options[eDropDownList.selectedIndex].value;
    if (selectedValue != "") {
        switch (selectedValue) {
            case "TRMMemAdd":
                eAnchor.href = "../DownloadFormate/PACE_POS_Add_Member.xls";
                break;
            case "TRMSalary":
                eAnchor.href = "../DownloadFormate/PACE_POS_Change_Salary_Member.xls";
                break;
            case "TRMFSA":
                eAnchor.href = "../DownloadFormate/PACE_POS_Change_FSA_Member.xls";
                break;
            case "TRMFSG":
                eAnchor.href = "../DownloadFormate/PACE_POS_Change_FSG_Member.xls";
                break;
            case "TRMDesignt":
                eAnchor.href = "../DownloadFormate/TermMemberPOS_Upload-Group Life.xls";
                break;
            case "TRMDOB":
                eAnchor.href = "../DownloadFormate/PACE_POS_Change_DOB_Member.xls";
                break;
            case "TRMEmpNo":
                eAnchor.href = "../DownloadFormate/PACE_POS_Change_EmployeeNo_Member.xls";
                break;
            case "TRMGender":
                eAnchor.href = "../DownloadFormate/PACE_POS_Change_Gender_Member.xls";
                break;
            case "TRMMemDel":
                eAnchor.href = "../DownloadFormate/PACE_POS_Deletion_Member.xls";
                break;
            case "TRMName":
                eAnchor.href = "../DownloadFormate/PACE_POS_Change_Name_Member.xls";
                break;
        }
    }
    else { alert("Please select " + eDropDownList); eDropDownList.focus(); }


}

function popUpWindow() {
    window.showModalDialog('PopUpBillGeneration.aspx', 'popWindow', "dialogHeight: 600px; dialogWidth: 960px; dialogTop: 180px; statusbar:yes; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes");
} //PopUp


function ServiceValidation() {
    var Servicing = $("select[id*='ddlServicingChange']");
    var FileUpload = $("input[id*='FUploadfile']");
    if (FileUpload.val() != "") {
        var fileExtension = ['xls', 'xlsx'];
        if ($.inArray(FileUpload.val().split('.').pop().toLowerCase(), fileExtension) == -1) {
            $('#fileUpload').css('display', 'inline');
            $('#fileUpload').html('<span id="DisplayingError" class="DisplayingError">Invalid formate ! upoad only \'.xls\',\'.xlsx\' formats .</span>');
            $('#DisplayingError').click(function() { FileUpload.focus(); });
            FileUpload.focus();
            return false;
        }
    } //file upload is empty
    if (Servicing.val() == 0) {
        $('#ddlSC').css('display', 'inline');
        $('#ddlSC').html('<span id="DisplayingError" class="DisplayingError">Select Service Changes</span>');
        $('#DisplayingError').click(function() { Servicing.focus(); });
        Servicing.focus();
        return false;
    } //checking dropdown
    else if (FileUpload.val() == "") {
        $('#fileUpload').css('display', 'inline');
        $('#fileUpload').html('<span id="DisplayingError" class="DisplayingError">File upload can\'t be empty.</span>');
        $('#DisplayingError').click(function() { FileUpload.focus(); });
        FileUpload.focus();
        $('#ddlSC').css('display', 'none');
        return false;
    } //file upload is empty
    else {
        $('#ddlSC').css('display', 'none');
        $('#fileUpload').css('display', 'none');
        return true;
    }
} //validation

//pop up window
function focusPopup() {
    if (popupWindow && !popupWindow.closed) { popupWindow.focus(); }
}

function WindowOpen(pageName) {
    var popupWindow;
    // to handle in Firefox
    if (window.open) {
        window.parent.blur();
        popupWindow = window.open(pageName, '_blank', 'width=960,height=600, scrollbars=yes,resizable=yes');
        //myWindow.focus();
    }
    else if (window.showModalDialog) {
    window.parent.blur();
        popupWindow = window.showModalDialog(pageName, null, "addressBar:yes; dialogHeight: 600px; dialogWidth: 960px; dialogTop: 180px; statusbar:yes; dialogLeft: 350px; edge: Raised;help: Yes; resizable: Yes; status: Yes; center:yes");
        //myWindow.focus();
    }
    else {
        popupWindow = window.open(pageName, '_blank', 'width=960,height=600, scrollbars=yes,resizable=yes');
        //myWindow.focus();
    }
    
}



function dispalyMsg(Message) {
    alert(Message);
}
function clientDetailFlag() {
    window.onload = function() {
        //        alert('Please update suboffice contact detail.');
        window.location = '../Default.aspx';
    }
}

function LoginValidation() {


    var userName = $("input[id*='txtUserName']").val().trim();
    var password = $("input[id*='txtPassword']").val().trim();

    if (userName == "" || userName == "User Name") {
        $("#lblUserName").css("display", "inline");

        return false;
    } //end if
    else if (userName != "" || userName != "User Name") {
        $("#lblUserName").css("display", "none");
        if (password == "" || password == "Password") {
            $("#lblPass").css("display", "inline");
            return false;
        } //end if
        else {
            $("#lblPass").css("display", "none");
            return true;
        }
    }
}
function RemoveSpecialChar(txtName) {
    if (txtName.value != '' && txtName.value.match(/^[\w ]+$/) == null) {
        txtName.value = txtName.value.replace(/[\W]/g, '');
    }
}
function ServiceRequestValidation() {
    var RequestType = $("select[id*='ddlServiceRequestType']");
    var Category = $("select[id*='ddlCategory']");

    var FileUpload = $("input[id*='fuServiceRequest']");
    if (FileUpload.val() != "") {
        var fileExtension = ['PDF', 'pdf'];
        if ($.inArray(FileUpload.val().split('.').pop().toLowerCase(), fileExtension) == -1) {
            $('#fuUpload').css('display', 'inline');
            $('#fuUpload').html('<span id="DisplayingError" class="DisplayingError">Only PDF formate is allowed</span>');
            FileUpload.focus();
            $('#DisplayingError').click(function() { FileUpload.focus(); });
            return false;
        }
    }
    if (RequestType.val() == 0) {
        $('#ServiceRequestType').css('display', 'inline');
        $('#ServiceRequestType').html('<span id="DisplayingError" class="DisplayingError">Select service request</span>');
        RequestType.focus();
        $('#DisplayingError').click(function() { RequestType.focus(); });
        return false;
    }
    else if (Category.val() == 0) {
        $('#Category').css('display', 'inline');
        $('#Category').html('<span id="DisplayingError" class="DisplayingError">Select service category</span>');
        Category.focus();
        $('#DisplayingError').click(function() { Category.focus(); });
        $('#ServiceRequestType').css('display', 'none');
        return false;
    }
    else if (FileUpload.val() == "") {
        $('#fuUpload').css('display', 'inline');
        $('#fuUpload').html('<span id="DisplayingError" class="DisplayingError">Upload a file</span>');

        FileUpload.focus();
        $('#Category').css('display', 'none');
        return false;
    }
    else {
        $('#ServiceRequestType').css('display', 'none');
        $('#Category').css('display', 'none');
        return true;
    }

}


function Confirm(HiddenFiled) {
    if (confirm('Do you want move Request List then press \"OK\"')) {
        HiddenFiled.value = "Yes";
    } else {
        HiddenFiled.value = "No";
    }
    return HiddenFiled.value;
}


function PremiumStatementValidation() {

    var FromDate = $("input[id*='txtFromDate']");
    var ToDate = $("input[id*='txtToDate']");
    if (FromDate.val() == "") {
        $('#divDate').css('display', 'inline');
        $('#divDate').html('<span id="DisplayingError" class="DisplayingError">Select DATE </span>');
        FromDate.focus();
        $('#DisplayingError').click(function() { FromDate.focus(); });
        return false;
    }
    else if (ToDate.val() == "") {
        $('#divDate').css('display', 'inline');
        $('#divDate').html('<span id="DisplayingError" class="DisplayingError">Select DATE  </span>');
        ToDate.focus();
        $('#DisplayingError').click(function() { ToDate.focus(); });
        return false;
    }
    else {
        return true;
    }
}
function validatePhone(phoneText) {
    var filter = /^[0-9-+]+$/;
    if (filter.test(phoneText)) {
        return true;
    }
    else {
        return false;
    }
}


function ClaimIntimationValidation() {

    //    var InsuredMember = $("input[id*='txtInsuredMember']");
    //    if (InsuredMember.val() == "") {
    //        $('#InsuredMember').css('display', 'inline');
    //        $('#InsuredMember').html('<span id="DisplayingError" class="DisplayingError">Name of Insured member is required </span>');
    //        InsuredMember.focus();
    //        $('#DisplayingError').click(function() { InsuredMember.focus(); });
    //        return false;
    //    }
    //    //Added by Karunakar on 28-04-2016 START
    //    var NameofCaller = $("input[id*='txtNameCaler']");
    //    if (NameofCaller.val() == "") {
    //        $('#Namecaler').css('display', 'inline');
    //        $('#Namecaler').html('<span id="DisplayingError" class="DisplayingError">Name of Insured member is required </span>');
    //        NameofCaller.focus();
    //        $('#DisplayingError').click(function() { NameofCaller.focus(); });
    //        return false;
    //    }

    var MobileNoCaler = $("input[id*='txtMobileCler']");
    if (MobileNoCaler.val() == "") {
        $('#MobileCler').css('display', 'inline');
        $('#MobileCler').html('<span id="DisplayingError" class="DisplayingError">Mobile number of caller is required </span>');
        MobileNoCaler.focus();
        $('#DisplayingError').click(function() { MobileNoCaler.focus(); });
        return false;
    }

    if (MobileNoCaler.val() != "") {
        if (!validatePhone(MobileNoCaler)) {
            $('#MobileCler').css('display', 'inline');
            $('#MobileCler').html('<span id="DisplayingError" style="Display:static;" class="DisplayingError">invalid mobile number!</span>');
            MobileNoCaler.focus();
            $('#DisplayingError').click(function() { MobileNoCaler.focus(); });
            return false;
        }
    }
    //   
    //    var RelcalInsured = $("input[id*='txtRelcalInsured']");
    //    if (RelcalInsured.val() == "") {
    //        $('#RelcalInsured').css('display', 'inline');
    //        $('#RelcalInsured').html('<span id="DisplayingError" class="DisplayingError">Relationship of caller with insured is required </span>');
    //        NameofCaller.focus();
    //        $('#DisplayingError').click(function() { RelcalInsured.focus(); });
    //        return false;
    //    }
    //    var Address = $("input[id*='txtAddress']");
    //    if (Address.val() == "") {
    //        $('#Address').css('display', 'inline');
    //        $('#Address').html('<span id="DisplayingError" class="DisplayingError">Address is required </span>');
    //        NameofCaller.focus();
    //        $('#DisplayingError').click(function() { Address.focus(); });
    //        return false;
    //    }
    else {
        return true;
    }
    //end
}

function InvokePop(fname) {
    val = document.getElementById(fname).value;
    // to handle in IE 7.0           
    if (window.showModalDialog) {
        retVal = window.showModalDialog("../Services/PopUpCommonSearch.aspx?Control1=" + fname + "&ControlVal=" + val, 'Show Popup Window', "dialogHeight: 600px; dialogWidth: 960px; dialogTop: 180px; statusbar:yes; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes");
        document.getElementById(fname).value = retVal;
    }
    // to handle in Firefox
    else {
        retVal = window.open("../Services/PopUpCommonSearch.aspx?Control1=" + fname + "&ControlVal=" + val, 'Show Popup Window', 'dialogHeight: 600px; dialogWidth: 960px; dialogTop: 180px; statusbar:yes; dialogLeft: 350px; edge: Raised;help: No; resizable: Yes; status: No; center:yes');
        retVal.focus();
    }
}

function ReverseString(retCOI) {
    var originalString = document.getElementById(retCOI).value;
    //var reversedString = Reverse(originalString);
    RetrieveControl();
    // to handle in IE 7.0
    if (window.showModalDialog) {
        window.returnValue = originalString;
        window.close();
    }
    // to handle in Firefox
    else {
        if ((window.opener != null) && (!window.opener.closed)) {
            // Access the control.
            window.opener.document.getElementById(ctr[1]).value = originalString;
            // window.opener.document.getElementById(ctr[1]).value = reversedString;
        }
        window.close();
    }
}


function RetrieveControl() {
    //Retrieve the query string 
    queryStr = window.location.search.substring(1);
    // Seperate the control and its value
    ctrlArray = queryStr.split("&");
    ctrl1 = ctrlArray[0];
    //Retrieve the control passed via querystring 
    ctr = ctrl1.split("=");
}

//function DataTableInGrid() {
//    $(document).ready(function() {
//        var Gridview = $(".display");
//        if (Gridview.visible == true) {
//            $('.display').DataTable({
//                'scrollCollapse': true,
//                'lengthMenu': [[5, 10, 15, -1], [5, 10, 15, 'All']]
//            });
//        }
//    });
//}