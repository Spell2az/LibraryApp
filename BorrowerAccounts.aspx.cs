using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BorrowerAccounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var borrowers = new BorrowerCollection();
            borrowers.FilterBorrowerById("");
            rptAllAccounts.DataSource = borrowers.BorrowerList;
            rptAllAccounts.DataBind();
            var liveList = (from Borrower borrower in borrowers.BorrowerList where borrower.Status.Trim() == "Live" select borrower);
            var suspendedList = (from Borrower borrower in borrowers.BorrowerList where borrower.Status.Trim() == "Suspended" select borrower);
            rptLiveAccounts.DataSource = liveList;
            rptSuspendedAccounts.DataSource = suspendedList;
            rptLiveAccounts.DataBind();
            rptSuspendedAccounts.DataBind();
        }
    }

    protected void GoToViewAccount(object sender, EventArgs e)
    {
        var source = sender as Button;
        string borrowerId = null;
        if (source != null)
        {
            borrowerId = source.CommandArgument;
        }
        Response.Redirect($"BorrowerSuspendAccountView.aspx?borrowerId={borrowerId}");
    }

    protected void HandlerSearchStudents(object sender, EventArgs e)
    {
        var borrowers = new BorrowerCollection();
        borrowers.FilterByFirstAndLastNameAndId(txtBorrowerId.Text,txtFirstName.Text,txtLastName.Text);
        rptAllAccounts.DataSource = borrowers.BorrowerList;
        rptAllAccounts.DataBind();
    }

    protected void HandlerClearSearchStudents(object sender, EventArgs e)
    {
        var borrowers = new BorrowerCollection();
        borrowers.FilterBorrowerById("");
        rptAllAccounts.DataSource = borrowers.BorrowerList;
        rptAllAccounts.DataBind();
    }
}