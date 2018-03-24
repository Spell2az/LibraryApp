<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookEdit.aspx.cs" Inherits="BookEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row flex-column m-5">
        <asp:TextBox runat="server" ID="txtIsbn"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtAuthor"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtPublisher"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtPubYear"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtShelfNo"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtEdition"></asp:TextBox>
        <asp:DropDownList AutoPostBack="True" runat="server" ID="ddlGenre"/>
        <asp:Button ID="btnUpdateBook" OnClick="HandlerUpdateBook" Text="Update" runat="server"/>
        <asp:Button ID="btnCancel" OnClick="HandlerCancelBook" Text="Cancel" runat="server"/>
    </div>
</asp:Content>

