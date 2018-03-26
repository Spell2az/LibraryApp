<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookManagement.aspx.cs" Inherits="BookManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- Search section markup --%>
    <div class="row">
        <label></label>
        <asp:TextBox runat="server"></asp:TextBox>
    </div>
    <%-- Controls section markup --%>
    <div class="row">
        <asp:Button runat="server" />
      
    </div>
    <div class="row justify-content-center search-box-row m-2">
        <asp:TextBox runat="server" ID="txtIsbn" placeholder="Isbn"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtTitle" placeholder="Title"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtAuthor" placeholder="Author"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtPublisher" placeholder="Publisher"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtYear" placeholder="Year"></asp:TextBox>
        <asp:Label runat="server" Text="Genre: "></asp:Label>
        <asp:DropDownList AutoPostBack="True" runat="server" ID="ddlGenre" ></asp:DropDownList>
        <asp:Button runat="server" Text="Search" ID="btnSearch" OnClick="HandlerSearchBooks"/>
        <asp:Button runat="server" Text="Clear" ID="btnClear" OnClick="HandlerClearSearch"/>
        
    </div>
    <div class="row justify-content-center">
        <asp:Button runat="server" Text="Add new Book" ID="btnAddNewBook" OnClick="HandlerAddNewBook"/>
    </div>
    <%-- Dispaly section markup --%>
    <div class="row justify-content-center">
        <table class="table" style="max-width: 1400px;">
            
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
                    <th> </th>
                    <th> </th>
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
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn.TrimEnd() %>' OnClick="GoToEditBook" runat="server" Text="Edit" CssClass="btn btn-primary" /> </td>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn.TrimEnd() %>' OnClick="HandlerDeleteBook" runat="server" Text="Delete" CssClass="btn btn-primary" /></td>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn.TrimEnd() %>' OnClick="GoToBookCopies" runat="server" Text="Book Copies" CssClass="btn btn-primary" /></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
</asp:Content>

