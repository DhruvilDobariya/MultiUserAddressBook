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
                <div class="row">
                    <asp:Label runat="server" ID="lblContact" CssClass="form-lable m-1">Enter Contact Name<span class="text-danger">*</span></asp:Label>
                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control m-1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContact" runat="server" ErrorMessage="Please Enter Contact Name" ControlToValidate="txtContact" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblContactCategory" CssClass="form-lable m-1">Select Contact Category<span class="text-danger">*</span></asp:Label>
                        <asp:CheckBoxList ID="chkContactCategory" runat="server" CssClass="form-check mt-2"></asp:CheckBoxList>
                    </div>

                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblCountry" CssClass="form-lable m-1">Select Country Name<span class="text-danger">*</span></asp:Label>
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddCountry_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Please Select Country" ControlToValidate="ddlCountry" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblState" CssClass="form-lable m-1">Select State Name<span class="text-danger">*</span></asp:Label>
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddState_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please Select State" ControlToValidate="ddlState" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblCity" CssClass="form-lable m-1">Select City Name<span class="text-danger">*</span></asp:Label>
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-select"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Please Select City" ControlToValidate="ddlCity" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblContactNo" CssClass="form-lable m-1">Enter Contact No<span class="text-danger">*</span></asp:Label>
                        <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control m-1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="Please Select Contact No" ControlToValidate="txtContactNo" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Please Enter Valid Contact No" ControlToValidate="txtContactNo" ForeColor="Red" Display="Dynamic" ValidationExpression="^([1-9]{1})([234789]{1})([0-9]{8})$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-md-6">
                        <label class="form-lable m-1">Enter Whatsapp No</label>
                        <asp:TextBox ID="txtWhatsappNo" runat="server" CssClass="form-control m-1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revWhatsappNo" runat="server" ErrorMessage="Please Enter Valid Whatsapp No" ControlToValidate="txtWhatsappNo" ForeColor="Red" Display="Dynamic" ValidationExpression="^([1-9]{1})([234789]{1})([0-9]{8})$"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6">
                        <label class="form-lable m-1">Enter Birth Date</label>
                        <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control m-1" TextMode="Date"></asp:TextBox>
                        <asp:CompareValidator ID="cvBirthDate" runat="server" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Enter valid Date of Birth" ForeColor="Red" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblEmail" CssClass="form-lable m-1">Enter Email<span class="text-danger">*</span></asp:Label>
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
                    <div class="col-md-12 pe-3 ps-2">
                        <asp:Label runat="server" ID="lblAddress" CssClass="form-lable m-1 ps-1">Enter Your Address<span class="text-danger">*</span></asp:Label>
                        <asp:TextBox ID="txtAddress" CssClass="form-control m-1 ms-2 me-4" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please Enter Address" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row mt-2">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblFile" onchange="fuFileChenge" CssClass="form-lable m-1">Enter Document</asp:Label>
                        <asp:FileUpload runat="server" ID="fuFile" onChange="uploadImage()" CssClass="form-control m-1" />
                    </div>
                    <div class="col-md-6 text-center">
                        <asp:Image ID="imgImage" CssClass="border border-4 rounded-circle" Visible="false" runat="server" Width="100" />
                    </div>
                </div>

                <div>
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-gradient mx-1 my-2" Text="Add" OnClick="btnSubmit_Click" />
                    <asp:HyperLink runat="server" ID="btnBack" CssClass="btn btn-danger mx-1 my-2" NavigateUrl="~/AdminPanel/Contact/List">Back</asp:HyperLink>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </form>
        </div>
    </div>
</asp:Content>


