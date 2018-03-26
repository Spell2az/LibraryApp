using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Borrower
/// </summary>
public class Borrower
{
    public string BorrowerId { get; set; }
    public string BorrowerType { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string  Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string TelNumber { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }

    public Borrower()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Find(string borrowerId)
    {
        var dc = new DataConnection();
        dc.AddParameter("@bor_id", borrowerId);
        dc.Execute("sproc_GetBorrowerById");

        if (dc.Count != 1) return false;

        var row = dc.DataTable.Rows[0];

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
}