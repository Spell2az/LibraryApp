<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row justify-content-center">
        
        <asp:Button ID="btnGoToBookManagement" OnClick="HandlerManageBooks" runat="server" Text="Book Management"/>
        <asp:Button OnClick="HandlerGoToBorrowerArea" runat="server"/>
        <asp:Button runat="server" OnClick="HandlerViewStudentAccounts" Text="Student Accounts"/>
        <asp:Button runat="server" OnClick="HandlerViewBookCatalogue" Text="BookCatalogue"/>
    </div>
</asp:Content>

