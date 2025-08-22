using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GlimpsDAL;
using System.Data.OleDb;
namespace GlimpsBAL
{
    public class _objConfigurationBAL
    {
        _objConfigurationDAL objConfigurationDAL = null;

        //Changed by Karunakar on 10/10/2016
        public DataSet GetPolicyYear(string UserUID, string ACTION)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "";
            return objConfigurationDAL.GetPolicyYear(xmldata, UserUID.ToString(), ACTION);
        }
        // Changes by LS
        public DataSet GetPolicyYear_cr(string UserUID, string ACTION)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "";
            //return objConfigurationDAL.GetPolicyYear(xmldata, UserUID.ToString(), ACTION);
            return objConfigurationDAL.GetPolicyYear_cr(xmldata, UserUID.ToString(), ACTION);
        }
        public DataSet GetServicingList(int UserUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "";
            return objConfigurationDAL.GetServicingList(xmldata, UserUID.ToString());
        }
        //LS
        public DataSet GetServicingList_cr(int UserUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "";
            return objConfigurationDAL.GetServicingList_cr(xmldata, UserUID.ToString());
        }
        public DataSet GetPolicyUID(int UserUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "";
            return objConfigurationDAL.GetPolicyUID(xmldata, UserUID.ToString());
        }
        //ls
        public DataSet GetPolicyUID_cr(int UserUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "";
            return objConfigurationDAL.GetPolicyUID_cr(xmldata, UserUID.ToString());
        }
        public DataSet premiumDll_cr(string UserUID, string policyUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "'<params><param><PolicyUID>" + policyUID + " </PolicyUID></param></params>'";
            return objConfigurationDAL.premiumFillDll_cr(xmldata, UserUID.ToString());
        }
        //RateOfInterest_cr
        public DataSet RateOfInterest_cr(string UserUID, string policyUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "'<params><param><PolicyUID>" + policyUID + " </PolicyUID></param></params>'";
            return objConfigurationDAL.RateOfInterest_crDAL(xmldata, UserUID.ToString());
        }
        //
        public DataSet PremiummodeTypeBAL(string UserUID, string policyUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "'<params><param><PolicyUID>" + policyUID + " </PolicyUID></param></params>'";
            return objConfigurationDAL.PremiummodeTypeDAL(xmldata, UserUID.ToString());
        }
        public DataSet SumassuredTypeBAL(string UserUID, string policyUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "'<params><param><PolicyUID>" + policyUID + " </PolicyUID></param></params>'";
            return objConfigurationDAL.SumassuredTypeDAL(xmldata, UserUID.ToString());
        }

        public DataSet PolicyBAL(string UserUID, string policyUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "'<params><param><PolicyUID>" + policyUID + " </PolicyUID></param></params>'";
            return objConfigurationDAL.PolicyDAL(xmldata, UserUID.ToString());
        }

        public DataSet SegmentCodeBAL(string UserUID, string policyUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "'<params><param><PolicyUID>" + policyUID + " </PolicyUID></param></params>'";
            return objConfigurationDAL.SegmentCodeDAL(xmldata, UserUID.ToString());
        }

        public DataSet Summsion_cr(int UserUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            //"'<params><param><PolicyUID></PolicyUID><ClientUID></ClientUID><ProductUID></ProductUID><SchemeType>" + SchemeType  + "</SchemeType><ProductType>" + ProductType +"</ProductType></param></params>'";
            string xmldata = "'<params><param><PolicyUID></PolicyUID><ClientUID></ClientUID><ProductUID></ProductUID></param></params>'"; ;
            //return objConfigurationDAL.GetPolicyUID_cr(xmldata, UserUID.ToString());
            return objConfigurationDAL.SummsionDAL_cr(xmldata, UserUID.ToString());
        }

        public DataSet GetSalesManager(string UserUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "<params><param><SalesMngrUID></SalesMngrUID></param></params>";
            return objConfigurationDAL.GetSalesManager(xmldata, UserUID);
        }

        public DataSet GetAllCountry(string UserUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "<params><param><CountryUID></CountryUID></param></params>";
            return objConfigurationDAL.GetAllCountry(xmldata, UserUID);
        }

        public DataSet GetState(string UserUID, string CountryUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "<params><param><CountryUID>" + CountryUID + "</CountryUID></param></params>";
            return objConfigurationDAL.GetState(xmldata, UserUID);
        }

        public DataSet GetCity(string UserUID, string StateUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "<params><param><StateUID>" + StateUID + "</StateUID></param></params>";
            return objConfigurationDAL.GetCity(xmldata, UserUID);
        }

        public DataSet GetPin(string UserUID, string CityUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "<params><param><CityUID>" + CityUID + "</CityUID></param></params>";
            return objConfigurationDAL.GetPin(xmldata, UserUID);
        }

        public DataSet GetAllActiveRegions(string UserUID)
        {
            objConfigurationDAL = new _objConfigurationDAL();
            string xmldata = "<params><param><RegionUID></RegionUID></param></params>";
            return objConfigurationDAL.GetAllActiveRegions(xmldata, UserUID);
        }
        ///<summary>
        ///creating a dataset from xls , xlsx , csv, txt
        ///</summary>
        ///<param name ="strFilePath">The string file path</param>
        public DataSet CreateDataSet(string strFilePath, string strFileType)
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter da = new OleDbDataAdapter();
                string conString = string.Empty;
                //System.Data.Odbc.OdbcConnection CSVCon;
                //System.Data.Odbc.OdbcDataAdapter CSVDa;
                if (strFileType.ToLower().Trim() == ".xls")
                {
                    conString = "provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + "; Extended Properties=\"Excel 8.0; HDR=YES;IMEX=1\"";
                }
                else if (strFileType.ToLower().Trim() == ".xlsx")
                {
                    conString = "provider =Microsoft.Jet.OLEDB.12.0;Data Source=" + strFilePath + "; Extended Properties=\"Excel 12.0; HDR=YES;IMEX=1\"";
                }
                conn = new OleDbConnection(conString);
                //Open connection 
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd = new OleDbCommand("SELECT * FROM [SHEET1$]", conn);
                da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        //LS
        public DataSet CreateDataSet_cr(string strFilePath, string strFileType)
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter da = new OleDbDataAdapter();
                string conString = string.Empty;
                //System.Data.Odbc.OdbcConnection CSVCon;
                //System.Data.Odbc.OdbcDataAdapter CSVDa;
                if (strFileType.ToLower().Trim() == ".xls")
                {
                    // conString = "provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + "; Extended Properties=\"Excel 8.0; HDR=YES;IMEX=1\""; //using for testing in Local Machine
                       conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";


                }
                else if (strFileType.ToLower().Trim() == ".xlsx")//.xlsx
                {
                    conString = "provider =Microsoft.Jet.OLEDB.12.0;Data Source=" + strFilePath + "; Extended Properties=\"Excel 12.0; HDR=YES;IMEX=1\"";
                }
                conn = new OleDbConnection(conString);
                //Open connection 
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd = new OleDbCommand("SELECT * FROM [SHEET1$]", conn); //PremiumCalculation SHEET1$
               
                da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet CreateDataSet_crPre(string strFilePath, string strFileType)
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter da = new OleDbDataAdapter();
                string conString = string.Empty;
                //System.Data.Odbc.OdbcConnection CSVCon;
                //System.Data.Odbc.OdbcDataAdapter CSVDa;
                if (strFileType.ToLower().Trim() == ".xls")
                {
                    conString = "provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + "; Extended Properties=\"Excel 8.0; HDR=YES;IMEX=1\"";
                }
                else if (strFileType.ToLower().Trim() == ".xlsx")//.xlsx
                {
                    conString = "provider =Microsoft.Jet.OLEDB.12.0;Data Source=" + strFilePath + "; Extended Properties=\"Excel 12.0; HDR=YES;IMEX=1\"";
                }
                conn = new OleDbConnection(conString);
                //Open connection 
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd = new OleDbCommand("SELECT * FROM [SHEET1$]", conn); //PremiumCalculation SHEET1$

                da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
