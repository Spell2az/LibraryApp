<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        context.Response.Write("Hello World");

        string id = context.Request.Form["borrowerId"];
        string email = context.Request.Form["borrowerEmail"];
        var borrower = new Borrower();
        if (borrower.Find(id))
        {
            if (borrower.Email.Trim() == email)
            {
                context.Response.Redirect($"Default.aspx?id={id}&email={email}");
            }
        }
        else
        {
            context.Response.Redirect($"Default.html");
        }

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}