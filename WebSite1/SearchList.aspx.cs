using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SearchList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("LoginPage.aspx");
        }
        String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Sem-6\ASP.NET\CIE_Project\WebSite1\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string que = "Select * from Friends where Uid="+Session["uid"];
        SqlCommand cmd = new SqlCommand(que, con);
        SqlDataReader reader = cmd.ExecuteReader();
        List<String> list = new List<String>();

        while (reader.Read())
        {
            list.Add(reader["FollowingId"].ToString());
        }
        reader.Close();
        que = "Select * from Users where UserName like '%" + Session["searchText"] + "%' and UserId !="+Session["uid"];
        cmd = new SqlCommand(que, con);
        reader = cmd.ExecuteReader();
        Boolean state_follow = false;
        while (reader.Read())
        {
            div.Visible = false;
            foreach(var fol in list)
            {
                if(fol == reader["userId"].ToString())
                {
                    state_follow = true;
                }
            }
            GenrateListControl(reader["Userid"].ToString(),reader["UserName"].ToString(),state_follow);
            state_follow = false;
        }
        reader.Close();
    }
    private void GenrateListControl(string uid,String username,Boolean state_follow)
    {
        HtmlGenericControl div = new HtmlGenericControl("div");
        HtmlGenericControl lable = new HtmlGenericControl("lable");
        div.Attributes.Add("class", "card mb-5 border-primary w-50 mt-5 p-2 ms-5");
        lable.Attributes.Add("class", "card-header");
        lable.InnerText = username;
        Button btnLike = new Button();
        btnLike.ID = "btnFollow_" + uid;
        if (state_follow)
        {
            btnLike.Text = "Unfollow";
            btnLike.CssClass = "btn btn-outline-secondary ";
            btnLike.Click += new System.EventHandler(btnUnfollow_click);
        }
        else
        {
            btnLike.Text = "+ Follow";
            btnLike.CssClass = "btn btn-outline-primary ";
            btnLike.Click += new System.EventHandler(btnFollow_click);
        }
        div.Controls.Add(lable);
        div.Controls.Add(btnLike);
        pan_searchlist.Controls.Add(div);
    }
    void btnFollow_click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if (b != null)
        {
            //Response.Write(b.ID.Substring(10));
            string bid = b.ID.Substring(10);
            try
            {
                String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                String que = "insert into Friends(Uid,FollowingId) values("+Session["uid"]+","+bid+")";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("Profile.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("update Failed " + ex);
            }
        }
    }
    void btnUnfollow_click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if (b != null)
        {
            //Response.Write(b.ID.Substring(10));
            string bid = b.ID.Substring(10);
            try
            {
                String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                String que = "delete from Friends where uid="+bid+" and FollowingId="+ Session["uid"];
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("Profile.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("update Failed " + ex);
            }
        }
    }
}