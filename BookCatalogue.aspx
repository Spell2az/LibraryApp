<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookCatalogue.aspx.cs" Inherits="BookCatalogue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
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
        <table class="table" style="max-width: 1400px;">
            
        <asp:Repeater ID="rptBookDisplay" runat="server">
            <HeaderTemplate>
                <tr>
                   
                    <th>Title</th>
                    <th>Author</th>
                   
                    <th> </th>             
                    
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                        
                    <td><%# (Container.DataItem as Book).Title %></td>
                    <td><%# (Container.DataItem as Book).Author %></td>
                    
                    <%--<td><%# (Container.DataItem as Book).GetGenreDescription((Container.DataItem as Book).GenreCode) %></td>--%>
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn.TrimEnd() %>' OnClick="HandlerViewBookInfo" runat="server" Text="Check Availability" CssClass="btn btn-primary" /> </td>
                   
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
</asp:Content>

