/// <summary>
/// Summary description for BookCopy
/// </summary>
public class BookCopy
{
    //Create properties reflecting attributes of a record in a book copy table
    public string Barcode { get; set; }
    public string LoanType { get; set; }
    public string Status { get; set; }
    public string Condition { get; set; }
    public string CopyIsbn { get; set; }

    //Method checks if there is a record of a book copy with passed in barcode in the database
    // if found sets properties on a book copy object
    public bool Find(string barcode)
    {
        //Connection to the database
        var dc = new DataConnection();
        //Pass parameter to the stored procedure
        dc.AddParameter("@cop_barcode", barcode);
        //Execute stored procedure
        dc.Execute("sproc_GetBookCopyByBarcode");
        //If returned results dont contain exactly one record return false
        if (dc.Count != 1) return false;
        //Sets object properties to coresponding rows returned from db and returns true
        var copyRow = dc.DataTable.Rows[0];

        Barcode = copyRow["cop_barcode"].ToString();
        LoanType = copyRow["cop_loan_type"].ToString().Trim();
        Status = copyRow["cop_status"].ToString().Trim();
        Condition = copyRow["cop_condition"].ToString().Trim();
        CopyIsbn = copyRow["fk1_isbn"].ToString().Trim();

        return true;
    }

   
}