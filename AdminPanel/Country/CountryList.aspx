<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook3Tier.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-danger">
        <h2 class="text-center text-white"><strong>CountryList SelectAll</strong></h2>
    </div>

    <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>

    <asp:GridView runat="server" ID="gvCountryList" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvCountryList_RowCommand">
        <Columns>
            <asp:BoundField DataField="CountryID" HeaderText="#" />
            <asp:BoundField DataField="CountryName" HeaderText ="Name" />
            <asp:BoundField DataField="CountryCode" HeaderText="Code" />

            <asp:TemplateField HeaderText ="DELETE">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument='<% #Eval("CountryID") %>' CssClass="btn btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="EDIT">
                <ItemTemplate>
                    <asp:HyperLink ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-info" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID="+ Eval("CountryId") %>' /> 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        
    </asp:GridView>
</asp:Content>

