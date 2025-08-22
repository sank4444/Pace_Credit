using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using System.Data;

namespace GlimpsBAL
{
    public class ContactInfoBAL
    {
        ContactInfoDAL contactInfoDAL = null;
        public DataSet GetContactInfo(int UserUID)
        {
            contactInfoDAL = new ContactInfoDAL();
            string XmlData = string.Empty;
            return contactInfoDAL.GetContactInfo(XmlData, UserUID);
        }
        //ls
        public DataSet GetContactInfo_cr(int UserUID)
        {
            contactInfoDAL = new ContactInfoDAL();
            string XmlData = string.Empty;
            //return contactInfoDAL.GetContactInfo(XmlData, UserUID);
            return contactInfoDAL.GetContactInfo_cr(XmlData, UserUID);

        }

        public DataSet GetContactInfoPopUp(string UserUID)
        {
            contactInfoDAL = new ContactInfoDAL();
            
            string XML = "<params><param>";
            XML += "<ClientUnitUID>" + string.Empty + "</ClientUnitUID>";
            
            XML += "</param></params>";
            return contactInfoDAL.GetContactInfoPopUp(XML, UserUID);
        }
        //LS
        public DataSet GetContactInfoPopUp_cr(string UserUID)
        {
            contactInfoDAL = new ContactInfoDAL();

            string XML = "<params><param>";
            XML += "<ClientUnitUID>" + string.Empty + "</ClientUnitUID>";

            XML += "</param></params>";
            return contactInfoDAL.GetContactInfoPopUp_cr(XML, UserUID);
        }

        public int SaveContactInfoPopUp(ContactInfo contactInfo, string userUID,string action)
        {
            contactInfoDAL = new ContactInfoDAL();
           // contactInfo = new ContactInfo();

            string XML = "<params><param>";
           // XML += "<ClientUnitCode>" + contactInfo.UnitCode + "</ClientUnitCode>";
           // XML += "<ClientUnitName>" + contactInfo.UnitName + "</ClientUnitName>";
           // XML += "<ClientUID>" + contactInfo.ClinetnCode + "</ClientUID>";
           // XML += "<ClientName>" + contactInfo.ClientName + "</ClientName>";
            //XML += "<Contactper>" + contactInfo.Contactper + "</Contactper>";
            //XML += "<CorresAdd>" + contactInfo.CorresAdd + "</CorresAdd>";
            XML += "<Address>" + contactInfo.RegAdd + "</Address>";
           //XML += "<Fk_CountryUID>" + contactInfo.Country + "</Fk_CountryUID>";
            //XML += "<CityID>" + contactInfo.City + "</CityID>";
            //XML += "<StateID>" + contactInfo.State + "</StateID>";
           //XML += "<PinCodeID>" + contactInfo.Pin + "</PinCodeID>";
            //XML += "<Phone>" + contactInfo.Phone + "</Phone>";
            //XML += "<Fax>" + contactInfo.Fax + "</Fax>";
            XML += "<ContactPersonContact>" + contactInfo.Mobile + "</ContactPersonContact>";
            XML += "<ContactPersonEmail>" + contactInfo.EmailID + "</ContactPersonEmail>";
            //XML += "<BankName>" + contactInfo.BankName + "</BankName>";
            //XML += "<AccountNumber>" + contactInfo.AccountNumber + "</AccountNumber>";
            //XML += "<MICRCode>" + contactInfo.MICRCode + "</MICRCode>";
            //XML += "<NEFT_IFSC_Code>" + contactInfo.NEFT_IFSC_Code + "</NEFT_IFSC_Code>";
            //XML += "<Branch>" + contactInfo.Branch + "</Branch>";
            //XML += "<PanCardNo>" + contactInfo.PancardNo + "</PanCardNo>";
            //XML += "<RegAdd>" + contactInfo.RegAdd + "</RegAdd>";
            //XML += "<fk_RegionUID>" + contactInfo.RegionCode + "</fk_RegionUID>";
            //XML += "<Fk_SalesMngrUID>" + contactInfo.SalesManager + "</Fk_SalesMngrUID>";

            XML += "<ClientUnitUID>" + contactInfo.ClientUnitUID + "</ClientUnitUID>";
            XML += "<ContactPersonDesignation>" + contactInfo.Designation + "</ContactPersonDesignation>";
            XML += "<ContactPerson>" + contactInfo.ContPerName + "</ContactPerson>";
            XML += "</param></params>";
            return contactInfoDAL.SaveContactInfoPopUp( userUID,XML,action);

        }
        //LS
        public int SaveContactInfoPopUp_cr(ContactInfo contactInfo, string userUID, string action)
        {
            contactInfoDAL = new ContactInfoDAL();
            // contactInfo = new ContactInfo();

            string XML = "<params><param>";
            // XML += "<ClientUnitCode>" + contactInfo.UnitCode + "</ClientUnitCode>";
            // XML += "<ClientUnitName>" + contactInfo.UnitName + "</ClientUnitName>";
            // XML += "<ClientUID>" + contactInfo.ClinetnCode + "</ClientUID>";
            // XML += "<ClientName>" + contactInfo.ClientName + "</ClientName>";
            //XML += "<Contactper>" + contactInfo.Contactper + "</Contactper>";
            //XML += "<CorresAdd>" + contactInfo.CorresAdd + "</CorresAdd>";
            XML += "<Address>" + contactInfo.RegAdd + "</Address>";
            //XML += "<Fk_CountryUID>" + contactInfo.Country + "</Fk_CountryUID>";
            //XML += "<CityID>" + contactInfo.City + "</CityID>";
            //XML += "<StateID>" + contactInfo.State + "</StateID>";
            //XML += "<PinCodeID>" + contactInfo.Pin + "</PinCodeID>";
            //XML += "<Phone>" + contactInfo.Phone + "</Phone>";
            //XML += "<Fax>" + contactInfo.Fax + "</Fax>";
            XML += "<ContactPersonContact>" + contactInfo.Mobile + "</ContactPersonContact>";
            XML += "<ContactPersonEmail>" + contactInfo.EmailID + "</ContactPersonEmail>";
            //XML += "<BankName>" + contactInfo.BankName + "</BankName>";
            //XML += "<AccountNumber>" + contactInfo.AccountNumber + "</AccountNumber>";
            //XML += "<MICRCode>" + contactInfo.MICRCode + "</MICRCode>";
            //XML += "<NEFT_IFSC_Code>" + contactInfo.NEFT_IFSC_Code + "</NEFT_IFSC_Code>";
            //XML += "<Branch>" + contactInfo.Branch + "</Branch>";
            //XML += "<PanCardNo>" + contactInfo.PancardNo + "</PanCardNo>";
            //XML += "<RegAdd>" + contactInfo.RegAdd + "</RegAdd>";
            //XML += "<fk_RegionUID>" + contactInfo.RegionCode + "</fk_RegionUID>";
            //XML += "<Fk_SalesMngrUID>" + contactInfo.SalesManager + "</Fk_SalesMngrUID>";

            XML += "<ClientUnitUID>" + contactInfo.ClientUnitUID + "</ClientUnitUID>";
            XML += "<ContactPersonDesignation>" + contactInfo.Designation + "</ContactPersonDesignation>";
            XML += "<ContactPerson>" + contactInfo.ContPerName + "</ContactPerson>";
            XML += "</param></params>";
            return contactInfoDAL.SaveContactInfoPopUp_cr(userUID, XML, action);

        }
        public int SaveContactInfo(ContactInfo contactInfo)
        {
            contactInfoDAL = new ContactInfoDAL();
            contactInfo = new ContactInfo();
            return contactInfoDAL.SaveContactInfo(contactInfo);
        }
    }
}
