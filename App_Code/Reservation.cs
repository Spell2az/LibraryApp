using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Reservation
/// </summary>
public class Reservation
{
    public string ReservationId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime? ClearedDate { get; set; }
    public string BorrowerId { get; set; }
    public string ReservedIsbn { get; set; }
    public Reservation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Find(string reservationId)
    {
        var dc = new DataConnection();
        dc.AddParameter("@res_id", reservationId);
        dc.Execute("sproc_GetReservationById");

        if (dc.Count != 1) return false;

        var row = dc.DataTable.Rows[0];
        ReservationId = row["res_id"].ToString();
        ReservationDate = Convert.ToDateTime(row["res_date"]);
        ClearedDate = DBNull.Value.Equals(row["res_cleared_date"]) ? (DateTime?) null : Convert.ToDateTime(row["res_cleared_date"]);
        BorrowerId = row["fk2_bor_id"].ToString();
        ReservedIsbn = row["fk1_isbn"].ToString();

        return true;
    }
}