using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlimpsDAL.Common;
using GlimpsBAL;

namespace GlimpsDAL
{
    public class ServicesDAL
    {

        #region Member Addition....

        public static DataSet InsertXMLInDataBase(int UserUID, string xmldata, string Action)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PPOL_MEMBER_PROCESS_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    // SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, 0);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.SUBACTION, string.Empty);
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
        public static DataSet InsertXMLInDataBase_cr(string xmldata, string Process, string SubProcess, int PolicyUID, int UserUID)
        {

            DataSet ds = null;
            try
            {
                Int64 iTransactionID = 0;
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_pPolicy_Member_Submission_pace, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                        cmd.Parameters.AddWithValue(SqlParameters.Process.ToString(), Process);
                        cmd.Parameters.AddWithValue(SqlParameters.SUBPROCESS.ToString(), SubProcess);
                        cmd.Parameters.AddWithValue(SqlParameters.PolicyUID.ToString(), PolicyUID);
                        cmd.Parameters.AddWithValue(SqlParameters.RenewalNoUID.ToString(), "");
                        cmd.Parameters.AddWithValue(SqlParameters.CreatedBy.ToString(), UserUID);
                        cmd.Parameters.AddWithValue(SqlParameters.module.ToString(), "submission");
                        cmd.Parameters.AddWithValue(SqlParameters.TransactionID.ToString(), "");
                        con.Open();
                        SqlParameter p = cmd.Parameters.Add(SqlParameters.INTERRORNO.ToString(), SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        iTransactionID = Convert.ToInt64(p.Value);
                       
                    }
                    using (SqlCommand cmd1 = new SqlCommand(StoreprocedureNames.PROC_PPOL_MEMBER_SUBMISSION_DISPLAY_RESULT_Pace, con))
                    {   
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Connection = con;
                        cmd1.CommandTimeout = 0;
                        cmd1.Parameters.AddWithValue(SqlParameters.REPORT.ToString(), "ALL");
                        cmd1.Parameters.AddWithValue(SqlParameters.Process.ToString(), Process);
                        cmd1.Parameters.AddWithValue(SqlParameters.SUBPROCESS.ToString(), SubProcess);
                        cmd1.Parameters.AddWithValue(SqlParameters.PolicyUID.ToString(), PolicyUID);
                        cmd1.Parameters.AddWithValue(SqlParameters.RenewalNoUID.ToString(), "0");
                        cmd1.Parameters.AddWithValue(SqlParameters.CreatedBy.ToString(), UserUID); //662
                        cmd1.Parameters.AddWithValue(SqlParameters.TransactionID.ToString(), iTransactionID); // 350395
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        da.Fill(ds);
                    }
                    return ds;
                    //con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet Upload_Premium_Calculation(string xmldata, int UserUID)
        {
            DataSet ds = null;
            try
            {
                //Int64 iTransactionID = 0;
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    using (SqlCommand cmd1 = new SqlCommand(StoreprocedureNames.Proc_Upload_Premium_Cal_Pace, con))
                    { 
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Connection = con;
                        cmd1.CommandTimeout = 0;
                        cmd1.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                        cmd1.Parameters.AddWithValue(SqlParameters.UserUID.ToString(), UserUID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        da.Fill(ds);
                    }
                    return ds;
                    //con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Bulk_COI_Upload
        public static DataSet Bulk_COI_Upload(string xmldata, int UserUID)
        {
            DataSet ds = null;
            try
            {
                //Int64 iTransactionID = 0;
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    using (SqlCommand cmd1 = new SqlCommand(StoreprocedureNames.Proc_Bulk_Upload_COI_Pace, con)) 
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Connection = con;
                        cmd1.CommandTimeout = 0;
                        cmd1.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                        cmd1.Parameters.AddWithValue(SqlParameters.UserUID.ToString(), UserUID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        da.Fill(ds);
                    }
                    return ds;
                    //con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LS
        public static DataSet MemberTermConfirm_cr(string Process, string SubProcess, int PolicyUID,int UserUID, string TransactionID)
        {
            DataSet ds = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_pPolicy_Member_Submission_Confirm_pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.Process.ToString(), Process);
                    cmd.Parameters.AddWithValue(SqlParameters.SUBPROCESS.ToString(), SubProcess);
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyUID.ToString(), PolicyUID);
                    cmd.Parameters.AddWithValue(SqlParameters.RenewalNoUID.ToString(), "");
                    cmd.Parameters.AddWithValue(SqlParameters.CreatedBy.ToString(), UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID.ToString(), TransactionID);
                    cmd.Parameters.AddWithValue(SqlParameters.module.ToString(), "submission");
                    // SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    //cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    //cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
                    //cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlParameter p = cmd.Parameters.Add(SqlParameters.INTERRORNO.ToString(), SqlDbType.Int);//
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
        public static DataSet MemberTermConfirm_undocr(string Process, string SubProcess, int PolicyUID, int UserUID, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();   //TRM_PPOLICY_MEMBER_TERM_CONFIRM_WEB  Proc_pPolicy_Member_Submission_Confirm_pace
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_pPolicy_Member_Submission_Confirm_pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.Process.ToString(), Process);
                    cmd.Parameters.AddWithValue(SqlParameters.SUBPROCESS.ToString(), SubProcess);
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyUID.ToString(), PolicyUID);
                    cmd.Parameters.AddWithValue(SqlParameters.RenewalNoUID.ToString(), "");
                    cmd.Parameters.AddWithValue(SqlParameters.CreatedBy.ToString(), UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID.ToString(), TransactionID);
                    cmd.Parameters.AddWithValue(SqlParameters.module.ToString(), "Undo");
                    // SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    //cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    //cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
                    //cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    SqlParameter p = cmd.Parameters.Add(SqlParameters.INTERRORNO.ToString(), SqlDbType.Int);//
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

        public static DataSet MemberTermConfirm(int UserUID, string Action, string TransactionID, string XML)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PPOLICY_MEMBER_TERM_CONFIRM_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    // SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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

        public static DataSet Autounderwriting_Job(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_QC_AUTOUNDERWRITING_JOB_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    //  SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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
        public static DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet(); //TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_WEB  
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    //SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);

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

        public static DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_cr(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet(); //TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_WEB 
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    //SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);

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

        public static DataSet MEMBER_BILLPROCESS_CONFIRM(int UserUID, string XML, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    // SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
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
        public static DataSet MEMBER_BILLPROCESS_CONFIRM_cr(int UserUID, string XML, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet(); //TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_WEB
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    // SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
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

        #endregion

        #region Member Deletion..
        //Next 
        public static DataSet InsertXMLInDataBaseForDeletion(int UserUID, string xmldata, string Action)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PPOL_MEMBER_PROCESS_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, 0);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue("@SubAction", "I");
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
        //LS
        public static DataSet InsertXMLInDataBaseForDeletion_cr(int UserUID, string xmldata, string Action)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();  // TRM_PPOL_MEMBER_PROCESS_WEB PEN_PPOL_MEMBER_PROCESS_PACE
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PPOL_MEMBER_PROCESS_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, 0);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue("@SubAction", "I");
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

        //Confirm
        public static DataSet MemberTermConfirmDeletion(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_PPOLICY_SERVICINGREQUEST_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, "Submit");
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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
        public static DataSet MemberTermConfirmDeletion_cr(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();  //TRM_PROC_COMMON_PPOLICY_SERVICINGREQUEST_WEB
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_COMMON_PPOLICY_SERVICINGREQUEST_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, "Submit");
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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


        //Job Run..
        public static DataSet Autounderwriting_JobDeletion(int UserUID, string Action)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOL_MULTIPLE_MEMBERSERVICING_PROCESS_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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

        //LS
        public static DataSet Autounderwriting_JobDeletion_cr(int UserUID, string Action)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();    ///TRM_PROC_PPOL_MULTIPLE_MEMBERSERVICING_PROCESS_WEB 
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOL_MULTIPLE_MEMBERSERVICING_PROCESS_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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

        public static DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_Deletion(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);

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
        public static DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_Deletion_cr(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet(); //TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_WEB
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);

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
        public static DataSet MEMBER_BILLPROCESS_CONFIRM_Deletion(int UserUID, string XML, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
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
        public static DataSet MEMBER_BILLPROCESS_CONFIRM_Deletion_cr(int UserUID, string XML, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet(); //  TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_WEB
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
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

        #endregion

        #region Sum Assured..
        //Next 
        public static DataSet InsertXMLInDataBaseForSumAssured(int UserUID, string xmldata, string Action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_PPOLICY_SERVICINGREQUEST_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, 0);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, "I");
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

        //Confirm
        public static DataSet MemberTermConfirmSumAssured(string XMLDATASTR, int UserUID, string Action, int TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_PPOLICY_SERVICINGREQUEST_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XMLDATASTR);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, "Submit");
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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

        //Job Run..
        public static DataSet Autounderwriting_JobSumAssured(int UserUID, string Action)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_MULTIPLE_MEMBERSERVICING_SUMASSURED_PROCESS_OTHER_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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
        //LS 
        public static DataSet Autounderwriting_JobSumAssured_cr(int UserUID, string Action)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();//  TRM_PROC_MULTIPLE_MEMBERSERVICING_SUMASSURED_PROCESS_OTHER_WEB
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_MULTIPLE_MEMBERSERVICING_SUMASSURED_PROCESS_OTHER_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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

        public static DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_SumAssured(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);

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

        public static DataSet MEMBER_BILLPROCESS_UPLOAD_TEMP_SumAssured_cr(int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet(); //TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_WEB
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOLICY_MEMBER_BILLPROCESS_UPLOAD_TEMP_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);

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

        public static DataSet MEMBER_BILLPROCESS_CONFIRM_SumAssured(int UserUID, string XML, string transactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, transactionID);
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
        public static DataSet MEMBER_BILLPROCESS_CONFIRM_SumAssured_cr(int UserUID, string XML, string transactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();//TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_WEB 
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, transactionID);
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

        #endregion

        #region Minor Servicing changes..
        //Next 
        public static DataSet InsertXMLInDataBaseForMinorServicingchanges(int UserUID, string xmldata, string Action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_PPOLICY_SERVICINGREQUEST_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, 0);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, "I");
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

        public static DataSet InsertXMLInDataBaseForMinorServicingchanges_cr(int UserUID, string xmldata, string Action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();   //TRM_PROC_COMMON_PPOLICY_SERVICINGREQUEST_WEB
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_COMMON_PPOLICY_SERVICINGREQUEST_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, 0);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, "I");
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

        //Confirm
        public static DataSet MemberTermConfirmMinorServicingchanges(string XMLDATASTR, int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_PPOLICY_SERVICINGREQUEST_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XMLDATASTR);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, "Submit");
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
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

        //LS
        public static DataSet MemberTermConfirmMinorServicingchanges_cr(string XMLDATASTR, int UserUID, string Action, string TransactionID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet(); //TRM_PROC_COMMON_PPOLICY_SERVICINGREQUEST_WEB 
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_COMMON_PPOLICY_SERVICINGREQUEST_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XMLDATASTR);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, "Submit");
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, TransactionID);
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

        //Job Run..
        public static DataSet Autounderwriting_JobMinorServicingchanges(int UserUID, string Action, string transactionUID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOL_MULTIPLE_MEMBERSERVICING_PROCESS_MINOR_CHANGE_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, transactionUID);
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
        public static DataSet Autounderwriting_JobMinorServicingchanges_cr(int UserUID, string Action, string transactionUID)
        {

            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();  //TRM_PROC_PPOL_MULTIPLE_MEMBERSERVICING_PROCESS_MINOR_CHANGE_WEB
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOL_MULTIPLE_MEMBERSERVICING_PROCESS_MINOR_CHANGE_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, string.Empty);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, transactionUID);
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

        #endregion

        #region Service Request DropDown and Sending Mail With attchment

        public static DataSet ServiceRequestTypeDDL(string UserUID, string xmldata, string Action)
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
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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
        //ls 2019
        public static DataSet ServiceRequestTypeDDL_cr(string UserUID, string xmldata, string Action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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
        public static int SendinMailWithAttachment(string UserUID, string XML, string Action, byte[] Attachement1)
        {
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_AUTO_MAIL_SEND_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.ATTACHEMENT1, Attachement1);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return i;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        #endregion

        #region category DropDown

        public static DataSet categoryDDL(string UserUID, string xmldata, string Action)
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
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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

        //ls 2019
        public static DataSet categoryDDL_cr(string UserUID, string xmldata, string Action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
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

        #endregion

        #region Policy DropDown

        public static DataSet PolicyDDL(string UserUID, string xmldata, string Action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("  ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, 0);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, " ");
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
        #endregion

        #region COI DropDown

        public static DataSet COIDDL(string UserUID, string xmldata, string Action)
        {
            DataSet ds = null;
            //DataTable dt = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("  ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    SqlParameter outComp = new SqlParameter(SqlParameters.TransactionID, SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };
                    cmd.Parameters.AddWithValue(SqlParameters.TransactionID, 0);
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);
                    cmd.Parameters.AddWithValue(SqlParameters.Type, " ");
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
        #endregion

        #region Saving Service Request

        public static DataSet SavingServiceRequest(string userID, string Xml)
        {
            DataSet ds = null;

            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_SERVICING_REQUEST_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, userID);
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, Xml);
                    cmd.Parameters.AddWithValue(SqlParameters.action, "I");

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    //i = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //ls 2019
        public static DataSet SavingServiceRequest_cr(string userID, string Xml)
        {
            DataSet ds = null;

            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_SERVICING_REQUEST_PACE, con); //TRM_PROC_SERVICING_REQUEST_WEB TRM_Proc_Servicing_Request_Web_PACE
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, userID);
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, Xml);
                    cmd.Parameters.AddWithValue(SqlParameters.action, "I");

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    //i = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        #region GET DATA OF CHECK BOX FOR DISPLAY

        public static DataSet getDataCHK(string userID, string Xml, string action)
        {
            DataSet ds = null;
            try
            {
                ConnectionString cs = new ConnectionString();
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Select_mClient_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, Xml);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, userID);

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
        #endregion

        #region Get Service list data

        public static DataSet GetServiceList(string UserID, string XML, string Action)
        {
            DataSet ds = null;
            try
            {
                ConnectionString OBJCONNECTION = new ConnectionString();
                using (SqlConnection CONNECTION = new SqlConnection(OBJCONNECTION.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();

                    SqlCommand COMMAND = new SqlCommand(StoreprocedureNames.TRM_PROC_SERVICING_REQUEST_WEB, CONNECTION);
                    COMMAND.CommandType = CommandType.StoredProcedure;
                    COMMAND.Connection = CONNECTION;
                    COMMAND.CommandTimeout = 30;
                    COMMAND.Parameters.AddWithValue(SqlParameters.UserUID, UserID);
                    COMMAND.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    COMMAND.Parameters.AddWithValue(SqlParameters.action, Action);
                    CONNECTION.Open();
                    SqlDataAdapter ADAPTER = new SqlDataAdapter(COMMAND);
                    ADAPTER.Fill(ds);
                    CONNECTION.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        //public static DataSet GetServiceList_cr(string UserID, string XML, string Action)
        //{
        //    DataSet ds = null;
        //    try
        //    {
        //        ConnectionString OBJCONNECTION = new ConnectionString();
        //        using (SqlConnection CONNECTION = new SqlConnection(OBJCONNECTION.ConnectionStringDB(ConnectionType.Credit).ToString()))
        //        {
        //            ds = new DataSet();
        //           // TRM_PROC_SERVICING_REQUEST_WEB
        //            //PEN_PROC_SERVICING_REQUEST_PACE
        //            SqlCommand COMMAND = new SqlCommand(StoreprocedureNames.TRM_PROC_SERVICING_REQUEST_WEB, CONNECTION);
        //            COMMAND.CommandType = CommandType.StoredProcedure;
        //            COMMAND.Connection = CONNECTION;
        //            COMMAND.CommandTimeout = 30;
        //            COMMAND.Parameters.AddWithValue(SqlParameters.UserUID, UserID);
        //            COMMAND.Parameters.AddWithValue(SqlParameters.xmldata, XML);
        //            COMMAND.Parameters.AddWithValue(SqlParameters.action, Action);
        //            CONNECTION.Open();
        //            SqlDataAdapter ADAPTER = new SqlDataAdapter(COMMAND);
        //            ADAPTER.Fill(ds);
        //            CONNECTION.Close();
        //            return ds;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public static DataSet GetServiceList_cr(string UserID, string XML, string Action)
        {
            DataSet ds = null;
            try
            {
                ConnectionString OBJCONNECTION = new ConnectionString();
                using (SqlConnection CONNECTION = new SqlConnection(OBJCONNECTION.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();

                    SqlCommand COMMAND = new SqlCommand(StoreprocedureNames.TRM_Proc_Servicing_Request_Web_PACE, CONNECTION);//  PEN_PROC_SERVICING_REQUEST_PACE
                    COMMAND.CommandType = CommandType.StoredProcedure;
                    COMMAND.Connection = CONNECTION;
                    COMMAND.CommandTimeout = 30;
                    COMMAND.Parameters.AddWithValue(SqlParameters.UserUID, UserID);
                    COMMAND.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    COMMAND.Parameters.AddWithValue(SqlParameters.action, Action);
                    CONNECTION.Open();
                    SqlDataAdapter ADAPTER = new SqlDataAdapter(COMMAND);
                    ADAPTER.Fill(ds);
                    CONNECTION.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Service Request COI

        public static DataSet GetServiceRequestCOI(string UserID, string XML, string Action)
        {
            DataSet ds = null;
            try
            {
                ConnectionString OBJCONNECTION = new ConnectionString();
                using (SqlConnection CONNECTION = new SqlConnection(OBJCONNECTION.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    ds = new DataSet();

                    SqlCommand COMMAND = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_MASTER_WEB, CONNECTION);
                    COMMAND.CommandType = CommandType.StoredProcedure;
                    COMMAND.Connection = CONNECTION;
                    COMMAND.CommandTimeout = 30;
                    COMMAND.Parameters.AddWithValue(SqlParameters.UserUID, UserID);
                    COMMAND.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    COMMAND.Parameters.AddWithValue(SqlParameters.action, Action);
                    CONNECTION.Open();
                    SqlDataAdapter ADAPTER = new SqlDataAdapter(COMMAND);
                    ADAPTER.Fill(ds);
                    CONNECTION.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
