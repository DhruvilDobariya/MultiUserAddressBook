﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MultiUserAddressBook.Login" %>

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
					<input type="text" name="Username" class="form-control" id="floatingInput" placeholder="name@example.com">
					<label for="floatingInput">Username</label>
				</div>
				<div class="form-floating">
					<input type="password" name="Password" class="form-control" id="floatingPassword" placeholder="Password">
					<label for="floatingPassword">Password</label>
				</div>
				
				<a class="w-100 btn btn-lg btn-danger my-3" type="submit">Sign in</a>
				<div class="">
					<asp:HyperLink runat="server" ID="hlSignup" CssClass="link mb-5" NavigateUrl="~/Registrastion.aspx">Sign Up</asp:HyperLink>
				</div>
			</form>
		</main>
	</div>
    </form>
    <script src="/Content/js/bootstrap.bundle.min.js" type="text/javascript"></script>
    <script src="/Content/js/all.min.js" type="text/javascript"></script>
</body>
</html>