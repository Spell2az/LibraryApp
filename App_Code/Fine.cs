using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Fine
/// </summary>
public class Fine
{
    //Create properties reflecting attributes of a records in a fine table
    public string FineId { get; set; }
    public DateTime FineDate { get; set; }
    public decimal FineAmount { get; set; }
    public string FineStatus { get; set; }
    public string BorrowerId { get; set; }
    public string LoanId { get; set; }
    public Fine()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //Find fine record with corresponding fine id
    public bool Find(string fineId)
    {
        //Connection to the database
        var dc = new DataConnection();
        //Pass parameter to the stored procedure
        dc.AddParameter("@fine_id", fineId);
        //Execute stored procedure
        dc.Execute("sproc_GetFineById");
        //If returned results don't contain exactly one record return false
        if (dc.Count != 1) return false;
        //returned exactly one record
        var row = dc.DataTable.Rows[0];
        //Sets object properties to coresponding columns returned from db and returns true
        FineId = row["fine_id"].ToString();
        FineDate = Convert.ToDateTime(row["fine_date"]);
        FineAmount = Convert.ToDecimal(row["fine_amount"]);
        FineStatus = row["fine_status"].ToString();
        BorrowerId = row["fk1_bor_id"].ToString();
        LoanId = row["fk2_loan_id"].ToString();

        return true;

    }
    //Gets title of a book which fine was issued for by loan id 
    public string GetBookTitle(string loanId)
    {
        var loan = new Loan();
        loan.Find(loanId);
        return loan.GetBookTitle(loan.CopyBarcode);
    }
}