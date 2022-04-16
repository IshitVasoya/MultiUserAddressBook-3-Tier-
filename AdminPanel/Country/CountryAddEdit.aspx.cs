using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region  pageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
        }
    }
    #endregion  pageLoad

    #region Button:Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErroeMessage = "";

        if (txtCountryName.Text.Trim() == "")
            strErroeMessage += "- Enter CountryName <br>";

        if (txtCountryCode.Text.Trim() == "")
            strErroeMessage += "- Enter CountryCode <br>";

        if (strErroeMessage != "")
        {
            lblMessage.Text = strErroeMessage;
            return;
        }
        #endregion Server Side Validation

        #region Collect FormData
        CountryENT entCountry = new CountryENT();

        if (txtCountryName.Text.Trim() != "")
            entCountry.CountryName = txtCountryName.Text.Trim();

        if (txtCountryCode.Text.Trim() != "")
            entCountry.CountryCode = txtCountryCode.Text.Trim();

        entCountry.UserID = Convert.ToInt32(Session["UserID"]);
        #endregion Collect FormData

        CountryBAL balCountry = new CountryBAL();
        if (Request.QueryString["CountryID"] == null)
        {
            if (balCountry.Insert(entCountry))
            {
                lblMessage.Text = "Successfully inserted";
                ClearControls();
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            if (balCountry.Update(entCountry))
            {
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
        }
    }
    #endregion Button:Save

    #region Button:Cancle

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClearControls();
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Button:Cancle

    #region ClearControls
    private void ClearControls()
    {
        txtCountryName.Text = "";
        txtCountryCode.Text = "";
    }
    #endregion ClearControls

    #region FillControls
    private void FillControls(SqlInt32 CountryID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();    

        entCountry= balCountry.SelectByPK(CountryID,Convert.ToInt32(Session["UserID"]));

        if (!entCountry.CountryName.IsNull)
            txtCountryName.Text = entCountry.CountryName.Value.ToString();

        if (!entCountry.CountryCode.IsNull)
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();

       
    }
   
    #endregion FillControls
}