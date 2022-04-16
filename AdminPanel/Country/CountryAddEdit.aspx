<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook3Tier.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-danger">
        <h2 class="text-center text-white"><strong>Country AddEdit Page</strong></h2>
    </div>
    <div class="col-md-12">
        <table class="table table-secondary">
            <tr>
                <td>
                    <h6>Enter CountryName</h6>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <h6>Enter CountryCode</h6>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" class="text-center">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-danger" OnClick="btnSave_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnCancle" Text="Cancle" CssClass="btn btn-info" OnClick="btnCancle_Click" /></td>

            </tr>
            <tr>
                <td colspan="3" class="text-center">
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>

