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
        books.FilerBookBy("");
        rptBookDisplay.DataSource = books.BookList;
        rptBookDisplay.DataBind();

    }

    protected void GoToEditBook(object sender, EventArgs e)
    {
        var source = sender as Button;
        string isbn = null;

        if (source != null)
        {
            isbn = source.CommandArgument;
        }
        Response.Redirect($"BookEdit.aspx?isbn={isbn}");
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
}