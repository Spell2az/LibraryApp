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
    private DataConnection _dc;
    public Borrower Borrower { get; set; } = new Borrower();

    public BorrowerCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

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
}