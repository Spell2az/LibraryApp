using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FineCollection
/// </summary>
public class FineCollection
{
    private DataConnection _dc;
    public Fine Fine { get; set; } = new Fine();
    private string _borrowerId;
    public FineCollection()
    {
        
    }
    public FineCollection(string borrowerId)
    {
        //
        // TODO: Add constructor logic here
        //
        _borrowerId = borrowerId;
        FilterFinesByBorrower(borrowerId);
    }

    public List<Fine> FineList => (from DataRow row in _dc.DataTable.Rows select new Fine
    {
        FineId = row["fine_id"].ToString(),
        FineDate = Convert.ToDateTime(row["fine_date"]),
        FineAmount = Convert.ToDecimal(row["fine_amount"]),
        FineStatus = row["fine_status"].ToString(),
        BorrowerId = row["fk1_bor_id"].ToString(),
        LoanId = row["fk2_loan_id"].ToString()
    }).ToList();


    public void FilterFinesByBorrower(string borrowerId)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@bor_id", borrowerId);
        _dc.Execute("sproc_GetFinesByBorrower");
    }

    public List<Dictionary<string, string>>  FinesWithPayments()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@bor_id", _borrowerId);
        _dc.Execute("sproc_GetFinesWithPaymentsByBorrower");

        var data = new List<Dictionary<string, string>>();
        if (_dc.Count == 0) return data;

        foreach (DataRow row in _dc.DataTable.Rows)
        {
            var temp = new Dictionary<string, string>
            {
                { "fineDate", Convert.ToDateTime(row["fine_date"]).ToString("dd/MMMM/yyyy") },
                { "fineAmount", Convert.ToDecimal(row["fine_amount"]).ToString("C")},
                { "paymentDate", Convert.ToDateTime(row["pmt_date"]).ToString("dd/MMMM/yyyy") },
                { "paymentAmount", Convert.ToDecimal(row["pmt_amount"]).ToString("C")},
                { "loanType", row["cop_loan_type"].ToString() },
                { "loanId", row["loan_id"].ToString() },
                { "title", row["bk_title"].ToString() }

            };

            data.Add(temp);
        }

        return data;
    }
}