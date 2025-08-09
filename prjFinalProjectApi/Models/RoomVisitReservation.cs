using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class RoomVisitReservation
{
    public int FReservationId { get; set; }

    public string FName { get; set; } = null!;

    public string FEmail { get; set; } = null!;

    public string FPhoneOrLineId { get; set; } = null!;

    public DateTime FReservationDate { get; set; }

    public DateTime? FCreatedAt { get; set; }
}
