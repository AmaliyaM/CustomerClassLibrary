<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerLibrary.WebForms.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
         <tr style="background-color:#ccc2c557">
            <td>
             FirstName    
            </td> 

             <td>
              LastName 
            </td>

            <td>
               Email 
            </td>   
            
            <td>
                PhoneNumber 
            </td> 
            
            <td>
                TotalPurchasesAmount 
            </td>

             <td>
                Addresses 
            </td>

             <td>
                Notes 
            </td>
             <td></td>
        </tr>
        <%foreach (var customer in Customers)
            { %>
       
        <tr>

            <td>
                <a href="CustomerEdit.aspx?id=<%=customer.ID %>">
                <%=customer.FirstName %>
                    </a>
            </td>

             <td>

                <%=customer.LastName %>
            </td>

            <td>
                <%=customer.Email %>
            </td>   
            
            <td>
                <%=customer.PhoneNumber %>
            </td> 
            
            <td>
                <%=customer.TotalPurchasesAmount %>
            </td>

            <td>
                <a href="AddressList.aspx?customerId=<%=customer.ID %>">
                <%=customer.FirstName%>'s Addresses
                    </a>

            </td>
           
             <td>
                 <a href="NoteList.aspx?customerId=<%=customer.ID %>">
                  <%=customer.FirstName%>'s Notes
                     </a>
            </td>
            <td>
                <a href="DeleteCustomer.aspx?id=<%=customer.ID %>" class="btn btn-danger">Delete</a> 
                
            </td>

        </tr>

           <% } %>
    </table>
    <asp:Button OnClick="OnClickUpload" Text="Upload data" runat="server" CssClass="btn btn-primary"/>
    <asp:Button OnClick="OnClickAddCustomer" Text="Add new customer" runat="server" CssClass="btn btn-primary"/>

   <%//  CommandArgument='<%#Eval("customer.Email")' OnClick="OnClickDelete" %>
 



</asp:Content>
