using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDown();
            if (Request.QueryString["CityID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
        }
    }
    #endregion PageLoad

    #region Button:Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";
        if(ddlStateId.SelectedIndex==0)
        {
            strErrorMessage += "-Please Select State<br>";
        }

        if (txtCityName.Text.Trim() == "")
        {
            strErrorMessage += "-Please Enter Name<br>";
        }

        if (txtStdCode.Text.Trim() == "")
        {
            strErrorMessage += "-Please Enter Code<br>";
        }

        if (txtPinCode.Text.Trim() == "")
        {
            strErrorMessage += "-Please Enter PIN<br>";
        }


        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Collect FormData
        CityENT entCity = new CityENT();

        if (ddlStateId.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlStateId.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (txtStdCode.Text.Trim() != "")
            entCity.STDCode = txtStdCode.Text.Trim();

        if (txtPinCode.Text.Trim() != "")
            entCity.PinCode = txtPinCode.Text.Trim();

        entCity.UserID = Convert.ToInt32(Session["UserID"]);

        #endregion Collect FormData

        CityBAL balCity = new CityBAL();
        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                lblMessage.Text = "inserted Successfully";
                ClearControls();
            }
            else
            {
                lblMessage.Text = balCity.Message;
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
            if (balCity.Update(entCity))
            {
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
            }
            else
            {
                lblMessage.Text = balCity.Message;
            }
        }

    }
    #endregion Button:Save

    #region Button:Cancle
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClearControls();
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Button:Cancle

    #region FillDropDown
    private void FillDropDown()
    {
        CommonFillMethods.FillDropDownState(ddlStateId, Convert.ToInt32(Session["UserID"]));
    }
    #endregion FillDropDown

    #region ClearControls
    private void ClearControls()
    {
        ddlStateId.Items.Clear();
        txtCityName.Text = "";
        txtStdCode.Text = "";
        txtPinCode.Text = "";
    }
    #endregion ClearControls

    #region FillControls
    private void FillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByPK(CityID, Convert.ToInt32(Session["UserID"]));

        if (!entCity.StateID.IsNull)
        {
            ddlStateId.SelectedValue = entCity.StateID.ToString();
        }

        if (!entCity.CityName.IsNull)
        {
            txtCityName.Text = entCity.CityName.ToString();
        }

        if (!entCity.STDCode.IsNull)
        {
            txtStdCode.Text = entCity.STDCode.ToString();
        }

        if (!entCity.PinCode.IsNull)
        {
            txtPinCode.Text = entCity.PinCode.ToString();
        }



    }
    #endregion FillControls
}