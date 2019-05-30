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
    public partial class AccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "admin")
            {
                Response.Redirect("Login.aspx");
            }

            GlobalMethods gm = new GlobalMethods();
            

            SqlConnection conn = SetupConnection.ConnectDB();
            conn.Open();
            SqlCommand sc = new SqlCommand("viewAccount", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("sid", SqlDbType.NVarChar).Value = gm.getSID(Session["username"].ToString());
            SqlDataReader dr = sc.ExecuteReader();

            while (dr.Read())
            {
                name.InnerHtml = dr.GetString(dr.GetOrdinal("fullName"));
                sid.InnerHtml = dr.GetString(dr.GetOrdinal("sid"));
                mobileNum.InnerHtml = dr.GetString(dr.GetOrdinal("mobileNum"));
                birthdate.InnerHtml = dr.GetString(dr.GetOrdinal("birthdate"));
                email.InnerHtml = dr.GetString(dr.GetOrdinal("email"));
            }

            dr.Close();
            conn.Close();


        }

        protected void btnChangeDeets_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeAccDetails.aspx");
        }
    }
}