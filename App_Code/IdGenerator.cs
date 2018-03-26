using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IdGenerator
/// </summary>
public class IdGenerator
{
    private DataConnection _dc;
  

    public string BookCopy()
    {
        _dc = new DataConnection();
        _dc.Execute("sproc_GetAllBookCopyBarcodes");
        var barcodes = (from DataRow row in _dc.DataTable.Rows select row["cop_barcode"])
            .Select(barcode => Convert.ToInt32(barcode.ToString())).ToList();
        barcodes.Sort();
        int firstAvailable = Enumerable.Range(1, Int32.MaxValue).Except(barcodes).First();

        return firstAvailable.ToString().PadLeft(12, '0');
    }

    public string FineId()
    {
        _dc = new DataConnection();
        _dc.Execute("sproc_GetAllFineIds");
        var fineIds = (from DataRow row in _dc.DataTable.Rows select row["fine_id"])
            .Select(id => Convert.ToInt32(id.ToString().Substring(1))).ToList();
        fineIds.Sort();
        int firstAvailable = Enumerable.Range(1, Int32.MaxValue).Except(fineIds).First();
        return "F"+firstAvailable.ToString().PadLeft(7, '0');
    }

    public string LoanId()
    {
        _dc = new DataConnection();
        _dc.Execute("sproc_GetAllLoanIds");
        var loanIds = (from DataRow row in _dc.DataTable.Rows select row["loan_id"])
            .Select(id => Convert.ToInt32(id.ToString().Substring(2))).ToList();
        loanIds.Sort();
        int firstAvailable = Enumerable.Range(1, Int32.MaxValue).Except(loanIds).First();
        return "LN" + firstAvailable.ToString().PadLeft(6, '0');
    }

    public string PaymentId()
    {
        _dc = new DataConnection();
        _dc.Execute("sproc_GetAllPaymentIds");
        var paymentIds = (from DataRow row in _dc.DataTable.Rows select row["pmt_id"])
            .Select(id => Convert.ToInt32(id.ToString().Substring(3))).ToList();
        paymentIds.Sort();
        int firstAvailable = Enumerable.Range(1, Int32.MaxValue).Except(paymentIds).First();
        return "PMT" + firstAvailable.ToString().PadLeft(5, '0');
    }

    public string ReservationId()
    {
        _dc = new DataConnection();
        _dc.Execute("sproc_GetAllReservationIds");
        var reservationIds = (from DataRow row in _dc.DataTable.Rows select row["res_id"])
            .Select(id => Convert.ToInt32(id.ToString().Substring(1))).ToList();
        reservationIds.Sort();
        int firstAvailable = Enumerable.Range(1, Int32.MaxValue).Except(reservationIds).First();
        return "R" + firstAvailable.ToString().PadLeft(7, '0');
    }

    public string GenreId()
    {
        _dc = new DataConnection();
        _dc.Execute("sproc_GetAllGenreCodes");
        var genreCode = (from DataRow row in _dc.DataTable.Rows select row["genre_code"])
            .Select(id => Convert.ToInt32(id.ToString().Substring(1))).ToList();
        genreCode.Sort();
        int firstAvailable = Enumerable.Range(1, Int32.MaxValue).Except(genreCode).First();
        return "G" + firstAvailable.ToString().PadLeft(3, '0');
    }
}