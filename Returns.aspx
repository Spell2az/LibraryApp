<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Returns.aspx.cs" Inherits="Returns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="h2 text-center m-5">Process Returns</div>
    <div class="row justify-content-center">
        <asp:TextBox runat="server" CssClass="m-3" placeholder="Scan/Enter Barcode"></asp:TextBox>
        <asp:Button CssClass="btn btn-primary m-3" runat="server" Text="Process"/>
    </div>
   
</asp:Content>

