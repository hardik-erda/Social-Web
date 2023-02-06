using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class dashboard : System.Web.UI.Page
{
    string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("LoginPage.aspx");
           
        }
        
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string que = "Select P.Uid,P.Pid,P.PostTitle,P.PostImg,P.PostDes,P.PostLikes,U.UserId,U.UserName from Posts as P,Users as U where P.Uid !=" + Session["Uid"] + "AND U.UserId = P.Uid ORDER BY P.Pid DESC";
        SqlCommand cmd = new SqlCommand(que, con);

        SqlDataReader reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            
            //Session["PostTitle"] = reader["PostTitle"].ToString();
            //Session["PostImg"] = reader["PostImg"].ToString();
            //Session["PostDes"] = reader["PostDes"].ToString();
            //Session["PostLikes"] = reader["PostLikes"].ToString();
            Session["PostId"] = reader["Pid"].ToString();
            GenerateControls(reader["Pid"].ToString(),reader["UserName"].ToString(), reader["PostTitle"].ToString(), reader["PostImg"].ToString(), reader["PostDes"].ToString(), reader["PostLikes"].ToString());
        }
        reader.Close();


    }
    private void GenerateControls(string pid,string user, string title, string imgurl, string des, string likes)
    {

        HtmlGenericControl div = new HtmlGenericControl("div");
        HtmlGenericControl div_cardBody = new HtmlGenericControl("div");
        HtmlGenericControl div_cardBody2 = new HtmlGenericControl("div");
        HtmlGenericControl div_cardBody3 = new HtmlGenericControl("div");
        HtmlGenericControl h3 = new HtmlGenericControl("h3");
        HtmlGenericControl h3_likes = new HtmlGenericControl("h3");
        HtmlGenericControl h5 = new HtmlGenericControl("h5");
        HtmlGenericControl img = new HtmlGenericControl("img");
        HtmlGenericControl p = new HtmlGenericControl("p");
        div.Attributes.Add("class", "card mb-5 border-primary w-80 mt-5    ");
        h3.Attributes.Add("class", "card-header");
        h3.InnerText = user;
        div.Controls.Add(h3);
        div_cardBody.Attributes.Add("class", "card-body");
        h5.Attributes.Add("class", "card-title");
        h5.InnerText = title;
        div_cardBody.Controls.Add(h5);
        div.Controls.Add(div_cardBody);
        img.Attributes.Add("class", "img-fluid");
        img.Attributes.Add("src", imgurl);
        div.Controls.Add(img);
        div_cardBody2.Attributes.Add("class", "card-body");
        p.Attributes.Add("class", "card-text");
        p.InnerText = des;
        div_cardBody2.Controls.Add(p);
        div.Controls.Add(div_cardBody2);
        div_cardBody3.Attributes.Add("class", "card-body");
        h3_likes.InnerText = "Likes: " + likes;
        div_cardBody3.Controls.Add(h3_likes);
        div.Controls.Add(div_cardBody3);
        Button btnLike = new Button();
        btnLike.ID = "btnLike_" + pid;
        btnLike.Text = "\uD83D\uDC4D Like";
        btnLike.CssClass = "btn btn-outline-primary ";
        btnLike.Click += new System.EventHandler(btnLike_click);
        div_cardBody3.Controls.Add(btnLike);
        pan_posts.Controls.Add(div);

    }
    void btnLike_click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if (b != null)
        {
            //Response.Write(b.ID.Substring(8));
            string bid = b.ID.Substring(8);
            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                String que = "update Posts set PostLikes=PostLikes+1 where Pid =" + bid;
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("dashboard.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("update Failed " + ex);
            }
        }
    }


}