using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentCollection
/// </summary>
public class PaymentCollection
{
    private DataConnection _dc;
    public Payment Payment { get; set; } = new Payment();
    private string _borrowerId;
    public PaymentCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public PaymentCollection(string borrowerId)
    {
        _borrowerId = borrowerId;
        FilterPaymentsByBorrower(borrowerId);
    }

    public List<Payment> PaymentList => (from DataRow row in _dc.DataTable.Rows select new Payment
    {
        PaymentId = row["pmt_id"].ToString(),
        PaymentDate = Convert.ToDateTime(row["pmt_date"]),
        Amount = Convert.ToDecimal(row["pmt_amount"]),
        BorrowerId = row["fk1_bor_id"].ToString(),
        FineId = row["fk2_fine_id"].ToString()
    }).ToList();

    public void FilterPaymentsByBorrower(string borrowerId)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@bor_id", borrowerId);
        _dc.Execute("sproc_GetPaymentsByBorrower");
    }

    public void AddPayment()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@pmt_id", Payment.PaymentId);
        _dc.AddParameter("@pmt_date", DateTime.Now);
        _dc.AddParameter("@pmt_amount", Payment.Amount);
        _dc.AddParameter("@fk1_bor_id", Payment.BorrowerId);
        _dc.AddParameter("@fk2_fine_id", Payment.FineId);
        _dc.Execute("sproc_AddPayment");
    }
}