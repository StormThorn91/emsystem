<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AddProduct.aspx.cs" Inherits="EMSystem.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
             <h2>ADD ITEM</h2>
         </center>
    <div class="form">
        <form>
            <input type="text" id="prodID" runat="server" placeholder="Product ID" required/>
            <input type="text" id="prodTitle" runat="server" placeholder="Title" required />
            <button runat="server" onserverclick="btnSubmit_Click">Submit</button>
            </form>
        </div>
</asp:Content>
