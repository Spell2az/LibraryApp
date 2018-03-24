using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Genre
/// </summary>
public class Genre
{
    public string GenreCode { get; set; }
    public string Description { get; set; }
    public Genre()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Genre(string genreCode, string description)
    {
        GenreCode = genreCode;
        Description = description;
    }

    public string GetDescription(string code)
    {
        var dc = new DataConnection();
        dc.AddParameter("@genre_code", code);
        dc.Execute("sproc_GetGenreByCode");
        return dc.DataTable.Rows[0]["genre_descript"].ToString();
    }

    public bool Find(string genreCode)
    {
        var dc = new DataConnection();
        dc.AddParameter("@genre_code", genreCode);
        dc.Execute("sproc_GetGenreByCode");

        if (dc.Count != 1) return false;

        var row = dc.DataTable.Rows[0];
        GenreCode = row["genre_code"].ToString();
        Description = row["genre_descript"].ToString();
        return true;
    }
}