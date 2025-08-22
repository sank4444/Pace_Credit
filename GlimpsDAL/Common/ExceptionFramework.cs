using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace GlimpsDAL.Common
{

    public class UserInstance
    {
        private static volatile UserInstance Instance;
        private static object _Lock = new object();

        public int UserUID { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns> 
        public static UserInstance GetInstance()
        {
            lock (_Lock)
            {
                if (Instance == null)
                    Instance = new UserInstance();
                return Instance;
            }
        }
    }

   public class ExceptionFramework
    {
        /// <summary>
        /// Writes the error logs.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public static void WriteErrorLogs(string logMessage)
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["IS_LOG_ENABLED"]) == false) return;
            string strLogMessage = string.Empty;
            int userUID = UserInstance.GetInstance().UserUID;
            string userName = UserInstance.GetInstance().UserName;
            string strLogFile = System.Configuration.ConfigurationManager.AppSettings["LOG_FILE_PATH"].ToString();
            StreamWriter swLog;
            strLogMessage = string.Format("{0}: {1}: {2}", DateTime.Now, "UserUID: " + userUID + " UserName: " + userName, logMessage);
            if (!File.Exists(strLogFile))
            {
                swLog = new StreamWriter(strLogFile);
            }
            else
            {
                swLog = File.AppendText(strLogFile);
            }

            swLog.WriteLine(strLogMessage);
            swLog.WriteLine();

            swLog.Close();

        }
       //LS
        public static void WriteErrorLogs_cr(string logMessage)
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["IS_LOG_ENABLED"]) == false) return;
            string strLogMessage = string.Empty;
            int userUID = UserInstance.GetInstance().UserUID;
            string userName = UserInstance.GetInstance().UserName;
            string strLogFile = System.Configuration.ConfigurationManager.AppSettings["LOG_FILE_PATH"].ToString();
            StreamWriter swLog;
            strLogMessage = string.Format("{0}: {1}: {2}", DateTime.Now, "UserUID: " + userUID + " UserName: " + userName, logMessage);
            if (!File.Exists(strLogFile))
            {
                swLog = new StreamWriter(strLogFile);
            }
            else
            {
                swLog = File.AppendText(strLogFile);
            }

            swLog.WriteLine(strLogMessage);
            swLog.WriteLine();

            swLog.Close();

        }
    }
}
