using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion PageLoad

    #region FillGridView
    private void FillGridView()
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dt = new DataTable();
        dt= balContact.SelectALL(Convert.ToInt32(Session["UserID"]));
        if(dt!=null && dt.Rows.Count > 0)
        {
            gvContactList.DataSource = dt;
            gvContactList.DataBind();
        }
        else
        {
            gvContactList.DataSource = null;
            gvContactList.DataBind();
        }
          
    }
    #endregion FillGridView

    #region gvContactList:RowCommand
    protected void gvContactList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                #region Delete Photo From Directory
                ContactImageBAL balContactImage = new ContactImageBAL();
                String LogicalPath = balContactImage.ContactImageFilePathSelectByContactID(Convert.ToInt32(e.CommandArgument)).ToString();
                String AbsolutePath = Server.MapPath(LogicalPath);

                FileInfo file = new FileInfo(AbsolutePath);
                if (file.Exists)
                    file.Delete();
                #endregion Delete Photo From Directory

                #region Delete ContactImage Record
                balContactImage.Delete(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"]));
                #endregion Delete ContactImage Record

                #region Delete CBL Records
                ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
               if (!balContactWiseContactCategory.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    lblMessage.Text = balContactWiseContactCategory.Message;
                }
                #endregion Delete CBL Records

                ContactBAL balContact = new ContactBAL();
                if(balContact.Delete(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    

                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balContact.Message;
                }
            }

        }
    }
    #endregion gvContactList:RowCommand
}