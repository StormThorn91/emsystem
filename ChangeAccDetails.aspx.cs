using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMSystem
{
    public partial class ChangeAccDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "admin")
            {
                Response.Redirect("Login.aspx");
            }

            getData();

            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GlobalMethods gm = new GlobalMethods();

            
            String mn = mobileNum.Value;
            String em = email.Value;


            SqlConnection conn = SetupConnection.ConnectDB();
            conn.Open();
            SqlCommand sc = new SqlCommand("editAccount", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("sid", gm.getSID(Session["username"].ToString()));
            sc.Parameters.AddWithValue("mobileNum", mn);
            sc.Parameters.AddWithValue("email", em);


            //sc.Parameters.Add("sid", SqlDbType.NVarChar).Value = gm.getSID(Session["username"].ToString());
            //sc.Parameters.Add("mobileNum", SqlDbType.NVarChar).Value = mn;
            //sc.Parameters.Add("email", SqlDbType.NVarChar).Value = em;
            sc.ExecuteNonQuery();
            conn.Close();

            getData();
            Response.Redirect("AccountDetails.aspx");
        }

        public void getData()
        {
            GlobalMethods gm = new GlobalMethods();


            SqlConnection conn = SetupConnection.ConnectDB();
            conn.Open();
            SqlCommand sc = new SqlCommand("viewAccount", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("sid", SqlDbType.NVarChar).Value = gm.getSID(Session["username"].ToString());
            SqlDataReader dr = sc.ExecuteReader();

            while (dr.Read())
            {
                /*
                name.Value = dr.GetString(dr.GetOrdinal("fullName"));
                studnum.Value = dr.GetString(dr.GetOrdinal("sid"));
                birthdate.Value = dr.GetString(dr.GetOrdinal("birthdate"));
                mobileNum.Value = dr.GetString(dr.GetOrdinal("mobileNum"));
                email.Value = dr.GetString(dr.GetOrdinal("email"));
                 * */

                name.Value = dr["fullName"].ToString();
                studnum.Value = dr["sid"].ToString();
                birthdate.Value = dr["birthdate"].ToString();
            }

            dr.Close();
            conn.Close();
        }
    }

}