using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using System.Data;
using GlimpsDAL.Common;

namespace GlimpsBAL
{
   public class ClaimBAL
    {
        #region Service Request DropDown
        public DataSet ServiceRequestTypeDDL(string UserUID)
        {
            try
            {
                return ClaimDAL.ServiceRequestTypeDDL(UserUID, string.Empty, CommonConstantNames.PACESERVICING);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        #endregion

        #region category DropDown
        public DataSet categoryDDL(string UserUID)
        {
            try
            {
                string XML = string.Empty;
                return ClaimDAL.categoryDDL(UserUID, XML, "PACESUBCATSERVICINGCLR");
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        #endregion

        #region Saving Service Request

        public DataSet SavingClaimRequest(ClaimInfo objClaimInfo, string userId, string FK_RequestTypeUID )
        {
            string XML = string.Empty;
            try
            {
                XML += "<params><param>";
                XML += "<RequestType>" + FK_RequestTypeUID + "</RequestType>";
                XML += "<FK_SubRequestTypeUID>" +objClaimInfo.category + "</FK_SubRequestTypeUID>";
                XML += "<COI>" + objClaimInfo.COI + "</COI>";
                XML += "<FilePath>" + objClaimInfo.FilePath + "</FilePath>";
                XML += "<DateOfDeath>" + objClaimInfo.DtofDeath + "</DateOfDeath>";
                XML += "<CauseOfDeath>" + objClaimInfo.CauseDeath + "</CauseOfDeath>";
                XML += "<NameOfCaller>" + objClaimInfo.NameCaler + "</NameOfCaller>";
                XML += "<RelationOfCaller>" + objClaimInfo.RelcalInsured + "</RelationOfCaller>";
                XML += "<AddressOfCaller>" + objClaimInfo.Address + "</AddressOfCaller>";
                XML += "<MobileNoOfCaller>" + objClaimInfo.MobileNoCaler+ "</MobileNoOfCaller>";
                
                XML += "</param></params>";

                return ClaimDAL.SavingClaimRequest(userId, XML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }

}
