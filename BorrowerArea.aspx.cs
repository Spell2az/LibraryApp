using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BorrowerArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var account = new Borrower();
        account.Find(Session["user"].ToString());
        lblUser.Text = $"Welcome, {account.FirstName} {account.LastName}";

        lblLoans.Text = account.Loans.FindAll(loan => loan.LoanReturnDate == null).Count.ToString();
        lblFines.Text = account.Fines.FindAll(fine => fine.FineStatus.Trim() == "DUE").Count.ToString();
        lblResrvation.Text = account.Reservations.FindAll(reservation => reservation.ClearedDate == null).Count
            .ToString();
    }

    protected void HandlerGoToDetails(object sender, EventArgs e)
    {
        Response.Redirect("UserDetails.aspx");
    }
}