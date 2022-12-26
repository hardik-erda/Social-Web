using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
    protected void btn_post_Click(object sender,EventArgs e)
    {
        if (tb_title.Text == "")
        {
            Response.Write("Enter title first!");
        }
        else if(fu_post.HasFile == false)
        {
            Response.Write("Add Img first!");
        }
        else
        {

            if (fu_post.HasFile)
            {
                fu_post.SaveAs(@"E:\Sem 6\ASP\WebSite1\WebSite1\PostImg\" + Session["Uid"] + "_"+fu_post.FileName);
                String temp_imgurl = "PostImg/" + Session["Uid"] +"_"+fu_post.FileName;
                try
                {
                    String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    String que = "insert into Posts(Uid,PostTitle,PostImg,PostDes,PostLikes) values(@uid,@title,@img,@des,0)";
                    SqlCommand cmd = new SqlCommand(que, con);
                    cmd.Parameters.AddWithValue("@uid", Session["uid"]);
                    cmd.Parameters.AddWithValue("@title", tb_title.Text.ToString());
                    cmd.Parameters.AddWithValue("@img", temp_imgurl);
                    cmd.Parameters.AddWithValue("@des", ta_des.Value);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Profile.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("Sign up fails !!   "+ex);
                }
            }
        }
    }
}