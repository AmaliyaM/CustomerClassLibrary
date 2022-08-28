<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoteList.aspx.cs" Inherits="CustomerLibrary.WebForms.NoteList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <table class="table">
         <tr style="background-color:#ccc2c557">
            <td>
             Note 
            </td> 

        </tr>
        <%foreach (var note in Notes)
            { %>
       
        <tr>

            <td>
               
                <%=note.NoteLine %>
                  
            </td>
           
             <td>
                <a href="DeleteNote.aspx?customerId=<%=note.CustomerId %>&id=<%=note.NoteId %>" class="btn btn-danger">Delete</a>  
                  <a href="EditNote.aspx?customerId=<%=note.CustomerId %>&id=<%=note.NoteId %>" class="btn btn-primary">Edit</a>  
            </td>

            

        </tr>

           <% } %>
    </table>
    <asp:Button OnClick="OnClickAddNote" Text="Add new note" runat="server" CssClass="btn btn-primary"/>
</asp:Content>
