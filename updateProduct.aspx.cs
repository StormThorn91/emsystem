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
    public partial class updateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalMethods gm = new GlobalMethods();

            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["prodId"] == null || Session["prodId"] == "")
            {
                Response.Redirect("Admin.aspx");
            }
            else
            {
                
                SqlConnection conn = SetupConnection.ConnectDB();
                conn.Open();
                SqlCommand sc = new SqlCommand("editProduct", conn);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add("id", SqlDbType.NVarChar).Value = Session["prodId"];
                SqlDataReader dr = sc.ExecuteReader();

                while (dr.Read())
                {

                    prodID.Value = dr["id"].ToString();
                    prodTitle.Value = dr["title"].ToString();
                }

                dr.Close();
                conn.Close();
            }

            int temp = 1;
            StringBuilder err = new StringBuilder();
            StringBuilder dis = new StringBuilder();
            SqlConnection connect = SetupConnection.ConnectDB();
            connect.Open();
            SqlCommand sc1 = new SqlCommand("checkReturned", connect);
            sc1.CommandType = CommandType.StoredProcedure;
            sc1.Parameters.Add("id", SqlDbType.NVarChar).Value = Session["prodId"].ToString();
            SqlDataReader dr1 = sc1.ExecuteReader();

            while (dr1.Read())
            {
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
                opt.Disabled = true;
                btnSubmit.Visible = false;
                btnBack.Visible = true;
                
            }

            else
            {
                btnSubmit.Visible = true;
                btnBack.Visible = false;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GlobalMethods gm = new GlobalMethods();
            int av = 0;

            if(opt.Value == "YES"){
                av = 1;
            }

            else{
                av = 0;
            }

            SqlConnection conn = SetupConnection.ConnectDB();
            conn.Open();
            SqlCommand sc = new SqlCommand("updateProduct", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("id", SqlDbType.NVarChar).Value = prodID.Value;
            sc.Parameters.Add("avail", SqlDbType.Int).Value = av;
            sc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Admin.aspx");
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}