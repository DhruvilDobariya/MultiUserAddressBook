<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactWithFileList.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.FileUpload.ContactWithFileList" %>
<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="my-4 p-4">
        <div class="row mb-2">
            <div class="col-md-4">
                <h2>
                    <i class="fas fa-user"></i>
                    Contact
                </h2>
            </div>
            <div class="col-md-4 d-flex justify-content-center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-md-4 d-flex justify-content-end p-2">
                <asp:HyperLink runat="server" ID="btnAddCountry" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx" CssClass="btn btn-danger">
                    <i class="fas fa-plus"></i>
                    Add Contact
                </asp:HyperLink>
            </div>
        </div>
        <div class="scrollmanu">
            <asp:GridView ID="gvContact" runat="server" CssClass="" RowStyle-Wrap="false" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString().Trim() %>' CssClass="btn btn-gradient">
                            <i class="fas fa-edit"></i>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>'>
                             <i class="fas fa-trash-alt"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ContactId" HeaderText="Id" />
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category" />
                    <asp:BoundField DataField="CityName" HeaderText="City Name" />
                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                    <asp:BoundField DataField="WhatsappNo" HeaderText="Whatsapp No" />
                    <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" />
                    <asp:BoundField DataField="Email" HeaderText="Email Id" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                    <asp:BoundField DataField="FacebookID" HeaderText="Facebook Id" />
                    <asp:BoundField DataField="LinkedinID" HeaderText="Linkedin Id" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>

