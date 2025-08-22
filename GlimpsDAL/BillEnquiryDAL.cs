using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlimpsDAL.Common;

namespace GlimpsDAL
{
    public class BillEnquiryDAL
    {
        public DataSet GetBillEnquiry(string billNo, string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();

                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_ENQUIRY_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
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
            return ds;
        }
        //LS 
        // public DataSet GetBillEnquiry_cr(string billNo, string XmlData, int UserUID, string action)
        public DataSet GetBillEnquiry_cr(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    // SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_ENQUIRY_WEB, con);
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_ALL_MIS_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);// "BI"
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
            return ds;
        }
        //
        public DataSet GetDashBoard_cr(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    // SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_ENQUIRY_WEB, con);
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_ALL_MIS_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 50;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);// "BI"
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
            return ds;
        }

        public DataSet GetPopUpBillEnquiry(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();

                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_ENQUIRY_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
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
            return ds;
        }
        //ls
        public DataSet GetPopUpBillEnquiry_cr(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();

                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOLICY_MEMBER_BILLPROCESS_CONFIRM_ENQUIRY_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;

                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
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
            return ds;
        }
        public static DataSet GetBillPayMent(string XmlData, string ACTION, string sUserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    using (SqlCommand cmdSelect = new SqlCommand(StoreprocedureNames.TRM_PROC_PPOLICY_MEMBER_BILLPAYMENT_DISPLAY_WEB.ToString()))
                    {
                        DataSet myDataSet = new DataSet();
                        cmdSelect.CommandType = CommandType.StoredProcedure;
                        cmdSelect.Connection = con;
                        cmdSelect.CommandTimeout = 30;
                        cmdSelect.Parameters.AddWithValue(SqlParameters.xmldata.ToString(), XmlData);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.action.ToString(), ACTION);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.UserUID.ToString(), sUserUID);
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                        da.Fill(myDataSet);
                        return myDataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls
        public static DataSet GetBillPayMent_cr(string XmlData, string ACTION, string sUserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    using (SqlCommand cmdSelect = new SqlCommand(StoreprocedureNames.PEN_PROC_PPOLICY_MEMBER_BILLPAYMENT_DISPLAY_PACE.ToString()))
                    { //PEN_Proc_Ppolicy_Member_BillPayment_Display_Pace
                        DataSet myDataSet = new DataSet();
                        cmdSelect.CommandType = CommandType.StoredProcedure;
                        cmdSelect.Connection = con;
                        cmdSelect.CommandTimeout = 30;
                        cmdSelect.Parameters.AddWithValue(SqlParameters.xmldata.ToString(), XmlData);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.action.ToString(), ACTION);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.UserUID.ToString(), sUserUID);
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                        da.Fill(myDataSet);
                        return myDataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetNonFloat(string XmlData, string Action, string sUserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    using (SqlCommand cmdSelect = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_POLICY_WEB.ToString()))
                    {
                        DataSet myDataSet = new DataSet();
                        cmdSelect.CommandType = CommandType.StoredProcedure;
                        cmdSelect.Connection = con;
                        cmdSelect.CommandTimeout = 30;
                        cmdSelect.Parameters.AddWithValue(SqlParameters.xmldata.ToString(), XmlData);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.action.ToString(), Action);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.UserUID.ToString(), sUserUID);
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                        da.Fill(myDataSet);
                        return myDataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public static DataSet GetNonFloat_cr(string XmlData, string Action, string sUserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    using (SqlCommand cmdSelect = new SqlCommand(StoreprocedureNames.PEN_PROC_COMMON_SELECT_POLICY_PACE.ToString()))
                    
                    {
                        DataSet myDataSet = new DataSet();
                        cmdSelect.CommandType = CommandType.StoredProcedure;
                        cmdSelect.Connection = con;
                        cmdSelect.CommandTimeout = 30;
                        cmdSelect.Parameters.AddWithValue(SqlParameters.xmldata.ToString(), XmlData);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.action.ToString(), Action);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.UserUID.ToString(), sUserUID);
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                        da.Fill(myDataSet);
                        return myDataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetFloat(string XmlData, string Action, string sUserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    using (SqlCommand cmdSelect = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_POLICY_WEB.ToString()))
                    {
                        DataSet myDataSet = new DataSet();
                        cmdSelect.CommandType = CommandType.StoredProcedure;
                        cmdSelect.Connection = con;
                        cmdSelect.CommandTimeout = 30;
                        cmdSelect.Parameters.AddWithValue(SqlParameters.xmldata.ToString(), XmlData);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.action.ToString(), Action);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.UserUID.ToString(), sUserUID);
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                        da.Fill(myDataSet);
                        return myDataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls
        public static DataSet GetFloat_cr(string XmlData, string Action, string sUserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    using (SqlCommand cmdSelect = new SqlCommand(StoreprocedureNames.PEN_PROC_COMMON_SELECT_POLICY_PACE.ToString()))
                    {
                        DataSet myDataSet = new DataSet();
                        cmdSelect.CommandType = CommandType.StoredProcedure;
                        cmdSelect.Connection = con;
                        cmdSelect.CommandTimeout = 30;
                        cmdSelect.Parameters.AddWithValue(SqlParameters.xmldata.ToString(), XmlData);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.action.ToString(), Action);
                        cmdSelect.Parameters.AddWithValue(SqlParameters.UserUID.ToString(), sUserUID);
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                        da.Fill(myDataSet);
                        return myDataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertBillPayment(string xmlData, string Action, string sUserUID)
        {

            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    using (SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_POLTOLERANCECHECKINGWEB.ToString()))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue(SqlParameters.UserUID, sUserUID);
                        cmd.Parameters.AddWithValue(SqlParameters.xmldata, xmlData);
                        cmd.Parameters.AddWithValue(SqlParameters.action, Action);

                        con.Open();
                        i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }
      //ls
        public static int InsertBillPayment_cr(string xmlData, string Action, string sUserUID)
        {

            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    using (SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_POLTOLERANCECHECKING_PACE.ToString()))
                    //PEN_Proc_POLToleranceChecking_Pace
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue(SqlParameters.UserUID, sUserUID);
                        cmd.Parameters.AddWithValue(SqlParameters.xmldata, xmlData);
                        cmd.Parameters.AddWithValue(SqlParameters.action, Action);

                        con.Open();
                        i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }
    }
}
