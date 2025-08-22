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
    public class ContactInfoDAL
    {
        ConnectionString cs = new ConnectionString();
        DataSet ds = null;
        public DataSet GetContactInfo(string XmlData, int UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Select_mClient_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    //cmd.Parameters.AddWithValue("@action", SearchCateria);
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
        public DataSet GetContactInfo_cr(string XmlData, int UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Select_mClient_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    //cmd.Parameters.AddWithValue("@action", SearchCateria);
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

        public DataSet GetContactInfoPopUp(string XmlData, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Select_mClient_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    //cmd.Parameters.AddWithValue("@Cli", SearchCateria);
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
        public DataSet GetContactInfoPopUp_cr(string XmlData, string UserUID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_Proc_Select_mClient_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    //cmd.Parameters.AddWithValue("@Cli", SearchCateria);
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

        public int SaveContactInfoPopUp(string UserUID,string XML,string action)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("TRM_Proc_Update_mClientUnit_Web", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.UnitName);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Country);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.SalesManager);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.State);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.City);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.ClientName);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.ClinetnCode);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.EmailID);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Fax);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Mobile);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Phone);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Pin);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.RegionCode);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Address);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Phone);
                    con.Open();
                    i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return i;
        }
        //LS
        public int SaveContactInfoPopUp_cr(string UserUID, string XML, string action)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("PEN_Proc_Update_mClientUnit_Pace", con); //PEN_Proc_Update_mClientUnit_Pace
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.UnitName);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Country);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.SalesManager);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.State);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.City);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.ClientName);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.ClinetnCode);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.EmailID);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Fax);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Mobile);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Phone);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Pin);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.RegionCode);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Address);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Phone);
                    con.Open();
                    i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return i;
        }

        public int SaveContactInfo(ContactInfo contactInfo)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Select_mClient_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.UnitCode);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.UnitName);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Country);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.SalesManager);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.State);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.City);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.ClientName);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.ClinetnCode);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.EmailID);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Fax);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Mobile);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Phone);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Pin);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.RegionCode);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Address);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, contactInfo.Phone);
                    con.Open();
                    i = cmd.ExecuteNonQuery();
                    con.Close();
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
