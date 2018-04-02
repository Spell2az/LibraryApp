using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


         var userType = Request.QueryString["user"];
        Session["user"] = userType;
        switch (userType)
        {
            case "manager":
                Response.Redirect("BookManagement.aspx");
                break;
            case "staff":
                Response.Redirect("BookCatalogue.aspx");
                break;
            case "borrower":
                Response.Redirect("BookCatalogue.aspx");
                break;
            default:
                Response.Redirect("Default.aspx");
                break;
            }
       
    }

    protected void HandlerManageBooks(object sender, EventArgs e)
    {
        Response.Redirect("BookManagement.aspx");
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