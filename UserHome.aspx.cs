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
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder tbl = new StringBuilder();

            String stat = "";
                SqlConnection conn = SetupConnection.ConnectDB();
                conn.Open();
                SqlCommand sc = new SqlCommand("viewProduct", conn);
                sc.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = sc.ExecuteReader();
                tbl.Append("<table class=\"table table-striped w-50\">");
                tbl.Append("<thead>");
                tbl.Append("<tr>");
                tbl.Append("<th scope=\"col\">Product ID</th>");
                tbl.Append("<th scope=\"col\">Title</th>");
                tbl.Append("<th scope=\"col\">Available</th>");
                tbl.Append("</tr>");
                tbl.Append("</thead>");
                tbl.Append("<tbody>");
                while (dr.Read())
                {
                    if (dr.GetInt32(dr.GetOrdinal("avail")) == 0)
                    {
                        stat = "NO";
                    }

                    else
                    {
                        stat = "YES";
                    }

                    tbl.Append("<tr>");
                    tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("id")) + "</td>");
                    tbl.Append("<td>" + dr.GetString(dr.GetOrdinal("title")) + "</td>");
                    tbl.Append("<td>" + stat + "</td>");
                    tbl.Append("</tr>");
                }
                tbl.Append("</tbody>");
                tbl.Append("</table>");
                dr.Close();
                conn.Close();
                PlaceHolder1.Controls.Add(new Literal { Text = tbl.ToString() });
              
            

            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }


        }

        protected void btnBorrow_Click(object sender, EventArgs e)
        {
            GlobalMethods gm = new GlobalMethods();
            StringBuilder err = new StringBuilder();
            String borrowDate = DateTime.Today.ToString("yyyy-MM-dd");
            String returnDate = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");
            String username = Session["username"].ToString();
            String pid = borrow.Value;
            if (checkAvailability(pid) == 0)
            {
                err.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                err.Append("Item not available");
                err.Append("</div>");
                PlaceHolder2.Controls.Add(new Literal { Text = err.ToString() });
            
                
            }

            else
            {
                borrowProduct(pid, gm.getSID(username), borrowDate, returnDate, 0);
            }


        }

        public int checkAvailability(String pid)
        {
            String temp = "";
            #region Connection Setup
            String con = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\College\Senior Files\2nd Sem\ASP Lab\SistosoLalwani\EMSystem\App_Data\EMSDB.mdf;Integrated Security=True";
            SqlConnection conn = SetupConnection.ConnectDB();
            #endregion
            conn.Open();
            SqlCommand sc = new SqlCommand("checkAvailability", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("prodId", SqlDbType.NVarChar).Value = pid;
            SqlDataReader dr = sc.ExecuteReader();

            while (dr.Read())
            {
                temp = dr.GetInt32(dr.GetOrdinal("avail")).ToString();
            }

            dr.Close();
            conn.Close();
            if (temp == "")
            {
                temp = "0";
            }
            return Int32.Parse(temp);
        }

        public void borrowProduct(String pid, String sid, String borrowDate, String returnDate, int returned)
        {
            #region Connection Setup
            String con = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\College\Senior Files\2nd Sem\ASP Lab\SistosoLalwani\EMSystem\App_Data\EMSDB.mdf;Integrated Security=True";
            SqlConnection conn = SetupConnection.ConnectDB();
            #endregion
            conn.Open();
            SqlCommand sc = new SqlCommand("borrowProduct", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("productID", SqlDbType.NVarChar).Value = pid;
            sc.Parameters.Add("sid", SqlDbType.NVarChar).Value = sid;
            sc.Parameters.Add("borrowDate", SqlDbType.NVarChar).Value = borrowDate;
            sc.Parameters.Add("returnDate", SqlDbType.NVarChar).Value = returnDate;
            sc.Parameters.Add("returned", SqlDbType.Int).Value = returned;
            sc.ExecuteNonQuery();

            /*SqlCommand sc1 = new SqlCommand("updateAvailability", conn);
            sc1.CommandType = CommandType.StoredProcedure;
            sc1.Parameters.Add("prodid", SqlDbType.NVarChar).Value = pid;
            sc1.ExecuteNonQuery(); */
            conn.Close();
            Response.Redirect("UserHome.aspx");

     
        }



    }
}