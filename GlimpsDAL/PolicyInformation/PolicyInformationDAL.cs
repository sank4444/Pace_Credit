using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using GlimpsBAL;
using System.Data;
using System.Data.SqlClient;
using GlimpsDAL.Common;
using System.Configuration;


namespace GlimpsDAL
{
    public class PolicyInformationDAL
    {
        DataSet ds = null;
        DataTable dt = null;
        ConnectionString cs = new ConnectionString();
        private static string ConnString { get; set; }


        /// <summary>
        /// Gets the connection string for system Database TALIC_GLIMPSE_SysDB.
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnectionStringSysDB()
        {

            try
            {
                SqlConnection SqlConnStr = null;
                //ConnString = System.Configuration.ConfigurationSettings.AppSettings["GLIMPSEConnectionStringSysDB"].ToString();
                ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["GLIMPSEConnectionStringAppDB"].ToString(); //Added by Sandip (30-09-2019)
                SqlConnStr = new SqlConnection(ConnString);
                return SqlConnStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataSet GetAllClients(string XmlData, string searchCriteria, int? sUserUID, int? sApplicationUID) //ramesh 18/02/2025
        {
            
            try
            {
                //DataSet dsResult = new DataSet();
                //SqlParameter[] sqlParam = new SqlParameter[4];
                //sqlParam[0] = new SqlParameter("", XmlData);
                //sqlParam[1] = new SqlParameter("", searchCriteria);
                //sqlParam[2] = new SqlParameter("", sUserUID);
                //sqlParam[3] = new SqlParameter("", sApplicationUID);
                //return dsResult = SqlHelper.ExecuteDataset("GLIMPSEConnectionStringAppDB", CommandType.StoredProcedure, "PROC_COMMON_SELECT_POLICY", sqlParam);
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GLIMPSEConnectionStringAppDB"].ToString());
                con.Open();
                DataSet dsResult = new DataSet();
                SqlCommand cmd = new SqlCommand("PROC_COMMON_SELECT_POLICY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XmlData", XmlData);
                cmd.Parameters.AddWithValue("@SearchCateria", searchCriteria);
                cmd.Parameters.AddWithValue("@UserUID", sUserUID);
                cmd.Parameters.AddWithValue("@ApplicationUID", sApplicationUID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsResult);
                return dsResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetAllPolicyByClientUID(string XmlData, string searchCriteria, Int16 sUserUID, Int16 sApplicationUID)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GLIMPSEConnectionStringAppDB"].ToString());
                con.Open();
                DataSet dsResult = new DataSet();
                SqlCommand cmd = new SqlCommand("PROC_COMMON_SELECT_POLICY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XmlData", XmlData);
                cmd.Parameters.AddWithValue("@SearchCateria", searchCriteria);
                cmd.Parameters.AddWithValue("@UserUID", sUserUID);
                cmd.Parameters.AddWithValue("@ApplicationUID", sApplicationUID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsResult);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDatatable(string UserUID, string subOfficeUID)
        {
            ds = new DataSet("params");
            dt = new DataTable("param");
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn(CommonConstantNames.USERID,typeof(string)),
                                                    new DataColumn(CommonConstantNames.SUBOFFICEUID,typeof(string))});

            dt.Rows.Add(UserUID, subOfficeUID);
            //DataRow row = dt.NewRow();
            //row["UserUID"] = UserUID;
            //row["subOfficeUID"] = subOfficeUID;
            //dt.Rows.Add(row);
            dt.AcceptChanges();
            ds.Merge(dt);
            return ds;
        }

        //Main Menu Policy Information
        public DataTable PolicyInformationDetails(string XmlData, string UserUID, string subOfficeUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Select_pPolicy_Web, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    // ds = GetDatatable(UserUID, subOfficeUID);
                    //string xmlStr = ds.GetXml().ToString();
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }
        //LS 
        public DataTable PolicyInformationDetails_cr(string XmlData, string UserUID, string subOfficeUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Select_pPolicy_Web_PACE, con);//PEN_Proc_Select_pPolicy_Pace
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    // ds = GetDatatable(UserUID, subOfficeUID);
                    //string xmlStr = ds.GetXml().ToString();
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }

        //Policy premium rates
        public DataTable PremiumRates(string XmlData, string SearchCateria, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Common_xPolicy_Premium_Rate_Mapping_Web, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, SearchCateria);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }
        //ls
        public DataTable PremiumRates_cr(string XmlData, string SearchCateria, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_xPolicy_Premium_Rate_Mapping_Pace, con);
                                                                      //PEN_Proc_Common_xPolicy_Premium_Rate_Mapping_Pace
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, SearchCateria);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }

        //NEL 
        public DataTable DALNEL_cr(string XmlData, string Action, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Common_xPolicypMedicalNonMedicalMapping_PACE, con);
                    //TRM_Proc_Common_xPolicypMedicalNonMedicalMapping_PACE
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }
        //for Nel
        public DataSet GetPolicyNonMedicalLimit_cr(string XmlData, string Action, string userID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PROC_COMMON_MNONMEDICALLIMIT_PACE, con);//PROC_COMMON_MNONMEDICALLIMIT
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID1, userID.Trim());
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }

        public  DataSet GetPolicyMedicalNonMedicalGrid_cr(string XmlData, string Action, int userID)
        {
           
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Common_xPolicypMedicalNonMedicalMapping_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, userID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return ds;
        }
        //LS GetPolicySubOfficeAccessSelect_cr kjkj
        public int GetPolicySubOfficeAccessSelect_cr(string XmlData, string Action, string UserUID)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Pen_PROC_USER_CLIENTUNIT_ACCESS_MAPPING_Pace, con);
                    //Pen_PROC_USER_CLIENTUNIT_ACCESS_MAPPING_Pace
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    i = cmd.ExecuteNonQuery(); //da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return i;
        }

        public DataTable GetPolicySubOfficeAccess(string XmlData, string Action, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_USER_CLIENTUNIT_ACCESS_MAPPING_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds.Tables[0];
        }
        //LS selectrd
        public DataTable GetPolicySubOfficeAccess_cr(string XmlData, string Action, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    // SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_USER_CLIENTUNIT_ACCESS_MAPPING_WEB, con); LS 24 1146
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_USER_CLIENTUNIT_ACCESS_MAPPING_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds.Tables[0];
        }

        public int GetPolicySubOfficeAccessSelect(string XmlData, string Action, string UserUID)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_USER_CLIENTUNIT_ACCESS_MAPPING_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    i = cmd.ExecuteNonQuery(); //da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return i;
        }

        public DataSet GetBenifitBasis(string XmlData, string Action, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_PPOLICY_COVERAGE_SCREEN_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
        //ls
        public DataSet GetBenifitBasis_cr(string XmlData, string Action, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_pPolicy_Coverage_Screen_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
        public DataTable GetPolicyQuoteListing(string XmlData, string UserUID, string action)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_PPOLICY_QUOTE_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    // ds = GetDatatable(UserUID, subOfficeUID);
                    //string xmlStr = ds.GetXml().ToString();
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }
        //ARCHIVAL FOR PHASE 2 10/10/2016
        public DataTable GetArchive(string XmlData, string UserUID, string Action)
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PROC_POLICY_DOCUMENT, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    // ds = GetDatatable(UserUID, subOfficeUID);
                    //string xmlStr = ds.GetXml().ToString();
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        //Receipts and Payments FOR PHASE 2 12/10/2016
        public DataTable GetReceiptsandPaymentsDDL(string UserUID, string Action)
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PROC_RECEIPT_PAYMENT_SCREEN_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, "");
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        //ls
        public DataTable GetReceiptsandPaymentsDDL_cr(string UserUID, string Action)
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_RECEIPT_PAYMENT_SCREEN_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, "");
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        public DataSet GetReceiptsAndPaymentsGrid(string XmlData,string UserUID, string Action)
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PROC_RECEIPT_PAYMENT_SCREEN_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        /// <summary>
        /// Lakhapat Singh
        /// </summary>
        /// <param name="XmlData"></param>
        /// <param name="UserUID"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        public DataSet GetReceiptsAndPaymentsGrid_cr(string XmlData, string UserUID, string Action)
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_RECEIPT_PAYMENT_SCREEN_PACE, con);
                    //PEN_PROC_RECEIPT_PAYMENT_SCREEN_Pace
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID.Trim());
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
    }
}
