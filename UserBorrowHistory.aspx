<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="UserBorrowHistory.aspx.cs" Inherits="EMSystem.UserBorrowHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <center>
                <h2>Borrow History</h2>
                <br />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <br /><br />
            </center>
        </div>
</asp:Content>
