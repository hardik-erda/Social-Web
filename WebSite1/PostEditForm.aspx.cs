using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostEditForm : System.Web.UI.Page
{
    string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(constr);
        con.Open();

        string que = "Select * from Posts where Pid=" + Session["bid"];
        SqlCommand cmd = new SqlCommand(que, con);
        SqlDataReader reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            tb_postTitle.Text = reader["PostTitle"].ToString();
            img_postImg.ImageUrl = reader["PostImg"].ToString();
            tb_postDes.Text = reader["PostDes"].ToString();
        }
        reader.Close();
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(constr);
        con.Open();

        try
        {
            string que = "update Posts set PostTitle='"+tb_postTitle.Text.ToString()+"',PostDes='"+ tb_postDes.Text.ToString() + "' where Pid=" + Session["bid"];
            SqlCommand cmd = new SqlCommand(que, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("Profile.aspx");
        }
        catch(Exception ex)  
        {
            Response.Write(ex.ToString());
        }
    }
}