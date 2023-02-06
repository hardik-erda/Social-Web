using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        //use sender obj to check btn click even
        //if (IsPostBack)
        //{
        //    object ctrl = Request.Params["__EVENTTARGET"];
        //    Response.Write(ctrl.ToString());
        //}

        if (Session["user"] == null)
        {
            Response.Redirect("LoginPage.aspx");
        }
        lb_pname.Text = Session["user"].ToString();

        
        SqlConnection con = new SqlConnection(constr);
        con.Open();

        string que = "Select * from Posts where Uid="+Session["Uid"]+ " ORDER BY Pid DESC";
        SqlCommand cmd = new SqlCommand(que, con);

        SqlDataReader reader = cmd.ExecuteReader();
        int CountPost = 0;
        while (reader.Read())
        {
            CountPost += 1;
            //Session["PostTitle"] = reader["PostTitle"].ToString();
            //Session["PostImg"] = reader["PostImg"].ToString();
            //Session["PostDes"] = reader["PostDes"].ToString();
            //Session["PostLikes"] = reader["PostLikes"].ToString();
            Session["PostId"] = reader["Pid"].ToString();
            GenerateControls(reader["Pid"].ToString(),Session["user"].ToString(),reader["PostTitle"].ToString(), reader["PostImg"].ToString(), reader["PostDes"].ToString(), reader["PostLikes"].ToString());
        }
        reader.Close();
        Session["countPost"] = CountPost;
        lb_countPost.InnerText = CountPost.ToString();
        //card_profileName.InnerText = Session["user"].ToString();
        //card_title_profile.InnerText = Session["PostTitle"].ToString();
        //card_des_profile.InnerText = Session["PostDes"].ToString();
        //card_like_profile.InnerText = Session["PostLikes"].ToString();
        que = "Select * from Users where UserId=" + Session["Uid"];
        cmd = new SqlCommand(que, con);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Session["ProfileImg"] = reader["ProfileImg"];
            img_profile.ImageUrl = reader["ProfileImg"].ToString();
        }
        reader.Close();
        //img_profile.ImageUrl = Session["ProfileImg"].ToString();

        //followers count

        que = "select count(*) from Friends where FollowingId="+Session["uid"];
        cmd = new SqlCommand(que, con);
        lb_countFollowers.InnerText = cmd.ExecuteScalar().ToString();

        //following count
        que = "select count(*) from Friends where UId=" + Session["uid"];
        cmd = new SqlCommand(que, con);
        lb_countFollowing.InnerText= cmd.ExecuteScalar().ToString();
    }
    
    private void GenerateControls(string pid,string user,string title,string imgurl,string des,string likes)
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
                div.Attributes.Add("class", "card mb-5 border-dark w-50 mt-5  mx-auto  ");
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
                h3_likes.InnerText = "Likes: "+likes;
                div_cardBody3.Controls.Add(h3_likes);
                div.Controls.Add(div_cardBody3);
        Button btnLike = new Button();
        btnLike.ID = "btnLike_"+pid;
        btnLike.Text = "\uD83D\uDC4D Like";
        btnLike.CssClass = "btn btn-outline-dark ";
        btnLike.Click += new System.EventHandler(btnLike_click);
                div_cardBody3.Controls.Add(btnLike);
                pan_posts.Controls.Add(div);
                
            
        
    }

    protected void editPname_ServerClick(object sender, EventArgs e)
    {
        
        Panel1.Visible = true;

    }
    protected void btn_update_click(object sender,EventArgs e)
    {
        if(tb_updatedUser.Text != "")
        {

        try
        {
           
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            String que = "update Users set UserName=@user where UserId ="+Session["Uid"];
            SqlCommand cmd = new SqlCommand(que, con);
            cmd.Parameters.AddWithValue("@user",tb_updatedUser.Text.ToString());
            cmd.ExecuteNonQuery();
            Session["user"] = tb_updatedUser.Text.ToString();
            lb_pname.Text = Session["user"].ToString();
            
            
        }
        catch
        {
                Response.Write("update Failed");
        }
        }

    }

    protected void btn_updatePic_Click(object sender, EventArgs e)
    {
        if (fu_profile.HasFile)
        { 
            string ext = System.IO.Path.GetExtension(fu_profile.FileName);
            fu_profile.SaveAs(@"E:\Sem 6\ASP\WebSite1\WebSite1\ProfilePics\"+Session["Uid"]+ ext);
            String temp_imgurl = "ProfilePics/" + Session["Uid"] + ext;
            img_profile.ImageUrl = temp_imgurl;

            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                String que = "update Users set ProfileImg='"+temp_imgurl+"' where UserId =" + Session["Uid"];
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("Profile.aspx");

            }
            catch(Exception ex)
            {
                Response.Write("update Failed "+ex);
            }
        }
    }

    void btnLike_click(object sender,EventArgs e)
    {
        Button b = sender as Button;
        if(b!= null)
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
                Response.Redirect("Profile.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("update Failed " + ex);
            }
        }
    }

    protected void btn_Followers_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("FollowersList.aspx");
    }

    protected void btn_Following_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("FollowingList.aspx");
    }
}