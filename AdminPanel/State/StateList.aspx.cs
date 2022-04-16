using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGridView();

        }
    }
    #endregion PageLoad

    #region FillGridView
    private void FillGridView()
    {
        StateBAL balState= new StateBAL();
        DataTable dt = new DataTable();
        dt = balState.SelectAll(Convert.ToInt32(Session["UserID"]));
        if(dt!=null && dt.Rows.Count > 0)
        {
            gvStateList.DataSource = dt;
            gvStateList.DataBind();
        }
        
    }
    #endregion FillGridView


    #region gvStateList:RowCommand
    protected void gvStateList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StateBAL balState = new StateBAL();
                if (balState.Delete(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balState.Message;
                }
            }
        }
    }

    #endregion gvStateList:RowCommand
}