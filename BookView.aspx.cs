using System;
using System.Collections.Generic;
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

        }
    }
}