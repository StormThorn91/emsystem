using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EMSystem
{
    public class GlobalMethods
    {
        public String getSID(String username)
        {
            String temp = "";
            #region Connection Setup
            SqlConnection conn = SetupConnection.ConnectDB();
            #endregion
            conn.Open();
            SqlCommand sc = new SqlCommand("getStudentID", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("user", SqlDbType.NVarChar).Value = username;
            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                temp = dr.GetString(dr.GetOrdinal("sid")).ToString();
            }

            dr.Close();
            conn.Close();
            return temp;
        }
    }
}