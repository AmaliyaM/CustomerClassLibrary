<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAddress.aspx.cs" Inherits="CustomerLibrary.WebForms.EditAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="form-group">
        <asp:Label Text="First Line" runat="server"></asp:Label>
        <asp:TextBox ID="firstLine" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "firstLine" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{0,100}$" ForeColor="Red" runat="server" ErrorMessage="Maximum 100 characters allowed."></asp:RegularExpressionValidator>
       <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstLine" runat="server" ErrorMessage="First Line cannot be blank" ControlToValidate="firstLine" ForeColor="Red"></asp:RequiredFieldValidator>  
      </div>

        <div class="form-group">
        <asp:Label Text="Second Line" runat="server"></asp:Label>
        <asp:TextBox ID="secondLine" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "secondLine" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{0,100}$" ForeColor="Red" runat="server" ErrorMessage="Maximum 100 characters allowed."></asp:RegularExpressionValidator>

           
    </div>

        <div class="form-group">
        <asp:Label Text="Address Type" runat="server"></asp:Label>
        <asp:TextBox ID="addressType" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorAddressType" runat="server" ControlToValidate="addressType" ErrorMessage="Only 'Shipping' or 'Billing'" ForeColor="Red" ValidationExpression="^(Shipping)|(Billing)$"></asp:RegularExpressionValidator> 
            
    </div>

        <div class="form-group">
        <asp:Label Text="City" runat="server"></asp:Label>
        <asp:TextBox ID="city" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "city" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{0,50}$" ForeColor="Red" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" ErrorMessage="City cannot be blank" ControlToValidate="city" ForeColor="Red"></asp:RequiredFieldValidator>  
        
    </div>

     <div class="form-group">
            <asp:Label Text="Postal Code" runat="server"></asp:Label>
            <asp:TextBox ID="postalCode" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorAmount" runat="server" ControlToValidate="postalCode" ErrorMessage="Only numeric allowed" ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator> 
            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "postalCode" ID="RegularExpressionValidator4" ValidationExpression = "^\d{6}$" ForeColor="Red" runat="server" ErrorMessage="Maximum 6 characters allowed."></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPostalCode" runat="server" ErrorMessage="Postal Code cannot be blank" ControlToValidate="postalCode" ForeColor="Red"></asp:RequiredFieldValidator>  

     </div>

     <div class="form-group">
        <asp:Label Text="State" runat="server"></asp:Label>
        <asp:TextBox ID="state" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "state" ID="RegularExpressionValidator5" ValidationExpression = "^[\s\S]{0,20}$" ForeColor="Red" runat="server" ErrorMessage="Maximum 20 characters allowed."></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorState4" runat="server" ErrorMessage="State cannot be blank" ControlToValidate="state" ForeColor="Red"></asp:RequiredFieldValidator>  

    </div>

    
     <div class="form-group">
        <asp:Label Text="Country" runat="server"></asp:Label>
        <asp:TextBox ID="country" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="country" ErrorMessage="Only 'Canada' or 'United States'" ForeColor="Red" ValidationExpression="^(Canada)|(United States)$"></asp:RegularExpressionValidator> 
            
    </div>
<asp:Button CssClass="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave" />
   
</asp:Content>
