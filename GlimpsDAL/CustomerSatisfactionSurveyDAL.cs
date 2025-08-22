using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using GlimpsDAL.Common;
using System.Data;

namespace GlimpsDAL
{
    public class CustomerSatisfactionSurveyDAL
    {
        public DataSet GetCustomerSatisfactionSurvey()
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();

                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_GET_CUSTOMER_ENQURY_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

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
            return ds;
        }
        //LS
        public DataSet GetCustomerSatisfactionSurvey_cr()
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();

                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_GET_CUSTOMER_ENQURY_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

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
            return ds;
        }
        public int UpdateCustomerSatisfactionSurvey1(string Xml, int UserUID)
        {
            ConnectionString cs = new ConnectionString();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Insert_Customer_Enqury_Web, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue("@xmldata", Xml);
                    cmd.Parameters.AddWithValue("@UserUid", UserUID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {

            }
            return 1;
        }

        //ls

        public int UpdateCustomerSatisfactionSurvey1_cr(string Xml, int UserUID)
        {
            ConnectionString cs = new ConnectionString();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    //TRM_Proc_Insert_Customer_Enqury_Web TRM_Proc_Insert_Customer_Enqury_Web_pace
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Insert_Customer_Enqury_Web_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue("@xmldata", Xml);
                    cmd.Parameters.AddWithValue("@UserUid", UserUID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {

            }
            return 1;
        }
    }
}
