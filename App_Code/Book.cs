using System;

/// <summary>
/// Summary description for Book
/// </summary>
public class Book
{
    public string Isbn { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public string PubYear { get; set; }
    public string ShelfNo { get; set; }
    public int Edition { get; set; }
    public string GenreCode { get; set; }

    public bool Find(string isbn)
    {
        var dc = new DataConnection();
        dc.AddParameter("@isbn", isbn);
        dc.Execute("sproc_GetBookByIsbn");

        if (dc.Count != 1) return false;

        var row = dc.DataTable.Rows[0];
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

    public string GetGenreDescription(string genreCode)
    {
        var genre = new Genre();
        return genre.GetDescription(genreCode);
    }
}