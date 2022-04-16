<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook3Tier.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-success">
        <h2 class="text-center text-white"><strong>CityList SelectAll</strong></h2>
    </div>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>

    <asp:GridView runat="server" ID="gvCityList" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvCityList_RowCommand">
        <Columns >
            <asp:BoundField DataField="CityID" HeaderText="#" />
            <asp:BoundField DataField="CityName" HeaderText="City" />
            <asp:BoundField DataField="StateName" HeaderText="State" />
            <asp:BoundField DataField="CountryName" HeaderText="Country" />
            <asp:BoundField DataField="STDCode" HeaderText="STD" />
            <asp:BoundField DataField="PinCode" HeaderText="PIN" />

            <asp:TemplateField HeaderText="DELETE">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>' CssClass="btn btn-danger"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="EDIT">
                <ItemTemplate>
                    <asp:HyperLink ID="btnEdit" runat="server" text="Edit" CssClass="btn btn-info" NavigateUrl='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID="+Eval("CityID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

