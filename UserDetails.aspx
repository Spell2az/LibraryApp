<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="text-center mb-3">
        <h2>Personal Details</h2>
    </div>
    <div class="row flex-column w-25 border p-3" style="margin: 0 auto;">
        <asp:Label runat="server" Text="Id: "></asp:Label>
        <asp:TextBox runat="server" ID="txtUserId"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Address Line 1: "></asp:Label>
        <asp:TextBox runat="server" ID="txtAddress1"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Address Line 2: "></asp:Label>
        <asp:TextBox runat="server" ID="txtAddress2"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Address Line 3: "></asp:Label>
        <asp:TextBox runat="server" ID="txtAddress3"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Telephone: "></asp:Label>
        <asp:TextBox runat="server" ID="txtTel"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Email: "></asp:Label>
        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
       
        
    </div>
    <div class="row justify-content-center">
        <asp:Button ID="btnUpdate" OnClick="HandlerSaveDetails" CssClass="m-4 btn btn-primary" runat="server" Text="Save"/>
        <asp:Button ID="btnCancel" OnClick="HandlerCancelDetailsView" CssClass="m-4 btn btn-primary" runat="server" Text="Cancel"/>
    </div>
</asp:Content>

