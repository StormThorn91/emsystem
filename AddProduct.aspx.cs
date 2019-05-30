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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region Connection Setup
            SqlConnection conn = SetupConnection.ConnectDB();
            #endregion
            conn.Open();
            SqlCommand sc = new SqlCommand("addProduct", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add("id", SqlDbType.NVarChar).Value = prodID.Value;
            sc.Parameters.Add("title", SqlDbType.NVarChar).Value = prodTitle.Value;
            try
            {
                sc.ExecuteNonQuery();
            }
            catch (SqlException f)
            {
                
            }
            
            conn.Close();
            Response.Redirect("Admin.aspx");

        }
    }
}