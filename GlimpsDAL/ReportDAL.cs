using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsBAL;
using System.Data;
using System.Data.SqlClient;
using GlimpsDAL.Common;

namespace GlimpsDAL
{
    public class ReportDAL
    {


        public static DataTable GetPremiumRateChartReport(string rateCode)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PR_PREMIUM_RATE_CHART_Web, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.pa_RateCode, rateCode);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public static DataTable GetPremiumRateChartReport_cr(string rateCode)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PREMIUM_RATE_PACE, con);
                    //PEN_PREMIUM_RATE_PACE
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.pa_RateCode, rateCode);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetMedicalReport_cr(string rateCode)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PR_MEDICALGRID, con);//PR_MEDICALGRID,
                    //PEN_PREMIUM_RATE_PACE
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.PA_CODE.ToString(), rateCode);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetMedicalNonMedical(int UserUID)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_MASTER_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, "NEL");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls
        public static DataTable GetMedicalNonMedical_cr(int UserUID)
        {
            //DataSet ds = null;
            DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    dt = new DataTable();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Common_xPolicypMedicalNonMedicalMapping_PACE, con);
                    // TRM_Proc_Common_xPolicypMedicalNonMedicalMapping_PACE
                    //Old Proce added PEN_Proc_Common_Select_Master_Pace   1530
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, "NEL");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
                 //return ds;
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetNELChartReport(int UserUID)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_MEDICALGRID_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //ls
        public static DataTable GetNELChartReport_cr(int UserUID)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_MEDICALGRID_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetBillReport(string  XML,int UserUID)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_BILL_INVOICE_REPORT_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.action, "BillInvoice");
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // DALGetDeclineLetterReport_cr
        public static DataSet DALGetDeclineLetterReport_cr( string Xml, string action, string MemberUID, int UserUID)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_Letter_Pace_Credit_Life, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, Xml);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    cmd.Parameters.AddWithValue(SqlParameters.MemberUID, MemberUID);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    
                    
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet DALGetPostponeLetterReport_cr(string Xml, string action, string MemberUID, int UserUID)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_Letter_Pace_Credit_Life, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, Xml);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    cmd.Parameters.AddWithValue(SqlParameters.MemberUID, MemberUID);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);


                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet GetMemberlisting(int UserUID, string Xml, string action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_POLICYRENEWAL_MEMBERRENEWAL_REN_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR , Xml);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetPremiumStatement(int UserUID, string Xml, string action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PREMIUM_STATEMENT_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, Xml);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LS
        public static DataSet GetPremiumStatement_cr(int UserUID, string Xml, string action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    //SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PREMIUM_STATEMENT_WEB, con);
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Premium_Statement_Web_PACE, con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, Xml);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
