using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlimpsDAL.Common;

namespace GlimpsDAL
{
    public class _objConfigurationDAL
    {
        ConnectionString cs = new ConnectionString();
        DataSet ds = null;

        public DataSet GetServicingList(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_MASTER_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, CommonConstantNames.SERVICING_CHANGE_NAME);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //added by LS 
        public DataSet GetServicingList_cr(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_COMMON_SELECT_MASTER_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, CommonConstantNames.SERVICING_CHANGE_NAME);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        public DataSet GetPolicyUID(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_MASTER_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, "USERACCESSSUBOFFICE");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        
       //added by ls
        public DataSet SummsionDAL_cr(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();                //TRM_Proc_Common_Select_Fill,
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Fill_PACE, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.Process, "FILLCLIENT");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, "");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet GetPolicyUID_cr(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, "USERACCESSSUBOFFICE");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //premiumFillDll_cr
        public DataSet premiumFillDll_cr(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, "RIDER");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet RateOfInterest_crDAL(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, "RATEOFINTEREST");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet PremiummodeTypeDAL(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, "PREMIUMMODETYPE");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
        //

        public DataSet PolicyDAL(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, "POLICY");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet SumassuredTypeDAL(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, "SUMASSUREDTYPE");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet SegmentCodeDAL(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, "SegmentCode");
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet GetSalesManager(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_MASTER_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, CommonConstantNames.SALEMANAGER);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                //cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet GetAllCountry(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_CLIENT_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.SearchCateria, CommonConstantNames.NATIONALITY);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
               // cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet GetState(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_CLIENT_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.SearchCateria, CommonConstantNames.STATE);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                //cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet GetCity(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_CLIENT_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.SearchCateria, CommonConstantNames.CITY);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
               // cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        public DataSet GetPin(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_CLIENT_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.SearchCateria, CommonConstantNames.PINCODE);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                //cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }


        public DataSet GetAllActiveRegions(string XmlData, string UserUID)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_MASTER_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, CommonConstantNames.ZONE);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                //cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        //Changed by Karunakar on 10/10/2016
        public DataSet GetPolicyYear(string XmlData, string UserUID, string ACTION)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_COMMON_SELECT_MASTER_WEB, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, ACTION);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }

        //added by lakhapat
        public DataSet GetPolicyYear_cr(string XmlData, string UserUID, string ACTION)
        {
            using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Common_Select_Master_Pace, con);
                                                                   
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                cmd.Parameters.AddWithValue(SqlParameters.action, ACTION);
                cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            return ds;
        }
    }
}
