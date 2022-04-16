using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region LoadEvent
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
        }
    }
    #endregion LoadEvent

    #region Button:Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region ServerSide Validation
        String strErrorMessage = "";

        if (txtContactCategoryName.Text.Trim() == "")
            strErrorMessage = "Enter Name";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }

        #endregion ServerSide Validation

        #region Collect FormData
        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        if(txtContactCategoryName.Text.Trim()!="")
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim();

        entContactCategory.UserID = Convert.ToInt32(Session["UserID"]);
        #endregion Collect FormData

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        if (Request.QueryString["ContactCategoryID"] == null)
        {
            if (balContactCategory.Insert(entContactCategory))
            {
                lblMessage.Text = "Successfully Inserted";
                ClearControls();
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
        }
        else
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);
            if (balContactCategory.Update(entContactCategory))
            {
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
        }
    }
    #endregion Button:Save

    #region Button:Cancle
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClearControls();
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion Button:Cancle

    #region ClearControls
    private void ClearControls()
    {
        txtContactCategoryName.Text = "";
    }
    #endregion ClearControls

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID, Convert.ToInt32(Session["UserID"]));

        if (!entContactCategory.ContactCategoryName.IsNull)
        {
            txtContactCategoryName.Text = entContactCategory.ContactCategoryName.ToString();
        }

    }
    #endregion FillControls
}