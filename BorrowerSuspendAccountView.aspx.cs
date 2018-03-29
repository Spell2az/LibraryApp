using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BorrowerSuspendAccountView : System.Web.UI.Page
{
    private string _borrowerId;
    protected void Page_Load(object sender, EventArgs e)
    {
        _borrowerId = Request.QueryString["borrowerId"];
        var account = new Borrower();
        account.Find(_borrowerId);
        if (!Page.IsPostBack)
        {
            lblId.Text = account.BorrowerId;
            lblFirstName.Text = account.FirstName;
            lblLastName.Text = account.LastName;
            lblTelephone.Text = account.TelNumber;
            lblEmail.Text = account.Email;
            lblAccountType.Text = account.GetBorrowerTypeDescription(account.BorrowerType);
            rdLive.Checked = account.Status.Trim() == "Live";
            rdSuspended.Checked = account.Status.Trim() == "Suspended";
            rptLoans.DataSource = account.Loans;
            rptLoans.DataBind();

            rptFines.DataSource = account.Fines;
            rptFines.DataBind();
        }
    }

    protected void HandlerCancelSuspendAccount(object sender, EventArgs e)
    {
        Response.Redirect("BorrowerAccounts.aspx");
    }

    protected void HandlerUpdateSuspendAccount(object sender, EventArgs e)
    {
        var borrowers = new BorrowerCollection();
        var account = borrowers.Borrower;
        account.Find(_borrowerId);
        account.Status = rdSuspended.Checked ? "Suspended" : "Live";
        borrowers.Update();
    }
}