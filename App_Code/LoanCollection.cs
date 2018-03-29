using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoanCollection
/// </summary>
public class LoanCollection
{
    private DataConnection _dc;
    public Loan Loan { get; set; } = new Loan();
    public LoanCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public LoanCollection(string borrowerId)
    {
        FilterLoansByBorrower(borrowerId);
    }

    public List<Loan> LoanList => (from DataRow row in _dc.DataTable.Rows select new Loan
    {
        LoanId = row["loan_id"].ToString(),
        LoanIssueDate = Convert.ToDateTime(row["loan_issue_date"]),
        LoanDueDate = Convert.ToDateTime(row["loan_due_date"]),
        LoanReturnDate = DBNull.Value.Equals(row["loan_return_date"]) ? (DateTime?)null : Convert.ToDateTime(row["loan_return_date"]),
        CopyBarcode = row["fk1_cop_barcode"].ToString(),
        BorrowerId = row["fk2_bor_id"].ToString()
        }).ToList();

    public void FilterLoansByBorrower(string borrowerId)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@bor_id", borrowerId);
        _dc.Execute("sproc_GetLoansByBorrower");
    }
}