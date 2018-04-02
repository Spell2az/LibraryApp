<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookCatalogue.aspx.cs" Inherits="BookCatalogue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row justify-content-center m-4 ">
        <div class="col-4 row flex-column align-items-end mr-3 ">
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtIsbn" placeholder="Isbn"></asp:TextBox>
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtTitle" placeholder="Title"></asp:TextBox>
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtAuthor" placeholder="Author"></asp:TextBox>
        </div>
    <div class="col-4 row flex-column">
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtPublisher" placeholder="Publisher"></asp:TextBox>
        <asp:TextBox runat="server" CssClass="w-50 mb-2" ID="txtYear" placeholder="Year"></asp:TextBox>
        <div></div>
        <asp:Label runat="server" Text="Genre: "></asp:Label>
        <asp:DropDownList  CssClass="w-50" AutoPostBack="True" runat="server" ID="ddlGenre" ></asp:DropDownList>
    </div>
    </div>
    <div class="row justify-content-center">
        <asp:Button runat="server" Text="Search" ID="btnSearch" CssClass="btn btn-primary m-4" OnClick="HandlerSearchBooks"/>
        <asp:Button runat="server" Text="Clear" ID="btnClear"  CssClass="btn btn-primary m-4"  OnClick="HandlerClearSearch"/>
    </div>
    <div class="row justify-content-center w-75" style="margin: 0 auto">
        <table class="table m-5" style="max-width: 1400px;">
            
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
                    <td><asp:Button CommandArgument='<%# (Container.DataItem as Book).Isbn.TrimEnd() %>' OnClick="HandlerViewBookInfo" runat="server" Text="Check Availability" CssClass="btn btn-outline-primary" /> </td>
                   
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
</asp:Content>

