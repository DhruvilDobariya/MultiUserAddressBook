﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrastion.aspx.cs" Inherits="MultiUserAddressBook.Registrastion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" 
    content="initial-scale=1.0, maximum-scale=1.0, user-scalable=no, width=device-width">
    <title></title>

    <link rel="icon" type="image/x-icon" href="~/Content/image/favicon.png">
    <link href="~/Content/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="~/Content/css/all.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5 border p-4">
            <div>
                <h2>
                    <asp:Label runat="server" ID="lblTitle">Sign Up</asp:Label>
                </h2>
            </div>
            <div class="mt-3">
                <form>
                    <h4>User Information</h4>
                    <div>
                        <label class="form-lable m-1">Enter Your Name</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control m-1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please Enter Name" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <label class="form-lable m-1">Enter Mobile No</label>
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control m-1"></asp:TextBox>
                    </div>
                    <div>
                        <label class="form-lable m-1">Enter Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control m-1" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <h4 class="mt-3">Login Information</h4>
                    <div>
                        <label class="form-lable m-1">Enter Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control m-1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    <div>
                        <label class="form-lable m-1">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control m-1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please Enter Password" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <label class="form-lable m-1">Retype Password</label>
                        <asp:TextBox ID="txtRetypePassword" runat="server" CssClass="form-control m-1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRetypePassword" runat="server" ErrorMessage="Please Enter Retype Password" ControlToValidate="txtRetypePassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvRetypePassword" runat="server" ErrorMessage="Password and Retype Password Not Same" ControlToCompare="txtPassword" ControlToValidate="txtRetypePassword" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                    </div>
                    <div>
                        <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success mx-1 my-2" Text="Submit"/>
                        <asp:HyperLink runat="server" ID="btnBack" CssClass="btn btn-dark mx-1 my-2" NavigateUrl="~/Login.aspx">Back</asp:HyperLink>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </form>
</body>
</html>
