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

        if (!Page.IsPostBack)
        {
            FillDropDown();
        }
    }

    private void FillDropDown()
    {
        ddlGenre.Items.Clear();
        var genreCollection = new GenreCollection();
        genreCollection.FilterGenre("");
        ddlGenre.Items.Add(new ListItem("...new Genre"));
        foreach (var genre in genreCollection.Genres)
        {
            ddlGenre.Items.Add(new ListItem(genre.Description, genre.GenreCode));
        }

    }

    

    
    
    protected void HanlderSaveUpdateGenre(object sender, EventArgs e)
    {
        var genres = new GenreCollection();
        var genre = genres.Genre;
        genre.GenreCode = txtGenreCode.Text;
        genre.Description = txtGenreDescription.Text;
        if (ddlGenre.SelectedIndex==0)
        {

            if (!genre.Find(txtGenreCode.Text))
            {
                genres.Add();
                FillDropDown();
            }
            else
            {
                Response.Write("This Genre Code is not available please enter different genre code");
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
        Response.Redirect("Default.aspx");
    }

    protected void HandlerGenreSelected(object sender, EventArgs e)
    {
        if (ddlGenre.SelectedIndex == 0)
        {
            txtGenreCode.Enabled = true;
            txtGenreCode.Text = "";
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