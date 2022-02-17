<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContant" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container mt-5 border p-4">
        <div>
            <h2>
                <asp:Label runat="server" ID="lblTitle">Add Country</asp:Label>
            </h2>
        </div>
        <div class="mt-3">
            <form>
                <div>
                    <label class="form-lable m-1">Enter Country Name</label>
                    <asp:TextBox ID="txtCountry" runat="server" class="form-control m-1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Please Enter Country" ControlToValidate="txtCountry" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label class="form-lable m-1">Enter Country Code</label>
                    <asp:TextBox ID="txtCode" runat="server" class="form-control m-1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCode" runat="server" ErrorMessage="Please Enter Country Code" ControlToValidate="txtCode" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success mx-1 my-2" Text="Add" OnClick="btnSubmit_Click" />
                    <asp:HyperLink runat="server" ID="btnBack" CssClass="btn btn-dark mx-1 my-2" NavigateUrl="~/AdminPanel/Country/CountryList.aspx">Back</asp:HyperLink>
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                </div>
            </form>
        </div>

    </div>
</asp:Content>

