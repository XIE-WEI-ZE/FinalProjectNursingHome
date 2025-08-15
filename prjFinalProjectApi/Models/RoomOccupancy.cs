using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class RoomOccupancy
{
    public int FOccupancyId { get; set; }

    public int? FMemberId { get; set; }

    public int FBedId { get; set; }

    public DateTime? FCheckInDate { get; set; }

    public DateTime? FCheckOutDate { get; set; }

    public int? FBillingAmount { get; set; }

    public DateTime? FBillingDate { get; set; }

    public string? FPaymentMethod { get; set; }

    public bool? FBillingStatus { get; set; }

    public virtual RoomBed FBed { get; set; } = null!;
}
