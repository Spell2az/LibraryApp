using System;

/// <summary>
/// Summary description for Book
/// </summary>
public class Book
{
    //Create properties reflecting attributes of a record in a book table
    public string Isbn { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public string PubYear { get; set; }
    public string ShelfNo { get; set; }
    public int Edition { get; set; }
    public string GenreCode { get; set; }

    //Find book record with corresponding isbn
    public bool Find(string isbn)
    {
        //Connection to the database
        var dc = new DataConnection();
        //Pass parameter to the stored procedure
        dc.AddParameter("@isbn", isbn);
        //Execute stored procedure
        dc.Execute("sproc_GetBookByIsbn");
        //If returned results don't contain exactly one record return false
        if (dc.Count != 1) return false;
        //returned exactly one record
        var row = dc.DataTable.Rows[0];
        //Sets object properties to coresponding columns returned from db and returns true
        Isbn = row["isbn"].ToString();
        Author = row["bk_author"].ToString();
        Title = row["bk_title"].ToString();
        Publisher = row["bk_publisher"].ToString();
        PubYear = row["bk_pub_yr"].ToString();
        ShelfNo = row["bk_shelf_no"].ToString();
        Edition = Convert.ToInt32(row["bk_edition_no"]);
        GenreCode = row["fk1_genre_code"].ToString();
        return true;
    }
    //Gets description of a genre from supplied genrecode. 
    public string GetGenreDescription(string genreCode)
    {
        var genre = new Genre();
        return genre.GetDescription(genreCode);
    }
}