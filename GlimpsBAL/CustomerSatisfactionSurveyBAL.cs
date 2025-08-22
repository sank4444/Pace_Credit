using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlimpsDAL;
using System.Data;

namespace GlimpsBAL
{
    //Information Class for gathering information at once
    public class CustomerSatisfactionSurveyInfo
    {
        public int id;
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public string Description;
    }

    public class CustomerSatisfactionSurveyBAL
    {
        public DataSet GetCustomerSatisfactionSurvey()
        {
            CustomerSatisfactionSurveyDAL objCustomerSatisfactionSurvey = null;

            try
            {
                objCustomerSatisfactionSurvey = new CustomerSatisfactionSurveyDAL();

                return objCustomerSatisfactionSurvey.GetCustomerSatisfactionSurvey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LS
        public DataSet GetCustomerSatisfactionSurvey_cr()
        {
            CustomerSatisfactionSurveyDAL objCustomerSatisfactionSurvey = null;

            try
            {
                objCustomerSatisfactionSurvey = new CustomerSatisfactionSurveyDAL();

                //return objCustomerSatisfactionSurvey.GetCustomerSatisfactionSurvey();
                return objCustomerSatisfactionSurvey.GetCustomerSatisfactionSurvey_cr();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateCustomerSatisfactionSurvey(CustomerSatisfactionSurveyInfo objCustomerSatisfactionSurveyInfo, int UserUID)
        {
            CustomerSatisfactionSurveyDAL objCustomerSatisfactionSurvey = null;
            string xml1 = string.Empty;
            try
            {
                objCustomerSatisfactionSurvey = new CustomerSatisfactionSurveyDAL();

                xml1 = "<params><param><Answer>" + objCustomerSatisfactionSurveyInfo.answer1 + "</Answer>" + "<Id>" + 1 + "</Id>" +
                        "</param></params>" +
                        "<params><param>" +
                        "<Answer>" + objCustomerSatisfactionSurveyInfo.answer2 + "</Answer>" + "<Id>" + 2 + "</Id>" +
                        "<Description>" + objCustomerSatisfactionSurveyInfo.Description + "</Description>" +
                        "</param></params>";
                        //"<params><param>" +
                        //"<Answer>" + objCustomerSatisfactionSurveyInfo.answer3 + "</Answer>" + "<Id>" + 3 + "</Id>" +
                        //"<Description>" + objCustomerSatisfactionSurveyInfo.Description + "</Description>" +
                        //"</param></params>" +
                        //"<params><param>" +
                        //"<Answer>" + objCustomerSatisfactionSurveyInfo.answer4 + "</Answer>" + "<Id>" + 4 + "</Id>" +
                        //"<Description>" + objCustomerSatisfactionSurveyInfo.Description + "</Description>" +
                        //"</param></params>";



                //return objCustomerSatisfactionSurvey.UpdateCustomerSatisfactionSurvey(xml1, UserUID);
                return objCustomerSatisfactionSurvey.UpdateCustomerSatisfactionSurvey1(xml1, UserUID);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ls
        public int UpdateCustomerSatisfactionSurvey_cr(CustomerSatisfactionSurveyInfo objCustomerSatisfactionSurveyInfo, int UserUID)
        {
            CustomerSatisfactionSurveyDAL objCustomerSatisfactionSurvey = null;
            string xml1 = string.Empty;
            try
            {
                objCustomerSatisfactionSurvey = new CustomerSatisfactionSurveyDAL();

                xml1 = "<params><param><Answer>" + objCustomerSatisfactionSurveyInfo.answer1 + "</Answer>" + "<Id>" + 1 + "</Id>" +
                        "</param></params>" +
                        "<params><param>" +
                        "<Answer>" + objCustomerSatisfactionSurveyInfo.answer2 + "</Answer>" + "<Id>" + 2 + "</Id>" +
                        "<Description>" + objCustomerSatisfactionSurveyInfo.Description + "</Description>" +
                        "</param></params>";
                //"<params><param>" +
                //"<Answer>" + objCustomerSatisfactionSurveyInfo.answer3 + "</Answer>" + "<Id>" + 3 + "</Id>" +
                //"<Description>" + objCustomerSatisfactionSurveyInfo.Description + "</Description>" +
                //"</param></params>" +
                //"<params><param>" +
                //"<Answer>" + objCustomerSatisfactionSurveyInfo.answer4 + "</Answer>" + "<Id>" + 4 + "</Id>" +
                //"<Description>" + objCustomerSatisfactionSurveyInfo.Description + "</Description>" +
                //"</param></params>";



                //return objCustomerSatisfactionSurvey.UpdateCustomerSatisfactionSurvey(xml1, UserUID);
                return objCustomerSatisfactionSurvey.UpdateCustomerSatisfactionSurvey1_cr(xml1, UserUID);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
