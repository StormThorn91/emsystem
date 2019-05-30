using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EMSystem
{
    public class ProductList
    {
        SqlConnection conn = SetupConnection.ConnectDB();
        public DataTable AllProducts()
        {
            DataTable dt = new DataTable();
            conn.Close();
            SqlCommand sc = new SqlCommand("viewProduct", conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sc);
            dt.Clear();
            da.Fill(dt);
            return dt;
        }
    }
}