<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container border my-4 p-4">
        <div class="row mb-2">
            <div class="col-md-4">
                <h2>
                    <i class="fas fa-flag-checkered"></i>
                    State
                </h2>
            </div>
            <div class="col-md-4 d-flex justify-content-center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-md-4 d-flex justify-content-end p-2">
                <asp:HyperLink runat="server" ID="btnAddCountry" NavigateUrl="~/AdminPanel/State/Add" CssClass="btn btn-danger">
                    <i class="fas fa-plus"></i>
                    Add State
                </asp:HyperLink>
            </div>
        </div>
        <asp:GridView ID="gvState" runat="server" CssClass="" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hyEdit" NavigateUrl='<%# "~/AdminPanel/State/Edit/" + Eval("StateID").ToString().Trim() %>' CssClass="btn btn-gradient">
                            <i class="fas fa-edit"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>'>
                             <i class="fas fa-trash-alt"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StateID" HeaderText="Id"/>
                <asp:BoundField DataField="StateName" HeaderText="Name"/>
                <asp:BoundField DataField="StateCode" HeaderText="Code"/>
                <asp:BoundField DataField="CountryName" HeaderText="Country"/>
                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

