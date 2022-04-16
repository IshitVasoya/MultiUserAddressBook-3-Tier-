<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook3Tier.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-primary">
        <h2 class="text-center text-white"><strong>State AddEdit Page</strong></h2>
    </div>
    <table class="table table-secondary">
        <tr>
            <td>Select Country</td>
            <td>:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCountryId" CssClass="form-select"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Enter StateName</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Enter StateCode</td>
            <td>:</td>
            <td>
                <asp:TextBox runat="server" ID="txtStateCode" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>           
            <td colspan="3" class="text-center"><asp:Button runat="server" id="btnSave" CssClass="btn btn-danger" Text="Save" OnClick="btnSave_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnCancle" Text="Cancle" CssClass="btn btn-info" OnClick="btnCancle_Click"  /></td>       
        </tr>
        <tr>           
            <td colspan="3" class="text-center" ><asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label></td>       
        </tr>

    </table>
</asp:Content>

