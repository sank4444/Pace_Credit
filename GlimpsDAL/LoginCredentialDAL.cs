using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlimpsBAL;


namespace GlimpsDAL
{
    public class LoginCredentialDAL
    {
        ConnectionString cs = new ConnectionString();

        public DataSet UserValidation(string Username, string Password, string sAction)
        {
            //LoginCredentialBAL loginCredentialBAL = null;
            try
            {
               // loginCredentialBAL = new LoginCredentialBAL();
                SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.AppDb));
                con.Open();
                DataSet ds = new DataSet();
                DataTable tb = new DataTable();
                DataSet dsResult = new DataSet("params");
                DataTable dtResult = new DataTable("param");

                dtResult.Columns.Add(CommonConstantNames.USERNAME, typeof(string));
                dtResult.Columns.Add(CommonConstantNames.PASSWORD, typeof(string));

                DataRow drResult = dtResult.NewRow();

                drResult[CommonConstantNames.USERNAME] = Username;
                drResult[CommonConstantNames.PASSWORD] = Password;

                dtResult.Rows.Add(drResult);
                dsResult.Merge(dtResult);

                //SqlDataAdapter SQLda = new SqlDataAdapter("Proc_Common_Select_User'" + dsResult.GetXml().ToString() + "','" + sAction + "'", con);
                //SqlDataAdapter SQLda = new SqlDataAdapter("Proc_Common_Select_User_Pace '" + dsResult.GetXml().ToString() + "','" + sAction + "'", con);
                SqlDataAdapter SQLda = new SqlDataAdapter("Proc_Common_Select_User '" + dsResult.GetXml().ToString() + "','" + sAction + "'", con);
                SQLda.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet CHANGEPASSWORD(string NewPassword, string OldPassword, string sAction, string userUID)
        {
           // LoginCredentialBAL loginCredentialBAL = null;
            try
            {
              //  loginCredentialBAL = new LoginCredentialBAL();
                SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.AppDb));
                con.Open();
                DataSet ds = new DataSet();
                DataTable tb = new DataTable();
                DataSet dsResult = new DataSet("params");
                DataTable dtResult = new DataTable("param");

                dtResult.Columns.Add("NewPassword", typeof(string));
                dtResult.Columns.Add("OldPassword", typeof(string));
                dtResult.Columns.Add("UserUID", typeof(string));

                DataRow drResult = dtResult.NewRow();

                drResult["NewPassword"] = NewPassword;
                drResult["OldPassword"] = OldPassword;
                drResult["UserUID"] = userUID;

                dtResult.Rows.Add(drResult);
                dsResult.Merge(dtResult);

                SqlDataAdapter SQLda = new SqlDataAdapter("Proc_Common_Select_User '" + dsResult.GetXml().ToString() + "','" + sAction + "'", con);
                SQLda.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //ls
        public DataSet CHANGEPASSWORD_cr(string NewPassword, string OldPassword, string sAction, string userUID)
        {
            // LoginCredentialBAL loginCredentialBAL = null;
            try
            {
                //  loginCredentialBAL = new LoginCredentialBAL();
                SqlConnection con = new SqlConnection(cs.ConnectionStringDB(ConnectionType.AppDb));
                con.Open();
                DataSet ds = new DataSet();
                DataTable tb = new DataTable();
                DataSet dsResult = new DataSet("params");
                DataTable dtResult = new DataTable("param");

                dtResult.Columns.Add("NewPassword", typeof(string));
                dtResult.Columns.Add("OldPassword", typeof(string));
                dtResult.Columns.Add("UserUID", typeof(string));

                DataRow drResult = dtResult.NewRow();

                drResult["NewPassword"] = NewPassword;
                drResult["OldPassword"] = OldPassword;
                drResult["UserUID"] = userUID;

                dtResult.Rows.Add(drResult);
                dsResult.Merge(dtResult);

                SqlDataAdapter SQLda = new SqlDataAdapter("Proc_Common_Select_User '" + dsResult.GetXml().ToString() + "','" + sAction + "'", con);
                SQLda.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
