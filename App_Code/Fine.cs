using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Fine
/// </summary>
public class Fine
{
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

    public bool Find(string fineId)
    {
        var dc = new DataConnection();
        dc.AddParameter("@fine_id", fineId);
        dc.Execute("sproc_GetFineById");

        if (dc.Count != 1) return false;

        var row = dc.DataTable.Rows[0];

        FineId = row["fine_id"].ToString();
        FineDate = Convert.ToDateTime(row["fine_date"]);
        FineAmount = Convert.ToDecimal(row["fine_amount"]);
        FineStatus = row["fine_status"].ToString();
        BorrowerId = row["fk1_bor_id"].ToString();
        LoanId = row["fk2_loan_id"].ToString();

        return true;

    }
}