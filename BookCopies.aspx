<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookCopies.aspx.cs" Inherits="BookCopies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Book Details</h3>
    <table class="table">
        <tr>
            <th>Isbn</th>
            <th>Author</th>
            <th>Title</th>
            <th>Publisher</th>
            <th>Year</th>
            <th>Shelf No</th>
            <th>Edition</th>
            <th>Genre</th>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="txtIsbn"></asp:Label> </td>
            <td><asp:Label runat="server" ID="txtAuthor"></asp:Label> </td>
            <td><asp:Label runat="server" ID="txtTitle"></asp:Label> </td>
            <td><asp:Label runat="server" ID="txtPublisher"></asp:Label> </td>
            <td><asp:Label runat="server" ID="txtYear"></asp:Label> </td>
            <td><asp:Label runat="server" ID="txtShelf"></asp:Label> </td>
            <td><asp:Label runat="server" ID="txtEdition"></asp:Label> </td>
            <td><asp:Label runat="server" ID="txtGenre"></asp:Label> </td>
           
        </tr>
    </table>
    <div class="row justify-content-center m-5">
        <asp:Button CssClass="btn btn-primary" runat="server" Text="Add Copy" OnClick="HandlerAddBookCopy"/>
    </div>
    <table class="table">
    <asp:Repeater ID="rptBookCopy" runat="server">
        <HeaderTemplate>
            <tr>
                <th>Barcode</th>
                <th>Loan Type</th>
                <th>Status</th>
                <th>Condition</th>
                <th> </th>
                <th> </th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
            <td>
                
                <%# (Container.DataItem as BookCopy).Barcode %> 
            </td>
            <td>
                <%# (Container.DataItem as BookCopy).LoanType %>
            </td>
            <td>
                <%# (Container.DataItem as BookCopy).Status %>
            </td>
            <td>
                <%# (Container.DataItem as BookCopy).Condition %>
            </td>
            <td>
                <asp:Button CommandArgument='<%# (Container.DataItem as BookCopy).Barcode %>' CssClass="btn btn-warning" OnClick="HandlerEditBookCopy" runat="server" Text="Edit"/>
            </td>
            <td>
                <asp:Button CommandArgument='<%# (Container.DataItem as BookCopy).Barcode %>' CssClass="btn btn-danger" OnClick="HandlerDeleteBookCopy" runat="server" Text="Delete"/>
            </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>

