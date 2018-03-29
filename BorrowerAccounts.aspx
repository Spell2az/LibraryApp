<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BorrowerAccounts.aspx.cs" Inherits="BorrowerAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <ul class="nav nav-tabs" style="margin: 0 auto; max-width: 1160px;" id="myTab" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">All Students</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Active</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact" aria-selected="false">Suspended</a>
            </li>
        </ul>
        <div class="tab-content" style="margin: 0 auto; max-width: 1160px;" id="myTabContent">
            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
               
                <div class="row justify-content-center">
                    <asp:TextBox runat="server" ID="txtBorrowerId" placeholder="Borrower ID"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtLastName" placeholder="Last Name"></asp:TextBox>
                    
                    <asp:Button runat="server" Text="Search"/>
                    <asp:Button runat="server" Text="Clear"/>
                </div>
                <table class="table">
                    <asp:Repeater ID="rptAllAccounts" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th>Id</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Account type</th>
                                <th>Status</th>
                                <th> </th>
                                <th> </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# (Container.DataItem as Borrower).BorrowerId %></td>
                                <td><%# (Container.DataItem as Borrower).FirstName %></td>
                                <td><%# (Container.DataItem as Borrower).LastName %></td>
                                <td><%# (Container.DataItem as Borrower).GetType() %></td>  
                                <td><%# (Container.DataItem as Borrower).Status %></td>  
                                <td><asp:Button CommandArgument='<%# (Container.DataItem as Borrower).BorrowerId %>' OnClick="GoToViewAccount" runat="server" Text="View Account" CssClass="btn btn-primary" /> </td>

                                <td></td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                <table class="table">
                    <asp:Repeater ID="rptLiveAccounts" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <th>Id</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Account type</th>
                                <th>Status</th>
                                <th> </th>
                                <th> </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# (Container.DataItem as Borrower).BorrowerId %></td>
                                <td><%# (Container.DataItem as Borrower).FirstName %></td>
                                <td><%# (Container.DataItem as Borrower).LastName %></td>
                                <td><%# (Container.DataItem as Borrower).GetType() %></td>  
                                <td><%# (Container.DataItem as Borrower).Status %></td>  
                                <td><asp:Button CommandArgument='<%# (Container.DataItem as Borrower).BorrowerId %>' OnClick="GoToViewAccount" runat="server" Text="View Account" CssClass="btn btn-primary" /> </td>

                                <td></td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">  
            <table class="table">
            <asp:Repeater ID="rptSuspendedAccounts" runat="server">
            <HeaderTemplate>
                    <tr>
                        <th>Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Account type</th>
                        <th>Status</th>
                        <th> </th>
                        <th> </th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# (Container.DataItem as Borrower).BorrowerId %></td>
                        <td><%# (Container.DataItem as Borrower).FirstName %></td>
                        <td><%# (Container.DataItem as Borrower).LastName %></td>
                        <td><%# (Container.DataItem as Borrower).GetType() %></td>  
                        <td><%# (Container.DataItem as Borrower).Status %></td>  
                        <td><asp:Button CommandArgument='<%# (Container.DataItem as Borrower).BorrowerId %>' OnClick="GoToViewAccount" runat="server" Text="View Account" CssClass="btn btn-primary" /> </td>

                        <td></td>
                        <td></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </table></div>
            </div>
    
            </asp:Content>

