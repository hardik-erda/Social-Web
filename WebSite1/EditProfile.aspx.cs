using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {

            String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Sem-6\ASP.NET\CIE_Project\WebSite1\App_Data\Database.mdf;Integrated Security=True";
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