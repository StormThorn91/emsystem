<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMSystem.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <div class="login-page">
        <div class="logo">
            <center>
            <img src="dlsudlogo.png" />
            </center>
        </div>
        <div class="form">
            <form class="login-form">
                <input type="text" name="user" placeholder="username" required/>
                <input type="password" name="pass" placeholder="password" required/>
                <button runat="server" onserverclick="btnLogin_Click">login</button>
                <p class="message">Not registered? <a href="Register.aspx">Create an account</a></p>
            </form>
        </div>
    </div>
</asp:Content>
