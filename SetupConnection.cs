using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EMSystem
{
    public class SetupConnection
    {
        public static SqlConnection ConnectDB()
        {
            String conn = ConfigurationManager.ConnectionStrings["EMSDB"].ConnectionString;
            //return new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\student\Downloads\EMSytsem-master\EMSytsem-master\EMSystem\App_Data\EMSDB.mdf;Integrated Security=True");
            return new SqlConnection(conn);
        }
    }
}