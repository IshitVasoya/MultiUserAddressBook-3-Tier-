using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
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
    private void FillGridView()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectALL(Convert.ToInt32(Session["UserID"]));
        try
        {
            if (dtCountry.Rows.Count > 0 && dtCountry != null)
            {
                gvCountryList.DataSource = balCountry.SelectALL(Convert.ToInt32(Session["UserID"]));
                gvCountryList.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    #endregion FillGridView

    #region gvCountryList : RowCommand
    protected void gvCountryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CountryBAL balCountry = new CountryBAL();
                if(balCountry.Delete(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balCountry.Message;
                }
            }
        }
    }

    #endregion gvCountryList : RowCommand

    

}