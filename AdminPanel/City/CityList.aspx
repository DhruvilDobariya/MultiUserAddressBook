<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container border my-4 p-4">
        <div class="row mb-2">
            <div class="col-md-4">
                <h2>
                    <i class="fas fa-city"></i>
                    City
                </h2>
            </div>
            <div class="col-md-4 d-flex justify-content-center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-md-4 d-flex justify-content-end p-2">
                <asp:HyperLink runat="server" ID="btnAddCountry" NavigateUrl="~/AdminPanel/City/Add" CssClass="btn btn-danger">
                    <i class="fas fa-plus"></i>
                    Add City
                </asp:HyperLink>
            </div>
        </div>
        <asp:GridView ID="gvCity" runat="server" CssClass="" AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-gradient" NavigateUrl='<%# "~/AdminPanel/City/Edit/" + Eval("CityID").ToString().Trim() %>'>
                            <i class="fas fa-edit"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>'>
                             <i class="fas fa-trash-alt"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CityID" HeaderText="Id" />
                <asp:BoundField DataField="CityName" HeaderText="Name" />
                <asp:BoundField DataField="PinCode" HeaderText="Pin Code" />
                <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                <asp:BoundField DataField="StateName" HeaderText="State"/>
                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>