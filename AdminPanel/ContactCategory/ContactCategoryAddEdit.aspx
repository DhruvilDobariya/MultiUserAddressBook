<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContant" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container mt-5 border p-4">
        <div>
            <h2>
                <asp:Label runat="server" ID="lblTitle">Add Contact Category</asp:Label>
            </h2>
        </div>
        <div class="mt-3">
            <form>
                <div>
                    <label class="form-lable m-1">Enter Contact Category Name</label>
                    <asp:TextBox ID="txtContactCategory" CssClass="form-control m-1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContactCategory" runat="server" ErrorMessage="Please Enter Contact Category" ControlToValidate="txtContactCategory" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success mx-1 my-2" Text="Add" OnClick="btnSubmit_Click" />
                    <asp:HyperLink runat="server" ID="btnBack" CssClass="btn btn-dark mx-1 my-2" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryList.aspx">Back</asp:HyperLink>
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                </div>
            </form>
        </div>

    </div>
</asp:Content>

