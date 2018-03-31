using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookView : System.Web.UI.Page
{
    private string _isbn;
    protected void Page_Load(object sender, EventArgs e)
    {
        _isbn = Request.QueryString["isbn"];

        if (!string.IsNullOrEmpty(_isbn))
        {
            var book = new Book();
            book.Find(_isbn);
            lblIsbn.Text = book.Isbn;
            lblTitle.Text = book.Title;
            lblAuthor.Text = book.Author;
            lblPublisher.Text = book.Publisher;
            lblPubYear.Text = book.PubYear;
            lblEdition.Text = book.Edition.ToString();
            lblGenre.Text = book.GetGenreDescription(book.GenreCode);


            
            var bookCopies = new BookCopyCollection(_isbn).BookCopies;
            var loans = new LoanCollection();
            loans.FilterActiveLoansByIsbn(_isbn);
            DataTable copyDisplay = new DataTable();
            var list =  loans.LoanList;
            copyDisplay.Columns.Add("Barcode", typeof(string));
            copyDisplay.Columns.Add("Shelf", typeof(string));
            copyDisplay.Columns.Add("LoanType", typeof(string));
            copyDisplay.Columns.Add("Status", typeof(string));
            List<bool> copyAvailability = new List<bool>();
            int copiesAvailable = 0;
            foreach (var bookCopy in bookCopies)
            {
                DataRow row = copyDisplay.NewRow();
                row["Barcode"] = bookCopy.Barcode;
                row["Shelf"] = book.ShelfNo;
                row["LoanType"] = bookCopy.LoanType;
                var activeLoan =
                    loans.LoanList.Find(loan => loan.CopyBarcode.Trim() == bookCopy.Barcode.Trim());
                var isReservable = activeLoan != null;
                row["Status"] = !isReservable 
                    ? "Available" 
                    : activeLoan.LoanDueDate < DateTime.Now 
                        ? $"Overdue (was due back {activeLoan.LoanDueDate.ToString("d MMMM")})" 
                        : $"Due on {activeLoan.LoanDueDate.ToString("d MMMM yyyy")}";
                copyDisplay.Rows.Add(row);
                copiesAvailable += !isReservable ? 1 : 0;
                copyAvailability.Add(isReservable && bookCopy.LoanType.Contains("Normal"));
            }

            btnReserve.Enabled = copyAvailability.Exists(available => available) && copyDisplay.Rows.Count != 0;
            lblAvailableCopy.Text = $"{copiesAvailable} copy/copies available at {book.ShelfNo}";
            rptBookCopies.DataSource = copyDisplay;
            rptBookCopies.DataBind();
        }
    }
}