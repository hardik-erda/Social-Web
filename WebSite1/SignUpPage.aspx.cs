using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class SignUpPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_signUp_Click(object sender, EventArgs e)
    {
        if(tb_username.Text == "" )
        {
            lb_msg.Text = "Username can't be empty!!";
        }
        else if (tb_password.Text == "")
        {
            lb_msg.Text = "Password can't be empty!!";
        }
        else if(fu_profile.HasFile == false)
        {
            lb_msg.Text = "Please add Profile pic!";
        }
        else
        {
            if (fu_profile.HasFile)
            {
                string ext = System.IO.Path.GetExtension(fu_profile.FileName);
                fu_profile.SaveAs(@"E:\Sem 6\ASP\WebSite1\WebSite1\ProfilePics\" + Session["Uid"] + ext);
                String temp_imgurl = "ProfilePics/" + Session["Uid"] + ext;
                try
                {
                String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                String que = "insert into Users(UserName,Password,ProfileImg) values(@user,@pass,@img)";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.Parameters.AddWithValue("@user", tb_username.Text.ToString());
                cmd.Parameters.AddWithValue("@pass", tb_password.Text.ToString());
                cmd.Parameters.AddWithValue("@img", temp_imgurl);
                cmd.ExecuteNonQuery();
                Response.Redirect("LoginPage.aspx");
                }
                catch
                {
                    lb_msg.Text = "Sign up fails !!";
                }
            }

        }
    }
}