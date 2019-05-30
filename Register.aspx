<%@ Page Title="" Language="C#" MasterPageFile="~/Register.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EMSystem.Register1" %>

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
            <form class="register-form">
                <input type="text" name="name" placeholder="full name" required/>
                <input type="text" name="sid" pattern="[1234567890]{9}" title="only 9 digit numbers are accepted" placeholder="student number" required/>
                <input type="text" name="username" placeholder="username" required/>
                <input type="password" name="pass" placeholder="password" required/>
                <input type="email" name="email" placeholder="email address" required/>
                Birthdate: <input type="date" name="birthdate" required/>
                <input type="number" placeholder="mobile number" name="mobileNum" required/>
                <asp:Button ID="Button1" runat="server" BackColor="#009900" OnClick="btnCreate_Click" Text="create" />
                <p class="message">Already registered? <a href="Login.aspx">Sign In</a></p>
            </form>
        </div>
    </div>
</asp:Content>
