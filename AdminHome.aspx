<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="EMSystem.AdminHome1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

</asp:Content>
