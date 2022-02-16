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
                <asp:HyperLink runat="server" ID="btnAddCountry" NavigateUrl="~/AdminPanel/FileUpload/ContactWithFileAddEdit.aspx" CssClass="btn btn-danger">
                    <i class="fas fa-plus"></i>
                    Add Contact
                </asp:HyperLink>
            </div>
        </div>
        <div class="scrollmanu">
            <asp:GridView ID="gvContact" runat="server" CssClass="" RowStyle-Wrap="false" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ContactId" HeaderText="Id" />
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgImage" CssClass="img-fluid" AlternateText="Image dosen't upload or found!" Height="50" ImageUrl='<%# Eval("FilePath") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete Image">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDeleteImg" CssClass="btn btn-danger" CommandName="DeleteImage" CommandArgument='<%# Eval("ContactID").ToString() %>'>
                             <i class="fas fa-trash-alt"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>

