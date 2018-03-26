<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <asp:TextBox runat="server" ID="txtUserId"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtSurname"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtAddress1"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtAddress2"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtAddress3"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtTel"></asp:TextBox>
        
    </div>
</asp:Content>

