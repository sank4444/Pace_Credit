using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlimpsDAL.Common;

namespace GlimpsDAL
{
  public  class ClaimDAL
    {
        #region Service Request DropDown

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
        #endregion

        #region Saving Claim Request

        public static DataSet SavingClaimRequest(string userID, string Xml)
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
        #endregion
    }
}
