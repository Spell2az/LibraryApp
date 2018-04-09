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
    //private field of type data connection(makes data connection available between mehtods)
    private DataConnection _dc;
    //book property - used to update and add records
    public Book Book { get; set; } = new Book();
    public BookCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //property which creates list of book objects from data table property of a data connection,
    // must be accessed after calling filter otherwise list is empty
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

    //Adds book record to the book table in db. 
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
    //Calls stored procedure with supplied isbn and deletes corresponding record from a db
    public void Delete(string isbn)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@isbn", isbn);
        _dc.Execute("sproc_DeleteBook");
    }
    //Updates record in the book table in db.
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
    //Filters records in book table by isbn
    public void FilerBookByIsbn(string isbn)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@isbn", isbn);
        _dc.Execute("sproc_FilterBookByIsbn");
    }
    //filters book records by isbn, title, author, publisher, year and genre code
    public List<Book> FilterBooksByAll(string isbn, string title, string author, string publisher, string year,
        string genreCode)
    {
        year = year.Length == 0 ? null : year;
             
        _dc = new DataConnection();
        _dc.AddParameter("@isbn", isbn);
        _dc.AddParameter("@bk_author", author);
        _dc.AddParameter("@bk_title", title);
        _dc.AddParameter("@bk_pub_yr", year);
        _dc.AddParameter("@bk_publisher", publisher);
        _dc.AddParameter("@fk1_genre_code", genreCode);
        _dc.Execute("sproc_FilterBooksByAll");

        //if no rows are returned from a querie return empty list ,else return book list
        return _dc.Count == 0 ? new List<Book>() : BookList;
    }
}