<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="EMSystem.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            <center>
                <h2>All EMS Item/s</h2>
                <br />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <br /><br />
                <h2>Type Product ID to delete: </h2>
                
                <button runat="server" class="btn btn-success" onserverclick="btnAdd_Click">Add</button>
                &nbsp;<input type="text" id="edit" name="edit" placeholder="Enter Product ID to EDIT here" runat="server" class="form-control" style="height:45px; width:378px"/>
                 <button runat="server" class="btn btn-success" onserverclick="btnEdit_Click">Edit</button>
                &nbsp;<input type="text" id="delete" name="delete" placeholder="Enter Product ID to DELETE here" runat="server" class="form-control" style="height:45px; width:378px"/>
                <button runat="server" id="delbtn" class="btn btn-success" onserverclick="btnDelete_Click">Delete</button>
            </center>
        </div>


</asp:Content>
