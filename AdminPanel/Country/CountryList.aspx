<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.Country.CountryList" %>
<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container border my-3 p-4">
        <div class="row mb-2">
            <div class="col-md-4">
                <h2>
                    <i class="fas fa-globe-americas"></i>
                    Country
                </h2>
            </div>
            <div class="col-md-4 d-flex justify-content-center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-md-4 d-flex justify-content-end p-2">
                <asp:HyperLink runat="server" ID="btnAddCountry" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" CssClass="btn btn-danger" >
                    <i class="fas fa-plus"></i>
                    Add Country
                </asp:HyperLink>
            </div>
        </div>
        <asp:GridView ID="gvCountry" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlEdit" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString().Trim() %>' CssClass="btn btn-gradient">
                            <i class="fas fa-edit"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>'>
                            <i class="fas fa-trash-alt"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CountryID" HeaderText="Id"/>
                <asp:BoundField DataField="CountryName" HeaderText="Name"/>
                <asp:BoundField DataField="CountryCode" HeaderText="Code"/>
                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

