using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    

    protected void Logout_ServerClick(object sender, EventArgs e)
    {

        Session.Remove("user");
        Session.Abandon();
        Response.Redirect("LoginPage.aspx");
    }

    protected void btn_search_ServerClick(object sender, EventArgs e)
    {
        Session["searchText"] = tb_search.Value.ToString();
        Response.Redirect("SearchList.aspx");
    }
}
