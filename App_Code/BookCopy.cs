/// <summary>
/// Summary description for BookCopy
/// </summary>
public class BookCopy
{
    public string Barcode { get; set; }
    public string LoanType { get; set; }
    public string Status { get; set; }
    public string Condition { get; set; }
    public string CopyIsbn { get; set; }

    public bool Find(string barcode)
    {
        var dc = new DataConnection();

        dc.AddParameter("@cop_barcode", barcode);
        dc.Execute("sproc_GetBookCopyByBarcode");

        if (dc.Count != 1) return false;

        var copyRow = dc.DataTable.Rows[0];

        Barcode = copyRow["cop_barcode"].ToString();
        LoanType = copyRow["cop_loan_type"].ToString().Trim();
        Status = copyRow["cop_status"].ToString().Trim();
        Condition = copyRow["cop_condition"].ToString().Trim();
        CopyIsbn = copyRow["fk1_isbn"].ToString().Trim();

        return true;
    }
}