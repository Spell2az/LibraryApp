using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var bookIsbn = Request.QueryString["isbn"];
        var newBool = Request.QueryString["isNew"];

        if (bookIsbn != null)
        {
            var bookCollection = new BookCollection();

            if (bookCollection.Book.Find(bookIsbn))
            {
                DisplayBookDetails(bookCollection.Book);
            }
        }
    }

    private void DisplayBookDetails(Book book)
    {
        txtIsbn.Text = book.Isbn;
        txtTitle.Text = book.Title;
        txtAuthor.Text = book.Author;
        txtPublisher.Text = book.Publisher;
        txtPubYear.Text = book.PubYear;
        txtShelfNo.Text = book.ShelfNo;
        txtEdition.Text = book.Edition;
    }

    private void FillDropDown(string select)
    {
        
    }
}