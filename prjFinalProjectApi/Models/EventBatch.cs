using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EventBatch
{
    public int BatchId { get; set; }

    public int EventId { get; set; }

    public DateTime EventDateTimeStart { get; set; }

    public DateTime EventDateTimeEnd { get; set; }

    public DateTime RegistrationDateStart { get; set; }

    public DateTime RegistrationDateEnd { get; set; }

    public int Status { get; set; }

    public string Organizer { get; set; } = null!;

    public string TargetAudience { get; set; } = null!;

    public int ContactPersonId { get; set; }

    public string ContactPhone { get; set; } = null!;

    public string EventLocation { get; set; } = null!;

    public int? Quota { get; set; }

    public string Description { get; set; } = null!;

    public string? MedicalAid { get; set; }

    public decimal? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }
}
