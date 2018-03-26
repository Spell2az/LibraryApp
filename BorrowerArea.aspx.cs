using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BorrowerArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void HadnlerGoToDetails(object sender, EventArgs e)
    {
        Response.Redirect("UserDetails.aspx");
    }
}