using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var books = new BookCollection();
        books.FilerBookByIsbn("");
        rptBookDisplay.DataSource = books.BookList;
        rptBookDisplay.DataBind();
        FillDropDown();
    }

    protected void GoToEditBook(object sender, EventArgs e)
    {
        var source = sender as Button;
        string isbn = null;

        if (source != null)
        {
            isbn = source.CommandArgument;
        }
        Response.Redirect($"BookEdit.aspx?isbn={isbn}&isNew=false");
    }

    protected void GoToBookCopies(object sender, EventArgs e)
    {
        var source = sender as Button;
        string isbn = null;
        if (source != null)
        {
            isbn = source.CommandArgument;
        }
        Response.Redirect($"BookCopies.aspx?isbn={isbn}");
    }

    protected void HandlerAddNewBook(object sender, EventArgs e)
    {
        Response.Redirect("BookEdit.aspx?isNew=true");
    }

    protected void HandlerDeleteBook(object sender, EventArgs e)
    {
        var source = sender as Button;
        string isbn = null;
        var books = new BookCollection();

        if (source != null)
        {
            isbn = source.CommandArgument;

            if (books.Book.Find(isbn))
            {
                books.Delete(isbn);
                rptBookDisplay.DataBind();
            }
        }
    }

    private void FillDropDown()
    {
        var genreCollection = new GenreCollection();
        genreCollection.FilterGenre("");
        ddlGenre.Items.Add(new ListItem("...Any", ""));
        foreach (var genre in genreCollection.Genres)
        {
            ddlGenre.Items.Add(new ListItem(genre.Description, genre.GenreCode));
        }

    }

    protected void HandlerSearchBooks(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected void HandlerClearSearch(object sender, EventArgs e)
    {
        txtIsbn.Text = "";
        txtTitle.Text = "";
        txtAuthor.Text = "";
        txtPublisher.Text = "";
        txtYear.Text = "";
        ddlGenre.SelectedValue = "";
    }
}