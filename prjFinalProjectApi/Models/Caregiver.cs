using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class Caregiver
{
    public int CaregiverId { get; set; }

    public int? EmployeeId { get; set; }

    public bool? IsOnline { get; set; }

    public double? CurrentLat { get; set; }

    public double? CurrentLng { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
