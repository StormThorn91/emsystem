<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ChangeAccDetails.aspx.cs" Inherits="EMSystem.ChangeAccDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <form>
            <input type="text" id="name" runat="server" placeholder="full name" required/>
            <input type="text" id="studnum" runat="server" placeholder="student number" required />
        <input type="text" id="birthdate" runat="server" placeholder="birthdate" required />
        <input type="text" id="mobileNum" name="mobileNum" runat="server" pattern="[1234567890]{11}" title="11 Digit Mobile Number please" placeholder="mobile number" required />
        <input type="text" id="email" name="email" runat="server" placeholder="Email" required />
            <button runat="server" onserverclick="btnSubmit_Click">Submit</button>
            </form>
        </div>
</asp:Content>
