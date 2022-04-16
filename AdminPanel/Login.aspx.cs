using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Login : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion PageLoad


    #region Button : Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region ServerSide Validation
        String strErrorMessage = "";

        if(txtUserNameLogin.Text.Trim() == "")
            strErrorMessage += "- Enter UserName <br>";

        if(txtPasswordLogin.Text.Trim() == "")
            strErrorMessage += "- Enter Password <br>";

        if (strErrorMessage != "")
        {
            lblMessageLogin.Text = strErrorMessage;
            return;
        }
        #endregion ServerSide Validation

        #region CollectFormData
        UserENT entUser = new UserENT();

        if (txtUserNameLogin.Text.Trim() != "")
            entUser.UserName = txtUserNameLogin.Text.Trim();

        if (txtPasswordLogin.Text.Trim() != "")
            entUser.Password = txtPasswordLogin.Text.Trim();
        #endregion CollectFormData

        UserBAL balUser = new UserBAL();
        UserENT objEntUser = balUser.SelectByUserNamePassword(entUser);

        if(objEntUser != null)
        {
            Session["UserID"] = objEntUser.UserID.ToString();
            Session["DisplayName"] = objEntUser.DisplayName.ToString();
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            lblMessageLogin.Text = "Invalid Login";

        }
    }
    #endregion Button : Login


    #region Button : SignUp
    protected void btnSignup_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";
        if (txtUsernameSignup.Text == "")
            strErrorMessage += "-enter UserName <br>";

        if (txtPasswordSignup.Text == "")
            strErrorMessage += "-enter Password <br>";

        if (txtDisplayNameSignup.Text == "")
            strErrorMessage += "-enter Displayname <br>";

        if (txtContactnoSignup.Text == "")
            strErrorMessage += "-enter Displayname <br>";

        if (strErrorMessage != "")
        {
            lblMessageSignup.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region CollectFormData
        UserENT entUser = new UserENT();

        if (txtUsernameSignup.Text != "")
            entUser.UserName = txtUsernameSignup.Text.ToString().Trim();

        if (txtPasswordSignup.Text != "")
            entUser.Password = txtPasswordSignup.Text.ToString().Trim();

        if (txtDisplayNameSignup.Text != "")
            entUser.DisplayName = txtDisplayNameSignup.Text.ToString().Trim();

        if (txtContactnoSignup.Text != "")
            entUser.ContactNumber = txtContactnoSignup.Text.ToString().Trim();
        #endregion CollectFormData

        UserBAL balUser = new UserBAL();

        if (balUser.Insert(entUser))
        {
            lblMessageSignup.Text= " Successfully Created Account !Please Login";
            txtUserNameLogin.Text = txtUsernameSignup.Text;
            txtContactnoSignup.Text = "";
            txtUsernameSignup.Text = "";
            txtPasswordSignup.Text = "";
            txtDisplayNameSignup.Text = "";
            txtPasswordLogin.Focus();
        }
        else
        {
            lblMessageSignup.Text = balUser.Message;
        }
    }
    #endregion Button : SignUp
}