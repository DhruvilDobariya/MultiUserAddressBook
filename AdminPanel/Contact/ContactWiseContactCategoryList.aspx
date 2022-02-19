<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactWiseContactCategoryList.aspx.cs" Inherits="AdminPanel_Contact_ContactWiseContactCategoryList" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container border my-4 p-4">
        <div class="row mb-2">
            <div class="col-md-6">
                <h2>
                    <i class="fas fa-user"></i>
                    Contact Wise Contact Category
                </h2>
            </div>
            <div class="col-md-6 d-flex justify-content-center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        <div class="scrollmanu">
            <asp:GridView ID="gvContactWiseContactCategory" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ContactWiseContactCategoryID" HeaderText="Id"/>
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category"/>
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>

