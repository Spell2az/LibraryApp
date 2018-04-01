<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookView.aspx.cs" Inherits="BookView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   
        <div class="row flex-column">
        <h3>Book Details: </h3>
        <asp:Label runat="server" Text="Isbn"></asp:Label>
        <asp:Label runat="server" ID="lblIsbn"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Title"></asp:Label>
        <asp:Label runat="server" ID="lblTitle"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Author"></asp:Label>
        <asp:Label runat="server" ID="lblAuthor"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Publisher"></asp:Label>
        <asp:Label runat="server" ID="lblPublisher"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Publication Year"></asp:Label>
        <asp:Label runat="server" ID="lblPubYear"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Edition No"></asp:Label>
        <asp:Label runat="server" ID="lblEdition"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Genre"></asp:Label>
        <asp:Label runat="server" ID="lblGenre"></asp:Label>
        
    </div>
    <br />
    <br />
    <div class="row flex-column">
        <p>
            <a class="" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">
                <asp:Label runat="server" ID="lblAvailableCopy"></asp:Label>
            </a>
           
        </p>
        <div class="collapse" id="collapseExample">
            <div class="card card-body">
                <table class="table">
                <asp:Repeater ID="rptBookCopies" runat="server">
                    <HeaderTemplate>
                        <tr>
                            <td>Barcode</td>
                            <td>Shelf</td>
                            <td>Loan type</td>
                            <td>Status</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Barcode") %></td>
                            <td><%# Eval("Shelf") %></td>
                            <td><%# Eval("LoanType") %></td>
                            <td><%# Eval("Status") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="row" id="messagePlaceholder">
        <asp:Button runat="server" ID="btnReserve" OnClick="HandlerReserveBook"/>
    </div>
    <div id="success" class="alert alert-success reservation-alert">
        <h4 class="alert-heading">Reservation placed!</h4>
    </div>
    <script type="text/javascript">
        function showMe(bool) {
            if (bool) {
                setTimeout(() => { $('#success').addClass("alert-up"); }, 500)
                setTimeout(() => {
                    $('#success').removeClass("alert-up");
                }, 1500)
                setTimeout(() => {window.location.href = 'BookCatalogue.aspx'},2000)
            }
            else {
                $('#error').show();
                setTimeout(() => {
                    $('#error').hide('fadeOut', 500);
                }, 3500)
            }
        }
    </script>
      
</asp:Content>

