<%@ Page Title="Customer Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="CustomerLibrary.WebForms.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <asp:Label Text="First Name" runat="server"></asp:Label>
        <asp:TextBox ID="firstName" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "firstName" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{0,50}$" ForeColor="Red" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
    </div>

        <div class="form-group">
        <asp:Label Text="Last Name" runat="server"></asp:Label>
        <asp:TextBox ID="lastName" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "lastName" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{0,50}$" ForeColor="Red" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>

              <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ErrorMessage="Last Name cannot be blank" ControlToValidate="lastName" ForeColor="Red"></asp:RequiredFieldValidator>  
    </div>

        <div class="form-group">
        <asp:Label Text="Phone Number" runat="server"></asp:Label>
        <asp:TextBox ID="phoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhoneNumber" runat="server" ControlToValidate="phoneNumber" ErrorMessage="Enter proper phone number format" ForeColor="Red" ValidationExpression="\+[1-9]\d{10,12}"></asp:RegularExpressionValidator> 
            
    </div>

        <div class="form-group">
        <asp:Label Text="Email" runat="server"></asp:Label>
        <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="email" ErrorMessage="Enter proper email format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> 
    </div>

        <div class="form-group">
        <asp:Label Text="Total Purchases Amount" runat="server"></asp:Label>
        <asp:TextBox ID="totalPurchasesAmount" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorAmount" runat="server" ControlToValidate="totalPurchasesAmount" ErrorMessage="Only numeric allowed" ForeColor="Red" ValidationExpression="^[0-9]*[,][0-9]*$"></asp:RegularExpressionValidator> 

    </div>

    <asp:Button CssClass="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave" />
</asp:Content>
