using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EventTemplate
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public string Organizer { get; set; } = null!;

    public string TargetAudience { get; set; } = null!;

    public int CategoryId { get; set; }

    public int Status { get; set; }

    public int ContactPersonId { get; set; }

    public string ContactPhone { get; set; } = null!;

    public string EventLocation { get; set; } = null!;

    public int Quota { get; set; }

    public string Description { get; set; } = null!;

    public string? MedicalAid { get; set; }

    public decimal? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }
}
