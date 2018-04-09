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
    
    //private field of type data connection(makes data connection available between mehtods)
    private DataConnection _dc = new DataConnection();
    //book copy property - used to update and add records
    public BookCopy BookCopy { get; set; } = new BookCopy();
    public BookCopyCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //second constructor, calls filter method with provided isbn argument
    public BookCopyCollection(string isbn)
    {
        FilterCopiesByIsbn(isbn);
    }
    //property which creates list of book copy objects from data table property rows of a data connection,
    public List<BookCopy> BookCopies => (from DataRow row in _dc.DataTable.Rows
        select new BookCopy
        {
            Barcode = row["cop_barcode"].ToString(),
            LoanType= row["cop_loan_type"].ToString(),
            Status = row["cop_status"].ToString(),
            Condition = row["cop_condition"].ToString(),
            CopyIsbn = row["fk1_isbn"].ToString()
        }).ToList();

    //Calls stored procedure with supplied barcode and deletes corresponding record from a db
    public void Delete(string barcode)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@cop_barcode", barcode);
        _dc.Execute("sproc_DeleteBookCopy");
    }
    //Updates record in the book copy table in db.
    public void Update()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@cop_barcode", BookCopy.Barcode);
        _dc.AddParameter("@cop_loan_type", BookCopy.LoanType);
        _dc.AddParameter("@cop_status", BookCopy.Status);
        _dc.AddParameter("@cop_condition", BookCopy.Condition);
        
        _dc.Execute("sproc_UpdateBookCopy");
    }
    //Adds book copy record to the book table in db. 
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
    //Filters records in book copy table by isbn
    public void FilterCopiesByIsbn(string isbn)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@isbn", isbn);
        _dc.Execute("sproc_FilterBookCopyByIsbn");
    }

}