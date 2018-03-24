using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;

/// <summary>
/// Summary description for BookCopyCollection
/// </summary>
public class BookCopyCollection
{
    private DataConnection _dc = new DataConnection();
    public BookCopy BookCopy { get; set; } = new BookCopy();
    public BookCopyCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<BookCopy> BookCopies => (from DataRow row in _dc.DataTable.Rows
        select new BookCopy
        {
            Barcode = row["cop_barcode"].ToString(),
            LoanType= row["cop_loan_type"].ToString(),
            Status = row["cop_status"].ToString(),
            Condition = row["cop_condition"].ToString(),
            CopyIsbn = row["fk1_isbn"].ToString()
        }).ToList();

    public void Delete(string barcode)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@cop_barcode", barcode);
        _dc.Execute("sproc_DeleteBookCopy");
    }

    public void Update()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@cop_barcode", BookCopy.Barcode);
        _dc.AddParameter("@cop_loan_type", BookCopy.LoanType);
        _dc.AddParameter("@cop_status", BookCopy.Status);
        _dc.AddParameter("@cop_condition", BookCopy.Condition);
        _dc.AddParameter("@fk1_isbn", BookCopy.CopyIsbn);
        _dc.Execute("sproc_UpdateBookCopy");
    }

    public void Add()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@cop_barcode", BookCopy.Barcode);
        _dc.AddParameter("@cop_loan_type", BookCopy.LoanType);
        _dc.AddParameter("@cop_status", BookCopy.Status);
        _dc.AddParameter("@cop_condition", BookCopy.Condition);
        _dc.AddParameter("@fk1_isbn", BookCopy.CopyIsbn);
        _dc.Execute("sproc_AddBookCopy");
    }

    public void Filter(string barcode)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@cop_barcode", barcode);
        _dc.Execute("sproc_FilterBookCopyByBarcode");
    }

}