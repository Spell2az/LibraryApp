<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookEdit.aspx.cs" Inherits="BookEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="text-center mb-3">
        <h2>Book Edit</h2>
    </div>
    <div class="row flex-column w-25 p-3 border" style="margin: 0 auto;">
        <asp:Label CssClass="mt-3" runat="server" Text="Isbn"></asp:Label>
        <asp:TextBox  runat="server" ID="txtIsbn"></asp:TextBox>
        <asp:Label CssClass="mt-3"  runat="server" Text="Title"></asp:Label>
        <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
        <asp:Label CssClass="mt-3"  runat="server" Text="Author"></asp:Label>
        <asp:TextBox runat="server" ID="txtAuthor"></asp:TextBox>
        <asp:Label CssClass="mt-3"  runat="server" Text="Pulbisher"></asp:Label>
        <asp:TextBox  runat="server" ID="txtPublisher"></asp:TextBox>
        <asp:Label CssClass="mt-3"  runat="server" Text="Year Published"></asp:Label>
        <asp:TextBox runat="server" ID="txtPubYear"></asp:TextBox>
        <asp:Label CssClass="mt-3"  runat="server" Text="Shelf No"></asp:Label>
        <asp:TextBox  runat="server" ID="txtShelfNo"></asp:TextBox>
        <asp:Label CssClass="mt-3"  runat="server" Text="Edition"></asp:Label>
        <asp:TextBox  runat="server" ID="txtEdition"></asp:TextBox>
        <asp:Label CssClass="mt-3"  runat="server" Text="Genre"></asp:Label>
        <asp:DropDownList   AutoPostBack="True" runat="server" ID="ddlGenre"/>
        
    </div>
    <div class="row justify-content-center">
        <asp:Button ID="btnUpdateBook" OnClick="HandlerUpdateBook" CssClass="btn btn-primary m-4" Text="Update" runat="server"/>
        <asp:Button ID="btnCancel" OnClick="HandlerCancelBook" CssClass="btn btn-primary m-4" Text="Cancel" runat="server"/>
    </div>
</asp:Content>

