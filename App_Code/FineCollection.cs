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
    //private field of type data connection(makes data connection available between mehtods)
    private DataConnection _dc;
    //fine property - used to update and add records
    public Fine Fine { get; set; } = new Fine();
    private string _borrowerId;
    public FineCollection()
    {
        
    }
    //Second constructor for creating fine collection for borrower
    public FineCollection(string borrowerId)
    {
        //
        // TODO: Add constructor logic here
        //
        _borrowerId = borrowerId;
        FilterFinesByBorrower(borrowerId);
    }
    //property which creates list of fine objects from data table property of a data connection,
    // must be accessed after calling filter otherwise list is empty
    public List<Fine> FineList => (from DataRow row in _dc.DataTable.Rows select new Fine
    {
        FineId = row["fine_id"].ToString(),
        FineDate = Convert.ToDateTime(row["fine_date"]),
        FineAmount = Convert.ToDecimal(row["fine_amount"]),
        FineStatus = row["fine_status"].ToString(),
        BorrowerId = row["fk1_bor_id"].ToString(),
        LoanId = row["fk2_loan_id"].ToString()
    }).ToList();

    //Filters fines by borrower id
    public void FilterFinesByBorrower(string borrowerId)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@bor_id", borrowerId);
        _dc.Execute("sproc_GetFinesByBorrower");
    }
    //Creates a list of type dictionary which holds information about fines with payments
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
                { "fineDate", Convert.ToDateTime(row["fine_date"]).ToString("dd MMMM yyyy") },
                { "fineAmount", Convert.ToDecimal(row["fine_amount"]).ToString("C")},
                { "paymentDate", Convert.ToDateTime(row["pmt_date"]).ToString("dd MMMM yyyy") },
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