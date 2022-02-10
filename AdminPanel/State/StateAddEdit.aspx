<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="StateAddEdit.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.State.StateAddEdit" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContant" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container mt-5 border p-4">
        <div>
            <h2>
                <asp:Label runat="server" ID="lblTitle">Add State</asp:Label>
            </h2>
        </div>
        <div class="mt-3">
            <form>
                <div>
                    <label class="form-lable m-1">Enter State Name</label>
                    <asp:TextBox ID="txtState" runat="server" CssClass="form-control m-1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please Enter State" ControlToValidate="txtState" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label class="form-lable m-1">Enter State Code</label>
                    <asp:TextBox ID="txtCode" runat="server" CssClass="form-control m-1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCode" runat="server" ErrorMessage="Please Enter State Code" ControlToValidate="txtCode" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label class="form-lable m-1">Select Country Name</label>
                    <asp:DropDownList ID="ddCountry" runat="server" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Please Select Country" ControlToValidate="ddCountry" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success mx-1 my-2" Text="Add" OnClick="btnSubmit_Click" />
                    <asp:HyperLink runat="server" ID="btnBack" CssClass="btn btn-dark mx-1 my-2" NavigateUrl="~/AdminPanel/State/StateList.aspx">Back</asp:HyperLink>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </form>
        </div>

    </div>
</asp:Content>
