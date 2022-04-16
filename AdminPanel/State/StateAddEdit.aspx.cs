using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDown();

            if (Request.QueryString["StateID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
        }
    }
    #endregion PageLoad

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlCountryId.SelectedIndex == 0)
            strErrorMessage += "- Please Select Coungtry <br>";

        if (txtStateName.Text.Trim() == "")
            strErrorMessage += "- Please Enter State<br>";

        if (txtStateCode.Text.Trim() == "")
            strErrorMessage += "-Please Enter Code<br>";

        if (strErrorMessage != "")
        {
            lblMessage.Text= strErrorMessage;
            return;
        }

        #endregion Server Side Validation

        #region Collect FormDATA
        StateENT entState = new StateENT();

        if (ddlCountryId.SelectedIndex != 0)
            entState.CountryID = Convert.ToInt32(ddlCountryId.SelectedValue);

        if(txtStateName.Text.Trim()!="")
        {
            entState.StateName = txtStateName.Text.Trim();
        }

        if (txtStateCode.Text.Trim() != "")
        {
            entState.StateCode = txtStateCode.Text.Trim();
        }

        entState.UserID = Convert.ToInt32(Session["UserID"]);

        #endregion Collect FormDATA

        StateBAL balState = new StateBAL();
        if (Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                lblMessage.Text = "Successfully Inserted";
                ClearControls();
            }
            else
            {
                lblMessage.Text = balState.Message;
            }
        }
        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if (balState.Update(entState))
            {
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
            }
            else
            {
                lblMessage.Text = balState.Message;
            }
        }
    }
    #endregion Button : Save

    #region Button:Cancle
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClearControls();
        Response.Redirect("~/AdminPanel/State/StateList");
    }
    #endregion Button:Cancle

    #region FillDropDown
    public void FillDropDown()
    {
        CommonFillMethods.FillDropDownCountry(ddlCountryId,Convert.ToInt32(Session["UserID"]));
    }
    #endregion FillDropDown

    #region ClearControls
    private void ClearControls()
    {
        ddlCountryId.Items.Clear();
        txtStateName.Text = "";
        txtStateCode.Text = "";
    }
    #endregion ClearControls

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        StateENT entState = new StateENT();
        StateBAL balState = new StateBAL();

        entState = balState.SelectByPK(StateID, Convert.ToInt32(Session["UserID"]));

        if (!entState.CountryID.IsNull)
            ddlCountryId.SelectedValue = entState.CountryID.ToString();

        if(!entState.StateName.IsNull)
            txtStateName.Text = entState.StateName.ToString();

        if (!entState.StateCode.IsNull)
            txtStateCode.Text = entState.StateCode.ToString();
    }
    #endregion FillControls
}