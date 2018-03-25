using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookCopies : System.Web.UI.Page
{
    private string _bookIsbn;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        _bookIsbn = Request.QueryString["isbn"];
       

        if (_bookIsbn != null)
        {
            GetBookDetails(_bookIsbn);
            var copies = new BookCopyCollection();
            copies.FilterCopiesByIsbn(_bookIsbn);
            rptBookCopy.DataSource = copies.BookCopies;
            rptBookCopy.DataBind();
        }

    }

    private void GetBookDetails(string isbn)
    {
        var books = new BookCollection();
        var book = books.Book;
        book.Find(isbn);
        txtIsbn.Text = book.Isbn;
        txtAuthor.Text = book.Author;
        txtTitle.Text = book.Title;
        txtGenre.Text = book.GetGenreDescription(book.GenreCode);
        txtPublisher.Text = book.Publisher;
        txtShelf.Text = book.ShelfNo;
        txtYear.Text = book.PubYear;
        txtEdition.Text = book.Edition.ToString();
    }

    protected void HandlerAddBookCopy(object sender, EventArgs e)
    {
        Response.Redirect("BookCopyEdit.aspx?isNew=true");
    }
    protected void HandlerEditBookCopy(object sender, EventArgs e)
    {
        var source = sender as Button;
        string barcode = null;
        if (source != null)
        {
            barcode = source.CommandArgument;
        }
        Response.Redirect($"BookCopyEdit.aspx?barcode={barcode}");
    }

    protected void HandlerDeleteBookCopy(object sender, EventArgs e)
    {
        var source = sender as Button;
        var books = new BookCollection();

        if (source != null)
        {
            var barcode = source.CommandArgument;

            if (books.Book.Find(barcode))
            {
                books.Delete(barcode);
                rptBookCopy.DataBind();
            }
        }
    }

}