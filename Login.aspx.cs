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
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            StringBuilder err = new StringBuilder();
            String user = Request.Form["user"];
            String pass = Request.Form["pass"];
            if (login(user, pass) != "")
            {
                Session["username"] = user;
                if (user == "admin")
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Response.Redirect("UserHome.aspx");
                }
            }

            else
            {
                err.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                err.Append("Invalid username and password");
                err.Append("</div>");
                PlaceHolder1.Controls.Add(new Literal {Text = err.ToString()});
            
            }
            
        }

        public String login(String user, String pass)
        {
            String temp = "";
            #region Connection Setup
            SqlConnection conn = SetupConnection.ConnectDB();
            #endregion
            conn.Open();
            SqlCommand sc = new SqlCommand("login", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("username", SqlDbType.NVarChar).Value = user;
            sc.Parameters.Add("pass", SqlDbType.NVarChar).Value = pass;
            SqlDataReader dr = sc.ExecuteReader();

            while (dr.Read())
            {
                temp = dr.GetString(dr.GetOrdinal("username")).ToString();
            }

            dr.Close();
            conn.Close();
            return temp;
        }
    }
}