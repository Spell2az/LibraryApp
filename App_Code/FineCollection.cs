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

    public FineCollection()
    {
        
    }
    public FineCollection(string borrowerId)
    {
        //
        // TODO: Add constructor logic here
        //
        FilterLoansByBorrower(borrowerId);
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


    public void FilterLoansByBorrower(string borrowerId)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@bor_id", borrowerId);
        _dc.Execute("sproc_GetFinesByBorrower");
    }
}