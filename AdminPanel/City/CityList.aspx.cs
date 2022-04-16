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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
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

    #region Fillgridview
    private void FillGridView()
    {
        CityBAL balCity = new CityBAL();
        DataTable dt = new DataTable();
        dt= balCity.SelectALL(Convert.ToInt32(Session["UserID"]));
        if(dt!=null && dt.Rows.Count>0)
        {
            gvCityList.DataSource = dt;
            gvCityList.DataBind();
        }
       

    }
    #endregion Fillgridview

    #region gvCityList : RowCommand
    protected void gvCityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CityBAL balCity = new CityBAL();
                if (balCity.Delete(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balCity.Message;
                }
            }
        }
    }
    #endregion gvCityList : RowCommand

   
}