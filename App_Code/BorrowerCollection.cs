using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BorrowerCollection
/// </summary>
public class BorrowerCollection
{
    //private field of type data connection(makes data connection available between mehtods)
    private DataConnection _dc;
    //borrower property - used to update and add records
    public Borrower Borrower { get; set; } = new Borrower();

    public BorrowerCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //property which returns list of borrower objects from data table property of a data connection,
    // must be accessed after calling filter otherwise list is empty
    public List<Borrower> BorrowerList => (from DataRow row in _dc.DataTable.Rows
        select new Borrower
        {
            BorrowerId = row["bor_id"].ToString(),
            BorrowerType = row["fk1_bor_type_id"].ToString(),
            FirstName = row["bor_firstname"].ToString(),
            LastName = row["bor_surname"].ToString(),
            Address1 = row["bor_address_1"].ToString(),
            Address2 = row["bor_address_2"].ToString(),
            Address3 = row["bor_address_3"].ToString(),
            TelNumber = row["bor_tel"].ToString(),
            Email = row["bor_email"].ToString(),
            Status = row["bor_status"].ToString()

        }).ToList();

    public void FilterBorrowerById(string id)
    {
        _dc= new DataConnection();
        _dc.AddParameter("@bor_id", id);
        _dc.Execute("sproc_FilterBorrowerById");

    }

    //Updates record in the book table in db.
    public void Update()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@bor_id", Borrower.BorrowerId);
        _dc.AddParameter("@fk1_bor_type_id", Borrower.BorrowerType);
        _dc.AddParameter("@bor_firstname", Borrower.FirstName);
        _dc.AddParameter("@bor_surname", Borrower.LastName);
        _dc.AddParameter("@bor_address_1", Borrower.Address1);
        _dc.AddParameter("@bor_address_2", Borrower.Address2);
        _dc.AddParameter("@bor_address_3", Borrower.Address3);
        _dc.AddParameter("@bor_tel", Borrower.TelNumber);
        _dc.AddParameter("@bor_email", Borrower.Email);
        _dc.AddParameter("@bor_status", Borrower.Status);
        _dc.Execute("sproc_UpdateBorrower");
    }
    //filters borrower records by borrower id, first and last name
    public void FilterByFirstAndLastNameAndId(string borrowerId, string firstName, string lastName)
    {
        _dc = new DataConnection();
        //firstName = "" == firstName ? "" : firstName.Trim();
        //lastName = "" == lastName ? "" : lastName.Trim();
        //borrowerId = "" == borrowerId ? "" : borrowerId.Trim();
        //var fullName = firstName + " " + lastName;
        _dc.AddParameter("@fullName", firstName + " " + lastName);
        _dc.AddParameter("@bor_id", borrowerId);
        _dc.Execute("sproc_FilterByFirstAndLastNameAndId");
    }

}