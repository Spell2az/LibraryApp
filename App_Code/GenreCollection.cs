using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for GenreCollection
/// </summary>
public class GenreCollection
{
    private DataConnection _dc = new DataConnection();
    public Genre Genre { get; set; } = new Genre();
    public GenreCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Genre> Genres => (from DataRow row in _dc.DataTable.Rows select new Genre
    {
        GenreCode = row["genre_code"].ToString(),
        Description = row["genre_descript"].ToString()
    }).ToList();
        

    public void Delete(string genreCode)
    {
        var dc = new DataConnection();
        dc.AddParameter("@genre_code", genreCode);
        dc.Execute("sproc_DeleteGenre");
    }

    public void Update(string genreCode, string genreDescription)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@genre_code", genreCode);
        _dc.AddParameter("@genre_description", genreDescription);
        _dc.Execute("sproc_UpdateGenre");
    }

    public void Add(string genreCode, string genreDescription)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@genre_code", genreCode);
        _dc.AddParameter("@genre_description", genreDescription);
        _dc.Execute("sproc_AddGenre");
    }

    public void FilterGenre(string genreCode)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@genre_code", genreCode);
        _dc.Execute("sproc_FilterGenreByCode");
    }
}