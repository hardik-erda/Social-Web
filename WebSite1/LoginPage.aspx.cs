using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class LoginPage : System.Web.UI.Page
{
    string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        lb_msg.Text = "";
        
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        String que = "select * from Users where UserName='"+tb_username.Text+"' and Password='"+tb_password.Text+"'";
        SqlCommand cmd = new SqlCommand(que,con);
        
        SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            Session["User"]=reader["UserName"].ToString();
            Session["Uid"] = reader["UserId"];
            Response.Redirect("dashboard.aspx");
        }
        lb_msg.Text = "Login fail!!";
        
    }
}