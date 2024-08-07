﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class FollowingList : System.Web.UI.Page
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
        string que = "select * from Users where UserId in(Select FollowingId from Friends where Uid=" + Session["uid"] + ")";
        //string que = "select Users.UserName,Users.ProfileImg,Friends.FollowingId from Users INNER JOIN Friends ON Users.UserId = in(Select FollowingId from Friends where Uid=\" + Session[\"uid\"] + \")";
        SqlCommand cmd = new SqlCommand(que, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            div.Visible = false;
            GenrateListControl(reader["UserName"].ToString(), reader["ProfileImg"].ToString(), Session["uid"].ToString(), reader["UserId"].ToString());
        }
        reader.Close();
    }
    private void GenrateListControl(String username, string userimg, string uid , string fid)
    {
        HtmlGenericControl div = new HtmlGenericControl("div");
        HtmlGenericControl div2 = new HtmlGenericControl("div");
        HtmlGenericControl lable = new HtmlGenericControl("lable");
        //HtmlGenericControl img = new HtmlGenericControl("img");
        Image img = new Image();


    

        div.Attributes.Add("class", "card mb-5 border-dark mt-5 p-2 ms-5 ");
        div2.Attributes.Add("class", "d-flex");
        lable.Attributes.Add("class", "align-self-center m-auto h2");
        lable.InnerText = username;
        img.CssClass = "rounded-circle float-start";
        img.ImageUrl = userimg;
        img.Width = 120;
        img.Height = 120;
        Button btnLike = new Button();
        btnLike.ID = "btnFollow_"+fid;
        btnLike.Text = "Remove";
        btnLike.CssClass = "btn btn-outline-danger mt-3";
        btnLike.Click += new System.EventHandler(btnUnfollow_click);

        div2.Controls.Add(img);
        div2.Controls.Add(lable);
        div.Controls.Add(div2);
        div.Controls.Add(btnLike);        
        //div.Controls.Add(btnLike);
        pan_searchlist.Controls.Add(div);
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
                //Response.Write(bid);
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                String que = "delete from Friends where uid=" + Session["uid"] + " and FollowingId=" + bid;
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