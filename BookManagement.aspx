<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookManagement.aspx.cs" Inherits="BookManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  
    <div class="row justify-content-center search-box-row m-2">
        <div class="col-4 row flex-column align-items-end">
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtIsbn" placeholder="Isbn"></asp:TextBox>
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtTitle" placeholder="Title"></asp:TextBox>
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtAuthor" placeholder="Author"></asp:TextBox>
        </div>
    <div class="col-4 row flex-column">
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtPublisher" placeholder="Publisher"></asp:TextBox>
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtYear" placeholder="Year"></asp:TextBox>
        <asp:Label runat="server" CssClass="w-50" Text="Genre: "></asp:Label>
        <asp:DropDownList CssClass="w-50 mb-2" AutoPostBack="True" runat="server" ID="ddlGenre" ></asp:DropDownList>
    </div>
        
    </div>
            <div class="row justify-content-center">
                <asp:Button  runat="server" CssClass="btn btn-primary m-4" Text="Search" ID="btnSearch" OnClick="HandlerSearchBooks"/>
                <asp:Button runat="server" CssClass="btn btn-primary m-4"  Text="Clear" ID="btnClear" OnClick="HandlerClearSearch"/>
            </div>
  
    <%-- Dispaly section markup --%>
    <div class="row justify-content-center">
        <table class="table m-5" style="max-width: 1400px;">
            
        <asp:Repeater ID="rptBookDisplay" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>Isbn</th>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Publisher</th>
                    <th>P. Year</th>
                    <th>Shelf No.</th>
                    <th>Edition</th>
                    <th>Genre</th>
                    <th> </th>             
                    <th><asp:Button runat="server" CssClass="btn btn-outline-success"  Text="Add new Book" ID="btnAddNewBook" OnClick="HandlerAddNewBook"/>  </th>
                    <th><asp:Button ID="btnEditGenre"  CssClass="btn btn-outline-success" OnClick="HandlerEditGenre" runat="server" Text="Update Genres"/></th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                        
                    <td><%# (Container.DataItem as Book).Isbn %></td>
                    <td><%# (Container.DataItem as Book).Title %></td>
                    <td><%# (Container.DataItem as Book).Author %></td>
                    <td><%# (Container.DataItem as Book).Publisher %></td>
                    <td><%# (Container.DataItem as Book).PubYear %></td>
                    <td><%# (Container.DataItem as Book).ShelfNo %></td>
                    <td><%# (Container.DataItem as Book).Edition %></td>
                    <td><%# (Container.DataItem as Book).GetGenreDescription((Container.DataItem as Book).GenreCode) %></td>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn.TrimEnd() %>' OnClick="GoToEditBook" runat="server" Text="Edit" CssClass="btn btn-warning" /> </td>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn.TrimEnd() %>' OnClick="HandlerDeleteBook" runat="server" Text="Delete" CssClass="btn btn-danger btn-block" /></td>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn.TrimEnd() %>' OnClick="GoToBookCopies" runat="server" Text="Book Copies" CssClass="btn btn-primary btn-block" /></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
      
</asp:Content>

