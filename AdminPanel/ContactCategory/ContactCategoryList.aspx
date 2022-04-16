<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook3Tier.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-warning">
        <h2 class="text-center text-white"><strong>ContactCategoryList SelectAll</strong></h2>
    </div>
    <asp:Label runat="server" ID="lblMessage"></asp:Label>
    <asp:GridView ID="gvContactCategoryList" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvContactCategoryList_RowCommand">
        <Columns>
            <asp:BoundField DataField="ContactCategoryID" HeaderText="#"/>
            <asp:BoundField DataField="ContactCategoryName" HeaderText="Name"/>
            <asp:TemplateField HeaderText="DELETE">
                <ItemTemplate >
                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID") %>' CssClass="btn btn-danger"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EDIT">
                <ItemTemplate >
                    <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-info" NavigateUrl='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID="+Eval("ContactCategoryID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

