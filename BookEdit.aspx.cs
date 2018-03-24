using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookEdit : System.Web.UI.Page
{
    private string _bookIsbn;
    private bool _isNew;
    protected void Page_Load(object sender, EventArgs e)
    {

        _bookIsbn = Request.QueryString["isbn"];
        _isNew = Convert.ToBoolean(Request.QueryString["isNew"]);
        if (!Page.IsPostBack)
        {
          
            Response.Write(_isNew);
            FillDropDown();
           
            if (_bookIsbn != null)
            {
                var bookCollection = new BookCollection();
                txtIsbn.Enabled = false;
                if (bookCollection.Book.Find(_bookIsbn))
                {
                    DisplayBookDetails(bookCollection.Book);
                }
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
        txtEdition.Text = book.Edition.ToString();
        ddlGenre.SelectedValue = book.GenreCode;
    }

    private void FillDropDown()
    {
        var genreCollection = new GenreCollection();
        genreCollection.FilterGenre("");
        foreach (var genre in genreCollection.Genres)
        {
            ddlGenre.Items.Add(new ListItem(genre.Description, genre.GenreCode));
        }
        
    }

    protected void HandlerCancelBook(object sender, EventArgs e)
    {
        Response.Redirect("BookManagement.aspx");
    }
    protected void HandlerUpdateBook(object sender, EventArgs e)
    {
        var bookCollection = new BookCollection();
        var book = bookCollection.Book;

        book.Isbn = txtIsbn.Text;
        book.Title = txtTitle.Text;
        book.Author = txtAuthor.Text;
        book.Publisher = txtPublisher.Text;
        book.PubYear = txtPubYear.Text;
        book.ShelfNo = txtShelfNo.Text;
        book.Edition = Convert.ToInt32(txtEdition.Text);
        book.GenreCode = ddlGenre.SelectedValue;

        bool isThere = book.Find(book.Isbn);

        if (_isNew && !isThere)
        {
            bookCollection.Add();
        }
        else if (isThere)
        {
            //Display Error
            ScriptManager.RegisterStartupScript(
                this,
                typeof(Page),
                "Alert",
                "<script>alert('Isbn already exists.');</script>",
                false);
        }
        else
        {
            bookCollection.Update();
        }
    }

  
}