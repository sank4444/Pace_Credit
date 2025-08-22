using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using System.Data;

namespace GlimpsBAL
{
    public class LoginCredentialBAL
    {
        LoginCredentialDAL loginCredentialDAL = null;
        public DataSet UserValidation(string UserName, string Password)
        {
            try
            {
                loginCredentialDAL = new LoginCredentialDAL();
                string sAction = "LOGIN";
                return loginCredentialDAL.UserValidation(UserName, Password, sAction);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet CHANGEPASSWORD(string NewPassword, string OldPassword ,string userUID)
        {
            try
            {
                loginCredentialDAL = new LoginCredentialDAL();
                string sAction = "CHANGEPASSWORD";
                return loginCredentialDAL.CHANGEPASSWORD(NewPassword, OldPassword, sAction, userUID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //LS
        public DataSet CHANGEPASSWORD_cr(string NewPassword, string OldPassword, string userUID)
        {
            try
            {
                loginCredentialDAL = new LoginCredentialDAL();
                string sAction = "CHANGEPASSWORD";
                return loginCredentialDAL.CHANGEPASSWORD_cr(NewPassword, OldPassword, sAction, userUID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
