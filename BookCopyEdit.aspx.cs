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
    private string _isbn;
    protected void Page_Load(object sender, EventArgs e)
    {


        _copyBarcode = Request.QueryString["barcode"];
        _isNew = Convert.ToBoolean(Request.QueryString["isNew"]);
        _isbn = Request.QueryString["isbn"];
        txtBarcode.Enabled = false;
        if (!Page.IsPostBack)
        {
            FillDropDowns();
            if (_copyBarcode != null)
            {
                var bookCopyCollection = new BookCopyCollection();
                
                if (bookCopyCollection.BookCopy.Find(_copyBarcode))
                {
                    DisplayCopyDetails(bookCopyCollection.BookCopy);
                }
            }

            if (_isNew)
            {
                var idGen = new IdGenerator();
                txtBarcode.Text = idGen.BookCopy();
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
        var copies = new BookCopyCollection();
        var copy = copies.BookCopy;
        var copyCheck = new BookCopy();
       

        bool isThere = copyCheck.Find(txtBarcode.Text);
        copy.Barcode = txtBarcode.Text;
        copy.Barcode = txtBarcode.Text;
        copy.LoanType = ddlLoanType.SelectedValue;
        copy.Status = ddlStatus.SelectedValue;
        copy.Condition = ddlCondition.SelectedValue;
        copy.CopyIsbn = _isbn;
        

        

        if (_isNew && !isThere)
        {
            copies.Add();
        }
        else if (isThere && _isNew)
        {
            //Display Error
            ScriptManager.RegisterStartupScript(
                this,
                typeof(Page),
                "Alert",
                "<script>alert('Barcode already exists.');</script>",
                false);
        }
        else
        {
            copies.Update();
        }
    }

    protected void HandlerCancelCopyEdit(object sender, EventArgs e)
    {
        Response.Redirect($"BookCopies.aspx?isbn={_isbn}");
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