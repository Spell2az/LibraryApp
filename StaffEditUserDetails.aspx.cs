using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffEditUserDetails : System.Web.UI.Page
{
   
        protected void Page_Load(object sender, EventArgs e)
        {
            var account = new Borrower();
            txtUserId.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            if (account.Find(Request.QueryString["id"]))
            {
                if (!Page.IsPostBack)
                {
                    txtUserId.Text = account.BorrowerId;
                    txtFirstName.Text = account.FirstName;
                    txtLastName.Text = account.LastName;
                    txtAddress1.Text = account.Address1;
                    txtAddress2.Text = account.Address2;
                    txtAddress3.Text = account.Address3;
                    txtTel.Text = account.TelNumber;
                    txtEmail.Text = account.Email;
                }
            }
        }

        protected void HandlerSaveDetails(object sender, EventArgs e)
        {
            var accounts = new BorrowerCollection();
            var account = accounts.Borrower;
            account.Find(txtUserId.Text);
            account.Address1 = txtAddress1.Text;
            account.Address2 = txtAddress2.Text;
            account.Address3 = txtAddress3.Text;
            account.TelNumber = txtTel.Text;
            account.Email = txtEmail.Text;

            accounts.Update();
        }

        protected void HandlerCancelDetailsView(object sender, EventArgs e)
        {
            Response.Redirect("UserAccounts.aspx");
        }

}