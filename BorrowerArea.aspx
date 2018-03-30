<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BorrowerArea.aspx.cs" Inherits="BorrowerArea" %>

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
    <div>
        <ul class="nav nav-tabs" id="mainTab" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" id="loans-tab" data-toggle="tab" href="#loans" role="tab" aria-controls="loans" aria-selected="true">Loans</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="reservations-tab" data-toggle="tab" href="#reservations" role="tab" aria-controls="reservations" aria-selected="false">Reservations</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="fines-tab" data-toggle="tab" href="#fines" role="tab" aria-controls="fines" aria-selected="false">Fines</a>
            </li>
        </ul>
        <div class="tab-content" id="mainTabContent">
            
<%--------------------------------------LOANS-----------------------------------------%>

            <div class="tab-pane fade show active" id="loans" role="tabpanel" aria-labelledby="loans-tab">
                <ul class="nav nav-pills mb-3" id="pills-loans-tab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="pills-current-loans-tab" data-toggle="pill" href="#pills-current-loans" role="tab" aria-controls="pills-current-loans" aria-selected="true">Current</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="pills-history-loans-tab" data-toggle="pill" href="#pills-history-loans" role="tab" aria-controls="pills-history-loans" aria-selected="false">History</a>
                    </li>
                </ul>
                <div class="tab-content" id="pills-loans-tabContent">
                    <div class="tab-pane fade show active" id="pills-current-loans" role="tabpanel" aria-labelledby="pills-current-loans-tab">
                        <table class="table">
                            <asp:Repeater ID="rptCurrentLoans" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        <th>Loan Id</th>
                                        <th>Title</th>
                                        <th>Issue Date</th>
                                        <th>Due Date</th>
                                        <th>Due in</th>
                                        <th></th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# (Container.DataItem as Loan).LoanId %></td>
                                        <td><%# (Container.DataItem as Loan).GetBookTitle((Container.DataItem as Loan).CopyBarcode) %></td>
                                        <td><%# (Container.DataItem as Loan).LoanIssueDate %></td>
                                        <td><%# (Container.DataItem as Loan).LoanDueDate %></td>
                                        <td><%# (int)((Container.DataItem as Loan).LoanDueDate - DateTime.Today).TotalDays == 0 
                                                    ? "Due Today" 
                                                    : (int)((Container.DataItem as Loan).LoanDueDate - DateTime.Today).TotalDays > 0 
                                                    ? $"{(int)((Container.DataItem as Loan).LoanDueDate - DateTime.Today).TotalDays} day(s)" 
                                                    : $"{-(int)((Container.DataItem as Loan).LoanDueDate - DateTime.Today).TotalDays} day(s) Overdue" %></td>
                                        <td><asp:Button runat="server" Text="Extend"/> </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="tab-pane fade" id="pills-history-loans" role="tabpanel" aria-labelledby="pills-history-loans-tab">
                        <table class="table">
                            <asp:Repeater ID="rptHistoryLoans" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        <th>Loan Id</th>
                                        <th>Title</th>
                                        <th>Issue Date</th>
                                        <th>Due Date</th>
                                        <th>Return Date</th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# (Container.DataItem as Loan).LoanId %></td>
                                        <td><%# (Container.DataItem as Loan).GetBookTitle((Container.DataItem as Loan).CopyBarcode) %></td>
                                        <td><%# (Container.DataItem as Loan).LoanIssueDate %></td>
                                        <td><%# (Container.DataItem as Loan).LoanDueDate %></td>
                                        <td><%# (Container.DataItem as Loan).LoanReturnDate %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    
                </div>
            </div>
            
<%--------------------------------------RESERVATIONS-----------------------------------------%>

            <div class="tab-pane fade" id="reservations" role="tabpanel" aria-labelledby="reservations-tab">
                <ul class="nav nav-pills mb-3" id="pills-reservations-tab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="pills-current-reservations-tab" data-toggle="pill" href="#pills-current-reservations" role="tab" aria-controls="pills-current-reservations" aria-selected="true">Current</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="pills-history-reservations-tab" data-toggle="pill" href="#pills-history-reservations" role="tab" aria-controls="pills-history-reservations" aria-selected="false">History</a>
                    </li>
                </ul>
                <div class="tab-content" id="pills-reservations-tabContent">
                    <div class="tab-pane fade show active" id="pills-current-reservations" role="tabpanel" aria-labelledby="pills-current-reservations-tab">
                        <table class="table">
                            <asp:Repeater ID="rptCurrentReservations" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        <th>Reservation Id</th>
                                        <th>Title</th>
                                        <th>Reservation Date</th>
                                        <th>Pick up Reservation By</th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# (Container.DataItem as Reservation).ReservationId %></td>
                                        <td><%# (Container.DataItem as Reservation).GetBookTitle((Container.DataItem as Reservation).ReservedIsbn) %></td>
                                        <td><%# (Container.DataItem as Reservation).ReservationDate %></td>
                                        <td><%# (Container.DataItem as Reservation).ReservationDate.AddDays(3) %></td>
                                        
                                        <td><asp:Button runat="server" Text="Extend"/> </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="tab-pane fade" id="pills-history-reservations" role="tabpanel" aria-labelledby="pills-history-reservations-tab">
                        <table class="table">
                            <asp:Repeater ID="rptHistoryReservations" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        <th>Reservation Id</th>
                                        <th>Title</th>
                                        <th>Reservation Date</th>
                                        <th>Reservation Cleared On</th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# (Container.DataItem as Reservation).ReservationId %></td>
                                        <td><%# (Container.DataItem as Reservation).GetBookTitle((Container.DataItem as Reservation).ReservedIsbn) %></td>
                                        <td><%# (Container.DataItem as Reservation).ReservationDate %></td>
                                        <td><%# (Container.DataItem as Reservation).ClearedDate %></td>
                                        
                                        <td><asp:Button runat="server" Text="Extend"/> </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    
                </div>
            </div>

<%--------------------------------------FINES-----------------------------------------%>
            

            <div class="tab-pane fade" id="fines" role="tabpanel" aria-labelledby="fines-tab">
                <ul class="nav nav-pills mb-3" id="pills-fines-tab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="pills-current-fines-tab" data-toggle="pill" href="#pills-current-fines" role="tab" aria-controls="pills-current-fines" aria-selected="true">Current</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="pills-history-fines-tab" data-toggle="pill" href="#pills-history-fines" role="tab" aria-controls="pills-history-fines" aria-selected="false">History</a>
                    </li>
                </ul>
                <div class="tab-content" id="pills-fines-tabContent">
                    <div class="tab-pane fade show active" id="pills-current-fines" role="tabpanel" aria-labelledby="pills-current-fines-tab">
                        <table class="table">
                            <asp:Repeater ID="rptCurrentFines" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        
                                        <th>Fine Date</th>
                                        <th>Fine Amount</th>
                                        <th>Late return Loan id</th>
                                        <th>Late return Book Title</th>
                                        <th></th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# (Container.DataItem as Fine).FineDate %></td>
                                        <td><%# (Container.DataItem as Fine).FineAmount %></td>
                                        <td><%# (Container.DataItem as Fine).LoanId %></td>
                                        <td><%# (Container.DataItem as Fine).GetBookTitle((Container.DataItem as Fine).LoanId) %></td>
                                        <td><asp:Button runat="server" OnClick="HandlerGoToPayment" CommandArgument='<%# (Container.DataItem as Fine).FineId %>' Text="Pay Fine"/></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="tab-pane fade" id="pills-history-fines" role="tabpanel" aria-labelledby="pills-history-fines-tab">
                        <table class="table">
                            <asp:Repeater ID="rptHistoryFines" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        <th>Fine Date</th>
                                        <th>Fine Amount</th>
                                        <th>Payment Date</th>
                                        <th>Payment Amount</th>
                                        <th>Loan Type</th>
                                        <th>Loan Id</th>
                                        <th>Book Title</th>
                                        <th></th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# (Container.DataItem as Dictionary<string, string>)["fineDate"] %></td>
                                        <td><%# (Container.DataItem as Dictionary<string, string>)["fineAmount"] %></td>
                                        <td><%# (Container.DataItem as Dictionary<string, string>)["paymentDate"] %></td>
                                        <td><%# (Container.DataItem as Dictionary<string, string>)["paymentAmount"] %></td>
                                        <td><%# (Container.DataItem as Dictionary<string, string>)["loanType"] %></td>
                                        <td><%# (Container.DataItem as Dictionary<string, string>)["loanId"] %></td>
                                        <td><%# (Container.DataItem as Dictionary<string, string>)["title"] %></td>
                                       
                                        
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>

