<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="Return.aspx.cs" Inherits="EMSystem.Borrow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    <div>
            <center>
                <h2>Return Borrowed Item/s</h2>
                <br />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <br /><br />
                <h2>Type Product ID to RETURN: </h2>
                &nbsp;<input type="text" id="ret" runat="server" class="form-control" style="height:45px; width:378px"/>
                <button runat="server" class="btn btn-success" onserverclick="btnReturn_Click">Return</button>
            </center>
        </div>
</asp:Content>
