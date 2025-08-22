using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlimpsBAL;
using GlimpsDAL.Common;
using GlimpsDAL;



namespace GlimpsDAL
{
    public class MemberInfoDAL
    {
        ConnectionString cs = new ConnectionString();
        DataSet ds = null;

        //Added by sonali on 08/08/2017
        public int SaveCircleDetails(string xmldata)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("TRM_Proc_Insert_mCircle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.INTERRORNO, 0);
                    con.Open();
                    i = cmd.ExecuteNonQuery();
                    return i;
                    //con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Added by sonali on 08/08/2017
        public int UpdateDeleteCircleDetails(string xmldata, string StateAction)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("TRM_Proc_Insert_mCircle", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, xmldata);
                    cmd.Parameters.AddWithValue(SqlParameters.action, StateAction);
                    cmd.Parameters.AddWithValue(SqlParameters.INTERRORNO, 0);
                    con.Open();
                    i = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }

        /// <summary>
        /// ============
        /// </summary>
        /// <param name="XmlData"></param>
        /// <param name="UserUID"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public DataSet GetMemberInfo(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_View_Policy_Member_Web, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
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
        //GetSurrenderCal_cr

        public DataSet GetSurrenderCal_cr(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {
                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_Surrender_Calculator_pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
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
        public DataSet GetPremiumCal(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    ////proc not created PEN_Proc_pPolicy_PremiumCalculation_Pace  //Proc_Premium_Calculation_pace
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_Premium_Calculation_pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
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


        public DataSet GetMemberInfo_cr(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_VIEW_POLICY_MEMBER_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
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
        //ALLGetMemberInfo_cr
        public DataSet ALLGetMemberInfo_cr(string XmlData, int UserUID, string action)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_VIEW_POLICY_MEMBER_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
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

        //GetPremiumDataDAL
        public DataSet GetPremiumDataDAL(string XmlData, int UserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet(); //Proc_Premium_Calculation_pace  Proc_Premium_Cal
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_Premium_Cal_pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.XMLDATASTR, XmlData);
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

        public DataSet GetMemberInfoPopUp(int UserUID, int PolicyMemberUID, int PolicyUID, int RenewalNoUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_Select_pPolicy_Member_Web, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyUID, PolicyUID);
                    cmd.Parameters.AddWithValue(SqlParameters.RenewalNoUID, RenewalNoUID);
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyMemberUID, PolicyMemberUID);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    //cmd.Parameters.AddWithValue(SqlParameters.xmldata, xml);
                    cmd.Parameters.AddWithValue(SqlParameters.module, null);
                    cmd.Parameters.AddWithValue(SqlParameters.Process, null);
                    cmd.Parameters.AddWithValue(SqlParameters.Fk_PolServicingRequestUID, null);
                    cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);

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
        public DataSet GetMemberInfoPopUp_cr(int UserUID, int PolicyMemberUID, int PolicyUID, int RenewalNoUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_SELECT_PPOLICY_MEMBER_DATAENTRY_QC_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyUID, PolicyUID);
                    cmd.Parameters.AddWithValue(SqlParameters.RenewalNoUID, RenewalNoUID);
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyMemberUID, PolicyMemberUID);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    //cmd.Parameters.AddWithValue(SqlParameters.xmldata, xml);
                    cmd.Parameters.AddWithValue(SqlParameters.module, null);
                    cmd.Parameters.AddWithValue(SqlParameters.Process, null);
                    cmd.Parameters.AddWithValue(SqlParameters.Fk_PolServicingRequestUID, null);
                    //cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);

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
        //ls2019 GetViolation_cr
        public DataSet GetViolation_cr(string XML) //int PolicyMemberUID,
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.Proc_pPol_member_List_Pace, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    //cmd.Parameters.AddWithValue(SqlParameters.PolicyUID, PolicyUID);
                    //cmd.Parameters.AddWithValue(SqlParameters.RenewalNoUID, RenewalNoUID);
                   // cmd.Parameters.AddWithValue(SqlParameters.PolicyMemberUID, PolicyMemberUID);
                    //cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                   // cmd.Parameters.AddWithValue(SqlParameters.module, null);
                    //cmd.Parameters.AddWithValue(SqlParameters.Process, null);
                    //cmd.Parameters.AddWithValue(SqlParameters.Fk_PolServicingRequestUID, null);
                    //cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);

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
        


        public DataSet GetALLMemberInfo_cr(int UserUID, int PolicyMemberUID, int PolicyUID, int RenewalNoUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PEN_PROC_SELECT_PPOLICY_MEMBER_DATAENTRY_QC_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyUID, PolicyUID);
                    cmd.Parameters.AddWithValue(SqlParameters.RenewalNoUID, RenewalNoUID);
                    cmd.Parameters.AddWithValue(SqlParameters.PolicyMemberUID, PolicyMemberUID);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    //cmd.Parameters.AddWithValue(SqlParameters.xmldata, xml);
                    cmd.Parameters.AddWithValue(SqlParameters.module, null);
                    cmd.Parameters.AddWithValue(SqlParameters.Process, null);
                    cmd.Parameters.AddWithValue(SqlParameters.Fk_PolServicingRequestUID, null);
                    //cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);

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

        public DataSet GetMemberInfoBillDetails(int UserUID, string XML, string action)
        {

            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_POLICY_MEMBER_DETAILS_HISTORY_WEB, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
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
        public DataSet GetMemberInfoBillDetails_cr(int UserUID, string XML, string action)
        {

            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_PROC_POLICY_MEMBER_DETAILS_HISTORY_WEB_PACE, con);
                    //TRM_PROC_POLICY_MEMBER_DETAILS_HISTORY_WEB
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.action, action);
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

        //Added by sonali  on 08/08/2017 for circle details
        public DataSet GetCircleDetails(string XML, Int16 UserId, string Action)
        {

            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.TRM_Proc_mCircle, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XML);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserId);
                    // cmd.Parameters.AddWithValue(SqlParameters.subOfficeId, SubOfficeUID);
                    cmd.Parameters.AddWithValue(SqlParameters.action, Action);

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

        public static DataSet GetInsuredDetailsAndMTRF(string UserUID, string PolicyMemberUID)
        {

            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.TermDB).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("TRM_Proc_PolicyMemberMedicalTest_Policy_Web", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@PolicyMemberUID", PolicyMemberUID);
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

        public DataSet GetMemberUnderwritingInfo_cr(string XmlData, int UserUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PROC_PPOL_MEMBER_LIST_UW, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    //cmd.Parameters.AddWithValue(SqlParameters.action, action);
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
        

        #region MemberIfoDetailsFillDropdownlist

        public DataSet GetSumAssured(string XmlData, string SearchCateria, string UserUID, string ApplicationUID)
        {
            ConnectionString cs = new ConnectionString();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.Credit).ToString()))
                {

                    ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(StoreprocedureNames.PROC_COMMON_SELECT_POLICY_PACE, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue(SqlParameters.xmldata, XmlData);
                    cmd.Parameters.AddWithValue(SqlParameters.SearchCateria, SearchCateria);
                    cmd.Parameters.AddWithValue(SqlParameters.UserUID, UserUID);
                    cmd.Parameters.AddWithValue(SqlParameters.ApplicationUID, null);
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

        #endregion

  


    }
}
