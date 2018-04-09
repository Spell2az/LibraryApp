using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Borrower
/// </summary>
public class Borrower
{

    //Create properties reflecting attributes of a record book borrower table
    public string BorrowerId { get; set; }
    public string BorrowerType { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string TelNumber { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }

    //gets list of loans for current borrower
    public List<Loan> Loans
    {
        get
        {
            if (BorrowerId!= null)
            {
                var loans = new LoanCollection(BorrowerId);
                return loans.LoanList;
            }
            return null;
        }
    }
    //gets list of fines for current borrower
    public List<Fine> Fines
    {
        get
        {
            if (BorrowerId != null)
            {
                var fines = new FineCollection(BorrowerId);
                return fines.FineList;
            }
            return null;
        }
    }
    //gets list of reservations for current borrower
    public List<Reservation> Reservations
    {
        get
        {
            if (BorrowerId != null)
            {
                var reservations = new ReservationCollection(BorrowerId);
                return reservations.ReservationList;
            }
            return null;
        }
    }

    public Borrower()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //Method checks if there is a record of a borrower with passed in borrowerId in the database
    // if found sets properties on a borrower object
    public bool Find(string borrowerId)
    {
        //Connection to the database
        var dc = new DataConnection();
        //Pass parameter to the stored procedure
        dc.AddParameter("@bor_id", borrowerId);
        //Execute stored procedure
        dc.Execute("sproc_GetBorrowerById");
        //If returned result doesn't contain exactly one record return false
        if (dc.Count != 1) return false;

        var row = dc.DataTable.Rows[0];
        //Sets object properties to coresponding columns returned from db and returns true
        BorrowerId = row["bor_id"].ToString();
        BorrowerType = row["fk1_bor_type_id"].ToString();
        FirstName = row["bor_firstname"].ToString();
        LastName = row["bor_surname"].ToString();
        Address1 = row["bor_address_1"].ToString();
        Address2 = row["bor_address_2"].ToString();
        Address3 = row["bor_address_3"].ToString();
        TelNumber = row["bor_tel"].ToString();
        Email = row["bor_email"].ToString();
        Status = row["bor_status"].ToString();
        return true;
    }

    public string GetBorrowerTypeDescription(string borrowerType)
    {
        var dc = new DataConnection();
        dc.AddParameter("@bor_type_id", borrowerType);
        dc.Execute("sproc_GetBorrowerDescriptionByTypeId");

        if (dc.Count != 1) return "";

        return dc.DataTable.Rows[0]["bor_type_name"].ToString();
    }
    //public DataTable GetAllUserDetails(string borrowerId)
    //{
    //    var dc = new DataConnection();
    //    dc.AddParameter("@bor_id", borrowerId);
    //    dc.Execute("sproc_Get")
    //}


    public int GetBorrowerMaxLoans()
    {
        var dc = new DataConnection();
        dc.AddParameter("@bor_type_id", BorrowerType);
        dc.Execute("sproc_GetBorrowerMaxLoans");

        if (dc.Count != 1) return 0;


        return Convert.ToInt32(dc.DataTable.Rows[0]["normal_max_loans"]);

    }
}