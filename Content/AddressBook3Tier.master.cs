using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_AddressBook3Tier : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            lblMessage.Text = "<h5>" + "Welcome ,<br>" + Session["DisplayName"] + "</h5>";
        }


    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/AdminPanel/Login.aspx");
    }
}
