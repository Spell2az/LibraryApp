<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BorrowerSuspendAccountView.aspx.cs" Inherits="BorrowerSuspendAccountView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div class="row flex-column align-items-center">
        <h3 class="mb-3">Account Info</h3>
        <div class="mt-3">
            <asp:Label runat="server" Text="Id: "></asp:Label>
            <asp:Label runat="server" ID="lblId"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="First Name: "></asp:Label>
            <asp:Label runat="server" ID="lblFirstName"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Last Name: "></asp:Label>
            <asp:Label runat="server" ID="lblLastName"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Telephone: "></asp:Label>
            <asp:Label runat="server" ID="lblTelephone"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Email: "></asp:Label>
            <asp:Label runat="server" ID="lblEmail"></asp:Label>

        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Account Type: "></asp:Label>
            <asp:Label runat="server" ID="lblAccountType"></asp:Label>
        </div>
    </div>
    <hr />
    <div class="row flex-column align-items-center">
        <h4>Update Account Status</h4>
        <div class="mt-3">
        <asp:RadioButton ID="rdLive" AutoPostBack="True" Text="Active" GroupName="StatusGroup" runat="server" />
        <asp:RadioButton ID="rdSuspended" AutoPostBack="True" Text="Suspended" GroupName="StatusGroup" runat="server" />
    </div>
        <div class="mt-3">
        <asp:Button runat="server" CssClass="btn btn-primary m-3" Text="Update" OnClick="HandlerUpdateSuspendAccount" />
        <asp:Button runat="server" CssClass="btn btn-primary m-3" Text="Cancel" OnClick="HandlerCancelSuspendAccount" />
        </div>
    </div>
    <ul class="nav nav-tabs" id="myTab" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Loans</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Fines</a>
        </li>

    </ul>
    <div class="tab-content" id="myTabContent">
        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
            <table class="table mt-4">
                <asp:Repeater runat="server" ID="rptLoans">

                    <HeaderTemplate>
                        <tr>
                            <th>Loan Id </th>
                            <th>Issue Date </th>
                            <th>Due Date </th>
                            <th>Return Date</th>
                            <th>Copy Barcode</th>

                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# (Container.DataItem as Loan).LoanId %></td>
                            <td><%# (Container.DataItem as Loan).LoanIssueDate.ToString("dd/MM/yyyy") %></td>
                            <td><%# (Container.DataItem as Loan).LoanDueDate.ToString("dd/MM/yyyy") %></td>
                            <td><%# (Container.DataItem as Loan).LoanReturnDate == null ? "Not Returned" : Convert.ToDateTime((Container.DataItem as Loan).LoanReturnDate.ToString()).ToString("dd/MM/yyyy") %></td>
                            <td><%# (Container.DataItem as Loan).CopyBarcode %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
            <table class="table mt-4">
                <asp:Repeater runat="server" ID="rptFines">

                    <HeaderTemplate>
                        <tr>
                            <th>Fine Id </th>
                            <th>Fine Date </th>
                            <th>Fine Amount</th>
                            <th>Fine Status</th>
                            <th>Loan Id</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                        <td><%# (Container.DataItem as Fine).FineId %></td>
                        <td><%# (Container.DataItem as Fine).FineDate.ToString("dd/MM/yyyy") %></td>
                        <td><%# (Container.DataItem as Fine).FineAmount.ToString("C") %></td>
                        <td><%# (Container.DataItem as Fine).FineStatus %></td>
                        <td><%# (Container.DataItem as Fine).LoanId %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

