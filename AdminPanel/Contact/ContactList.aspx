<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook3Tier.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-secondary">
        <h2 class="text-center text-white"><strong>ContactList SelectAll</strong></h2>
    </div>
    <asp:Label runat="server" ID="lblMessage"></asp:Label>

    <asp:GridView runat="server" ID="gvContactList" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvContactList_RowCommand">
         <Columns>
                 <asp:BoundField HeaderText="#" DataField="ContactID" />
                 <asp:BoundField HeaderText="Country" DataField="CountryName" />
                 <asp:BoundField HeaderText="State" DataField="StateName" />
                 <asp:BoundField HeaderText="City" DataField="CityName" />
                 <%--<asp:BoundField HeaderText="ContactCategory" DataField="ContactCategoryName"  /> --%>

             <asp:TemplateField HeaderText="DELETE">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnDelete" CssClass ="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID") %>' Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EDIT">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="btnEdit" CssClass ="btn btn-info btn-sm" Text="Edit"  NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID="+Eval("ContactID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="IMG">
                 <ItemTemplate>
                     <asp:Image ID="imgContactImage" runat="server" ImageUrl='<%# Eval("ContactImageFilePath") %>' AlternateText="Not Found" Width="150"/>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Images AllAttributes " >
                 <ItemTemplate >
                     
                     <asp:Label ID="Label1" runat="server" Text='<% # "Size : " + Eval("FileSize") + " <br> " + "Extension : " + Eval("Extension") %>'></asp:Label><hr>
                     <asp:Label ID="Label2" runat="server" Text='<% # "Width : " + Eval("Width") + "<br>" + "Height : " + Eval("Height")  %>'></asp:Label><hr />
                     

                 </ItemTemplate>
                 
             </asp:TemplateField>

                 <asp:BoundField HeaderText="Name" DataField="ContactName" />
                 <asp:BoundField HeaderText="Number" DataField="ContactNumber" />
                 <asp:BoundField HeaderText="Whtsapp" DataField="WhatsAppNumber" />
                 <asp:BoundField HeaderText="BDate" DataField="BirthDate" />
                 <asp:BoundField HeaderText="E-mail" DataField="Email" />
                 <asp:BoundField HeaderText="Age" DataField="Age" />
                 <asp:BoundField HeaderText="Address" DataField="Address" />
                <%--<asp:BoundField HeaderText="Creation Date" DataField="CreationDate" />--%>

            
        </Columns>
    </asp:GridView>
</asp:Content>

