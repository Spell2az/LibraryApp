using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookCopyEdit : System.Web.UI.Page
{
    private string _copyBarcode;
    private bool _isNew;
    protected void Page_Load(object sender, EventArgs e)
    {


        _copyBarcode = Request.QueryString["barcode"];
        _isNew = Convert.ToBoolean(Request.QueryString["isNew"]);
        if (!Page.IsPostBack)
        {
            FillDropDowns();
            if (_copyBarcode != null)
            {
                var bookCopyCollection = new BookCopyCollection();
                txtBarcode.Enabled = false;
                if (bookCopyCollection.BookCopy.Find(_copyBarcode))
                {
                    DisplayCopyDetails(bookCopyCollection.BookCopy);
                }
            }
        }
    }

    private void DisplayCopyDetails(BookCopy copy)
    {
        txtBarcode.Text = copy.Barcode;
        ddlLoanType.SelectedValue = copy.LoanType;
        ddlStatus.SelectedValue = copy.Status;
        ddlCondition.SelectedValue = copy.Condition;
    }

    protected void HandlerSaveBookCopy(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected void HandlerCancelCopyEdit(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void FillDropDowns()
    {
        ddlLoanType.Items.Add(new ListItem("Normal", "Normal"));
        ddlLoanType.Items.Add(new ListItem("Short", "Short"));
        ddlLoanType.Items.Add(new ListItem("Not for loan", "Not for loan"));


        ddlStatus.Items.Add(new ListItem("Available", "Available"));
        ddlStatus.Items.Add(new ListItem("Withdrawn", "Withdrawn"));
        ddlStatus.Items.Add(new ListItem("Lost", "Lost"));

        ddlCondition.Items.Add(new ListItem("Good", "Good"));
        ddlCondition.Items.Add(new ListItem("Vandalised", "Vandalised"));
        ddlCondition.Items.Add(new ListItem("Damaged", "Damaged"));
    }
}