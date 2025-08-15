using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class RegistrationDetail
{
    public int RegistrationId { get; set; }

    public string RegistrationNum { get; set; } = null!;

    public int EventBatchId { get; set; }

    public int MemberId { get; set; }

    public decimal? AmountDue { get; set; }

    public DateTime RegistrationDateTime { get; set; }

    public int CurrentStatus { get; set; }

    public string? InternalRemarks { get; set; }
}
