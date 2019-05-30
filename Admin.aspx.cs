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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else
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
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            delProduct(delete.Value);
            
 
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            String holdUp = "";
            String storeHere = "";
            StringBuilder err = new StringBuilder();
            SqlConnection conn = SetupConnection.ConnectDB();
            conn.Open();
            SqlCommand sc = new SqlCommand("viewProduct", conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = sc.ExecuteReader();

            while (dr.Read())
            {
                holdUp = dr.GetString(dr.GetOrdinal("id"));
                if (holdUp == edit.Value.ToLower() || holdUp == edit.Value.ToUpper())
                {
                    storeHere = holdUp;
                    break;
                }
            }
            if (storeHere == "")
            {
                err.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                err.Append("Item not available so it cannot be edited");
                err.Append("</div>");
                PlaceHolder2.Controls.Add(new Literal { Text = err.ToString() });
            }
            else
            {
                Session["prodId"] = edit.Value;
                Response.Redirect("updateProduct.aspx");
            }
        }

        public void delProduct(String pid)
        {
            #region Connection Setup
            SqlConnection conn = SetupConnection.ConnectDB();
            #endregion
            int temp = 1;
            String str = "";
            StringBuilder err = new StringBuilder();
            SqlConnection connect = SetupConnection.ConnectDB();
            connect.Open();
            SqlCommand sc1 = new SqlCommand("checkReturned", connect);
            sc1.CommandType = CommandType.StoredProcedure;
            sc1.Parameters.Add("id", SqlDbType.NVarChar).Value = delete.Value;
            SqlDataReader dr1 = sc1.ExecuteReader();

            while (dr1.Read())
            {
                str = dr1.GetString(dr1.GetOrdinal("productID"));
                if (dr1.GetString(dr1.GetOrdinal("productID")) == "")
                {
                    temp = 1;
                    break;
                }
                temp = dr1.GetInt32(dr1.GetOrdinal("returned"));
            }

            dr1.Close();
            connect.Close();

            if (temp == 0)
            {
                err.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                err.Append("Item is borrowed");
                err.Append("</div>");
                PlaceHolder2.Controls.Add(new Literal { Text = err.ToString() });

            }
            else
            {
                conn.Open();
                SqlCommand sc = new SqlCommand("deleteProduct", conn);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add("id", SqlDbType.NVarChar).Value = pid;
                sc.ExecuteNonQuery();

                /*SqlCommand sc1 = new SqlCommand("updateAvailability", conn);
                sc1.CommandType = CommandType.StoredProcedure;
                sc1.Parameters.Add("prodid", SqlDbType.NVarChar).Value = pid;
                sc1.ExecuteNonQuery(); */
                conn.Close();
                Response.Redirect("Admin.aspx");
            }


        }
    }
}