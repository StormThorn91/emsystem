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
    public partial class Borrow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GlobalMethods gm = new GlobalMethods();

            if (Session["username"] == null || Session["username"] == "admin")
            {
                Response.Redirect("Login.aspx");
            }

            StringBuilder tbl = new StringBuilder();


            SqlConnection conn = SetupConnection.ConnectDB();
            conn.Open();
            SqlCommand sc = new SqlCommand("viewBorrowedItems", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("sid", SqlDbType.NVarChar).Value = gm.getSID(Session["username"].ToString());
            SqlDataReader dr = sc.ExecuteReader();
            tbl.Append("<table class=\"table table-striped w-50\">");
            tbl.Append("<thead>");
            tbl.Append("<tr>");
            tbl.Append("<th scope=\"col\">Product ID</th>");
            tbl.Append("<th scope=\"col\">Borrow Date</th>");
            tbl.Append("<th scope=\"col\">Return Date</th>");
            tbl.Append("</tr>");
            tbl.Append("</thead>");
            tbl.Append("<tbody>");
            while (dr.Read())
            {
                tbl.Append("<tr>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("productID")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("borrowDate")) + "</td>");
                tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("returnDate")) + "</td>");
                tbl.Append("</tr>");
            }
            tbl.Append("</tbody>");
            tbl.Append("</table>");
            dr.Close();
            conn.Close();
            PlaceHolder1.Controls.Add(new Literal { Text = tbl.ToString() });

        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            GlobalMethods gm = new GlobalMethods();
            String stahp = "";
            StringBuilder err = new StringBuilder();
            SqlConnection conn = SetupConnection.ConnectDB();

            conn.Open();
            SqlCommand sc1 = new SqlCommand("viewAllHistory", conn);
            sc1.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = sc1.ExecuteReader();

            while (dr.Read())
            {
                if (dr.GetString(dr.GetOrdinal("sid")) == gm.getSID(Session["username"].ToString()))
                {
                    stahp = "okay";
                    break;
                }
            }
            dr.Close();
            conn.Close();
            if (stahp != "")
            {

                SqlCommand sc = new SqlCommand("returnProduct", conn);
                conn.Open();
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add("productID", SqlDbType.NVarChar).Value = ret.Value;
                sc.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Return.aspx");
            }

            else
            {
                err.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                err.Append("Item is not in your borrow list");
                err.Append("</div>");
                PlaceHolder2.Controls.Add(new Literal { Text = err.ToString() });
            }
        
        }

    }
}