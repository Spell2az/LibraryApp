<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditGenre.aspx.cs" Inherits="EditGenre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row m-3  flex-column align-items-end w-50 ml-5" >
        <div>
        <asp:Label runat="server" Text="Please select genre  "></asp:Label>
        <asp:DropDownList ID="ddlGenre" AutoPostBack="True" OnSelectedIndexChanged="HandlerGenreSelected" runat="server"></asp:DropDownList>
        </div>
    </div>
    <asp:Panel ID="pnUpdateGenre" CssClass="row flex-column align-items-end w-50 m-3 ml-5" runat="server">
        <div class="mb-3">
        <asp:Label runat="server" Text="Genre Code  "></asp:Label>
        <asp:TextBox ID="txtGenreCode"  runat="server"></asp:TextBox>
        </div>
        <div class="">
        <asp:Label runat="server" Text="Genre Description  "></asp:Label>
        <asp:TextBox ID="txtGenreDescription" placeholder="Enter Genre description" runat="server"></asp:TextBox>
        </div>
        
    </asp:Panel>
    <div class="row justify-content-center">
        <asp:Button ID="btnUpdateGenre" OnClick="HanlderSaveUpdateGenre" CssClass="btn btn-primary m-4" runat="server" Text="Save" />
        <asp:Button ID="btnCancelUpdateGenre" CssClass="btn btn-primary m-4" OnClick="HanlderCancelUpdateGenre" runat="server" Text="Cancel" />
    </div>
</asp:Content>

