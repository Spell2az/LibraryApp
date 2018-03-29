<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BorrowerArea.aspx.cs" Inherits="BorrowerArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server" ID="lblUser"></asp:Label>
    <asp:Button OnClick="HandlerGoToDetails" runat="server" Text="Personal Details"/>
    <div>
        <h4>Account information</h4>
        <asp:Label runat="server" Text="Loans: "></asp:Label>
        <asp:Label runat="server" ID="lblLoans"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Reserved: "></asp:Label>
        <asp:Label runat="server" ID="lblResrvation"></asp:Label>
        
        <br />
        <asp:Label runat="server" Visible="True" Text="Fines: "></asp:Label>
        <asp:Label runat="server" ID="lblFines"></asp:Label>
    </div>
</asp:Content>

