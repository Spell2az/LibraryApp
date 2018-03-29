using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Loan
/// </summary>
public class Loan
{
    public string LoanId { get; set; }
    public DateTime LoanIssueDate { get; set; }
    public DateTime LoanDueDate { get; set; }
    public DateTime? LoanReturnDate { get; set; } = null;
    public string CopyBarcode { get; set; }
    public string BorrowerId { get; set; }

    public Loan()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Find(string loanId)
    {
        var dc = new DataConnection();
        dc.AddParameter("@loan_id", loanId);
        dc.Execute("sproc_GetLoanById");

        if (dc.Count != 1) return false;

        var row = dc.DataTable.Rows[0];
        LoanId = row["loan_id"].ToString();
        LoanIssueDate = Convert.ToDateTime(row["loan_issue_date"]);
        LoanDueDate = Convert.ToDateTime(row["loan_due_date"]);

        var isDate = DBNull.Value.Equals(row["loan_return_date"]);
        if (!isDate)
        {
            LoanReturnDate = Convert.ToDateTime(row["loan_return_date"]);
        }
        CopyBarcode = row["fk1_cop_barcode"].ToString();
        BorrowerId = row["fk2_bor_id"].ToString();

        return true;
    }

}