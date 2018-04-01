using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReservationCollection
/// </summary>
public class ReservationCollection
{
    private DataConnection _dc;
    public Reservation Reservation { get; set; } = new Reservation();
    public ReservationCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ReservationCollection(string borrowerId)
    {
        FilterReservationsByBorrower(borrowerId);
    }

    public List<Reservation> ReservationList =>
        (from DataRow row in _dc.DataTable.Rows select new Reservation
        {
            ReservationId = row["res_id"].ToString(),
            ReservationDate = Convert.ToDateTime(row["res_date"]),
            ClearedDate = DBNull.Value.Equals(row["res_cleared_date"]) ? (DateTime?)null : Convert.ToDateTime(row["res_cleared_date"]),
            BorrowerId = row["fk2_bor_id"].ToString(),
            ReservedIsbn = row["fk1_isbn"].ToString()
        }).ToList();

    public void FilterReservationsByBorrower(string borrowerId)
    {
        _dc = new DataConnection();
        _dc.AddParameter("@bor_id", borrowerId);
        _dc.Execute("sproc_GetReservationsByBorrower");
    }

    public void AddReservation()
    {
        _dc = new DataConnection();
        _dc.AddParameter("@res_id", Reservation.ReservationId);
        _dc.AddParameter("@fk2_bor_id", Reservation.BorrowerId);
        _dc.AddParameter("@fk1_isbn", Reservation.ReservedIsbn);
        _dc.Execute("sproc_AddReservation");
    }
}