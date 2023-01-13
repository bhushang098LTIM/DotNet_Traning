using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login_Redirection
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.user_name = tb_user_name.Text;
            user.password = tb_password.Text;

            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();

            string strConn = @"Data Source=PRSQL;Initial Catalog=UserDb;User ID=labuser;Password=Welcome123$";
            string strCmd = @"select * from Users where user_name = '"+user.user_name+"' and password = '"+user.password+"'";

            objConn.ConnectionString = strConn;
            objCmd.Connection = objConn;
            objCmd.CommandType = System.Data.CommandType.Text;
            objCmd.CommandText = strCmd;

            objConn.Open();
            int rowaffected = objCmd.ExecuteNonQuery();

            if(rowaffected > 0)
            {
                Response.Write("Crediientials not matched");
            }
            else
            {
                Response.Write("User Found");
                // Redirect

                FormsAuthentication.RedirectFromLoginPage(user.user_name, false);


            }
            objConn.Close();


        }
    }
}