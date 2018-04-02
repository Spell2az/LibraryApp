using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void PreInit(object sender, EventArgs e)
    {
        //update 
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
          // var userType = Request.QueryString["user"];
        var userType= Session["user"].ToString();
     



        switch (userType)
        {
            case "manager":
                menuManager.Visible = true;
                break;
            case "staff":
                menuStaff.Visible = true;
                break;
            default:
                menuBorrower.Visible = true;
                break;
        }
    }


    protected void HanlerLogout(object sender, EventArgs e)
    {
      
        Response.Redirect("Default.html");
    }
}
