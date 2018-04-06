using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditGenre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtGenreCode.Enabled = false;
        if (!Page.IsPostBack)
        {
            FillDropDown();
        }
    }

    private void FillDropDown()
    {
        ddlGenre.Items.Clear();
        txtGenreDescription.Text = "";
        var idGen = new IdGenerator();

        var genreCollection = new GenreCollection();
        genreCollection.FilterGenre("");
        var newGenreCode = idGen.GenreId();
        ddlGenre.Items.Add(new ListItem("...new Genre", newGenreCode));
        foreach (var genre in genreCollection.Genres)
        {
            ddlGenre.Items.Add(new ListItem(genre.Description, genre.GenreCode));
        }
        txtGenreCode.Text = ddlGenre.SelectedValue;
    }

    

    
    
    protected void HanlderSaveUpdateGenre(object sender, EventArgs e)
    {
        var genres = new GenreCollection();
        var genre = genres.Genre;
        genre.GenreCode = txtGenreCode.Text;
        genre.Description = txtGenreDescription.Text;
        if (ddlGenre.SelectedIndex==0)
        {

            if (txtGenreDescription.Text.Trim() != "")
            {
                genres.Add();
                FillDropDown();
            }
            
        }
        else
        {
            genres.Update();
            FillDropDown();
        }
    }

    protected void HanlderCancelUpdateGenre(object sender, EventArgs e)
    {
        Response.Redirect("BookManagement.aspx");
    }

    protected void HandlerGenreSelected(object sender, EventArgs e)
    {
        if (ddlGenre.SelectedIndex == 0)
        {

            txtGenreCode.Text = ddlGenre.SelectedValue;
            txtGenreDescription.Text = "";
        }
        else
        {
            txtGenreCode.Enabled = false;
            txtGenreCode.Text = ddlGenre.SelectedValue;
            txtGenreDescription.Text = ddlGenre.Items.FindByValue(ddlGenre.SelectedValue).Text;
        }
    }
}