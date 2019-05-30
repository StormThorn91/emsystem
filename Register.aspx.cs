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
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            String username = Request.Form["username"];
            String pass = Request.Form["pass"];
            String name = Request.Form["name"];
            String email = Request.Form["email"];
            String sid = Request.Form["sid"];
            String mobileNum = Request.Form["mobileNum"];
            String birthDate = Request.Form["birthDate"];

            registerAccount(username, pass, name, email, sid, mobileNum, birthDate);

        }

        public void registerAccount(String user, String pass, String name, String email, String sid, String mobileNum, String birthdate)
        {
            #region Connection Setup
            String con = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\College\Senior Files\2nd Sem\ASP Lab\SistosoLalwani\EMSystem\App_Data\EMSDB.mdf;Integrated Security=True";
            SqlConnection conn = SetupConnection.ConnectDB();
            #endregion
            StringBuilder err = new StringBuilder();
            
            if (validateRegistration(sid) == "")
            {
                conn.Open();
                SqlCommand sc = new SqlCommand("register", conn);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add("username", SqlDbType.NVarChar).Value = user;
                sc.Parameters.Add("pass", SqlDbType.NVarChar).Value = pass;
                sc.Parameters.Add("sid", SqlDbType.NVarChar).Value = sid;
                sc.Parameters.Add("email", SqlDbType.NVarChar).Value = email;
                sc.Parameters.Add("mobileNum", SqlDbType.NVarChar).Value = mobileNum;
                sc.Parameters.Add("fullName", SqlDbType.NVarChar).Value = name;
                sc.Parameters.Add("birthdate", SqlDbType.NVarChar).Value = birthdate;
                sc.ExecuteNonQuery();
                conn.Close();
                Session["username"] = user;
                Response.Redirect("UserHome.aspx");
            }

            else
            {
                err.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                err.Append("You already have an account");
                err.Append("</div>");
                PlaceHolder1.Controls.Add(new Literal { Text = err.ToString() });
            
            }
                
        }

        public String validateRegistration(String sid)
        {
            String temp = "";
            #region Connection Setup
            String con = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\College\Senior Files\2nd Sem\ASP Lab\SistosoLalwani\EMSystem\App_Data\EMSDB.mdf;Integrated Security=True";
            SqlConnection conn = SetupConnection.ConnectDB();
            #endregion
            conn.Open();
            SqlCommand sc = new SqlCommand("validateRegister", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("sid", SqlDbType.NVarChar).Value = sid;
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