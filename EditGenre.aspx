<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditGenre.aspx.cs" Inherits="EditGenre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row justify-content-center">
        <asp:Label runat="server" Text="Please select genre"></asp:Label>
        <asp:DropDownList ID="ddlGenre" AutoPostBack="True" OnSelectedIndexChanged="HandlerGenreSelected" runat="server"></asp:DropDownList>

    </div>
    <asp:Panel ID="pnUpdateGenre" runat="server">
        <asp:Label runat="server" Text="Genre Code"></asp:Label>
        <asp:TextBox ID="txtGenreCode"  runat="server"></asp:TextBox>
        <asp:Label runat="server" Text="Genre Description"></asp:Label>
        <asp:TextBox ID="txtGenreDescription" placeholder="Enter Genre description" runat="server"></asp:TextBox>
        <asp:Button ID="btnUpdateGenre" OnClick="HanlderSaveUpdateGenre" runat="server" Text="Save" />
        <asp:Button ID="btnCancelUpdateGenre" OnClick="HanlderCancelUpdateGenre" runat="server" Text="Cancel" />
    </asp:Panel>
</asp:Content>

