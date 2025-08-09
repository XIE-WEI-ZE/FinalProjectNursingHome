using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CareRequest
{
    public int RequestId { get; set; }

    public int? FMemberId { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? Address { get; set; }

    public string? ServiceType { get; set; }

    public DateTime? RequestTime { get; set; }

    public string? Status { get; set; }
}
