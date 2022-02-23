<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login" %>

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
    <style>
    	html, body {
    		height: 100%;
    		background-color: white;
    	}
    </style>
</head>
<body class="d-flex justify-content-center align-items-center">
    <form id="form1" runat="server">
        <div class="box">
		<main class="form-signin m-3 p-3 pt-5">
			<form class="p-3">
                <div class="d-flex justify-content-center">
					<img class="mb-4" src="./Content/image/favicon.png" alt="" width="72" height="72">
				</div>
				<div class="d-flex justify-content-center">
					<h1 class="h3 fw-normal">Welcome</h1>
				</div>
				<div class="d-flex justify-content-center">
					<p>Sign in with your id</p>
				</div>
				<div class="form-floating">
					<asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="name@example.com"></asp:TextBox>
					<label for="floatingInput">Username</label>
					<asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Please Enter Username" ControlToValidate="txtUserName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
				
				<div class="form-floating">
					<asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
					<label for="floatingPassword">Password</label>
					<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please Enter Password" ControlToValidate="txtPassword" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
				
				<asp:Button runat="server" ID="btnSubmit" CssClass="w-100 btn btn-danger btn-lg my-3" Text="Sign in" OnClick="btnSubmit_Click"/>
				<div class="">
					<asp:HyperLink runat="server" ID="hlSignup" CssClass="link mb-5" NavigateUrl="~/Signup">Sign Up</asp:HyperLink>
				</div>
				<div class="text-center">
					<asp:Label runat="server" ID="lblMsg" CssClass="text-danger"></asp:Label>
					<asp:ValidationSummary ID="vsSignUp" runat="server" DisplayMode="List" ForeColor="Red" />

				</div>
			</form>
		</main>
	</div>
    </form>
    <script src="/Content/js/bootstrap.bundle.min.js" type="text/javascript"></script>
    <script src="/Content/js/all.min.js" type="text/javascript"></script>
</body>
</html>