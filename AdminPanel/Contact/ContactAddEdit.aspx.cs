using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownCountry();
            // FillDropDownContactCategory();
            FillCheckBoxList();

            if (Request.QueryString["ContactID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
        }
    }
    #endregion PageLoad

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region LocalVariables

        String strErrorMessage = "";
        String LogicalPath = "~/UserContent/";
        String AbsolutePath = "";
        AbsolutePath = Server.MapPath(LogicalPath);
        #endregion LocalVariables

        #region ServerSide Validation

        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += "- Please select Country";
        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += "- Please select State";
        if (ddlCityID.SelectedIndex == 0)
            strErrorMessage += "- Please select City";
        //if (ddlContactCategoryID.SelectedIndex == 0)
        //    strErrorMessage += "- Please select ContactCategory";
        if (txtContactName.Text.Trim()=="")
            strErrorMessage += "- Please Enter Name";
        if (Request.QueryString["ContactID"] == null)
        {
            if (!fuContactImage.HasFile)
                strErrorMessage += "-Please Select Image";
        }
        if (txtContactNumber.Text.Trim() == "")
            strErrorMessage += "- Please Enter ContactNumber";
        if (txtWhatsappNumber.Text.Trim() == "")
            strErrorMessage += "- Please Enter WhatsappNumber";
        if (txtBirthdate.Text.Trim() == "")
            strErrorMessage += "- Please Enter Birthdate";
        if (txtEmail.Text.Trim() == "")
            strErrorMessage += "- Please Enter Email";
        if (txtAge.Text.Trim() == "")
            strErrorMessage += "- Please Enter Age";
        if (txtAddress.Text.Trim() == "")
            strErrorMessage += "- Please Enter Address";

        if(strErrorMessage!="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }

        #endregion ServerSide Validation

        #region Collect FormData 
        ContactENT entContact = new ContactENT();
        

       
        if (ddlCountryID.SelectedIndex > 0)
            entContact.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        if (ddlStateID.SelectedIndex > 0)
            entContact.StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        if (ddlCityID.SelectedIndex > 0)
            entContact.CityID = Convert.ToInt32(ddlCityID.SelectedValue);
        //if (ddlContactCategoryID.SelectedIndex > 0)
        //    entContact.ContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
        if (txtContactName.Text.Trim() != "")
            entContact.ContactName = txtContactName.Text.Trim();
        if (txtContactNumber.Text.Trim() != "")
            entContact.ContactNumber = txtContactNumber.Text.Trim();
        if (txtWhatsappNumber.Text.Trim() != "")
            entContact.WhatsappNumber = txtWhatsappNumber.Text.Trim();
        if (txtBirthdate.Text.Trim() != "")
            entContact.BirthDate = txtBirthdate.Text.Trim();
        if (txtEmail.Text.Trim() != "")
            entContact.Email = txtEmail.Text.Trim();
        if (txtAge.Text.Trim() != "")
            entContact.Age = Convert.ToInt32(txtAge.Text.Trim());
        if (txtAddress.Text.Trim() != "")
            entContact.Address = txtAddress.Text.Trim();

        entContact.UserID = Convert.ToInt32(Session["UserID"]);

        entContact.BloodGroup = txtBloodGroup.Text.Trim();
        entContact.FacebookID = txtFaceBookId.Text.Trim();  
        entContact.LinkedinID = txtLinkedinId.Text.Trim();
        

        

        #endregion Collect FormData

        ContactBAL balContact = new ContactBAL();
        if (Request.QueryString["ContactID"] == null)
        {
            if (balContact.Insert(entContact))
            {
                lblMessage.Text = "inserted Successfully" + entContact.ContactID;
                #region SaveCBL Record
                ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
                ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();
                entContactWiseContactCategory.ContactID = entContact.ContactID;
                foreach(ListItem liContactCategoryID in cblContactCategoryID.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        entContactWiseContactCategory.ContactCategoryID = Convert.ToInt32(liContactCategoryID.Value);
                        balContactWiseContactCategory.Insert(entContactWiseContactCategory);

                    }
                }
                #endregion SaveCBL Record

                #region Insert ContactImage

                #region SaveImageToDirectory
                if (!Directory.Exists(AbsolutePath))
                    Directory.CreateDirectory(AbsolutePath);

                fuContactImage.SaveAs(AbsolutePath + fuContactImage.FileName);
                #endregion SaveImageToDirectory

                #region Insert ContactImage record
                ContactImageENT entContactImage = new ContactImageENT();

                entContactImage.ContactImageFilePath = LogicalPath + fuContactImage.FileName;
                entContactImage.UserID = Convert.ToInt32(Session["UserID"]);
                entContactImage.ContactID = entContact.ContactID;
                System.Drawing.Image img = System.Drawing.Image.FromStream(fuContactImage.PostedFile.InputStream);
                entContactImage.Width = img.Width.ToString();
                entContactImage.Height = img.Height.ToString();
                entContactImage.FileName = fuContactImage.FileName;
                FileInfo File = new FileInfo(AbsolutePath + fuContactImage.FileName);
                entContactImage.FileSize = ((File.Length) / 1024).ToString() + " KB";
                entContactImage.Extension = File.Extension;

                ContactImageBAL balContactImage = new ContactImageBAL();
                balContactImage.Insert(entContactImage);
                #endregion Insert ContactImage record

                //entContact.ContactID
                #endregion Insert ContactImage
                ClearControls();


            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
        }
        else
        {
            entContact.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);
            if (balContact.Update(entContact))
            {
                #region UpdateCBL
                ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();

                balContactWiseContactCategory.Delete(entContact.ContactID);

                ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();
                entContactWiseContactCategory.ContactID = entContact.ContactID;
                foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        entContactWiseContactCategory.ContactCategoryID = Convert.ToInt32(liContactCategoryID.Value);
                        balContactWiseContactCategory.Insert(entContactWiseContactCategory);

                    }
                }

                #endregion UpdateCBL

                if (fuContactImage.HasFile)
                {
                    #region Delete old image and Insert new image
                    FileInfo file = new FileInfo(Server.MapPath(hfFilePath.Value));
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    fuContactImage.SaveAs(AbsolutePath + fuContactImage.FileName);
                    #endregion Delete old image and Insert new image

                    #region Update ContactImage Record
                    
                    ContactImageENT entContactImage = new ContactImageENT();

                    entContactImage.ContactImageFilePath = LogicalPath + fuContactImage.FileName;
                    entContactImage.UserID = Convert.ToInt32(Session["UserID"]);
                    entContactImage.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(fuContactImage.PostedFile.InputStream);
                    entContactImage.Width = img.Width.ToString();
                    entContactImage.Height = img.Height.ToString();
                    entContactImage.FileName = fuContactImage.FileName;
                    FileInfo File = new FileInfo(AbsolutePath + fuContactImage.FileName);
                    entContactImage.FileSize = ((File.Length) / 1024).ToString() + " KB";
                    entContactImage.Extension = File.Extension;

                    ContactImageBAL balContactImage = new ContactImageBAL();
                    balContactImage.Update(entContactImage);
                    
                    #endregion Update ContactImage Record
                }
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
        }
    }
    #endregion Button : Save

    

    #region Button : Cancle
    protected void btnCancle_Click(object sender, EventArgs e)
    {

        ClearControls();
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion Button : Cancle

    #region FillDropDown : Country | State | City | ContactCategory 
    public void FillDropDownCountry()
    {
        CommonFillMethods.FillDropDownCountry(ddlCountryID,Convert.ToInt32(Session["UserID"]));
    }

    public void FillDropDownContactCategory()
    {
        //CommonFillMethods.FillDropDownContactCategory(ddlContactCategoryID, Convert.ToInt32(Session["UserID"]));
    }

    public void FillDropDownStateByCountryID(SqlInt32 CountryID)
    {
        CommonFillMethods.FillDropDownStateByCountryID(ddlStateID,CountryID, Convert.ToInt32(Session["UserID"]));
    }
    public void FillDropDownCityByStateID(SqlInt32 StateID)
    {
        CommonFillMethods.FillDropDownCityByStateID(ddlCityID, StateID, Convert.ToInt32(Session["UserID"]));
    }
    #endregion FillDropDown : Country | State | City | ContactCategory 

    #region FillCheckBoxList
    public void  FillCheckBoxList()
    {
         ContactCategoryBAL balCategory = new ContactCategoryBAL();
        cblContactCategoryID.DataSource = balCategory.SelectALL(Convert.ToInt32(Session["UserID"]));
        cblContactCategoryID.DataValueField = "ContactCategoryID";
        cblContactCategoryID.DataTextField = "ContactCategoryName";
        cblContactCategoryID.DataBind();
    }
    #endregion FillCheckBoxList

    protected void ddlCountryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDownStateByCountryID(Convert.ToInt32(ddlCountryID.SelectedValue));
    }

    protected void ddlStateList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDownCityByStateID(Convert.ToInt32(ddlStateID.SelectedValue));
    }

    #region ClearControls
    private void ClearControls()
    {
        //ddlCountryID.Items.Clear();
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.Items.Clear();
        ddlCityID.Items.Clear();
        //ddlContactCategoryID.Items.Clear();
        //ddlContactCategoryID.SelectedIndex = 0;
        cblContactCategoryID.ClearSelection();
        txtContactName.Text = "";
        txtContactNumber.Text = "";
        txtWhatsappNumber.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        txtBirthdate.Text = "";
        txtBloodGroup.Text = "";
        txtFaceBookId.Text = "";
        txtLinkedinId.Text = "";
    }
    #endregion ClearControls

    #region FillControls
    private void FillControls(SqlInt32 ContactID)
    {
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(ContactID, Convert.ToInt32(Session["UserID"]));

        if (!entContact.CountryID.IsNull)
        {
            ddlCountryID.SelectedValue = entContact.CountryID.ToString();
            FillDropDownStateByCountryID(Convert.ToInt32(ddlCountryID.SelectedValue));
        }
           

        if (!entContact.StateID.IsNull)
        {
            ddlStateID.SelectedValue = entContact.StateID.ToString();
            FillDropDownCityByStateID(Convert.ToInt32(ddlStateID.SelectedValue));
        }
            

        if (!entContact.CityID .IsNull)
            ddlCityID.SelectedValue = entContact.CityID.ToString();

        //if (!entContact.ContactCategoryID.IsNull)
        //    ddlContactCategoryID.SelectedValue = entContact.ContactCategoryID.ToString();

        if (!entContact.ContactName.IsNull)
            txtContactName.Text = entContact.ContactName.ToString();

        if (!entContact.ContactNumber.IsNull)
            txtContactNumber.Text = entContact.ContactNumber.ToString();

        if (!entContact.WhatsappNumber.IsNull)
            txtWhatsappNumber.Text = entContact.WhatsappNumber.ToString();

        if (!entContact.Email.IsNull)
            txtEmail.Text = entContact.Email.ToString();

        if (!entContact.BirthDate.IsNull)
            txtBirthdate.Text = entContact.BirthDate.ToString();

        if (!entContact.Address.IsNull)
            txtAddress.Text = entContact.Address.ToString();

        if (!entContact.Age.IsNull)
            txtAge.Text = entContact.Age.ToString();

        if (!entContact.BloodGroup.IsNull)
            txtBloodGroup.Text = entContact.BloodGroup.ToString();
        if (!entContact.FacebookID.IsNull)
            txtFaceBookId.Text = entContact.FacebookID.ToString();
        if (!entContact.LinkedinID.IsNull)
            txtLinkedinId.Text = entContact.LinkedinID.ToString();
        if(!entContact.ContactImageFilePath.IsNull)
            hfFilePath.Value = entContact.ContactImageFilePath.ToString();

        ContactWiseContactCategoryBAL ContactWiseContactCategory = new ContactWiseContactCategoryBAL();
        //SqlDataReader objSDR = ContactWiseContactCategory.SelectByContactID(Convert.ToInt32(Request.QueryString["ContactID"]));
        DataTable dt = new DataTable();
        dt = ContactWiseContactCategory.SelectByContactID(Convert.ToInt32(Request.QueryString["ContactID"]));
        foreach (DataRow dr in dt.Rows)
        {
            foreach(ListItem liContectCategory in cblContactCategoryID.Items)
            {
                if(liContectCategory.Value == dr["ContactCategoryID"].ToString() )
                {
                    liContectCategory.Selected= true;
                }
            }
        }


    }
    #endregion FillControls
}