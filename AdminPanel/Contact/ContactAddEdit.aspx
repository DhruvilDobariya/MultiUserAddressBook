<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContant" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container my-5 border p-4">
        <div>
            <h2>
                <asp:Label runat="server" ID="lblTitle">Add Contact</asp:Label>
            </h2>
        </div>
        <div class="mt-3">
            <form>
                <div>
                    <asp:Label runat="server" ID="lblContact" CssClass="form-lable m-1">Enter Contact Name</asp:Label>
                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control m-1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContact" runat="server" ErrorMessage="Please Enter Contact Name" ControlToValidate="txtContact" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblContactCategory" CssClass="form-lable m-1">Select Contact Category</asp:Label>
                        <asp:DropDownList ID="ddContactCategory" runat="server" CssClass="form-select"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCotactCategory" runat="server" ErrorMessage="Please Select Contact Category" ControlToValidate="ddContactCategory" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblCountry" CssClass="form-lable m-1">Select Country Name</asp:Label>
                        <asp:DropDownList ID="ddCountry" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddCountry_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Please Select Country" ControlToValidate="ddCountry" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblState" CssClass="form-lable m-1">Select State Name</asp:Label>
                        <asp:DropDownList ID="ddState" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddState_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddState" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblCity" CssClass="form-lable m-1">Select City Name</asp:Label>
                        <asp:DropDownList ID="ddCity" runat="server" CssClass="form-select"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Please Select City" ControlToValidate="ddCity" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblContactNo" CssClass="form-lable m-1">Enter Contact No</asp:Label>
                        <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control m-1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="Please Select Contact No" ControlToValidate="txtContactNo" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6">
                        <label class="form-lable m-1">Enter Whatsapp No</label>
                        <asp:TextBox ID="txtWhatsappNo" runat="server" CssClass="form-control m-1"></asp:TextBox>
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <label class="form-lable m-1">Enter Birth Date</label>
                        <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control m-1" TextMode="Date"></asp:TextBox>
                        <asp:CompareValidator ID="cvBirthDate" runat="server" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Enter valid Date of Birth" ForeColor="Red" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblEmail" CssClass="form-lable m-1">Enter Email</asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control m-1" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <label class="form-lable m-1">Enter Your Age</label>
                        <asp:TextBox ID="txtAge" runat="server" CssClass="form-control m-1" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-lable m-1">Enter Your Blood Group</label>
                        <asp:TextBox ID="txtBloodGroup" runat="server" CssClass="form-control m-1"></asp:TextBox>
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <label class="form-lable m-1">Enter Fecebook ID</label>
                        <asp:TextBox ID="txtFecebook" runat="server" CssClass="form-control m-1" TextMode="Url"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-lable m-1">Enter Linkedin ID</label>
                        <asp:TextBox ID="txtLinkedin" runat="server" CssClass="form-control m-1" TextMode="Url"></asp:TextBox>
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6 pe-4">
                        <asp:Label runat="server" ID="lblAddress" CssClass="form-lable m-1">Enter Your Address</asp:Label>
                        <asp:TextBox ID="txtAddress" CssClass="form-control m-1 ms-3 me-4" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please Enter Address" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblFile" CssClass="form-lable m-1">Enter Document</asp:Label>
                        <asp:FileUpload runat="server" ID="fuFile" CssClass="form-control m-1 ms-3 me-4"/>
                    </div>
                </div>

                <div>
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success mx-1 my-2" Text="Add" OnClick="btnSubmit_Click" />
                    <asp:HyperLink runat="server" ID="btnBack" CssClass="btn btn-dark mx-1 my-2" NavigateUrl="~/AdminPanel/Contact/ContactList.aspx">Back</asp:HyperLink>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </form>
        </div>
    </div>
</asp:Content>