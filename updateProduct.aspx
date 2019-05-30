<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="updateProduct.aspx.cs" Inherits="EMSystem.updateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
             <h2>EDIT ITEM</h2>
         </center>
     <div class="form">
         <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        <form>
            <input type="text" id="prodID" runat="server" placeholder="Product ID" readonly/>
            <input type="text" id="prodTitle" runat="server" placeholder="Title" readonly />
            <h3>Product Available?</h3>
            <select name="opt" id="opt" runat="server" required>
                <option>YES</option>
                <option>NO</option>
            </select>
            <button runat="server" id="btnSubmit" onserverclick="btnSubmit_Click">Submit</button>
            <button runat="server" id="btnBack" onserverclick="btnBack_ServerClick">Back</button>
            </form>
        </div>
</asp:Content>
