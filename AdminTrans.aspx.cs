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
    public partial class AdminTrans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalMethods gm = new GlobalMethods();

            if (Session["username"] == null || Session["username"] == "admin")
            {
                Response.Redirect("Login.aspx");
            }

            StringBuilder tbl = new StringBuilder();

            String stat = "";

            SqlConnection conn = SetupConnection.ConnectDB();
            conn.Open();
            SqlCommand sc = new SqlCommand("viewAllHistory", conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = sc.ExecuteReader();
            tbl.Append("<table class=\"table table-striped w-50\">");
            tbl.Append("<thead>");
            tbl.Append("<tr>");
            tbl.Append("<th scope=\"col\">Transaction ID</th>");
            tbl.Append("<th scope=\"col\">Product ID</th>");
            tbl.Append("<th scope=\"col\">Student ID</th>");
            tbl.Append("<th scope=\"col\">Borrow Date</th>");
            tbl.Append("<th scope=\"col\">Return Date</th>");
            tbl.Append("<th scope=\"col\">Returned</th>");
            tbl.Append("</tr>");
            tbl.Append("</thead>");
            tbl.Append("<tbody>");
            while (dr.Read())
            {

                if (dr.GetInt32(dr.GetOrdinal("returned")) == 0)
                {
                    stat = "NO";
                }

                else
                {
                    stat = "YES";
                }

                tbl.Append("<tr>");
                tbl.Append("<td>" + dr.GetInt32(dr.GetOrdinal("transID")).ToString() + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("productID")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("sid")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("borrowDate")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("returnDate")) + "</td>");
                tbl.Append("<td>" + stat + "</td>");
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