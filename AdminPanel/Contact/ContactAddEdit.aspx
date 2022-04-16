<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook3Tier.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-secondary">
        <h2 class="text-center text-white"><strong>Contact AddEdit Page</strong></h2>
    </div>
    
    <table class="table table-secondary">   
        <tr>
            <td colspan="4" class="text-center"><asp:Label runat="server" ID="lblMessage"></asp:Label></td>

        </tr>
        <tr>
            <td class="text-center"><h5>Select Country</h5></td>
            <td><h5>:</h5></td>
            <td><asp:DropDownList runat="server" ID="ddlCountryID" EnableViewState="true" AutoPostBack="true"  CssClass="form-select" OnSelectedIndexChanged="ddlCountryList_SelectedIndexChanged"></asp:DropDownList></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center"><h5>Select State</h5></td>
            <td><h5>:</h5></td>
            <td><asp:DropDownList runat="server" ID="ddlStateID" AutoPostBack="true"  CssClass="form-select" OnSelectedIndexChanged="ddlStateList_SelectedIndexChanged"></asp:DropDownList></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center"><h5>Select City</h5></td>
            <td><h5>:</h5></td>
            <td><asp:DropDownList runat="server" ID="ddlCityID"  CssClass="form-select"></asp:DropDownList></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center"><h5>Select ContactCategoryId</h5></td>
            <td><h5>:</h5></td>
            <%--<td><asp:DropDownList runat="server" ID="ddlContactCategoryID" CssClass="form-select"></asp:DropDownList></td>--%>
            <td>
                <asp:CheckBoxList ID="cblContactCategoryID" runat="server"></asp:CheckBoxList>
            </td>
            <td>
                &nbsp;</td>

        </tr>
        <tr>
            <td class="text-center"><h5>Enter ContactName</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtContactName"  CssClass="form-control"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center"><h5>UploadImage</h5></td>
            <td><h5>:</h5></td>
            <td><asp:FileUpload runat="server" ID="fuContactImage" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Contact Number</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtContactNumber" CssClass="form-control" ></asp:TextBox></td>
            <td>
&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Whatsapp Number</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtWhatsappNumber" CssClass="form-control" ></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter BirthDate</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtBirthdate" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Email</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Age</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtAge" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Address</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter BloodGroup</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter LinkedinId</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtLinkedinId" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter FaceBookId</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtFaceBookId" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3" class="text-center"><asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-danger" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnCancle" Text="Cancle" CssClass="btn btn-info" OnClick="btnCancle_Click"/> </td>
        </tr>
     
    </table>
    <asp:HiddenField ID="hfFilePath" runat="server" />
</asp:Content>

