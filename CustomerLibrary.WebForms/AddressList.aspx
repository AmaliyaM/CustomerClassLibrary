<%@ Page Title="AddressList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressList.aspx.cs" Inherits="CustomerLibrary.WebForms.AddressList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
         <tr style="background-color:#ccc2c557">
            <td>
             First Line   
            </td> 

             <td>
              Second Line
            </td>

            <td>
               Type
            </td>   
            
            <td>
                City 
            </td> 
            
            <td>
                Postal Code 
            </td>

             <td>
                State 
            </td>

             <td>
                Country 
            </td>
             
        </tr>
        <%foreach (var address in Addresses)
            { %>
       
        <tr>

            <td>
               
                <%=address.FirstLine %>
                  
            </td>

             <td>

                <%=address.SecondLine %>
            </td>

            <td>
                <%=address.Type %>
            </td>   
            
            <td>
                <%=address.City %>
            </td> 
            
            <td>
                <%=address.PostalCode %>
            </td>

            <td>
                <%=address.State%>
            </td>

              <td>
                <%=address.Country%>
            </td>
           
             <td>
                <a href="DeleteAddress.aspx?customerId=<%=address.CustomerId %>&id=<%=address.AddressId %>" class="btn btn-danger">Delete</a>  
                  <a href="EditAddress.aspx?customerId=<%=address.CustomerId %>&id=<%=address.AddressId %>" class="btn btn-primary">Edit</a>  
            </td>

            

        </tr>

           <% } %>
    </table>
    <asp:Button OnClick="OnClickAddAddress" Text="Add new address" runat="server" CssClass="btn btn-primary"/>
   

</asp:Content>

