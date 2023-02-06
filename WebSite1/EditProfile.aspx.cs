using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class EditProfile : System.Web.UI.Page
{
    string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Sem 6\ASP\WebSite1\WebSite1\App_Data\db_socialMedia.mdf';Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string que = "update Users set UserName='" + tb_editPname.Text + "' where UserName='"+Session["user"]+"'";
            SqlCommand cmd = new SqlCommand(que, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("Profile.aspx");
        }
        catch 
        {
            Response.Write("Not updated!!");
        }
    }
}