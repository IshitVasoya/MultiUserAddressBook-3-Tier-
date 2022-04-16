using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
public class CommonFillMethods
{

    public static void FillDropDownCountry(DropDownList ddl , SqlInt32 UserID)
    {
        CountryBAL balCountry = new CountryBAL();
        ddl.DataSource = balCountry.SelectForDropDownList(UserID);
        ddl.DataValueField = "CountryID";
        ddl.DataTextField = "CountryName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select Country", "-1"));
    }

    public static void FillDropDownState(DropDownList ddl, SqlInt32 UserID)
    {
        StateBAL balState = new StateBAL();
        ddl.DataSource = balState.DropDownListAllState(UserID);
        ddl.DataValueField = "StateID";
        ddl.DataTextField = "StateName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select State", "-1"));
    }

    public static void FillDropDownContactCategory(DropDownList ddl, SqlInt32 UserID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        ddl.DataSource = balContactCategory.DropDownListAll(UserID);
        ddl.DataValueField = "ContactCategoryID";
        ddl.DataTextField = "ContactCategoryName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
    }


    public static void FillDropDownStateByCountryID(DropDownList ddl , SqlInt32 CountryID , SqlInt32 UserID)
    {
        StateBAL balState = new StateBAL();
        ddl.DataSource = balState.DropDownListStateSelectByCountryID(CountryID,UserID);
        ddl.DataValueField = "StateID";
        ddl.DataTextField = "StateName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select State", "-1"));
    }

    public static void FillDropDownCityByStateID(DropDownList ddl,SqlInt32 StateID, SqlInt32 UserID)
    {
        CityBAL balCity = new CityBAL();
        ddl.DataSource = balCity.DropDownListSelectByStateID(StateID,UserID);
        ddl.DataValueField = "CityID";
        ddl.DataTextField = "CityName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select City", "-1"));
    }
}