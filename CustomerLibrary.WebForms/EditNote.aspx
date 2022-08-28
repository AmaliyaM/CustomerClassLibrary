<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditNote.aspx.cs" Inherits="CustomerLibrary.WebForms.EditNote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="form-group">
        <asp:Label Text="Enter note" runat="server"></asp:Label>
        <asp:TextBox ID="noteLine" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "noteLine" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{0,50}$" ForeColor="Red" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
       <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstLine" runat="server" ErrorMessage="Line cannot be blank" ControlToValidate="noteLine" ForeColor="Red"></asp:RequiredFieldValidator>  
      </div>
    <asp:Button CssClass="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave" />
</asp:Content>
