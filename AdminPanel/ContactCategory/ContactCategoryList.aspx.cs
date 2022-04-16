using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    #region LoadEvent
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion LoadEvent

    #region FillGridView
    public void FillGridView()
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dt= new DataTable();
        dt = balContactCategory.SelectALL(Convert.ToInt32(Session["UserID"]));
        if(dt!=null && dt.Rows.Count > 0)
        {
            gvContactCategoryList.DataSource = dt;
            gvContactCategoryList.DataBind();
        }

    }
    #endregion FillGridView

    protected void gvContactCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
                if (balContactCategory.Delete(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balContactCategory.Message;
                }
            }
        }
    }
}