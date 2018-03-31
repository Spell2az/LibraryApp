using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FinePayment : System.Web.UI.Page
{
    private string _fineId;
    protected void Page_Load(object sender, EventArgs e)
    {
        _fineId = Request.QueryString["fineId"];
        var fine = new Fine();
        if (!string.IsNullOrEmpty(_fineId))
        {
            fine.Find(_fineId);
            lblTotalAmount.Text = $"Total: {fine.FineAmount.ToString("C")}";
        }
    }

    protected void HandlerProcessPayment(object sender, EventArgs e)
    {
        var payments = new PaymentCollection();
        var idGen = new IdGenerator();
        var fine = new Fine();
        fine.Find(_fineId);
        var payment = payments.Payment;
        payment.Amount = fine.FineAmount;
        payment.BorrowerId = fine.BorrowerId;
        payment.FineId = fine.FineId;
        payment.PaymentId = idGen.PaymentId();

        payments.AddPayment();
        Response.Redirect("BorrowerArea.aspx");

    }
}