<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookView.aspx.cs" Inherits="BookView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row flex-column">
        <h3>Book Details: </h3>
        <asp:Label runat="server" Text="Isbn"></asp:Label>
        <asp:Label runat="server" ID="lblIsbn"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Title"></asp:Label>
        <asp:Label runat="server" ID="lblTitle"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Author"></asp:Label>
        <asp:Label runat="server" ID="lblAuthor"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Publisher"></asp:Label>
        <asp:Label runat="server" ID="lblPublisher"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Publication Year"></asp:Label>
        <asp:Label runat="server" ID="lblPubYear"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Edition No"></asp:Label>
        <asp:Label runat="server" ID="lblEdition"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Genre"></asp:Label>
        <asp:Label runat="server" ID="lblGenre"></asp:Label>
        
    </div>
    <br />
    <br />
    <div class="row flex-column">
        <h3>Availability</h3>
        <p>Not Available</p>
    </div>
    <br />
    <br />
    <div class="row">
        <asp:Button runat="server" Text="Reserve"/>
    </div>
</asp:Content>

