<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookCopyEdit.aspx.cs" Inherits="BookCopyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label runat="server" Text="Barcode"></asp:Label>
    <asp:TextBox ID="txtBarcode" runat="server"></asp:TextBox>
    <asp:Label runat="server" Text="Loan Type"></asp:Label>
    <asp:DropDownList AutoPostBack="True" ID="ddlLoanType" runat="server"/>
    <asp:Label runat="server" Text="Status"></asp:Label>
    <asp:DropDownList AutoPostBack="True" ID="ddlStatus" runat="server"/>
    <asp:Label runat="server" Text="Condition"></asp:Label>
    <asp:DropDownList AutoPostBack="True" ID="ddlCondition" runat="server"/>
   
    <asp:Button runat="server" Text="Save" ID="btnSave" OnClick="HandlerSaveBookCopy"/>
    <asp:Button runat="server" Text="Cancel" ID="btnCancel" OnClick="HandlerCancelCopyEdit"/>
</asp:Content>

