using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlimpsDAL
{

    ///Class cotains values of SqlPameters 

    public class SqlParameters
    {
        public const string PolicyMemberUIDXml = "@xmlDataStr"; // add by ramesh for coi-print
        public const string subOfficeId = "@subOfficeId";
        public const string xmldata = "@xmldata";
        public const string XMLDATASTR = "@xmlDataStr";
        public const string REPORT = "@REPORT";
        
        public const string SearchCateria = "@SearchCateria";
        public const string UserUID = "@UserUID";
        public const string UserUID1 = "@UserID";
        public const string ApplicationUID = "@ApplicationUID";
        public const string pa_RateCode = "@pa_RateCode";
        public const string action = "@action";
        public const string INTERRORNO = "@INTERRORNO";
        public const string PA_CODE = "@pa_code";
        

        //Contact Information


        //MemberInformation PopUp
        public const string PolicyUID = "@PolicyUID";
        public const string RenewalNoUID = "@RenewalNoUID";
        public const string PolicyMemberUID = "@PolicyMemberUID";
        public const string module = "@module";
        public const string Process = "@Process";
        public const string Fk_PolServicingRequestUID = "@Fk_PolServicingRequestUID";

        public const string SUBPROCESS = "@SubProcess";
       
        public const string CreatedBy = "@CreatedBy"; 

         
        //BillEnquiry
        public const string billNo = "@billNo";
        //Online Enquery
        public const string ID = "@Id";
        public const string ANSWERS = "@Answers";
        public const string ISACTIVE = "@IsActive ";
        //Servicing
        public const string TransactionID = "@TransactionID";
        public const string BillUID = "@BillUID";
        public const string Type = "@Type";
        public const string ServiceReqNo = "@ServiceReqNo";
        public const string SUBACTION = "@SubAction";

        public const string MemberUID = "@MemberUID";

        //mailing
        public const string ATTACHEMENT1 = "@Attachement1";
        public const string CommonListMainCode = "@CommonListMainCode";
        
        
    }
}
