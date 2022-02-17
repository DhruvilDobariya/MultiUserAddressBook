<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContant" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container mt-5 border p-4">
        <div>
            <h2>
                <asp:Label runat="server" ID="lblTitle">Add City</asp:Label>
            </h2>
        </div>
        <div class="mt-3">
            <form>
                <div>
                    <label class="form-lable m-1">Enter City Name</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control m-1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Please Enter City" ControlToValidate="txtCity" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label class="form-lable m-1">Select State Name</label>
                    <asp:DropDownList ID="ddState" runat="server" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddState" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
                 <div>
                    <label class="form-lable m-1">Enter Pin Name</label>
                    <asp:TextBox ID="txtPin" runat="server" CssClass="form-control m-1"></asp:TextBox>
                </div>
                <div>
                    <label class="form-lable m-1">Enter STD Name</label>
                    <asp:TextBox ID="txtSTD" runat="server" CssClass="form-control m-1"></asp:TextBox>
                </div>
                <div>
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success mx-1 my-2" Text="Add" OnClick="btnSubmit_Click" />
                    <asp:HyperLink runat="server" ID="btnBack" CssClass="btn btn-dark mx-1 my-2" NavigateUrl="~/AdminPanel/City/CityList.aspx">Back</asp:HyperLink>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </form>
        </div>

    </div>
</asp:Content>

