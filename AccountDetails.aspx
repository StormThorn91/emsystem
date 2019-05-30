<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="EMSystem.AccountDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="logo">
            <center>
            <img src="placeholder.png" />
            </center>
        </div>
        <div class="form">
            <p><h1 id="name" runat="server">CAITLIN SISTOSO</h1></p>
            <p id="sid" runat="server">201512345</p>
            <p id="mobileNum" runat="server">(+63) 914 456 5462</p>
            <p id="birthdate" runat="server">10/12/1999</p>
            <a id="email" runat="server">kitlinsistoso@gmail.com</a>
            <button runat="server" onserverclick="btnChangeDeets_Click">CHANGE DETAILS</button>
        </div>
    </div>

    <script>
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').trigger('focus')
        })
    </script>

</asp:Content>
