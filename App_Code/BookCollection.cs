using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookCollection
/// </summary>
public class BookCollection
{
    private DataConnection _dc;
    public Book Book { get; set; } = new Book();
    public BookCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Book> BookList => (from DataRow row in _dc.DataTable.Rows select new Book
    {
        Isbn = row["isbn"].ToString(),
        Author = row["bk_author"].ToString(),
        Title = row["bk_title"].ToString(),
        PubYear = row["bk_pub_yr"].ToString(),
        Publisher = row["bk_publisher"].ToString(),
        ShelfNo = row["bk_shelf_no"].ToString(),
        Edition = Convert.ToInt32(row["bk_edition_no"]),
        GenreCode = row["fk1_genre_code"].ToString()
    }).ToList();

    public void Add()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@isbn", Book.Isbn);
        _dc.AddParameter("@bk_author", Book.Author);
        _dc.AddParameter("@bk_title", Book.Title);
        _dc.AddParameter("@bk_pub_yr", Book.PubYear);
        _dc.AddParameter("@bk_publisher", Book.Publisher);
        _dc.AddParameter("@bk_shelf_no", Book.ShelfNo);
        _dc.AddParameter("@bk_edition_no", Book.Edition);
        _dc.AddParameter("@fk1_genre_code", Book.GenreCode);
        _dc.Execute("sproc_AddBook");
    }
    public void Delete(string isbn)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@isbn", isbn);
        _dc.Execute("sproc_DeleteBook");
    }
    public void Update()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@isbn", Book.Isbn);
        _dc.AddParameter("@bk_author", Book.Author);
        _dc.AddParameter("@bk_title", Book.Title);
        _dc.AddParameter("@bk_pub_yr", Book.PubYear);
        _dc.AddParameter("@bk_publisher", Book.Publisher);
        _dc.AddParameter("@bk_shelf_no", Book.ShelfNo);
        _dc.AddParameter("@bk_edition_no", Book.Edition);
        _dc.AddParameter("@fk1_genre_code", Book.GenreCode);
        _dc.Execute("sproc_UpdateBook");
    }

    public void FilerBookByIsbn(string isbn)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@isbn", isbn);
        _dc.Execute("sproc_FilterBookByIsbn");
    }

    public List<Book> FilterBooksByAll(string isbn, string title, string author, string publisher, string year,
        string genreCode)
    {
        _dc.AddParameter("@isbn", isbn);
        _dc.AddParameter("@bk_author", author);
        _dc.AddParameter("@bk_title", title);
        _dc.AddParameter("@bk_pub_yr", year);
        _dc.AddParameter("@bk_publisher", publisher);
        _dc.AddParameter("@fk1_genre_code", genreCode);
        _dc.Execute("sproc_FilterBooksByAll");

        return _dc.Count == 0 ? new List<Book>() : BookList;
    }
}