using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMSystem
{
    public partial class AdminViewAccs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            StringBuilder tbl = new StringBuilder();

            SqlConnection conn = SetupConnection.ConnectDB();
            conn.Open();
            SqlCommand sc = new SqlCommand("viewAllAccs", conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = sc.ExecuteReader();
            tbl.Append("<table class=\"table table-striped w-50\">");
            tbl.Append("<thead>");
            tbl.Append("<tr>");
            tbl.Append("<th scope=\"col\">Student ID</th>");
            tbl.Append("<th scope=\"col\">Username</th>");
            tbl.Append("<th scope=\"col\">Full Name</th>");
            tbl.Append("<th scope=\"col\">Birthdate</th>");
            tbl.Append("<th scope=\"col\">Email</th>");
            tbl.Append("<th scope=\"col\">Mobile Number</th>");
            tbl.Append("</tr>");
            tbl.Append("</thead>");
            tbl.Append("<tbody>");
            while (dr.Read())
            {

                tbl.Append("<tr>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("sid")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("username")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("fullName")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("birthdate")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("email")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("mobileNum")) + "</td>");
                tbl.Append("</tr>");
            }
            tbl.Append("</tbody>");
            tbl.Append("</table>");
            dr.Close();
            conn.Close();
            PlaceHolder1.Controls.Add(new Literal { Text = tbl.ToString() });

        }
    }
}