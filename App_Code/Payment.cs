using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Payment
/// </summary>
public class Payment
{
    public string PaymentId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public string BorrowerId { get; set; }
    public string FineId { get; set; }  
    public Payment()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Find(string paymentId)
    {
        var dc = new DataConnection();
        dc.AddParameter("@pmt_id", paymentId);
        dc.Execute("sproc_GetPaymentById");

        if (dc.Count != 1) return false;

        var row = dc.DataTable.Rows[0];

        PaymentId = row["pmt_id"].ToString();
        PaymentDate = Convert.ToDateTime(row["pmt_date"]);
        Amount = Convert.ToDecimal(row["pmt_amount"]);
        BorrowerId = row["fk1_bor_id"].ToString();
        FineId = row["fk2_fine_id"].ToString();

        return true;
    }
}