<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="EMSystem.UserHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="/bootstrap/4.0.0/css/bootstrap.min.css">
    <link href="userCSS.css" rel="stylesheet" />
    <link href="style.css" rel="stylesheet" />
    <script src="userJS.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            <center>
                <h2>All EMS Item/s</h2>
                <br />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <br /><br />
                <h2>Type Product ID to borrow: </h2>
                &nbsp;<input type="text" id="borrow" name="borrow" runat="server" class="form-control" style="height:45px; width:378px"/>
                <button runat="server" class="btn btn-success" onserverclick="btnBorrow_Click">Borrow</button>
            </center>
        </div>
    

</asp:Content>
