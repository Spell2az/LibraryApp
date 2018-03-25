<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row justify-content-center">
        <asp:Button ID="btnEditGenre" OnClick="HandlerEditGenre" runat="server" Text="Edit Genres"/>
        <asp:Button ID="btnGoToBookManagement" OnClick="HandlerManageBooks" runat="server" Text="Book Management"/>
    </div>
</asp:Content>

