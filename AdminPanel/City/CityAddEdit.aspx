<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook3Tier.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-success">
        <h2 class="text-center text-white"><strong>City AddEdit Page</strong></h2>
    </div>
    <table class="table table-secondary">
        <tr>
            <td>Select State</td>
            <td>:</td>
            <td><asp:DropDownList runat="server" ID="ddlStateId" CssClass="form-select"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Enter CityName</td>
            <td>:</td>
            <td><asp:TextBox runat="server" ID="txtCityName" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Enter STDCode</td>
            <td>:</td>
            <td><asp:TextBox runat="server" ID="txtStdCode" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Enter PinCode</td>
            <td>:</td>
            <td><asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>           
            <td colspan="3" class="text-center"><asp:Button runat="server" text="Save" ID="btnSave" CssClass="btn btn-danger" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnCancle" Text="Cancle" CssClass="btn btn-info" OnClick="btnCancle_Click" /></td>       
        </tr>
        <tr>           
            <td colspan="3" class="text-center"><asp:Label runat="server" EnableViewState="false" ID="lblMessage"></asp:Label></td>       
        </tr>
    </table>
</asp:Content>

