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
                    <td><%# (Container.DataItem as Book).GenreCode %></td>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn %>' OnClick="GoToEditBook" runat="server" Text="Edit" CssClass="btn btn-primary" /> </td>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn %>' runat="server" Text="Delete" CssClass="btn btn-primary" /></td>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn %>' OnClick="GoToBookCopies" runat="server" Text="Book Copies" CssClass="btn btn-primary" /></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
</asp:Content>

