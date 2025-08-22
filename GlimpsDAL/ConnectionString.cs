using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace GlimpsDAL
{
    class ConnectionString
    {

        public string ConnectionStringDB(ConnectionType connectionType)
        {
            //ConnectionType connection = ConnectionType.;

            if (connectionType == 0)
            {
                return ConfigurationManager.ConnectionStrings["ConnectionStringAppDB"].ConnectionString;
            }
            else if ( Convert.ToInt32(connectionType) == 1)
            {
                return ConfigurationManager.ConnectionStrings["ConnectionStringTermDB"].ConnectionString;
            }
            else // Added LS
            {
                return ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            }
        }
    }
}
