using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPages_LibraryStaff_UserAccounts : System.Web.UI.Page
{
    private string _borrowerId;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void HandlerGoToDetails(object sender, EventArgs e)
    {
        Response.Redirect($"StaffEditUserDetails.aspx?id={_borrowerId}");
      
    }

    protected void HandlerGoToPayment(object sender, EventArgs e)
    {
       
    }

    protected void HandlerFindUser(object sender, EventArgs e)
    {
        var account = new Borrower();

        if (account.Find(txtStudentNumber.Text.Trim()))
        {
            pnUserInfo.Visible = true;
            _borrowerId = account.BorrowerId;

            lblUser.Text = $"{account.FirstName} {account.LastName}";

            lblLoans.Text = $"{account.Loans.FindAll(loan => loan.LoanReturnDate == null).Count.ToString()} / {account.GetBorrowerMaxLoans()}";
            lblFines.Text = account.Fines.FindAll(fine => fine.FineStatus.Trim() == "DUE").Sum(fine => fine.FineAmount).ToString("C");
            lblResrvation.Text = account.Reservations.FindAll(reservation => reservation.ClearedDate == null).Count
                .ToString();

            rptCurrentLoans.DataSource = account.Loans.FindAll(loan => loan.LoanReturnDate == null);
            rptCurrentLoans.DataBind();

            rptHistoryLoans.DataSource = account.Loans.FindAll(loan => loan.LoanReturnDate != null);
            rptHistoryLoans.DataBind();

            rptCurrentReservations.DataSource = account.Reservations.FindAll(reservation => reservation.ClearedDate == null);
            rptCurrentReservations.DataBind();

            rptHistoryReservations.DataSource = account.Reservations.FindAll(reservation => reservation.ClearedDate != null);
            rptHistoryReservations.DataBind();

            rptCurrentFines.DataSource = account.Fines.FindAll(fine => fine.FineStatus.Trim() == "DUE");
            rptCurrentFines.DataBind();

            var finesWithPayments = new FineCollection(account.BorrowerId);
            rptHistoryFines.DataSource = finesWithPayments.FinesWithPayments();
            rptHistoryFines.DataBind();
        }
        
    }
}