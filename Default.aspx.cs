﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void HandlerManageBooks(object sender, EventArgs e)
    {
        Response.Redirect("BookManagement.aspx");
    }

    protected void HandlerEditGenre(object sender, EventArgs e)
    {
        Response.Redirect("EditGenre.aspx");
    }

    protected void HandlerGoToBorrowerArea(object sender, EventArgs e)
    {
        Response.Redirect("BorrowerArea.aspx");
    }

    protected void HandlerViewStudentAccounts(object sender, EventArgs e)
    {
        Response.Redirect("BorrowerAccounts.aspx");
    }

    protected void HandlerViewBookCatalogue(object sender, EventArgs e)
    {
        Response.Redirect("BookCatalogue.aspx");
    }
}